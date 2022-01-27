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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string baglanti_bilgisi = "Data Source=DESKTOP-M4SIFD0;Initial Catalog=bookRead;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglanti_bilgisi);

        public int bas_deger=1;
        public int bit_deger=10;
        public int o_sayfa = 0;
        public int b_sayfa = 1;
        public int s_sayfa = 2;
        public int text_cntrl = 0;
        public int oy_say = 0;
        public int p1 = 0,p2 = 0, p3 = 0,p4= 0,p5 = 0,p6 = 0,p7 = 0,p8 = 0,p9 = 0,p10 = 0;
        public int b1 = 0, b2=0, b3 = 0;
        public string[] isbn = new string[10];
        public string[] yeni_kitap_isbn = new string[5];
        public string[] en_iyi_kitap_isbn = new string[10];
        public string[] en_pop_kitap_isbn = new string[10];
        public string[,] verilen_oy = new string[15, 3];
        public string[,] a_user_rating;
        public string[,] p_user_rating;
        public string[,] all_user_value;
        string[,] kitap;
        public int[] pre_userid;
        static public string secilen_ISBN;
        static public int pdf;
        public int listeleme = 0;
        public int kitap_sayisi=0;
        public int oneri_k_sayisi = 0;
        System.Drawing.Graphics nesne;
        System.Drawing.Graphics prof;
        Pen firca = new Pen(System.Drawing.Color.Red, 2);
       

        private void g_bilgi_ekle(string isbn, string oy,string pk) {
            int cn = 0,cn1=0,say=0;
            for (int i = 0; i < 15; i++) {
                if (verilen_oy[i, 0] == isbn) say++;
            }
            if (say == 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (verilen_oy[i, 0] == null && cn == 0)
                    {
                        verilen_oy[i, 0] = isbn;
                        verilen_oy[i, 1] = oy;
                        verilen_oy[i, 2] = pk;
                        cn = 1;
                    }
                }
            }
            else {
                for (int i = 0; i < 15; i++)
                {
                    if (verilen_oy[i, 0] == isbn && verilen_oy[i,1]!=oy && cn1 == 0)
                    {
                        verilen_oy[i, 1] = oy;
                        cn1 = 1;
                    }
                }
            }
        }

        private void g_bilgi_sil(string isbn)
        {
            for (int i = 0; i < 15; i++)
            {
                if (verilen_oy[i, 0] == isbn)
                {
                    verilen_oy[i, 0] = "";
                    verilen_oy[i, 1] ="";
                    verilen_oy[i, 2] = "";
                    verilen_oy[i, 3] = "";
                }
            }
        }

        private void g_bilgi_ara_duzenle() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 15; j++) {
                    if (isbn[i] == verilen_oy[j, 0]) {
                        if (verilen_oy[j, 2] == "p1") {
                            pictureBox1.Size = new Size(110, 190);
                            button4.Enabled = true;
                            button5.Enabled = true;
                            textBox2.Enabled = true;
                            textBox2.Text = verilen_oy[j, 1];                            
                            p1 = 1;
                        }
                        else if(verilen_oy[j, 2] == "p2") {
                            pictureBox2.Size = new Size(110, 190);
                            button6.Enabled = true;
                            button7.Enabled = true;
                            textBox3.Enabled = true;
                            textBox3.Text = verilen_oy[j, 1];
                            p2 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p3") {
                            pictureBox3.Size = new Size(110, 190);
                            button8.Enabled = true;
                            button9.Enabled = true;
                            textBox4.Enabled = true;
                            textBox4.Text = verilen_oy[j, 1];
                            p3 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p4") {
                            pictureBox4.Size = new Size(110, 190);
                            button10.Enabled = true;
                            button11.Enabled = true;
                            textBox5.Enabled = true;
                            textBox5.Text = verilen_oy[j, 1];
                            p4 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p5") {
                            pictureBox5.Size = new Size(110, 190);
                            button12.Enabled = true;
                            button13.Enabled = true;
                            textBox6.Enabled = true;
                            textBox6.Text = verilen_oy[j, 1];
                            p5 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p6") {
                            pictureBox6.Size = new Size(110, 190);
                            button14.Enabled = true;
                            button15.Enabled = true;
                            textBox7.Enabled = true;
                            textBox7.Text = verilen_oy[j, 1];
                            p6 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p7") {
                            pictureBox7.Size = new Size(110, 190);
                            button16.Enabled = true;
                            button17.Enabled = true;
                            textBox8.Enabled = true;
                            textBox8.Text = verilen_oy[j, 1];
                            p7 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p8") {
                            pictureBox8.Size = new Size(110, 190);
                            button18.Enabled = true;
                            button19.Enabled = true;
                            textBox9.Enabled = true;
                            textBox9.Text = verilen_oy[j, 1];
                            p8 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p9") {
                            pictureBox9.Size = new Size(110, 190);
                            button20.Enabled = true;
                            button21.Enabled = true;
                            textBox10.Enabled = true;
                            textBox10.Text = verilen_oy[j, 1];
                            p9 = 1;
                        }
                        else if (verilen_oy[j, 2] == "p10") {
                            pictureBox10.Size = new Size(110, 190);
                            button22.Enabled = true;
                            button23.Enabled = true;
                            textBox11.Enabled = true;
                            textBox11.Text = verilen_oy[j, 1];
                            p10 = 1;
                        }
                    }
                }
            }

            
        }

        private void temizle() {
            pictureBox1.Size = new Size(165, 228);
            pictureBox2.Size = new Size(165, 228);
            pictureBox3.Size = new Size(165, 228);
            pictureBox4.Size = new Size(165, 228);
            pictureBox5.Size = new Size(165, 228);
            pictureBox6.Size = new Size(165, 228);
            pictureBox7.Size = new Size(165, 228);
            pictureBox8.Size = new Size(165, 228);
            pictureBox9.Size = new Size(165, 228);
            pictureBox10.Size = new Size(165, 228);            
            for (int i = 4; i < 24; i++) { this.Controls["button" + i].Enabled = false; }
            for (int i = 2; i < 12; i++) { this.Controls["textBox" + i].Text = "0";this.Controls["textBox" + i].Enabled = false; }
            p1 = 0; p2 = 0; p3 = 0; p4 = 0; p5 = 0; p6 = 0; p7 = 0; p8 = 0; p9 = 0; p10 = 0;
        }

        private void clear()
        {
            for (int i = 0; i < 10; i++)
            {               
                this.Controls["Label" + ((i+1) + 1)].Text = "";
                this.Controls["Label" + ((i+1) + 11)].Text ="";
                if (i == 0) { pictureBox1.Image = null; }
                else if (i == 1) { pictureBox2.Image = null; }
                else if (i == 2) { pictureBox3.Image = null; }
                else if (i == 3) { pictureBox4.Image = null; }
                else if (i == 4) { pictureBox5.Image = null; }
                else if (i == 5) { pictureBox6.Image = null; }
                else if (i == 6) { pictureBox7.Image = null; }
                else if (i == 7) { pictureBox8.Image = null; }
                else if (i == 8) { pictureBox9.Image = null; }
                else if (i == 9) { pictureBox10.Image = null; }               
            }        
        }

        private void oylama_kontrolu(int oy) {
            if (oy >= 10)
            {
                label26.Text = "Oylamayı Bitirerek Kitap Okumaya Geçebilirsiniz !!!";
                label26.ForeColor = Color.Green;
                label25.ForeColor = Color.Green;
                label24.ForeColor = Color.Green;
                button3.Enabled = true;
                button3.ForeColor = Color.Green;
            }
            else {
                label26.Text = "Kitap Okuma İşlemi Gerçekleştirmek için En Az 10 Kitap Şeçilmelidir !!!";
                label26.ForeColor = Color.Red;
                label25.ForeColor = Color.Red;
                label24.ForeColor = Color.Red;
                button3.Enabled = false;
                button3.ForeColor = Color.Red;
            }
        }

        private void yeni_kullanici() {
            if (Form2.cntrl == 0)
            {                
                button24.Enabled = true;button25.Enabled = true; button26.Enabled = true; button27.Enabled = true; button28.Enabled = true; button29.Enabled = true;
                label24.Visible = false; label25.Visible = false; label26.Visible = false;
                for (int i = 3; i < 24; i++) this.Controls["button" + i].Visible = false;
                for (int i = 2; i < 12; i++) this.Controls["textBox" + i].Visible = false;
                pictureBox1.Location = new Point(pictureBox1.Location.X + 25, pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictureBox2.Location.X + 25, pictureBox2.Location.Y);
                pictureBox3.Location = new Point(pictureBox3.Location.X + 25, pictureBox3.Location.Y);
                pictureBox4.Location = new Point(pictureBox4.Location.X + 25, pictureBox4.Location.Y);
                pictureBox5.Location = new Point(pictureBox5.Location.X + 25, pictureBox5.Location.Y);
                pictureBox6.Location = new Point(pictureBox6.Location.X + 25, pictureBox6.Location.Y);
                pictureBox7.Location = new Point(pictureBox7.Location.X + 25, pictureBox7.Location.Y);
                pictureBox8.Location = new Point(pictureBox8.Location.X + 25, pictureBox8.Location.Y);
                pictureBox9.Location = new Point(pictureBox9.Location.X + 25, pictureBox9.Location.Y);
                pictureBox10.Location = new Point(pictureBox10.Location.X + 25, pictureBox10.Location.Y);
                for (int i = 2; i < 22; i++) { this.Controls["Label" + i].Location = new Point(this.Controls["Label" + i].Location.X + 25, this.Controls["Label" + i].Location.Y); }
                profil(0);
                tablo_ciz_anaEkran();
                
            }
            else {
                profil(0);
                tablo_ciz_anaEkran();                
                button25.Enabled = false;
            }            
        }

        private void tablo_ciz_anaEkran() {
            nesne = this.CreateGraphics();
            nesne.DrawLine(firca, 290, 56, 1430, 56);
            nesne.DrawLine(firca, 290, 55, 290, 731);
            nesne.DrawLine(firca, 290, 730, 1430, 730);
            nesne.DrawLine(firca, 1430, 55, 1430, 732);
            nesne.DrawLine(firca, 290, 380, 1430, 380);
            nesne.DrawLine(firca, 520, 56, 520, 731);
            nesne.DrawLine(firca, 750, 56, 750, 731);
            nesne.DrawLine(firca, 980, 56, 980, 731);
            nesne.DrawLine(firca, 1205, 56, 1205, 731);
        }

        private void profil(int x) {
            prof = this.CreateGraphics();
            prof.DrawLine(firca, 30, 56, 250, 56);
            prof.DrawLine(firca, 30, 290+x, 250, 290+x);
            prof.DrawLine(firca, 30, 56, 30, 290+x);
            prof.DrawLine(firca, 250, 56, 250, 290+x);

        }

        private void en_yeni_kitaplar()
        {
            int i = 0;
            SqlCommand komut = new SqlCommand("select top(5) * from BX_Books order by id desc", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                yeni_kitap_isbn[i] = dr["ISBN"].ToString();
                this.Controls["Label" + (i + 2)].Text = dr["Book_Title"].ToString();
                this.Controls["Label" + (i + 12)].Text="Yazarı:" ;
                this.Controls["Label" + (i + 12)].Text += dr["Book_Author"].ToString();
                if (i == 0) { pictureBox1.ImageLocation = dr["Image_URL_L"].ToString(); }
                else if (i == 1) { pictureBox2.ImageLocation = dr["Image_URL_L"].ToString(); }
                else if (i == 2) { pictureBox3.ImageLocation = dr["Image_URL_L"].ToString(); }
                else if (i == 3) { pictureBox4.ImageLocation = dr["Image_URL_L"].ToString(); }
                else if (i == 4) { pictureBox5.ImageLocation = dr["Image_URL_L"].ToString(); }
                i++;
            }
            baglanti.Close();
        }

        private void en_iyi_kitaplar() {
            int i = 0;
            SqlCommand komut = new SqlCommand("select top(10) ISBN,sum(Book_Rating) as Toplam_Oy, count(Book_Rating) as Tekrar_Kitap, avg(Book_Rating) as Ortalaması from BX_Book_Ratings group by ISBN order by Ortalaması desc", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                en_iyi_kitap_isbn[i] = dr["ISBN"].ToString();
                i++;
            }
            baglanti.Close();
        }

        private void en_pop_kitaplar()
        {
            int i = 0;
            SqlCommand komut = new SqlCommand("select top(10) ISBN,count(User_ID) as User_Say from BX_Book_Ratings group by ISBN order by User_Say desc", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                en_pop_kitap_isbn[i] = dr["ISBN"].ToString();
                i++;
            }
            baglanti.Close();
        }
        
        private void oneri_kitap_cagir(int bas, int bit)
        {            
            int k = 1;
            clear();
            for(int x = 1; x <= oneri_k_sayisi; x++)
            {
                SqlCommand komut = new SqlCommand("select * from BX_Books where ISBN='"+kitap[(x-1),0]+"'", baglanti);
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (x >= bas && x<= bit)
                    {                        
                        isbn[k - 1] = dr["ISBN"].ToString();
                        this.Controls["Label" + (k + 1)].Text = dr["Book_Title"].ToString();
                        this.Controls["Label" + (k + 11)].Text = "Yazarı:";
                        this.Controls["Label" + (k + 11)].Text += dr["Book_Author"].ToString();
                        if (k == 1) { pictureBox1.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 2) { pictureBox2.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 3) { pictureBox3.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 4) { pictureBox4.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 5) { pictureBox5.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 6) { pictureBox6.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 7) { pictureBox7.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 8) { pictureBox8.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 9) { pictureBox9.ImageLocation = dr["Image_URL_L"].ToString(); }
                        else if (k == 10) { pictureBox10.ImageLocation = dr["Image_URL_L"].ToString(); break; }
                        k++;
                    }
                }
                baglanti.Close();
            }
           
        }

        private void oneri_kitap_bul()
        {
            int i = 0, x = 0, kullanici_say = 0;
            double a_user_islem = 0, p_user_islem = 0, a_user_karekok = 0, p_user_karekok = 0, ortak_kitap_t_oy = 0, son_islem = 0, a_user_rating_avg = 0, p_user_rating_avg = 0, all_rating_avg = 0, tahmini_oy = 0;

            //---------------------------------Aktif Kullanıcı Bilgileri------------------------------------
            SqlCommand say = new SqlCommand("select count(*) from BX_Book_Ratings where User_ID='" + Form2.user_id + "'", baglanti);
            baglanti.Open();
            int a_user_oy_say = Convert.ToInt32(say.ExecuteScalar());
            baglanti.Close();
            a_user_rating = new string[a_user_oy_say, 2];
            SqlCommand komut = new SqlCommand("select * from BX_Book_Ratings where User_ID='" + Form2.user_id + "'", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                a_user_rating[i, 0] = dr["ISBN"].ToString();
                a_user_rating[i, 1] = dr["Book_Rating"].ToString();
                a_user_islem += Math.Pow(Convert.ToInt32(dr["Book_Rating"]), 2);
                a_user_rating_avg += Convert.ToInt32(dr["Book_Rating"]);
                i++;
            }
            baglanti.Close();
            a_user_karekok = Math.Sqrt(a_user_islem);
            a_user_rating_avg = a_user_rating_avg / i;
            //-----------------------------------------------------------------------------------------------------

            //--------------------------------Aktif Kullanıcının Oylağı Kitapları Oylayan ilişkili Userlar----------
            for (int j = 0; j < a_user_oy_say; j++)
            {
                SqlCommand dene = new SqlCommand("select count(User_ID) from BX_Book_Ratings where ISBN='" + a_user_rating[j, 0].ToString() + "'", baglanti);
                baglanti.Open();
                kullanici_say += Convert.ToInt32(dene.ExecuteScalar());
                baglanti.Close();
            }
            pre_userid = new int[kullanici_say];

            for (int j = 0; j < a_user_oy_say; j++)
            {
                int t = 0;
                SqlCommand dn = new SqlCommand("select User_ID from BX_Book_Ratings where ISBN='" + a_user_rating[j, 0] + "'", baglanti);
                baglanti.Open();
                SqlDataReader d = dn.ExecuteReader();
                while (d.Read())
                {
                    for (int z = 0; z < x; z++) if (pre_userid[z] == Convert.ToInt32(d["User_ID"])) t++;
                    if (t == 0) { pre_userid[x] = Convert.ToInt32(d["User_ID"]); x++; }
                    t = 0;
                }
                baglanti.Close();

            }
            x = 0;
            all_user_value = new string[kullanici_say, 3];
            for (int j = 0; j < kullanici_say; j++)
            {
                int k = 0;
                //------- İlişkili Kullanıcının Oyladigi Kitap Sayıları-------------------------------------------
                SqlCommand s = new SqlCommand("select count(*) from BX_Book_Ratings where User_ID='" + pre_userid[j] + "'", baglanti);
                baglanti.Open();
                int p_user_oy_say = Convert.ToInt32(s.ExecuteScalar());
                baglanti.Close();
                //------------------------------------------------------------------------------------------------

                if (p_user_oy_say != 0 && pre_userid[j] != Form2.user_id)
                {
                    p_user_rating = new string[p_user_oy_say, 2];
                    SqlCommand kmt = new SqlCommand("select * from BX_Book_Ratings where User_ID='" + pre_userid[j] + "'", baglanti);
                    baglanti.Open();
                    SqlDataReader d = kmt.ExecuteReader();
                    while (d.Read())
                    {
                        p_user_rating[k, 0] = d["ISBN"].ToString();
                        p_user_rating[k, 1] = d["Book_Rating"].ToString();
                        p_user_islem += Math.Pow(Convert.ToInt32(d["Book_Rating"]), 2);
                        p_user_rating_avg += Convert.ToInt32(d["Book_Rating"]);
                        k++;
                    }
                    baglanti.Close();
                    p_user_rating_avg = p_user_rating_avg / k;
                    if (p_user_islem != 0) p_user_karekok = Math.Sqrt(p_user_islem); else continue;
                    for (int n = 0; n < a_user_oy_say; n++)
                    {
                        for (int m = 0; m < p_user_oy_say; m++)
                        {
                            if (a_user_rating[n, 0].Trim() == p_user_rating[m, 0].Trim())
                            {
                                ortak_kitap_t_oy += Convert.ToDouble(a_user_rating[n, 1]) * Convert.ToDouble(p_user_rating[m, 1]);
                            }
                        }
                    }
                    if (ortak_kitap_t_oy != 0)
                    {
                        son_islem = ortak_kitap_t_oy / (a_user_karekok * p_user_karekok);                        
                        all_user_value[x, 0] = pre_userid[j].ToString();
                        all_user_value[x, 1] = son_islem.ToString();
                        all_user_value[x, 2] = p_user_rating_avg.ToString();
                        x++;
                    }
                    p_user_islem = 0;
                    p_user_rating_avg = 0;
                    ortak_kitap_t_oy = 0;

                }
            }
            //----------------------Bulunan Kosinüs Yakınlığı Değerlerinin Sıralanması-------------
            string kap_id = "", kap_deger = "",kap_avg="";
            for (int n = 0; n < x; n++)
            {
                for (int m = n + 1; m < x; m++)
                {
                    if (Convert.ToDouble(all_user_value[n, 1]) < Convert.ToDouble(all_user_value[m, 1]))
                    {
                        kap_id = all_user_value[m, 0];
                        kap_deger = all_user_value[m, 1];
                        kap_avg = all_user_value[m, 2];
                        all_user_value[m, 0] = all_user_value[n, 0];
                        all_user_value[m, 1] = all_user_value[n, 1];
                        all_user_value[m, 2] = all_user_value[n, 2];
                        all_user_value[n, 0] = kap_id;
                        all_user_value[n, 1] = kap_deger;
                        all_user_value[n, 2] = kap_avg;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------
           
            double[,] benzer_user_id = new double[x,3];
            for (int a = 0; a < x; a++)
            {
               benzer_user_id[a, 0] = Convert.ToDouble(all_user_value[a, 0]); benzer_user_id[a, 1] = Convert.ToDouble(all_user_value[a, 1]); benzer_user_id[a, 2] = Convert.ToDouble(all_user_value[a, 2]);
                all_rating_avg += Convert.ToDouble(all_user_value[a, 1]);
            }
            all_rating_avg /= x;

            int oneri_say = 0;

            for (int a = 0; a < x; a++)
            {
                SqlCommand s = new SqlCommand("select count(*) from BX_Book_Ratings where User_ID='" +Convert.ToInt32(benzer_user_id[a,0]) + "'", baglanti);
                baglanti.Open();
                oneri_say += Convert.ToInt32(s.ExecuteScalar());
                baglanti.Close();
            }
            kitap = new string[oneri_say,2];            
            int u = 0;
            for (int a = 0; a < x; a++)
            {
                int t = 0;
                SqlCommand s = new SqlCommand("select * from BX_Book_Ratings where User_ID='" + Convert.ToInt32(benzer_user_id[a, 0]) + "'", baglanti);
                baglanti.Open();
                SqlDataReader oku = s.ExecuteReader();
                while (oku.Read())
                {
                    for (int z = 0; z < a_user_oy_say; z++) if (a_user_rating[z, 0] == oku["ISBN"].ToString()) t++;
                    for (int z = 0; z < u; z++) if (kitap[z,0] == oku["ISBN"].ToString()) t++;
                    if (t == 0) { kitap[u,0] = oku["ISBN"].ToString();
                        tahmini_oy = a_user_rating_avg + (((Convert.ToInt32(oku["Book_Rating"]) - benzer_user_id[a, 2]) * benzer_user_id[a, 1]) / all_rating_avg);
                        kitap[u, 1] = tahmini_oy.ToString();
                        u++;
                    }
                    t = 0;
                }
                baglanti.Close();
            }
            string kap_isbn = "", kap_oy = "";
            for (int n = 0; n < u; n++)
            {
                for (int m = n + 1; m < u; m++)
                {
                    if (Convert.ToDouble(kitap[n, 1]) < Convert.ToDouble(kitap[m, 1]))
                    {
                        kap_isbn = kitap[m, 0];
                        kap_oy = kitap[m, 1];
                        kitap[m, 0] = kitap[n, 0];
                        kitap[m, 1] = kitap[n, 1];
                        kitap[n, 0] = kap_isbn;
                        kitap[n, 1] = kap_oy;
                    }
                }
            }
            oneri_k_sayisi = u;
        }

        private void kitap_cagir(int bas, int bit)
        {
            int i = 1, k = 1;
            SqlCommand komut = new SqlCommand("select * from BX_Books order by id", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (i >= bas && i <= bit)
                {
                    isbn[k - 1] = dr["ISBN"].ToString();
                    this.Controls["Label" + (k + 1)].Text = dr["Book_Title"].ToString();
                    this.Controls["Label" + (k + 11)].Text = "Yazarı:";
                    this.Controls["Label" + (k + 11)].Text += dr["Book_Author"].ToString();
                    if (k == 1) { pictureBox1.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 2) { pictureBox2.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 3) { pictureBox3.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 4) { pictureBox4.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 5) { pictureBox5.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 6) { pictureBox6.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 7) { pictureBox7.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 8) { pictureBox8.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 9) { pictureBox9.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (k == 10) { pictureBox10.ImageLocation = dr["Image_URL_L"].ToString(); break; }
                    k++;
                }
                i++;
            }
            baglanti.Close();

        }

        private void kitap_say() {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select count(*) from BX_Books",baglanti);
            kitap_sayisi = Convert.ToInt32(komut.ExecuteScalar())+1;
            baglanti.Close();
        }

        private void user_info() {
            SqlCommand komut = new SqlCommand("select * from BX_Users where User_ID='"+Form2.user_id+"'", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                textBox12.Text = dr["U_Name"].ToString();
                textBox13.Text = dr["Password"].ToString();
                string a=dr["Location"].ToString();
                string[] b = a.Split(',');                
                for (int i = 0; i < b.Length; i++) { this.Controls["textBox" + (i+14)].Text = b[i].ToString(); }                
                textBox17.Text = dr["Age"].ToString();
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   label1.Text = "";
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
            button24.Enabled = false;button26.Enabled = false;button27.Enabled = false; button28.Enabled = false; button29.Enabled = false;
            kitap_say();          
            yeni_kullanici();
            kitap_cagir(bas_deger, bit_deger);
            pictureBox11.Image = Image.FromFile(@"C:\Users\Y.KAMCI\Desktop\yaz_lab1_proje1\yaz_lab1_proje1\img\usr.png");            
            user_info();
        }            

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listeleme == 0)
            {
                if (textBox1.Text != "" && (Convert.ToInt32(textBox1.Text) >= 1 && Convert.ToInt32(textBox1.Text) <= kitap_sayisi / 10))
                {
                    int text_deger = Convert.ToInt32(textBox1.Text);
                    if (Form2.cntrl == 1) temizle();
                    bas_deger = (text_deger * 10) - 10;
                    bit_deger = (text_deger * 10);
                    b_sayfa = Convert.ToInt32(textBox1.Text);
                    o_sayfa = Convert.ToInt32(textBox1.Text) - 1; label1.Text = o_sayfa.ToString();
                    s_sayfa = Convert.ToInt32(textBox1.Text) + 1; label23.Text = s_sayfa.ToString();
                    kitap_cagir(bas_deger, bit_deger);
                    if (Form2.cntrl == 1) g_bilgi_ara_duzenle();
                }
                else MessageBox.Show("Girilen Değer Sıfıra Eşit, Boş veya Toplam Sayfa Sayısından Fazla Girilemez!!!");
            }
            else
            {
                if (textBox1.Text != "" && (Convert.ToInt32(textBox1.Text) >= 1 && Convert.ToInt32(textBox1.Text) <= oneri_k_sayisi / 10))
                {
                    int text_deger = Convert.ToInt32(textBox1.Text);
                    bas_deger = (text_deger * 10) - 10;
                    bit_deger = (text_deger * 10);
                    b_sayfa = Convert.ToInt32(textBox1.Text);
                    o_sayfa = Convert.ToInt32(textBox1.Text) - 1; label1.Text = o_sayfa.ToString();
                    s_sayfa = Convert.ToInt32(textBox1.Text) + 1; label23.Text = s_sayfa.ToString();
                    oneri_kitap_cagir(bas_deger, bit_deger);                    
                }
                else MessageBox.Show("Girilen Değer Sıfıra Eşit, Boş veya Toplam Sayfa Sayısından Fazla Girilemez!!!");
                
            }
        }


        /*Button olayları*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (p1 == 1) { g_bilgi_ekle(isbn[0], textBox2.Text, "p1"); }
            if (p2 == 1) { g_bilgi_ekle(isbn[1], textBox3.Text, "p2"); }
            if (p3 == 1) { g_bilgi_ekle(isbn[2], textBox4.Text, "p3"); }
            if (p4 == 1) { g_bilgi_ekle(isbn[3], textBox5.Text, "p4"); }
            if (p5 == 1) { g_bilgi_ekle(isbn[4], textBox6.Text, "p5"); }
            if (p6 == 1) { g_bilgi_ekle(isbn[5], textBox7.Text, "p6"); }
            if (p7 == 1) { g_bilgi_ekle(isbn[6], textBox8.Text, "p7"); }
            if (p8 == 1) { g_bilgi_ekle(isbn[7], textBox9.Text, "p8"); }
            if (p9 == 1) { g_bilgi_ekle(isbn[8], textBox10.Text, "p9"); }
            if (p10 == 1) { g_bilgi_ekle(isbn[9], textBox11.Text, "p10"); }
            if (Form2.cntrl == 1) temizle();
            if (bas_deger > 1)
            {
                bit_deger -= 10;
                bas_deger -= 10;               
            }
            if (o_sayfa > 0) { o_sayfa--; label1.Text = ""; }
            if(b_sayfa>1)b_sayfa--;
            if(s_sayfa>2)s_sayfa--;            
            label1.Text = o_sayfa.ToString();
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
            if (listeleme == 0) kitap_cagir(bas_deger, bit_deger); else oneri_kitap_cagir(bas_deger, bit_deger);
            if (Form2.cntrl == 1) g_bilgi_ara_duzenle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p1 == 1) { g_bilgi_ekle(isbn[0], textBox2.Text,"p1"); }
            if (p2 == 1) { g_bilgi_ekle(isbn[1], textBox3.Text, "p2"); }
            if (p3 == 1) { g_bilgi_ekle(isbn[2], textBox4.Text, "p3"); }
            if (p4 == 1) { g_bilgi_ekle(isbn[3], textBox5.Text, "p4"); }
            if (p5 == 1) { g_bilgi_ekle(isbn[4], textBox6.Text, "p5"); }
            if (p6 == 1) { g_bilgi_ekle(isbn[5], textBox7.Text, "p6"); }
            if (p7 == 1) { g_bilgi_ekle(isbn[6], textBox8.Text, "p7"); }
            if (p8 == 1) { g_bilgi_ekle(isbn[7], textBox9.Text, "p8"); }
            if (p9 == 1) { g_bilgi_ekle(isbn[8], textBox10.Text, "p9"); }
            if (p10 == 1) { g_bilgi_ekle(isbn[9], textBox11.Text, "p10"); }
            if (Form2.cntrl == 1)temizle();            
                bas_deger += 10;
                bit_deger += 10;
                o_sayfa++;
                b_sayfa++;
                s_sayfa++;
                label1.Text = o_sayfa.ToString();
                textBox1.Text = b_sayfa.ToString();
                label23.Text = s_sayfa.ToString();
             if (listeleme == 0) kitap_cagir(bas_deger, bit_deger);  else oneri_kitap_cagir(bas_deger, bit_deger);           
            if (Form2.cntrl == 1) g_bilgi_ara_duzenle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            label24.Visible = false;            
            label26.Visible = false;
            label25.Visible = false;
            button24.Enabled = true;            
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            if (p1 == 1) { g_bilgi_ekle(isbn[0], textBox2.Text, "p1"); }
            if (p2 == 1) { g_bilgi_ekle(isbn[1], textBox3.Text, "p2"); }
            if (p3 == 1) { g_bilgi_ekle(isbn[2], textBox4.Text, "p3"); }
            if (p4 == 1) { g_bilgi_ekle(isbn[3], textBox5.Text, "p4"); }
            if (p5 == 1) { g_bilgi_ekle(isbn[4], textBox6.Text, "p5"); }
            if (p6 == 1) { g_bilgi_ekle(isbn[5], textBox7.Text, "p6"); }
            if (p7 == 1) { g_bilgi_ekle(isbn[6], textBox8.Text, "p7"); }
            if (p8 == 1) { g_bilgi_ekle(isbn[7], textBox9.Text, "p8"); }
            if (p9 == 1) { g_bilgi_ekle(isbn[8], textBox10.Text, "p9"); }
            if (p10 == 1) { g_bilgi_ekle(isbn[9], textBox11.Text, "p10"); }
            for (int i = 0; i < oy_say; i++)
            {
                if (verilen_oy[i, 0] != null) {
                   SqlCommand veri_kayit = new SqlCommand("insert into BX_Book_Ratings (User_ID,ISBN,Book_Rating) values('"+Form2.user_id+"','"+verilen_oy[i,0]+"','"+verilen_oy[i,1]+"')", baglanti);
                   baglanti.Open();
                    veri_kayit.ExecuteNonQuery();
                    baglanti.Close();
                }              
            }         
            for (int i = 3; i < 24; i++) this.Controls["button" + i].Visible = false;
            for (int i = 2; i < 12; i++) this.Controls["textBox" + i].Visible = false;
            pictureBox1.Location = new Point(pictureBox1.Location.X + 25, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(pictureBox2.Location.X + 25, pictureBox2.Location.Y);
            pictureBox3.Location = new Point(pictureBox3.Location.X + 25, pictureBox3.Location.Y);
            pictureBox4.Location = new Point(pictureBox4.Location.X + 25, pictureBox4.Location.Y);
            pictureBox5.Location = new Point(pictureBox5.Location.X + 25, pictureBox5.Location.Y);
            pictureBox6.Location = new Point(pictureBox6.Location.X + 25, pictureBox6.Location.Y);
            pictureBox7.Location = new Point(pictureBox7.Location.X + 25, pictureBox7.Location.Y);
            pictureBox8.Location = new Point(pictureBox8.Location.X + 25, pictureBox8.Location.Y);
            pictureBox9.Location = new Point(pictureBox9.Location.X + 25, pictureBox9.Location.Y);
            pictureBox10.Location = new Point(pictureBox10.Location.X + 25, pictureBox10.Location.Y);
            pictureBox1.Size = new Size(165, 228);
            pictureBox2.Size = new Size(165, 228);
            pictureBox3.Size = new Size(165, 228);
            pictureBox4.Size = new Size(165, 228);
            pictureBox5.Size = new Size(165, 228);
            pictureBox6.Size = new Size(165, 228);
            pictureBox7.Size = new Size(165, 228);
            pictureBox8.Size = new Size(165, 228);
            pictureBox9.Size = new Size(165, 228);
            pictureBox10.Size = new Size(165, 228);
            for (int i = 2; i < 22; i++) { this.Controls["Label" + i].Location = new Point(this.Controls["Label" + i].Location.X + 25, this.Controls["Label" + i].Location.Y); }
            Form2.cntrl = 0;            
            button25.Enabled = true;
            bas_deger = 1;
            bit_deger = 10;
            kitap_cagir(bas_deger,bit_deger);
            o_sayfa=0;
            b_sayfa=1;
            s_sayfa=2;
            label1.Text = "";
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox2.Text)!=10)textBox2.Text=(Convert.ToInt32(textBox2.Text)+1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) != 0) textBox2.Text = (Convert.ToInt32(textBox2.Text) - 1).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) != 10) textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) != 0) textBox3.Text = (Convert.ToInt32(textBox3.Text) - 1).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) != 10) textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) != 0) textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) != 10) textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) != 0) textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox6.Text) != 10) textBox6.Text = (Convert.ToInt32(textBox6.Text) + 1).ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox6.Text) != 0) textBox6.Text = (Convert.ToInt32(textBox6.Text) - 1).ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox7.Text) != 10) textBox7.Text = (Convert.ToInt32(textBox7.Text) + 1).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox7.Text) != 0) textBox7.Text = (Convert.ToInt32(textBox7.Text) - 1).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox8.Text) != 10) textBox8.Text = (Convert.ToInt32(textBox8.Text) + 1).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox8.Text) != 0) textBox8.Text = (Convert.ToInt32(textBox8.Text) - 1).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox9.Text) != 10) textBox9.Text = (Convert.ToInt32(textBox9.Text) + 1).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox9.Text) != 0) textBox9.Text = (Convert.ToInt32(textBox9.Text) - 1).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox10.Text) != 10) textBox10.Text = (Convert.ToInt32(textBox10.Text) + 1).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox10.Text) != 0) textBox10.Text = (Convert.ToInt32(textBox10.Text) - 1).ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox11.Text) != 10) textBox11.Text = (Convert.ToInt32(textBox11.Text) + 1).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox11.Text) != 0) textBox11.Text = (Convert.ToInt32(textBox11.Text) - 1).ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            b1 = 1;b2 = 0;b3 = 0;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            label23.Visible = false;
            nesne.Clear(Form.DefaultBackColor);
            profil(0);
            nesne = this.CreateGraphics();
            nesne.DrawLine(firca, 300, 56, 1430, 56);
            nesne.DrawLine(firca, 300, 400, 1430, 400);
            nesne.DrawLine(firca, 300, 56, 300, 400);
            nesne.DrawLine(firca, 520, 56, 520, 400);
            nesne.DrawLine(firca, 740, 56, 740, 400);
            nesne.DrawLine(firca, 975, 56, 975, 400);
            nesne.DrawLine(firca, 1200, 56, 1200, 400);
            nesne.DrawLine(firca, 1430, 56, 1430, 400);
            en_yeni_kitaplar();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            b2 = 1;b1 = 0;b3 = 0;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            label23.Visible = false;
            nesne.Clear(Form.DefaultBackColor);
            tablo_ciz_anaEkran();
            profil(0);
            en_iyi_kitaplar();
            for (int i = 0; i < 10; i++)
            {
                SqlCommand komut = new SqlCommand("select * from BX_Books where ISBN='" + en_iyi_kitap_isbn[i] + "'", baglanti);
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    this.Controls["Label" + (i + 2)].Text = dr["Book_Title"].ToString();
                    this.Controls["Label" + (i + 12)].Text = "";
                    this.Controls["Label" + (i + 12)].Text += dr["Book_Author"].ToString();
                    if (i == 0) { pictureBox1.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 1) { pictureBox2.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 2) { pictureBox3.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 3) { pictureBox4.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 4) { pictureBox5.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 5) { pictureBox6.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 6) { pictureBox7.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 7) { pictureBox8.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 8) { pictureBox9.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 9) { pictureBox10.ImageLocation = dr["Image_URL_L"].ToString(); }
                }
                baglanti.Close();
            }

        }

        private void button27_Click(object sender, EventArgs e)
        {
            b3 = 1;b1 = 0;b2 = 0;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            label23.Visible = false;
            nesne.Clear(Form.DefaultBackColor);
            tablo_ciz_anaEkran();
            profil(0);
            en_pop_kitaplar();
            for (int i = 0; i < 10; i++)
            {
                SqlCommand komut = new SqlCommand("select * from BX_Books where ISBN='" + en_pop_kitap_isbn[i] + "'", baglanti);
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    this.Controls["Label" + (i + 2)].Text = dr["Book_Title"].ToString();
                    this.Controls["Label" + (i + 12)].Text = "";
                    this.Controls["Label" + (i + 12)].Text += dr["Book_Author"].ToString();
                    if (i == 0) { pictureBox1.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 1) { pictureBox2.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 2) { pictureBox3.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 3) { pictureBox4.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 4) { pictureBox5.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 5) { pictureBox6.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 6) { pictureBox7.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 7) { pictureBox8.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 8) { pictureBox9.ImageLocation = dr["Image_URL_L"].ToString(); }
                    else if (i == 9) { pictureBox10.ImageLocation = dr["Image_URL_L"].ToString(); }
                }
                baglanti.Close();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            b1 = 0;b2 = 0;b3 = 0;
            listeleme = 0;
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button34.Visible = true;
            button35.Visible = true;
            label1.Visible = true;
            label23.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            nesne.Clear(Form.DefaultBackColor);
            tablo_ciz_anaEkran();
            profil(0);
            bas_deger = 1;
            bit_deger = 10;
            o_sayfa = 0;
            b_sayfa = 1;
            s_sayfa = 2;
            label1.Text = "";
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
            kitap_cagir(bas_deger, bit_deger);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            b1 = 0; b2 = 0; b3 = 0;
            listeleme = 1;
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button34.Visible = true;
            button35.Visible = true;
            label1.Visible = true;
            label23.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            tablo_ciz_anaEkran();
            profil(0);
            bas_deger = 1;
            bit_deger = 10;
            o_sayfa = 0;
            b_sayfa = 1;
            s_sayfa = 2;
            label1.Text = "";
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
            oneri_kitap_bul();
            oneri_kitap_cagir(bas_deger, bit_deger);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            prof.Clear(Form.DefaultBackColor);
            label22.Visible = true;
            for (int i = 27; i <= 31; i++) this.Controls["Label" + i].Visible = true;
            for (int i = 12; i <= 17; i++) this.Controls["textBox" + i].Visible = true;
            button30.Visible = false; button31.Visible = true; button32.Visible = true; button33.Visible = true;
            profil(225);
            tablo_ciz_anaEkran();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            prof.Clear(Form.DefaultBackColor);
            label22.Visible = false;
            for (int i = 27; i <= 31; i++) this.Controls["Label" + i].Visible = false;
            for (int i = 12; i <= 17; i++) this.Controls["textBox" + i].Visible = false;
            button30.Visible = true; button31.Visible = false; button32.Visible = false; button33.Visible = false;
            profil(0);
            tablo_ciz_anaEkran();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "" && textBox13.Text != "")
            {
                string loc = textBox14.Text + "," + textBox15.Text + "," + textBox16.Text;
                SqlCommand komut = new SqlCommand("update BX_Users set U_Name='" + textBox12.Text + "', Password='" + textBox13.Text + "', Location='" + loc + "', Age='" + textBox17.Text + "' where User_ID='" + Form2.user_id + "'", baglanti);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kişisel Bilgiler Güncellenmiştir...");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            prof.Clear(Form.DefaultBackColor);
            label22.Visible = false;
            for (int i = 27; i <= 31; i++) this.Controls["Label" + i].Visible = false;
            for (int i = 12; i <= 17; i++) this.Controls["textBox" + i].Visible = false;
            button30.Visible = true; button31.Visible = false; button32.Visible = false; button33.Visible = false;
            profil(0);
            tablo_ciz_anaEkran();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (p1 == 1) { g_bilgi_ekle(isbn[0], textBox2.Text, "p1"); }
            if (p2 == 1) { g_bilgi_ekle(isbn[1], textBox3.Text, "p2"); }
            if (p3 == 1) { g_bilgi_ekle(isbn[2], textBox4.Text, "p3"); }
            if (p4 == 1) { g_bilgi_ekle(isbn[3], textBox5.Text, "p4"); }
            if (p5 == 1) { g_bilgi_ekle(isbn[4], textBox6.Text, "p5"); }
            if (p6 == 1) { g_bilgi_ekle(isbn[5], textBox7.Text, "p6"); }
            if (p7 == 1) { g_bilgi_ekle(isbn[6], textBox8.Text, "p7"); }
            if (p8 == 1) { g_bilgi_ekle(isbn[7], textBox9.Text, "p8"); }
            if (p9 == 1) { g_bilgi_ekle(isbn[8], textBox10.Text, "p9"); }
            if (p10 == 1) { g_bilgi_ekle(isbn[9], textBox11.Text, "p10"); }
            if (Form2.cntrl == 1) temizle();
            if (listeleme == 0)
            {
                bas_deger = kitap_sayisi - 10;
                bit_deger = kitap_sayisi;
                o_sayfa = kitap_sayisi /10 - 1;
                b_sayfa = kitap_sayisi / 10;
            }
            else {
                bas_deger = oneri_k_sayisi - 10;
                bit_deger = oneri_k_sayisi;
                o_sayfa = oneri_k_sayisi /10-1;
                b_sayfa = oneri_k_sayisi / 10;                
            }
            label1.Text = o_sayfa.ToString();
            textBox1.Text = b_sayfa.ToString();
            label23.Text = "";
            if (listeleme == 0) kitap_cagir(bas_deger, bit_deger); else oneri_kitap_cagir(bas_deger, bit_deger);
            if (Form2.cntrl == 1) g_bilgi_ara_duzenle();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (p1 == 1) { g_bilgi_ekle(isbn[0], textBox2.Text, "p1"); }
            if (p2 == 1) { g_bilgi_ekle(isbn[1], textBox3.Text, "p2"); }
            if (p3 == 1) { g_bilgi_ekle(isbn[2], textBox4.Text, "p3"); }
            if (p4 == 1) { g_bilgi_ekle(isbn[3], textBox5.Text, "p4"); }
            if (p5 == 1) { g_bilgi_ekle(isbn[4], textBox6.Text, "p5"); }
            if (p6 == 1) { g_bilgi_ekle(isbn[5], textBox7.Text, "p6"); }
            if (p7 == 1) { g_bilgi_ekle(isbn[6], textBox8.Text, "p7"); }
            if (p8 == 1) { g_bilgi_ekle(isbn[7], textBox9.Text, "p8"); }
            if (p9 == 1) { g_bilgi_ekle(isbn[8], textBox10.Text, "p9"); }
            if (p10 == 1) { g_bilgi_ekle(isbn[9], textBox11.Text, "p10"); }
            if (Form2.cntrl == 1) temizle();
            bas_deger = 1;
            bit_deger = 10;
            o_sayfa = 0;
            b_sayfa = 1;
            s_sayfa = 2;
            label1.Text = "";
            textBox1.Text = b_sayfa.ToString();
            label23.Text = s_sayfa.ToString();
            if (listeleme == 0) kitap_cagir(bas_deger, bit_deger); else oneri_kitap_cagir(bas_deger, bit_deger);
            if (Form2.cntrl == 1) g_bilgi_ara_duzenle();
        }


        /*picturebox olayları*/



        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[0];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[0];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[0];
                else secilen_ISBN = isbn[0];
                pdf = 1;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[1];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[1];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[1];
                else secilen_ISBN = isbn[1];
                pdf = 2;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[2];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[2];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[2];
                else secilen_ISBN = isbn[2];
                pdf = 3;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[3];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[3];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[3];
                else secilen_ISBN = isbn[3];
                pdf = 4;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[4];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[4];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[4];
                else secilen_ISBN = isbn[4];
                pdf = 5;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[5];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[5];
                else secilen_ISBN = isbn[5];
                pdf = 6;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b1 == 1) secilen_ISBN = yeni_kitap_isbn[6];
                else if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[6];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[6];
                else secilen_ISBN = isbn[6];
                pdf = 7;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[7];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[7];
                else secilen_ISBN = isbn[7];
                pdf = 8;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox9_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[8];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[8];
                else secilen_ISBN = isbn[8];
                pdf = 9;
                Form3 a = new Form3();
                a.Show();
            }
        }

        private void pictureBox10_DoubleClick(object sender, EventArgs e)
        {
            if (Form2.cntrl == 0)
            {
                if (b2 == 1) secilen_ISBN = en_iyi_kitap_isbn[9];
                else if (b3 == 1) secilen_ISBN = en_pop_kitap_isbn[9];
                else secilen_ISBN = isbn[0];
                pdf = 10;
                Form3 a = new Form3();
                a.Show();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p1 == 0)
                {
                    pictureBox1.Size = new Size(110, 190);
                    button4.Enabled = true;
                    button5.Enabled = true;
                    textBox2.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p1 = 1;
                }
                else
                {
                    pictureBox1.Size = new Size(165, 228);
                    button4.Enabled = false;
                    button5.Enabled = false;
                    textBox2.Enabled = false;
                    textBox2.Text = "0";
                    g_bilgi_sil(isbn[0]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p1 = 0;

                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p2 == 0)
                {
                    pictureBox2.Size = new Size(110, 190);
                    button6.Enabled = true;
                    button7.Enabled = true;
                    textBox3.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p2 = 1;

                }
                else
                {
                    pictureBox2.Size = new Size(165, 228);
                    button6.Enabled = false;
                    button7.Enabled = false;
                    textBox3.Enabled = false;
                    g_bilgi_sil(isbn[1]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    textBox3.Text = "0";
                    p2 = 0;

                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p3 == 0)
                {
                    pictureBox3.Size = new Size(110, 190);
                    button8.Enabled = true;
                    button9.Enabled = true;
                    textBox4.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p3 = 1;

                }
                else
                {
                    pictureBox3.Size = new Size(165, 228);
                    button8.Enabled = false;
                    button9.Enabled = false;
                    textBox4.Enabled = false;
                    textBox4.Text = "0";
                    g_bilgi_sil(isbn[2]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p3 = 0;

                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p4 == 0)
                {
                    pictureBox4.Size = new Size(110, 190);
                    button10.Enabled = true;
                    button11.Enabled = true;
                    textBox5.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p4 = 1;
                }
                else
                {
                    pictureBox4.Size = new Size(165, 228);
                    button10.Enabled = false;
                    button11.Enabled = false;
                    textBox5.Enabled = false;
                    textBox5.Text = "0";
                    g_bilgi_sil(isbn[3]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p4 = 0;

                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p5 == 0)
                {
                    pictureBox5.Size = new Size(110, 190);
                    button12.Enabled = true;
                    button13.Enabled = true;
                    textBox6.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p5 = 1;
                }
                else
                {
                    pictureBox5.Size = new Size(165, 228);
                    button12.Enabled = false;
                    button13.Enabled = false;
                    textBox6.Enabled = false;
                    textBox6.Text = "0";
                    g_bilgi_sil(isbn[4]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p1 = 0;

                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p6 == 0)
                {
                    pictureBox6.Size = new Size(110, 190);
                    button14.Enabled = true;
                    button15.Enabled = true;
                    textBox7.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p6 = 1;
                }
                else
                {
                    pictureBox6.Size = new Size(165, 228);
                    button14.Enabled = false;
                    button15.Enabled = false;
                    textBox7.Enabled = false;
                    textBox7.Text = "0";
                    g_bilgi_sil(isbn[5]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p6 = 0;
                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p7 == 0)
                {
                    pictureBox7.Size = new Size(110, 190);
                    button16.Enabled = true;
                    button17.Enabled = true;
                    textBox8.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p7 = 1;
                }
                else
                {
                    pictureBox7.Size = new Size(165, 228);
                    button16.Enabled = false;
                    button17.Enabled = false;
                    textBox8.Enabled = false;
                    textBox8.Text = "0";
                    g_bilgi_sil(isbn[6]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p7 = 0;
                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p8 == 0)
                {
                    pictureBox8.Size = new Size(110, 190);
                    button18.Enabled = true;
                    button19.Enabled = true;
                    textBox9.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p8 = 1;
                }
                else
                {
                    pictureBox8.Size = new Size(165, 228);
                    button18.Enabled = false;
                    button19.Enabled = false;
                    textBox9.Enabled = false;
                    textBox9.Text = "9";
                    g_bilgi_sil(isbn[7]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p8 = 0;
                }
                label25.Text = oy_say.ToString();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p9 == 0)
                {
                    pictureBox9.Size = new Size(110, 190);
                    button20.Enabled = true;
                    button21.Enabled = true;
                    textBox10.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p9 = 1;
                }
                else
                {
                    pictureBox9.Size = new Size(165, 228);
                    button20.Enabled = false;
                    button21.Enabled = false;
                    textBox10.Enabled = false;
                    textBox10.Text = "0";
                    g_bilgi_sil(isbn[8]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p9 = 0;
                }
                label25.Text = oy_say.ToString();
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (Form2.cntrl == 1)
            {
                if (p10 == 0)
                {
                    pictureBox10.Size = new Size(110, 190);
                    button22.Enabled = true;
                    button23.Enabled = true;
                    textBox11.Enabled = true;
                    oy_say++;
                    oylama_kontrolu(oy_say);
                    p10 = 1;
                }
                else
                {
                    pictureBox10.Size = new Size(165, 228);
                    button22.Enabled = false;
                    button23.Enabled = false;
                    textBox11.Enabled = false;
                    textBox11.Text = "0";
                    g_bilgi_sil(isbn[9]);
                    oy_say--;
                    oylama_kontrolu(oy_say);
                    p10 = 0;
                }
                label25.Text = oy_say.ToString();
            }
        }
    }
}
