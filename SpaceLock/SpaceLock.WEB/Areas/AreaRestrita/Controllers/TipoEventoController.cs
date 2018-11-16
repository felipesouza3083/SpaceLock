using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.WEB.Areas.AreaRestrita.Models.Tipo_Evento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    public class TipoEventoController : Controller
    {
        private ITipoEventoRepository repository;

        public TipoEventoController(ITipoEventoRepository repository)
        {
            this.repository = repository;
        }

        // GET: AreaRestrita/TipoEvento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CadastrarTipoEvento(TipoEventoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoEvento te = new TipoEvento();

                    te.Descricao = model.Descricao;

                    repository.Insert(te);

                    return Json("Tipo de Evento cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    return Json($"Ocorreu um erro:{e.Message}");
                }
            }
            else
            {
                Hashtable erros = new Hashtable();

                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Count > 0)
                    {
                        erros[m.Key] = m.Value.Errors.Select(e => e.ErrorMessage);
                    }
                }

                return Json(erros);
            }
        }

        [HttpGet]
        public JsonResult ConsultarTipoEvento()
        {
            try
            {
                List<TipoEventoConsultaViewModel> lista = new List<TipoEventoConsultaViewModel>();

                foreach (var te in repository.FindAll())
                {
                    TipoEventoConsultaViewModel model = new TipoEventoConsultaViewModel();

                    model.IdTipoEvento = te.IdTipoEvento;
                    model.Descricao = te.Descricao;

                    lista.Add(model);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json($"Ocorreu um erro:{e.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }
}