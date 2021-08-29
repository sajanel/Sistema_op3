using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sistema_op3
{
    public partial class Form1 : Form
    {
        Operaciones op = new Operaciones();
        delegate void delegado(int valor);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtEntrada.Text == "") { MessageBox.Show("Digite variables"); }

            else {

                if (comboBox1.Text == "Secuencial")
                {
                    listBox1.Items.Add("Secuencial factorial:  " + op.Factorial(Convert.ToInt32(txtEntrada.Text)));
                    listBox1.Items.Add("Secuencial fibonacci:  " + op.Fibonacci(Convert.ToInt32(txtEntrada.Text)));
                }
                else if (comboBox1.Text == "Hilos")
                {
                    Thread HiloProceso1 = new Thread(new ThreadStart(attender_hilo1));
                    Thread HiloProceso2 = new Thread(new ThreadStart(atteder_Hilo2));
                    HiloProceso1.Start();
                    HiloProceso2.Start();
                   
                }
            }
        }

        //Calculo del factoria por medio de Hilos
        public void attender_hilo1()
        {
            int cont = 1;
            int var = Convert.ToInt32(txtEntrada.Text);

            for (int i = 1; i <= var; i++)
            {
                Thread.Sleep(500);
                delegado MD = new delegado(Actualizar1);
                this.Invoke(MD, new object[] { cont *= i });
                
            }
        }
        public void Actualizar1(int valor)
        {
            listBox1.Items.Add("Factorial--> " + valor + "\r\n");
        }
        //Fin del calculo 



        public void atteder_Hilo2()
        {

            int primero = 0, segundo = 1, siguiente, var = 0;
            delegado MD;

            var = Convert.ToInt32(txtEntrada.Text);

            for (int i = 0; i <= var; i++)
            {
                if (i <= 1)
                {
                    siguiente = i;
                }
                else
                {
                    siguiente = primero + segundo;
                    primero = segundo;
                    segundo = siguiente;
                }

                Thread.Sleep(500);
                MD = new delegado(Actualizar2);
                this.Invoke(MD, new object[] { siguiente });
            }

        }
        public void Actualizar2(int valor)
        {
            listBox1.Items.Add("     Fibonacci--> " + valor + "\r\n");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

      
    }
}
