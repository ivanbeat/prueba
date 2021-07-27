using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LandingPage.Models;
using LandingPage.Entidad;
namespace LandingPage.Negocio
{
    public class BusPostData : Base
    {
        public static string PostSendPago(Data Pago, string pago)
        {
            MetodoPago metodoPago = new MetodoPago();
            metodoPago.IdUnico = Pago.IdUnico;
            metodoPago.ClaveGrupo = Pago.clavegrupo;
            metodoPago.Pago = pago;
            metodoPago.FechaPago = (DateTime.Now).ToString("yyyy/MM/dd");
            metodoPago.ComentarioPago = "API Landing Page2";
            metodoPago.TipoPago = "Pago 2";
            metodoPago.Telefono = Pago.Telefono;

            string SendPago = string.Empty;
            try
            {
                SendPago = Newtonsoft.Json.JsonConvert.SerializeObject(metodoPago);

                string respuesta = EntPostSend.PostSendPago(SendPago);

                return respuesta;
            }
            catch (Exception ex )
            {
                InvokeAppendLogEx(ex);
                throw;
            }
        }

        public static string ConvertLink(Data DataCliente)
        {
            string cadenaEncryptada = string.Empty;
            string cadena = "?idUnico=" + DataCliente.IdUnico + "&ClaveGrupo=" + "G3900" + "&Telefono=" + DataCliente.Telefono;
            cadenaEncryptada = Encriptar(cadena);

            return cadenaEncryptada;

        }
    }
}
