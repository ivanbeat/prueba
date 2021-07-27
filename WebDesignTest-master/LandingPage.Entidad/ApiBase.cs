using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPage.Entidad
{
    public class ApiBase
    {
        public static RestSharp.RestClient Cliente;
        public static RestSharp.RestRequest request;

        public static void Iniciar(string url, RestSharp.Method metodo)
        {
            Cliente = new RestSharp.RestClient(url);
            Cliente.Timeout = -1;
            request = new RestSharp.RestRequest(metodo);
        }
    }
}
