using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Novacode;

namespace playfair_elgamal_LSB
{
	public partial class EE : Form
	{
		Stopwatch watch = new Stopwatch();
		Random r = new Random();
		DocX dokumen;
		List<int> plain = new List<int>();
        List<int> cpher = new List<int>();
        int[] angka = new int[256];
        int ab = 0;
		
		public EE()
		{
			InitializeComponent();
		}
		
		void DekripsiEkstrakToolStripMenuItemClick(object sender, EventArgs e)
		{
			DE fpindah = new DE();
            this.Hide();
            fpindah.Show();
		}
		
		void PembangkitKunToolStripMenuItemClick(object sender, EventArgs e)
		{
			kunci fpindah = new kunci();
            this.Hide();
            fpindah.Show();
		}
		
		
		void Button5Click(object sender, EventArgs e)
		{
			richTextBox1.Text = null;
			richTextBox2.Text = null;
			richTextBox3.Text = null;
			richTextBox4.Text = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            textBox14.Text = null;
            dokumen = null;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			pictureBox1.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse Image File";
            ofd.Filter = "Bitmap files( *.bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox2.Text = pictureBox1.Image.Height.ToString() + " x " + pictureBox1.Image.Width.ToString();
                textBox1.Text = Path.GetFileName(ofd.FileName);
            }
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			textBox4.Text = null;
			textBox5.Text = null;
			richTextBox1.Text = null;
			try
			{
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Text Files|*.txt;*.docx;*.doc";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string metode = open.FileName.Substring(open.FileName.Length - 3, 3);
                    if (metode == "txt")
                    {
                        textBox5.Text = Path.GetFileName(open.FileName);
                        string nama = open.FileName.Substring(0, open.FileName.Length);
                        FileStream fstream = new FileStream(nama, FileMode.Open, FileAccess.ReadWrite);
                        StreamReader sreader = new StreamReader(fstream);
                        sreader.BaseStream.Seek(0, SeekOrigin.Begin);
                        richTextBox1.Text = sreader.ReadToEnd();
                        sreader.Close();
                    }
                    else
                    {
                    	dokumen = DocX.Load(open.FileName);
						String teks_tampilan = "";
						int banyak_paragraph = dokumen.Paragraphs.Count;
						for(int i = 0; i < banyak_paragraph; i++){
							teks_tampilan += dokumen.Paragraphs[i].Text;
							teks_tampilan += "\n";
						}
						richTextBox1.Text = teks_tampilan;
						textBox5.Text = Path.GetFileName(open.FileName);
					}
                    textBox4.Text = richTextBox1.Text.Length.ToString();
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Public Key( *.public)|*.public";
			open.FileName="";
			if (open.ShowDialog() == DialogResult.OK)
			{
			
				string[] lines = File.ReadAllLines(open.FileName);
				textBox11.Text = lines[0];
				textBox13.Text = lines[1];
				textBox14.Text=lines[2];
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			if (pictureBox2.Image != null)
            {
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					pictureBox2.Image.Save(saveFileDialog1.FileName);
					MessageBox.Show("Gambar Berhasil Disimpan");
				}
		    }
            else
            {
                MessageBox.Show("Gambar Belum Diembed"); 
            }
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			if (textBox11.Text == "" || textBox13.Text == "" || textBox14.Text == "")
			{
				MessageBox.Show(this, "Kunci Public belum diinput", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else if (richTextBox4.Text == "") 
			{
				MessageBox.Show(this, "Pesan yang akan dienkrip belum ada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else
			{
				richTextBox3.Text = null;
				textBox10.Text = null;
				textBox9.Text = null;
				List<int> cipher = new List<int>();
				watch.Restart();
				String pesan = richTextBox4.Text;
				string[] plainteks = pesan.Split(',');
				int p = Convert.ToInt32(textBox11.Text);
				int a = Convert.ToInt32(textBox13.Text);
				int b = Convert.ToInt32(textBox14.Text);
				int rr = 0;
				do
				{
			  		rr = r.Next(1,p-1);
		    	}
				while( rr >= (p-1));
				for (int i=0; i<plainteks.Length;i++)
				{
					cipher.Add(Fungsi.modexp(a,rr,p));
					cipher.Add(Fungsi.modexp(b,Convert.ToInt32(plainteks[i]),rr,p));
				}
				richTextBox3.Text = string.Join(", ",cipher);
            	watch.Stop();
            	textBox9.Text = cipher.Count.ToString();
            	textBox10.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
            	MessageBox.Show("Pesan Berhasil Dienkrip");
			}
		}
		
		private void enkripsiplayfair(int a, int b, int[,] Matrik)
        {
            int[] bigram = {a,b};
            bool limit = false;
            int[] bigramx = new int[2];
            int[] bigramy = new int[2];
            for (int x = 0; x < 2; x++)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (bigram[x] == Matrik[i, j])
                        {
                            bigramx[x] = i;
                            bigramy[x] = j;
                            limit = true;
                            if (limit == true && x == 2)
                                break;
                        }
                    }
                    if (limit == true && x == 2)
                        break;
                }
            }
            if ((bigramx[0] == bigramx[1]) && (bigramy[0] == bigramy[1]))
            {
            	if ((bigramx[0] == 15) && (bigramy[0] == 15))
                {
                    cpher.Add(Matrik[0, 0]); 
                    cpher.Add(Matrik[0, 0]);
                }
                else if (bigramx[0] == 15)
                {
                    cpher.Add(Matrik[0, bigramy[0] + 1]);
                    cpher.Add(Matrik[0, bigramy[0] + 1]);
                }
                else if (bigramy[0] == 15)
                {
                    cpher.Add(Matrik[bigramx[0] + 1, 0]); 
                    cpher.Add(Matrik[bigramx[0] + 1, 0]);
                }
                else
                {
                    cpher.Add(Matrik[bigramx[0] + 1, bigramy[0] + 1]);
                    cpher.Add(Matrik[bigramx[0] + 1, bigramy[0] + 1]);
                } 
            }
            else if (bigramx[0] == bigramx[1])
            {
                if (bigramy[0] == 15)
                {
                    cpher.Add(Matrik[bigramx[0], 0]); 
                    cpher.Add(Matrik[bigramx[1], bigramy[1] + 1]);
                }
                else if (bigramy[1] == 15)
                {
                    cpher.Add(Matrik[bigramx[0], bigramy[0] + 1]); 
                    cpher.Add(Matrik[bigramx[1], 0]);
                }
                else
                {
                    cpher.Add(Matrik[bigramx[0], bigramy[0] + 1]);
                    cpher.Add(Matrik[bigramx[1], bigramy[1] + 1]);
                } 
            }
            else if (bigramy[0] == bigramy[1])
            {
                if (bigramx[0] == 15)
                {
                    cpher.Add(Matrik[0, bigramy[0]]);
                    cpher.Add(Matrik[bigramx[1] + 1, bigramy[1]]);
                }
                else if (bigramx[1] == 15)
                {
                    cpher.Add(Matrik[bigramx[0] + 1, bigramy[0]]);
                    cpher.Add(Matrik[0, bigramy[1]]);
                }
                else
                {
                    cpher.Add(Matrik[bigramx[0] + 1, bigramy[0]]);
                    cpher.Add(Matrik[bigramx[1] + 1, bigramy[1]]);
                } 
            }
            else
            {
                {
                    cpher.Add(Matrik[bigramx[0], bigramy[1]]);
                    cpher.Add(Matrik[bigramx[1], bigramy[0]]);
                }
            }
        }

        bool cekKunci(int huruf)
        {
            for (int i = 0; i < ab; i++)
            {
                if (angka[i] == huruf)
                    return false;
            }
            angka[ab] = huruf;
            ab++;
            return true;
        }
		
		void Button7Click(object sender, EventArgs e)
		{
			if (textBox6.Text == "")
			{
				MessageBox.Show(this, "Kunci Playfair belum diinput", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else if (richTextBox1.Text == "") 
			{
				MessageBox.Show(this, "Pesan yang akan dienkrip belum ada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else
			{
				richTextBox2.Text = null;
				textBox8.Text = null;
				textBox7.Text = null;
				watch.Restart();
				plain = new List<int>();
	            cpher = new List<int>();
	            angka = new int[256];
	            ab = 0;
	            string kunci1 = textBox6.Text;
	            int PKunci1 = kunci1.Length;
	            int[,] Matrik1 = new int[16, 16];
	            int[,] Matrik2 = new int[16, 16];
	            int a = 0, pixel = 0;
	            //tabel1
	            for (int i = 0; i < 16; i++)
	            {
	                for (int j = 0; j < 16; j++)
	                {
	                    if (a < PKunci1)
	                    {
	                        if (cekKunci(kunci1[a]) == true)
	                            Matrik1[i, j] = kunci1[a];
	                        else
	                            j--;
	                        a++;
	                    }
	                    else
	                    {
	                        if (cekKunci(pixel) == true)
	                            Matrik1[i, j] = pixel;
	                        else
	                            j--;
	                        pixel++;
	                    }
	                }
	            }
	            for (int i = 0; i < richTextBox1.Text.Length; i++)
	            {
	            	plain.Add(Convert.ToInt32(richTextBox1.Text[i]));
	            }
	
	            //enkrip
	            if (plain.Count % 2 != 0)
	            	plain.Add(Convert.ToInt32('x'));
	            for (int i = 0; i < plain.Count; i += 2)
	            {
	                enkripsiplayfair(plain[i],plain[i + 1], Matrik1);
	            }
            	watch.Stop();
            	richTextBox2.Text = String.Join(", ",cpher);
            	textBox7.Text = cpher.Count.ToString();
            	textBox8.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
            	textBox12.Text = textBox7.Text;
            	richTextBox4.Text = richTextBox2.Text;
            	MessageBox.Show("Pesan Berhasil Dienkrip");
			}
		}
		
		private int changeint(string x)
        {
            return Convert.ToInt32(x,2);
        }
		
		void Button3Click(object sender, EventArgs e)
		{
			if (richTextBox3.Text == "") 
			{
				MessageBox.Show(this, "Tidak ada pesan yang disisipkan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else if (pictureBox1.Image == null) 
			{
				MessageBox.Show(this, "Gambar cover belum diinput", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else
			{
				pictureBox2.Image = null;
				textBox3.Text = null;
				watch.Restart();
				string pesanbit = "";
				String pesan = richTextBox3.Text;
				string[] cipherteks = pesan.Split(',');
				int[] msg = new int[cipherteks.Length*2];
				for(int i = 0; i < cipherteks.Length; i++)
				{
					string pesann = cipherteks[i];
        			while (pesann.Length != 4) 
        			{
        				pesann = "0" + pesann;
        			}
        			msg[2*i] = Convert.ToInt32(pesann.Substring(0,2));
        			msg[(2*i)+1] = Convert.ToInt32(pesann.Substring(2,2));
				}
				for (int i = 0; i < msg.Length; i++) 
				{
					pesanbit += Convert.ToString(msg[i], 2).PadLeft(8, '0');
				}
            	Bitmap gambarcover = (Bitmap)pictureBox1.Image;
            	if(pesanbit.Length > (gambarcover.Width * gambarcover.Height))
            	{
            		MessageBox.Show(this, "Ukuran Gambar Cover Tidak Mencukupi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            	}
            	else
            	{
	            	string[] cover = new string[gambarcover.Width * gambarcover.Height * 3];
	            	string[] sisip = new string[gambarcover.Width * gambarcover.Height * 3];
	            	int yy = 0;
	            	for (int i = 0; i < gambarcover.Width; i++) 
	            	{
	            		for (int j = 0; j < gambarcover.Height; j++) 
	            		{
	            			int red = gambarcover.GetPixel(i, j).R;
	            			cover[yy] = Convert.ToString(red, 2).PadLeft(8, '0');
	            			yy++;
	            			int green = gambarcover.GetPixel(i, j).G;
	            			cover[yy] = Convert.ToString(green, 2).PadLeft(8, '0');
	            			yy++;
	            			int blue = gambarcover.GetPixel(i, j).B;
	            			cover[yy] = Convert.ToString(blue, 2).PadLeft(8, '0');
	            			yy++;
	            		}
	            	}
	            	cover.CopyTo(sisip,0);
	            	int z = 0;
	            	for (int i = 0; i < pesanbit.Length; i++) 
	            	{
	            		sisip[i*3] = cover[i*3].Substring(0,7) + pesanbit.Substring(z,1);
	            		z += 1;
	            	}
	            	sisip[pesanbit.Length*3] = "00000000";
	            	sisip[(pesanbit.Length*3)+1] = "00000000";
	            	sisip[(pesanbit.Length*3)+2] = "00000000";
	             	Bitmap encode_img = new Bitmap(gambarcover.Width, gambarcover.Height);
	            	int zz = 0;
	            	for (int i = 0; i < encode_img.Width; i++)
	            	{
	                	for (int j = 0; j < encode_img.Height; j++)
	               		{
	                		encode_img.SetPixel(i, j, Color.FromArgb(changeint(sisip[zz]), changeint(sisip[zz+1]), changeint(sisip[zz+2])));
	                		zz = zz+3;
	                	}
	            	}
	            	watch.Stop();
		        	textBox3.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
		        	pictureBox2.Image = encode_img;
		        	MessageBox.Show("pesan berhasil diembed");
            	}
			}
		}
	}
}
