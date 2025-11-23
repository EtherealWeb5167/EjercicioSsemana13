using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejerciciossemana13
{
    public partial class Form1 : Form
    {

        // ejercicio 1
        int[] numeros = new int[20];
        bool listagenerada = false;
        //ejercicio 1

        public Form1()
        {
            InitializeComponent();
        }

        //ejercicio 1
        private void btnBuscarEjercicio1_Click(object sender, EventArgs e)
        {
            Random aleatorio = new Random();
            string textoLista = "";

            for (int i = 0; i < 20; i++)
            {
                numeros[i] = aleatorio.Next(1, 100);
                textoLista += numeros[i] + ", ";
            }

            listagenerada = true;

            
            lblEjercicio1.Text = textoLista;

        }

        //ejercicio 1
        private void btnBuscarEjercicio1_Click_1(object sender, EventArgs e)
        {
            if (!listagenerada)
            {
                MessageBox.Show("Primero debes presionar el boton Generar");
                return;
            }

            if (string.IsNullOrEmpty(tbBuscarEjercicio1.Text))
            {
                MessageBox.Show("Escribe un numero primero.");
                return;
            }

            int numeroBuscado;
            if (!int.TryParse(tbBuscarEjercicio1.Text, out numeroBuscado))
            {
                lblResultadoEjercicio1.Text = "Error: Ingresa solo numeros.";
                return;
            }

            bool encontrado = false;
            int posicion = -1;

            for (int i = 0; i < 20; i++)
            {
                if (numeros[i] == numeroBuscado)
                {
                    encontrado = true;
                    posicion = i;
                    break;
                }
            }

            if (encontrado)
            {
                lblResultadoEjercicio1.Text = "Encontrado en la posicion: " + (posicion);
            }
            else
            {
                lblResultadoEjercicio1.Text = "El numero " + numeroBuscado + " no existe en la lista.";
            }
        }

        //ejercicio2
        private void btnEjercicio2_Click(object sender, EventArgs e)
        {
            lbEjercicio2.Items.Clear(); 

            List<int> lista = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                lista.Add(rnd.Next(1, 100));
            }

            //ORDENAR
            lista.Sort();

            lbEjercicio2.Items.Add("Lista Ordenada: " + string.Join(", ", lista));

            
            int buscado = rnd.Next(1,100);
            lbEjercicio2.Items.Add("Buscando el numero: " + buscado);

            int inicio = 0;
            int fin = lista.Count - 1;
            bool encontrado = false;

            while (inicio <= fin)
            {
                int mitad = (inicio + fin) / 2;
                int valorCentro = lista[mitad];

                lbEjercicio2.Items.Add($"Revisando mitad: indice {mitad}, valor {valorCentro}");

                if (valorCentro == buscado)
                {
                    lbEjercicio2.Items.Add("encontrado en indice " + mitad);
                    encontrado = true;
                    break;
                }
                else if (valorCentro < buscado)
                {
                    lbEjercicio2.Items.Add("El valor es menor, buscando en la derecha.");
                    inicio = mitad + 1;
                }
                else
                {
                    lbEjercicio2.Items.Add("El valor es mayor, buscando en la izquierda.");
                    fin = mitad - 1;
                }
            }

            if (!encontrado)
            {
                lbEjercicio2.Items.Add("No se encontro el numero.");
            }
        }
        
        //ejercicio 3
        private void btnBuscarEjercicio3_Click(object sender, EventArgs e)
        {
            string parrafo = tbEjercicio3parrafo.Text.ToLower(); 
            string palabra = tbBuscarEjercicio3.Text.ToLower(); 
            int contador = 0;

            if (parrafo.Length == 0 || palabra.Length == 0) return;

            for (int i = 0; i <= parrafo.Length - palabra.Length; i++)
            {
                bool coincide = true;

                for (int j = 0; j < palabra.Length; j++)
                {
                    if (parrafo[i + j] != palabra[j])
                    {
                        coincide = false;
                        break; 
                    }
                }

                if (coincide)
                {
                    contador++;
                }
            }

            lblResultadosEjercicio3.Text = "La palabra aparece " + contador + " veces.";
        }
    }
}
