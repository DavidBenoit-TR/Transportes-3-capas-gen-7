using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Users
    {
        //Create
        public static string insertar_User(User_VO user)
        {
            return DAL_Users.insertar_User(user);
        }
        //Read
        public static List<User_VO> get_Users(params object[] parametros)
        {
            return DAL_Users.get_Users(parametros);
        }
        //Update
        public static string actualizar_User(User_VO user)
        {
            return DAL_Users.actualizar_User(user);
        }
        //Delete
        public static string eliminar_User(int id)
        {
            return DAL_Users.eliminar_User(id);
        }

        //Login
        public static List<string> Login(string nick, string pass)
        {
            //Recupero el Usuario que corresponda
            User_VO usuario = DAL_Users.Login(nick, pass);
            //preparar las variables que necesito
            string nombre = "", rol = "", error = "";
            List<string> respuesta = new List<string>();
            //valido si realmente existe el usuario
            if (usuario.ID_User != 0)
            {
                //Si exite y se recuperó
                nombre = usuario.Nickname;
                rol = usuario.Rol;
            }
            else
            {
                //no hay nada
                error = "Error: No se ha encontrado el usuario en la Base de datos";
            }
            //añadimos las variables de respuesta a la lsita
            respuesta.Add(nombre);
            respuesta.Add(rol);
            respuesta.Add(error);
            //devolvemos la lista
            return respuesta;
        }
    }
}
