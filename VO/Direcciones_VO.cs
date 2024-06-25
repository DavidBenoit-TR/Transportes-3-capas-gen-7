using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Direcciones_VO
    {
        private int idDireccion;
        private string calle;
        private string numero;
        private string colonia;
        private string ciudad;
        private string estado;
        private string cp;

        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cp { get => cp; set => cp = value; }

        public Direcciones_VO()
        {
            idDireccion = 0;
            calle = "";
            numero = "";
            colonia = "";
            ciudad = "";
            estado = "";
            cp = "";

        }

        public Direcciones_VO(DataRow dr)
        {
            idDireccion = int.Parse(dr["idDireccion"].ToString());
            calle = dr["calle"].ToString();
            numero = dr["numero"].ToString();
            colonia = dr["colonia"].ToString();
            ciudad = dr["ciudad"].ToString();
            estado = dr["estado"].ToString();
            cp = dr["cp"].ToString();

        }
    }
}
