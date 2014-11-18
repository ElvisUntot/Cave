using System;
using System.Windows.Forms;

namespace Cave
{
    public partial class Form1 : Form
    {
        private char[,] world = new char[100, 100];
        private int x = 100;
        private int y = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < y; ii++)
                {
                    if (i == 0 || i == x - 1 || ii == 0 || ii == y - 1)
                    {
                        char fill = ' ';
                        if (checkBox1.Checked == true) { fill = '#'; } else { fill = ' '; }
                        world[i, ii] = fill;
                    }
                    else
                    {
                        int bb = random.Next(0, 100);
                        if (bb > Convert.ToInt32(textBox2.Text))
                        {
                            world[i, ii] = '#';
                        }
                        else
                        {
                            world[i, ii] = ' ';
                        }
                    }
                }
            }

            string s = "";
            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < y; ii++)
                {
                    s = s + world[i, ii];
                }
                s = s + Environment.NewLine;
            }
            textBox1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < y; ii++)
                {
                    if (i == 0 || i == x - 1 || ii == 0 || ii == y - 1)
                    {
                        //nix passiert hier, die aussenwände bleiben zu
                    }
                    else
                    {
                        int counter = 0;
                        if (world[i, ii] == '#') { counter++; }
                        if (world[i + 1, ii] == '#') { counter++; }
                        if (world[i + 1, ii - 1] == '#') { counter++; }
                        if (world[i, ii - 1] == '#') { counter++; }
                        if (world[i - 1, ii - 1] == '#') { counter++; }
                        if (world[i - 1, ii] == '#') { counter++; }
                        if (world[i - 1, ii + 1] == '#') { counter++; }
                        if (world[i, ii + 1] == '#') { counter++; }
                        if (world[i + 1, ii + 1] == '#') { counter++; }

                        if (counter > 4) { world[i, ii] = '#'; } else { world[i, ii] = ' '; }
                    }
                }
            }

            string s = "";
            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < y; ii++)
                {
                    s = s + world[i, ii];
                }
                s = s + Environment.NewLine;
            }
            textBox1.Text = s;
        }
    }
}