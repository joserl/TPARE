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
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null) // si el usuario ya se logeo lo mando a su cuenta directamente
            {
                Usuario usuario = (Usuario)Session["usuario"];
                lblusuario.Text = usuario.usuario;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String usuario= lblusuario.Text;
            String viejaPassword = txtContra.Text;
            String nuevaPassword = txtNuevaContra.Text;
            Usuario usu = GestorUsuario.recuperarUSuario(usuario, viejaPassword);
            if (usu != null)
            {
                GestorUsuario.modificarPassword(usuario, nuevaPassword);
                lblMensaje.Text = "La Contraseña se ha modificado";
            }
            else 
            {
                lblMensaje.Text = "La Contraseña es incorrecta";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}