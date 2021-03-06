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
    public class SucursalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var sucursales = db.Sucursales.Include(s => s.ciudad).Include(s => s.Empleado);
            return View(sucursales.ToList());
        }

        public ActionResult Mostrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            return View(sucursales);
        }

        public ActionResult Nuevo()
        {
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres");
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(Sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                db.Sucursales.Add(sucursales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", sucursales.CiudadId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", sucursales.EmpleadoId);
            return View(sucursales);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", sucursales.CiudadId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", sucursales.EmpleadoId);
            return View(sucursales);
        }


        [HttpPost]
        public ActionResult Editar([Bind(Include = "SucursalId,EmpleadoId,CiudadId,Barrio,calles,telefono")] Sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Detalle", sucursales.CiudadId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", sucursales.EmpleadoId);
            return View(sucursales);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            return View(sucursales);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursales sucursales = db.Sucursales.Find(id);
            db.Sucursales.Remove(sucursales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
