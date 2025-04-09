using ConsoleApplication6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kohenen
{
    public partial class Form1 : Form
    {
        Siec siec;

        public Form1()
        {
            siec = new Siec(200,200);
            InitializeComponent();
            pictureBox1.BackgroundImage = new Bitmap(siec.AktualnaMapa(), new Size(pictureBox1.Width, pictureBox1.Height));
            List<Color> kolory = new List<Color>();
            kolory.Add(Color.Red);
            kolory.Add(Color.Yellow);
            kolory.Add(Color.Blue);
            kolory.Add(Color.Orange);
            kolory.Add(Color.Pink);
            kolory.Add(Color.Gray);
            kolory.Add(Color.Green);

            siec.Start(kolory, 1000);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int iterator = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iterator > 200)
            {
                timer1.Enabled = false;
            }
            siec.Epoka();
            pictureBox1.BackgroundImage = new Bitmap(siec.AktualnaMapa(), new Size(pictureBox1.Width, pictureBox1.Height));
            iterator++;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            iterator = 0;
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color tmp = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            pictureBox1.BackgroundImage = new Bitmap(siec.odpytanieSieci(tmp), new Size(pictureBox1.Width, pictureBox1.Height));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = new Bitmap(siec.AktualnaMapa(), new Size(pictureBox1.Width, pictureBox1.Height));

        }
    }
}
