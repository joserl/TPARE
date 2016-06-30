using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_ARE.Gestores;
using TP_ARE.Entidades;
using System;

namespace TP_ARE.WebForms
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == txtRepContra.Text)
            {
                Usuario usuario = crearUsuario();
                GestorUsuario.guardarUsuarioWeb(usuario);
                int idUsuario = GestorUsuario.recuperarIdUsuario(usuario.usuario);
                lblMensaje.Text = "USUARIO CREADO CON EXITO";
                Session["usuario"] = usuario;
                Response.Write("<script>alert('La Autentificacion se ha realizado con exito');document.location.href='./MiCuenta.aspx';</script>");
                //Response.Redirect("MiCuenta.aspx");
            }
            else 
            {
                lblMensaje.Text = "LAS CONTRASEÑAS NO COINCIDEN";
            }

        }

        public Usuario crearUsuario() 
        {
            Usuario usu = new Usuario();
            String usuario = txtUsuario.Text;
            usu.usuario = usuario;
            String password = txtContra.Text;
            usu.password = password;
            return usu;
        }
    }
}