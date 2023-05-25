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
        public static int[,] matriz;
        public static Panel IniciarMatriz(Panel tablero, int proporción)
        {
            Color LightSquareColor = Color.White;
            Color DarkSquareColor = Color.DarkGray;
            int[,] referencia = CrearMatriz(proporción);
            Random random = new Random();
            int figura = 0;
            int borderSize = proporción;
            int tamañoCasilla = tablero.Width / borderSize;
            for(int row=0; row<borderSize; row++)
            {
                for(int col =0; col<borderSize;col++)
                {
                    Panel casilla = new Panel();
                    casilla.Size = new Size(tamañoCasilla, tamañoCasilla);
                    casilla.Location = new Point(row*tamañoCasilla, col*tamañoCasilla);
                    figura = random.Next(1, 6);
                    casilla.BackgroundImageLayout = ImageLayout.Zoom;
                    switch(figura)
                    {
                        case 1:
                            casilla.BackgroundImage = Properties.Resources.cuadrado;
                            break;
                        case 2:
                            casilla.BackgroundImage = Properties.Resources.rectangulo;
                            break;
                        case 3:
                            casilla.BackgroundImage = Properties.Resources.triangulo;
                            break;
                        case 4:
                            casilla.BackgroundImage = Properties.Resources.circulo;
                            break;
                        case 5:
                            casilla.BackgroundImage = Properties.Resources.diamante;
                            break;
                        default:
                            break;
                    }
                    casilla.BackColor = (row + col) % 2 == 0 ? LightSquareColor : DarkSquareColor;
                    casilla.Click += new EventHandler(Seleccionar);
                    AgregarListas(casilla, figura,false);
                    referencia[col, row] = figura;
                    tablero.Controls.Add(casilla);
                }
            }
            matriz = referencia;
            ImprimirMatriz(matriz);
            return tablero;
        }

        private static void Seleccionar(object sender, EventArgs e)
        {
            Panel casilla = sender as Panel;
            int index = posiciones.IndexOf(casilla);
            casilla.BackColor = seleccionada[index] ? Color.DarkBlue : Color.White;
            seleccionada[index] = seleccionada[index]? false: true;
        }
        static List<bool> seleccionada = new List<bool>();
        static List<Panel> posiciones = new List<Panel>();
        static List<int> indices = new List<int>();
        
        public static void AgregarListas(Panel casilla, int indice, bool flag)
        {
            posiciones.Add(casilla);
            indices.Add(indice);
            seleccionada.Add(flag);
        }

        public static List<int> ObtenerIndices()
        {
            return indices;
        }

        public static List<Panel> ObtenerCasillas()
        {
            return posiciones;
        }

        private static void ImprimirMatriz(int[,] referencia)
        {
            string respuesta = "";
            for(int i = 0; i< referencia.GetLength(0);i++)
            {
                for(int j = 0; j < referencia.GetLength(1);j++)
                {
                    respuesta += " | " + referencia[i, j] + " | ";
                }
                respuesta += "\n";
            }
            MessageBox.Show(respuesta);
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

        public static int[,] CrearMatriz(int proporción)
        {
            int[,] matriz = new int[proporción, proporción];
            matriz = IniciarMatriz(matriz);
            return matriz;
        }
        public static int[,] Cambiar(List<Panel> casillas, List<int> indices, int[,] tablero)
        {


            return tablero;
        }
    }
}
