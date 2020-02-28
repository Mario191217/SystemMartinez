using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemMartinezCV.Models;

namespace SystemMartinezCV.Controllers
{
    public class GestionProyectosController : Controller
    {
        Contexto db = new Contexto();
        // GET: GestionProyectos
        public ActionResult Index()
        {
            ViewBag.Clientes = db.Clientes.ToList();
            ViewBag.Empleados = db.Empleados.ToList();
            return View();
        }

        public double Comision(double monto)
        {
            if (monto <= 10000)
            {
                return monto * 0.01;
            }
            else if (monto <= 20000)
            {
                return monto * 0.02;
            }
            else if (monto <= 30000)
            {
                return monto * 0.03;
            }
            return monto * 0.04;
        }

        public JsonResult AddProject(Proyectos proyectos )
        {
            try 
            {
                proyectos.FechaRegistro = DateTime.Now;
                proyectos.Comision = Comision(proyectos.MontoFinal);
                proyectos.Rentabilidad = proyectos.MontoFinal - proyectos.Costo;
                proyectos.IdEstado = 1;
                db.Proyectos.Add(proyectos);
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }

        }
    }
}