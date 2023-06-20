using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Gider_Hesaplayici
{
    public partial class FormKazanc : Form
    {
        public FormKazanc()
        {
            InitializeComponent();
        }

        string kazanc, tarih, sonuc;

        private void FormKazanc_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kazanc = textBox1.Text;
            tarih = dateTimePicker1.Text;
            sonuc = kazanc + ";" + tarih;

            StreamWriter sw = new StreamWriter("kazanc.txt", true, Encoding.Default);
            sw.WriteLine(sonuc);
            sw.Close();

            textBox1.Clear();
            MessageBox.Show("Para hesabınıza yüklendi");
        }
    }
}
