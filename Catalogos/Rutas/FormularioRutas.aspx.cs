using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.Utilidades;
using VO;

namespace Transportes_3_capas_gen_7.Catalogos.Rutas
{
    public partial class FormularioRutas : System.Web.UI.Page
    {
        public DateTime fecha_salida_global;
        public DateTime fecha_llegada_global;
        protected void Page_Load(object sender, EventArgs e)
        {
            //recupero las variables de sesión
            string session_user = (string)Session["user"];
            string session_rol = (string)Session["rol"];
            if (!IsPostBack)
            {
                //Cargo mis DDL's
                cargar_DDL();
                //Configuro mis Calendarios
                calactual.SelectedDate = DateTime.Now.Date;
                calactual.VisibleDate = DateTime.Now.Date;
                lblactual.Text = "Fecah Actual: " + DateTime.Now.ToShortDateString();
                //Valido si se desea Insertar o Actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a Actualizar
                    //recupero el ID de la URL
                    int idruta = int.Parse(Request.QueryString["Id"].ToString());
                    //recupero el objeto original
                    Rutas_VO _ruta = BLL_Rutas.GetRutas("@idRuta", idruta)[0];
                    //valido que realmente haya recuperado una ruta
                    if (_ruta.IdRuta != 0)
                    {
                        //Relleno el formulario
                        titulo.Text = "Actualizar Ruta";
                        subtitulo.Text = "Ruta #" + idruta;
                        ddlcamion.SelectedValue = _ruta.CamionId.ToString();
                        ddlchoferes.SelectedValue = _ruta.ChoferId.ToString();
                        ddlorigen.SelectedValue = _ruta.DireccionOrigenId.ToString();
                        ddldestino.SelectedValue = _ruta.DireccionDestinoId.ToString();
                        txtdistancia.Text = _ruta.Distancia.ToString();

                        calestimada.SelectedDate = DateTime.Parse(_ruta.FechaLlegadaEstimada);
                        calestimada.VisibleDate = DateTime.Parse(_ruta.FechaLlegadaEstimada);
                        lblestimada.Text = "Fecha estimada de LLegada: " + _ruta.FechaLlegadaEstimada;

                        calsalida.SelectedDate = DateTime.Parse(_ruta.FechaSalida);
                        calsalida.VisibleDate = DateTime.Parse(_ruta.FechaSalida);
                        lblsalida.Text = "Fecha estimada de Salida: " + _ruta.FechaSalida;

                    }
                    else
                    {
                        sweetAlert.Swert_Alert("Opción no válida", "No hemos encontrado el ID solicitado", "info", this.Page, this.GetType(), "/Catalogos/Rutas/ListarRutas.aspx");
                    }
                }
                else
                {
                    //voy a aInsertar
                    titulo.Text = "Agregar Nueva Ruta";
                    subtitulo.Text = "";

                    calestimada.SelectedDate = DateTime.Now.Date.AddDays(4);
                    calestimada.VisibleDate = DateTime.Now.Date.AddDays(4);
                    lblestimada.Text = "Fecha estimada de LLegada: " + DateTime.Now.Date.AddDays(4).ToShortDateString();

                    calsalida.SelectedDate = DateTime.Now.Date.AddDays(1);
                    calsalida.VisibleDate = DateTime.Now.Date.AddDays(1);
                    lblsalida.Text = "Fecha de Salida: " + DateTime.Now.Date.AddDays(1).ToShortDateString();
                }
            }
            //if (session_user != null)
            //{

            //}
            //else
            //{
            //    //lo regreso al Login
            //    //vaciar las variables de sesión por seguridad
            //    Session.Clear();
            //    sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
            //}
        }

