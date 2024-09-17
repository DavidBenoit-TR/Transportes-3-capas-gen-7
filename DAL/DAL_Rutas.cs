using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Rutas
    {
        //Create (crear/insertar)
        public static string InsertarRuta(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Rutas_Ins",
                        "@camionId", ruta.CamionId,
                        "@distancia", ruta.Distancia,
                        "@fechaSalida", ruta.FechaSalida,
                        "@fechaLlegadaEstimada", ruta.FechaLlegadaEstimada,
                        "@fechaLlegadaReal", ruta.FechaLlegadaReal,
                        "@choferid", ruta.ChoferId,
                        "@direccionOrigenId", ruta.DireccionOrigenId,
                        "@direccionDestinoId", ruta.DireccionDestinoId
                    );
                if (respuesta != 0)
                {
                    salida = "Ruta registrada con éxito";
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

        //Read (consultar/obtener)
        public static List<Rutas_VO> GetRutas(params object[] parametros)
        {
            List<Rutas_VO> list_rutas = new List<Rutas_VO>();
            try
            {
                DataSet ds_camiones = metodos_Datos.execute_DataSet("sp_ListarRutas", parametros);
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_rutas.Add(new Rutas_VO(dr));
                }
                return list_rutas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update (actualizar/modificar)
        public static string ActualizarRuta(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Rutas_Upd",
                        "@camionId", ruta.CamionId,
                        "@distancia", ruta.Distancia,
                        "@fechaSalida", ruta.FechaSalida,
                        "@fechaLlegadaEstimada", ruta.FechaLlegadaEstimada,
                        "@fechaLlegadaReal", ruta.FechaLlegadaReal,
                        "@choferid", ruta.ChoferId,
                        "@direccionOrigenId", ruta.DireccionOrigenId,
                        "@direccionDestinoId", ruta.DireccionDestinoId,
                        "@idRuta", ruta.IdRuta
                    ); ;
                if (respuesta != 0)
                {
                    salida = "Ruta Actualizada con éxito";
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

        //Delete (eliminar)
        public static string EliminarRuta(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_Datos.execute_NonQuery("sp_Rutas_Del",
                    "@idRuta", id
                    );
                if (respuesta != 0)
                {
                    salida = "Ruta eliminada con éxito";
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

        #region ViewRutas
        public static List<View_Rutas_VO> GetViewRutas(params object[] parametros)
        {
            List<View_Rutas_VO> list_rutas = new List<View_Rutas_VO>();
            try
            {
                DataSet ds_camiones = metodos_Datos.execute_DataSet("sp_View_Rutas", parametros);
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_rutas.Add(new View_Rutas_VO(dr));
                }
                return list_rutas;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
