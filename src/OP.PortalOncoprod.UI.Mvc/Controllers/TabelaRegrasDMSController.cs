using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Application.ViewModels;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Services;
using SistemaIndexador.Infra.Data.Context;
using SistemaIndexador.UI.Mvc.Controllers;
using SistemaIndexador.UI.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace OP.PortalOncoprod.UI.Mvc.Controllers
{
    [RoutePrefix("TabelaRegrasDMS")]
    [Route("{action=listar}")]
    public class TabelaRegrasDMSController : BaseController
    {
        private readonly ITabelaRegrasDMSAppService _TabelaRegrasDMSAppService;

        public TabelaRegrasDMSController(ITabelaRegrasDMSAppService TabelaRegrasDMSAppService)
        {
            _TabelaRegrasDMSAppService = TabelaRegrasDMSAppService;
        }

        [Route("listar")]
        [Authorize]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _TabelaRegrasDMSAppService.ObterTodos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;

            return View(paged.List);
        }

        // POST: TabelaPrecoOncoprod/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            TabelaRegrasDMSViewModel TabelaRegrasDMSViewModel)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)TabelaRegrasDMSViewModel);
            TabelaRegrasDMSViewModel = this._TabelaRegrasDMSAppService.Adicionar(TabelaRegrasDMSViewModel);
            return (ActionResult)this.RedirectToAction("Index");
        }

        [Route("Visualizar/{id}")]
        [Authorize]
        public ActionResult Visualizar(int? id)
        {
            if (id.Equals((object)null))
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TabelaRegrasDMSViewModel oncoprodViewModel = this._TabelaRegrasDMSAppService.ObterPorIdTabela(id.Value);
            if (!oncoprodViewModel.Equals((object)null))
            {
                Usuario usuario = (Usuario)this.Session["USUARIO"];
                if (usuario != null)
                {
                    int num = usuario.usuarioId.ToUpper().Equals("RENATAP") ? 1 : (usuario.usuarioId.ToUpper().Equals("THIAGOA") ? 1 : 0);
                    //    oncoprodViewModel.AcessoGerente = num == 0 ? "REP" : "GER";
                }
                else
                    this.Response.Redirect("/Usuario/Logout");
                oncoprodViewModel.PaginasAcessos = (List<UsuarioTabelaRegrasDMSViewModel>)this.Session["LISTA_USUARIO"];
                if (oncoprodViewModel == null)
                    return (ActionResult)this.HttpNotFound();
            }
            return (ActionResult)this.View((object)oncoprodViewModel);
        }

        public ActionResult ImportaExcel() => (ActionResult)this.View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportaExcel(HttpPostedFileBase postedFile)
        {
            TabelaRegrasDMSViewModel oncoprodViewModel = new TabelaRegrasDMSViewModel();
            if (this.ModelState.IsValid)
            {
                if (postedFile == null)
                    return this.View().Error("Nenhum arquivo foi selecionado!");
                if (postedFile.FileName.Substring(postedFile.FileName.IndexOf('.')).ToUpper() != ".CSV")
                    return this.View().Error("O formato do arquivo não é suportado, O tipo de arquivo suportado é CSV.");
                this._TabelaRegrasDMSAppService.ExcluirExcel();
                string empty = string.Empty;
                if (postedFile != null)
                {
                    string path = this.Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    string str = path + Path.GetFileName(postedFile.FileName);
                    Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(str);
                    DataTable dataTable = new DataTable();
                    Regex regex1 = new Regex("\r\n");
                    Regex regex2 = new Regex("\t");
                    StreamReader streamReader = new StreamReader(str, Encoding.GetEncoding(1252));
                    string end = streamReader.ReadToEnd();
                    string[] strArray1 = regex1.Split(end);
                    streamReader.Close();
                    string[] strArray2 = strArray1[0].Split(';');
                    int length = strArray2.GetLength(0);
                    for (int index = 0; index < length; ++index)
                        dataTable.Columns.Add(strArray2[index].ToString(), typeof(string));
                    for (int index = 0; index < strArray1.Length; ++index)
                    {
                        if (strArray1[index].IndexOf("CÓD") < 0 && !string.IsNullOrEmpty(strArray1[index]))
                        {
                            string[] strArray3 = strArray1[index].Split(';');
                            DataRow row = dataTable.NewRow();
                            for (int columnIndex = 0; columnIndex < length; ++columnIndex)
                                row[columnIndex] = (object)strArray3[columnIndex];
                            dataTable.Rows.Add(row);
                        }
                    }
                    DataTable dt = dataTable;
                    if (dt.Rows.Count.Equals(0))
                        return this.View().Error("Não foi encontrado nenhum registro na planilha!");
                    this.InseraTabelaV4(dt);
                }
            }
            return this.RedirectToAction("Index").Success("Planilha importada com sucesso.");
        }

        public DataSet InseraTabelaV4(DataTable dt)
        {
            DataSet dataSet = new DataSet("Tabelas");
            bool flag = false;
            DataTable dt1 = new DataTable();
            
            dt1.Columns.Add("Infotipo", typeof(string));
            dt1.Columns.Add("Subinfotipo", typeof(string));
            dt1.Columns.Add("FormularioKitAdmissao", typeof(string));
            dt1.Columns.Add("OutrosDocumentosControlados", typeof(string));
            dt1.Columns.Add("Obrigatorio", typeof(string));
            dt1.Columns.Add("Regra", typeof(string));
            dt1.Columns.Add("DescricaoOutrosDocs", typeof(string));
            dt1.Columns.Add("NomeFunçcao", typeof(string));
            dt1.Columns.Add("TipoMedida", typeof(string));
            dt1.Columns.Add("NomeUsuario", typeof(string));
            dt1.Columns.Add("Data", typeof(string));
            dt1.Columns.Add("CampoDaCtg", typeof(string));
            dt1.Columns.Add("GrupoAutorizacoes", typeof(string));
            dt1.Columns.Add("CodGrupo", typeof(string));

            for (int index = 0; index < dt.Rows.Count; ++index)
                dt1.Rows.Add((object)dt.Rows[index][0].ToString(), 
                             (object)dt.Rows[index][1].ToString(), 
                             (object)dt.Rows[index][2].ToString(), 
                             (object)dt.Rows[index][3].ToString(), 
                             (object)dt.Rows[index][4].ToString(), 
                             (object)dt.Rows[index][5].ToString(), 
                             (object)dt.Rows[index][6].ToString(), 
                             (object)dt.Rows[index][7].ToString(), 
                             (object)dt.Rows[index][8].ToString(), 
                             (object)dt.Rows[index][9].ToString(), 
                             (object)dt.Rows[index][10].ToString(), 
                             (object)dt.Rows[index][11].ToString(), 
                             (object)dt.Rows[index][12].ToString(), 
                             (object)dt.Rows[index][13].ToString());
            flag = this.InsertBulkCopy(dt1, "TabelaRegrasDMS");
            return dataSet;
        }

        public DataSet InseraTabela(DataTable dt)
        {
            DataSet dataSet = new DataSet("Tabelas");
            bool flag = false;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("codigo", typeof(string));
            dt1.Columns.Add("dataAlteracao", typeof(string));
            dt1.Columns.Add("margemMinima", typeof(string));
            dt1.Columns.Add("margemVenda", typeof(string));
            dt1.Columns.Add("descricao", typeof(string));
            dt1.Columns.Add("nomeQuimico", typeof(string));
            dt1.Columns.Add("laboratorio", typeof(string));
            dt1.Columns.Add("ncm", typeof(string));
            dt1.Columns.Add("lista", typeof(string));
            dt1.Columns.Add("categoria", typeof(string));
            dt1.Columns.Add("tipoArmazenamento", typeof(string));
            dt1.Columns.Add("produtoControlado", typeof(string));
            dt1.Columns.Add("exclusivoHospitalar", typeof(string));
            dt1.Columns.Add("tipo", typeof(string));
            dt1.Columns.Add("resolucao13", typeof(string));
            dt1.Columns.Add("origem", typeof(string));
            dt1.Columns.Add("ufLaboratorio", typeof(string));
            dt1.Columns.Add("observacao", typeof(string));
            dt1.Columns.Add("ean", typeof(string));
            dt1.Columns.Add("nivel", typeof(string));
            dt1.Columns.Add("aproximadoDeAumento", typeof(string));
            dt1.Columns.Add("PrVdRS", typeof(string));
            dt1.Columns.Add("vendaPara_SP", typeof(string));
            dt1.Columns.Add("vendaPara_CE", typeof(string));
            dt1.Columns.Add("vendaParaPE", typeof(string));
            dt1.Columns.Add("PrVd17_HOSPLOG_DF", typeof(string));
            dt1.Columns.Add("valorClienteGo", typeof(string));
            dt1.Columns.Add("PrVd175_RO", typeof(string));
            dt1.Columns.Add("PrVd18_HOSPLOG_DF", typeof(string));
            dt1.Columns.Add("Clientes_ES", typeof(string));
            dt1.Columns.Add("PrVd17_ONCOPROD_ES", typeof(string));
            dt1.Columns.Add("PrVd18_ONCOPROD_ES", typeof(string));
            dt1.Columns.Add("PrVd20_ONCOPROD_ES", typeof(string));
            dt1.Columns.Add("cmedPrecoFabrica_0", typeof(string));
            dt1.Columns.Add("cmedPrecoFabrica_17", typeof(string));
            dt1.Columns.Add("cmedPrecoFabrica_17_5", typeof(string));
            dt1.Columns.Add("cmedPrecoFabrica_18", typeof(string));
            dt1.Columns.Add("cmedPrecoFabrica_20", typeof(string));
            dt1.Columns.Add("cmedPmc_0", typeof(string));
            dt1.Columns.Add("cmedPmc_17", typeof(string));
            dt1.Columns.Add("cmedPmc_17_5", typeof(string));
            dt1.Columns.Add("cmedPmc_18", typeof(string));
            dt1.Columns.Add("cmedPmc_20", typeof(string));
            dt1.Columns.Add("Indicacao", typeof(string));
            for (int index = 0; index < dt.Rows.Count; ++index)
                dt1.Rows.Add((object)dt.Rows[index][0].ToString(), (object)dt.Rows[index][1].ToString(), (object)dt.Rows[index][2].ToString(), (object)dt.Rows[index][3].ToString(), (object)dt.Rows[index][4].ToString(), (object)dt.Rows[index][5].ToString(), (object)dt.Rows[index][6].ToString(), (object)dt.Rows[index][7].ToString(), (object)dt.Rows[index][8].ToString(), (object)dt.Rows[index][9].ToString(), (object)dt.Rows[index][10].ToString(), (object)dt.Rows[index][11].ToString(), (object)dt.Rows[index][12].ToString(), (object)dt.Rows[index][13].ToString(), (object)dt.Rows[index][14].ToString(), (object)dt.Rows[index][15].ToString(), (object)dt.Rows[index][16].ToString(), (object)dt.Rows[index][17].ToString(), (object)dt.Rows[index][18].ToString(), (object)dt.Rows[index][19].ToString(), (object)dt.Rows[index][20].ToString(), (object)dt.Rows[index][21].ToString(), (object)dt.Rows[index][22].ToString(), (object)dt.Rows[index][23].ToString(), (object)dt.Rows[index][24].ToString(), (object)dt.Rows[index][25].ToString(), (object)dt.Rows[index][26].ToString(), (object)dt.Rows[index][27].ToString(), (object)dt.Rows[index][28].ToString(), (object)dt.Rows[index][29].ToString(), (object)dt.Rows[index][30].ToString(), (object)dt.Rows[index][31].ToString(), (object)dt.Rows[index][32].ToString(), (object)dt.Rows[index][33].ToString(), (object)dt.Rows[index][34].ToString(), (object)dt.Rows[index][35].ToString(), (object)dt.Rows[index][36].ToString(), (object)dt.Rows[index][37].ToString(), (object)dt.Rows[index][38].ToString(), (object)dt.Rows[index][39].ToString(), (object)dt.Rows[index][40].ToString(), (object)dt.Rows[index][41].ToString(), (object)dt.Rows[index][42].ToString(), (object)dt.Rows[index][43].ToString());
            flag = this.InsertBulkCopy(dt1, "ksTabelaPrecoOncoprod_v3");
            return dataSet;
        }

        public bool InsertBulkCopy(DataTable dt, string Tabela)
        {
            SqlConnection connection;
            using (connection = new SqlConnection(Utility.CONNECTIONSTRING))
            {
                connection.Open();
                SqlTransaction externalTransaction = connection.BeginTransaction();
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepNulls, externalTransaction);
                sqlBulkCopy.DestinationTableName = Tabela;
                foreach (DataColumn column in (InternalDataCollectionBase)dt.Columns)
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                sqlBulkCopy.WriteToServer(dt);
                externalTransaction.Commit();
            }
            return true;
        }


    }
}