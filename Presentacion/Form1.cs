using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BotonesAleatorios();
        }
        int labelIndex = 0;
        private void BotonesAleatorios()
        {
            List<int> labelList = new List<int>();

            Random rand = new Random();
            foreach (Button btn in this.Puzzle.Controls)
            {
                while (labelList.Contains(labelIndex))
                    labelIndex = rand.Next(16);

                btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                //btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLight);
                labelList.Add(labelIndex);
            }

        }

        public void Intercambio(Button origen, Button destino)
        {
            if (button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "4" &&
                button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8" &&
                button9.Text == "9" && button10.Text == "10" && button11.Text == "11" && button12.Text == "12" &&
                button13.Text == "13" && button14.Text == "14" && button15.Text == "15" && button16.Text == "16")
            {
                MessageBox.Show("Felicidades, Ganaste");
            }
            String Aux;
            if (origen.Text != "")
            {
                if (destino.Text == "")
                {
                    Aux = origen.Text;
                    origen.Text = "";
                    destino.Text = Aux;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Click");
            Intercambio(button1, button2);
            Intercambio(button1, button5);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Intercambio(button2, button1);
            Intercambio(button2, button3);
            Intercambio(button2, button6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Intercambio(button3, button2);
            Intercambio(button3, button4);
            Intercambio(button3, button7);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Intercambio(button4, button3);
            Intercambio(button4, button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Intercambio(button5, button1);
            Intercambio(button5, button6);
            Intercambio(button5, button9);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Intercambio(button6, button2);
            Intercambio(button6, button5);
            Intercambio(button6, button7);
            Intercambio(button6, button10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Intercambio(button7, button3);
            Intercambio(button7, button6);
            Intercambio(button7, button8);
            Intercambio(button7, button11);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Intercambio(button8, button4);
            Intercambio(button8, button7);
            Intercambio(button8, button12);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Intercambio(button9, button5);
            Intercambio(button9, button10);
            Intercambio(button9, button13);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Intercambio(button10, button6);
            Intercambio(button10, button9);
            Intercambio(button10, button11);
            Intercambio(button10, button14);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Intercambio(button11, button7);
            Intercambio(button11, button10);
            Intercambio(button11, button12);
            Intercambio(button11, button15);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Intercambio(button12, button8);
            Intercambio(button12, button11);
            Intercambio(button12, button16);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Intercambio(button13, button9);
            Intercambio(button13, button14);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Intercambio(button14, button10);
            Intercambio(button14, button13);
            Intercambio(button14, button15);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Intercambio(button15, button11);
            Intercambio(button15, button14);
            Intercambio(button15, button16);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Intercambio(button16, button12);
            Intercambio(button16, button15);
        }

        private void btnNuevoJuego_Click(object sender, EventArgs e)
        {
            BotonesAleatorios();
            Start();
        }

        int seg, min, hor;

        private void timer1_Tick(object sender, EventArgs e)
        {
            seg += 1;
            String segundos = seg.ToString();
            String minutos = min.ToString();
            String horas = hor.ToString();

            if (seg < 10)
            {
                segundos = "0" + seg.ToString();
            }

            if (min < 10)
            {
                minutos = "0" + min.ToString();
            }

            if (hor < 10)
            {
                horas = "0" + hor.ToString();
            }

            labelTime.Text = horas + ":" + minutos + ":" + segundos;

            if (seg == 60)
            {
                min +=1;
                seg = 0;
            }

            if (min == 60)
            {
                hor += 1;
                min = 0;
            }

        }

        public void Stop()
        {
            if (btnStart.Text != "Start")
            {
                if (btnStop.Text == "Stop")
                {
                    timer1.Stop();
                    btnStop.ForeColor = Color.DarkOrange;
                    btnStop.Text = "Resume";
                }
                else
                {
                    timer1.Start();
                    btnStop.ForeColor = Color.RoyalBlue;
                    btnStop.Text = "Stop";
                }
            }
        }

        public void Start()
        {
            if (btnStart.Text == "Start")
            {
                timer1.Start();
                btnStart.ForeColor = Color.ForestGreen;
                btnStop.Enabled = true;
                btnStart.Text = "Restart";
            }
            else
            {
                timer1.Stop();
                seg = 0;
                min = 0;
                hor = 0;
                labelTime.Text = "00:00:00";
                btnStart.ForeColor = Color.ForestGreen;
                btnStop.Enabled = false;
                btnStop.ForeColor = Color.Purple;
                btnStop.Text = "Stop";
                btnStart.Text = "Start";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        //Start --> Forest Green
        //Stop --> Royal Blue
        //Restart --> FireBrick
        //Continue --> Dark Orange
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
