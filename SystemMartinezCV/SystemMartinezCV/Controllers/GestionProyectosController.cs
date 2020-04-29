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
            ViewBag.Productos = db.Productos.ToList();
            ViewBag.Clientes = db.Clientes.ToList();
            ViewBag.Empleados = db.Empleados.ToList();
            return View();
        }

        public ActionResult General()
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


        [HttpPost]
        public ActionResult AddProject(Proyectos proyectos )
        {
            proyectos.FechaRegistro = DateTime.Now;
            proyectos.Comision = Comision(proyectos.MontoFinal);
            proyectos.Rentabilidad = proyectos.MontoFinal - proyectos.Costo - proyectos.Comision;
            proyectos.IdEstado = 1;
            db.Proyectos.Add(proyectos);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public JsonResult AddSubproject(Subproyectos subproyecto)
        {
            try
            {
                subproyecto.IdProyecto = (from x in db.Proyectos select x.IdProyecto).Max();
                db.Subproyectos.Add(subproyecto);
                db.SaveChanges();
                return Json(true);
            }
            catch(Exception e)
            {
                return Json(false);
            }
        }

        public JsonResult AddDetail(DetalleProyectos productos)
        {
            try
            {
                productos.Fecha = DateTime.Now;
                productos.Total = productos.Precio * productos.Cantidad;
                productos.Comentario = "comentario";
                productos.Existencias = true;
                productos.IdSubProyecto = (from x in db.Subproyectos select x.IdSubProyecto).Max();
                productos.IdUnidadMedida = 1;
                db.DetalleProyectos.Add(productos);
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