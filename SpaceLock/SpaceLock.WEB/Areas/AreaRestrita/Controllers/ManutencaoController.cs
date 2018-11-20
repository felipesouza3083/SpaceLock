using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.WEB.Areas.AreaRestrita.Models.Manutenção;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    public class ManutencaoController : Controller
    {
        private IManutencaoRepository repository;

        public ManutencaoController(IManutencaoRepository repository)
        {
            this.repository = repository;
        }

        // GET: AreaRestrita/Manutencao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CadastraManutencao(ManutencaoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Manutencao m = new Manutencao();

                    m.DataInicio = model.DataInicio;
                    m.DataFim = model.DataFim;
                    m.Motivo = model.Motivo;
                    m.IdEspaco = model.IdEspaco;
                    m.IdUsuario = model.IdUsuario;

                    repository.Insert(m);

                    return Json("Manutenção cadastrada com sucesso.");
                }
                catch(Exception e)
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
    }
}