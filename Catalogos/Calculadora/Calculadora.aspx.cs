using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_7.CalculadoraServiceReference;

namespace Transportes_3_capas_gen_7.Catalogos.Calculadora
{
    public partial class Calculadora : System.Web.UI.Page
    {
        //crear un cliente que resuelva las peticiones del Servicio SOAP
        CalculadoraServiceSoapClient Cliente_WS;
        protected void Page_Load(object sender, EventArgs e)
        {
            //inicializo mi cliente SOAP
            Cliente_WS = new CalculadoraServiceSoapClient();

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de mi formulario
            float a = float.Parse(txta.Text);
            float b = float.Parse(txtb.Text);
            //Invoco a mi servicio pasándole los datos que requiere
            float resultado = Cliente_WS.Suma(a, b);
            //muestro el resultado en mi lbl
            lblresultado.Text = resultado.ToString();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de mi formulario
            float a = float.Parse(txta.Text);
            float b = float.Parse(txtb.Text);
            //Invoco a mi servicio pasándole los datos que requiere
            float resultado = Cliente_WS.Resta(a, b);
            //muestro el resultado en mi lbl
            lblresultado.Text = resultado.ToString();
        }

        protected void btnMultiplicar_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de mi formulario
            float a = float.Parse(txta.Text);
            float b = float.Parse(txtb.Text);
            //Invoco a mi servicio pasándole los datos que requiere
            float resultado = Cliente_WS.Multiplicacion(a, b);
            //muestro el resultado en mi lbl
            lblresultado.Text = resultado.ToString();
        }

        protected void btnDividir_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de mi formulario
            float a = float.Parse(txta.Text);
            float b = float.Parse(txtb.Text);
            //Invoco a mi servicio pasándole los datos que requiere
            float resultado = Cliente_WS.Division(a, b);
            //muestro el resultado en mi lbl
            lblresultado.Text = resultado.ToString();
        }
    }
}