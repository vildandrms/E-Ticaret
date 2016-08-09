using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class checkout4 : System.Web.UI.Page
    {

        cOdeme.KargoBilgileri k = new cOdeme.KargoBilgileri();

        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["kullanici"] != null)
                {

                    BilgileriDoldur();
                }
                else
                {
                    Response.Redirect("register.aspx");
                }

            }
        }

        private void BilgileriDoldur()
        {
            cOdeme.AdresBilgileri oku = new cOdeme.AdresBilgileri();
            oku = (cOdeme.AdresBilgileri)Session["Adresi"];

            if (Session["Adresi"] != null && Session["Kargosu"] != null && Session["Odeme"] != null)
            {
                lblAdSoyad.Text = oku.Ad + " " + oku.Soyad;
                lblKargo.Text = k.Kargo1;
                lblAdres.Text = oku.Cadde + " " + "caddesi " + " " + oku.Mahalle + " mahallesi " + " " + oku.Sokak + " " + " sokak " + " " + oku.Il + " / " + oku.Ilce + "Posta :" + oku.PostaKodu;
                txtToplam.Text = ToplamTutarBul().ToString() +"TL";

            }
        }
        private int ToplamAdetBul()
        {
            int adet = 0;
            DataTable dt = (DataTable)Session["sepeteAt"];
            foreach (DataRow dr in dt.Rows)
            {
                adet += Convert.ToInt32(dr["Adet"]);
            }
            return adet;
        }
        private int ToplamTutarBul()
        {
            int tutar = 0;
            DataTable dt = (DataTable)Session["sepeteAt"];
            foreach (DataRow dr in dt.Rows)
            {
                tutar += Convert.ToInt32(dr["Tutar"]);
            }
            return tutar;
        }
        protected void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["kullanici"]);

            DataTable dt = (DataTable)Session["sepeteAt"];
            cOdeme.AdresBilgileri oku = new cOdeme.AdresBilgileri();
            oku = (cOdeme.AdresBilgileri)Session["Adresi"];
            Odemeler yeni = new Odemeler();
            cOdeme.OdemeBilgileri o = new cOdeme.OdemeBilgileri();
            o = (cOdeme.OdemeBilgileri)Session["Odeme"];
            cOdeme.KargoBilgileri krg = new cOdeme.KargoBilgileri();
            krg = (cOdeme.KargoBilgileri)Session["Kargosu"];
            if (Session["kullanici"] != null)
            {
                yeni.KullanıcıId = Convert.ToInt32(Session["kullanici"]);

                if (o.OdemeTuru1 == true)
                {
                    yeni.Kredi = o.OdemeTuru1;
                    yeni.Nakit = false;
                    yeni.CvcNo = o.CvcNo1.ToString();
                    yeni.SKTarihi = o.SkTarihi1;
                    yeni.TaksitSayiyi = o.TaksitSayisi1;
                    yeni.KartNo = o.KartNo1;
                    yeni.Ad = o.KartAd1;
                    yeni.Soyad = o.KartSoyad1;
                    yeni.KullanıcıId = Convert.ToInt32(Session["kullanici"]);
                    ent.Odemeler.Add(yeni);
                    ent.SaveChanges();
                }
                else if (o.OdemeTuru1 == false)
                {
                    var kulID = (from k in ent.Kullanicilar
                                 where k.id == ID
                                 select k).FirstOrDefault();
                    yeni.Nakit = true;
                    yeni.Kredi = false;

                    yeni.Ad = kulID.Ad;
                    yeni.Soyad = kulID.Soyad;

                    ent.Odemeler.Add(yeni);
                    ent.SaveChanges();

                }




                Satıslar s = new Satıslar();
                s.Adet = ToplamAdetBul();
                s.Tutar = ToplamTutarBul();
                s.KargoAd = krg.Kargo1;
                s.KullaniciId = yeni.KullanıcıId;
                s.Name = oku.Ad;
                s.LastName = oku.Soyad;
                if (krg.Kargo1 == "Aras Kargo")
                {
                    o.SiparisTrh1 = DateTime.Now;
                    o.TeslimTrh1 = DateTime.Now.AddDays(3);
                    Session["Odeme"] = o;
                    s.TeslimTarih = o.TeslimTrh1;
                    s.SiparisTarih = o.SiparisTrh1;
                }
                else if (krg.Kargo1 == "Ups Kargo")
                {
                    o.SiparisTrh1 = DateTime.Now;
                    o.TeslimTrh1 = DateTime.Now.AddDays(1);
                    Session["Odeme"] = o;
                    s.TeslimTarih = o.TeslimTrh1;
                    s.SiparisTarih = o.SiparisTrh1;
                }
                else if (krg.Kargo1 == "Yurtiçi Kargo")
                    {
                        o.SiparisTrh1 = DateTime.Now;
                        o.TeslimTrh1 = DateTime.Now.AddDays(7);
                        Session["Odeme"] = o;
                        s.TeslimTarih = o.TeslimTrh1;
                        s.SiparisTarih = o.SiparisTrh1;

                    }
                s.Telefon = oku.Telefon;
                s.OdemeId = ent.Odemeler.Where(sn => sn.id == yeni.id).ToList().Last().id;
                s.Email = oku.Email;
                s.Adres = oku.Cadde + " " + oku.Mahalle + " " + oku.Sokak + " " + oku.Il + " / " + oku.Ilce;
                ent.Satıslar.Add(s);

                ent.SaveChanges();
                Sepettekiler spt = new Sepettekiler();
                foreach (DataRow dr in dt.Rows)
                {

                    spt.Adet = Convert.ToInt32(dr["Adet"]);
                    spt.Fiyat = Convert.ToInt32(dr["Fiyat"]);
                    spt.Tutar = Convert.ToDecimal(dr["Tutar"]);
                    spt.UrunId = Convert.ToInt32(dr["UrunId"]);
                    spt.SatisNo = ent.Satıslar.Where(sn => sn.id == s.id).ToList().Last().id;
                    spt.Satildi = true;
                    ent.Sepettekiler.Add(spt);
                    StoktanDus(Convert.ToInt32(spt.UrunId), Convert.ToInt32(spt.Adet));
                    ent.SaveChanges();
                    Session.Remove("sepeteAt");
                }

            }
            Response.Redirect("default.aspx");

        }

        private void StoktanDus(int ID, int Adeti)
        {
            var satilanUrun = (from u in ent.Urunler
                               where u.id == ID
                               select u).FirstOrDefault();
            satilanUrun.Adet = Convert.ToInt32(satilanUrun.Adet) - Adeti;
            satilanUrun.id = ID;
            ent.SaveChanges();
        }
    }
}
