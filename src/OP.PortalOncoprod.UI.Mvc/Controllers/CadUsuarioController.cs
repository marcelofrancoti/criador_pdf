using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Application.ViewModels;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndexador.UI.Mvc.Controllers
{
    public class CadUsuarioController : Controller
    {

        private readonly IUsuarioAppService _usuarioApp;

        public CadUsuarioController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }


        public void RecarregarTabelaSelecionada(List<String> postData)
        {
            var teste = ViewData["NovoUsuario"];
        }

        // GET: CadUsuario
        public ActionResult Index()
        {

            

            var model = new UsuarioTabelaRegrasDMSViewModel();
            List<GrupoSistemaViewModel> grupos = new List<GrupoSistemaViewModel>();
            GrupoSistemaViewModel grupo = new GrupoSistemaViewModel()
            {
                grupoId = 0,
                nomeGrupo = "JSL"
            };
            grupos.Add(grupo);
            grupo = new GrupoSistemaViewModel()
            {
                grupoId = 1,
                nomeGrupo = "Movida"
            };
            grupos.Add(grupo);
            grupo = new GrupoSistemaViewModel()
            {
                grupoId = 2,
                nomeGrupo = "Original"
            };
            grupos.Add(grupo);
            grupo = new GrupoSistemaViewModel()
            {
                grupoId = 3,
                nomeGrupo = "CS Brasil"
            };
            grupos.Add(grupo);

            grupo = new GrupoSistemaViewModel()
            {
                grupoId = 4,
                nomeGrupo = "Grupo Vamos"
            };
            grupos.Add(grupo);

            model.listaGrupo = grupos;

            return View(model);
        }

        // GET: CadUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadUsuario/Create
        public ActionResult Create(string buscar, int pageNumber = 1)
        {
            var paged = _usuarioApp.ObterTodos();
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / 5);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;

            return View(paged.List);

        }

        public ActionResult ListaSelecionados(string buscar, int pageNumber = 1)
        {
            return PartialView();
        }

        // POST: CadUsuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
