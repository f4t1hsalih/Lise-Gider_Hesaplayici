using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Gider_Hesaplayici
{
    public partial class FormRapor : Form
    {
        public FormRapor()
        {
            InitializeComponent();
        }

        double toplamgider, gider, eldekalan, toplamkazanc;
        string tur, st;

        private void FormRapor_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }

        private void rapor_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("rapor.txt", Encoding.Default);
            while (!sr.EndOfStream)
            {
                string[] rapor = sr.ReadLine().Split(';');
                gider = double.Parse(rapor[2]);
                toplamgider += gider;
            }
            sr.Close();
            label3.Text = toplamgider.ToString() + " ₺";

            StreamReader sr1 = new StreamReader("turler.txt", Encoding.Default);
            while (!sr1.EndOfStream)
            {
                tur = sr1.ReadLine();
                double toplam = 0;
                StreamReader sr2 = new StreamReader("rapor.txt", Encoding.Default);
                while (!sr2.EndOfStream)
                {
                    st = sr2.ReadLine();
                    string[] bilgi = st.Split(';');

                    if (tur == bilgi[0])
                    {
                        toplam += double.Parse(bilgi[2]);
                    }
                }
                sr2.Close();

                listBox1.Items.Add(tur + " = " + toplam.ToString());
            }
            sr1.Close();

            StreamReader sr3 = new StreamReader("kazanc.txt", Encoding.Default);
            while (!sr3.EndOfStream)
            {
                st = sr3.ReadLine();
                string[] kazanç = st.Split(';');
                toplamkazanc += double.Parse(kazanç[0]);
            }
            sr3.Close();

            eldekalan = toplamkazanc - toplamgider;
            label5.Text = toplamkazanc.ToString() + " ₺";
            label7.Text = eldekalan.ToString() + " ₺";
        }
    }
}
