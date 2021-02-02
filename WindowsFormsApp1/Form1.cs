using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Dal;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Kontrol
            if (string.IsNullOrEmpty(textBox1.Text.Trim())) return;
            if (string.IsNullOrEmpty(textBox2.Text.Trim())) return;
            if (string.IsNullOrEmpty(textBox3.Text.Trim())) return;

            #endregion

            var faturano = textBox1.Text.Trim();

            #region Yıl Bilgisi Al
            int.TryParse(textBox2.Text.Trim(), out int yil);
            if (yil == 0) return;
            #endregion

            #region Müşteri No Bilgisi Al
            int.TryParse(textBox3.Text.Trim(), out int musteriNo);
            if (musteriNo == 0) return;
            #endregion


            using (var db = new UGM_ERPEntities())
            {
                var liste = db.Assan_Fatura_Text(faturano, yil, musteriNo).ToList();
                if (liste.Count > 0)
                {
                    foreach (var item in liste)
                    {
                        textBox4.Text += item + Environment.NewLine;
                    }



                    string YeniMetin = textBox4.Text;
                    string Dosyaadi = faturano + ".txt";
                    string DosyaAdres = System.IO.Path.Combine(@"C:\\", Dosyaadi);
                    System.IO.File.AppendAllText(DosyaAdres,YeniMetin);
                }
            }
        }
    }
}
