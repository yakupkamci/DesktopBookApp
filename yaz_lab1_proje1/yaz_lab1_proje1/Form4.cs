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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int p1=0, p2=0, p3=0,p5=0;
        string k_id="";

        static string baglanti_bilgisi = "Data Source=DESKTOP-M4SIFD0;Initial Catalog=bookRead;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglanti_bilgisi);

        private void admin_info() {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from BX_Users where User_ID='"+Form2.user_id+"'",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                textBox9.Text = dr["U_Name"].ToString();
                textBox10.Text = dr["Password"].ToString();
                string a = dr["Location"].ToString();
                string[] b = a.Split(',');
                for (int i = 0; i < b.Length; i++) this.Controls["textBox"+(i+11)].Text=b[i].ToString();                
                textBox14.Text = dr["Age"].ToString();
            }
            baglanti.Close();
            
        }
        private void admin_buton_gizle() {
            button11.Visible = false;
            for (int i = 17; i >= 0; i--)
            {
                label9.Location = new Point(label9.Location.X - i, label9.Location.Y);
                label10.Location = new Point(label10.Location.X - i, label10.Location.Y);
                label11.Location = new Point(label11.Location.X - i, label11.Location.Y);
                label12.Location = new Point(label12.Location.X - i, label12.Location.Y);
                label13.Location = new Point(label13.Location.X - i, label13.Location.Y);
                label14.Location = new Point(label14.Location.X - i, label14.Location.Y);
                textBox9.Location = new Point(textBox9.Location.X - i, textBox9.Location.Y);
                textBox10.Location = new Point(textBox10.Location.X - i, textBox10.Location.Y);
                textBox11.Location = new Point(textBox11.Location.X - i, textBox11.Location.Y);
                textBox12.Location = new Point(textBox12.Location.X - i, textBox12.Location.Y);
                textBox13.Location = new Point(textBox13.Location.X - i, textBox13.Location.Y);
                textBox14.Location = new Point(textBox14.Location.X - i, textBox14.Location.Y);                
                System.Threading.Thread.Sleep(30);
            }
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            
            for (int i = 0; i <= 17; i++)
            {
                label9.Location = new Point(label9.Location.X + i, label9.Location.Y);
                label10.Location = new Point(label10.Location.X + i, label10.Location.Y);
                label11.Location = new Point(label11.Location.X + i, label11.Location.Y);
                label12.Location = new Point(label12.Location.X + i, label12.Location.Y);
                label13.Location = new Point(label13.Location.X + i, label13.Location.Y);
                label14.Location = new Point(label14.Location.X + i, label14.Location.Y);
                textBox9.Location = new Point(textBox9.Location.X + i, textBox9.Location.Y);
                textBox10.Location = new Point(textBox10.Location.X + i, textBox10.Location.Y);
                textBox11.Location = new Point(textBox11.Location.X + i, textBox11.Location.Y);
                textBox12.Location = new Point(textBox12.Location.X + i, textBox12.Location.Y);
                textBox13.Location = new Point(textBox13.Location.X + i, textBox13.Location.Y);
                textBox14.Location = new Point(textBox14.Location.X + i, textBox14.Location.Y);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void admin_guncelle() {
            string a = textBox11.Text + "," + textBox12.Text + "," + textBox13.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update BX_Users set U_Name='"+textBox9.Text+"',Password='"+textBox10.Text+"',Location='"+a+"',Age='"+textBox14.Text+"' where User_ID='"+Form2.user_id+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Admin Bilgileri Güncellenmiştir...");
        }

        private void admin_ata()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update BX_Users set Role='"+"Admin"+"' where User_ID='" + k_id + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Admin Ataması Yapılmıştır...");
        }

        private void user_ata()
        {
            if (Form2.user_id != Convert.ToInt32(k_id))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update BX_Users set Role='" + "User" + "' where User_ID='" + k_id + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("User Ataması Yapılmıştır...");
            }
            else MessageBox.Show("Kendinizi User Atayamazsınız!!!!");
        }

        private void kullanici_buton_gizle()
        {
            button13.Visible = false;
            button14.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            for (int i = 17; i >= 0; i--)
            {
                button1.Location = new Point(button1.Location.X - i, button1.Location.Y);
                button2.Location = new Point(button2.Location.X - i, button2.Location.Y);
                button12.Location = new Point(button12.Location.X - i, button12.Location.Y);
                button15.Location = new Point(button15.Location.X - i, button15.Location.Y);
                System.Threading.Thread.Sleep(30);
            }
            button1.Visible = false;
            button2.Visible= false;            
            button12.Visible = false;
            button15.Visible = false;
            for (int i = 0; i <= 17; i++)
            {
                button1.Location = new Point(button1.Location.X + i, button1.Location.Y);
                button2.Location = new Point(button2.Location.X + i, button2.Location.Y);
                button12.Location = new Point(button12.Location.X + i, button12.Location.Y);
                button15.Location = new Point(button15.Location.X + i, button15.Location.Y);
                System.Threading.Thread.Sleep(5);
            }
        }
       
        private void kitap_buton_gizle()
        {
            for (int i = 17; i >= 0 ; i--)
            {
                button3.Location = new Point(button3.Location.X - i, button3.Location.Y);
                button4.Location = new Point(button4.Location.X - i, button4.Location.Y);
                button5.Location = new Point(button5.Location.X - i, button5.Location.Y);
                button6.Location = new Point(button6.Location.X - i, button6.Location.Y);
                System.Threading.Thread.Sleep(30);
            }
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button10.Visible = false;
            dataGridView1.DataSource = null;
            for (int i = 0; i <= 17; i++)
            {
                button3.Location = new Point(button3.Location.X + i, button3.Location.Y);
                button4.Location = new Point(button4.Location.X + i, button4.Location.Y);
                button5.Location = new Point(button5.Location.X + i, button5.Location.Y);
                button6.Location = new Point(button6.Location.X + i, button6.Location.Y);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void kullanici_listele() {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from BX_Users", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void kullanici_sil() {
            if (k_id != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from BX_Users where User_ID='"+Convert.ToInt32(k_id)+ "' and ('"+Convert.ToInt32(k_id)+"'!= '"+Form2.user_id+"')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand komutt = new SqlCommand("delete from BX_Book_Ratings where User_ID='" + Convert.ToInt32(k_id) + "'", baglanti);
                komutt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kullanıcı Silinmiştir...");
            }
            else MessageBox.Show("Silinecek Kullanıcıyı Seçmediniz veya Kendinizi Silmeye Çalışıyorsunuz!!!");
        }

        private void kitap_listele() {
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("select * from BX_Books order by id", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            baglanti.Close();
        }

        private void kitap_ekle() {
            SqlCommand komut = new SqlCommand("insert into BX_Books(ISBN,Book_Title,Book_Author,Year_Of_Publication,Publisher,Image_URL_S,Image_URL_M,Image_URL_L) values('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Başarıyla Eklendi...");
        }

        private void kitap_sil() {
            if (k_id != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from BX_Books where ISBN='" + k_id + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitap Silinmiştir...");
            }
            else MessageBox.Show("Silinecek Kitabı Seçiniz!!!");
        }

        private void kitap_guncelle() {
            if (k_id != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update BX_Books set Book_Title='" + textBox2.Text + "',Book_Author='" + textBox3.Text + "',Year_Of_Publication='" + textBox4.Text + "',Publisher='" + textBox5.Text + "',Image_URL_S='" + textBox6.Text + "',Image_URL_M='" + textBox7.Text + "', Image_URL_L = '" + textBox8.Text + "' where ISBN='" + k_id + "'",baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitap Güncellenmiştir...");
            }
            else MessageBox.Show("Güncellecek Kitabı Seçiniz!!!");

            
        }

        private void ozel_temizleme() {
            for (int i = 1; i <= 8; i++) {
                this.Controls["Label" + i].Visible = false;
                this.Controls["textBox" + i].Visible = false;
            }
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            admin_info();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            button7.Visible = false;
            kullanici_listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p5 = 0;
            button7.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ozel_temizleme();
            kitap_listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            for (int i = 1; i <= 8; i++) { this.Controls["Label" + i].Visible = true; }
            for (int i = 1; i <= 8; i++) { this.Controls["textBox" + i].Visible = true; }
            textBox1.Enabled = true;
            button9.Visible = false;
            button8.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p5 = 1;
            ozel_temizleme();            
            for (int i = 1; i <= 8; i++) { this.Controls["Label" + i].Visible = true; }
            for (int i = 1; i <= 8; i++) { this.Controls["textBox" + i].Visible = true; }
            textBox1.Enabled = false;
            button9.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p5 = 0;
            ozel_temizleme();
            button10.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kullanici_sil();
            k_id = "";
            kullanici_listele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                kitap_ekle();
                kitap_listele();
                for (int i = 1; i <= 8; i++) { this.Controls["textBox" + i].Text = ""; }
            }
            else MessageBox.Show("Kitap Eklemek için Eksiksiz Bilgilerin Girilmesi Gerekir!!!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                kitap_guncelle();
                kitap_listele();
                for (int i = 1; i <= 8; i++) { this.Controls["textBox" + i].Text = ""; }
            }
            else MessageBox.Show("Kitap Eklemek için Eksiksiz Bilgilerin Girilmesi Gerekir!!!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            kitap_sil();
            k_id = "";
            kitap_listele();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            admin_guncelle();
            admin_info();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen_satir = dataGridView1.CurrentRow.Index;
            if(p2==1)k_id=Convert.ToString(dataGridView1.Rows[secilen_satir].Cells[0].Value);
            else k_id = Convert.ToString(dataGridView1.Rows[secilen_satir].Cells[1].Value);
            if (p5==1)  for (int i = 1; i <= 8; i++) { this.Controls["textBox" + i].Text = Convert.ToString(dataGridView1.Rows[secilen_satir].Cells[i].Value); }
            this.Text = k_id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (p1 == 0)
            {
                if (p2 == 1)
                {
                    p2 = 0;
                    pictureBox2.Size = new Size(pictureBox2.Width + 20, pictureBox2.Height + 20);
                    kullanici_buton_gizle();
                }
                else if (p3 == 1)
                {
                    p3 = 0;
                    pictureBox3.Size = new Size(pictureBox3.Width + 20, pictureBox3.Height + 20);
                    kitap_buton_gizle();
                }
                p1 = 1;
                pictureBox1.Size = new Size(pictureBox1.Width - 20, pictureBox1.Height - 20);
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                button11.Visible = true;
             
            }
            else
            {
                p1 = 0;
                pictureBox1.Size = new Size(pictureBox1.Width + 20, pictureBox1.Height + 20);                
                admin_buton_gizle();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button13.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            admin_ata();
            k_id = "";
            kullanici_listele();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            user_ata();
            k_id = "";
            kullanici_listele();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button14.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (p2 == 0)
            {
                if (p3 == 1)
                {
                    p3 = 0;
                    pictureBox3.Size = new Size(pictureBox3.Width + 20, pictureBox3.Height + 20);
                    dataGridView1.DataSource = null;
                    ozel_temizleme();
                    kitap_buton_gizle();
                }
                else if (p1 == 1)
                {
                    p1 = 0;
                    pictureBox1.Size = new Size(pictureBox1.Width + 20, pictureBox1.Height + 20);               
                    admin_buton_gizle();
                }
                
                p2 = 1;
                pictureBox2.Size = new Size(pictureBox2.Width - 20, pictureBox2.Height - 20);
                dataGridView1.Size = new Size(660,780);
                button1.Visible = true;
                button2.Visible = true;
                button12.Visible = true;
                button15.Visible = true;
            }
            else
            {
                p2 = 0;
                pictureBox2.Size = new Size(pictureBox2.Width+20, pictureBox2.Height+20);
                kullanici_buton_gizle();
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (p3 == 0)
            {
                if (p2 == 1)
                {
                    p2 = 0;
                    pictureBox2.Size = new Size(pictureBox2.Width + 20, pictureBox2.Height + 20);
                    dataGridView1.DataSource = null;
                    button7.Visible = false;
                    kullanici_buton_gizle();
                }
                else if (p1 == 1)
                {
                    p1 = 0;
                    pictureBox1.Size = new Size(pictureBox1.Width + 20, pictureBox1.Height + 20);                   
                    admin_buton_gizle();
                }
                p3 = 1;
                pictureBox3.Size = new Size(pictureBox3.Width - 20, pictureBox3.Height - 20);
                dataGridView1.Size = new Size(860,670);
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
               
            }
            else
            {
                p3 = 0;
                pictureBox3.Size = new Size(pictureBox3.Width + 20, pictureBox3.Height + 20);
                ozel_temizleme();
                kitap_buton_gizle();
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 a = new Form2();
            a.Show();
        }
    }
}
