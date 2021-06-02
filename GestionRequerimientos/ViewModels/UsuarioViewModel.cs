using GestionRequerimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionRequerimientos.ViewModels
{
    public class UsuarioViewModel
    {
        public USUARIOS Usuarios { get; set; }

        public List<PERSONA> Personas { get; set; }
        public List<ROL> Roles { get; set; }
    }
}