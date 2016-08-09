using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{

    public partial class kullanıcıIslemlerı : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string syf = "kullanıcıIslemleri.aspx";
                if (Session["kullanici"] != null)
                {
                    int ID = Convert.ToInt32(Session["kullanici"]);
                    if (KullaniciKontrol(ID))
                    {
 KullanicilariGetir();
                    }

                    else
                    {
                        Response.Redirect(string.Format("register.aspx?yonlendirme={0}", syf));
                    }

                }
                else
                {
                    Response.Redirect(string.Format("register.aspx?yonlendirme={0}", syf));
                }
               
            }
        }

        private bool KullaniciKontrol(int idsi)
        {
            bool sonuc;
            var admin = (from k in ent.Kullanicilar
                         where k.id == idsi
                         select k).FirstOrDefault();

            if (admin.Ad == "admin")
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }
            return sonuc;
        }
        private void KullanicilariGetir()
        {
            var kul = (from k in ent.Kullanicilar
                       select k).ToList();
            rptKullanıcılar.DataSource = kul;
            rptKullanıcılar.DataBind();
        }

        protected void btnYeniEkle_Click(object sender, EventArgs e)
        {
            pnlKullanıcıIslemlerı.Visible = true;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
           
            if (btnKaydet.Text=="Güncelle")
            {
                int ıd = Convert.ToInt32(lblId.Text);
                var Id = (from k in ent.Kullanicilar
                          where k.id == ıd
                          select k).FirstOrDefault();
                Id.Ad = txtAd.Text.Trim();
                Id.Soyad = txtSoyad.Text.Trim();
                Id.Telefon = Convert.ToInt32(txtTelefon.Text.Trim());
                Id.Adres = txtAdres.Text.Trim();
                Id.Sifre = txtSifre.Text.Trim();
                Id.Email = txtEmail.Text.Trim();               
                ent.SaveChanges();
                pnlKullanıcıIslemlerı.Visible = false;
                KullanicilariGetir();
            }
            Kullanicilar yeni = new Kullanicilar();
            yeni.Ad = txtAd.Text.Trim();
            yeni.Soyad = txtSoyad.Text.Trim();
            yeni.Telefon = Convert.ToInt32(txtTelefon.Text.Trim());
            yeni.Adres = txtAdres.Text.Trim();
            yeni.Sifre = txtSifre.Text.Trim();
            yeni.Email = txtEmail.Text.Trim();
            ent.Kullanicilar.Add(yeni);
            ent.SaveChanges();
            Temizle();
            pnlKullanıcıIslemlerı.Visible = false;
        }

        private void Temizle()
        {
            txtAd.Text = "";
            txtAdres.Text = "";
            txtEmail.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
        }

        protected void rptKullanıcılar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ıd = Convert.ToInt32(e.CommandArgument);
          
            var Id = (from k in ent.Kullanicilar
                                   where k.id == ıd
                                   select k).First();
            if (e.CommandName=="Sil")
            {
                ent.Kullanicilar.Remove(Id);
                ent.SaveChanges();
                KullanicilariGetir();
            }
            else if (e.CommandName=="Guncelle")
            {
                txtAd.Text= Id.Ad;
                txtSoyad.Text = Id.Soyad;
                txtAdres.Text = Id.Adres;
                txtEmail.Text = Id.Email;
                txtSifre.Text = Id.Sifre;
                txtTelefon.Text = Id.Telefon.ToString();
                btnKaydet.Text = "Güncelle";
                lblId.Text = ıd.ToString();
                pnlKullanıcıIslemlerı.Visible = true;
            }
        }
    }
}