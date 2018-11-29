using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alquileres.Models;

namespace Alquileres.Controllers
{
    public class ciudadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var ciudads = db.Ciudads.Include(c => c.Provincias);
            return View(ciudads.ToList());
        }

        public ActionResult Mostrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        public ActionResult Nuevo()
        {
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Detalle");
            return View();
        }

      
        [HttpPost]
        public ActionResult Nuevo(ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudads.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Detalle", ciudad.ProvinciaId);
            return View(ciudad);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Detalle", ciudad.ProvinciaId);
            return View(ciudad);
        }


        [HttpPost]
        public ActionResult Editar([Bind(Include = "CiudadId,Detalle,ProvinciaId")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Detalle", ciudad.ProvinciaId);
            return View(ciudad);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            ciudad ciudad = db.Ciudads.Find(id);
            db.Ciudads.Remove(ciudad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
