using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.Repositorio.Repositories;
using SpaceLock.WEB.Areas.AreaRestrita.Models.Espaco;
using SpaceLock.WEB.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    [Authorize]
    public class EspacoController : Controller
    {

        private IEspacoRepository repository;

        public EspacoController(IEspacoRepository repository)
        {
            this.repository = repository;
        }

        // GET: AreaRestrita/Espaco
        [NoCache]
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: AreaRestrita/Espaco
        [NoCache]
        public ActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CadastrarEspaco(EspacoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoEventoRepository rep = new TipoEventoRepository();

                    List<TipoEvento> lista = new List<TipoEvento>();
                    foreach(int i in model.IdEventos)
                    {
                        TipoEvento t = rep.FindById(i);

                        lista.Add(t);
                    }
                    Espaco e = new Espaco();

                    e.NomeEspaco = model.NomeEspaco;
                    e.Tamanho = model.Tamanho;
                    e.Capacidade = model.Capacidade;
                    e.UnidadeMedida = model.UnidadeMedida;
                    e.Endereco = model.Endereco;
                    e.Numero = model.Numero;
                    e.Complemento = model.Complemento;
                    e.Bairro = model.Bairro;
                    e.Cidade = model.Cidade;
                    e.Uf = model.Uf;
                    e.Cep = model.Cep;
                    e.TipoEventos = lista;
                    e.DataCadastro = DateTime.Now;
                    e.IdUsuario = model.IdUsuario;

                    repository.Insert(e);

                    return Json("Espaço cadastrado com sucesso!");
                }
                catch(Exception e)
                {
                    return Json(e.Message);
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

        [HttpPut]
        public JsonResult AtualizarEspaco(EspacoAtualizacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Espaco e = new Espaco();

                    e.IdEspaco = model.IdEspaco;
                    e.NomeEspaco = model.NomeEspaco;
                    e.Tamanho = model.Tamanho;
                    e.Capacidade = model.Capacidade;
                    e.UnidadeMedida = model.UnidadeMedida;
                    e.Endereco = model.Endereco;
                    e.Numero = model.Numero;
                    e.Complemento = model.Complemento;
                    e.Bairro = model.Bairro;
                    e.Cidade = model.Cidade;
                    e.Uf = model.Uf;
                    e.Cep = model.Cep;
                    e.DataCadastro = DateTime.Now;
                    e.IdUsuario = model.IdUsuario;

                    repository.Update(e);

                    return Json("Espaço cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    return Json(e.Message);
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
        public JsonResult ConsultarEspaco(int idUsuario)
        {
            try
            {
                List<EspacoConsultaViewModel> lista = new List<EspacoConsultaViewModel>();

                foreach(var e in repository.ListarPorUsuario(idUsuario))
                {
                    EspacoConsultaViewModel model = new EspacoConsultaViewModel();

                    model.IdEspaco = e.IdEspaco;
                    model.NomeEspaco = e.NomeEspaco;
                    model.Tamanho = e.Tamanho;
                    model.Capacidade = e.Capacidade;
                    model.UnidadeMedida = e.UnidadeMedida;
                    model.Endereco = e.Endereco;
                    model.Numero = e.Numero;
                    model.Complemento = e.Complemento;
                    model.Bairro = e.Bairro;
                    model.Cidade = e.Cidade;
                    model.Uf = e.Uf;
                    model.Cep = e.Cep;
                    model.IdUsuario = e.IdUsuario;

                    lista.Add(model);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json($"Ocorreu um erro interno: {e.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }
}