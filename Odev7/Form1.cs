using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
                

        }



        private void resimAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.DefaultExt = ".jpg";
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                String ResminYolu = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(ResminYolu);
            }
            catch { }

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            saveFileDialog1.Title = "Resmi Kaydet";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") //Dosya adı boş değilse kaydedecek.
            {
                // FileStream nesnesi ile kayıtı gerçekleştirecek.
                FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                DosyaAkisi.Close();
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

        }

        private void zoomboyut_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void strechboyut_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoboyut_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerboyut_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void negatifiniAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = 255 - OkunanRenk.R;
                    G = 255 - OkunanRenk.G;
                    B = 255 - OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void ortalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
                    double Toplam = R + G + B;
                    GriDeger = Convert.ToInt16(Toplam / 3);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
                    double Toplam = R + G + B;
                    GriDeger = Convert.ToInt16(0.299 * R + 0.587 * G + 0.114 * B);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void r071G0071BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
                    double Toplam = R + G + B;
                    GriDeger = Convert.ToInt16(0.21 * R + 0.71 * G + 0.071 * B);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void r06G01BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
                    double Toplam = R + G + B;
                    GriDeger = Convert.ToInt16(0.3 * R + 0.6 * G + 0.1 * B);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void parlaklıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Visible = true;
            label1.Visible = true;


            
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;

            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int i = 0, j = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    R = OkunanRenk.R + a;
                    G = OkunanRenk.G + a;
                    B = OkunanRenk.B + a;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
        }

        private void eşiklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;


            label1.Visible = false;
            
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;
           
            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int EsiklemeDegeri = Convert.ToInt32(textBox1.Text);
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    if (OkunanRenk.R >= EsiklemeDegeri)
                        R = 255;
                    else
                        R = 0;
                    if (OkunanRenk.G >= EsiklemeDegeri)
                        G = 255;
                    else
                        G = 0;
                    if (OkunanRenk.B >= EsiklemeDegeri)
                        B = 255;
                    else
                        B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
      
        private void otomatikLineerKontrastArttırmaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    DiziPiksel.Add(OrtalamaRenk);
                }
            }

            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++)
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++)
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }


            //Histogramın ilk 0'dan büyük değerinin kaçıncı sırada olduğunu bulma
            int l = 0;
            int o = 0;

            while (o <= 10) //o<=10 alarak daha iyi net bir resim hedefleniyor
            {
                o = DiziPikselSayilari[l] - 1;
                l++;
            }

            //Histogramın en son 0 olduğu değeri bulma
            o = 0;
            int v = 255;
            while (o <= 10)  ////o<=10 alarak daha iyi net bir resim hedefleniyor
            {
                o = DiziPikselSayilari[v] - 1;
                v--;
            }

            int X1 = l;
            int X2 = v;
            int Y1 = 0;
            int Y2 = 255;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    int Gri = (R + G + B) / 3;

                    //*********** Kontras Formülü***************
                    int X = Gri;
                    int Y = ((((X - X1) * Y2 - Y1)) / (X2 - X1)) + Y1;
                    if (Y > 255) Y = 255;
                    if (Y < 0) Y = 0;
                    DonusenRenk = Color.FromArgb(Y, Y, Y);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Refresh();
            pictureBox2.Image = null;
            pictureBox2.Image = CikisResmi;
        }

        private void renkliResimKontrastArttırmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            label3.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
           
            textBox1.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double C_KontrastSeviyesi = Convert.ToInt32(textBox2.Text);
            double F_KontrastFaktoru = (259 * (C_KontrastSeviyesi + 255)) / (255 * (259 -
            C_KontrastSeviyesi));
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    R = (int)((F_KontrastFaktoru * (R - 128)) + 128);
                    G = (int)((F_KontrastFaktoru * (G - 128)) + 128);
                    B = (int)((F_KontrastFaktoru * (B - 128)) + 128);
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        int a;
        private void taşımaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 10; 
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
        int X1, Y1;

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

           

        }
        int X2, Y2;

        private void küçültmeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            trackBar3.Visible = true;
            label4.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
           
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
           
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int b = trackBar3.Value;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            int R = 0, G = 0, B = 0;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resminin boyutları
            int x2 = 0, y2 = 0; //Çıkış resminin x ve y si olacak.
            int KucultmeKatsayisi = b;
            for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + KucultmeKatsayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + KucultmeKatsayisi)
                {
                    //x ve y de ilerlerken her atlanan pikselleri okuyacak ve ortalama değerini alacak.
                    R = 0; G = 0; B = 0;
                    try //resim sınırının dışına çıkaldığında hata vermesin diye
                    {
                        for (int i = 0; i < KucultmeKatsayisi; i++)
                        {
                            for (int j = 0; j < KucultmeKatsayisi; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x1 + i, y1 + j);
                                R = R + OkunanRenk.R;
                                G = G + OkunanRenk.G;
                                B = B + OkunanRenk.B;
                            }
                        }
                    }
                    catch { }
                    //Renk kanallarının ortalamasını alıyor
                    R = R / (KucultmeKatsayisi * KucultmeKatsayisi);
                    G = G / (KucultmeKatsayisi * KucultmeKatsayisi);
                    B = B / (KucultmeKatsayisi * KucultmeKatsayisi);
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x2, y2, DonusenRenk);
                    y2++;
                }
                x2++;
            }
            pictureBox2.Image = CikisResmi;

        }

        private void büyültmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            trackBar2.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
         
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
           
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            int c = trackBar2.Value;
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int BuyutmeKatsayisi = c;

            int x2 = 0, y2 = 0;
            for (int x1 = 0; x1 < ResimGenisligi; x1++)
            {

                for (int y1 = 0; y1 < ResimYuksekligi; y1++)
                {

                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    for (int i = 0; i < BuyutmeKatsayisi; i++)
                    {
                        for (int j = 0; j < BuyutmeKatsayisi; j++)
                        {
                            x2 = x1 * BuyutmeKatsayisi + i;
                            y2 = y1 * BuyutmeKatsayisi + j;
                            if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                                CikisResmi.SetPixel(x2, y2, OkunanRenk);
                        }
                    }

                }

            }
            pictureBox2.Image = CikisResmi;
        }

        private void aynalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void dereceAynalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek.
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
           
                    x2 = Convert.ToInt16(-x1 + 2 * x0);
                    y2 = Convert.ToInt16(y1);
                   

                   
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void dereceAynalamaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek.
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    x2 = Convert.ToInt16(x1);
                    y2 = Convert.ToInt16(-y1 + 2 * y0);


                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
     
        private void mouseİleÖlçeklendirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 20;
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);

                }

            }
            pictureBox2.Image = CikisResmi;
            Graphics grafik;
            Pen kalem = new Pen(Color.Red, 4);
            pictureBox2.Refresh();


            grafik = pictureBox2.CreateGraphics();
            grafik.DrawRectangle(kalem, ResimGenisligi, ResimYuksekligi, 2, 2);
            grafik.DrawRectangle(kalem, ResimGenisligi, ResimYuksekligi / 2, 2, 2);
            grafik.DrawRectangle(kalem, ResimGenisligi, 0, 2, 2);
            grafik.DrawRectangle(kalem, ResimGenisligi / 2, 0, 2, 2);
            grafik.DrawRectangle(kalem, 0, 0, 2, 2);
            grafik.DrawRectangle(kalem, 0, ResimYuksekligi / 2, 2, 2);
            grafik.DrawRectangle(kalem, 0, ResimYuksekligi, 2, 2);
            grafik.DrawRectangle(kalem, ResimGenisligi / 2, ResimYuksekligi, 2, 2);
            grafik.DrawRectangle(kalem, ResimGenisligi / 2, ResimYuksekligi / 2, 2, 2);
        }

        private void açıİleDöndürmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            label6.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
           
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
       
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = Convert.ToInt16(textBox3.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;

            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    //Döndürme Formülleri
                    x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            Color _OkunanRenk, _DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap _GirisResmi;
            _GirisResmi = CikisResmi;
            int R1, R2, R3, R4, R5, R6, R7, R8, G1, G2, G3, G4, G5, G6, G7, G8, B1, B2, B3, B4, B5, B6, B7, B8;
            int RT, RS, GT, GS, BT, BS;

            for (int x = 1; x < ResimGenisligi - 1; x++)
            {
                for (int y = 1; y < ResimYuksekligi - 1; y++)
                {
                    _OkunanRenk = CikisResmi.GetPixel(x, y);

                    R = _OkunanRenk.R;
                    G = _OkunanRenk.G;
                    B = _OkunanRenk.B;

                    if (R == 0 && G == 0 && B == 0)
                    {


                        _OkunanRenk = CikisResmi.GetPixel(x - 1, y + 1);
                        R1 = _OkunanRenk.R;
                        G1 = _OkunanRenk.G;
                        B1 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x, y + 1);
                        R2 = _OkunanRenk.R;
                        G2 = _OkunanRenk.G;
                        B2 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x + 1, y + 1);
                        R3 = _OkunanRenk.R;
                        G3 = _OkunanRenk.G;
                        B3 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x + 1, y);
                        R4 = _OkunanRenk.R;
                        G4 = _OkunanRenk.G;
                        B4 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x + 1, y - 1);
                        R5 = _OkunanRenk.R;
                        G5 = _OkunanRenk.G;
                        B5 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x, y - 1);
                        R6 = _OkunanRenk.R;
                        G6 = _OkunanRenk.G;
                        B6 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x - 1, y - 1);
                        R7 = _OkunanRenk.R;
                        G7 = _OkunanRenk.G;
                        B7 = _OkunanRenk.B;

                        _OkunanRenk = CikisResmi.GetPixel(x - 1, y);
                        R8 = _OkunanRenk.R;
                        G8 = _OkunanRenk.G;
                        B8 = _OkunanRenk.B;


                        RT = R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8;
                        GT = G1 + G2 + G3 + G4 + G5 + G6 + G7 + G8;
                        BT = B1 + B2 + B3 + B4 + B5 + B6 + B7 + B8;

                        RS = RT / 8;
                        GS = GT / 8;
                        BS = BT / 8;

                        _DonusenRenk = Color.FromArgb(RS, GS, BS);
                        CikisResmi.SetPixel(x, y, _DonusenRenk);


                    }

                }
            }

            pictureBox2.Image = CikisResmi;
        }

        private void kırpmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 30;
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            int i = 0, j = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void meanFilterBoxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            trackBar4.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
           
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
           
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = trackBar4.Value;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R;
                            toplamG = toplamG + OkunanRenk.G;
                            toplamB = toplamB + OkunanRenk.B;
                        }
                    }
                    ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                    ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                    ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void medyanFilitresiMedianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar5.Visible = true;
            label8.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 0;
            try
            {
                SablonBoyutu = trackBar5.Value;
            }
            catch
            {
                SablonBoyutu = 3;
            }
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int[] R = new int[ElemanSayisi];
            int[] G = new int[ElemanSayisi];
            int[] B = new int[ElemanSayisi];
            int[] Gri = new int[ElemanSayisi];
            int x, y, i, j;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {

                    int k = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            R[k] = OkunanRenk.R;
                            G[k] = OkunanRenk.G;
                            B[k] = OkunanRenk.B;
                            Gri[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114);
                            k++;
                        }
                    }
                    int GeciciSayi = 0;
                    for (i = 0; i < ElemanSayisi; i++)
                    {
                        for (j = i + 1; j < ElemanSayisi; j++)
                        {
                            if (Gri[j] < Gri[i])
                            {
                                GeciciSayi = Gri[i];
                                Gri[i] = Gri[j];
                                Gri[j] = GeciciSayi;
                                GeciciSayi = R[i];
                                R[i] = R[j];
                                R[j] = GeciciSayi;
                                GeciciSayi = G[i];
                                G[i] = G[j];
                                G[j] = GeciciSayi;
                                GeciciSayi = B[i];
                                B[i] = B[j];
                                B[j] = GeciciSayi;
                            }
                        }
                    }
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R[(ElemanSayisi - 1) / 2], G[(ElemanSayisi - 1) /
                   2], B[(ElemanSayisi - 1) / 2]));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void bulanıklaştırmaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gaussFilitresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 5; //Çekirdek matrisin boyutu
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int[] Matris = { 1, 4, 7, 4, 1, 4, 20, 33, 20, 4, 7, 33, 55, 33, 7, 4, 20, 33, 20, 4, 1, 4, 7, 4, 1 };
            int MatrisToplami = 1 + 4 + 7 + 4 + 1 + 4 + 20 + 33 + 20 + 4 + 7 + 33 + 55 + 33 + 7 + 4 + 20 +
             33 + 20 + 4 + 1 + 4 + 7 + 4 + 1;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) 
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                   
                    int k = 0; 
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    ortalamaR = toplamR / MatrisToplami;
                    ortalamaG = toplamG / MatrisToplami;
                    ortalamaB = toplamB / MatrisToplami;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void seçiliAlanıBulanıklaştırmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 40;

            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            int i = 0, j = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void kenarGörüntüsüİleNetleştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap OrjinalResim = new Bitmap(pictureBox1.Image);

            Bitmap BulanikResim = MeanFiltresi();
            Bitmap KenarGoruntusu = OrjianalResimdenBulanikResmiCikarma(OrjinalResim,
           BulanikResim);
            Bitmap NetlesmisResim = KenarGoruntusuIleOrjinalResmiBirlestir(OrjinalResim,
           KenarGoruntusu);
            pictureBox2.Image = NetlesmisResim;
        }

        private void konvülüsyonMatrisiİleNetleştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami;
                    G = toplamG / MatrisToplami;
                    B = toplamB / MatrisToplami;
                    //===========================================================
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    //===========================================================
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            int X2 = e.X;
            int Y2 = e.Y;
            // TAŞIMA*****
           if (a==10)
            {
                
                Color OkunanRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width;
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                double x2 = 0, y2 = 0;
                int Tx = X2-X1;
                int Ty = Y2-Y1;
                for (int x1 = 0; x1 < (ResimGenisligi); x1++)
                {
                    for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x1, y1);
                        x2 = x1 + Tx;
                        y2 = y1 + Ty;
                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                            CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                    }
                }
                pictureBox2.Image = CikisResmi;
            }
           if(a==20)
            {
                Color _OkunanRenk;
                Bitmap _GirisResmi, _CikisResmi;
                _GirisResmi = new Bitmap(pictureBox1.Image);
                int _ResimGenisligi = _GirisResmi.Width;
                int _ResimYuksekligi = _GirisResmi.Height;
                _CikisResmi = new Bitmap(_ResimGenisligi, _ResimYuksekligi);
                if (X1 > _ResimGenisligi - 10 && X1 < _ResimGenisligi + 10 && Y1 > _ResimYuksekligi - 10 && Y1 < _ResimYuksekligi + 10)
                {

                    double KucultmeKatsayisi = X2 / X1;
                    int ks = Convert.ToInt32(KucultmeKatsayisi);

                    if (ks > 0)
                    {
                        Color OkunanRenk;
                        Bitmap GirisResmi, CikisResmi;
                        GirisResmi = new Bitmap(pictureBox1.Image);
                        int ResimGenisligi = GirisResmi.Width * ks;
                        int ResimYuksekligi = GirisResmi.Height * ks;
                        CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


                        int x2 = 0, y2 = 0;
                        for (int x1 = 0; x1 < GirisResmi.Width; x1++)
                        {

                            for (int y1 = 0; y1 < GirisResmi.Height; y1++)
                            {

                                OkunanRenk = GirisResmi.GetPixel(x1, y1);

                                for (int i = 0; i < ks; i++)
                                {
                                    for (int j = 0; j < ks; j++)
                                    {
                                        x2 = x1 * ks + i;
                                        y2 = y1 * ks + j;

                                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                                            CikisResmi.SetPixel(x2, y2, OkunanRenk);
                                    }
                                }
                            }

                        }
                        pictureBox2.Image = CikisResmi;
                    }
                    else
                    {
                        ks = X1 / X2;
                        Color OkunanRenk;
                        Bitmap GirisResmi, CikisResmi;
                        GirisResmi = new Bitmap(pictureBox1.Image);
                        int ResimGenisligi = GirisResmi.Width;
                        int ResimYuksekligi = GirisResmi.Height;
                        CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

                        int x2 = 0, y2 = 0;

                        for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + ks)
                        {
                            y2 = 0;
                            for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + ks)
                            {

                                OkunanRenk = GirisResmi.GetPixel(x1, y1);

                                CikisResmi.SetPixel(x2, y2, OkunanRenk);
                                y2++;
                            }
                            x2++;
                        }
                        pictureBox2.Image = CikisResmi;
                    }
                }
                else if (X1 > _ResimGenisligi / 2 - 10 && X1 < _ResimGenisligi / 2 + 10 && Y1 > _ResimYuksekligi - 10 && Y1 < _ResimYuksekligi + 10)
                {

                    double ks = Y2 / Y1;
                    int k = Convert.ToInt32(ks);
                    Color OkunanRenk;
                    Bitmap GirisResmi, CikisResmi;
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    int ResimGenisligi = GirisResmi.Width;
                    int ResimYuksekligi = GirisResmi.Height * k;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


                    int x2 = 0, y2 = 0;
                    for (int x1 = 0; x1 < GirisResmi.Width; x1++)
                    {

                        for (int y1 = 0; y1 < GirisResmi.Height; y1++)
                        {

                            OkunanRenk = GirisResmi.GetPixel(x1, y1);

                            for (int i = 0; i < k; i++)
                            {
                                for (int j = 0; j < k; j++)
                                {
                                    x2 = x1 + i;
                                    y2 = y1 * k + j;

                                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                                        CikisResmi.SetPixel(x2, y2, OkunanRenk);
                                }
                            }
                        }

                    }
                    pictureBox2.Image = CikisResmi;
                }
                else if (X1 > _ResimGenisligi - 10 && X1 < _ResimGenisligi + 10 && Y1 > _ResimYuksekligi / 2 - 10 && Y1 < _ResimYuksekligi / 2 + 10)
                {

                    double ks = X2 / X1;
                    int k = Convert.ToInt32(ks);
                    Color OkunanRenk;
                    Bitmap GirisResmi, CikisResmi;
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    int ResimGenisligi = GirisResmi.Width * k;
                    int ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


                    int x2 = 0, y2 = 0;
                    for (int x1 = 0; x1 < GirisResmi.Width; x1++)
                    {

                        for (int y1 = 0; y1 < GirisResmi.Height; y1++)
                        {

                            OkunanRenk = GirisResmi.GetPixel(x1, y1);

                            for (int i = 0; i < k; i++)
                            {
                                for (int j = 0; j < k; j++)
                                {
                                    x2 = x1 * k + i;
                                    y2 = y1 + j;

                                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                                        CikisResmi.SetPixel(x2, y2, OkunanRenk);
                                }
                            }
                        }

                    }
                    pictureBox2.Image = CikisResmi;
                }
            }
           if(a==30)
            {
                Color OkunanRenk, DonusenRenk;
                int R = 0, G = 0, B = 0;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width;
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        if (X2 <= x && X1 >= x && Y1 >= y && Y2 <= y)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x, y);
                            R = OkunanRenk.R;
                            G = OkunanRenk.G;
                            B = OkunanRenk.B;
                            DonusenRenk = Color.FromArgb(R, G, B);
                            CikisResmi.SetPixel(x, y, DonusenRenk);
                        }

                    }
                }
                pictureBox2.Image = CikisResmi;
            }
           if (a == 40)
            {
                int R = 0;
                int G = 0;
                int B = 0;
                Color OkunanRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int ResimGenisligi = GirisResmi.Width;
                int ResimYuksekligi = GirisResmi.Height;
                CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                int SablonBoyutu = 7;
                int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
                for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
                {
                    for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                    {
                        if (x > X2 && x < X1 && y > Y2 && y < Y1)
                        {
                            toplamR = 0;
                            toplamG = 0;
                            toplamB = 0;
                            for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                            {
                                for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                                {
                                    OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                                    toplamR = toplamR + OkunanRenk.R;
                                    toplamG = toplamG + OkunanRenk.G;
                                    toplamB = toplamB + OkunanRenk.B;
                                }
                            }
                            ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                            ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                            ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);

                            CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                        }
                        else
                        {
                            OkunanRenk = GirisResmi.GetPixel(x, y);
                            R = OkunanRenk.R;
                            G = OkunanRenk.G;
                            B = OkunanRenk.B;
                            CikisResmi.SetPixel(x, y, Color.FromArgb(R, G, B));
                        }

                    }
                }
                pictureBox2.Image = CikisResmi;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            X1 = e.X;
            Y1 = e.Y;
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fontDialog1.ShowDialog();
            colorDialog1.ShowDialog();

            label9.Visible = true;
            textBox4.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

          
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;


            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap _GirisResmi, _CikisResmi;
            _GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = _GirisResmi.Width;
            int ResimYuksekligi = _GirisResmi.Height;
            _CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int i = 0, j = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = _GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    _CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = _CikisResmi;


        }
        
        int X11 = 0;
        int Y11 = 0;
      
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
          
            
                X11 = e.X;
                Y11 = e.Y;
             
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            Bitmap CikisResmi = new Bitmap(GirisResmi);
            string Metin1 = textBox4.Text;

            Point BirinciKonum = new Point(X11, Y11);

            Graphics graphics = Graphics.FromImage(CikisResmi);
            Font FontTipi = fontDialog1.Font;
            Color renk = colorDialog1.Color;
            SolidBrush brush = new SolidBrush(renk);
            graphics.DrawString(Metin1, FontTipi, brush, BirinciKonum);

            pictureBox2.Image = CikisResmi;
        }



        public Bitmap OrjianalResimdenBulanikResmiCikarma(Bitmap OrjinalResim, Bitmap BulanikResim)
        {
            Color OkunanRenk1, OkunanRenk2, DonusenRenk;
            Bitmap CikisResmi;
            int ResimGenisligi = OrjinalResim.Width;
            int ResimYuksekligi = OrjinalResim.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int R, G, B;
            double Olcekleme = 2;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk1 = OrjinalResim.GetPixel(x, y);
                    OkunanRenk2 = BulanikResim.GetPixel(x, y);
                    R = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.R - OkunanRenk2.R));
                    G = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.G - OkunanRenk2.G));
                    B = Convert.ToInt16(Olcekleme * Math.Abs(OkunanRenk1.B - OkunanRenk2.B));

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            return CikisResmi;
        }

        private void karikatürEfektiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;

            int KomsularinEnKucukEtiketDegeri = 0;

            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            int PikselSayisi = ResimGenisligi * ResimYuksekligi;

            GirisResmi = ResmiGriTonaDonustur(GirisResmi); //Resmi önce gri tona dönüştürüyor.
            GirisResmi = _ResmiEsiklemeYap(GirisResmi); //Resmi 128 ile eşikleme siyah beyaz yapıyor.
            pictureBox1.Image = GirisResmi; //Resmin son halini gösteriyor. 

            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


            int x, y, i, j, EtiketNo = 0;

            int[,] EtiketNumarasi = new int[ResimGenisligi, ResimYuksekligi]; //Resmin her pikselinin etiket numarası tutulacak.

            //Tüm piksellerin Etiket numarasını başlangıçta 0 olarak atayacak. Siyah ve beyaz farketmez. Zaten ileride beyaz olanlara numara verilecek.
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    EtiketNumarasi[x, y] = 0;
                }
            }

            int IlkDeger = 0, SonDeger = 0;
            bool DegisimVar = false; //Etiket numaralarında değişim olmayana kadar dönmesi için sonsuz döngüyü kontrol edecek. 
            do //etiket numaralarında değişim kalmayana kadar dönecek.
            {
                DegisimVar = false;
                //------------------------- Resmi tarıyor ----------------------------
                for (y = 1; y < ResimYuksekligi - 1; y++) //Resmin 1 piksel içerisinden başlayıp, bitirecek. Çünkü çekirdek şablon en dış kenardan başlamalı.
                {
                    for (x = 1; x < ResimGenisligi - 1; x++)
                    {
                        //Resim siyah beyaz olduğu için tek kanala bakmak yeterli olacak. Sıradaki piksel beyaz ise işlem yap. Beyaz olduğu 255 yerine 128 kullanarak yapıldı.
                        if (GirisResmi.GetPixel(x, y).R > 128)
                        {

                            //işlem öncesi ele alınan pikselin etiket değerini okuyacak. İşlemler bittikten sonra bu değer değişirse, sonsuz döngü için işlem yapılmış demektir.
                            IlkDeger = EtiketNumarasi[x, y];

                            //Komşular arasında en küçük etiket numarasını bulacak.
                            KomsularinEnKucukEtiketDegeri = 0;
                            for (j = -1; j <= 1; j++) //Çekirdek şablon 3x3 lük bir matris. Dolayısı ile x,y nin -1 den başlayıp +1 ne kadar yer kaplar.
                            {
                                for (i = -1; i <= 1; i++)
                                {

                                    if (EtiketNumarasi[x + i, y + j] != 0 && KomsularinEnKucukEtiketDegeri == 0)  //hücrenin etiketi varsa ve daha hiç en küçük atanmadı ise ilk okuduğu bu değeri en küçük olarak atayacak.
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                    else if (EtiketNumarasi[x + i, y + j] < KomsularinEnKucukEtiketDegeri && EtiketNumarasi[x + i, y + j] != 0 && KomsularinEnKucukEtiketDegeri != 0)  //En küçük değer ve okunan hücreye etiket atanmışsa, içindeki değer en küçük değerden küçük ise  o zaman en küçük o hücrenin değeri olmalıdır. 
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                }
                            }

                            if (KomsularinEnKucukEtiketDegeri != 0) //Beyaz komşu buldu ve içlerinde en küçük etiket değerine sahip numara da var.  O zaman orta piksele o numarayı ata.
                            {
                                EtiketNumarasi[x, y] = KomsularinEnKucukEtiketDegeri;
                            }
                            else if (KomsularinEnKucukEtiketDegeri == 0) //Komşuların hiç birinde etiket numarası yoksa o zaman yeni bir numara ata
                            {
                                EtiketNo = EtiketNo + 1;
                                EtiketNumarasi[x, y] = EtiketNo;
                            }

                            SonDeger = EtiketNumarasi[x, y]; //İşlem öncesi ve işlem sonrası değerler aynı ise ve butün piksellerde hep aynı olursa artık değişim yok demektir.

                            if (IlkDeger != SonDeger)
                                DegisimVar = true;

                        }

                    }
                }
            } while (DegisimVar == true);


            // Etiket değerine bağlı resmi renklendirecek-----------------------
            // Önce etiket numaralarını diziye çekecek. 
            int[] DiziEtiket = new int[PikselSayisi];
            i = 0;
            for (x = 1; x < ResimGenisligi - 1; x++)
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    i++;
                    DiziEtiket[i] = EtiketNumarasi[x, y];
                }
            }

            //Dizideki etiket numaralarını sıralıyor. Hazır fonksiyon kullanıyor. 
            Array.Sort(DiziEtiket);

            //Tekrar eden etiket numaraarını çıkarıyor. Hazır fonksiyon kullanıyor.
            int[] TekrarsizEtiketNumaralari = DiziEtiket.Distinct().ToArray();

            int[] RenkDizisi = new int[TekrarsizEtiketNumaralari.Length];

            for (j = 0; j < TekrarsizEtiketNumaralari.Length; j++)
            {
                RenkDizisi[j] = TekrarsizEtiketNumaralari[j]; //sıradaki ilk renge, ait olacağı etiketin kaç numara olacağını atıyor. 
            }

            int RenkSayisi = RenkDizisi.Length;

            Color[] Renkler = new Color[RenkSayisi];
            Random Rastgele = new Random();
            int Kirmizi, Yesil, Mavi;

            for (int r = 0; r < RenkSayisi; r++) //sonraki renkler.
            {
                Kirmizi = Rastgele.Next(5, 25) * 10; //Açık renkler elde etmek ve 10 katları şeklinde olmasını sağlıyor. yani 150-250 arasındaki sayıları atıyor.
                Yesil = Rastgele.Next(5, 25) * 10;
                Mavi = Rastgele.Next(5, 25) * 10;

                Renkler[r] = Color.FromArgb(Kirmizi, Yesil, Mavi);
            }

            //Color[] Renkler= { Color.Black, Color.Blue, Color.Red, Color.Orange, Color.LightPink, Color.LightYellow, Color.LimeGreen, Color.MediumPurple, Color.Olive, Color.Magenta, Color.Maroon, Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.LightBlue, Color.Azure, Color.White  };

            for (x = 1; x < ResimGenisligi - 1; x++) //Resmin 1 piksel içerisinden başlayıp, bitirecek. Çünkü çekirdek şablon en dış kenardan başlamalı.
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    int RenkSiraNo = Array.IndexOf(RenkDizisi, EtiketNumarasi[x, y]); //Dikkat: önemli bir komut. Dizinin değerinden sıra numarasını alıyor. int[] array = { 2, 3, 5, 7, 11, 13 }; int index = Array.IndexOf(array, 11); // returns 4

                    if (GirisResmi.GetPixel(x, y).R < 128) //Eğer bu pikselin rengi siyah ise aynı pikselin CikisResmi resmide siyah yapılacak.
                    {
                        CikisResmi.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, Renkler[RenkSiraNo]);
                    }
                }
            }



            pictureBox2.Image = CikisResmi;
        }

      
        
        public Bitmap KenarGoruntusuIleOrjinalResmiBirlestir(Bitmap OrjinalResim, Bitmap KenarGoruntusu)
        {
            Color OkunanRenk1, OkunanRenk2, DonusenRenk;
            Bitmap CikisResmi;
            int ResimGenisligi = OrjinalResim.Width;
            int ResimYuksekligi = OrjinalResim.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int R, G, B;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk1 = OrjinalResim.GetPixel(x, y);
                    OkunanRenk2 = KenarGoruntusu.GetPixel(x, y);
                    R = OkunanRenk1.R + OkunanRenk2.R;
                    G = OkunanRenk1.G + OkunanRenk2.G;
                    B = OkunanRenk1.B + OkunanRenk2.B;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                   
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            return CikisResmi;
        }


        public Bitmap MeanFiltresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R;
                            toplamG = toplamG + OkunanRenk.G;
                            toplamB = toplamB + OkunanRenk.B;
                        }
                    }
                    ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                    ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                    ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            return CikisResmi;
        }

        private void ikiResmiBirleştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            trackBar6.Visible = true;


            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
            trackBar7.Visible = false;
           
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;


            try
            {
                openFileDialog1.DefaultExt = ".jpg";
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                String ResminYolu = openFileDialog1.FileName;
                pictureBox2
                    .Image = Image.FromFile(ResminYolu);
            }
            catch { }

        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double d = trackBar6.Value;
            d = d / 15;
            double dd = 1 - d;

            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = Resim1.Width;
            int ResimYuksekligi = Resim1.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Color Renk1, Renk2;
            int x, y;
            int R = 0, G = 0, B = 0;
            for (x = 0; x < ResimGenisligi; x++) 
 {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
   
                    if (Renk2.R > 20 && Renk2.G > 20 && Renk2.B > 20)
                    {
                        R = Convert.ToInt16(Renk1.R * d + Renk2.R * dd);
                        G = Convert.ToInt16(Renk1.G * d + Renk2.G * dd);
                        B = Convert.ToInt16(Renk1.B * d + Renk2.B * dd);
                    }
                    else
                    {
                        R = Renk1.R;
                        G = Renk1.G;
                        B = Renk1.B;
                    }
                    
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void kırmızıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            trackBar7.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            
            label12.Visible = false;
            label13.Visible = false;

            trackBar9.Visible = false;
            trackBar8.Visible = false;
           
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double u = trackBar7.Value;
            //double uu = (1 - u) / 2;

            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
           
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
            
                    R = R * u;
                    
                    if (R > 255)
                        R = 255;
                    //G = G * uu;
                    //B = B * uu;
                    DonusenRenk = Color.FromArgb((int)R, (int)G, (int)B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void yeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            trackBar8.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            
            label13.Visible = false;

            trackBar9.Visible = false;
          
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            double u = trackBar8.Value;
            

            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    G = G * u;

                    if (G > 255)
                        G = 255;
                    
                    DonusenRenk = Color.FromArgb((int)R, (int)G, (int)B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
            trackBar9.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
           

           
            trackBar8.Visible = false;
            trackBar7.Visible = false;
            trackBar6.Visible = false;
            trackBar5.Visible = false;
            trackBar4.Visible = false;
            trackBar3.Visible = false;
            trackBar2.Visible = false;
            trackBar1.Visible = false;

            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            double u = trackBar9.Value;


            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    B = B * u;

                    if (B > 255)
                        B = 255;

                    DonusenRenk = Color.FromArgb((int)R, (int)G, (int)B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void resmiSolaTaşıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
             int i = 0, j = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox1.Image = CikisResmi;

        }

        private void griToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void kenarBulmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmiXY, CikisResmiX, CikisResmiY;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmiX = new Bitmap(ResimGenisligi, ResimYuksekligi);
            CikisResmiY = new Bitmap(ResimGenisligi, ResimYuksekligi);
            CikisResmiXY = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y;
            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) 
 {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = GirisResmi.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
          
                    int Gx = Math.Abs(-P1 + P3 - 2 * P4 + 2 * P6 - P7 + P9); 
                    int Gy = Math.Abs(P1 + 2 * P2 + P3 - P7 - 2 * P8 - P9); 
                    int Gxy = Gx + Gy;
                    if (Gx > 255)
                        Gx = 255;as
                    if (Gy > 255)
                        Gy = 255;
                    if (Gxy > 255)
                        Gxy = 255;

                    CikisResmiX.SetPixel(x, y, Color.FromArgb(Gx, Gx, Gx));
                    CikisResmiY.SetPixel(x, y, Color.FromArgb(Gy, Gy, Gy));
                    CikisResmiXY.SetPixel(x, y, Color.FromArgb(Gxy, Gxy, Gxy));
                }
            }
            pictureBox2.Image = CikisResmiXY;
        }

        public Bitmap ResmiGriTonaDonustur(Bitmap GirisResmi)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
          
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;

           
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int i = 0, j = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    
                    int GriDegeri = Convert.ToInt16(OkunanRenk.R * 0.21 + OkunanRenk.G * 0.71 + OkunanRenk.B * 0.071); 

                    R = GriDegeri;
                    G = GriDegeri;
                    B = GriDegeri;
                    DonusenRenk = Color.FromArgb(R, G, B);

                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }


            return CikisResmi;
        }

        public Bitmap _ResmiEsiklemeYap(Bitmap GirisResmi)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk;
          

            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);


            int EsikDegeri = 128;

            int i = 0, j = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    if (OkunanRenk.R >= EsikDegeri)
                        R = 255;
                    else
                        R = 0;

                    if (OkunanRenk.G >= EsikDegeri)
                        G = 255;
                    else
                        G = 0;

                    if (OkunanRenk.B >= EsikDegeri)
                        B = 255;
                    else
                        B = 0;

                    Color DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }

            return CikisResmi;
        }


    }
}