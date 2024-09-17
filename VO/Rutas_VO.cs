using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Rutas_VO
    {
        private int idRuta;
        private int camionId;
        private double distancia;
        private string fechaSalida;
        private string fechaLlegadaEstimada;
        private string fechaLlegadaReal;
        private int choferId;
        private int direccionOrigenId;
        private int direccionDestinoId;

        public int IdRuta { get => idRuta; set => idRuta = value; }
        public int CamionId { get => camionId; set => camionId = value; }
        public double Distancia { get => distancia; set => distancia = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string FechaLlegadaEstimada { get => fechaLlegadaEstimada; set => fechaLlegadaEstimada = value; }
        public string FechaLlegadaReal { get => fechaLlegadaReal; set => fechaLlegadaReal = value; }
        public int ChoferId { get => choferId; set => choferId = value; }
        public int DireccionOrigenId { get => direccionOrigenId; set => direccionOrigenId = value; }
        public int DireccionDestinoId { get => direccionDestinoId; set => direccionDestinoId = value; }

        public Rutas_VO()
        {
            idRuta = 0;
            camionId = 0;
            distancia = 0;
            fechaSalida = "";
            fechaLlegadaEstimada = "";
            fechaLlegadaReal = "";
            choferId = 0;
            direccionOrigenId = 0;
            direccionDestinoId = 0;
        }

        public Rutas_VO(DataRow dr)
        {
            idRuta = int.Parse(dr["ID_Ruta"].ToString());
            camionId = int.Parse(dr["Camion_ID"].ToString());
            distancia = double.Parse(dr["Distancia"].ToString());
            //1. Recupero la Fecha del DR => dr["Fecha_Salida"].ToString()
            //2. Convierto la fecha a ujn DateTime => DateTime.Parse()
            //3. Convierto nuevamente la fecha a un string con formato aaaa/MM/dd => .ToShortDateString()
            fechaSalida = DateTime.Parse(dr["Fecha_Salida"].ToString()).ToShortDateString();
            fechaLlegadaEstimada = DateTime.Parse(dr["Fecha_llegadaestimada"].ToString()).ToShortDateString();
            fechaLlegadaReal = DateTime.Parse(dr["Fecha_llegadareal"].ToString()).ToShortDateString();
            choferId = int.Parse(dr["Chofer_ID"].ToString());
            direccionOrigenId = int.Parse(dr["Direccionorigen_ID"].ToString());
            direccionDestinoId = int.Parse(dr["Direcciondestino_ID"].ToString());
        }
    }
}
