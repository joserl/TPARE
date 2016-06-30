using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TP_ARE.WebForms;
using TP_ARE.Entidades;
using System.Configuration;

namespace TP_ARE.Gestores
{
    public class GestorCurriculum
    {
        public static String cadenaConexion = ConfigurationManager.ConnectionStrings["conexionARE"].ConnectionString;

        public static void guardarCV(Usuario usuario, Candidato candidato, Domicilio domicilio, Experiencia experiencia, Curriculum curriculum, List<Conocimientos> conocimientosXCurriculum, List<MotorBD> motoresXCurriculum, List<Software> softwareXCurriculum, List<Lenguaje> lenguajeXcurriculum, List<SistemaOperativo> SOPXCurriculum, List<Idioma> idiomas)
        {
            insertarDomicilio(domicilio);
            insertarCandidato(candidato, usuario);
            insertarExperiencia(experiencia, usuario, candidato);
            insertarCV(curriculum, candidato);
            insertarConocimientoXCurriculum(conocimientosXCurriculum);
            insertarMotoresXCurriculum(motoresXCurriculum);
            insertarSoftwaresXCurriculum(softwareXCurriculum);
            insertarLenguajesXCurriculum(lenguajeXcurriculum);
            insertarSopXCurriculum(SOPXCurriculum);
            insertarIdiomasXCurriculum(idiomas);

        }

        public static void modificarCV(Curriculum currriculum, Usuario usuario, Candidato candidato, Domicilio domicilio, Experiencia experiencia, Curriculum curriculum, List<Conocimientos> conocimientosXCurriculum, List<MotorBD> motoresXCurriculum, List<Software> softwareXCurriculum, List<Lenguaje> lenguajeXcurriculum, List<SistemaOperativo> SOPXCurriculum, List<Idioma> idiomas)
        {
            //cambiar todo por modificacion
            modificarDomicilio(domicilio);
            modificarCandidato(candidato);
            modificarExperiencia(experiencia);
            modificarCV(curriculum);
            BorrarConocimientoXCurriculum(curriculum);
            modificarConocimientoXCurriculum(conocimientosXCurriculum, curriculum);
            BorrarMotoresXCurriculum(curriculum);
            modificarMotoresXCurriculum(motoresXCurriculum, curriculum);
            BorrarSoftwaresXCurriculum(curriculum);         
            modificarSoftwareXCurriculum(softwareXCurriculum, curriculum);
            BorrarLenguajesXCurriculum(curriculum);
            modificarLenguajesXCurriculum(lenguajeXcurriculum, curriculum);
            BorrarSOPXCurriculum(curriculum);
            modificarSOPXCurriculum(SOPXCurriculum, curriculum);
            BorrarIdiomaXCurriculum(curriculum);
            modificarIdiomaXCurriculum(idiomas, curriculum);
        }

