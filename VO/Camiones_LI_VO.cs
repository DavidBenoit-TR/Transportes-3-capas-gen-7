using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Camiones_LI_VO
    {
        private int _idCamion;
        private string _matricula;
        private string _marca;
        private string _modelo;
        private bool _disponibilidad;

        public int IdCamion { get => _idCamion; set => _idCamion = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }

        public Camiones_LI_VO()
        {
            _idCamion = 0;
            _matricula = "";
            _marca = "";
            _modelo = "";
            _disponibilidad = true;
        }

        //Constructor con DR(DataRow) de ADO
        public Camiones_LI_VO(DataRow dr)
        {
            _idCamion = int.Parse(dr["idCamion"].ToString());
            _matricula = dr["matricula"].ToString();
            _marca = dr["marca"].ToString();
            _modelo = dr["modelo"].ToString();
            _disponibilidad = bool.Parse(dr["disponibilidad"].ToString());
        }
    }
}
