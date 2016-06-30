using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ARE.Entidades
{
    public class Candidato
    {
        public int tipoDoc { get; set; }
        public int numeroDoc { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String fechaNac { get; set; }
        public int numeroTelf { get; set; }
        public String email { get; set; }
        public DateTime fechaRegistrar { get; set; }
        public String sexo  { get; set; }
        public int idSexo { get; set; }
        public int idUSuario { get; set; }
        public int idDomicilio { get; set; }
        public int idEstadoCivil { get; set; }
        public int idDisponibilidad { get; set; }
        public int idTitulo { get; set; }
    }
}