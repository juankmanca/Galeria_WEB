using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.Models.Clases;
using Galeria_WEB.DAO;

namespace Galeria_WEB.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Usuario user = new Usuario();
            this.Session["Login"] = null;
            var data = Request.QueryString["msg"];
            if(data != null && !data.Equals(""))
            {
                ViewData["Error"] = data;
            }
            ViewBag.Message = user;
            return View();
        }

        public ActionResult About()
        {
            Usuario user = new Usuario();
            this.Session["Login"] = null;
            ViewBag.Message = user;
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {

            string sw = Request["sw"];

            if (sw.Equals("1")) {
                return View("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Contact()
        {
            Usuario user = new Usuario();
            this.Session["Login"] = null;
            ViewBag.Message = user;
            return View();
        }
        public ActionResult Registro()
        {
            Usuario user = new Usuario();
            this.Session["Login"] = null;

            ViewBag.Message = "Formulario de registros";

            var data = Request.QueryString["msg"];
            if(data != null && !data.Equals(""))
            {
                ViewData["Error"] = data;
            }
            ViewBag.Message = user;
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin()
        {
            daoRead dbRead = new daoRead();
            List<Dispositivo> userList = new List<Dispositivo>();

            string nombreUsuario = Request["Username"];
            string contrasena = Request["password"];
            if (nombreUsuario.Equals("") || contrasena.Equals(""))
            {
                ViewData["Error"] = "Todos los campos son obligatorios";
                return View("index");
               // return RedirectToAction("Index", "Home", new { msg = "Todos los campos son obligatorios" });
            }
            else // Si no ingreso ningun campo vacio
            {
                Usuario user = new Usuario(null, nombreUsuario,0, null, null, 0, null,contrasena,null,null);

                 string aux = dbRead.ValidarUserPass(user);
                switch (aux) 
                {
                    case "Usuario":
                        //userList = dbRead.TraerUsuarios();
                        //ViewData["userList"] = userList;
                        //this.Session["Login"] = user.Username;
                        ViewBag.Message = user;
                        ViewData["aux"] = aux;

                        //ViewBag.Message = user;
                        //this.Session["Login"] = user.Nombre;
                        return RedirectToAction("Welcome", "Usuario",user);
                    case "Administrador":
                        return RedirectToAction("Welcome", "Administrador",user);
                        
                    case "Moderador":
                        return RedirectToAction("Welcome", "Moderador",user);
                    default:

                        ViewData["Error"] = aux;
                        return View("index");
                        //return RedirectToAction("Index", "Home", new { msg = "Usuario o contraseña incorrectas" });

                }
            }
        }




    }
    }