using GestionRequerimientos.Models;
using GestionRequerimientos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class ProyectosController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Proyectos
        public ActionResult Index()
        {
            var listado = context.PROYECTO;
            return View(listado);

        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewmodel = new ProyectoViewModel();
            viewmodel.Estados = context.ESTADO.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Nuevo(PROYECTO proyecto)
        {
            if ((proyecto.id_proyecto != "") && (proyecto.nombre != "") && (proyecto.nom_estado != "")) {
                context.PROYECTO.Add(proyecto);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detalle(string id) 
        {
            var viewmodel = new ProyectoViewModel();
            viewmodel.proyecto = context.PROYECTO.FirstOrDefault(x => x.id_proyecto == id);
            viewmodel.Requerimientos = context.REQUERIMIENTO.Where(y => y.id_proyecto == id).ToList();
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Actualizar(string id)
        {
            var viewmodel = new ProyectoViewModel();
            viewmodel.proyecto = context.PROYECTO.FirstOrDefault(x => x.id_proyecto == id);
            viewmodel.Estados = context.ESTADO.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Actualizar(PROYECTO proyecto)
        {
            if ((proyecto.id_proyecto != "") && (proyecto.nombre != "") && (proyecto.nom_estado != ""))
            {
                context.Entry(proyecto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}