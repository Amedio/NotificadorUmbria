using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotificadorMensajesUmbria
{
    public class NotificadorUmbria
    {
        public List<Mensajes> GetNovedades()
        {
            string data = String.Empty;
            //conectar con URL novedades Umbria y parsear página
            var html = Properties.Settings.Default.url;

            var webReq = new HttpClient();

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(Properties.Settings.Default.usuario), Constantes.ACCESO);
                string ClaveEncript = Properties.Settings.Default.clave;
                string Clave = "";
                try
                {
                    Clave = EasyCrypto.AesEncryption.DecryptWithPassword(ClaveEncript, Constantes.PASSWORD_KEY);
                    formData.Add(new StringContent(Clave), Constantes.CLAVE);
                }
                catch
                { }

                var response = webReq.PostAsync(html, formData).Result;

                if (!response.IsSuccessStatusCode)
                {
                    //return null;
                }

                var stream = response.Content.ReadAsStreamAsync().Result;
                using (var reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();
                }
            }

            //parsear data
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(data);

            List<Mensajes> mensajes = new List<Mensajes>();
            if (Properties.Settings.Default.showMensajesDirector)
                mensajes.AddRange( GetMensajes(htmlDoc, Properties.Settings.Default.idMensajesDirector, "Director"));
            if (Properties.Settings.Default.showMensajesJugador)
                mensajes.AddRange(GetMensajes(htmlDoc, Properties.Settings.Default.idMensajesJugador, "Jugador"));
            if (Properties.Settings.Default.showMensajesVIP)
                mensajes.AddRange(GetMensajes(htmlDoc, Properties.Settings.Default.idMensajesVIP, "VIP"));
            if (Properties.Settings.Default.showMensajesTalleresDirector)
                mensajes.AddRange(GetMensajes(htmlDoc, Properties.Settings.Default.idMensajesTalleresDirector, "Taller (Director)"));
            if (Properties.Settings.Default.showMensajesTalleresRedactor)
                mensajes.AddRange(GetMensajes(htmlDoc, Properties.Settings.Default.idMensajesTalleresRedactor, "Taller (Redactor)"));

            if (Properties.Settings.Default.showMensajesPrivados)
                mensajes.Add(GetMensajesPrivados(htmlDoc,
                    Properties.Settings.Default.idMensajesPrivados,
                    Properties.Settings.Default.tagMensajesPrivados));

            return mensajes;
        }


        public List<Mensajes> GetMensajes(HtmlDocument htmlDoc, string id, string tipo)
        {
            List<Mensajes> mensajes = new List<Mensajes>();
            //m_1 partidas como director
            var node = htmlDoc.GetElementbyId(id);
            if (node == null) return mensajes;
            var p_node = node.SelectNodes("ul/li");

            if(p_node!=null &&
               p_node.Count > 0)
            {
                foreach (var node_partida in p_node)
                {
                    var a_node = node_partida.SelectSingleNode("a");
                    string partida = a_node.InnerText.Trim();

                    var m_node = node_partida.SelectNodes("ul/li");
                    int n_hilos = m_node.Count;
                    int n_mensajes = 0;
                    foreach (var node_hilo in m_node)
                    {
                        n_mensajes += int.Parse(node_hilo.SelectSingleNode("span").InnerText.Trim());
                    }

                    mensajes.Add(new Mensajes()
                    {
                        n_hilos = n_hilos,
                        n_mensajes = n_mensajes,
                        tipo = tipo,
                        partida = partida
                    });
                }
            }
            return mensajes;
        }

        public Mensajes GetMensajesPrivados(HtmlDocument HtmlDoc, string id, string tag)
        {
            var node = HtmlDoc.GetElementbyId(id);
            if(node==null)
                return new Mensajes()
                {
                    n_mensajes = 0,
                    tipo = Constantes.MENSAJES_PRIVADOS,
                    partida = String.Empty,
                    n_hilos = 0
                };
            var tag_node = node.SelectSingleNode(tag);

            int n_mensajes = int.Parse(tag_node.InnerText);

            return new Mensajes()
            {
                n_mensajes = n_mensajes,
                tipo = Constantes.MENSAJES_PRIVADOS,
                partida = String.Empty,
                n_hilos=0
            };
        }
    }

    public class Mensajes
    {
        public int n_hilos;
        public int n_mensajes;
        public string partida;
        public string tipo;
    }
}
