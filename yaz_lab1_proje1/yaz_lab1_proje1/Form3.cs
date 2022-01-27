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

namespace yaz_lab1_proje1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static string baglanti_bilgisi = "Data Source=DESKTOP-M4SIFD0;Initial Catalog=bookRead;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglanti_bilgisi);

        private void kitap_getir() {
            SqlCommand komut = new SqlCommand("select * from BX_Books where ISBN='" + Form1.secilen_ISBN + "'", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr["ISBN"].ToString();
                this.Text=label4.Text = dr["Book_Title"].ToString();
                label6.Text = dr["Book_Author"].ToString();
                label8.Text = dr["Year_Of_Publication"].ToString();
                label10.Text = dr["Publisher"].ToString();
                pictureBox1.ImageLocation = dr["Image_URL_M"].ToString();
            }
            baglanti.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kitap_getir();         
            axAcroPDF1.LoadFile(@"C:\Users\Y.KAMCI\Desktop\yaz_lab1_proje1\yaz_lab1_proje1\pdf\book"+Form1.pdf+ ".pdf");
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text !=" ")
            {
                if (Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) <= 10)
                {
                    int say = 0;
                    baglanti.Open();
                    SqlCommand veri_sor = new SqlCommand("select count(*) from BX_Book_Ratings where  User_ID='" + Form2.user_id + "' and ISBN='" + Form1.secilen_ISBN + "'", baglanti);
                    say = Convert.ToInt32(veri_sor.ExecuteScalar());
                    baglanti.Close();

                    if (say == 0)
                    {
                        baglanti.Open();
                        SqlCommand veri_kayit = new SqlCommand("insert into BX_Book_Ratings (User_ID,ISBN,Book_Rating) values('" + Form2.user_id + "','" + Form1.secilen_ISBN + "','" + Convert.ToInt32(textBox1.Text) + "')", baglanti);
                        veri_kayit.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    else
                    {
                        baglanti.Open();
                        SqlCommand veri_kayit = new SqlCommand("update BX_Book_Ratings set Book_Rating='" + Convert.ToInt32(textBox1.Text) + "' where User_ID='" + Form2.user_id + "' and ISBN='" + Form1.secilen_ISBN + "'", baglanti);
                        veri_kayit.ExecuteNonQuery();
                        baglanti.Close();
                    }

                }
                else { MessageBox.Show("Verdiğiniz Oy Geçersizdir. Tekrar ;Deneyiniz..."); textBox1.Clear(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox1.Text = "0";
            }
            if (Convert.ToInt32(textBox1.Text) > 0) textBox1.Text = (Convert.ToInt32(textBox1.Text) - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox1.Text = "0";
            }
            if(Convert.ToInt32(textBox1.Text)<10)   textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
