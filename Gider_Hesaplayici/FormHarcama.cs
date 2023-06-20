using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Gider_Hesaplayici
{
    public partial class FormHarcama : Form
    {
        public FormHarcama()
        {
            InitializeComponent();
        }

        string tur, tarih, gider, sonuc, turler;

        private void FormHarcama_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain a = new FormMain();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain a = new FormMain();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tur = comboBox1.Text;
            tarih = dateTimePicker1.Text;
            gider = textBox1.Text;
            sonuc = tur + ";" + tarih + ";" + gider;

            StreamWriter sw = new StreamWriter("rapor.txt", true, Encoding.Default);
            sw.WriteLine(sonuc);
            sw.Close();

            textBox1.Clear();
            MessageBox.Show("Gider Kaydedildi");
        }

        private void harcama_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("turler.txt", Encoding.Default);
            while ((turler = sr.ReadLine()) != null)
            {
                comboBox1.Items.Add(turler);
            }
            sr.Close();
        }
    }
}
