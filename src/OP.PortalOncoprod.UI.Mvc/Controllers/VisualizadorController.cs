using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndexador.Application.ViewModels;

namespace OP.PortalOncoprod.UI.Mvc.Controllers
{
    public class VisualizadorController : Controller
    {
        // GET: Visualizador
        public ActionResult Index()
        {
            DadosIndexacaoViewModel model = new DadosIndexacaoViewModel();
            //model.ListaAquivos = ListarArquivosParaIndexar();

            return View(model);
        }

        //private List<string> ListarArquivosParaIndexar()
        //{

        //    DirectoryInfo DirOld = new DirectoryInfo(@"C:\Temp\UploadIndexador\new\");
        //    List<string> lista = new List<string>();


        //    FileInfo[] Files = DirOld.GetFiles("*", SearchOption.AllDirectories);
        //    foreach (FileInfo File in Files)
        //    {
        //        string FileName = @"C:\Temp\UploadIndexador\new\" + File.FullName.Replace(DirOld.FullName, "");
        //        lista.Add(FileName);
        //    }

        //    return lista;

        //}
    }
}