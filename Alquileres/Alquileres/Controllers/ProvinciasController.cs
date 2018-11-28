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
    public class ProvinciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index()
        {
            return View(db.Provincias.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "ProvinciaId,Detalle")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincia);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }


        [HttpPost]

        public ActionResult Edit([Bind(Include = "ProvinciaId,Detalle")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincia);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            Provincia provincia = db.Provincias.Find(id);
            db.Provincias.Remove(provincia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    
    }
}
