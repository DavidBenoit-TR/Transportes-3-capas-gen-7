using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class View_Rutas_VO
    {
        private int no;
        private int idCargamento;
        private string cargamento;
        private int idDireccionOrigen;
        private string origen;
        private int idDireccionDestino;
        private string destino;
        private int idChofer;
        private string chofer;
        private int idCamion;
        private string camion;
        private string salida;
        private string llegada_estimada;

        public int No { get => no; set => no = value; }
        public int IdCargamento { get => idCargamento; set => idCargamento = value; }
        public string Cargamento { get => cargamento; set => cargamento = value; }
        public int IdDireccionOrigen { get => idDireccionOrigen; set => idDireccionOrigen = value; }
        public string Origen { get => origen; set => origen = value; }
        public int IdDireccionDestino { get => idDireccionDestino; set => idDireccionDestino = value; }
        public string Destino { get => destino; set => destino = value; }
        public int IdChofer { get => idChofer; set => idChofer = value; }
        public string Chofer { get => chofer; set => chofer = value; }
        public int IdCamion { get => idCamion; set => idCamion = value; }
        public string Camion { get => camion; set => camion = value; }
        public string Salida { get => salida; set => salida = value; }
        public string Llegada_estimada { get => llegada_estimada; set => llegada_estimada = value; }

        public View_Rutas_VO()
        {
            no = 0;
            idCargamento = 0;
            cargamento = "";
            idDireccionOrigen = 0;
            origen = "";
            idDireccionDestino = 0;
            destino = "";
            idChofer = 0;
            chofer = "";
            idCamion = 0;
            camion = "";
            salida = "";
            llegada_estimada = "";
        }

        public View_Rutas_VO(DataRow dr)
        {
            no = int.Parse(dr["#"].ToString());
            idCargamento = int.Parse(dr["idCargamento"].ToString());
            cargamento = dr["cargamento"].ToString();
            idDireccionOrigen = int.Parse(dr["idDireccionOrigen"].ToString());
            origen = dr["origen"].ToString();
            idDireccionDestino = int.Parse(dr["idDireccionDestino"].ToString());
            destino = dr["destino"].ToString();
            idChofer = int.Parse(dr["idChofer"].ToString());
            chofer = dr["chofer"].ToString();
            idCamion = int.Parse(dr["idCamion"].ToString());
            camion = dr["camion"].ToString();
            salida = dr["salida"].ToString();
            llegada_estimada = dr["llegada estimada"].ToString();
        }
    }
}
