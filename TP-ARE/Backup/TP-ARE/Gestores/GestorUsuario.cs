using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_ARE.Entidades;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TP_ARE.Gestores
{
    public class GestorUsuario
    {
        public static String cadenaConexion = ConfigurationManager.ConnectionStrings["conexionARE"].ConnectionString;

        public static  void guardarUsuarioWeb(Usuario usuario)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = " Insert into Usuario (idRol,usuario,password) values (2,'"+usuario.usuario+"','"+usuario.password+"')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                if (cn != null && ConnectionState.Open == cn.State)
                {
                    cn.Close();
                }
            }
        }

        public static int recuperarIdUsuario(String usuario)
        {
            SqlConnection cn = null;
            int idDomicilio = 0;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT idUsuario ";
                sql = sql + "FROM Usuario WHERE usuario='"+usuario+"'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idDomicilio = dr.GetInt32(dr.GetOrdinal("idUsuario"));
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                if (cn != null && ConnectionState.Open == cn.State)
                {
                    cn.Close();
                }
            }
            return idDomicilio;
        }

        public static void guardarUsuarioEmpleado(Usuario usuario)
        {
            SqlConnection cn = null;
            int res = 0;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = " Insert into Usuario (idRol,usuario,contraseña) values (@IDROL,@USUARIO,@PASSWORD)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IDROL", 1); //1  es el tipo empleado
                cmd.Parameters.AddWithValue("@USUARIO", usuario.usuario);
                cmd.Parameters.AddWithValue("@PASSWORD", usuario.password);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                if (cn != null && ConnectionState.Open == cn.State)
                {
                    cn.Close();
                }
            }
        }

        public static Usuario recuperarUSuario(String usuario,String password)
        {
            SqlConnection cn = null;
            Usuario  usu = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT idUsuario, idRol, usuario, password FROM USUARIO WHERE usuario='" + usuario + "' AND password='" + password+"'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usu = new Usuario();
                    //usu.idUsuario = dr.GetInt32(dr.GetOrdinal("idUsuario"));
                    usu.idUsuario = recuperarIdUsuario(usuario);
                    usu.idRol = dr.GetInt32(dr.GetOrdinal("idRol"));
                    usu.usuario = dr.GetString(dr.GetOrdinal("usuario"));
                    usu.password = dr.GetString(dr.GetOrdinal("password"));
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                if (cn != null && ConnectionState.Open == cn.State)
                {
                    cn.Close();
                }
            }
            return usu;
        }

        public static void modificarPassword(String usuario, String password)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = " UPDATE USUARIO SET password='" + password + "' WHERE usuario='" + usuario+"'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                if (cn != null && ConnectionState.Open == cn.State)
                {
                    cn.Close();
                }
            }
        }

    }
}