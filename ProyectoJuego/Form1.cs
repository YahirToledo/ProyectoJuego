﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoJuego
{
    public partial class Form1 : Form
    {
        bool moverDer;
        bool moverIzq;
        bool disparar;
        bool pausa = false;
        bool juego = true;
        int speed = 20;
        int puntos = 0;
        PictureBox pbPausa = new PictureBox();
        List<PictureBox> imagenChinches = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            new Enemigo(0, 0, 0, 0).Malla(this);
            dibujarChinches();
        }

        #region Eventos
        private void TeclaAbajo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moverIzq = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moverDer = true;
            }
            if (e.KeyCode == Keys.Up && pausa == false)
            {
                crearBalaJugador();
                disparar = true;
            }
            if (e.KeyCode == Keys.P && pausa == false)
            {
                ponerPausa();
                dibujarPausa(pbPausa);
                pausa = true;
            }
            else if (e.KeyCode == Keys.P && pausa == true)
            {
                quitarPausa();
                borrarPausa(pbPausa);
                pausa = false;
            }
            if (e.KeyCode == Keys.Escape && juego == false)
            {
                //Hacer que se regrese al menu
            }
            if (e.KeyCode == Keys.Enter && juego == true)
            {
                //Haver que pase al siguiente nivel
            }
        }
        private void TeclaArriba(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moverIzq = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moverDer = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                disparar = false;
            }
        }

        private void timerMoverJugador_Tick(object sender, EventArgs e)
        {
            if (moverIzq == true && pbJugador.Location.X >= 15)
            {
                pbJugador.Left -= speed;
            }
            else if (moverDer == true && pbJugador.Location.X <= 525)
            {
                pbJugador.Left += speed;
            }
        }
        private void timerFrecuenciaDeDisparoEnemigo_Tick(object sender, EventArgs e)
        {
            timerFrecuenciaDeDisparoEnemigo.Interval = 1500; // Cambia la frecuancia con la que disparan los enemigos en [ms]
            Random r = new Random();
            int eleccion; //Elige de cual chinche se va a disparar

            if (imagenChinches.Count > 0)
            {
                eleccion = r.Next(imagenChinches.Count);
                crearBalaChinche(imagenChinches[eleccion]);
            }
        }
        private void timerDetectarBalaChinche_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "BalaChinche")
                {
                    PictureBox laser = (PictureBox)c;
                    laser.Top += 3; // Cambia la velocidad de las balas de las chinches
                    if (laser.Location.Y >= 730)
                    {
                        this.Controls.Remove(laser);
                    }
                    if (laser.Bounds.IntersectsWith(pbJugador.Bounds))
                    {
                        this.Controls.Remove(laser);
                        perdiste();
                    }
                }
            }
        }
        private void timerDispararBalaJugador_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "BalaJugador")
                {
                    PictureBox pbBalaJugador = (PictureBox)c;
                    pbBalaJugador.Top -= 5;
                    if (pbBalaJugador.Location.Y <= 0)
                    {
                        this.Controls.Remove(pbBalaJugador);
                    }
                    foreach (Control ct in this.Controls)
                    {

                        if (ct is PictureBox && ct.Name == "BalaChinche")
                        {
                            PictureBox pbBalaChinche = (PictureBox)ct;

                            if (pbBalaJugador.Bounds.IntersectsWith(pbBalaChinche.Bounds))
                            {
                                this.Controls.Remove(pbBalaJugador);
                                this.Controls.Remove(pbBalaChinche);
                                puntos += 100;
                                puntaje(puntos);
                            }

                        }

                    }

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is PictureBox && ctrl.Name == "Chinche")
                        {
                            PictureBox pbChinche = (PictureBox)ctrl;

                            if (pbBalaJugador.Bounds.IntersectsWith(pbChinche.Bounds))
                            {
                                this.Controls.Remove(pbBalaJugador);
                                this.Controls.Remove(pbChinche);
                                imagenChinches.Remove(pbChinche);
                                puntos += 500;
                                puntaje(puntos);
                                verificarGanador();
                            }
                        }
                    }

                }
            }
        }
        #endregion

        #region Funciones
        private void dibujarChinches()
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Chinche")
                {
                    PictureBox chinches = (PictureBox)c;
                    imagenChinches.Add(chinches);
                }
            }
        }
        private void crearBalaJugador()
        {
            PictureBox pbBalaJugador = new PictureBox();
            pbBalaJugador.Location = new Point(pbJugador.Location.X + pbJugador.Width / 2, pbJugador.Location.Y - 30);
            pbBalaJugador.Size = new Size(20, 30);
            pbBalaJugador.BackgroundImage = Properties.Resources.BalaJugador;
            pbBalaJugador.BackgroundImageLayout = ImageLayout.Stretch;
            pbBalaJugador.Name = "BalaJugador";
            this.Controls.Add(pbBalaJugador);
        }
        private void crearBalaChinche(PictureBox a)
        {
            PictureBox pbBalaChinche = new PictureBox();
            pbBalaChinche.Location = new Point(a.Location.X + a.Width / 3, a.Location.Y + 20);
            pbBalaChinche.Size = new Size(20, 20);
            pbBalaChinche.BackgroundImage = Properties.Resources.BalaChinche;
            pbBalaChinche.BackgroundImageLayout = ImageLayout.Stretch;
            pbBalaChinche.Name = "BalaChinche";
            this.Controls.Add(pbBalaChinche);
        }
        private void puntaje(int puntos)
        {
            lbPuntuacion.Text = "Puntuacion: " + puntos.ToString();
        }
        private void dibujarPausa(PictureBox pbPausa)
        {
            pbPausa.Location = new Point(100, 100);
            pbPausa.Size = new Size(200, 200);
            pbPausa.BackgroundImage = Properties.Resources.NaveJugador1;
            pbPausa.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pbPausa);
        }
        private void borrarPausa(PictureBox pbPausa)
        {
            Controls.Remove(pbPausa);
        }
        private void ponerPausa()
        {
            timerMoverJugador.Stop();
            timerDetectarBalaChinche.Stop();
            timerFrecuenciaDeDisparoEnemigo.Stop();
            timerDispararBalaJugador.Stop();
        }
        private void quitarPausa()
        {
            timerMoverJugador.Start();
            timerDetectarBalaChinche.Start();
            timerFrecuenciaDeDisparoEnemigo.Start();
            timerDispararBalaJugador.Start();
        }    
        private void textoPerdiste()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name == "lbTerminar")
                {
                    Label lbTerminar = (Label)c;
                    c.Visible = true;
                    lbTerminar.Text = "Perdiste";
                }
                else
                {
                    c.Visible = false;
                }
            }
            
        }
        private void textoSalir()
        {
            lbSalir.Text = "Presiona ESC para salir al menu";
            lbSalir.Visible = true;
        }
        private void perdiste()
        {
            timerDetectarBalaChinche.Stop();
            timerMoverJugador.Stop();
            timerFrecuenciaDeDisparoEnemigo.Stop();
            timerDispararBalaJugador.Stop();
            textoPerdiste();
            textoSalir();
            juego = false;
        }
        private void verificarGanador()
        {
            int count = 0;

            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Chinche") count++;
            }

            if (count == 0) ganaste();
        }
        private void textoGanaste()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name == "lbTerminar")
                {
                    Label lbTerminar = (Label)c;
                    c.Visible = true;
                    lbTerminar.Text = "Ganaste" + "\n" + "Puntuacion: " + puntos.ToString();
                }
                else
                {
                    c.Visible = false;
                }
            }
        }
        private void textoSiguiente()
        {
            lbSalir.Text = "Presiona ENTER para pasar al siguiente nivel";
            lbSalir.Visible = true;
        }
        private void ganaste()
        {
            timerDetectarBalaChinche.Stop();
            timerMoverJugador.Stop();
            timerFrecuenciaDeDisparoEnemigo.Stop();
            timerDispararBalaJugador.Stop();
            textoGanaste();
            textoSiguiente();
        }
        #endregion
    }
}