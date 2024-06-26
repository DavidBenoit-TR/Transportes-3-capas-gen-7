using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.Utilidades;

namespace Transportes_3_capas_gen_7.Catalogos.Usuarios
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recupero las variables de sesión
            string session_user = (string)Session["user"];
            string session_rol = (string)Session["rol"];

            //valido si no están vacías
            if (session_user != null)
            {
                //puedo entrar
                if (!IsPostBack)
                {
                    //Valido acciones por usuario
                    if (session_rol != "Admin")
                    {
                        //Esto es un Operativo
                        //lo regreso al Login
                        //vaciar las variables de sesión por seguridad
                        Session.Clear();
                        sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
                    }
                    else
                    {
                        cargargrid();
                    }

                }
            }
            else
            {
                //lo regreso al Login
                //vaciar las variables de sesión por seguridad
                Session.Clear();
                sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
            }
        }

        public void cargargrid()
        {
            GVUsuarios.DataSource = BLL_Users.get_Users();
            GVUsuarios.DataBind();
        }

        protected void GVUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVUsuarios.DataKeys[varIndex].Values["ID_User"].ToString();
                Response.Redirect("FormularioUsuario.aspx?Id=" + id);
            }
        }

        protected void GVUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int iduser = int.Parse(GVUsuarios.DataKeys[e.RowIndex].Values["ID_User"].ToString());
            string respuesta = BLL_Users.eliminar_User(iduser);
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Ops..."; msg = respuesta; tipo = "error";
            }
            else
            {
                titulo = "Correcto!"; msg = respuesta; tipo = "success";
            }
            sweetAlert.Swert_Alert(titulo, msg, tipo, this.Page, this.GetType());
            cargargrid();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioUsuario.aspx");
        }
    }
}