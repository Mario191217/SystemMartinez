using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemMartinezCV.Controllers
{
    public class HomeController : Controller
    {
        Contexto db = new Contexto();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            pass = pass.GetHashCode().ToString();
            try
            {
                var login = from x in db.Usuarios
                            where x.Usuario == user && x.Clave == pass
                            select x;
                var us = login.FirstOrDefault();
                if(login.Count() > 0)
                {
                    Session["User"] = us.Usuario;
                    Session["Rol"] = us.Roles.Rol;
                    Session["Nombre"] = us.Empleados.Nombre;
                    return RedirectToAction("Bienvenida", "Home");
                }
                else
                {
                    ViewBag.msj = "Clave o Usuario invalido";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.msj = "Clave o Usuario invalido";
                return View();
            }
        }

        public ActionResult Bienvenida()
        {
            if(Session["User"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.mensaje = "Buen Dia " + Session["Nombre"];
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}