        protected void cargar_DDL()
        {
            //ddlcamiones
            //creo un objeto de tipo 'ListItem' para agregarlo a la lsita de elemntos del DDL
            //ListItem(valor a mostrar, valor a guardar)
            ListItem ddlcamiones_I = new ListItem("Seleccione un camión", "0");
            ddlcamion.Items.Add(ddlcamiones_I);
            //recuperar la lista de camiones que se encuentren disponibles que voy a pasar al DDL
            List<Camiones_VO> list_c = BLL_Camiones.get_Camiones("@disponibilidad", true);
            //valido si tiene objetos esta lista
            if (list_c.Count > 0)
            {
                //recorro la lista creando nuevos objetos ListItem en función de lis datos que requiero
                foreach (Camiones_VO c in list_c)
                {
                    ListItem i = new ListItem((c.Marca + " | " + c.Modelo + " | " + c.Matricula), c.IdCamion.ToString());
                    ddlcamion.Items.Add((i));
                }
            }

            ////Opción Alternativa apra llenar los DDL
            //ddlcamion.DataSource = BLL_Camiones.get_Camiones(); //llenar el DDL
            //ddlcamion.DataBind(); //mostrar los resultados

            //ddlchoferes
            ListItem DDL_Ch = new ListItem("Seleccione un Chofer", "0");
            ddlchoferes.Items.Add(DDL_Ch);
            List<Choferes_VO> list_ch = BLL_Choferes.get_Choferes();
            if (list_ch.Count > 0)
            {
                foreach (Choferes_VO ch in list_ch)
                {
                    ListItem k = new ListItem(ch.NombreCompleto, ch.IdChofer.ToString());
                    ddlchoferes.Items.Add(k);
                }
            }

            //ddorigne
            //ddldestino
            ListItem DDL_D = new ListItem("Seleccione una Dirección", "0");
            ddlorigen.Items.Add(DDL_D);
            ddldestino.Items.Add(DDL_D);
            List<Direcciones_VO> list_d = BLL_Direcciones.get_Direcciones();
            if (list_d.Count > 0)
            {
                foreach (Direcciones_VO d in list_d)
                {
                    ListItem l = new ListItem((d.Calle + " # " + d.Numero + " ") + d.Colonia + " " + d.Ciudad, d.IdDireccion.ToString());
                    ListItem m = new ListItem((d.Calle + " #" + d.Numero + " ") + d.Colonia + " " + d.Ciudad, d.IdDireccion.ToString());
                    ddlorigen.Items.Add(l);
                    ddldestino.Items.Add(m);
                }
            }
        }

        protected void calsalida_SelectionChanged(object sender, EventArgs e)
        {
            //almacenos la fecha seleccionada en el calendario de salida de forma global
            fecha_salida_global = calsalida.SelectedDate;
            fecha_llegada_global = calsalida.SelectedDate.AddDays(4);

            //asiganos textos especiales a las cabeceras de los calendarios, convirtiendo la fecha estandar en una fecha más legible
            //(dd/MM/aaaa HH:mm:ss => dd/MM/aaaa)
            lblsalida.Text = "Salida Estimada \n" + fecha_salida_global.ToShortDateString();
            lblestimada.Text = "Llegada estimada \n" + fecha_llegada_global.ToShortDateString();
            calestimada.SelectedDate = fecha_llegada_global;
            calestimada.VisibleDate = fecha_llegada_global;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //preparo mi objeto a enviar
            Rutas_VO _ruta = new Rutas_VO();
            //variables apra mi Sweet Alert
            string titulo, msg, tipo, respuesta;

            try
            {
                // Asigno mis valores del formulario al objeto
                _ruta.Distancia = float.Parse(txtdistancia.Text);
                _ruta.CamionId = int.Parse(ddlcamion.SelectedValue);
                _ruta.ChoferId = int.Parse(ddlchoferes.SelectedValue);
                _ruta.DireccionOrigenId = int.Parse(ddlorigen.SelectedValue);
                _ruta.DireccionDestinoId = int.Parse(ddldestino.SelectedValue);
                //Formateamos la fecha en Inglés, para así enviarla a SQL
                _ruta.FechaSalida = calsalida.SelectedDate.ToString("yyyy/MM/dd");
                _ruta.FechaLlegadaEstimada = calestimada.SelectedDate.ToString("yyyy/MM/dd");
                _ruta.FechaLlegadaReal = DateTime.MaxValue.ToString("yyyy/MM/dd"); //paso el valor máximo, para así guardarlo en la BD

                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a actualziar
                    _ruta.IdRuta = int.Parse(Request.QueryString["Id"]);
                    respuesta = BLL_Rutas.ActualizarRuta(_ruta);
                }
                else
                {
                    //Voy a Insertar
                    respuesta = BLL_Rutas.InsertarRuta(_ruta);
                }

                //Preaparo mi Sweet Alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    msg = respuesta;
                    tipo = "error";
                }
                else
                {
                    titulo = "Ok!";
                    msg = respuesta;
                    tipo = "success";
                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                msg = ex.Message;
                tipo = "error";
            }

            sweetAlert.Swert_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Rutas/ListarRutas.aspx");
        }
    }
}