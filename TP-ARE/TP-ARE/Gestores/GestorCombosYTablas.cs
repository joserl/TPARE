using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_ARE.Entidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace TP_ARE.Gestores
{
    public class GestorCombosYTablas
    {
        public static String cadenaConexion = ConfigurationManager.ConnectionStrings["conexionARE"].ConnectionString;


        public static List<TipoDoc> comboTiposDoc()
        {
            SqlConnection cn = null;
            List<TipoDoc> lista = new List<TipoDoc>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idTipoDoc, nombre FROM TipoDoc";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDoc tipoDoc = new TipoDoc();
                    int idTipoDoc = dr.GetInt32(dr.GetOrdinal("idTipoDoc"));
                    tipoDoc.idTipoDoc = idTipoDoc;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    tipoDoc.nombre=nombre;  
                    lista.Add(tipoDoc);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Pais> comboPaises()
        {
            SqlConnection cn = null;
            List<Pais> lista = new List<Pais>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idPais, nombre FROM Pais";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pais pais = new Pais();
                    int idPais = dr.GetInt32(dr.GetOrdinal("idPais"));
                    pais.idPais = idPais;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    pais.nombre = nombre;
                    lista.Add(pais);
                }
            }
            catch (Exception e )
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Provincia> comboProvincia()
        {
            SqlConnection cn = null;
            List<Provincia> lista = new List<Provincia>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idProvincia, nombre FROM Provincia";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Provincia provincia = new Provincia();
                    int idProvincia = dr.GetInt32(dr.GetOrdinal("idProvincia"));
                    provincia.idProvincia = idProvincia;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    provincia.nombre = nombre;
                    lista.Add(provincia);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Ciudad> comboCiudad()
        {
            SqlConnection cn = null;
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idCiudad, nombre FROM Ciudad";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    int idCiudad = dr.GetInt32(dr.GetOrdinal("idCiudad"));
                    ciudad.idCiudad = idCiudad;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    ciudad.nombre = nombre;
                    lista.Add(ciudad);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<EstadoCivil> comboEstadoCivil()
        {
            SqlConnection cn = null;
            List<EstadoCivil> lista = new List<EstadoCivil>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idEstadoCivil, nombre FROM EstadoCivil";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoCivil estadoCivil = new EstadoCivil();
                    int idEstadoCivil = dr.GetInt32(dr.GetOrdinal("idEstadoCivil"));
                    estadoCivil.idEstadoCivil = idEstadoCivil;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    estadoCivil.nombre = nombre;
                    lista.Add(estadoCivil);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Disponibilidad> comboDisponibilidad()
        {
            SqlConnection cn = null;
            List<Disponibilidad> lista = new List<Disponibilidad>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idDisponibilidad, nombre FROM Disponibilidad";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Disponibilidad disponibilidad = new Disponibilidad();
                    int idDisponibilidad = dr.GetInt32(dr.GetOrdinal("idDisponibilidad"));
                    disponibilidad.idDisponibilidad = idDisponibilidad;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    disponibilidad.nombre = nombre;
                    lista.Add(disponibilidad);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Titulo> comboTitulo()
        {
            SqlConnection cn = null;
            List<Titulo> lista = new List<Titulo>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idTitulo, nombre FROM Titulo";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Titulo titulo = new Titulo();
                    int idTitulo = dr.GetInt32(dr.GetOrdinal("idTitulo"));
                    titulo.idTitulo = idTitulo;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    titulo.nombre = nombre;
                    lista.Add(titulo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Lenguaje> comboLenguaje()
        {
            SqlConnection cn = null;
            List<Lenguaje> lista = new List<Lenguaje>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idLenguaje, nombre FROM LenguajesDeProgramacion";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Lenguaje lenguaje = new Lenguaje();
                    int idLenguaje = dr.GetInt32(dr.GetOrdinal("idLenguaje"));
                    lenguaje.idLenguaje = idLenguaje;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    lenguaje.nombre = nombre;
                    lista.Add(lenguaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<MotorBD> comboMotores()
        {
            SqlConnection cn = null;
            List<MotorBD> lista = new List<MotorBD>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idMotor, nombre FROM MotoresBD";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MotorBD motor = new MotorBD();
                    int idMotor = dr.GetInt32(dr.GetOrdinal("idMotor"));
                    motor.idMotor = idMotor;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    motor.nombre = nombre;
                    lista.Add(motor);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<SistemaOperativo> comboSistemaOperativo()
        {
            SqlConnection cn = null;
            List<SistemaOperativo> lista = new List<SistemaOperativo>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idSistema, nombre FROM SistemaOperativo";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SistemaOperativo sis = new SistemaOperativo();
                    int idSisOP = dr.GetInt32(dr.GetOrdinal("idSistema"));
                    sis.idSisOP = idSisOP; 
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    sis.nombre = nombre;
                    lista.Add(sis);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Software> comboSoftware()
        {
            SqlConnection cn = null;
            List<Software> lista = new List<Software>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idSoftware, nombre FROM Software";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Software sw = new Software();
                    int idSW = dr.GetInt32(dr.GetOrdinal("idSoftware"));
                    sw.idSoftware = idSW;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    sw.nombre = nombre;
                    lista.Add(sw);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Idioma> comboIdioma()
        {
            SqlConnection cn = null;
            List<Idioma> lista = new List<Idioma>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idIdioma, nombre FROM Idioma";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Idioma idioma = new Idioma();
                    int idIdioma = dr.GetInt32(dr.GetOrdinal("idIdioma"));
                    idioma.idIdioma = idIdioma;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    idioma.nombre = nombre;
                    lista.Add(idioma);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Provincia> obtenerProvincias(int idPais)
        {
            List<Provincia> provincias = new List<Provincia>();          
            SqlConnection cn = null;       
            try
            {
                
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT * FROM Provincia WHERE idPais=" + idPais;
                SqlCommand cmd = new SqlCommand(sql, cn);

               SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.idProvincia = dr.GetInt32(dr.GetOrdinal("idProvincia"));
                    provincia.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    provincias.Add(provincia);         
                }
                cn.Close();
                
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
            return provincias;
        }

        public static List<Ciudad> obtenerCiudades(int idProvincia)
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            SqlConnection cn = null;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT * FROM Ciudad WHERE idProvincia=" + idProvincia;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.idCiudad = dr.GetInt32(dr.GetOrdinal("idCiudad"));
                    ciudad.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    ciudades.Add(ciudad);
                }
                cn.Close();
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
            return ciudades;
        }

        public static List<Actividad> comboActividad()
        {
            SqlConnection cn = null;
            List<Actividad> lista = new List<Actividad>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idActividad, nombre FROM Actividad";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Actividad actividad = new Actividad();
                    int idExperiencia = dr.GetInt32(dr.GetOrdinal("idActividad"));
                    actividad.idActividad = idExperiencia;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    actividad.nombre = nombre;
                    lista.Add(actividad);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Jerarquia> comboJerarquia()
        {
            SqlConnection cn = null;
            List<Jerarquia> lista = new List<Jerarquia>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idJerarquia, nombre FROM Jerarquia";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Jerarquia jerarquia = new Jerarquia();
                    int idJerarquia = dr.GetInt32(dr.GetOrdinal("idJerarquia"));
                    jerarquia.idJerarquia = idJerarquia;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    jerarquia.nombre = nombre;
                    lista.Add(jerarquia);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<Area> comboArea()
        {
            SqlConnection cn = null;
            List<Area> lista = new List<Area>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idArea, nombre FROM Area";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Area area = new Area();
                    int idArea = dr.GetInt32(dr.GetOrdinal("idArea"));
                    area.idArea = idArea;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    area.nombre = nombre;
                    lista.Add(area);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public static List<DuracionExperiencia> comboDuracionExperiencia()
        {
            SqlConnection cn = null;
            List<DuracionExperiencia> lista = new List<DuracionExperiencia>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idDuracionExperiencia, nombre FROM DuracionExperiencia";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DuracionExperiencia experiencia = new DuracionExperiencia();
                    int idExperiencia = dr.GetInt32(dr.GetOrdinal("idDuracionExperiencia"));
                    experiencia.idDuracion = idExperiencia;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    experiencia.nombre = nombre;
                    lista.Add(experiencia);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }
        public static List<Nivel> comboNivel()
        {
            SqlConnection cn = null;
            List<Nivel> lista = new List<Nivel>();
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sqlText = "SELECT idNivel, nombre FROM Nivel";
                SqlCommand cmd = new SqlCommand(sqlText, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Nivel nivel = new Nivel();
                    int idNivel = dr.GetInt32(dr.GetOrdinal("idNivel"));
                    nivel.idNivel = idNivel;
                    String nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    nivel.nombre = nombre;
                    lista.Add(nivel);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return lista;
        }

    }
}