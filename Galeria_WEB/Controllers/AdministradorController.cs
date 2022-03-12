using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.Models.Clases;
using Galeria_WEB.DAO;

namespace Galeria_WEB.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View("Welcome");
        }

        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult AgregarDispositivo()
        {
            string nombre          = Request["nombre"];
            string serial          = Request["serial"] ;
            string marca           = Request["marca"];
            string tipoDispositivo = Request["tipo"];
            string disponibilidad  = Request["disponibilidad"];
            string descripcion     = Request["descripcion"];
            Dispositivo disp = new Dispositivo(nombre,serial,marca,tipoDispositivo,disponibilidad,descripcion);
            daoCreate create = new daoCreate();
            string err = create.AgregarDispositivo(disp);
            ViewData["err"] = err;
            return View();
        }
    }
}