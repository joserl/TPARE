using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_ARE.Gestores;
using TP_ARE.Entidades;
using System.Data;
using System.Xml;
namespace TP_ARE.WebForms
{
    public partial class CargarCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null) // si el usuario ya se logeo recuperaremos su cv si lo tiene
            {       
                if (!IsPostBack)
                {
                    cargarCombos();
                    List<Lenguaje> listaLenguaje = new List<Lenguaje>();
                    List<MotorBD> listaMotores = new List<MotorBD>();
                    List<Software> listaSoftware = new List<Software>();
                    List<SistemaOperativo> listaSOP = new List<SistemaOperativo>();
                    List<Idioma> listaIdioma = new List<Idioma>();
                
                Usuario usuario = (Usuario)Session["usuario"];
                Session["bandera"] = false;
                if (usuario != null)
                    {               
                    Domicilio domicilio = recuperarDomicilio(usuario);
                    Candidato candidato = recuperarCandidato(usuario);
                    Experiencia experiencia = recuperarExperiencia(usuario);
                    Curriculum curriculum = recuperarCurriculum(candidato);
                    List<Conocimientos> conocimientosXCurriculum = recuperarConocimientos(usuario);
                    List<MotorBD> motoresXCurriculum = recuperarMotores(curriculum);
                    List<Software> softwarXCurriculum = recuperarSoftware(curriculum);
                    List<Lenguaje> lenguajesXCurriculum = recuperarLenguajes(curriculum);
                    List<SistemaOperativo> SOPXCurriculum = recuperarSOP(curriculum);
                    List<Idioma> idiomasXCurriculum = recuperarIdiomas(curriculum);
                    rellenarCamposCVRecuperado(domicilio, candidato,experiencia,conocimientosXCurriculum,curriculum,motoresXCurriculum,softwarXCurriculum, lenguajesXCurriculum, SOPXCurriculum, idiomasXCurriculum);
                    
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((Boolean)Session["bandera"] == false) //inserta
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Domicilio domicilio = crearDomicilio();
                Candidato candidato = crearCandidato();
                Experiencia experiencia = crearExperiencia();
                Curriculum curriculum = crearCurriculum();
                List<Conocimientos> conocimientosXCurriculum = crearConocimientos();
                List<MotorBD> motoresXCurriculum = (List<MotorBD>)Session["listaBD"];
                List<Software> softwarXCurriculm = (List<Software>)Session["listaSW"];
                List<Lenguaje> lenguajesXCurriculum = (List<Lenguaje>)Session["listaLenguaje"];
                List<SistemaOperativo> SOPXCurriculum = (List<SistemaOperativo>)Session["listaSOP"];
                List<Idioma> idiomas = (List<Idioma>)Session["listaIdioma"];
                GestorCurriculum.guardarCV(usuario, candidato, domicilio, experiencia, curriculum, conocimientosXCurriculum, motoresXCurriculum, softwarXCurriculm, lenguajesXCurriculum, SOPXCurriculum, idiomas);
                Response.Write("<script>alert('El curriculum se a guardo con exito');document.location.href='./Inicio.aspx';</script>");
            }
            else //modifica
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Domicilio domicilio = crearDomicilio();
                Candidato candidato = crearCandidato();
                Experiencia experiencia = crearExperiencia();
                Curriculum curriculum = crearCurriculum();
                List<Conocimientos> conocimientosXCurriculum = crearConocimientos();
                List<MotorBD> motoresXCurriculum = (List<MotorBD>)Session["listaBD"];
                List<Software> softwarXCurriculm = (List<Software>)Session["listaSW"];
                List<Lenguaje> lenguajesXCurriculum = (List<Lenguaje>)Session["listaLenguaje"];
                List<SistemaOperativo> SOPXCurriculum = (List<SistemaOperativo>)Session["listaSOP"];
                List<Idioma> idiomas = (List<Idioma>)Session["listaIdioma"];
                GestorCurriculum.modificarCV(curriculum,usuario,candidato, domicilio, experiencia, curriculum, conocimientosXCurriculum, motoresXCurriculum, softwarXCurriculm, lenguajesXCurriculum, SOPXCurriculum, idiomas);
                Response.Write("<script>alert('El curriculum se a guardo con exito');document.location.href='./Inicio.aspx';</script>");
            }

        }

        public void rellenarCamposCVRecuperado(Domicilio domicilio, Candidato candidato, Experiencia experiencia, List<Conocimientos> conocimientosXCurriculum, Curriculum curriculum, List<MotorBD> motoresXCurriculum, List<Software> softwarXCurriculum, List<Lenguaje> lenguajesXCurriculum, List<SistemaOperativo> SOPXCurriculum, List<Idioma> idiomasXCurriculum)
        {
            if (domicilio != null)
            {
                Session["bandera"] = true;
                txtCalle.Text = domicilio.calle;
                txtNro.Text = domicilio.numero.ToString();
                cbPais.SelectedIndex = domicilio.idPais;
                obtenerProvincias(domicilio.idPais);
                cbProvincia.SelectedValue = domicilio.idProvincia.ToString();
                obtenerCiudades(domicilio.idProvincia);
                cbCiudad.SelectedValue = domicilio.idciudad.ToString();
            }
            if (candidato != null)
            {
                Session["bandera"] = true;
                txtNombre.Text = candidato.nombre;
                txtApellido.Text = candidato.apellido;
                txtNumeroDoc.Text = candidato.numeroDoc.ToString();
                String fecha = candidato.fechaNacimiento.ToString();
                String[] cadena = fecha.Split('/', ' ');
                cbDia.SelectedValue = cadena[0];
                cbMes.SelectedValue = cadena[1];
                cbAno.SelectedValue = cadena[2];
                if(candidato.idSexo==1)
                {
                    optMasculino.Checked = true;
                }
                else
                {
                    optFemenino.Checked= true;
                }
                txtEmail.Text = candidato.email.ToString();
                cbTipoDoc.SelectedValue = candidato.tipoDoc.ToString();
                txtTelFijo.Text = candidato.numeroTelf.ToString();
                cbEstadoCivil.SelectedValue = candidato.idEstadoCivil.ToString();
                cbDisponibilidad.SelectedIndex = candidato.idDisponibilidad;
                cbTitulo.SelectedValue = candidato.idTitulo.ToString();

            }
            if (experiencia != null)
            {
                Session["bandera"] = true;
                txtNombreEmpresa.Text = experiencia.nombreEmpresa;
                cbActivdad.SelectedValue = experiencia.idActividad.ToString();
                cbJerarquia.SelectedValue = experiencia.idJerarquia.ToString();
                cbArea.SelectedValue = experiencia.idArea.ToString();
                cbTiempo.SelectedValue = experiencia.idDuracion.ToString();
            }
            if (conocimientosXCurriculum != null)
            {
                Session["bandera"] = true;
                foreach (Conocimientos item in conocimientosXCurriculum)
                {
                    if (item.idConocimiento == 1)
                    {
                        cbxHerraOffice.Checked = true;
                    }
                    if (item.idConocimiento == 2)
                    {
                        cbxSofModelado.Checked = true;
                    }
                    if (item.idConocimiento == 3)
                    {
                        cbxRedes.Checked = true;
                    }
                    if (item.idConocimiento == 4)
                    {
                        cbxBaseDatos.Checked = true;
                    }
                }
            }
            if (motoresXCurriculum!=null)
            {
                Session["bandera"] = true;
                gvMotores.DataSource = motoresXCurriculum;
                gvMotores.DataBind();
                Session["listaBD"] = motoresXCurriculum;
            }
            if (softwarXCurriculum!=null)
            {
                Session["bandera"] = true;
                gvSoftware.DataSource = softwarXCurriculum;
                gvSoftware.DataBind();
                Session["listaSW"] = softwarXCurriculum;

            }
            if (lenguajesXCurriculum != null)
            {
                Session["bandera"] = true;
                gvLenguajes.DataSource = lenguajesXCurriculum;
                gvLenguajes.DataBind();
                Session["listaLenguaje"] = lenguajesXCurriculum;
            }
            if (SOPXCurriculum != null)
            {
                Session["bandera"] = true;
                gvSOP.DataSource = SOPXCurriculum;
                gvSOP.DataBind();
                Session["listaSOP"] = SOPXCurriculum;
            }
            if (idiomasXCurriculum != null)
            {
                Session["bandera"] = true;
                gvIdioma.DataSource = idiomasXCurriculum;
                gvIdioma.DataBind();
                Session["listaIdioma"] = idiomasXCurriculum;
            }

        }

        public Experiencia crearExperiencia()
        {
            Experiencia experiencia = new Experiencia();
            String nombreEmpresa = txtNombreEmpresa.Text.ToString();
            experiencia.nombreEmpresa = nombreEmpresa;
            int idActividad = Convert.ToInt32(cbActivdad.SelectedValue);
            experiencia.idActividad = idActividad;
            int idJerarquia = Convert.ToInt32(cbJerarquia.SelectedValue);
            experiencia.idJerarquia=idJerarquia;
            int idDuracion = Convert.ToInt32(cbTiempo.SelectedValue);
            experiencia.idDuracion= idDuracion;
            int idArea = Convert.ToInt32(cbArea.SelectedValue);
            experiencia.idArea = idArea;
            if (Session["usuario"] != null)
            {
                if (recuperarExperiencia((Usuario)Session["usuario"]) != null)
                {
                    experiencia.idExperiencia = recuperarExperiencia((Usuario)Session["usuario"]).idExperiencia;
                    experiencia.numeroDoc = recuperarExperiencia((Usuario)Session["usuario"]).numeroDoc;
                    experiencia.tipoDoc = recuperarExperiencia((Usuario)Session["usuario"]).tipoDoc;
                }
            }

            return experiencia;
        }

        public List<Conocimientos> crearConocimientos()
        {   
            List<Conocimientos> conocimientos = new List<Conocimientos>();
            if (cbxHerraOffice.Checked == true)
            {
                Conocimientos conocimiento = new Conocimientos();
                conocimiento.conocimiento = cbxHerraOffice.Text;
                conocimiento.idConocimiento = 1;
                conocimientos.Add(conocimiento);
            }
            if (cbxBaseDatos.Checked == true)
            {
                Conocimientos conocimiento = new Conocimientos();
                conocimiento.conocimiento = cbxBaseDatos.Text;
                conocimiento.idConocimiento = 4;
                conocimientos.Add(conocimiento);
            }
            if (cbxRedes.Checked == true)
            {
                Conocimientos conocimiento = new Conocimientos();
                conocimiento.conocimiento = cbxRedes.Text;
                conocimiento.idConocimiento = 3;
                conocimientos.Add(conocimiento);
            }
            if (cbxSofModelado.Checked == true)
            {
                Conocimientos conocimiento = new Conocimientos();
                conocimiento.conocimiento = cbxSofModelado.Text;
                conocimiento.idConocimiento = 2; 
                conocimientos.Add(conocimiento);
            }
            return conocimientos;
        }

        public Candidato crearCandidato()
        {
            Candidato candidato = new Candidato();
            String nombre = txtNombre.Text;
            candidato.nombre = nombre;
            String apellido = txtApellido.Text;
            candidato.apellido = apellido;
            String dia = cbDia.SelectedValue.ToString();
            String mes = cbMes.SelectedValue.ToString();
            String ano = cbAno.SelectedValue.ToString();
            String fecha = ano+"/"+mes+"/"+dia;
            candidato.fechaNac = fecha;
            DateTime fechaNacimiento = Convert.ToDateTime(fecha.ToString());
            candidato.fechaNacimiento = fechaNacimiento;
            int TipoDoc = Convert.ToInt32(cbTipoDoc.SelectedValue);
            candidato.tipoDoc = TipoDoc;
            int numeroDoc = Convert.ToInt32(txtNumeroDoc.Text);
            candidato.numeroDoc = numeroDoc;
            if (optFemenino.Checked == true)
            {
                String sexo = optFemenino.Text;
                candidato.sexo = sexo;
                candidato.idSexo = 1;
            }
            else
            {
                String sexo = optMasculino.Text;
                candidato.sexo = sexo;
                candidato.idSexo = 1;
            }
            String email = txtEmail.Text;
            candidato.email = email;
            int telefono = Convert.ToInt32(txtTelFijo.Text);
            candidato.numeroTelf = telefono;
            int idEstadoCivil = Convert.ToInt32(cbEstadoCivil.SelectedValue);
            candidato.idEstadoCivil = idEstadoCivil;
            int idDisponibilidad = Convert.ToInt32(cbDisponibilidad.SelectedValue);
            candidato.idDisponibilidad = idDisponibilidad;
            Usuario usuario = (Usuario)Session["usuario"];
            int idUsuario = usuario.idUsuario;
            candidato.idUSuario =idUsuario;
            candidato.idTitulo = Convert.ToInt32(cbTitulo.SelectedValue);
            if (recuperarDomicilio(usuario) != null)
            {
                candidato.idDomicilio = recuperarDomicilio(usuario).idDomicilio;
            }
            return candidato;
        }
        public Domicilio crearDomicilio()
        {
            Domicilio domicilio = new Domicilio();
            String calle = txtCalle.Text;
            domicilio.calle = calle;
            int numero = Convert.ToInt32(txtNro.Text);
            domicilio.numero = numero;
            int ciudad = Convert.ToInt32(cbCiudad.SelectedValue);
            domicilio.idciudad = ciudad;
            int idProvincia = Convert.ToInt32(cbProvincia.SelectedValue);
            domicilio.idProvincia = idProvincia;
            int idPais = Convert.ToInt32(cbPais.SelectedValue);
            domicilio.idPais = idPais;
            if (Session["usuario"] != null)
            {
                if (recuperarDomicilio((Usuario)Session["usuario"])!=null)
                {
                    domicilio.idDomicilio = recuperarDomicilio((Usuario)Session["usuario"]).idDomicilio;
                }
            }
            return domicilio;
        }

        public Curriculum crearCurriculum()
        {
            Curriculum curriculum = new Curriculum();
            int TipoDoc = Convert.ToInt32(cbTipoDoc.SelectedValue);
            curriculum.tipoDoc = TipoDoc;
            int numeroDoc = Convert.ToInt32(txtNumeroDoc.Text);
            curriculum.numeroDoc = numeroDoc;
            String disponibilidad = cbDisponibilidad.SelectedItem.ToString() ;
            curriculum.disponibilidad = disponibilidad;
            DateTime fechaRegistro =Convert.ToDateTime(DateTime.Now.ToString());
            curriculum.fechaRegistro =fechaRegistro;
            if(Session["Usuario"]!=null)
            {
                Candidato candidato = recuperarCandidato((Usuario)Session["usuario"]);
                if (candidato != null)
                {
                    curriculum.idCurriculum = recuperarCurriculum(candidato).idCurriculum;
                    curriculum.idDisponibilidad = recuperarCurriculum(candidato).idDisponibilidad;
                }
            }
            return curriculum;
        }

        protected void btnAgregarMotores_Click(object sender, EventArgs e)
        {
            MotorBD motor = new MotorBD();
            int idMotor = Convert.ToInt32(cbMotor.SelectedValue);
            motor.idMotor = idMotor;

            String nombre = cbMotor.SelectedItem.ToString();
            motor.nombre = nombre;

            int idNivelMotor = Convert.ToInt32(cbNivelMotor.SelectedValue);
            motor.idNivel = idNivelMotor;
            String nivel = cbNivelMotor.SelectedItem.ToString();
            motor.nivel = nivel;
            cargarGrillaMotores(motor);           
        }

        protected void btnAgregarLenguaje_Click(object sender, EventArgs e)
        {
            Lenguaje lenguaje = new Lenguaje();
            int idLenguaje = Convert.ToInt32(cbLenguaje.SelectedValue);
            lenguaje.idLenguaje = idLenguaje;

            String nombre = cbLenguaje.SelectedItem.ToString();
            lenguaje.nombre = nombre;

            int idNivelLenguaje = Convert.ToInt32(cbNivelLenguaje.SelectedValue);
            lenguaje.idNivel = idNivelLenguaje;
            String nivel = cbNivelLenguaje.SelectedItem.ToString();
            lenguaje.nivel = nivel;
            cargarGrillaLenguajes(lenguaje); 
        }

        protected void btnAgregarSOP_Click(object sender, EventArgs e)
        {
            SistemaOperativo sisOP = new SistemaOperativo();
            int idSisOP = Convert.ToInt32(cbSOP.SelectedValue);
            sisOP.idSisOP = idSisOP;
            String nombre = cbSOP.SelectedItem.ToString();
            sisOP.nombre = nombre;
            int nivelSOP = Convert.ToInt32(cbNivelSOP.SelectedValue);
            sisOP.idNivel = nivelSOP;
            String nivel = cbNivelSOP.SelectedItem.ToString();
            sisOP.nivel = nivel;
            cargarGrillaSOP(sisOP);
        }
        protected void btnAgregarSW_Click(object sender, EventArgs e)
        {
            Software sw = new Software();
            int idSoftware= Convert.ToInt32(cbSW.SelectedValue);
            sw.idSoftware = idSoftware;
            String nombre = cbSW.SelectedItem.ToString();
            sw.nombre = nombre;
            int idNivelSW = Convert.ToInt32(cbNivelSW.SelectedValue);
            sw.idNivel = idNivelSW;
            String nivel = cbNivelSW.SelectedItem.ToString();
            sw.nivel = nivel;
            cargarGrillaSoftwares(sw);
        }

        public void cargarCombos()
        {
            cargarComboTipoDoc();
            cargarComboPaises();
            //cargarComboProvincias();
            //cargarCombociudades();
            cargarComboEstadocivil();
            cargarComboDisponibilidad();
            cargarComboTitulo();
            cargarComboLenguaje();
            cargarComboMotores();
            cargarComboSW();
            cargarComboSOP();
            cargarComboNiveles();
            cargarComboIdiomas();
            cargarComboActividad();
            cargarComboJerarquia();
            cargarComboArea();
            cargarComboTiempo();
        }

        public void cargarComboIdiomas()
        {
            List<Idioma> idiomas = GestorCombosYTablas.comboIdioma();
            cbIdioma.DataSource = idiomas;
            cbIdioma.DataTextField = "nombre";
            cbIdioma.DataValueField = "idIdioma";
            cbIdioma.DataBind();
        }


        public void cargarComboActividad()
        {
            List<Actividad> actividad = GestorCombosYTablas.comboActividad();
            cbActivdad.DataSource = actividad;
            cbActivdad.DataTextField = "nombre";
            cbActivdad.DataValueField = "idActividad";
            cbActivdad.DataBind();
        }
        public void cargarComboJerarquia()
        {
            List<Jerarquia> jerarquia = GestorCombosYTablas.comboJerarquia();
            cbJerarquia.DataSource = jerarquia;
            cbJerarquia.DataTextField = "nombre";
            cbJerarquia.DataValueField = "idJerarquia";
            cbJerarquia.DataBind();
        }
        public void cargarComboArea()
        {
            List<Area> area = GestorCombosYTablas.comboArea();
            cbArea.DataSource = area;
            cbArea.DataTextField = "nombre";
            cbArea.DataValueField = "idArea";
            cbArea.DataBind();
        }
        public void cargarComboTiempo()
        {
            List<DuracionExperiencia> experiencia = GestorCombosYTablas.comboDuracionExperiencia();
            cbTiempo.DataSource = experiencia;
            cbTiempo.DataTextField = "nombre";
            cbTiempo.DataValueField = "idDuracion";
            cbTiempo.DataBind();
        }

        public void cargarComboEstadocivil()
        {
            List<EstadoCivil> estadoCivil = GestorCombosYTablas.comboEstadoCivil();
            cbEstadoCivil.DataSource = estadoCivil;
            cbEstadoCivil.DataTextField = "nombre";
            cbEstadoCivil.DataValueField = "idEstadoCivil";
            cbEstadoCivil.DataBind();
        }
        public void cargarComboDisponibilidad()
        {
            List<Disponibilidad> disponibilidad = GestorCombosYTablas.comboDisponibilidad();
            cbDisponibilidad.DataSource = disponibilidad;
            cbDisponibilidad.DataTextField = "nombre";
            cbDisponibilidad.DataValueField = "idDisponibilidad";
            cbDisponibilidad.DataBind();

        }
        public void cargarComboTipoDoc()
        {
            List<TipoDoc> tiposDoc = GestorCombosYTablas.comboTiposDoc();
            cbTipoDoc.DataSource = tiposDoc;
            cbTipoDoc.DataTextField = "nombre";
            cbTipoDoc.DataValueField = "idTipoDoc";
            cbTipoDoc.DataBind();
        }

        public void cargarComboPaises()
        {
            List<Pais> paises = GestorCombosYTablas.comboPaises();
            cbPais.DataSource = paises;
            cbPais.DataTextField = "nombre";
            cbPais.DataValueField = "idPais";
            cbPais.DataBind();
            cbPais.Items.Insert(0, new ListItem("Seleccione una opcion"));
        }

        public void cargarComboProvincias()
        {
            List<Provincia> paises = GestorCombosYTablas.comboProvincia();
            cbProvincia.DataSource = paises;
            cbProvincia.DataTextField = "nombre";
            cbProvincia.DataValueField = "idProvincia";
            cbProvincia.DataBind();
            
        }
        public void cargarCombociudades()
        {
            List<Ciudad> paises = GestorCombosYTablas.comboCiudad();
            cbCiudad.DataSource = paises;
            cbCiudad.DataTextField = "nombre";
            cbCiudad.DataValueField = "idCiudad";
            cbCiudad.DataBind();
        }

        public void cargarComboTitulo()
        {
            List<Titulo> titulo = GestorCombosYTablas.comboTitulo();
            cbTitulo.DataSource = titulo;
            cbTitulo.DataTextField = "nombre";
            cbTitulo.DataValueField = "idTitulo";
            cbTitulo.DataBind();
        }

        public void cargarComboLenguaje()
        {
            List<Lenguaje> lenguajes = GestorCombosYTablas.comboLenguaje();
            cbLenguaje.DataSource = lenguajes;
            cbLenguaje.DataTextField = "nombre";
            cbLenguaje.DataValueField = "idLenguaje";
            cbLenguaje.DataBind();
        }

        public void cargarComboMotores()
        {
            List<MotorBD> motores = GestorCombosYTablas.comboMotores();
            cbMotor.DataSource = motores;
            cbMotor.DataTextField = "nombre";
            cbMotor.DataValueField = "idMotor";
            cbMotor.DataBind();
        }
        public void cargarComboSW()
        {
            List<Software> software = GestorCombosYTablas.comboSoftware();
            cbSW.DataSource = software;
            cbSW.DataTextField = "nombre";
            cbSW.DataValueField = "idSoftware";
            cbSW.DataBind();
        }
        public void cargarComboSOP()
        {
            List<SistemaOperativo> sistemaOperativo = GestorCombosYTablas.comboSistemaOperativo();
            cbSOP.DataSource = sistemaOperativo;
            cbSOP.DataTextField = "nombre";
            cbSOP.DataValueField = "idSisOP";
            cbSOP.DataBind();
        }
        public void cargarComboNiveles()
        {
            List<Nivel> niveles = GestorCombosYTablas.comboNivel();
            cbNivelLenguaje.DataSource = niveles;
            cbNivelMotor.DataSource = niveles;
            cbNivelSOP.DataSource = niveles;
            cbNivelSW.DataSource = niveles;
            cbLee.DataSource = niveles;
            cbHabla.DataSource = niveles;
            cbEscribe.DataSource = niveles;

            cbNivelLenguaje.DataTextField = "nombre";
            cbNivelMotor.DataTextField = "nombre";
            cbNivelSOP.DataTextField= "nombre";
            cbNivelSW.DataTextField = "nombre";
            cbLee.DataTextField = "nombre";
            cbHabla.DataTextField = "nombre";
            cbEscribe.DataTextField = "nombre";

            cbNivelLenguaje.DataValueField = "idNivel";
            cbNivelMotor.DataValueField = "idNivel";
            cbNivelSOP.DataValueField = "idNivel";
            cbNivelSW.DataValueField = "idNivel";
            cbLee.DataValueField = "idNivel";
            cbHabla.DataValueField = "idNivel";
            cbEscribe.DataValueField = "idNivel";

            cbNivelLenguaje.DataBind();
            cbNivelMotor.DataBind(); 
            cbNivelSOP.DataBind(); 
            cbNivelSW.DataBind();
            cbLee.DataBind();
            cbHabla.DataBind();
            cbEscribe.DataBind();
        }

        public void cargarGrillaLenguajes(Lenguaje lenguaje)
        {
            if (Session["listaLenguaje"] == null)
            {
                List<Lenguaje> listaLenguaje = new List<Lenguaje>(); 
                listaLenguaje.Add(lenguaje);
                gvLenguajes.DataSource = listaLenguaje;
                gvLenguajes.DataBind();
                Session["listaLenguaje"] = listaLenguaje;
            }
            else 
            {
                List<Lenguaje> listaLenguaje = (List<Lenguaje>)Session["listaLenguaje"];
                listaLenguaje.Add(lenguaje);
                
                gvLenguajes.DataSource = listaLenguaje;
                gvLenguajes.DataBind();
                Session["listaLenguaje"] = listaLenguaje;
            }
        }

        public void cargarGrillaMotores(MotorBD motor)
        {
            if (Session["listaBD"] == null)
            {
                List<MotorBD> listaBD = new List<MotorBD>();
                listaBD.Add(motor);
                gvMotores.DataSource = listaBD;
                gvMotores.DataBind();
                Session["listaBD"] = listaBD;
            }
            else
            {
                List<MotorBD> listaBD = (List<MotorBD>)Session["listaBD"];
                listaBD.Add(motor);
                gvMotores.DataSource = listaBD;
                gvMotores.DataBind();
                Session["listaBD"] = listaBD;
            }

        }

        public void cargarGrillaSoftwares(Software software)
        {
            if (Session["listaSW"] == null)
            {
                List<Software> listaSW = new List<Software>();
                listaSW.Add(software);
                gvSoftware.DataSource = listaSW;
                gvSoftware.DataBind();
                Session["listaSW"] = listaSW;
            }
            else
            {
                List<Software> listaSW = (List<Software>)Session["listaSW"];
                listaSW.Add(software);
                gvSoftware.DataSource = listaSW;
                gvSoftware.DataBind();
                Session["listaSW"] = listaSW;
            }
        }

        public void cargarGrillaSOP(SistemaOperativo sop)
        {
            if (Session["listaSOP"] == null)
            {
                List<SistemaOperativo> listaSOP = new List<SistemaOperativo>();
                listaSOP.Add(sop);
                gvSOP.DataSource = listaSOP;
                gvSOP.DataBind();
                Session["listaSOP"] = listaSOP;
            }
            else
            {
                List<SistemaOperativo> listaSOP = (List<SistemaOperativo>)Session["listaSOP"];
                listaSOP.Add(sop);
                gvSOP.DataSource = listaSOP;
                gvSOP.DataBind();
                Session["listaSOP"] = listaSOP;
            }
        }

        public Curriculum recuperarCurriculum(Candidato candidato)
        {
            Curriculum cv = null;
            cv = GestorCurriculum.recuperarCV(candidato);
            return cv;
 
        }

        public Candidato recuperarCandidato(Usuario usuario)
        {
            Candidato candidato = null;
            candidato = GestorCurriculum.recuperarCandidato(usuario);
            return candidato;
 
        }

        public Domicilio recuperarDomicilio(Usuario usuario)
        {
            Domicilio domicilio = null;
            domicilio = GestorCurriculum.recuperarDomicilio(usuario);
            return domicilio;
        }

        public Experiencia recuperarExperiencia(Usuario usuario)
        {
            Experiencia experiencia = null;
            experiencia = GestorCurriculum.recuperarExperiencia(usuario);
            return experiencia;
        }

        public List<Conocimientos> recuperarConocimientos(Usuario usuario)
        {
            List<Conocimientos> conocimientos = null;
            conocimientos =  GestorCurriculum.recuperarConocimientos(usuario);
            return conocimientos;
        }

        public List<MotorBD> recuperarMotores(Curriculum cv)
        {
            List<MotorBD> listaMotores = null;
            listaMotores = GestorCurriculum.recuperarMotores(cv);
            return listaMotores;
        }

        public List<Lenguaje> recuperarLenguajes(Curriculum cv)
        {
            List<Lenguaje> lenguaje = null;
            lenguaje = GestorCurriculum.recuperarLenguajes(cv);
            return lenguaje;
        }

        public List<Software> recuperarSoftware(Curriculum cv)
        {
            List<Software> software = null;
            software = GestorCurriculum.recuperarSoftware(cv);
            return software;
        }

        public List<SistemaOperativo> recuperarSOP(Curriculum cv)
        {
            List<SistemaOperativo> sisOP = null;
            sisOP = GestorCurriculum.recuperarSOP(cv);
            return sisOP;
        }

        public List<Idioma> recuperarIdiomas(Curriculum cv)
        {
            List<Idioma> idiomas = null;
            idiomas = GestorCurriculum.recuperarIdioma(cv);
            return idiomas;
        }

        public void cargarGrillaIdiomas()
        {

        }

        protected void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerProvincias(Convert.ToInt32(cbPais.SelectedValue));  
        }

        public void obtenerProvincias(int idPais)
        {
                cbProvincia.Items.Clear();
                List<Provincia> provincias= GestorCombosYTablas.obtenerProvincias(idPais);
                cbProvincia.DataSource = provincias;
                cbProvincia.DataTextField = "nombre";
                cbProvincia.DataValueField = "idProvincia";
                cbProvincia.DataBind();
                cbProvincia.Enabled = true;
                
                cbProvincia.Items.Insert(0, new ListItem("Seleccione una opcion"));
        }

        public void obtenerCiudades(int idProvincia)
        {
            cbCiudad.Items.Clear();
            List<Ciudad> ciudad = GestorCombosYTablas.obtenerCiudades(idProvincia);
            cbCiudad.DataSource = ciudad;
            cbCiudad.DataTextField = "nombre";
            cbCiudad.DataValueField = "idCiudad";
            cbCiudad.DataBind();
            cbCiudad.Enabled = true;
        }

        protected void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerCiudades(Convert.ToInt32(cbProvincia.SelectedValue));  
        }

        protected void clFechaNacimiento_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
        }

        protected void btnAgregarIdioma_Click(object sender, EventArgs e)
        {
            Idioma idioma = new Idioma();
            int idIdioma = Convert.ToInt32(cbIdioma.SelectedValue);
            idioma.idIdioma = idIdioma;
            String nombre = cbIdioma.SelectedItem.ToString();
            idioma.nombre = nombre;

            int idNivelLee = Convert.ToInt32(cbLee.SelectedValue);
            idioma.idNivelLee = idNivelLee;

            String nivelLee = cbLee.SelectedItem.ToString();
            idioma.nivelLee = nivelLee;

            int idNivelEscribe = Convert.ToInt32(cbEscribe.SelectedValue);
            idioma.idNivelEscribe = idNivelEscribe;

            String nivelEscribe = cbEscribe.SelectedItem.ToString();
            idioma.nivelEscribe = nivelEscribe;

            int idNivelHabla = Convert.ToInt32(cbHabla.SelectedValue);
            idioma.idNivelHabla = idNivelHabla;

            String nivelHabla = cbHabla.SelectedItem.ToString();
            idioma.nivelHabla = nivelHabla;
            cargarIdioma(idioma);
        }

        public void cargarIdioma(Idioma idioma)
        {
            if (Session["listaIdioma"] == null)
            {
                List<Idioma> listaIdi = new List<Idioma>();
                listaIdi.Add(idioma);
                gvIdioma.DataSource = listaIdi;
                gvIdioma.DataBind();
                Session["listaIdioma"] = listaIdi;
            }
            else
            {
                List<Idioma> listaIdi = (List<Idioma>)Session["listaIdioma"];
                listaIdi.Add(idioma);
                gvIdioma.DataSource = listaIdi;
                gvIdioma.DataBind();
                Session["listaIdioma"] = listaIdi;
            }
        }

        protected void gvLenguajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvLenguajes.SelectedDataKey["idLenguaje"].ToString());
            List<Lenguaje> lista= (List<Lenguaje>)Session["listaLenguaje"];
            Lenguaje eliminar = new Lenguaje();
            foreach (Lenguaje lenguaje in lista)
            {
                if (lenguaje.idLenguaje == id)
                {
                    eliminar = lenguaje;
                }
            }
            lista.Remove(eliminar);
            Session["listaLenguaje"] = lista;
            gvLenguajes.DataSource = lista;
            gvLenguajes.DataBind();
        }

       

        protected void gvMotores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvMotores.SelectedDataKey["idMotor"].ToString());
            List<MotorBD> lista = (List<MotorBD>)Session["listaBD"];
            MotorBD eliminar = new MotorBD();
            foreach (MotorBD motor in lista)
            {
                if (motor.idMotor == id)
                {
                    eliminar = motor;
                }
            }
            lista.Remove(eliminar);
            Session["listaBD"] = lista;
            gvMotores.DataSource = lista;
            gvMotores.DataBind();
        }

        protected void gvSOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvSOP.SelectedDataKey["idSisOP"].ToString());
            List<SistemaOperativo> lista = (List<SistemaOperativo>)Session["listaSOP"];
            SistemaOperativo eliminar = new SistemaOperativo();
            foreach (SistemaOperativo sop in lista)
            {
                if (sop.idSisOP == id)
                {
                    eliminar = sop;
                }
            }
            lista.Remove(eliminar);
            Session["listaSOP"] = lista;
            gvSOP.DataSource = lista;
            gvSOP.DataBind();
        }

        protected void gvSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvSoftware.SelectedDataKey["idSoftware"].ToString());
            List<Software> lista = (List<Software>)Session["listaSW"];
            Software eliminar = new Software();
            foreach (Software sw in lista)
            {
                if (sw.idSoftware == id)
                {
                    eliminar = sw;
                }
            }
            lista.Remove(eliminar);
            Session["listaSW"] = lista;
            gvSoftware.DataSource = lista;
            gvSoftware.DataBind();
        }

        protected void gvIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvIdioma.SelectedDataKey["idIdioma"].ToString());
            List<Idioma> lista = (List<Idioma>)Session["listaIdioma"];
            Idioma eliminar = new Idioma();
            foreach (Idioma lenguaje in lista)
            {
                if (lenguaje.idIdioma == id)
                {
                    eliminar = lenguaje;
                }
            }
            lista.Remove(eliminar);
            Session["listaIdioma"] = lista;
            gvIdioma.DataSource = lista;
            gvIdioma.DataBind();
        }


    }
}