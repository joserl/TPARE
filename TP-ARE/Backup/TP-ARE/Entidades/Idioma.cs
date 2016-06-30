using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Idioma
    {
        public int idIdioma { get; set; }
        public String nombre { get; set; }
        public int idNivelLee { get; set; }
        public String nivelLee { get; set; }
        public int idNivelEscribe { get; set;}
        public String nivelEscribe { get; set;}

        public int idNivelHabla { get; set;}
        public String nivelHabla { get; set;}
    }
}