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
    public class SubproyectosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Subproyectos
        public ActionResult Index()
        {
            var subproyectos = db.Subproyectos.Include(s => s.Proyectos);
            return View(subproyectos.ToList());
        }

        // GET: Subproyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subproyectos subproyectos = db.Subproyectos.Find(id);
            if (subproyectos == null)
            {
                return HttpNotFound();
            }
            return View(subproyectos);
        }

        // GET: Subproyectos/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            return View();
        }

        // POST: Subproyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSubProyecto,Nombre,Descripcion,IdProyecto,Precio,Costo,Rentabilidad")] Subproyectos subproyectos)
        {
            if (ModelState.IsValid)
            {
                db.Subproyectos.Add(subproyectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", subproyectos.IdProyecto);
            return View(subproyectos);
        }

        // GET: Subproyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subproyectos subproyectos = db.Subproyectos.Find(id);
            if (subproyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", subproyectos.IdProyecto);
            return View(subproyectos);
        }

        // POST: Subproyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSubProyecto,Nombre,Descripcion,IdProyecto,Precio,Costo,Rentabilidad")] Subproyectos subproyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subproyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", subproyectos.IdProyecto);
            return View(subproyectos);
        }

        // GET: Subproyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subproyectos subproyectos = db.Subproyectos.Find(id);
            if (subproyectos == null)
            {
                return HttpNotFound();
            }
            return View(subproyectos);
        }

        // POST: Subproyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subproyectos subproyectos = db.Subproyectos.Find(id);
            db.Subproyectos.Remove(subproyectos);
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
