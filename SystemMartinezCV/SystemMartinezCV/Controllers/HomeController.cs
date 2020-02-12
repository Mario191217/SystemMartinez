using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemMartinezCV.Models;

namespace SystemMartinezCV.Controllers
{
    public class HomeController : Controller
    {
        Contexto db = new Contexto();

        private void AddGenero(string genero)
        {
            var Genero = new Generos();
            Genero.Genero = genero;
            db.Generos.Add(Genero);
            db.SaveChanges();
        }

        private void AddRol()
        {
            var rol = new Roles();
            rol.Rol = "Administrador";
            db.Roles.Add(rol);
            db.SaveChanges();
        }

        private void AddEmpleado()
        {
            var empleado = new Empleados();
            empleado.Nombre = "Mario";
            empleado.Apellido = "Alvarenga";
            empleado.IdGenero = 1;
            empleado.Direccion = "El Divisadero";
            empleado.AFP = "8765432";
            empleado.Dui = "057227945-5";
            empleado.Nit = "1306-190698-101-5";
            empleado.FechaNacimiento = DateTime.Now;
            empleado.FechaRegistro = DateTime.Now;
            db.Empleados.Add(empleado);
            db.SaveChanges();
        }

        private void AddUser()
        {
            var user = new Usuarios();
            user.Usuario = "Administrador";
            user.Clave = "1234".GetHashCode().ToString();
            user.IdEmpleado = 1;
            user.IdRol = 1;
            db.Usuarios.Add(user);
            db.SaveChanges();
        }

        // GET: Home
        public ActionResult Index()
        {
            if(db.Generos.Count() == 0)
            {
                AddGenero("Masculino");
                AddGenero("Femenino");
            }
            if(db.Usuarios.Count() == 0)
            {
                AddEmpleado();
                AddRol();
                AddUser();
            }
            if (Session["User"] != null)
            {
                return RedirectToAction("Bienvenida", "Home");
            }
            Session["Rol"] = "User";
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