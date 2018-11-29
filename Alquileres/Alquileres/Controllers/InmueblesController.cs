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

        // GET: Inmuebles
        public ActionResult Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.ciudades).Include(i => i.Propietarios);
            return View(inmuebles.ToList());
        }

        // GET: Inmuebles/Details/5
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

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle");
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres");
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmuebleId,calle,barrio,CiudadId,departamento,tipo,NumeroHabitaciones,CostoMensual,PropietarioId")] Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                db.Inmuebles.Add(inmuebles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", inmuebles.CiudadId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", inmuebles.PropietarioId);
            return View(inmuebles);
        }

        // GET: Inmuebles/Edit/5
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
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", inmuebles.PropietarioId);
            return View(inmuebles);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmuebleId,calle,barrio,CiudadId,departamento,tipo,NumeroHabitaciones,CostoMensual,PropietarioId")] Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmuebles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", inmuebles.CiudadId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", inmuebles.PropietarioId);
            return View(inmuebles);
        }

        // GET: Inmuebles/Delete/5
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

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmuebles inmuebles = db.Inmuebles.Find(id);
            db.Inmuebles.Remove(inmuebles);
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
