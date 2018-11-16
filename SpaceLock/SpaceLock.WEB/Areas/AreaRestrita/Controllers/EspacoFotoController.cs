using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.WEB.Areas.AreaRestrita.Models.EspacoFoto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    [Authorize]
    public class EspacoFotoController : Controller
    {

        private IEspacoFotoRepository repository;

        public EspacoFotoController(IEspacoFotoRepository repository)
        {
            this.repository = repository;
        }

        // GET: AreaRestrita/EspacoFoto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SalvarFoto(EspacoFotoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                EspacoFoto ef = new EspacoFoto();

                ef.DataInsercao = DateTime.Now;
                ef.Foto = model.Foto;
                ef.IdEspaco = model.IdEspaco;

                repository.Insert(ef);

                return Json("Imagem salva com sucesso!");
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

        [HttpPost]
        public JsonResult UploadFoto(int idEspaco)
        {
            HttpPostedFileBase foto = null;
            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                foto = Request.Files[0];
            }
            string caminho = "";
            if (foto != null)
            {
                try
                {
                    caminho = Server.MapPath($"/Imagens/Espaco/{idEspaco}/");
                    //Se o caminho não existe, Cria
                    if (!Directory.Exists(caminho))
                    {
                        Directory.CreateDirectory(caminho);
                    }

                    caminho = caminho + Path.GetFileName(foto.FileName);
                    foto.SaveAs(caminho);
                    return Json("Imagem salva com sucesso!");
                }
                catch (Exception e)
                {
                    return Json($"Erro ao importar imagem {e.Message}");
                }
            }
            else
            {
                return Json("Nenhum arquivo selecionado!");
            }

        }

        [HttpGet]
        public JsonResult ListaFotoPorEspaco(int idEspaco)
        {
            try
            {
                List<EspacoFotoConsultaViewModel> lista = new List<EspacoFotoConsultaViewModel>();

                foreach(var tf in repository.ListarFotosPorEspaco(idEspaco))
                {
                    EspacoFotoConsultaViewModel model = new EspacoFotoConsultaViewModel();

                    model.IdEspacoFoto = tf.IdEspacoFoto;
                    model.Foto = tf.Foto;

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