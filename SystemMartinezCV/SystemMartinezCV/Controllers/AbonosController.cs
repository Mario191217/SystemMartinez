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
    public class AbonosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Abonos
        public ActionResult Index()
        {
            var abonos = db.Abonos.Include(a => a.Proyectos);
            return View(abonos.ToList());
        }

        // GET: Abonos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonos abonos = db.Abonos.Find(id);
            if (abonos == null)
            {
                return HttpNotFound();
            }
            return View(abonos);
        }

        // GET: Abonos/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            return View();
        }

        // POST: Abonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAbono,Codigo,Abono,Descripcion,IdProyecto")] Abonos abonos)
        {
            if (ModelState.IsValid)
            {
                db.Abonos.Add(abonos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", abonos.IdProyecto);
            return View(abonos);
        }

        // GET: Abonos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonos abonos = db.Abonos.Find(id);
            if (abonos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", abonos.IdProyecto);
            return View(abonos);
        }

        // POST: Abonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAbono,Codigo,Abono,Descripcion,IdProyecto")] Abonos abonos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", abonos.IdProyecto);
            return View(abonos);
        }

        // GET: Abonos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonos abonos = db.Abonos.Find(id);
            if (abonos == null)
            {
                return HttpNotFound();
            }
            return View(abonos);
        }

        // POST: Abonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonos abonos = db.Abonos.Find(id);
            db.Abonos.Remove(abonos);
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
