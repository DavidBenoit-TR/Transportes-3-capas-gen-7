using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.Utilidades;

namespace Transportes_3_capas_gen_7
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //recuperar los datos del formulario
            var user = txtnickname.Text;
            var pass = txtPassword.Text;

            //mandarlo a la capa BLL para validación, y esperar una respuesta
            var session = BLL_Users.Login(user, pass);

            //validar
            if (session[2].ToUpper().Contains("ERROR"))
            {
                //significa que existe un error
                sweetAlert.Swert_Alert("Error", session[2], "warning", this.Page, this.GetType());
            }
            else
            {
                //to' bien
                //creamos variables de sesión
                Session["user"] = session[0];
                Session["rol"] = session[1];
                //muestro un msj y redirecciono
                sweetAlert.Swert_Alert("Bienvenido", $"Bienvenido de vuelta {session[0]}", "success", this.Page, this.GetType(), "/catalogos/Camiones/listarCamiones.aspx");
            }
        }
    }
}