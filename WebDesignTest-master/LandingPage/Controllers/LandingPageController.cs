using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

using LandingPage.Models;
using LandingPage.Negocio;
namespace LandingPage.Controllers
{
    public class LandingPageController : Controller
    {
        string IdUnico;
        string ClaveGrupo;
        public static string nombreParametro = WebConfigurationManager.AppSettings["ParametroURL"].ToString();
        // GET: LandingPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LandingPage()
        {
            IdUnico = Request[nombreParametro];
            string telefono = string.Empty;

            if (string.IsNullOrEmpty(IdUnico))
            {
                IdUnico = Request["IdUnico"];
                ClaveGrupo = Request.QueryString["ClaveGrupo"];
                Session["Company"] = ClaveGrupo;
            }
            else
            {
                
                string key = "";
                string value = "";
                string datos = Negocio.BusGetData.GetData(IdUnico);
                foreach (var item in Negocio.Base.ValorCadena(datos))
                {
                    switch (item.Key)
                    {
                        case "idUnico":
                            IdUnico = item.Value;
                            break;
                        case "ClaveGrupo":
                            ClaveGrupo = item.Value;
                            break;
                        case "Telefono":
                            telefono = item.Value;
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(telefono) || !string.IsNullOrWhiteSpace(telefono))
            {
                Session["Tel"] = telefono;
            }
            else
            {
                Session["Tel"] = "";
            }

            Data Datoscuenta = Cuenta(IdUnico, ClaveGrupo);
            if (!string.IsNullOrEmpty(ClaveGrupo) && !string.IsNullOrEmpty(IdUnico))
            {
                if (!string.IsNullOrEmpty(Datoscuenta.IdUnico))
                {
                    if (Datoscuenta.IdUnico.Contains("no se encuentra registrado en el sistema") || Datoscuenta.IdUnico.Contains("Error"))
                    {
                        ViewBag.MessageError = Datoscuenta.IdUnico;
                        return View("Error");
                    }
                    else
                    {
                        if (Datoscuenta.saldoVencido.ToString() == "0.0000" || Datoscuenta.saldoVencido.ToString() == "0,0000" || Datoscuenta.saldoVencido.ToString() == "0.00" || Datoscuenta.saldoVencido.ToString() == "0,00"
                            || Datoscuenta.saldoVencido.ToString() == "0.0" || Datoscuenta.saldoVencido.ToString() == "0,0" || Datoscuenta.saldoVencido.ToString() == "0.000" || Datoscuenta.saldoVencido.ToString() == "0,000")
                        {
                            ViewBag.Message = "Su póliza se encuentra sin adeudos";
                        }
                    }

                }
                else
                {
                    string Message = "Sin Datos que cargar";
                    ViewBag.MessageProblema = Message;
                }

                ViewBag.Monto = string.Format("{0:F}", Datoscuenta.saldoVencido);
                Datoscuenta.saldoVencido = Convert.ToDecimal(string.Format("{0:F}", Datoscuenta.saldoVencido));
                //var formatmonto = string.Format(
                //    (new System.Globalization.CultureInfo("en-US")).NumberFormat,
                //    "{0:C}",
                //    monto1);
                return View(Datoscuenta);
            }
            else
            {
                return View("Error");
            }

        }
        public Data Cuenta(string IdUnico, string ClaveGrupo)
        {
            Data Respuesta = new Data();
            Respuesta = BusGetData.GetDataCuenta(IdUnico, ClaveGrupo);

            return Respuesta;

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendPago(Data CapturaDePago, string Pago)
        {
            string Respuesta = "false";
            CapturaDePago.Telefono = Session["Tel"].ToString();
            Respuesta = BusPostData.PostSendPago(CapturaDePago, Pago);

            if (!string.IsNullOrEmpty(Respuesta))
            {
                if (Respuesta.Contains("No se pudo actualizar su cobro"))
                {
                    ViewBag.MessageError = "No se pudo actualizar su cobro";
                    return View("Error");
                }
                else
                {
                    ViewBag.MenssageExito = Respuesta.ToString();
                    return View("Exito");
                }

            }
            else
            {
                return View("Error");
            }
        }
    }
}