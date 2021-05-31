using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRequerimientos.Controllers
{
    public class RequerimientosController : Controller
    {
        // GET: Requerimientos
        public ActionResult Index()
        {
            return View();
        }
    }
}