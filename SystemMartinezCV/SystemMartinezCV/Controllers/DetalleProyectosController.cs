using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemMartinezCV;
using SystemMartinezCV.Models;

namespace SystemMartinezCV.Controllers
{
    public class DetalleProyectosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DetalleProyectos
        public ActionResult Index()
        {
            var detalleProyectos = db.DetalleProyectos.Include(d => d.SubProyectos).Include(d => d.UnidadMedida);
            return View(detalleProyectos.ToList());
        }

        // GET: DetalleProyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyectos detalleProyectos = db.DetalleProyectos.Find(id);
            if (detalleProyectos == null)
            {
                return HttpNotFound();
            }
            return View(detalleProyectos);
        }

        // GET: DetalleProyectos/Create
        public ActionResult Create()
        {
            ViewBag.IdSubProyecto = new SelectList(db.Subproyectos, "IdSubProyecto", "Nombre");
            ViewBag.IdUnidadMedida = new SelectList(db.unidadMedida, "IdUnidadMedida", "Unidad");
            return View();
        }

        // POST: DetalleProyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleProyecto,Fecha,Producto,Cantidad,Precio,Total,IdUnidadMedida,Comentario,Existencias,NumeroFactura,IdSubProyecto")] DetalleProyectos detalleProyectos)
        {
            if (ModelState.IsValid)
            {
                db.DetalleProyectos.Add(detalleProyectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSubProyecto = new SelectList(db.Subproyectos, "IdSubProyecto", "Nombre", detalleProyectos.IdSubProyecto);
            ViewBag.IdUnidadMedida = new SelectList(db.unidadMedida, "IdUnidadMedida", "Unidad", detalleProyectos.IdUnidadMedida);
            return View(detalleProyectos);
        }

        // GET: DetalleProyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyectos detalleProyectos = db.DetalleProyectos.Find(id);
            if (detalleProyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSubProyecto = new SelectList(db.Subproyectos, "IdSubProyecto", "Nombre", detalleProyectos.IdSubProyecto);
            ViewBag.IdUnidadMedida = new SelectList(db.unidadMedida, "IdUnidadMedida", "Unidad", detalleProyectos.IdUnidadMedida);
            return View(detalleProyectos);
        }

        // POST: DetalleProyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleProyecto,Fecha,Producto,Cantidad,Precio,Total,IdUnidadMedida,Comentario,Existencias,NumeroFactura,IdSubProyecto")] DetalleProyectos detalleProyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleProyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSubProyecto = new SelectList(db.Subproyectos, "IdSubProyecto", "Nombre", detalleProyectos.IdSubProyecto);
            ViewBag.IdUnidadMedida = new SelectList(db.unidadMedida, "IdUnidadMedida", "Unidad", detalleProyectos.IdUnidadMedida);
            return View(detalleProyectos);
        }

        // GET: DetalleProyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProyectos detalleProyectos = db.DetalleProyectos.Find(id);
            if (detalleProyectos == null)
            {
                return HttpNotFound();
            }
            return View(detalleProyectos);
        }

        // POST: DetalleProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProyectos detalleProyectos = db.DetalleProyectos.Find(id);
            db.DetalleProyectos.Remove(detalleProyectos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
