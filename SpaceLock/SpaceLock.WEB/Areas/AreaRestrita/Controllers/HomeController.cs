using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    public class HomeController : Controller
    {
        // GET: AreaRestrita/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}