using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.Utilidades;

namespace Transportes_3_capas_gen_7.Catalogos.Rutas
{
    public partial class listarRutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recupero las variables de sesión
            string session_user = (string)Session["user"];
            string session_rol = (string)Session["rol"];

            //puedo entrar
            if (!IsPostBack)
            {
                cargargrid();
            }

            ////valido si no están vacías
            //if (session_user != null)
            //{
            //    //puedo entrar
            //    if (!IsPostBack)
            //    {
            //        cargargrid();
            //    }
            //}
            //else
            //{
            //    //lo regreso al Login
            //    //vaciar las variables de sesión por seguridad
            //    Session.Clear();
            //    sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
            //}
        }

        private void cargargrid()
        {
            GVRutas.DataSource = BLL_Rutas.GetRutas();
            GVRutas.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRutas.aspx");
        }

        protected void GVRutas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVRutas.DataKeys[varIndex].Values["IdRuta"].ToString();
                Response.Redirect("FormularioRutas.aspx?Id=" + id);
            }
        }

        protected void GVRutas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idruta = int.Parse(GVRutas.DataKeys[e.RowIndex].Values["IdRuta"].ToString());
            string respuesta = BLL_Rutas.EliminarRuta(idruta);
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Ops...";
                msg = respuesta;
                tipo = "error";
            }
            else
            {

                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";
            }
            sweetAlert.Swert_Alert(titulo, msg, tipo, this.Page, this.GetType());
            cargargrid();
        }
    }
}