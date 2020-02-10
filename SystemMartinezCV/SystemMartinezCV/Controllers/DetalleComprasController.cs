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
    public class DetalleComprasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DetalleCompras
        public ActionResult Index(int? id)
        {
            var detalleCompras = db.DetalleCompras.Include(d => d.Compras).Include(d => d.Productos);
            var datos = from x in detalleCompras
                        where x.IdCompra == id
                        select x;
            var lista = datos.ToList();
            return View(lista);
        }

        // GET: DetalleCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public ActionResult Create()
        {
            ViewBag.IdCompra = new SelectList(db.Compras, "IdCompra", "NFactura");
            ViewBag.IdProducto = new SelectList(db.Productos, "IdProducto", "Nombre");
            return View();
        }

        // POST: DetalleCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleCompra,IdProducto,IdCompra,Cantidad,PrecioUnitario,Total")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCompras.Add(detalleCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompra = new SelectList(db.Compras, "IdCompra", "NFactura", detalleCompra.IdCompra);
            ViewBag.IdProducto = new SelectList(db.Productos, "IdProducto", "Nombre", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompra = new SelectList(db.Compras, "IdCompra", "NFactura", detalleCompra.IdCompra);
            ViewBag.IdProducto = new SelectList(db.Productos, "IdProducto", "Nombre", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleCompra,IdProducto,IdCompra,Cantidad,PrecioUnitario,Total")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompra = new SelectList(db.Compras, "IdCompra", "NFactura", detalleCompra.IdCompra);
            ViewBag.IdProducto = new SelectList(db.Productos, "IdProducto", "Nombre", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            db.DetalleCompras.Remove(detalleCompra);
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
