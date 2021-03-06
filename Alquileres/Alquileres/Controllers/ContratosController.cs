﻿using System;
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
    public class ContratosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var contratoes = db.Contratoes.Include(c => c.Cliente).Include(c => c.Inmuebles);
            return View(contratoes.ToList());
        }

        public ActionResult Mostrar(int? id)
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

        public ActionResult Nuevo()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres");
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle");
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo( Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contratoes.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", contrato.ClienteId);
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle", contrato.InmuebleId);
            return View(contrato);
        }

        public ActionResult Editar(int? id)
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
            return View(contrato);
        }

       
        [HttpPost]
        public ActionResult Editar([Bind(Include = "ContratoId,ClienteId,InmuebleId,ModoPago,DuracionContrato,FechaInicio,FechaFin")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", contrato.ClienteId);
            ViewBag.InmuebleId = new SelectList(db.Inmuebles, "InmuebleId", "calle", contrato.InmuebleId);
            return View(contrato);
        }

        public ActionResult Elliminar(int? id)
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

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contratoes.Find(id);
            db.Contratoes.Remove(contrato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
