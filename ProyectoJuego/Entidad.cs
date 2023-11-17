using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    internal class Entidad
    {
        #region Atributos
        private int ancho;
        private int alto;
        private int poscX;
        private int poscY;
        #endregion

        #region Propiedades
        public int Ancho
        {
            get => ancho;
            set => ancho = value > 70 ? 40 : value;
        }
        public int Alto
        {
            get => alto;
            set => alto = value > 70 ? 40 : value;
        }
        public int PoscX
        {
            get => poscX;
            set => poscX = value > 600 ? 0 : value;
        }
        public int PoscY
        {
            get => poscY;
            set => poscY = value > 600 ? 0 : value;
        }
        #endregion

        #region Constructor
        public Entidad(int ancho, int alto, int poscX, int poscY)
        {
            Ancho = ancho;
            Alto = alto;
            PoscX = poscX;
            PoscY = poscY;
        }
        #endregion
    }
}
