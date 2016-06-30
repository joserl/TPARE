using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Experiencia
    {
        public int idExperiencia {get; set;}
        public String nombreEmpresa {get; set;}
        public int idActividad {get; set;}
        public int idJerarquia {get; set;}
        public int idDuracion { get; set; }
        public int numeroDoc { get; set; }
        public int tipoDoc { get; set; }
        public int idArea { get; set; }
    }
}