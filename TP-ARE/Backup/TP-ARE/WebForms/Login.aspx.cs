using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_ARE.Entidades;
using TP_ARE.Gestores;


namespace TP_ARE.WebForms
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"]!=null) // si el usuario ya se logeo lo mando a su cuenta directamente
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Response.Redirect("MiCuenta.aspx");
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUsuario.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String usuario = txtusaurio.Text;
            String password = txtContra.Text;
            Usuario usu = GestorUsuario.recuperarUSuario(usuario,password);
            if(usu!=null && usu.idRol==2)
            {
                Session["usuario"] = usu; // guardamos el usuario en una variable session
                txtMensaje.Text = "LA AUTENTIFICACION SE REALIZO CON EXITO";
                Response.Redirect("MiCuenta.aspx");
            }
            else
            {
                txtMensaje.Text = "USUARIO INCORRECTO O INEXISTENTE";
            }
        }
    }
}