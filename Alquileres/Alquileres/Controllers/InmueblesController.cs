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
    public class InmueblesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.ciudades);
            return View(inmuebles.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmuebles inmuebles = db.Inmuebles.Find(id);
            if (inmuebles == null)
            {
                return HttpNotFound();
            }
            return View(inmuebles);
        }

        public ActionResult Create()
        {
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle");
            return View();
        }

      
        [HttpPost]
        public ActionResult Create( Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                db.Inmuebles.Add(inmuebles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", inmuebles.CiudadId);
            return View(inmuebles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmuebles inmuebles = db.Inmuebles.Find(id);
            if (inmuebles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", inmuebles.CiudadId);
            return View(inmuebles);
        }

    
        [HttpPost]
        public ActionResult Edit([Bind(Include = "InmuebleId,calle,barrio,CiudadId,departamento,tipo")] Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmuebles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", inmuebles.CiudadId);
            return View(inmuebles);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmuebles inmuebles = db.Inmuebles.Find(id);
            if (inmuebles == null)
            {
                return HttpNotFound();
            }
            return View(inmuebles);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmuebles inmuebles = db.Inmuebles.Find(id);
            db.Inmuebles.Remove(inmuebles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
