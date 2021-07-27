using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Net;
using Newtonsoft.Json;
namespace LandingPage.Entidad
{
    public class EntPostSend : ApiBase
    {
        public static string Link = ConfigurationManager.AppSettings["MsCobranza"];
        public static string PostSendPago(string SendPago)
        {
            var respuesta = string.Empty;
            try
            {
                Iniciar(string.Format(Link + "UpdInfoCobranza"), RestSharp.Method.POST);
                request.AddJsonBody(SendPago);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody);
                RestSharp.IRestResponse response = Cliente.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    respuesta = response.Content;
                }
                else
                {
                    respuesta = response.Content;
                }

            }
            catch (Exception ex)
            {

                respuesta = ex.ToString();
            }
            return (respuesta);
        }
    }
}
