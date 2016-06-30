using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ARE
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (System.IO.Path.GetFileName(Page.Request.Path))
            {
                case "Inicio.aspx":
                    liInicio.Attributes.Add("class", "active");
                    liLogin.Attributes.Remove("class");
                    liCargarCV.Attributes.Remove("class");
                    liContacto.Attributes.Remove("class");              
                    break;
                case "Login.aspx":
                    liInicio.Attributes.Remove("class");
                   liLogin.Attributes.Add("class", "active");
                    liCargarCV.Attributes.Remove("class");
                    liContacto.Attributes.Remove("class");  
                    break;
                case "MiCuenta.aspx":
                    liInicio.Attributes.Remove("class");
                   liLogin.Attributes.Add("class", "active");
                    liCargarCV.Attributes.Remove("class");
                    liContacto.Attributes.Remove("class");  
                    break;
                case "RegistrarUsuario.aspx":
                     liInicio.Attributes.Remove("class");
                   liLogin.Attributes.Add("class", "active");
                    liCargarCV.Attributes.Remove("class");
                    liContacto.Attributes.Remove("class");  
                    break;
                case "CargarCV.aspx":
                    liInicio.Attributes.Remove("class");
                    liLogin.Attributes.Remove("class");
                    liCargarCV.Attributes.Add("class", "active");
                    liContacto.Attributes.Remove("class");
                    break;
                case "Contacto.aspx":
                    liInicio.Attributes.Remove("class");
                    liLogin.Attributes.Remove("class");
                    liCargarCV.Attributes.Remove("class");
                    liContacto.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}