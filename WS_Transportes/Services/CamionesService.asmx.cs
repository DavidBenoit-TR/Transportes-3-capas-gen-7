﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace WS_Transportes.Services
{
    /// <summary>
    /// Descripción breve de CamionesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CamionesService : System.Web.Services.WebService
    {

        //Create
        [WebMethod]
        public string insertar_Camion(Camiones_VO camion)
        {
            return BLL_Camiones.insertar_Camion(camion);
        }
        //Read
        [WebMethod]
        public List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            return BLL_Camiones.get_Camiones(parametros);
        }
        //Update
        [WebMethod]
        public string actualizar_Camion(Camiones_VO camion)
        {
            return BLL_Camiones.actualizar_Camion(camion);
        }
        //Delete
        [WebMethod]
        public string eliminar_Camion(int id)
        {
            return BLL_Camiones.eliminar_Camion(id);
        }
    }
}
