using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoJuego
{
    internal class Enemigo : Entidad
    {
        private int columnas;
        private int filas;
        private int espacio;

        public int Columnas
        {
            get => columnas;
            set => columnas = value <= 0 ? 10 : value;
        }
        public int Filas
        {
            get => filas;
            set => filas = value <= 0 ? 3 : value;
        }
        public Enemigo(int ancho, int alto, int poscX, int poscY) : base(ancho, alto, poscX, poscY)
        {
            Ancho = 50;
            Alto = 50;
            Columnas = 8;
            Filas = 3;
            PoscX = 70;
            PoscY = 30;
            espacio = 5;
        }
        private void crearEnemigo(Form p)
        {
            PictureBox pbChinche = new PictureBox();
            pbChinche.Location = new Point(PoscX, PoscY);
            //pbChinche.Location = new Point(poscX, poscY);
            pbChinche.Size = new Size(Ancho, Alto);
            //pbChinche.Size = new Size(ancho, alto);
            pbChinche.BackgroundImage = Properties.Resources.Chinche1;
            pbChinche.BackgroundImageLayout = ImageLayout.Stretch;
            pbChinche.Name = "Chinche";
            p.Controls.Add(pbChinche);
        }
        public void Malla(Form p)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    crearEnemigo(p);
                    PoscX += Ancho + espacio;
                }
                PoscY += Alto + espacio;
                PoscX = 70;
            }
        }
    }
}
