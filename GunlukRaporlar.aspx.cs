using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class GunlukRaporlar : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBaşlangic.Text = DateTime.Now.ToShortDateString();
            txtBitisTrh.Text = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                string syf = "GunlukRaporlar.aspx";
                if (Session["kullanici"] != null)
                {
                    int ID = Convert.ToInt32(Session["kullanici"]);
                    if (KullaniciKontrol(ID))
                    {
                      
                        SorguGetir(Convert.ToDateTime(txtBaşlangic.Text), Convert.ToDateTime(txtBitisTrh.Text));
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
    private void SorguGetir(DateTime bas, DateTime bit)
        {
            var sorgu = (from s in ent.Satıslar
                         join k in ent.Kullanicilar on s.KullaniciId equals k.id
                         where s.SiparisTarih >= bas && s.SiparisTarih <= bit
                         select new {s.id,s.KargoAd,s.LastName,s.Name,s.Telefon,s.Tutar,s.Adet,s.Adres,s.Email,k.Ad,k.Soyad, s.SiparisTarih}).ToList();
            rptRaporlar.DataSource = sorgu;
            rptRaporlar.DataBind();
        }

        protected void txtBaşlangic_TextChanged(object sender, EventArgs e)
        {
             CdBaslangicTrh.Visible = true;
           

        }

        protected void CdBaslangicTrh_SelectionChanged(object sender, EventArgs e)
        {
            txtBaşlangic.Text = CdBaslangicTrh.SelectedDate.ToShortDateString();
            CdBaslangicTrh.Visible = false;
            if (txtBaşlangic.Text.Trim() != null)
            {
                SorguGetir(Convert.ToDateTime(txtBaşlangic.Text), Convert.ToDateTime(txtBitisTrh.Text));

            }

        }

        protected void txtBitisTrh_TextChanged(object sender, EventArgs e)
        {
            CdBitisTrh.Visible = true;
           
        }

        protected void CdBitisTrh_SelectionChanged(object sender, EventArgs e)
        {
            txtBitisTrh.Text = CdBitisTrh.SelectedDate.ToShortDateString();
            CdBitisTrh.Visible = false;
            if (txtBaşlangic.Text.Trim() != null)
            {
                SorguGetir(Convert.ToDateTime(txtBaşlangic.Text), Convert.ToDateTime(txtBitisTrh.Text));

            }
        }

        protected void btnTariheGore_Click(object sender, EventArgs e)
        {
            pnlTarihSorgusu.Visible = true;
            pnpMusteriSorgusu.Visible = false;
        }

        protected void btnMusteri_Click(object sender, EventArgs e)
        {
            pnlTarihSorgusu.Visible = false;
            pnpMusteriSorgusu.Visible = true;
            if (txtMusteriAra.Text.Length>=3)
            {
                MusteriyeGoreGetir(txtMusteriAra.Text.Trim());
            }
        }

        private void MusteriyeGoreGetir(string MusteriAd)
        {
           
            var sorgu = (from s in ent.Satıslar
                         join k in ent.Kullanicilar on s.KullaniciId equals k.id
                         where k.Ad==MusteriAd || k.Soyad==MusteriAd ||k.Ad+" "+k.Soyad==MusteriAd
                         select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
            rptRaporlar.DataSource = sorgu;
            rptRaporlar.DataBind();
        }

        protected void ddlSıralama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSıralama.SelectedValue=="Artan Fiyat")
            {
                var artanFiyat= (from s in ent.Satıslar
                                 join k in ent.Kullanicilar on s.KullaniciId equals k.id
                                 orderby s.Tutar ascending
                                 select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
                rptRaporlar.DataSource = artanFiyat;
                rptRaporlar.DataBind();
            }
           else if (ddlSıralama.SelectedValue == "Azalan Fiyat")
            {
                var azalanFiyat = (from s in ent.Satıslar
                                  join k in ent.Kullanicilar on s.KullaniciId equals k.id
                                  orderby s.Tutar descending
                                  select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
                rptRaporlar.DataSource = azalanFiyat;
                rptRaporlar.DataBind();
            }
          else  if (ddlSıralama.SelectedValue == "Artan Adet")
            {
                var artanAdet = (from s in ent.Satıslar
                                  join k in ent.Kullanicilar on s.KullaniciId equals k.id
                                  orderby s.Adet ascending
                                  select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
                rptRaporlar.DataSource = artanAdet;
                rptRaporlar.DataBind();
            }
         else   if (ddlSıralama.SelectedValue == "Azalan Adet")
            {
                var azalanAdet = (from s in ent.Satıslar
                                  join k in ent.Kullanicilar on s.KullaniciId equals k.id
                                  orderby s.Adet descending
                                  select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
                rptRaporlar.DataSource = azalanAdet;
                rptRaporlar.DataBind();
            }
          else  if (ddlSıralama.SelectedValue == "A-Z")
            {
                var AZ = (from s in ent.Satıslar
                                  join k in ent.Kullanicilar on s.KullaniciId equals k.id
                                  orderby k.Ad ascending
                                  select new { s.id, s.KargoAd, s.LastName, s.Name, s.Telefon, s.Tutar, s.Adet, s.Adres, s.Email, k.Ad, k.Soyad, s.SiparisTarih }).ToList();
                rptRaporlar.DataSource =AZ;
                rptRaporlar.DataBind();
            }
        }
    }
}