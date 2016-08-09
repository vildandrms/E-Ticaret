using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class register : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUyeOl_Click(object sender, EventArgs e)
        {
            string sayfasi=Request.QueryString["yonlendirme"];
            Kullanicilar k = new Kullanicilar();
            k.Ad = txtAd.Text.Trim();
            k.Soyad = txtSoyad.Text.Trim();
            k.Email = txtEmail.Text.Trim();
            k.Sifre = txtSifre.Text.Trim();
            try
            {
                ent.Kullanicilar.Add(k);
                ent.SaveChanges();
                YeniKulTemizle();
                Response.Redirect(sayfasi);
            }
            catch (Exception ex)
            {

                string hata = ex.Message;
            }

        }

        private void YeniKulTemizle()
        {
            txtAd.Text = "";
            txtEmail.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            txtGEmail.Text = "";
            txtGSifre.Text = "";
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string sayfasi = Request.QueryString["yonlendirme"];
            string mail = txtGEmail.Text.Trim();
            string sifre = txtGSifre.Text.Trim();
            var KKontrol = (from k in ent.Kullanicilar
                            where k.Email == mail && k.Sifre == sifre
                            select k).FirstOrDefault();
            if (KKontrol != null)
            {
                Session["kullanici"] = KKontrol.id;
                YeniKulTemizle();
                Response.Redirect(sayfasi);
            }
        }
    }
}