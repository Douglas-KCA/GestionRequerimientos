using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionRequerimientos.Models;

namespace GestionRequerimientos.Controllers
{
    public class LoginController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verificar(string usuario, string pass)
        {
            if ((!string.IsNullOrEmpty(usuario)) && (!string.IsNullOrEmpty(pass)))
            {
                var viewmodel = new USUARIOS();
                viewmodel = context.USUARIOS.FirstOrDefault(x => x.pk_usuario == usuario && x.contrasena == pass);

                if (viewmodel != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index");
                }
            }
            else 
            {
                return View("Index");
            }
        }

    }
}