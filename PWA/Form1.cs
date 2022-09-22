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

namespace PWA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Metodos 
        public void asic()
        {
            int a = 0, b = 0;

            for (a = 1; a <= 100000; a++)
            {
                for (b = 1; b <= 100000; b++)
                {

                }
            }
            
        }

        public void metodo(fundelegate z, float x1, float x2)
        {
            float salida = 0;
            salida = z(x1, x2);
            MessageBox.Show("Salida realizada desde un delegado" + salida);
        }
        //Funciones con los metosdos suma, multiplicacion y divicion para nuestro delegado 
        public float suma( float a, float b)
        {
            return a + b;
        }

        public float multiplica(float a, float b)
        {
            return a * b;
        }

        public float divicion(float a, float b)
        {
            return a/b;
        }
        //Delegado 
        public delegate float fundelegate(float a, float b);

        private void button1_Click(object sender, EventArgs e)
        {
            asic();
        }

        //suma utilizando un delegado
        private void button2_Click(object sender, EventArgs e)
        {
            fundelegate subyection = suma;
            float salida = subyection(2.5f, 5.6f);
            MessageBox.Show("Suma utilizando un delegado es de " + salida);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fundelegate d1 = null;
            if (radioButton1.Checked)
            {
                d1 = suma;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    d1 = multiplica;
                }
                else if (radioButton3.Checked)
                {
                    d1 = divicion;
                }
            }
            if (d1 != null)
            {
                metodo(d1, Convert.ToSingle(textBox1.Text),
                    Convert.ToSingle(textBox2.Text));
            }
            else
            {
                MessageBox.Show("Selecciona uno");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = ("Procesando");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = ("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = false;
            listBox1.Items.Clear();
            Thread core = new Thread(
                delegate ()
                {
                    asic();
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new MethodInvoker(delegate
                        {
                            listBox1.Items.Add("El proceso a Terminado");
                        }));
                    }
                    if (button4.InvokeRequired)
                    {
                        button4.Invoke(new MethodInvoker(delegate
                        {
                            button4.Enabled = true;
                        }));
                    }
                });
            core.Start();
        }
    }
}
