using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] sayilar = new int[9, 9];
        public void kutulariolustur()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Height = 30;
                    tb.Width = 30;
                    tb.Left = kutuleft;
                    tb.Top = kututop;
                    tb.Name = "tb" + i + j;
                    this.Controls.Add(tb);
                    kutuleft += 50;
                }
                kutuleft = 20;
                kututop += 50;
            }
        }
        int kutuleft = 20;
        int kututop = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            kutulariolustur();
        }
        Random rnd = new Random();
        public void kutularasayilaridoldur()
        {
            int zorluk = comboBox1.SelectedIndex + 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox tb = (TextBox)this.Controls.Find("tb" + i + j, false)[0];
                    if (rnd.Next(zorluk) % 5 == 0) tb.Text = sayilar[i, j].ToString();
                    else tb.Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sayilar = new int[,] { { 9, 8, 5, 4, 2, 1, 7, 3, 6 }, { 7, 2, 4, 6, 3, 8, 5, 1, 9 }, { 1, 3, 6, 9, 5, 7, 8, 4, 2 }, { 6, 7, 3, 5, 4, 2, 1, 9, 8 }, { 4, 1, 2, 8, 7, 9, 6, 5, 3 }, { 5, 9, 8, 1, 6, 3, 4, 2, 7 }, { 3, 6, 7, 2, 1, 5, 9, 8, 4 }, { 8, 4, 1, 3, 9, 6, 2, 7, 5 }, { 2, 5, 9, 7, 8, 4, 3, 6, 1 } };
            kutularasayilaridoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool yanlismi = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox tb = (TextBox)this.Controls.Find("tb" + i + j, false)[0];
                    if (tb.Text != sayilar[i, j].ToString())
                        yanlismi = true;
                }
            }
            if (yanlismi == false)
                MessageBox.Show("Tebrikler");
            else
                MessageBox.Show("Yanlış ya da coş sayı var");
        }
    }
}
