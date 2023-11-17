namespace ProyectoJuego
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lbPuntuacion = new System.Windows.Forms.Label();
            this.timerMoverJugador = new System.Windows.Forms.Timer(this.components);
            this.pbJugador = new System.Windows.Forms.PictureBox();
            this.timerFrecuenciaDeDisparoEnemigo = new System.Windows.Forms.Timer(this.components);
            this.timerDetectarBalaChinche = new System.Windows.Forms.Timer(this.components);
            this.timerDispararBalaJugador = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPuntuacion
            // 
            this.lbPuntuacion.AutoSize = true;
            this.lbPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuntuacion.ForeColor = System.Drawing.Color.White;
            this.lbPuntuacion.Location = new System.Drawing.Point(12, 9);
            this.lbPuntuacion.Name = "lbPuntuacion";
            this.lbPuntuacion.Size = new System.Drawing.Size(104, 20);
            this.lbPuntuacion.TabIndex = 1;
            this.lbPuntuacion.Text = "Puntuacion:";
            // 
            // timerMoverJugador
            // 
            this.timerMoverJugador.Enabled = true;
            this.timerMoverJugador.Tick += new System.EventHandler(this.timerMoverJugador_Tick);
            // 
            // pbJugador
            // 
            this.pbJugador.Image = global::ProyectoJuego.Properties.Resources.NaveJugador1;
            this.pbJugador.Location = new System.Drawing.Point(275, 500);
            this.pbJugador.Name = "pbJugador";
            this.pbJugador.Size = new System.Drawing.Size(50, 50);
            this.pbJugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJugador.TabIndex = 0;
            this.pbJugador.TabStop = false;
            // 
            // timerFrecuenciaDeDisparoEnemigo
            // 
            this.timerFrecuenciaDeDisparoEnemigo.Enabled = true;
            this.timerFrecuenciaDeDisparoEnemigo.Interval = 1500;
            this.timerFrecuenciaDeDisparoEnemigo.Tick += new System.EventHandler(this.timerFrecuenciaDeDisparoEnemigo_Tick);
            // 
            // timerDetectarBalaChinche
            // 
            this.timerDetectarBalaChinche.Enabled = true;
            this.timerDetectarBalaChinche.Interval = 1;
            this.timerDetectarBalaChinche.Tick += new System.EventHandler(this.timerDetectarBalaChinche_Tick);
            // 
            // timerDispararBalaJugador
            // 
            this.timerDispararBalaJugador.Enabled = true;
            this.timerDispararBalaJugador.Interval = 10;
            this.timerDispararBalaJugador.Tick += new System.EventHandler(this.timerDispararBalaJugador_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.lbPuntuacion);
            this.Controls.Add(this.pbJugador);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeclaAbajo);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TeclaArriba);
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbJugador;
        private System.Windows.Forms.Label lbPuntuacion;
        private System.Windows.Forms.Timer timerMoverJugador;
        private System.Windows.Forms.Timer timerFrecuenciaDeDisparoEnemigo;
        private System.Windows.Forms.Timer timerDetectarBalaChinche;
        private System.Windows.Forms.Timer timerDispararBalaJugador;
    }
}

