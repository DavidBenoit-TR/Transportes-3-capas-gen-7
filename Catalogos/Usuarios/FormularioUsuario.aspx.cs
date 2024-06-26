using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.Utilidades;
using VO;

namespace Transportes_3_capas_gen_7.Catalogos.Usuarios
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string session_user = (string)Session["user"];
            string session_rol = (string)Session["rol"];
            if (session_user != null)
            {
                if (!IsPostBack)
                {
                    if (session_rol != "Admin")
                    {
                        sweetAlert.sweetAlert2("Alto ahí loca", "Este perfil no tiene permisos de Admin", "info", this.Page, this.GetType(), "/Catalogos/Rutas/ListarRutas.aspx");
                    }
                    else
                    {
                        cargarddl();

                        //validar si es inserción o actualización
                        if (Request.QueryString["Id"] != null)
                        {
                            int iduser = int.Parse(Request.QueryString["Id"]);
                            User_VO user = BLL_Users.get_Users("@ID_User", iduser)[0];
                            if (user.ID_User != 0)
                            {
                                txtnickname.Text = user.Nickname;
                                ddlrol.SelectedValue = user.Rol.Trim().ToUpper();
                                chkestatus.Checked = user.Estatus;
                            }
                            else
                            {
                                sweetAlert.Swert_Alert("Opción no válida", "No hemos encontrado el ID solicitado", "info", this.Page, this.GetType(), "/Catalogos/Usuarios/ListarUsuarios.aspx");
                            }
                        }
                    }
                }
            }
            else
            {
                Session.Clear();
                sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
            }
        }

        public void cargarddl()
        {
            List<string> list = new List<string>()
            {
                "Seleccione un Rol",
                "NA",
                "Administrativo",
                "Admin",
                "Operativo",
                "User"
            };

            for (int i = 0; i < list.Count; i += 2)
            {
                ListItem x = new ListItem(list[i], list[i + 1]);
                ddlrol.Items.Add(x);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var a = txtPassword_C.Text;
            var b = txtPassword.Text;
            if (a != b)
            {
                lblPasswordMatch.Text = "Las Contraseñas no Coinciden";
                lblPasswordMatch.ForeColor = Color.White;
                lblPasswordMatch.ForeColor = Color.Red;
            }
            else
            {
                User_VO newuser = new User_VO();
                newuser.Nickname = txtnickname.Text.ToLower();
                newuser.Rol = ddlrol.SelectedValue;
                newuser.Estatus = chkestatus.Checked;

                var hashedPassword = ComputeSha512Hash(txtPassword_C.Text);
                newuser.Pass = hashedPassword;

                string respuesta = "", titulo = "", tipo = "";
                if (Request.QueryString["Id"] != null)
                {
                    newuser.ID_User = int.Parse(Request.QueryString["Id"]);
                    respuesta = BLL_Users.actualizar_User(newuser);
                }
                else
                {
                    respuesta = BLL_Users.insertar_User(newuser);
                }

                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    tipo = "error";
                }
                else
                {
                    titulo = "Ok";
                    tipo = "success";
                }

                sweetAlert.Swert_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Usuarios/ListarUsuarios.aspx");
            }
        }

        private static string ComputeSha512Hash(string rawData)
        {
            //Raw Data (Pronunciado: roh –dei-ta) es todo tipo de data que no ha sido procesada aún.
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //ComputeHash => deolver el array de bytes de la palabra ya cifrada
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                //convertimos el array a un nuevo string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    //La cadena de formato "x2" en el método ToString se utiliza para convertir un byte a su representación hexadecimal, asegurando que cada byte se represente con dos caracteres:

                    //"x": Especifica que el formato de la cadena debe ser hexadecimal en minúsculas.
                    //"2": Indica que la cadena resultante debe tener al menos dos caracteres.Si el valor hexadecimal del byte es un solo carácter(por ejemplo, 0x5), se agregará un cero a la izquierda para hacer dos caracteres(05).
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}