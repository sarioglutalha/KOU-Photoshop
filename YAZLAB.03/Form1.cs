using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAZLAB._03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int[,] red = new int[1080,1080];
        int[,] green = new int[1080,1080];
        int[,] blue = new int[1080,1080];
        Color[,,] back = new Color[20,1080,1080];
        int i, j, sayac=0;
        Color r;

        OpenFileDialog dialog = new OpenFileDialog();
        SaveFileDialog safe = new SaveFileDialog();

        public void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 100;
            trackBar2.Minimum = 100;
            trackBar1.Maximum = 2000;
            trackBar2.Maximum = 2000;
            hScrollBar1.Minimum = 0;
            hScrollBar2.Minimum = 0;
            hScrollBar3.Minimum = 0;

            hScrollBar1.Maximum = 255;
            hScrollBar2.Maximum = 255;
            hScrollBar3.Maximum = 255;

            progressBar1.Style = ProgressBarStyle.Continuous; 

            panel5.AutoScroll = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            
            }
        public void Geri(Bitmap bmp)
        {
            for (i = 0; i <= bmp.Width - 1; i++)
            {
                for (j = 0; j <= bmp.Height - 1; j++)
                {
                    r = bmp.GetPixel(i, j);
                    back[sayac, i, j] = r;
                }
            }
        }

        public void Menu2_Click(object sender, EventArgs e)
        {
            //NEW FILE(+)

            dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void Menu3_Click(object sender, EventArgs e)
        {
            //PROJEYI KAYDET (+)

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Kaydedilecek bir resim bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(@"C:\\yazlab\\kaydet.png");
               
            }
        }

        public void Menu5_Click(object sender, EventArgs e)
        {
            //SILME (+)
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Silinecek bir resim bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        public void Menu7_Click(object sender, EventArgs e)
        {
            //SAAT YONU 90 DERECE DONDURME (+)
            
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
               
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                Bitmap img = new Bitmap(bmp.Height, bmp.Width);

                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        img.SetPixel(img.Width - j - 1, i, bmp.GetPixel(i, j));
                    }
                }
                pictureBox1.Image = img;
            }
            sayac++;
        }

        public void Menu8_Click(object sender, EventArgs e)
        {
            //SAAT YONU TERSINE 90 DERECE DONDURME (+)
         
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                Bitmap img = new Bitmap(bmp.Height, bmp.Width);

                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        img.SetPixel(j, img.Height - 1 - i, bmp.GetPixel(i, j));
                    }
                }

                pictureBox1.Image = img;
            }
            sayac++;
        }

        public void Menu9_Click(object sender, EventArgs e)
        {

            //GRI TONLAMA (+)
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                progressBar1.Visible = true;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                progressBar1.Maximum = bmp.Width * bmp.Height;
                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb((byte)((r.R + r.G + r.B) / 3), (byte)((r.R + r.G + r.B) / 3), (byte)((r.R + r.G + r.B) / 3));
                        bmp.SetPixel(i, j, r);
                        progressBar1.Value = i * bmp.Height + j;
                    }
                }
                pictureBox1.Image = bmp;
                progressBar1.Visible = false;
            }
            sayac++;
        }

        public void Menu10_Click(object sender, EventArgs e)
        {
            //AYNALAMA (+)
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                Bitmap img = new Bitmap(bmp.Width, bmp.Height);
                
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        img.SetPixel(img.Width - i - 1, j, bmp.GetPixel(i, j));
                    }
                }
             
                pictureBox1.Image = img;

            }
            sayac++;
        }

        public void Menu11_Click(object sender, EventArgs e)
        {
            //NEGATIF (+)
            if (pictureBox1.Image == null)
            {

                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                progressBar1.Visible = true;
                Color r;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                progressBar1.Maximum = bmp.Width * bmp.Height;

                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb(r.A, (byte)~r.R, (byte)~r.G, (byte)~r.B);
                        bmp.SetPixel(i, j, r);
                        progressBar1.Value = i * bmp.Height + j;
                    }
                }
                pictureBox1.Image = bmp;
                progressBar1.Visible = false;
            }
            sayac++;
        }


        public void pictureBox4_Click(object sender, EventArgs e)
        {
            //RED
            
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                Bitmap orjinal = new Bitmap(pictureBox1.Image);
                safe.FileName = "orjinalRed.png";
                orjinal.Save(safe.FileName);

                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                progressBar1.Visible = true;
                progressBar1.Maximum = bmp.Width * bmp.Height;
                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb((byte)(r.R +hScrollBar1.Value), (byte)(r.G), (byte)(r.B));
                        bmp.SetPixel(i, j, r);
                        progressBar1.Value = i * bmp.Height + j;
                    }
                }
                pictureBox1.Image = bmp;
                progressBar1.Visible = false;
            }
            sayac++;
        }

        public void pictureBox6_Click(object sender, EventArgs e)
        {
            //GREEN
            
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                Bitmap orjinal = new Bitmap(pictureBox1.Image);
                safe.FileName = "orjinalGreen.png";
                orjinal.Save(safe.FileName);
                progressBar1.Visible = true;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                progressBar1.Maximum = bmp.Width * bmp.Height;
                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb((byte)(r.R), (byte)(r.G + hScrollBar2.Value), (byte)(r.B));
                        bmp.SetPixel(i, j, r);
                        progressBar1.Value = i * bmp.Height + j;
                    }
                }
                pictureBox1.Image = bmp;
                progressBar1.Visible = false;
            }
            sayac++;
        }

        public void Menu13_Click(object sender, EventArgs e)
        {
            //OLCEKLENDIRME (+)

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
               Bitmap orjinal = new Bitmap(pictureBox1.Image);
               safe.FileName = "orjinal.png";
               orjinal.Save(safe.FileName);
                Bitmap obj = new Bitmap(pictureBox1.Image, new Size(trackBar1.Value, trackBar2.Value));
                pictureBox1.Image = obj;
            }
        }

        private void orjinalHaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ölçek orjinali
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Boyutlarda bir değişiklik yapılmamıştır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox1.ImageLocation = dialog.FileName;
              
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RENK ORJINAL
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("RGB değerlerinde bir değişiklik yapılmamıştır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void Save_Item_Click(object sender, EventArgs e)
        {
            //FARKLI KAYDET
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Kaydedilecek resim bulunmamaktadır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                safe.InitialDirectory = ".";
                safe.Title = "Projenizin kaydedilecegi dosya konumunu belirleyiniz";
                safe.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";

                if (safe.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(safe.FileName);
                }
                } 
            }

        private void Date_Item_Click(object sender, EventArgs e)
        {
          
        }
        private void Exit_Item_Click(object sender, EventArgs e)
        {
            //EXIT
            this.Close();
        }

        public void Menu4_Click(object sender, EventArgs e)
        {

            //GERI

            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            
            for (i = 0; i < bmp.Width; i++)
            {
                for (j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, back[sayac-1, i, j]);
                }
            }
           
            pictureBox1.Image = bmp;
            sayac--;
        }

        public void pictureBox5_Click(object sender, EventArgs e)
        {
            //BLUE
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                dialog.InitialDirectory = ".";
                dialog.Title = "Bir resim dosyası seçiniz";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
            else
            {
                Bitmap orjinal = new Bitmap(pictureBox1.Image);
                safe.FileName = "orjinalBlue.png";
                orjinal.Save(safe.FileName);
                progressBar1.Visible = true;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Geri(bmp);
                progressBar1.Maximum = bmp.Width * bmp.Height;
                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb((byte)(r.R), (byte)(r.G), (byte)(r.B + hScrollBar3.Value));
                        bmp.SetPixel(i, j, r);
                        progressBar1.Value = i * bmp.Height + j;
                    }
                }
                pictureBox1.Image = bmp;
                progressBar1.Visible = false;
            }
            sayac++;
        }

        public void Menu12_Click(object sender, EventArgs e)
        {
            //HISTOGRAM (yarım)

           
            try
            {
                if (pictureBox1.Image == null)
                {

                    MessageBox.Show("İşlem yapmak için bir resim bulunmamaktadır.Lütfen önce resim seçiniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dialog.Filter = "JPEG Dosyaları| *.jpg | Bütün Dosyalar(*.png*) | *.*";
                    dialog.InitialDirectory = ".";
                    dialog.Title = "Bir resim dosyası seçiniz";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.ImageLocation = dialog.FileName;
                    }
                }

                else
                {


                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    bmp.Save(@"C:\\histogram\\x.txt");
                    StreamWriter fwriter = File.CreateText(@"C:\\histogram\\x.txt");
                        for (int i = 0; i < bmp.Width; i++)
                        {
                            for (j = 0; j < bmp.Height; j++)
                            {
                                Color renk = bmp.GetPixel(i, j);
                                red[i, j] = renk.R;
                                green[i, j] = renk.G;
                                blue[i, j] = renk.B;
                                fwriter.WriteLine(red[i, j] + "-" + green[i, j] + "-" + blue[i, j] + "-");
                                
                                
                            }
                        }
                        fwriter.Close();
                    
                  Form2 f2 = new Form2();
                   f2.Show();
                }
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("[File Missing]");
            }
        }
        


    }
}
