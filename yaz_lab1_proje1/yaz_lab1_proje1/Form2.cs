using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yaz_lab1_proje1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string baglanti_bilgisi = "Data Source=DESKTOP-M4SIFD0;Initial Catalog=bookRead;Integrated Security=True";        
        SqlConnection baglanti = new SqlConnection(baglanti_bilgisi);
        int giris_butonu = 0;
        int kayit_butonu = 0;
        int toplam_veri = 0;
        static public int user_id;
        public string user_name;
        static public int cntrl = 0;      

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            int say = 0;
            SqlCommand komut = new SqlCommand("select count(*) from BX_Users", baglanti);
            baglanti.Open();
            toplam_veri = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            
            do
            {
                toplam_veri++;
                SqlCommand kmt = new SqlCommand("select count(*) from BX_Users where User_ID='"+toplam_veri+"'", baglanti);
                baglanti.Open();
                say = Convert.ToInt32(kmt.ExecuteScalar());
                baglanti.Close();
            } while (say != 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (giris_butonu == 0)
            {
                this.Height = 300;
                label1.Text = "Kullanıcı Adı:";
                label2.Text = "Kullanıcı Sifresi:";
                button2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button1.Location = new Point(140, 33);
                button3.Location = new Point(353, 214);
                button4.Location = new Point(5, 200);
                giris_butonu = 1;
                kayit_butonu = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kayit_butonu == 0)
            {
                this.Height = 460;
                label1.Text = "K. Adı Giriniz:";
                label2.Text = "K Şifresi Giriniz:";
                label3.Text = "Yaş Giriniz:";
                label4.Text = "Semt Giriniz:";
                label5.Text = "İlçe Giriniz:";
                label6.Text = "İl Giriniz:";
                button1.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                button2.Location = new Point(140, 33);
                button3.Location = new Point(353, 365);
                button4.Location = new Point(5, 351);
                kayit_butonu=1;
                giris_butonu = 0;
            }
           
        }
  
        private void button3_Click(object sender, EventArgs e)
        {            
            int eslesme = 0; string role="";
            if (giris_butonu == 1 && textBox1.Text != "" && textBox2.Text != "") {
                SqlCommand komut = new SqlCommand("select count(*) from BX_Users where U_Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", baglanti);
                baglanti.Open();
                eslesme = Convert.ToInt32(komut.ExecuteScalar());
                baglanti.Close();
                if (eslesme == 1)
                {
                   int k=0;
                    SqlCommand kul_id = new SqlCommand("select User_ID,U_Name,Role from BX_Users where U_Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", baglanti);
                    baglanti.Open();
                    SqlDataReader dr = kul_id.ExecuteReader();
                    while (dr.Read())
                    {
                        user_id = Convert.ToInt32(dr["User_ID"].ToString());
                        user_name = dr["U_Name"].ToString();
                         role = dr["Role"].ToString();
                         role=role.Trim();                        
                    }
                    baglanti.Close();
                    
                    if (role=="User")
                    {
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.Show();
                    }
                    else {
                        this.Hide();
                        Form4 frm = new Form4();
                        frm.Show();
                    }
                    
                }
                else {
                    DialogResult soru = new DialogResult();
                    soru=MessageBox.Show("'"+textBox1.Text+"'"+" İsminde Bir Kullanıcı Mevcut Değildir!!! \n Kayıt Olmak İster misiniz?","Güvenlik Sistemi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (soru == DialogResult.Yes)
                    {
                        this.Height = 460;
                        label1.Text = "K. Adı Giriniz:";
                        label2.Text = "K Şifresi Giriniz:";
                        label3.Text = "Yaş Giriniz:";
                        label4.Text = "Semt Giriniz:";
                        label5.Text = "İlçe Giriniz:";
                        label6.Text = "İl Giriniz:";
                        button1.Visible = false;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        textBox4.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        button2.Location = new Point(140, 33);
                        button3.Location = new Point(353, 365);
                        button4.Location = new Point(5, 351);
                        kayit_butonu = 1;
                        giris_butonu = 0;
                    }
                    else { textBox1.Clear();textBox2.Clear(); }
                }
                
            }
            else if (kayit_butonu == 1 && textBox1.Text != "" && textBox2.Text != "") {
                SqlCommand komut = new SqlCommand("select count(*) from BX_Users where U_Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", baglanti);
                baglanti.Open();
                eslesme = Convert.ToInt32(komut.ExecuteScalar());
                baglanti.Close();
                if (eslesme == 0)
                {
                    string loc = textBox4.Text+","+textBox5.Text+","+textBox6.Text;
                    baglanti.Open();
                    SqlCommand veri_kayit = new SqlCommand("insert into BX_Users (User_ID,U_Name,Password,Location,Age,Role) values('"+toplam_veri+"','"+textBox1.Text+"','"+textBox2.Text+"','"+loc+"','"+textBox3.Text+"','"+"User"+"')", baglanti);
                    veri_kayit.ExecuteNonQuery();
                    baglanti.Close();                    
                    MessageBox.Show("Kayıt İşleminiz Gerçekleştirilmiştir");
                    user_id = toplam_veri;
                    user_name = textBox1.Text;
                    cntrl = 1;
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else  {
                    MessageBox.Show("Aynı İsim veya Parolada Kullanıcı Mevcut...\n Lütfen Başka Bir Kullanıcı Adıyla veya Parolasıyla Deneyiniz","Güvenlik Sistemi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş girilemez!");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            giris_butonu = 0;
            kayit_butonu = 0;
            this.Height = 236;
            button1.Location = new Point(54, 33);
            button2.Location = new Point(243, 33);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) { e.Handled = false; }
            else if ((int)e.KeyChar == 8) { e.Handled = false; }
            else { e.Handled = true;MessageBox.Show("Yaş Değeri Sayısal Olmalıdır..."); }
        }
    }
}