        public static void insertarIdiomasXCurriculum(List<Idioma> idiomas)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (Idioma item in idiomas)
                {
                    int idIdioma = item.idIdioma;
                    int idNivelEscribe = item.idNivelEscribe;
                    int idNivelHabla = item.idNivelHabla;
                    int idNivelLee = item.idNivelLee;
                    string sql = "INSERT INTO IdiomasXCurriculum VALUES (" + idCV + "," + idIdioma + "," + idNivelEscribe + "," + idNivelHabla + "," + idNivelLee + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void BorrarIdiomaXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM IdiomasXCurriculum WHERE idCurriculum=" + cv.idCurriculum;
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
        public static void modificarIdiomaXCurriculum(List<Idioma> idioma, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (Idioma item in idioma)
                {
                    int idIdioma = item.idIdioma;
                    int idLee = item.idNivelLee;
                    int idHabla = item.idNivelHabla;
                    int idEscribe = item.idNivelEscribe;
                    string sql = "INSERT INTO IdiomasXCurriculum VALUES ("+cv.idCurriculum+","+idIdioma+","+idEscribe+","+idHabla+","+idLee+ ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }

        public static void insertarSopXCurriculum(List<SistemaOperativo> sisOP)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (SistemaOperativo item in sisOP)
                {
                    int idSistemaOp = item.idSisOP;
                    int idNivel = item.idNivel;
                    string sql = "INSERT INTO SistemaOperativoXCurriculum VALUES (" + idSistemaOp + "," + idCV + "," + idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void BorrarSOPXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM SistemaOperativoXCurriculum WHERE idCurriculum=" + cv.idCurriculum;
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

        public static void modificarSOPXCurriculum(List<SistemaOperativo> sop, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (SistemaOperativo item in sop)
                {
                    int idSop = item.idSisOP;
                    string sql = "INSERT INTO SistemaOperativoXCurriculum VALUES (" + idSop + "," + cv.idCurriculum + "," + item.idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }


        public static void insertarLenguajesXCurriculum(List<Lenguaje> lenguaje)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (Lenguaje item in lenguaje)
                {
                    int idLenguaje = item.idLenguaje;
                    int idNivel = item.idNivel;
                    string sql = "INSERT INTO LenguajesXCurriculum VALUES (" + idLenguaje + "," + idCV + "," + idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void BorrarLenguajesXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM LenguajesXCurriculum WHERE idCurriculum=" + cv.idCurriculum;
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
        public static void modificarLenguajesXCurriculum(List<Lenguaje> lenguaje, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (Lenguaje item in lenguaje)
                {
                    int idLenguaje = item.idLenguaje;
                    string sql = "INSERT INTO LenguajesXCurriculum VALUES (" + idLenguaje + "," + cv.idCurriculum + "," + item.idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }

        public static void insertarSoftwaresXCurriculum(List<Software> sw)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (Software item in sw)
                {
                    int idSoftware = item.idSoftware;
                    int idNivel = item.idNivel;
                    string sql = "INSERT INTO SoftwareXCurriculum VALUES (" + idSoftware + "," + idCV + ","+idNivel+")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void BorrarSoftwaresXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM SoftwareXCurriculum WHERE idCurriculum=" + cv.idCurriculum;
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
        public static void modificarSoftwareXCurriculum(List<Software> sw, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (Software item in sw)
                {
                    int idsw = item.idSoftware;
                    string sql = "INSERT INTO SoftwareXCurriculum VALUES (" + idsw + "," + cv.idCurriculum + "," + item.idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }

        public static void insertarMotoresXCurriculum(List<MotorBD> motores)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (MotorBD item in motores)
                {
                    int idMotor = item.idMotor;
                    int idNivel = item.idNivel;
                    string sql = "INSERT INTO MotoresBDXCurriculum VALUES (" + idMotor + "," + idCV + "," + idNivel + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void BorrarMotoresXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM MotoresBDXCurriculum WHERE idCurriculum=" + cv.idCurriculum;
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
        public static void modificarMotoresXCurriculum(List<MotorBD> motor, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (MotorBD item in motor)
                {
                    int idMotor = item.idMotor;
                    string sql = "INSERT INTO MotoresBDXCurriculum VALUES (" + idMotor + "," + cv.idCurriculum + ","+item.idNivel+")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }

        public static void insertarConocimientoXCurriculum(List<Conocimientos> conocimientos)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idCV = recuperarUltimoCV();
                foreach (Conocimientos item in conocimientos)
                {
                    int idConocimiento = item.idConocimiento;
                    string sql = "INSERT INTO ConocimientosXCurriculum VALUES (" + idConocimiento + "," + idCV + ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }
        public static void modificarConocimientoXCurriculum(List<Conocimientos> conocimientos, Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                foreach (Conocimientos item in conocimientos)
                {
                    int idConocimiento = item.idConocimiento;
                    string sql = "INSERT INTO ConocimientosXCurriculum VALUES (" + idConocimiento + "," + cv.idCurriculum+ ")";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
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
        }

        public static void BorrarConocimientoXCurriculum(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                string sql = "DELETE FROM ConocimientosXCurriculum WHERE idCurriculum="+cv.idCurriculum;
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
        public static void insertarCV(Curriculum cv, Candidato candidato)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                String sql = " INSERT INTO Curriculum (tipoDoc,nroDoc, fechaRegistro, fechaActualizacion, idDisponibilidad) VALUES(" + candidato.tipoDoc + "," + candidato.numeroDoc + ", GETDATE(),  GETDATE(), " + candidato.idDisponibilidad+")";
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

        public static void modificarCV(Curriculum cv)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                String sql = "UPDATE Curriculum ";
                sql = sql + "SET fechaActualizacion= GETDATE(),idDisponibilidad="+cv.idDisponibilidad;
                sql = sql + " WHERE idCurriculum=" + cv.idCurriculum;
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
        public static void insertarDomicilio(Domicilio domicilio)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                String sql = " INSERT INTO Domicilio (calle,Nro,idCiudad) VALUES('" + domicilio.calle + "'," + domicilio.numero + "," + domicilio.idciudad + ")";
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

        public static void modificarDomicilio(Domicilio domicilio)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                String sql = "UPDATE Domicilio SET calle='"+domicilio.calle+"', Nro="+domicilio.numero+", idCiudad="+domicilio.idciudad;
                sql = sql + " WHERE idDomicilio=" + domicilio.idDomicilio;
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

        public static void insertarCandidato(Candidato candidato, Usuario usuario)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                int idDomicilio = recuperarIdDomicilio();
                String sql = " INSERT INTO Candidato (NroDoc, TipoDoc, nombre, apellido, fechaNacimiento, telefono, email, fechaRegistro, sexo, idDomicilio, idUsuario, idEstadoCivil, idTitulo) VALUES(" + candidato.numeroDoc + "," + candidato.tipoDoc + ",'" + candidato.nombre + "','" + candidato.apellido +"','" + candidato.fechaNac + "'," + candidato.numeroTelf + ",'" + candidato.email + "',GETDATE(),"+ candidato.idSexo + "," + idDomicilio+ "," + usuario.idUsuario+ ","+candidato.idEstadoCivil +","+candidato.idTitulo+")";
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

        public static void modificarCandidato(Candidato candidato)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "UPDATE Candidato ";
                sql = sql + "SET nombre='" + candidato.nombre + "',apellido='" + candidato.apellido + "',fechaNacimiento='" + candidato.fechaNac + "', telefono=" + candidato.numeroTelf + ", email='" + candidato.email + "', sexo=" + candidato.idSexo + ", idDomicilio=" + candidato.idDomicilio + ", idUsuario=" + candidato.idUSuario + ", idEstadoCivil=" + candidato.idEstadoCivil + ", idTitulo=" + candidato.idTitulo;
                sql = sql + " WHERE nroDoc=" + candidato.numeroDoc + " AND TipoDoc=" + candidato.tipoDoc;
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

        public static void insertarExperiencia(Experiencia exp, Usuario usuario , Candidato candidato)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = " INSERT INTO Experiencia (nombreEmpresa, idActividad, idJerarquia, idDuracionExperiencia, nroDoc, tipoDoc, idArea ) VALUES('" + exp.nombreEmpresa + "'," + exp.idActividad + "," + exp.idJerarquia + "," + exp.idDuracion+ "," + candidato.numeroDoc + "," + candidato.tipoDoc + "," + exp.idArea + ")";
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

        public static void modificarExperiencia(Experiencia exp)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "UPDATE EXPERIENCIA ";
                sql = sql + "SET nombreEmpresa='" + exp.nombreEmpresa + "', idActividad=" + exp.idActividad + ", idJerarquia=" + exp.idJerarquia + ", idDuracionExperiencia=" + exp.idDuracion + ",idArea=" + exp.idArea;
                sql = sql + " WHERE TipoDoc=" + exp.tipoDoc + " AND nroDoc=" + exp.numeroDoc;
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
        public static void modificiarCV() 
        {
 
        }

        public Curriculum recuperarCurriculum(Usuario usuario)
        {
            SqlConnection cn = null;
            Curriculum cv = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cv = new Curriculum();
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
            return cv;
        }

        public static Curriculum recuperarCV(Candidato candidato)
        {
            SqlConnection cn = null;
            Curriculum cv = null;
            if (candidato != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT * FROM Curriculum WHERE nroDoc=" + candidato.numeroDoc;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cv = new Curriculum();
                        cv.idCurriculum = dr.GetInt32(dr.GetOrdinal("idCurriculum"));
                        cv.tipoDoc = candidato.tipoDoc;
                        cv.numeroDoc = candidato.numeroDoc;
                        cv.fechaRegistro = dr.GetDateTime(dr.GetOrdinal("fechaRegistro"));
                        cv.fechaActualizacion = dr.GetDateTime(dr.GetOrdinal("fechaActualizacion"));
                        cv.idDisponibilidad = dr.GetInt32(dr.GetOrdinal("idDisponibilidad"));
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
            }
            return cv;
        }

        public static Candidato recuperarCandidato(Usuario usuario)
        {
            SqlConnection cn = null;
            Candidato candidato = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT * FROM Candidato WHERE idUsuario="+usuario.idUsuario;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    candidato = new Candidato();
                    candidato.idUSuario = usuario.idUsuario;
                    candidato.idTitulo = dr.GetInt32(dr.GetOrdinal("idTitulo"));
                    candidato.numeroDoc = dr.GetInt32(dr.GetOrdinal("NroDoc"));
                    candidato.tipoDoc = dr.GetInt32(dr.GetOrdinal("TipoDoc"));
                    candidato.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                    candidato.apellido = dr.GetString(dr.GetOrdinal("apellido"));
                    candidato.fechaNacimiento = dr.GetDateTime(dr.GetOrdinal("fechaNacimiento"));
                    candidato.numeroTelf = dr.GetInt32(dr.GetOrdinal("telefono"));
                    candidato.idDomicilio = dr.GetInt32(dr.GetOrdinal("idDomicilio"));
                    candidato.email= dr.GetString(dr.GetOrdinal("email"));
                    candidato.idSexo = dr.GetInt32(dr.GetOrdinal("sexo"));
                    candidato.idEstadoCivil= dr.GetInt32(dr.GetOrdinal("idEstadoCivil"));
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
            return candidato;
        }

        public static Domicilio recuperarDomicilio(Usuario usuario)
        {
            SqlConnection cn = null;
            Domicilio domicilio =null;
            Candidato candidato = recuperarCandidato(usuario);
            if (candidato != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT D.idDomicilio, D.calle, D.Nro, D.idCiudad, P.idProvincia, PA.idPais ";
                    sql = sql + "FROM Domicilio D ,Ciudad C, Provincia P, Pais PA ";
                    sql = sql + "WHERE D.idCiudad = C.idCiudad AND C.idProvincia=P.idProvincia AND P.idPais=Pa.idPais AND D.idDomicilio=" + candidato.idDomicilio;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        domicilio = new Domicilio();
                        domicilio.idDomicilio = dr.GetInt32(dr.GetOrdinal("idDomicilio"));
                        domicilio.calle = dr.GetString(dr.GetOrdinal("Calle"));
                        domicilio.numero = dr.GetInt32(dr.GetOrdinal("Nro"));
                        domicilio.idciudad = dr.GetInt32(dr.GetOrdinal("idCiudad"));
                        domicilio.idProvincia = dr.GetInt32(dr.GetOrdinal("idProvincia"));
                        domicilio.idPais = dr.GetInt32(dr.GetOrdinal("idPais"));
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
            }
            return domicilio;
        }

        public static int recuperarUltimoCV()
        {
            SqlConnection cn = null;
            int idCv = 0;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT MAX(idCurriculum) idCurriculum ";
                sql = sql + "FROM Curriculum";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idCv = dr.GetInt32(dr.GetOrdinal("idCurriculum"));
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
            return idCv;
        }

        public static int recuperarIdDomicilio()
        {
            SqlConnection cn = null;
            int idDomicilio = 0;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                String sql = "SELECT MAX(idDomicilio) idDomicilio ";
                sql = sql + "FROM Domicilio";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idDomicilio = dr.GetInt32(dr.GetOrdinal("idDomicilio"));
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
        public static Experiencia recuperarExperiencia(Usuario usuario)
        {
            SqlConnection cn = null;
            Experiencia experiencia = null;
            Candidato candidato = recuperarCandidato(usuario);
            if (candidato != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT * ";
                    sql = sql + "FROM Experiencia ";
                    sql = sql + "WHERE NroDoc=" + candidato.numeroDoc;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        experiencia = new Experiencia();
                        experiencia.idExperiencia = dr.GetInt32(dr.GetOrdinal("idExperiencia"));
                        experiencia.nombreEmpresa = dr.GetString(dr.GetOrdinal("nombreEmpresa"));
                        experiencia.idActividad = dr.GetInt32(dr.GetOrdinal("idActividad"));
                        experiencia.idJerarquia = dr.GetInt32(dr.GetOrdinal("idJerarquia"));
                        experiencia.idDuracion = dr.GetInt32(dr.GetOrdinal("idDuracionExperiencia"));
                        experiencia.numeroDoc = candidato.numeroDoc;
                        experiencia.tipoDoc = candidato.tipoDoc;
                        experiencia.idArea = dr.GetInt32(dr.GetOrdinal("idArea"));
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
            }
            return experiencia;
        }

        public static List<Conocimientos> recuperarConocimientos(Usuario usuario)
        {
            SqlConnection cn = null;
            List<Conocimientos> conocimientos = new List<Conocimientos>();
            Candidato candidato = recuperarCandidato(usuario);
            if (candidato != null)
            {
                Curriculum cv = recuperarCV(candidato);
                if (cv!=null)
                { 
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT C.idConocimiento, C.concimiento ";
                    sql = sql + "FROM ConocimientosXCurriculum CC, Conocimiento C ";
                    sql = sql + "WHERE c.idConocimiento= CC.idConocimiento AND CC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Conocimientos con = new Conocimientos();
                        con.idConocimiento = dr.GetInt32(dr.GetOrdinal("idConocimiento"));
                        con.conocimiento = dr.GetString(dr.GetOrdinal("concimiento"));
                        conocimientos.Add(con);
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
                }
            }
            return conocimientos;
        }

        public static List<Software> recuperarSoftware(Curriculum cv)
        {
            SqlConnection cn = null;
            List<Software> lisSw = new List<Software>();
            if (cv != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT SC.idSoftware, SC.idNivel, S.nombre, N.nombre nombre2 ";
                    sql = sql + "FROM SoftwareXCurriculum SC, Software S, Nivel N ";
                    sql = sql + "WHERE S.idSoftware=SC.idSoftware AND SC.idNivel=N.idNivel AND SC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Software sw = new Software();
                        sw.idSoftware = dr.GetInt32(dr.GetOrdinal("idSoftware"));
                        sw.idNivel = dr.GetInt32(dr.GetOrdinal("idNivel"));
                        sw.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                        sw.nivel = dr.GetString(dr.GetOrdinal("nombre2"));
                        lisSw.Add(sw);
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
            }
            return lisSw;
        }

        public static List<MotorBD> recuperarMotores(Curriculum cv)
        {
            SqlConnection cn = null;
            List<MotorBD> motorBD = new List<MotorBD>();
            if (cv != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT MC.idMotorBD, MC.idNivel, M.nombre, N.nombre nombre2 ";
                    sql = sql + "FROM MotoresBDXCurriculum MC, MotoresBD M, Nivel N ";
                    sql = sql + "WHERE M.idMotor=MC.idMotorBD AND N.idNivel=MC.idNivel AND MC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        MotorBD mb = new MotorBD();
                        mb.idMotor = dr.GetInt32(dr.GetOrdinal("idMotorBD"));
                        mb.idNivel = dr.GetInt32(dr.GetOrdinal("idNivel"));
                        mb.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                        mb.nivel = dr.GetString(dr.GetOrdinal("nombre2"));
                        motorBD.Add(mb);
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
            }
            return motorBD;
        }

        public static List<Lenguaje> recuperarLenguajes(Curriculum cv)
        {
            SqlConnection cn = null;
            List<Lenguaje> listLenguaje = new List<Lenguaje>();
            if (cv != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT LC.idLenguaje, LC.idNivel, L.nombre, N.nombre nombre2 ";
                    sql = sql + "FROM LenguajesXCurriculum LC, LenguajesDeProgramacion L, Nivel N  ";
                    sql = sql + "WHERE L.idLenguaje=LC.idLenguaje AND LC.idNivel=N.idNivel AND LC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Lenguaje lenguaje = new Lenguaje();
                        lenguaje.idLenguaje = dr.GetInt32(dr.GetOrdinal("idLenguaje"));
                        lenguaje.idNivel = dr.GetInt32(dr.GetOrdinal("idNivel"));
                        lenguaje.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                        lenguaje.nivel = dr.GetString(dr.GetOrdinal("nombre2"));
                        listLenguaje.Add(lenguaje);
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
            }
            return listLenguaje;
        }

        public static List<SistemaOperativo> recuperarSOP(Curriculum cv)
        {
            SqlConnection cn = null;
            List<SistemaOperativo> listSOP = new List<SistemaOperativo>();
            if (cv != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    String sql = "SELECT SC.idSop, SC.idNivel, SO.nombre, N.nombre nombre2 ";
                    sql = sql + "FROM SistemaOperativoXCurriculum SC, SistemaOperativo SO, Nivel N ";
                    sql = sql + "WHERE SO.idSistema=SC.idSop AND SC.idNivel=N.idNivel AND SC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        SistemaOperativo sop = new SistemaOperativo();
                        sop.idSisOP = dr.GetInt32(dr.GetOrdinal("idSop"));
                        sop.idNivel = dr.GetInt32(dr.GetOrdinal("idNivel"));
                        sop.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                        sop.nivel = dr.GetString(dr.GetOrdinal("nombre2"));
                        listSOP.Add(sop);
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
            }
                return listSOP;
            
        }

        public static List<Idioma> recuperarIdioma(Curriculum cv)
        {
            SqlConnection cn = null;
            List<Idioma> listIdioma = new List<Idioma>();
            if (cv != null)
            {
                try
                {
                    cn = new SqlConnection(cadenaConexion);
                    cn.Open();
                    //nose como hacer la cnsulta
                    String sql = "SELECT * ";
                    sql = sql + "FROM IdiomasXCurriculum IC, Idioma I ";
                    sql = sql + "WHERE IC.idIdioma=I.idIdioma AND IC.idCurriculum=" + cv.idCurriculum;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Idioma idioma = new Idioma();
                        idioma.idIdioma = dr.GetInt32(dr.GetOrdinal("idIdioma"));
                        idioma.nombre = dr.GetString(dr.GetOrdinal("nombre"));
                        idioma.idNivelEscribe = dr.GetInt32(dr.GetOrdinal("idNivelEscribe"));
                        idioma.nivelEscribe = recuperarNombreNivel(idioma.idNivelEscribe);
                        idioma.idNivelHabla = dr.GetInt32(dr.GetOrdinal("idNivelHabla"));
                        idioma.nivelHabla = recuperarNombreNivel(idioma.idNivelHabla);
                        idioma.idNivelLee = dr.GetInt32(dr.GetOrdinal("idNivelLee"));
                        idioma.nivelLee = recuperarNombreNivel(idioma.idNivelLee);
                        listIdioma.Add(idioma);
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
            }
                return listIdioma;
           
        }

        public static String recuperarNombreNivel(int id)
        {
            SqlConnection cn = null;
            String nombre = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                //nose como hacer la cnsulta
                String sql = "SELECT * ";
                sql = sql + "FROM Nivel ";
                sql = sql + "WHERE idNivel=" + id;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nombre = dr.GetString(dr.GetOrdinal("nombre"));
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
            return nombre;
        }
    }
}