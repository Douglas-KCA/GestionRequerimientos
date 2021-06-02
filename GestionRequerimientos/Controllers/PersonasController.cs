using GestionRequerimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class PersonasController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Personas
        public ActionResult Index()
        {
            var lista = context.PERSONA.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PERSONA persona)
        {
            if ((!string.IsNullOrEmpty(persona.nombre)) && (!string.IsNullOrEmpty(persona.apellido)) && (!string.IsNullOrEmpty(persona.dpi)))
            {
                context.PERSONA.Add(persona);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(string dpi)
        {
            var viewmodel = new PERSONA();
            viewmodel = context.PERSONA.FirstOrDefault(x => x.dpi == dpi);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Actualizar(PERSONA persona)
        {
            if ((!string.IsNullOrEmpty(persona.dpi)) && (!string.IsNullOrEmpty(persona.nombre)) && (!string.IsNullOrEmpty(persona.apellido)))
            {
                context.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}