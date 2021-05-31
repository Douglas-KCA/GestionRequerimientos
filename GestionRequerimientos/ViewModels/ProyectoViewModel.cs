using GestionRequerimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionRequerimientos.ViewModels
{
    public class ProyectoViewModel
    {
        public PROYECTO proyecto { get; set; }

        public List<ESTADO> Estados { get; set; }
        public List<REQUERIMIENTO> Requerimientos { get; set; }
    }
}