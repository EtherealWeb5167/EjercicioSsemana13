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

        int[] numeros = new int[20];
        bool listagenerada = false;

        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
