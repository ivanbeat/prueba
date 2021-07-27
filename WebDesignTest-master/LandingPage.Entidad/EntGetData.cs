using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Configuration;
using Newtonsoft.Json;
namespace LandingPage.Entidad
{
    public class EntGetData : ApiBase
    {
        public static string Link = ConfigurationManager.AppSettings["MsCobranza"];
        public static string GetDatacuenta(string IdUnico, string ClaveGrupo)
        {
            var respuesta = string.Empty;
            try
            {
                Iniciar(string.Format(Link + "InfoClient"), RestSharp.Method.POST);
                request.AddJsonBody(new { IdUnico = IdUnico, ClaveGrupo = ClaveGrupo });
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
