using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPage.Models
{
    public class Data
    {
        //[JsonProperty("idcliente")]
        public decimal Idcliente { get; set; }

        //[JsonProperty("idMovimiento")]
        public string IdMovimiento { get; set; }

        //[JsonProperty("idCartera")]
        public string IdCartera { get; set; }

        //[JsonProperty("nombre_contacto")]
        public string nombre_contacto { get; set; }

        //[JsonProperty("clavegrupo")]
        public string clavegrupo { get; set; }

        //[JsonProperty("clave_bd")]
        public string clave_bd { get; set; }

        //[JsonProperty("IdAgrupado")]
        public string IdAgrupado { get; set; }

        //[JsonProperty("IdUnico")]
        public string IdUnico { get; set; }

        //[JsonProperty("saldoVencido")]
        public decimal saldoVencido { get; set; }

        //[JsonProperty("saldoVencidoInicial")]
        public decimal saldoVencidoInicial { get; set; }

        //[JsonProperty("FechaInicio")]
        public string FechaInicio { get; set; }

        //[JsonProperty("FechaFin")]
        public string FechaFin { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
