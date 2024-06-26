using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Choferes_VO
    {
        private int _idChofer;
        private string _nombre;
        private string _apellidoPaterno;
        private string _apellidoMaterno;
        private string _telefono;
        private string _fechaNacimiento;
        private string _licencia;
        private string _urlFoto;
        private bool _disponibilidad;
        private string nombreCompleto;

        public int IdChofer { get => _idChofer; set => _idChofer = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string ApellidoPaterno { get => _apellidoPaterno; set => _apellidoPaterno = value; }
        public string ApellidoMaterno { get => _apellidoMaterno; set => _apellidoMaterno = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Licencia { get => _licencia; set => _licencia = value; }
        public string UrlFoto { get => _urlFoto; set => _urlFoto = value; }
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

        public Choferes_VO()
        {
            _idChofer = 0;
            _nombre = "";
            _apellidoPaterno = "";
            _apellidoMaterno = "";
            _telefono = "";
            _fechaNacimiento = "";
            _licencia = "";
            _urlFoto = "";
            _disponibilidad = true;
            nombreCompleto = "";
        }

        public Choferes_VO(DataRow dr)
        {
            _idChofer = int.Parse(dr["idChofer"].ToString());
            _nombre = dr["nombre"].ToString();
            _apellidoPaterno = dr["apellidoPaterno"].ToString();
            _apellidoMaterno = dr["apellidoMaterno"].ToString();
            _telefono = dr["telefono"].ToString();
            _fechaNacimiento = dr["fechaNacimiento"].ToString();
            _licencia = dr["licencia"].ToString();
            _urlFoto = dr["urlFoto"].ToString();
            _disponibilidad = bool.Parse(dr["disponibilidad"].ToString());
            nombreCompleto = dr["apellidoPaterno"].ToString() + " " + dr["apellidoMaterno"].ToString() + " " + dr["nombre"].ToString();
        }
    }
}
