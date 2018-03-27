using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificadorMensajesUmbria
{
    public partial class Form1 : Form
    {
        NotificadorUmbria Notificador = new NotificadorUmbria();
        public Form1()
        {
            InitializeComponent();

            //version
            this.Text += " v" + Assembly.GetEntryAssembly().GetName().Version.ToString();

            timerProgreso.Interval = 1000;
            timerProgreso.Tick += TimerProgreso_Tick;
            timerProgreso.Start();

            CalcularIntervalo();
            LblNext.Text = "Próxima comprobación: " + (DateTime.Now.AddMinutes(Properties.Settings.Default.Espera));

            progreso = ProgressBar.Minimum;
            ProgressBar.Value = ProgressBar.Minimum;

            notifyIcon1.BalloonTipTitle= "Notificador Mensajes Umbría";
            notifyIcon1.BalloonTipText = Constantes.ESPERANDO;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            Comprobar();
        }

        float incrementoProgreso = 0;
        float progreso = 0;
        private void CalcularIntervalo()
        {/*
            Properties.Settings.Default.Espera * 60 --> 100
                1 --> ¿¿
                */
            incrementoProgreso =((float) (ProgressBar.Maximum - ProgressBar.Minimum) / (Properties.Settings.Default.Espera * 60));
        }

        private void TimerProgreso_Tick(object sender, EventArgs e)
        {

        }

        private void Comprobar()
        {
            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    throw new Exception("No se ha encontrado conexión a Internet!!");
                }

                var result = Notificador.GetNovedades();

                var resultResumido = CrearMensaje(result, true);
                var resultMsg = CrearMensaje(result, Properties.Settings.Default.Resumido);

                tbResumen.Text = resultMsg;
                notifyIcon1.BalloonTipText = resultMsg;
                string notifyText = "Notificador Novedades Umbria:" + Environment.NewLine + resultResumido;
                if (notifyText.Length > 64)
                    notifyText = notifyText.Substring(0, 61) + "...";
                notifyIcon1.Text = notifyText;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                lblMsgToolStripMenuItem.Text = resultResumido;

                if (resultMsg != Constantes.NO_MENSAJES
                    || Properties.Settings.Default.showNotificacionSinMensajes)
                    notifyIcon1.ShowBalloonTip(2000);
                LblLast.Text = "Última comprobación: " + DateTime.Now;

            }
            catch(Exception ex)
            {
                tbResumen.Text  = "Se ha encontrado un error inesperado: " + ex.Message;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.BalloonTipText = tbResumen.Text;
            }
            finally
            {
                LblNext.Text = "Próxima comprobación: " + (DateTime.Now.AddMinutes(Properties.Settings.Default.Espera));
                progreso = ProgressBar.Minimum;
                ProgressBar.Value = ProgressBar.Minimum;
            }
        }
        private string CrearMensaje(List<Mensajes> mensajes, bool resumido)
        {
            string Mensaje = String.Empty;
            int total_mensajes = mensajes
                .Where(msg => msg.tipo != Constantes.MENSAJES_PRIVADOS)
                .Sum(msg => msg.n_mensajes);
            int total_mensajes_privados = mensajes
                .Where(msg => msg.tipo == Constantes.MENSAJES_PRIVADOS)
                .Sum(msg => msg.n_mensajes);
            int total_hilos = mensajes.Sum(msg => msg.n_hilos);

            if (total_mensajes + total_mensajes_privados > 0)
            {
                if (resumido)
                {
                    Mensaje = String.Empty;
                    if (total_mensajes>0)
                    {
                        Mensaje += String.Format("{0} mensaje{2} en {1} hilo{3}",
                            total_mensajes,
                            total_hilos,
                            total_mensajes > 1 ? "s" : "",
                            total_hilos > 1 ? "s" : "");
                    }
                    if (total_mensajes_privados > 0)
                    {
                        if (!String.IsNullOrEmpty(Mensaje))
                            Mensaje += Environment.NewLine;
                        Mensaje += String.Format("{0} mensaje{1} privado{1}",
                            total_mensajes_privados,
                            total_mensajes_privados > 1 ? "s" : "");
                    }
                }
                else
                {
                    foreach (Mensajes mensaje in mensajes)
                    {
                        if (mensaje.n_mensajes > 0)
                        {
                            if (!String.IsNullOrEmpty(Mensaje))
                                Mensaje += Environment.NewLine;
                            Mensaje += String.Format("{0} mensaje{2} nuevo{2} como {1} ",
                               mensaje.n_mensajes,
                               mensaje.tipo,
                                total_mensajes > 1 ? "s" : "");
                            if (mensaje.tipo != Constantes.MENSAJES_PRIVADOS)
                                Mensaje += String.Format("en {0} hilo{1}",
                                        mensaje.n_hilos,
                                        total_hilos > 1 ? "s" : "");
                            if (!String.IsNullOrEmpty(mensaje.partida))
                                Mensaje += String.Format(" en la partida {0}", mensaje.partida);
                        }
                    }
                }
            }
            else
            {
                Mensaje = Constantes.NO_MENSAJES;
            }
            return Mensaje;
        }

        private void BtnComprobar_Click(object sender, EventArgs e)
        {
            Comprobar();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs &&
              (e as MouseEventArgs).Button == MouseButtons.Left)
                irANovedadesToolStripMenuItem_Click(sender, e);
            //contextMenuStrip1.Show();
        }

        private void comprogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comprobar();
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        private void BtnConfiguración_Click(object sender, EventArgs e)
        {
            Configurar();
        }

        private void Configurar()
        {
            FrmConf frm = new FrmConf();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                CalcularIntervalo();
                ProgressBar.Value = ProgressBar.Minimum;
                LblNext.Text = "Próxima comprobación: " + (DateTime.Now.AddMinutes(Properties.Settings.Default.Espera));
            }
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configurar();
        }

        private void irANovedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Properties.Settings.Default.browser ) ||
                Properties.Settings.Default.browser == Constantes.DEFAULT_BROWSER)
                System.Diagnostics.Process.Start(Properties.Settings.Default.url);
            else
                System.Diagnostics.Process.Start(Properties.Settings.Default.browser, Properties.Settings.Default.url);
        }

        private void lblMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnNovedades_Click(object sender, EventArgs e)
        {
            irANovedadesToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IniciarMinimizado)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Form1_Resize(this, null);
            }
        }
    }
}
