using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.WEB.Areas.AreaRestrita.Models.Aluguel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    public class AluguelController : Controller
    {
        private IAluguelRepository repository;

        public AluguelController(IAluguelRepository repository)
        {
            this.repository = repository;
        }

        // GET: AreaRestrita/Aluguel
        public ActionResult Solicitar()
        {
            return View();
        }

        // GET: AreaRestrita/Aluguel
        public ActionResult MeusAlugueis()
        {
            return View();
        }

        // GET: AreaRestrita/Aluguel
        public ActionResult Solicitacoes()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SolicitarAluguel(AluguelSolicitacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Aluguel a = new Aluguel();

                    a.DataAlguel = model.DataAluguel;
                    a.HoraInicio = model.HorInicio;
                    a.HoraFim = model.HoraFim;
                    a.Descricao = model.DescricaoEvento;
                    a.IdEspaco = model.IdEspaco;
                    a.IdUsuario = model.IdUsuario;
                    a.ValorAluguel = 0;

                    repository.Insert(a);

                    return Json("Aluguel solicitado com sucesso!");
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
        public JsonResult ConsultarAlgueisDoUsuario(int idUsuario)
        {
            try
            {
                List<AluguelConsultaUsuarioViewModel> lista = new List<AluguelConsultaUsuarioViewModel>();

                foreach(var a in repository.ListaAlugueisPorUsuario(idUsuario))
                {
                    AluguelConsultaUsuarioViewModel model = new AluguelConsultaUsuarioViewModel();

                    model.IdAluguel = a.IdAluguel;
                    model.DataAluguel = a.DataAlguel;
                    model.HoraInicio = a.HoraInicio.ToString();
                    model.HoraFim = a.HoraFim.ToString();
                    model.Descricao = a.Descricao;
                    model.NomeEspaco = a.Espaco.NomeEspaco;

                    lista.Add(model);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json($"Ocorreu um erro: {e.Message}", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ConsultarAlgueisDoEspaco(int idEspaco)
        {
            try
            {
                List<AluguelConsultaEspacoViewModel> lista = new List<AluguelConsultaEspacoViewModel>();

                foreach (var a in repository.ListaAlugueisPorEspaco(idEspaco))
                {
                    AluguelConsultaEspacoViewModel model = new AluguelConsultaEspacoViewModel();

                    model.IdAluguel = a.IdAluguel;
                    model.DataAluguel = a.DataAlguel;
                    model.HoraInicio = a.HoraInicio.ToString();
                    model.HoraFim = a.HoraFim.ToString();
                    model.Descricao = a.Descricao;
                    model.NomeUsuario = a.Usuario.Nome;

                    lista.Add(model);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json($"Ocorreu um erro: {e.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }
}