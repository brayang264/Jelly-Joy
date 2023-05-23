using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jelly_Joy
{
    public class Iniciar
    {
        public static Panel IniciarMatriz(Panel tablero, int proporción)
        {
            Color LightSquareColor = Color.White;
            Color DarkSquareColor = Color.DarkGray;
            int borderSize = proporción;
            int tamañoCasilla = tablero.Width / borderSize;
            for(int row=0; row<borderSize; row++)
            {
                for(int col =0; col<borderSize;col++)
                {
                    Panel casilla = new Panel();
                    casilla.Size = new Size(tamañoCasilla, tamañoCasilla);
                    casilla.Location = new Point(row*tamañoCasilla, col*tamañoCasilla);
                    casilla.BackColor = (row + col) % 2 == 0 ? LightSquareColor : DarkSquareColor;
                    tablero.Controls.Add(casilla);
                }
            }
            return tablero;
        }
        private static int[,] IniciarMatriz(int[,] casillas)
        {
            for(int i = 0; i < casillas.GetLength(0); i++)
            {
                for(int j = 0; j < casillas.GetLength(1); j++)
                {
                    casillas[i, j] = 0;
                }
            }
            return casillas;
        }
    }
}
