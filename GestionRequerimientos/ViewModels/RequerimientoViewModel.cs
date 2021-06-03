using GestionRequerimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionRequerimientos.ViewModels
{
    public class RequerimientoViewModel
    {
        public REQUERIMIENTO Requerimiento { get; set; }


        public List<ESTADO> Estados { get; set; }

        public List<PROYECTO> Proyectos { get; set; }

        public List<TIPO_REQUERIMIENTO> Tipo_Requerimiento { get; set; }
    }
}