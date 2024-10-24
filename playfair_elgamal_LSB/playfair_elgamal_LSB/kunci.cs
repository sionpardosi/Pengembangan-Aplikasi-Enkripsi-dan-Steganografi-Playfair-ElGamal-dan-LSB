using System;
using System.IO;
using System.Windows.Forms;

namespace playfair_elgamal_LSB
{
	public partial class kunci : Form
	{
		Random r = new Random();
		
		public kunci()
		{
			InitializeComponent();
		}
		
		void DekripsiEkstrakToolStripMenuItemClick(object sender, EventArgs e)
		{
			DE fpindah = new DE();
            this.Hide();
            fpindah.Show();
		}
		
		void EnkripsiEmbedToolStripMenuItemClick(object sender, EventArgs e)
		{
			EE fpindah = new EE();
            this.Hide();
            fpindah.Show();
		}
	
		
		void Button2Click(object sender, EventArgs e)
		{
			textBox1.Text = null;
			textBox2.Text = null;
			textBox3.Text = null;
			textBox4.Text = null;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			int p,alpa,d, beta;
			p = Fungsi.lehmann(r.Next(257,1000));
			textBox1.Text = p.ToString();
			alpa = r.Next(2,p-1);
			textBox2.Text = alpa.ToString();
			d = r.Next(2,p-2);
			textBox3.Text = d.ToString();
			beta = Fungsi.modexp(alpa,d,p);
			textBox4.Text = beta.ToString();
		}
		void Button3Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show(this, "Kunci Elgamal Belum Digenerate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}
			else
			{
				SaveFileDialog simpan = new SaveFileDialog();
				simpan.Filter = "Public Key( *.public)|*.public";
				simpan.FileName = "*.public";
				if (simpan.ShowDialog() == DialogResult.OK)
				{
					FileStream fstream=new FileStream(simpan.FileName,FileMode.Create);
					StreamWriter sw = new StreamWriter(fstream);
					SeekOrigin seekorigin = new SeekOrigin();
					sw.BaseStream.Seek(0, seekorigin);
					sw.WriteLine(textBox1.Text);
					sw.WriteLine(textBox2.Text);
					sw.WriteLine(textBox4.Text);	
					sw.Flush();
					sw.Close();
					MessageBox.Show("Kunci Public Berhasil Disimpan");
				}
				SaveFileDialog simpann = new SaveFileDialog();
				simpann.Filter = "Private Key( *.private)|*.private";
				simpann.FileName = "*.private";
				if (simpann.ShowDialog() == DialogResult.OK)
				{
					FileStream fstream=new FileStream(simpann.FileName,FileMode.Create);
					StreamWriter sw = new StreamWriter(fstream);
					SeekOrigin seekorigin = new SeekOrigin();
					sw.BaseStream.Seek(0, seekorigin);
					sw.WriteLine(textBox1.Text);
					sw.WriteLine(textBox3.Text);
					sw.Flush();
					sw.Close();
					MessageBox.Show("Kunci Private Berhasil Disimpan");
				}			
			}
		}
	}
}
