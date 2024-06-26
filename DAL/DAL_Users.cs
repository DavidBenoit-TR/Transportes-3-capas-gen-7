using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Users
    {
        //Create
        public static string insertar_User(User_VO user)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Users_Ins",
                    "@nickname", user.Nickname,
                    "@pass", user.Pass,
                    "@rol", user.Rol
                    );

                if (respuesta != 0)
                {
                    salida = "Usuario registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
        //Read
        public static List<User_VO> get_Users(params object[] parametros)
        {
            List<User_VO> list_Users = new List<User_VO>();
            try
            {
                DataSet ds_Users = metodos_Datos.execute_DataSet("sp_Users_Sel", parametros);
                foreach (DataRow dr in ds_Users.Tables[0].Rows)
                {
                    list_Users.Add(new User_VO(dr));
                }
                return list_Users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Update
        public static string actualizar_User(User_VO user)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Users_Upd",
                    "@ID_User", user.ID_User,
                    "@nickname", user.Nickname,
                    "@pass", user.Pass,
                    "@rol", user.Rol
                    );

                if (respuesta != 0)
                {
                    salida = "Usuario Actualizado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
        //Delete
        public static string eliminar_User(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Users_Del",
                    "@ID_User", id
                    );
                if (respuesta != 0)
                {
                    salida = "Usuario eliminado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }

        //Login
        public static User_VO Login(string nick, string pass)
        {
            User_VO User = new User_VO();
            try
            {
                DataSet ds_Users = metodos_Datos.execute_DataSet("sp_Login",
                    "@nickname", nick,
                    "@pass", pass);
                foreach (DataRow dr in ds_Users.Tables[0].Rows)
                {
                    User = new User_VO(dr);
                }
                return User;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
