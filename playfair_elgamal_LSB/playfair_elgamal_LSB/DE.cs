using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Novacode;

namespace playfair_elgamal_LSB
{
	public partial class DE : Form
	{
		Stopwatch watch = new Stopwatch();
		DocX dokumenbaru;
		List<int> plain = new List<int>();
        int[] angka = new int[256];
        int ab = 0;
		
		public DE()
		{
			InitializeComponent();
		}
		
		void EnkripsiEmbedToolStripMenuItemClick(object sender, EventArgs e)
		{
			EE fpindah = new EE();
            this.Hide();
            fpindah.Show();
		}
		
		void PembangkitKunToolStripMenuItemClick(object sender, EventArgs e)
		{
			kunci fpindah = new kunci();
            this.Hide();
            fpindah.Show();
		}
		
		
		
		void Button4Click(object sender, EventArgs e)
		{
			richTextBox1.Text = null;
			richTextBox2.Text = null;
			richTextBox3.Text = null;
			richTextBox4.Text = null;
            pictureBox1.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            dokumenbaru = null;
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Private Key( *.private)|*.private";
			open.FileName="";
			if (open.ShowDialog() == DialogResult.OK)
			{
			
				string[] lines = File.ReadAllLines(open.FileName);
				textBox11.Text = lines[0];
				textBox13.Text = lines[1];
			}
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
                textBox2.Text = pictureBox1.Image.Height + " x " + pictureBox1.Image.Width;
                textBox1.Text = Path.GetFileName(ofd.FileName);
            }
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			dokumenbaru = null;
			if (richTextBox2.Text != "")
			{
				SaveFileDialog save = new SaveFileDialog();
				save.Filter = "Document Files|*.docx|Document Files|*.doc|Text Files( *.txt)|*.txt";
				if(save.ShowDialog() == DialogResult.OK)
				{
					string metode = save.FileName.Substring(save.FileName.Length - 3, 3);
					if (metode == "txt")
                    {
						FileStream fstream=new FileStream(save.FileName,FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fstream);
						SeekOrigin seekorigin = new SeekOrigin();
						sw.BaseStream.Seek(0, seekorigin);
						sw.Write(richTextBox2.Text);
						sw.Flush();
						sw.Close();
					}
					else
					{
						dokumenbaru = DocX.Create("ENC_", DocumentTypes.Document);
						dokumenbaru.InsertParagraph(richTextBox2.Text);
						dokumenbaru.SaveAs(save.FileName);
					}
					MessageBox.Show("Pesan Berhasil Disimpan");
				}
			} 
			else
			{
				MessageBox.Show("Pesan Belum Didekripsi"); 
			}
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			if (textBox11.Text == "" || textBox13.Text == "")
			{
				MessageBox.Show(this, "Kunci Private belum diinput", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else if (richTextBox4.Text == "") 
			{
				MessageBox.Show(this, "Pesan yang akan didekrip belum ada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else
			{
				richTextBox3.Text = null;
				textBox10.Text = null;
				textBox9.Text = null;
				List<int> plainteks = new List<int>();
				watch.Restart();
				String pesan = richTextBox4.Text;
				string[] cipherteks = pesan.Split(',');
				int p = Convert.ToInt32(textBox11.Text);
				int d = Convert.ToInt32(textBox13.Text);
				watch.Restart();
				for (int i=0; i<cipherteks.Length; i = i+2)
				{
					plainteks.Add(Fungsi.modexp(Convert.ToInt32(cipherteks[i]),Convert.ToInt32(cipherteks[i+1]),(p-1-d),p));
				}
				richTextBox3.Text = string.Join(", ",plainteks);
            	watch.Stop();
            	textBox9.Text = plainteks.Count.ToString();
            	textBox10.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
            	textBox4.Text = textBox9.Text;
            	richTextBox1.Text = richTextBox3.Text;
            	MessageBox.Show("Pesan Berhasil Didekrip");
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
		
		private void dekripsiplayfair(int a, int b, int[,] Matrik)
        {
            int[] bigram = { a, b };
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
            	if ((bigramx[0] == 0) && (bigramy[0] == 0))
                {
                    plain.Add(Matrik[15, 15]); 
                    plain.Add(Matrik[15, 15]);
                }
                else if (bigramx[0] == 0)
                {
                    plain.Add(Matrik[15, bigramy[0] - 1]);
                    plain.Add(Matrik[15, bigramy[0] - 1]);
                }
                else if (bigramy[0] == 0)
                {
                    plain.Add(Matrik[bigramx[0] - 1, 15]); 
                    plain.Add(Matrik[bigramx[0] - 1, 15]);
                }
                else
                {
                    plain.Add(Matrik[bigramx[0] - 1, bigramy[0] - 1]);
                    plain.Add(Matrik[bigramx[0] - 1, bigramy[0] - 1]);
                } 
            }
            else if (bigramx[0] == bigramx[1])
            {
                if (bigramy[0] == 0)
                {
                    plain.Add(Matrik[bigramx[0], 15]); 
                    plain.Add(Matrik[bigramx[1], bigramy[1] - 1]);
                }
                else if (bigramy[1] == 0)
                {
                    plain.Add(Matrik[bigramx[0], bigramy[0] - 1]); 
                    plain.Add(Matrik[bigramx[1], 15]);
                }
                else
                {
                    plain.Add(Matrik[bigramx[0], bigramy[0] - 1]); 
                    plain.Add(Matrik[bigramx[1], bigramy[1] - 1]);
                }
            }
            else if (bigramy[0] == bigramy[1])
            {
                if (bigramx[0] == 0)
                {
                    plain.Add(Matrik[15, bigramy[0]]); 
                    plain.Add(Matrik[bigramx[1] - 1, bigramy[1]]);
                }
                else if (bigramx[1] == 0)
                {
                    plain.Add(Matrik[bigramx[0] - 1, bigramy[0]]); 
                    plain.Add(Matrik[15, bigramy[1]]);
                }
                else
                {
                    plain.Add(Matrik[bigramx[0] - 1, bigramy[0]]);
                    plain.Add(Matrik[bigramx[1] - 1, bigramy[1]]);
                } 
            }
            else
            {
                {
                    plain.Add(Matrik[bigramx[0], bigramy[1]]);
                    plain.Add(Matrik[bigramx[1], bigramy[0]]);
                } 
            }
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
	            String pesan = richTextBox1.Text;
				string[] cpher = pesan.Split(',');
	            for (int i = 0; i < cpher.Length; i += 2)
	            {
	            	dekripsiplayfair(Convert.ToInt32(cpher[i]),Convert.ToInt32(cpher[i+1]), Matrik1);
	            }
            	watch.Stop();
            	List<char> plains = plain.Select(x => Convert.ToChar(x)).ToList();
            	richTextBox2.Text = String.Join("",plains);
            	if (richTextBox2.Text[richTextBox2.Text.Length-1] == 'x')
            		richTextBox2.Text = richTextBox2.Text.Substring(0, richTextBox2.Text.Length-1);
            	textBox7.Text = richTextBox2.Text.Length.ToString();
            	textBox8.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
            	MessageBox.Show("Pesan Berhasil Didekrip");
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			if (pictureBox1.Image == null)
            {
                MessageBox.Show(this, "Gambar belum diinput", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
			richTextBox4.Text = null;
			textBox12.Text = null;
			textBox3.Text = null;
			watch.Restart();
            Bitmap gambarcover = (Bitmap)pictureBox1.Image;
            string[] cover = new string[gambarcover.Width * gambarcover.Height];
            int yyy = 0;
            for (int i = 0; i < gambarcover.Width; i++) 
            {
            	for (int j = 0; j < gambarcover.Height; j++) 
            	{
            		int red = gambarcover.GetPixel(i, j).R;
            		int green = gambarcover.GetPixel(i, j).G;
            		int blue = gambarcover.GetPixel(i, j).B;
            		if (red == 0 && green == 0 && blue == 0) 
            		{
            			goto foo;
            		}
            		else
            		{
	            		cover[yyy] = Convert.ToString(red, 2).PadLeft(8, '0');
	            		yyy++;
            		}
            	}
            }
           	foo:
            string pesanbit = string.Empty;
            for (int i = 0; i < yyy; i++) 
            {
            	pesanbit += cover[i].Substring(7,1);
            }
            List<int> msg = new List<int>();
            List<string> cipher = new List<string>();
            for (int i = 0; i < pesanbit.Length; i=i+8) 
            {
            	msg.Add(changeint(pesanbit.Substring(i,8)));
            }
            for (int i = 0; i < msg.Count; i=i+2)
            {
            	if(msg[i] == 0)
            	{
            		cipher.Add(Convert.ToString(msg[i+1]));
            	}
            	else
            	{
            		if(msg[i+1] < 10)
            			cipher.Add(Convert.ToString(msg[i]) + "0" + Convert.ToString(msg[i+1]));
            		else
            			cipher.Add(Convert.ToString(msg[i]) + Convert.ToString(msg[i+1]));
            	}
            }
            watch.Stop();
            richTextBox4.Text = string.Join(", ",cipher);
            textBox12.Text = cipher.Count.ToString();
	        textBox3.Text = Math.Round(Convert.ToDecimal(watch.Elapsed.TotalMilliseconds),4).ToString() + " ms";
	        MessageBox.Show("pesan berhasil diekstrak");
		}
		
		private int changeint(string x)
        {
            return Convert.ToInt32(x,2);
        }
	}
}
