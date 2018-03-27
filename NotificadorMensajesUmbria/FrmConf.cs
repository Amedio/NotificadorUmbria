using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificadorMensajesUmbria
{
    public partial class FrmConf : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        const string AppNotificadorUmbria = "NotificadorUmbria";
        public FrmConf()
        {
            InitializeComponent();
            //Cargar Navegadores Instalados
            cmbBrowser.DataSource = LoadInstalledBrowsers();
            cmbBrowser.DisplayMember ="Item1";
            cmbBrowser.ValueMember = "Item2";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmConf_Load(object sender, EventArgs e)
        {
            tbUsuario.Text = Properties.Settings.Default.usuario;
            try
            {
                tbPassword.Text = EasyCrypto.AesEncryption.DecryptWithPassword(Properties.Settings.Default.clave, Constantes.PASSWORD_KEY);
            }
            catch
            {
                tbPassword.Text = "";
            }
            tbIntervalo.Value = Properties.Settings.Default.Espera;
            chkDirector.Checked = Properties.Settings.Default.showMensajesDirector;
            chkJugador.Checked = Properties.Settings.Default.showMensajesJugador;
            chkPrivados.Checked = Properties.Settings.Default.showMensajesPrivados;
            chkResumida.Checked = Properties.Settings.Default.Resumido;
            chkNotificacionSinMensajes.Checked = Properties.Settings.Default.showNotificacionSinMensajes;
            chkMinimizado.Checked = Properties.Settings.Default.IniciarMinimizado;
            chkVips.Checked = Properties.Settings.Default.showMensajesVIP;
            chkTallerRedactor.Checked = Properties.Settings.Default.showMensajesTalleresRedactor;
            chkTallerDirector.Checked = Properties.Settings.Default.showMensajesTalleresDirector;
            if (Properties.Settings.Default.browser == Constantes.DEFAULT_BROWSER)
                cmbBrowser.SelectedValue = "";
            else
                cmbBrowser.SelectedValue = Properties.Settings.Default.browser;

            chkStartUp.Checked = rkApp.GetValue(AppNotificadorUmbria) != null;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.usuario = tbUsuario.Text;
            Properties.Settings.Default.clave = EasyCrypto.AesEncryption.EncryptWithPassword( tbPassword.Text, Constantes.PASSWORD_KEY);
            Properties.Settings.Default.Espera =(int) tbIntervalo.Value;
            Properties.Settings.Default.showMensajesDirector = chkDirector.Checked;
            Properties.Settings.Default.showMensajesJugador = chkJugador.Checked;
            Properties.Settings.Default.showMensajesPrivados = chkJugador.Checked;
            Properties.Settings.Default.Resumido = chkResumida.Checked;
            Properties.Settings.Default.showNotificacionSinMensajes = chkNotificacionSinMensajes.Checked;
            Properties.Settings.Default.IniciarMinimizado = chkMinimizado.Checked;
            Properties.Settings.Default.showMensajesVIP= chkVips.Checked ;
            Properties.Settings.Default.showMensajesTalleresRedactor=chkTallerRedactor.Checked ;
            Properties.Settings.Default.showMensajesTalleresDirector=chkTallerDirector.Checked;
            if (cmbBrowser.SelectedValue == Constantes.DEFAULT_BROWSER)
                Properties.Settings.Default.browser = Constantes.DEFAULT_BROWSER;
            else
                Properties.Settings.Default.browser = cmbBrowser.SelectedValue.ToString();

            Properties.Settings.Default.Save();

            if (chkStartUp.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue(AppNotificadorUmbria, Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue(AppNotificadorUmbria, false);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private List<Tuple<string, string>> LoadInstalledBrowsers()
        {
            List<Tuple<string, string>> lst = new List<Tuple<string, string>>();
            lst.Add(new Tuple<string, string>(Constantes.DEFAULT_BROWSER, ""));

            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                if (webClientsRootKey != null)
                    foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                        if (webClientsRootKey.OpenSubKey(subKeyName) != null)
                            if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
                                if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
                                    if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
                                    {
                                        string commandLineUri = (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
                                        if (string.IsNullOrEmpty(commandLineUri))
                                            continue;
                                        commandLineUri = commandLineUri.Trim("\"".ToCharArray());
                                        Tuple<string, string> newBrowser = new Tuple<string, string>((string)webClientsRootKey.OpenSubKey(subKeyName).GetValue(null), commandLineUri);

                                        lst.Add(newBrowser);
                                    }
            }
            return lst;
        }
    }
}
