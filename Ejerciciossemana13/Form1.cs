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

        //ejercicio 6
        int[,] matriz = new int[10, 10];

        //ejercicio4
        public class Estudiante
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        // EJERCICIO 4
        List<Estudiante> misEstudiantes = new List<Estudiante>();

        // ejercicio 1
        int[] numeros = new int[20];
        bool listagenerada = false;

        //ejercicio 5
        List<int> listaEjercicio5 = new List<int>();


        public Form1()
        {
            InitializeComponent();

            //EJERCICIO 4
            CargarEstudiantes();
        }

        //ejercicio 4
        private void CargarEstudiantes()
        {

            misEstudiantes.Add(new Estudiante { Id = 20, Nombre = "Ana" });
            misEstudiantes.Add(new Estudiante { Id = 15, Nombre = "Beto" });
            misEstudiantes.Add(new Estudiante { Id = 33, Nombre = "Carlos" });
            misEstudiantes.Add(new Estudiante { Id = 12, Nombre = "Daniel" });
            misEstudiantes.Add(new Estudiante { Id = 50, Nombre = "Elena" });
            misEstudiantes.Add(new Estudiante { Id = 08, Nombre = "Fabio" });
            misEstudiantes.Add(new Estudiante { Id = 41, Nombre = "Gabriela" });
            misEstudiantes.Add(new Estudiante { Id = 19, Nombre = "Hugo" });
            misEstudiantes.Add(new Estudiante { Id = 22, Nombre = "Irene" });
            misEstudiantes.Add(new Estudiante { Id = 05, Nombre = "Juan" });

            foreach (Estudiante est in misEstudiantes)
            {
                lbListadoEstudiantes.Items.Add(est.Id + " - " + est.Nombre);
            }
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

        //ejercicio4

        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            int idBuscado = Convert.ToInt32(tbBuscarID.Text);

            bool encontrado = false;

            foreach (Estudiante est in misEstudiantes)
            {
                if (est.Id == idBuscado)
                {
                    MessageBox.Show("encontrado Es: " + est.Nombre);
                    encontrado = true;
                    break; 
                }
            }

            if (encontrado == false)
            {
                MessageBox.Show("No existe un estudiante con ese ID.");
            }
        }

        //ejercicio4

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            string nombreBuscado = tbBuscarNombre.Text;

            int izquierda = 0;                      
            int derecha = misEstudiantes.Count - 1;  
            bool encontrado = false;

            
            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2; 
                string nombreDelMedio = misEstudiantes[medio].Nombre;

                // funcinoamento del compareto:
                // resultado es 0  -> Son iguales 
                // resultado < 0   -> El del medio es menor (buscar a la derecha)
                // resultado > 0   -> El del medio es mayor (buscar a la izquierda)

                int resultado = nombreDelMedio.CompareTo(nombreBuscado);

                if (resultado == 0)
                {
                    MessageBox.Show("encontrado ID: " + misEstudiantes[medio].Id);
                    encontrado = true;
                    break;
                }
                else if (resultado < 0)
                {
                    
                    izquierda = medio + 1;
                }
                else
                {
                    
                    derecha = medio - 1;
                }
            }

            if (encontrado == false)
            {
                MessageBox.Show("No se encontro el nombre.");
            }
        }


        //ejercicio5
        private void btnGenerarEjercicio5_Click(object sender, EventArgs e)
        {
            listaEjercicio5.Clear(); 
            lbEjercicio5.Items.Clear(); 

            Random aleatorio = new Random();

            for (int i = 0; i < 15; i++)
            {
                int numero = aleatorio.Next(1, 100);
                listaEjercicio5.Add(numero);

                lbEjercicio5.Items.Add(numero);
            }
        }

        //ejercicio5
        private void btnCalcularEjercicio5_Click(object sender, EventArgs e)
        {
            if (listaEjercicio5.Count == 0)
            {
                MessageBox.Show("Primero presiona el boton generar Lista.");
                return;
            }

          
            int maximo = listaEjercicio5[0];
            int minimo = listaEjercicio5[0];
            int iteraciones = 0;

            foreach (int numero in listaEjercicio5)
            {
                iteraciones++;

                //  El numero actual es mas grande que el maximo actual?
                if (numero > maximo)
                {
                    maximo = numero; 
                }

                // El numero actual es mas pequeno queel minimo actual?
                if (numero < minimo)
                {
                    minimo = numero;
                }
            }

            
            string mensaje = "";
            mensaje += "El valor maximo es: " + maximo + "\n";
            mensaje += "El valor minimo es: " + minimo + "\n";
            mensaje += "Total de iteraciones: " + iteraciones;

            lblRespuestaEjercicio5.Text = mensaje;
        }

        //ejercicio6
        private void btnGenerarMatriz_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string textoMostrar = ""; 

            // Recorre las filas del 0 al 9
            for (int f = 0; f < 10; f++)
            {
                //Recorre las columnas del 0 al 9
                for (int c = 0; c < 10; c++)
                {
                    //llenar con un numero random
                    matriz[f, c] = rnd.Next(10, 100);

                    // agregamr al texto con un espacio separador
                    textoMostrar += matriz[f, c] + "   ";
                }

                // salto de linea
                textoMostrar += "\r\n";
            }

            tbMatriz.Text = textoMostrar;
        }

        //ejercicio6
        private void btnBuscarMatriz_Click(object sender, EventArgs e)
        {
            if (tbMatriz.Text == "")
            {
                MessageBox.Show("Primero genera la matriz");
                return;
            }

            int buscado = Convert.ToInt32(tbMatrizEjercicio6.Text);
            string encontrados = ""; 
            bool existe = false;

    

            for (int f = 0; f < 10; f++) //  cada fila
            {
                for (int c = 0; c < 10; c++) // cada columna.
                {
                    // El numero en la fila F y columna C es el que busco?
                    if (matriz[f, c] == buscado)
                    {
                        // Guardar la cordenadda
                        encontrados += "Fila " + f + " - Columna " + c + "\n";
                        existe = true;
                    }
                }
            }

            if (existe)
            {
                lblResultadoMatriz.Text = "Encontrado en:\n" + encontrados;
            }
            else
            {
                lblResultadoMatriz.Text = "El numero no esta en la matriz.";
            }
        }
    }
}
