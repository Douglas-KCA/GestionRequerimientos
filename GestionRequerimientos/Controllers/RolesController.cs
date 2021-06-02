using GestionRequerimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class RolesController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Roles
        public ActionResult Index()
        {
            var listado = context.ROL;
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ROL rol)
        {
            if ((rol.rol1 != "") && (rol.descripcion != ""))
            {
                context.ROL.Add(rol);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            /*
            var viewmodel = new ProyectoViewModel();
            viewmodel.proyecto = context.PROYECTO.FirstOrDefault(x => x.id_proyecto == id);
            viewmodel.Estados = context.ESTADO.ToList();
            */
            var listado = context.ROL.FirstOrDefault(x => x.id_rol == id);
            return View(listado);
        }

        [HttpPost]
        public ActionResult Actualizar(ROL rol)
        {
            if ((rol.rol1 != "") && (rol.descripcion != ""))
            {
                context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}