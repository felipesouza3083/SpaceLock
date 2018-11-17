using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    public class AluguelController : Controller
    {

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

        [HttpGet]
        public JsonResult ListarEspacoPorCidade(string cidade)
        {
            try
            {

            }
            catch(Exception e)
            {
                return Json($"Ocorreu um erro:{e.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }
}