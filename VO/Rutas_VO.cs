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
        private string fechaLlegadaEstima;
        private string fechaLlegadaReal;
        private int choferId;
        private int direccionOrigenId;
        private int direccionDestinoId;

        public int IdRuta { get => idRuta; set => idRuta = value; }
        public int CamionId { get => camionId; set => camionId = value; }
        public double Distancia { get => distancia; set => distancia = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string FechaLlegadaEstima { get => fechaLlegadaEstima; set => fechaLlegadaEstima = value; }
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
            fechaLlegadaEstima = "";
            fechaLlegadaReal = "";
            choferId = 0;
            direccionOrigenId = 0;
            direccionDestinoId = 0;
        }

        public Rutas_VO(DataRow dr)
        {
            idRuta = int.Parse(dr["idRuta"].ToString());
            camionId = int.Parse(dr["camionId"].ToString());
            distancia = double.Parse(dr["distancia"].ToString());
            fechaSalida = DateTime.Parse(dr["fechaSalida"].ToString()).ToShortDateString();
            fechaLlegadaEstima = DateTime.Parse(dr["fechaLlegadaEstima"].ToString()).ToShortDateString();
            fechaLlegadaReal = DateTime.Parse(dr["fechaLlegadaReal"].ToString()).ToShortDateString();
            choferId = int.Parse(dr["choferId"].ToString());
            direccionOrigenId = int.Parse(dr["direccionOrigenId"].ToString());
            direccionDestinoId = int.Parse(dr["direccionDestinoId"].ToString());
        }
    }
}
