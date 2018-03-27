namespace NotificadorMensajesUmbria
{
    partial class FrmConf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbIntervalo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkJugador = new System.Windows.Forms.CheckBox();
            this.chkDirector = new System.Windows.Forms.CheckBox();
            this.chkPrivados = new System.Windows.Forms.CheckBox();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.chkResumida = new System.Windows.Forms.CheckBox();
            this.chkNotificacionSinMensajes = new System.Windows.Forms.CheckBox();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.chkMinimizado = new System.Windows.Forms.CheckBox();
            this.chkVips = new System.Windows.Forms.CheckBox();
            this.chkTallerDirector = new System.Windows.Forms.CheckBox();
            this.chkTallerRedactor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBrowser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(114, 9);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(100, 20);
            this.tbUsuario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(114, 35);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // tbIntervalo
            // 
            this.tbIntervalo.Location = new System.Drawing.Point(114, 62);
            this.tbIntervalo.Name = "tbIntervalo";
            this.tbIntervalo.Size = new System.Drawing.Size(120, 20);
            this.tbIntervalo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Intervalo (Minutos)";
            // 
            // chkJugador
            // 
            this.chkJugador.AutoSize = true;
            this.chkJugador.Location = new System.Drawing.Point(15, 88);
            this.chkJugador.Name = "chkJugador";
            this.chkJugador.Size = new System.Drawing.Size(195, 17);
            this.chkJugador.TabIndex = 6;
            this.chkJugador.Text = "Comprobar Mensajes como Jugador";
            this.chkJugador.UseVisualStyleBackColor = true;
            // 
            // chkDirector
            // 
            this.chkDirector.AutoSize = true;
            this.chkDirector.Location = new System.Drawing.Point(15, 111);
            this.chkDirector.Name = "chkDirector";
            this.chkDirector.Size = new System.Drawing.Size(194, 17);
            this.chkDirector.TabIndex = 7;
            this.chkDirector.Text = "Comprobar Mensajes como Director";
            this.chkDirector.UseVisualStyleBackColor = true;
            // 
            // chkPrivados
            // 
            this.chkPrivados.AutoSize = true;
            this.chkPrivados.Location = new System.Drawing.Point(15, 134);
            this.chkPrivados.Name = "chkPrivados";
            this.chkPrivados.Size = new System.Drawing.Size(169, 17);
            this.chkPrivados.TabIndex = 8;
            this.chkPrivados.Text = "Comprobar Mensajes Privados";
            this.chkPrivados.UseVisualStyleBackColor = true;
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Location = new System.Drawing.Point(12, 228);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(75, 23);
            this.BtnGrabar.TabIndex = 16;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(304, 228);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // chkResumida
            // 
            this.chkResumida.AutoSize = true;
            this.chkResumida.Location = new System.Drawing.Point(216, 88);
            this.chkResumida.Name = "chkResumida";
            this.chkResumida.Size = new System.Drawing.Size(163, 17);
            this.chkResumida.TabIndex = 12;
            this.chkResumida.Text = "Mostrar notificación resumida";
            this.chkResumida.UseVisualStyleBackColor = true;
            // 
            // chkNotificacionSinMensajes
            // 
            this.chkNotificacionSinMensajes.Location = new System.Drawing.Point(216, 112);
            this.chkNotificacionSinMensajes.Name = "chkNotificacionSinMensajes";
            this.chkNotificacionSinMensajes.Size = new System.Drawing.Size(166, 39);
            this.chkNotificacionSinMensajes.TabIndex = 13;
            this.chkNotificacionSinMensajes.Text = "Mostrar notificación INCLUSO si no hay mensajes";
            this.chkNotificacionSinMensajes.UseVisualStyleBackColor = true;
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(216, 157);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(135, 17);
            this.chkStartUp.TabIndex = 14;
            this.chkStartUp.Text = "Lanzar al Iniciar Sesión";
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // chkMinimizado
            // 
            this.chkMinimizado.AutoSize = true;
            this.chkMinimizado.Location = new System.Drawing.Point(216, 180);
            this.chkMinimizado.Name = "chkMinimizado";
            this.chkMinimizado.Size = new System.Drawing.Size(109, 17);
            this.chkMinimizado.TabIndex = 15;
            this.chkMinimizado.Text = "Iniciar Minimizado";
            this.chkMinimizado.UseVisualStyleBackColor = true;
            // 
            // chkVips
            // 
            this.chkVips.AutoSize = true;
            this.chkVips.Location = new System.Drawing.Point(15, 157);
            this.chkVips.Name = "chkVips";
            this.chkVips.Size = new System.Drawing.Size(145, 17);
            this.chkVips.TabIndex = 9;
            this.chkVips.Text = "Comprobar Mensajes VIP";
            this.chkVips.UseVisualStyleBackColor = true;
            // 
            // chkTallerDirector
            // 
            this.chkTallerDirector.AutoSize = true;
            this.chkTallerDirector.Location = new System.Drawing.Point(15, 180);
            this.chkTallerDirector.Name = "chkTallerDirector";
            this.chkTallerDirector.Size = new System.Drawing.Size(200, 17);
            this.chkTallerDirector.TabIndex = 10;
            this.chkTallerDirector.Text = "Comprobar Mensajes Taller (Director)";
            this.chkTallerDirector.UseVisualStyleBackColor = true;
            // 
            // chkTallerRedactor
            // 
            this.chkTallerRedactor.AutoSize = true;
            this.chkTallerRedactor.Location = new System.Drawing.Point(15, 203);
            this.chkTallerRedactor.Name = "chkTallerRedactor";
            this.chkTallerRedactor.Size = new System.Drawing.Size(200, 17);
            this.chkTallerRedactor.TabIndex = 11;
            this.chkTallerRedactor.Text = "Comprobar Mensajes Taller (Director)";
            this.chkTallerRedactor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Navegador";
            // 
            // cmbBrowser
            // 
            this.cmbBrowser.FormattingEnabled = true;
            this.cmbBrowser.Location = new System.Drawing.Point(240, 35);
            this.cmbBrowser.Name = "cmbBrowser";
            this.cmbBrowser.Size = new System.Drawing.Size(142, 21);
            this.cmbBrowser.TabIndex = 18;
            // 
            // FrmConf
            // 
            this.AcceptButton = this.BtnGrabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(394, 263);
            this.Controls.Add(this.cmbBrowser);
            this.Controls.Add(this.chkTallerRedactor);
            this.Controls.Add(this.chkTallerDirector);
            this.Controls.Add(this.chkVips);
            this.Controls.Add(this.chkMinimizado);
            this.Controls.Add(this.chkStartUp);
            this.Controls.Add(this.chkNotificacionSinMensajes);
            this.Controls.Add(this.chkResumida);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.chkPrivados);
            this.Controls.Add(this.chkDirector);
            this.Controls.Add(this.chkJugador);
            this.Controls.Add(this.tbIntervalo);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FrmConf";
            this.Text = "Notificador Umbria - Configuración";
            this.Load += new System.EventHandler(this.FrmConf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.NumericUpDown tbIntervalo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkJugador;
        private System.Windows.Forms.CheckBox chkDirector;
        private System.Windows.Forms.CheckBox chkPrivados;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox chkResumida;
        private System.Windows.Forms.CheckBox chkNotificacionSinMensajes;
        private System.Windows.Forms.CheckBox chkStartUp;
        private System.Windows.Forms.CheckBox chkMinimizado;
        private System.Windows.Forms.CheckBox chkVips;
        private System.Windows.Forms.CheckBox chkTallerDirector;
        private System.Windows.Forms.CheckBox chkTallerRedactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBrowser;
    }
}