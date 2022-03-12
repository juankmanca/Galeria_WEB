using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Galeria_WEB.Controllers
{
    public class ModeradorController : Controller
    {
        // GET: Moderador
        public ActionResult Index()
        {
            return View("welcome");
        }
        public ActionResult Welcome()
        {
            return View();
        }
    }
}