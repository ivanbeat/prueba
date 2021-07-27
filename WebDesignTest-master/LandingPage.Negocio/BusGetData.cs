using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LandingPage.Entidad;
using LandingPage.Models;
namespace LandingPage.Negocio
{
    public class BusGetData : Base
    {
        public static Data GetDataCuenta(string IdUnico, string ClaveGrupo)
        {
            List<Data> lstrespuesta = new List<Data>();
            Data DatosCuenta = new Data();

            try
            {
                var respuesta = EntGetData.GetDatacuenta(IdUnico, ClaveGrupo);
                string MessageError = "no se encuentra registrado en el sistema";
                if (!string.IsNullOrEmpty(respuesta))
                {
                    if (respuesta.Contains(MessageError) || respuesta.Contains("Error"))
                    {
                        
                        DatosCuenta.IdUnico = respuesta;
                    }
                    else
                    {
                        lstrespuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Data>>(respuesta);
                        foreach (var item in lstrespuesta)
                        {
                            DatosCuenta.clavegrupo = item.clavegrupo;
                            DatosCuenta.clave_bd = item.clave_bd;
                            DatosCuenta.FechaFin = item.FechaFin;
                            DatosCuenta.FechaInicio = item.FechaInicio;
                            DatosCuenta.IdAgrupado = item.IdAgrupado;
                            DatosCuenta.IdCartera = item.IdCartera;
                            DatosCuenta.Idcliente = item.Idcliente;
                            DatosCuenta.IdMovimiento = item.IdMovimiento;
                            DatosCuenta.IdUnico = item.IdUnico;
                            DatosCuenta.IdUnico = item.IdUnico;
                            DatosCuenta.nombre_contacto = item.nombre_contacto;
                            DatosCuenta.saldoVencido = item.saldoVencido;
                            DatosCuenta.saldoVencidoInicial = item.saldoVencidoInicial;
                        }
                    }
                }
                else
                {
                    DatosCuenta.IdAgrupado = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(respuesta);
                }
                return DatosCuenta;
            }
            catch (System.Exception ex)
            {
                InvokeAppendLogEx(ex);
                return DatosCuenta;
            }
        }


        public static string GetData (string cadena)
        {
            cadena = cadena.Substring(3);
            string cadenaDesencriptada = Desencriptar(cadena);
            return cadenaDesencriptada;
        }
    }
}
