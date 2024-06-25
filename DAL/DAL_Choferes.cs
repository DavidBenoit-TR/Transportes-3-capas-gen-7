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
    public class DAL_Choferes
    {
        //Create

        //Read
        public static List<Choferes_VO> get_Choferes(params object[] parametros)
        {
            List<Choferes_VO> list_choferes = new List<Choferes_VO>();
            try
            {
                DataSet ds_camiones = metodos_Datos.execute_DataSet("sp_Choferes_Sel", parametros);
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_choferes.Add(new Choferes_VO(dr));
                }
                return list_choferes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Update

        //Delete

    }
}
