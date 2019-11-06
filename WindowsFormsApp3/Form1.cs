﻿using ISS.BLL;
using ISS.DAL;
using ISS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1(Yonetici yoneten)
        {
           
            InitializeComponent();
            TXTYONETEN.Text = yoneten.saglayici_mail+'('+yoneten.saglayici_sirket+')';
        }
      
        
        private void button1_Click(object sender, EventArgs e)
        {
            var paket = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            var taahut = groupBox2.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Checked);
            Musteri mstr = new Musteri();
            mstr.musteri_ad = textBox1.Text;
            mstr.musteri_adres = textBox2.Text;
            mstr.musteri_tel = maskedTextBox1.Text;
            mstr.musteri_paket = paket.Text;
            mstr.musteri_mail = "testmail";
            mstr.musteri_sifre = "testsifre";

            OgrenciBLL bll = new OgrenciBLL();
            bll.Musteri_Ekle(mstr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Helper hlpme = new Helper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MusteriAra mara = new MusteriAra(this);
            mara.Show();
        }

       
    }
}
