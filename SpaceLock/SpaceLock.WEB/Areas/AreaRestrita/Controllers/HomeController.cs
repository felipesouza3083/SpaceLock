using SpaceLock.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceLock.WEB.Areas.AreaRestrita.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: AreaRestrita/Home
        [NoCache]
        public ActionResult Index()
        {
            return View();
        }
    }
}