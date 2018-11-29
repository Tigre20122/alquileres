using Alquileres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alquileres.Controllers
{
    public class ProvinciasController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Provincias
        public ActionResult Index()
        {
            return View(_context.Provincias.ToList());
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Provincias.Add(provincia);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(provincia);
            }
        }
        public ActionResult Editar(int? Id)
        {

            Provincia provincia = _context.Provincias.Find(Id);
            return View(provincia);

        }
        [HttpPost]
        public ActionResult Editar(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(provincia).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(provincia);
            }
        }
        public ActionResult Eliminar(int? Id)
        {

            Provincia eliminarSexo = _context.Provincias.Find(Id);
            return View(eliminarSexo);
        }
        [HttpPost]
        public ActionResult Eliminar(Provincia Id)
        {
            if (ModelState.IsValid)
            {
                Provincia sex = _context.Provincias.Find(Id);
                _context.Provincias.Remove(sex);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Id);
        }
        public ActionResult Detalle(int? Id)
        {
            Provincia provincia = _context.Provincias.Find(Id);
            return View(provincia);
        }
    }
}