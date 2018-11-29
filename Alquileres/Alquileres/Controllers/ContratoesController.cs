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
    public class ContratoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contratoes = db.Contratoes.Include(c => c.Cliente).Include(c => c.Inmuebles).Include(c => c.Propietario);
            return View(contratoes.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratoes.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres");
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle");
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,ClienteId,PropietarioId,InmuebleId,ModoPago,DuracionContrato,FechaInicio,FechaFin")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contratoes.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", contrato.ClienteId);
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle", contrato.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", contrato.PropietarioId);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratoes.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", contrato.ClienteId);
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle", contrato.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", contrato.PropietarioId);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,ClienteId,PropietarioId,InmuebleId,ModoPago,DuracionContrato,FechaInicio,FechaFin")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", contrato.ClienteId);
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle", contrato.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "Nombres", contrato.PropietarioId);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratoes.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contratoes.Find(id);
            db.Contratoes.Remove(contrato);
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
