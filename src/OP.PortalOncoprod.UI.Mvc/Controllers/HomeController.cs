using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OP.PortalOncoprod.Application.ViewModels;
using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Application.ViewModels;

namespace SistemaIndexador.UI.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        ITabelaRegrasDMSAppService _tabelaRegrasDMSAppService;
        private static readonly ImageConverter _imageConverter = new ImageConverter();


        public HomeController(ITabelaRegrasDMSAppService TabelaRegrasDMSAppService)
        {
            _tabelaRegrasDMSAppService = TabelaRegrasDMSAppService;
        }

        public ActionResult Index()
        {
            DadosIndexacaoViewModel model = ListarDocumentos();
            model.ListaAquivos = ListarArquivosParaIndexar();

            return View(model);
        }

        private DadosIndexacaoViewModel ListarDocumentos()
        {
            DadosIndexacaoViewModel model = new DadosIndexacaoViewModel();
            model.TipoDoc = new List<string>();


            var listarTipos = _tabelaRegrasDMSAppService.ObterTodos();

            foreach (var item in listarTipos)
            {
                model.TipoDoc.Add(item.DescricaoOutrosDocs);
            }

            return model;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public void Upload(DadosIndexacaoViewModel data)
        {
            var regraSelecionada = _tabelaRegrasDMSAppService.ObterTodos().Find(f => f.DescricaoOutrosDocs.Contains(data.TipoDocSelected));
            string directory = @"C:\Temp\UploadIndexador\new\";
            List<byte[]> pdfs = new List<byte[]>();

            for (int i = 0; i < Request.Files.Keys.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {

                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                        pdfs.Add(thePictureAsBytes);
                    }
                    //string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);

                    //    file.SaveAs(Path.Combine(directory, fileName));
                }
            }
            var fileName = data.matricula + "-" + data.cpf.Replace(".", "").Replace("-", "") + "-" + regraSelecionada.Regra + ".PDF";//Path.GetFileName(file.FileName);

            var mergePDF = MergePdf(pdfs);

            System.IO.FileStream stream = new FileStream(directory + fileName, FileMode.CreateNew);
            System.IO.BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(mergePDF, 0, mergePDF.Length);
            writer.Close();
        }
        public static byte[] MergePdf(List<byte[]> pdfs)
        {
            List<PdfSharp.Pdf.PdfDocument> lstDocuments = new List<PdfSharp.Pdf.PdfDocument>();
            foreach (var pdf in pdfs)
            {
                lstDocuments.Add(PdfSharp.Pdf.IO.PdfReader.Open(new MemoryStream(pdf), PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import));
            }

            using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
            {
                for (int i = 1; i <= lstDocuments.Count; i++)
                {
                    foreach (PdfSharp.Pdf.PdfPage page in lstDocuments[i - 1].Pages)
                    {
                        outPdf.AddPage(page);
                    }
                }

                MemoryStream stream = new MemoryStream();
                outPdf.Save(stream, false);
                byte[] bytes = stream.ToArray();

                return bytes;
            }
        }



        public void RenameArquivos(DadosIndexacaoViewModel model)
        {
            MoverERenomearArquivos();
        }


        private void MoverERenomearArquivos()
        {
            DirectoryInfo DirOld = new DirectoryInfo(@"C:\Temp\UploadIndexador\old\");
            string sourcePath = @"C:\Temp\UploadIndexador\old\";
            string targetPath = @"C:\Temp\UploadIndexador\new\";

            Directory.CreateDirectory(targetPath);

            FileInfo[] Files = DirOld.GetFiles("*", SearchOption.AllDirectories);


            foreach (FileInfo File in Files)
            {

                string FileName = File.FullName.Replace(DirOld.FullName, "");
                string sourceFile = Path.Combine(sourcePath, FileName);
                string destFile = Path.Combine(targetPath, FileName);

                System.IO.File.Copy(sourceFile, destFile, true);


                if (Directory.Exists(sourcePath))
                {
                    string[] files = Directory.GetFiles(sourcePath);

                    foreach (string s in files)
                    {
                        FileName = Path.GetFileName(s);
                        destFile = Path.Combine(targetPath, FileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
            }
        }


        private List<DadosArquivoViewModel> ListarArquivosParaIndexar()
        {

            DirectoryInfo DirOld = new DirectoryInfo(@"C:\Temp\UploadIndexador\new\");
            List<DadosArquivoViewModel> lista = new List<DadosArquivoViewModel>();

            FileInfo[] Files = DirOld.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                DadosArquivoViewModel dadosArquivoViewModel = new DadosArquivoViewModel();

                dadosArquivoViewModel.Nome = File.FullName.Replace(DirOld.FullName, "");
                byte[] arquivoBuffer;

                arquivoBuffer = System.IO.File.ReadAllBytes(File.FullName);

                dadosArquivoViewModel.ImagemArquivo = Convert.ToBase64String(arquivoBuffer);

                lista.Add(dadosArquivoViewModel);
            }

            return lista;

        }
      
    }
}