﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.CamionesServiceReference;
using Transportes_3_capas_gen_7.Utilidades;
using VO;

namespace Transportes_3_capas_gen_7.Catalagos.Camiones
{
    public partial class FormularioCamion : System.Web.UI.Page
    {
        CamionesServiceSoapClient client_WS;
        protected void Page_Load(object sender, EventArgs e)
        {
            client_WS = new CamionesServiceSoapClient();
            //Valido si es PostBack
            if (!IsPostBack)
            {
                //Validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a inertar
                    Titulo.Text = "Agregar Camión";
                    Subtitulo.Text = "Registro de un nuevo camión";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    CamionesServiceReference.Camiones_VO _camion_original = client_WS.get_Camiones(new ArrayOfAnyType { "@idCamion", _id })[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_camion_original.IdCamion != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Camión";
                        Subtitulo.Text = $"Modificar los datos del Camión #{_id}";
                        txtmatricula.Text = _camion_original.Matricula;
                        txtcapacidad.Text = _camion_original.Capacidad.ToString();
                        txtkilometraje.Text = _camion_original.Kilometraje.ToString();
                        txtmarca.Text = _camion_original.Marca.ToString();
                        txtmodelo.Text = _camion_original.Modelo;
                        txttipo_camion.Text = _camion_original.TipoCamion;
                        chkdisponibilidad.Checked = _camion_original.Disponibilidad;
                        imgfoto.ImageUrl = _camion_original.UrlFoto;
                    }
                    else
                    {
                        ////Voy pa' tras
                        //Response.Redirect("listarCamiones.aspx");
                        sweetAlert.Swert_Alert("No hay nada por aquí", "No hemos podido encontrar los que buscas", "info", this.Page, this.GetType(), "listarCamiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //este método sirve para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info necesaria para la BD

            //valido que exista una imagen
            if (subeimagen.Value != "")
            {
                //recupero el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //validar la extención del archivo
                string fileext = Path.GetExtension(filename).ToLower();
                if ((fileext != ".jpg") && (fileext != ".png"))
                {
                    //sweet alert
                    sweetAlert.Swert_Alert("Esto no va aquí", "Solo se aceptan formatos '.jpg' o '.png'", "info", this.Page, this.GetType());
                }
                else
                {
                    //verifico que existe el directorio en el servidor para poder almacenar la imagen, si es que no, lo creo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones/");// ~ (virgulilla) hace referencia a la dirección completa del servidor, independientemenete de donde esté instalado, permitiendo que la validicación funciones en diferentes entornos
                    //si no existe eldirectorio, lo creamos
                    if (!Directory.Exists(pathdir))
                    {
                        //creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }
                    //subimos la imagen a la carpeta del server
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenaremos en la BD
                    string urlfoto = "/Imagenes/Camiones/" + filename;
                    //mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlfoto;
                    //mostramos la imagen
                    imgcamion.ImageUrl = urlfoto;
                    //Sweet Alert
                    sweetAlert.Swert_Alert("Guardado!", "la imagen se ha cargado con éxito", "success", this.Page, this.GetType());
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";

            try
            {
                //Creamos el objeto que enviaremos para actualiza o insertar
                CamionesServiceReference.Camiones_VO _camion_aux = new CamionesServiceReference.Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.TipoCamion = txttipo_camion.Text;
                _camion_aux.Marca = txtmarca.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = double.Parse(txtkilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;

                CamionesServiceReference.Camiones_VO _camion_aux2 = new CamionesServiceReference.Camiones_VO()
                {
                    Matricula = txtmatricula.Text,
                    TipoCamion = txttipo_camion.Text,
                    Marca = txtmarca.Text,
                    Modelo = txtmodelo.Text,
                    Capacidad = Convert.ToInt32(txtcapacidad.Text),
                    Kilometraje = float.Parse(txtkilometraje.Text),
                    UrlFoto = imgcamion.ImageUrl,
                    Disponibilidad = chkdisponibilidad.Checked
                };

                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar
                    _camion_aux.Disponibilidad = true;
                    salida = client_WS.insertar_Camion(_camion_aux);
                }
                else
                {
                    //Actualizar
                    _camion_aux.IdCamion = int.Parse(Request.QueryString["Id"]);
                    salida = client_WS.actualizar_Camion(_camion_aux);
                }

                //preparamos la salida para cachar un error y mostrar un Sweet Alert
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    respuesta = salida;
                    tipo = "error";
                }
                else
                {
                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                }

            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //sweet alert
            sweetAlert.Swert_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "listarCamiones.aspx");
        }
    }
}