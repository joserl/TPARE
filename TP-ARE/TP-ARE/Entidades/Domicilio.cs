using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Domicilio
    {
        public int idDomicilio { get; set; }
        public String calle { get; set; }
        public int numero { get; set; }
        public int idciudad { get; set; }
        public int idProvincia { get; set; }
        public int idPais { get; set; }
    }
}