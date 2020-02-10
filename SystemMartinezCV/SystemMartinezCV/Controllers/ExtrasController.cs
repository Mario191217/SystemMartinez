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
    public class ExtrasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Extras
        public ActionResult Index()
        {
            var extras = db.Extras.Include(e => e.Proyectos);
            return View(extras.ToList());
        }

        // GET: Extras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            return View(extras);
        }

        // GET: Extras/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            return View();
        }

        // POST: Extras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExtra,Extra,Descripcion,Precio,IdProyecto")] Extras extras)
        {
            if (ModelState.IsValid)
            {
                db.Extras.Add(extras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", extras.IdProyecto);
            return View(extras);
        }

        // GET: Extras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", extras.IdProyecto);
            return View(extras);
        }

        // POST: Extras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExtra,Extra,Descripcion,Precio,IdProyecto")] Extras extras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", extras.IdProyecto);
            return View(extras);
        }

        // GET: Extras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            return View(extras);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extras extras = db.Extras.Find(id);
            db.Extras.Remove(extras);
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
