using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Curriculum
    {
        public int idCurriculum {get; set;}
        public int tipoDoc {get; set;}
        public int numeroDoc {get; set;}
        public DateTime fechaRegistro {get; set;}
        public DateTime fechaActualizacion {get; set;}
        public string disponibilidad {get; set;}
        public int idDisponibilidad { get; set; }
    }
}