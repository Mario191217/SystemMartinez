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
    public class ComprasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Compras
        public ActionResult CrearCompra()
        {
            var compras = db.Compras.Include(c => c.Proveedores);
            ViewBag.IdProveedor = db.Proveedores;
            ViewBag.IdProducto = db.Productos;
            return View(compras.ToList());
        }

        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Proveedores);
            return View(compras.ToList());
        }

        public ActionResult Detalles()
        {
            var compras = db.DetalleCompras.Include(c => c.Compras);
            return View(compras.ToList());
        }


        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "RazonSocial");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompra,NFactura,Fecha,FechaRegistro,IdProveedor,Descripcion,EstadoEliminar")] Compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "RazonSocial", compras.IdProveedor);
            return View(compras);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "RazonSocial", compras.IdProveedor);
            return View(compras);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompra,NFactura,Fecha,FechaRegistro,IdProveedor,Descripcion,EstadoEliminar")] Compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "RazonSocial", compras.IdProveedor);
            return View(compras);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compras compras = db.Compras.Find(id);
            db.Compras.Remove(compras);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult AddFactura(Compras compra)
        {
            try
            {
                compra.FechaRegistro = DateTime.Now;
                compra.Descripcion = "alv ptm";
                compra.EstadoEliminar = "Disponible";
                db.Compras.Add(compra);
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }

        public JsonResult Detalle(DetalleCompra compra)
        {
            try
            {
                var idPrimaria = (from id in db.Compras select id.IdCompra).Max();
                compra.IdCompra = idPrimaria;
                db.DetalleCompras.Add(compra);
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Factura()
        {

            return View();
        }

    }


}


