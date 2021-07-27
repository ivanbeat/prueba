using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace LandingPage.Negocio
{
    public class Base
    {
        public static string nombreParametro = WebConfigurationManager.AppSettings["ParametroURL"].ToString();
        public static string Encriptar(string stringToEncrypt)
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            byte[] rgbIV = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };
            byte[] key = { };
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes("A0D1nX0Q");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                string cadena = Convert.ToBase64String(ms.ToArray());
                return "?" + nombreParametro + "=" + cadena;
            }
            catch (Exception ex)
            {
                InvokeAppendLogEx(ex);
                throw new Exception("A ocurrido un error" + ex.Message + ex.Source + ex.InnerException);
            }
        }

        public static string Desencriptar(string EncryptedText)
        {
            byte[] inputByteArray = new byte[EncryptedText.Length + 1];
            byte[] rgbIV = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };
            byte[] key = { };

            try
            {
                EncryptedText = EncryptedText.Replace(" ", "+");
                key = System.Text.Encoding.UTF8.GetBytes("A0D1nX0Q");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(EncryptedText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                InvokeAppendLogEx(ex);
                throw new Exception("A ocurrido un error" + ex.Message + ex.Source + ex.InnerException);
            }
        }

        public static List<KeyValuePair<string, string>> ValorCadena(string cadena)
        {
            var list = new List<KeyValuePair<string, string>>();

            string[] separadas;
            separadas = cadena.Split('&');
            string regex = "=.*";
            string a;
            string b;
            //for (int i = 0; i < separadas.Length; i++)
            //{
            //    string resultado = Regex.Replace(separadas[i], regex, "");
            //    a = resultado.Substring(resultado.IndexOf("?") + 1);
            //    b = separadas[0].Substring(separadas[i].IndexOf("=") + 1);
            //    list.Add(new KeyValuePair<string, string>(a, b));
            //}

            foreach (var i in separadas )
            {
                string resultado = Regex.Replace(i, regex, "");
                a = resultado.Substring(resultado.IndexOf("?") + 1);
                b = i.Substring(i.IndexOf("=") + 1);
                list.Add(new KeyValuePair<string, string>(a, b));
            }

            return list;
        }

        public static void InvokeAppendLogEx(Exception Ex)
        {
            var trace = new StackTrace(Ex);
            var frame = trace.GetFrame(0);
            var method = frame.GetMethod();
            string mensaje = (method.Name + " " + Ex.InnerException + " " + DateTime.Now + Ex.Message + Ex.HelpLink);
            Logitel.Services.Tracing.TracePublisher.Write(mensaje + Ex.HelpLink + Ex.InnerException, "LandingPage");
        }
    }
}
