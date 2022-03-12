using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.DAO;
using Galeria_WEB.Models.Clases;

namespace Galeria_WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View("Welcome");
        }
        
        public ActionResult Welcome(Usuario user)
        {

            daoRead dbRead = new daoRead();
            ViewData["userList"] = dbRead.TraerDispositivos();
            ViewBag.Message = user;
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {

            string name = Request["username"];
            string session = Request["session"];
            Usuario user = new Usuario(null, name, 0, null, null, 0,null,null,null,null);

            Usuario userLoged = new Usuario(null, session, 0, null, null, 0, null, null, null, null);

            daoDelete dbDelete = new daoDelete();
            daoRead dbRead = new daoRead();
            if (dbDelete.EliminarRegistro(user))
            {

                ViewData["userList"] = dbRead.TraerDispositivos();
                ViewBag.Message = userLoged;
                return View("Welcome");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {

            string username = Request["username"];
            string session = Request["session"];
            Usuario user = new Usuario(null, username, 0, null, null, 0, null, null, null, null);

            Usuario userLoged = new Usuario(null, session, 0, null, null, 0, null, null, null, null);

            ViewBag.Message = userLoged;
            ViewBag.user = user.Username;
            return View();
        }

        [HttpPost]
        public ActionResult EditData()
        {
            string name = Request["username"];
            string session = Request["session"];
            string newPass = Request["password"];

            Usuario user = new Usuario(null, name, 0, null, null, 0,null,newPass,null,null);

            Usuario userLoged = new Usuario(null, session, 0, null, null, 0, null, null, null, null);

            daoUpdate dbUpdate = new daoUpdate();
            daoRead dbRead = new daoRead();
            //if (dbUpdate.ActualizarContrasena(user))
            //{

            //    ViewData["userList"] = dbRead.TraerDispositivos();
            //    ViewBag.Message = userLoged;
            //    return View("Welcome");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }
        [HttpPost]
        public ActionResult ValidarRegistro()
        {
            daoCreate dbCreate = new daoCreate();
            daoRead dbRead = new daoRead();
            List<Dispositivo> ListaDispositivos = new List<Dispositivo>();

            string nombre = Request["nombre"];
            string nombreUsuario = Request["username"];
            string contrasena = Request["contrasena"];
            int cedula = int.Parse(Request["cedula"]);
            string direccion = Request["direccion"];
            string telefono = Request["telefono"];
            int carnet = int.Parse(Request["carnet"]);
            string dependencia = Request["Dependencia"];
            string departamento = Request["Departamento"];
                
                string tipoUsuario = Request["TipoUsuario"];
            //Validar si hay algun campo vacio
            if (nombre.Equals("") || cedula.Equals("") || direccion.Equals("") || contrasena.Equals("") || nombreUsuario.Equals("") || telefono.Equals("") || carnet.Equals("") || dependencia.Equals("") || departamento.Equals("")) 
                {
                return RedirectToAction("Registro", "Home/Registro", new { msg = "Todos los campos son obligatorios" });
                //return View("Home/Registro");
                }
                else //  Si ningun campo esta vacio
                {
                    Usuario user = new Usuario(nombre, nombreUsuario, cedula, direccion, telefono, carnet, tipoUsuario,contrasena,departamento, dependencia);

                    int aux = dbCreate.InsertUser(user);
                    switch(aux) //  Si no hubo error
                    {
                    case 0:
                        ListaDispositivos = dbRead.TraerDispositivos();
                        ViewData["userList"] = ListaDispositivos;
                        //this.Session["Login"] = user.NombreUsuario;
                        ViewBag.Message = user;
                        return View("Welcome");
                    case 1: // Si ingreso un campo erroneo
                    
                    return RedirectToAction("Registro", "Home/Registro", new { msg = "Error al ingresar los campos(INSERT)" });
                    case 2: 

                    return RedirectToAction("Registro", "Home/Registro", new { msg = "Este usuario ya existe" });
                    default:
                        return RedirectToAction("Registro", "Home/Registro", new { msg = "Error Inesperado" });

                }
                }
            }

        public ActionResult Perfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prestamo()
        {
            string username = Request["username"];
            string serial = Request["serial"];
            daoRead read = new daoRead();
            daoCreate create = new daoCreate();
            daoUpdate update = new daoUpdate();
            string Userid = read.TraerPersonaID(username);
            string Dispid = read.TraerDispositivoID(serial);
            ViewData["error"] = create.CrearTransaccion(Userid, Dispid);

            update.ActualizarDisponibilidad(serial);
            return View();
        }
    }
    }
