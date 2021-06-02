using GestionRequerimientos.Models;
using GestionRequerimientos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class UsuarioController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Usuario
        public ActionResult Index()
        {
            var listado = context.USUARIOS;
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewmodel = new UsuarioViewModel();
            viewmodel.Personas = context.PERSONA.ToList();
            viewmodel.Roles = context.ROL.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Nuevo(USUARIOS usuario)
        {
            if ((usuario.pk_usuario != "") && (usuario.contrasena != "") && (usuario.dpi != "") && (usuario.rol != ""))
            {
                context.USUARIOS.Add(usuario);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            var viewmodel = new UsuarioViewModel();
            viewmodel.Usuarios = context.USUARIOS.FirstOrDefault(x => x.id_usuario == id);
            viewmodel.Personas = context.PERSONA.ToList();
            viewmodel.Roles = context.ROL.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Actualizar(USUARIOS usuario)
        {

            if ((usuario.pk_usuario != "") && (usuario.contrasena != "") && (usuario.dpi != "") && (usuario.rol != ""))
            {
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}