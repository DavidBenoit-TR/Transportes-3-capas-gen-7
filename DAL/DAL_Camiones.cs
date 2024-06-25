using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //Create
        public static string insertar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Camiones_Ins",
                    "@matricula", camion.Matricula,
                    "@tipoCamion", camion.TipoCamion,
                    "@marca", camion.Marca,
                    "@modelo", camion.Modelo,
                    "@capacidad", camion.Capacidad,
                    "@kilometraje", camion.Kilometraje,
                    "@urlFoto", camion.UrlFoto,
                    "@disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión registrado con éxito";
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
        public static List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            //cre una lista de objetos que voy a llenar
            List<Camiones_VO> list_camiones = new List<Camiones_VO>();
            try
            {
                //crear un DataSet el cual recibirá lo que devuelva la ejecución del método "execute_DataSet" proviniente de la clase "metodos_Datos".
                //en esta ocasión, no pasamos ningún parámetro, solo el SP
                DataSet ds_camiones = metodos_Datos.execute_DataSet("sp_Camiones_Sel", parametros);
                //recorremos cada renglón existente de nuestro ds creando objetos VO y añadiéndolos a la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_camiones.Add(new Camiones_VO(dr));
                }
                return list_camiones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Update
        public static string actualizar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Camiones_Upd",
                    "@matricula", camion.Matricula,
                    "@tipoCamion", camion.Capacidad,
                    "@marca", camion.Marca,
                    "@modelo", camion.Modelo,
                    "@capacidad", camion.Capacidad,
                    "@kilometraje", camion.Kilometraje,
                    "@urlFoto", camion.UrlFoto,
                    "@disponibilidad", camion.Disponibilidad,
                    "@idCamion", camion.IdCamion
                    );

                if (respuesta != 0)
                {
                    salida = "Camión Actualziado con éxito";
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
        public static string eliminar_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Camiones_Del",
                    "@idCamion", id
                    );
                if (respuesta != 0)
                {
                    salida = "Camión eliminado con éxito";
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
    }
}
