using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Camiones_VO
    {
        //VO= View Objet
        //Representación de una tabla SQL en código
        private int _idCamion;
        private string _matricula;
        private string _tipoCamion;
        private string _marca;
        private string _modelo;
        private int _capacidad;
        private double _kilometraje;
        private string _urlFoto;
        private bool _disponibilidad;

        public int IdCamion { get => _idCamion; set => _idCamion = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string TipoCamion { get => _tipoCamion; set => _tipoCamion = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Capacidad { get => _capacidad; set => _capacidad = value; }
        public double Kilometraje { get => _kilometraje; set => _kilometraje = value; }
        public string UrlFoto { get => _urlFoto; set => _urlFoto = value; }
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }

        public Camiones_VO()
        {
            _idCamion = 0;
            _matricula = "";
            _tipoCamion = string.Empty;
            _marca = "";
            _modelo = "";
            _capacidad = 0;
            _kilometraje = 0;
            _urlFoto = "";
            _disponibilidad = true;
        }

        //Constructor con DR(DataRow) de ADO
        public Camiones_VO(DataRow dr)
        {
            _idCamion = int.Parse(dr["idCamion"].ToString());
            _matricula = dr["matricula"].ToString();
            _tipoCamion = dr["tipoCamion"].ToString();
            _marca = dr["marca"].ToString();
            _modelo = dr["modelo"].ToString();
            _capacidad = int.Parse(dr["capacidad"].ToString());
            _kilometraje = double.Parse(dr["kilometraje"].ToString());
            _urlFoto = dr["urlFoto"].ToString();
            _disponibilidad = bool.Parse(dr["disponibilidad"].ToString());
        }
    }
}
