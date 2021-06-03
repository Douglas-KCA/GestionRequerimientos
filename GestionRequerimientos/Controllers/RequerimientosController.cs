using GestionRequerimientos.Models;
using GestionRequerimientos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class RequerimientosController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Requerimientos
        public ActionResult Index()
        {
            var listado = context.REQUERIMIENTO;
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewmodel = new RequerimientoViewModel();
            viewmodel.Estados = context.ESTADO.ToList();
            viewmodel.Proyectos = context.PROYECTO.ToList();
            viewmodel.Tipo_Requerimiento = context.TIPO_REQUERIMIENTO.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Nuevo(REQUERIMIENTO requerimiento)
        {
            //if ((usuario.pk_usuario != "") && (usuario.contrasena != "") && (usuario.dpi != "") && (usuario.rol != ""))
            //{
                context.REQUERIMIENTO.Add(requerimiento);
                context.SaveChanges();
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int idreq, string idproy)
        {
            var viewmodel = new RequerimientoViewModel();
            viewmodel.Requerimiento = context.REQUERIMIENTO.FirstOrDefault(x => x.id_proyecto == idproy && x.id_requerimiento == idreq);
            viewmodel.Estados = context.ESTADO.ToList();
            viewmodel.Proyectos = context.PROYECTO.ToList();
            viewmodel.Tipo_Requerimiento = context.TIPO_REQUERIMIENTO.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Actualizar(REQUERIMIENTO req)
        {
            if ((req.id_proyecto != "") && (req.nombre != "") && (req.nom_estado != ""))
            {
                context.Entry(req).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}