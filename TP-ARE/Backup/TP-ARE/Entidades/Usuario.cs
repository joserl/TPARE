using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
    }
}