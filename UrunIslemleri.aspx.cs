using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class UrunIslemleri : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string syf = "UrunIslemleri.aspx";
                int ID = Convert.ToInt32(Session["kullanici"]);
                if (Session["kullanici"]==null)
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
        protected void btnMarkaIslemleri_Click(object sender, EventArgs e)
        {
            pnlMarkaIslem.Visible = true;
            pnlAKategoriIslem.Visible = false;
            pnlUrunIslemlerı.Visible = false;
            pnlRenkIslem.Visible = false;
            pnpKategoriIslem.Visible = false;
            MarkalarıDoldur();
        }

        private void MarkalarıDoldur()
        {
            var marklar = (from m in ent.Markalar
                           select m).ToList();
            gvMarkalar.DataSource = marklar;
            gvMarkalar.DataBind();
        }

        protected void gvMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ıdsi = Convert.ToInt32(gvMarkalar.SelectedRow.Cells[1].Text);
            var seciliGetir = (from m in ent.Markalar
                               where m.id == ıdsi
                               select m).ToList();
            dvDetailsMarklaar.DataSource = seciliGetir;
            dvDetailsMarklaar.DataBind();
        }



        protected void dvDetailsMarklaar_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvDetailsMarklaar.Rows[0].Cells[1].Text);
            TextBox txt = (TextBox)dvDetailsMarklaar.FindControl("txtGMarkaAd");
            var guncelle = (from m in ent.Markalar
                            where m.id == Idsi
                            select m).FirstOrDefault();
            guncelle.MarkaAd = txt.Text;
            ent.SaveChanges();
            MarkalarıDoldur();
            dvDetailsMarklaar.Visible = false;
        }

        protected void dvDetailsMarklaar_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvDetailsMarklaar.ChangeMode(e.NewMode);

        }

        protected void dvDetailsMarklaar_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox txt = (TextBox)dvDetailsMarklaar.FindControl("txtEMarkaAd");
            var guncelle = (from m in ent.Markalar
                            select m).FirstOrDefault();
            guncelle.MarkaAd = txt.Text;
            ent.Markalar.Add(guncelle);
            ent.SaveChanges();
            MarkalarıDoldur();
            dvDetailsMarklaar.Visible = false;
        }

        protected void dvDetailsMarklaar_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvDetailsMarklaar.Rows[0].Cells[1].Text);
            var guncelle = (from m in ent.Markalar
                            where m.id == Idsi
                            select m).FirstOrDefault();
            ent.Markalar.Remove(guncelle);
            ent.SaveChanges();
            MarkalarıDoldur();
            dvDetailsMarklaar.Visible = false;

        }

        protected void btnKategoriIslemleri_Click(object sender, EventArgs e)
        {
            pnlMarkaIslem.Visible = false;
            pnlAKategoriIslem.Visible = false;
            pnlUrunIslemlerı.Visible = false;
            pnlRenkIslem.Visible = false;
            pnpKategoriIslem.Visible = true;
            KategorileriDoldur();
        }

        protected void gvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ıdsi = Convert.ToInt32(gvKategoriler.SelectedRow.Cells[1].Text);
            var seciliGetir = (from m in ent.Kategoriler
                               where m.id == ıdsi
                               select m).ToList();
            dvDetayKategoriler.DataSource = seciliGetir;
            dvDetayKategoriler.DataBind();
        }



        private void KategorileriDoldur()
        {

            var kategoriler = (from m in ent.Kategoriler
                               select m).ToList();
            gvKategoriler.DataSource = kategoriler;
            gvKategoriler.DataBind();
        }



        protected void dvDetayKategoriler_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvDetayKategoriler.Rows[0].Cells[1].Text);
            TextBox txt = (TextBox)dvDetayKategoriler.FindControl("txtGKategoriAd");
            var guncelle = (from m in ent.Kategoriler
                            where m.id == Idsi
                            select m).FirstOrDefault();
            guncelle.KategoriAd = txt.Text;
            ent.SaveChanges();
            KategorileriDoldur();
            dvDetayKategoriler.Visible = false;

        }

        protected void dvDetayKategoriler_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox txt = (TextBox)dvDetayKategoriler.FindControl("txtEKategoriAd");
            var guncelle = (from m in ent.Kategoriler
                            select m).FirstOrDefault();
            guncelle.KategoriAd = txt.Text;
            ent.Kategoriler.Add(guncelle);
            ent.SaveChanges();
            KategorileriDoldur();
            dvDetayKategoriler.Visible = false;
        }

        protected void dvDetayKategoriler_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvDetayKategoriler.Rows[0].Cells[1].Text);
            var guncelle = (from m in ent.Kategoriler
                            where m.id == Idsi
                            select m).FirstOrDefault();
            ent.Kategoriler.Remove(guncelle);
            ent.SaveChanges();
            KategorileriDoldur();
            dvDetayKategoriler.Visible = false;
        }

        protected void dvDetayKategoriler_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvDetayKategoriler.ChangeMode(e.NewMode);
        }

        protected void btnAKategoriIslemleri_Click(object sender, EventArgs e)
        {
            pnlMarkaIslem.Visible = false;
            pnlAKategoriIslem.Visible = true;
            pnlUrunIslemlerı.Visible = false;
            pnlRenkIslem.Visible = false;
            pnpKategoriIslem.Visible = false;

            AltKategorileriDoldur();

        }

        private void AltKategorileriDoldur()
        {

            var Altkategoriler = (from m in ent.UrunKategorileri
                                  select m).ToList();
            gvAKategoriIslem.DataSource = Altkategoriler;
            gvAKategoriIslem.DataBind();
        }

        protected void gvAKategoriIslem_SelectedIndexChanged(object sender, EventArgs e)
        {

            dvAKategori.Visible = true;
            int ıdsi = Convert.ToInt32(gvAKategoriIslem.SelectedRow.Cells[1].Text);
            var seciliGetir = (from m in ent.UrunKategorileri
                               join k in ent.Kategoriler on m.KategoriId equals k.id
                               where m.id == ıdsi
                               select new { m.id, m.GiyimAd, k.KategoriAd }).ToList();
            dvAKategori.DataSource = seciliGetir;
            dvAKategori.DataBind();
            var katDol = (from k in ent.Kategoriler
                          select k).ToList();

            ddlKategoriler.DataSource = katDol;
            ddlKategoriler.DataBind();



        }

        protected void dvAKategori_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvAKategori.ChangeMode(e.NewMode);

        }

        protected void dvAKategori_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvAKategori.Rows[0].Cells[1].Text);
            TextBox txt = (TextBox)dvAKategori.FindControl("txtGAKategoriAd");
            TextBox txt2 = (TextBox)dvAKategori.FindControl("txtGAGiyimAd");
            var guncelle = (from m in ent.UrunKategorileri
                            where m.id == Idsi
                            select m).FirstOrDefault();
            guncelle.KategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
            guncelle.GiyimAd = txt2.Text;
            ent.SaveChanges();
            AltKategorileriDoldur();
            dvAKategori.Visible = false;
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)dvAKategori.FindControl("txtGAKategoriAd");
            TextBox txt2 = (TextBox)dvAKategori.FindControl("txtEAKategoriAd");
            ////sor burayı ikisini aynı anada yapamıyorum if ile de yaptın txt.tex!=null gibi
            // txt.Text = ddlKategoriler.SelectedItem.Text;                      
            //txt2.Text = ddlKategoriler.SelectedItem.Text;



        }

        protected void dvAKategori_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox txt = (TextBox)dvDetayKategoriler.FindControl("txtEAKategoriAd");
            TextBox txt2 = (TextBox)dvAKategori.FindControl("txtEAGiyimAd");
            var guncelle = (from m in ent.UrunKategorileri
                            select m).FirstOrDefault();
            guncelle.KategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
            guncelle.GiyimAd = txt2.Text;
            ent.UrunKategorileri.Add(guncelle);
            ent.SaveChanges();
            AltKategorileriDoldur();
            dvAKategori.Visible = false;
        }

        protected void dvAKategori_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvAKategori.Rows[0].Cells[1].Text);
            var guncelle = (from m in ent.UrunKategorileri
                            where m.id == Idsi
                            select m).FirstOrDefault();
            ent.UrunKategorileri.Remove(guncelle);
            ent.SaveChanges();
            AltKategorileriDoldur();
            dvAKategori.Visible = false;
        }

        protected void btnRenkIslemleri_Click(object sender, EventArgs e)
        {
            pnlMarkaIslem.Visible = false;
            pnlAKategoriIslem.Visible = false;
            pnlUrunIslemlerı.Visible = false;
            pnlRenkIslem.Visible = true;
            pnpKategoriIslem.Visible = false;
            RenklerDoldur();

        }

        private void RenklerDoldur()
        {
            var rnk = (from r in ent.Renkler
                       select r).ToList();
            gvRenkler.DataSource = rnk;
            gvRenkler.DataBind();
        }

        protected void gvRenkler_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvRenkler.Visible = true;
            int ıdsi = Convert.ToInt32(gvRenkler.SelectedRow.Cells[1].Text);
            var seciliGetir = (from m in ent.Renkler
                               where m.id == ıdsi
                               select m).ToList();
            dvRenkler.DataSource = seciliGetir;
            dvRenkler.DataBind();
        }

        protected void dvRenkler_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvRenkler.ChangeMode(e.NewMode);
        }

        protected void dvRenkler_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvRenkler.Rows[0].Cells[1].Text);
            TextBox txt = (TextBox)dvRenkler.FindControl("txtGRenkAd");

            var guncelle = (from m in ent.Renkler
                            where m.id == Idsi
                            select m).FirstOrDefault();
            guncelle.id = Idsi;
            guncelle.RenkAd = txt.Text;
            ent.SaveChanges();
            RenklerDoldur();
            dvRenkler.Visible = false;
        }

        protected void dvRenkler_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox txt = (TextBox)dvRenkler.FindControl("txtERenkAd");

            var guncelle = (from m in ent.Renkler
                            select m).FirstOrDefault();

            guncelle.RenkAd = txt.Text;
            ent.Renkler.Add(guncelle);
            ent.SaveChanges();
            RenklerDoldur();
            dvRenkler.Visible = false;
        }

        protected void dvRenkler_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            int Idsi = Convert.ToInt32(dvRenkler.Rows[0].Cells[1].Text);
            var guncelle = (from m in ent.Renkler
                            where m.id == Idsi
                            select m).FirstOrDefault();
            ent.Renkler.Remove(guncelle);
            ent.SaveChanges();
            RenklerDoldur();
            dvRenkler.Visible = false;
        }

        protected void btnUrunIslemleri_Click(object sender, EventArgs e)
        {
            pnlMarkaIslem.Visible = false;
            pnlAKategoriIslem.Visible = false;
            pnlRenkIslem.Visible = false;
            pnpKategoriIslem.Visible = false;
            pnlUrunIslemlerı.Visible = true;
            pnlUrunEkle.Visible = true;
            DroplarıDoldur();
        }
        private void DroplarıDoldur()
        {
            var renk = (from r in ent.Renkler
                        select r).ToList();
            ddlRengi.DataSource = renk;
            ddlRengi.DataBind();
            var mark = (from m in ent.Markalar
                        select m).ToList();
            ddlMarkasi.DataSource = mark;
            ddlMarkasi.DataBind();
            var cins = (from c in ent.Cinsiyet
                        select c).ToList();
            ddlCinsiyet.DataSource = cins;
            ddlCinsiyet.DataBind();
            var kategori = (from k in ent.Kategoriler
                            select k).ToList();
            ddlKategorisi.DataSource = kategori;
            ddlKategorisi.DataBind();
            var Akaategori = (from ak in ent.UrunKategorileri
                              select ak).ToList();
            ddlAltKategori.DataSource = Akaategori;
            ddlAltKategori.DataBind();

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Urunler yeni = new Urunler();
            yeni.Adet = Convert.ToInt32(txtAdet.Text.Trim());
            yeni.CinsiyetId = Convert.ToInt32(ddlCinsiyet.SelectedValue);
            yeni.BendenId = 1;
            yeni.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            yeni.KategoriID = Convert.ToInt32(ddlKategorisi.SelectedValue);
            yeni.MarkaId = Convert.ToInt32(ddlMarkasi.SelectedValue);
            yeni.RenkId = Convert.ToInt32(ddlRengi.SelectedValue);
            if (fuResimBir.HasFile)
            {
                yeni.ResimBir = fuResimBir.FileName;
                string ResimYolu = string.Format("~/img/{0}", yeni.ResimBir);
                fuResimBir.SaveAs(Server.MapPath(ResimYolu));
            }
            if (fuResimİki.HasFile)
            {
                yeni.Resimİki = fuResimİki.FileName;
                string ResimYolu = string.Format("~/img/{0}", yeni.Resimİki);
                fuResimİki.SaveAs(Server.MapPath(ResimYolu));
            }
            if (fuResimUc.HasFile)
            {
                yeni.ResimUc = fuResimUc.FileName;
                string ResimYolu = string.Format("~/img/{0}", yeni.ResimUc);
                fuResimUc.SaveAs(Server.MapPath(ResimYolu));
            }
            if (cbYeniMi.Checked)
            {
                yeni.YeniMi = true;
            }
            else
            {
                yeni.YeniMi = false;
            }
            if (cbVitrin.Checked)
            {
                yeni.Vitrin = true;
            }
            else
            {
                yeni.Vitrin = false;
            }

            yeni.UrunKatId = Convert.ToInt32(ddlAltKategori.SelectedValue);
            yeni.UrunMetaryali = txtMetaryali.Text.Trim();
            yeni.UrunTanimi = txtUTanimi.Text.Trim();
            ent.Urunler.Add(yeni);
            ent.SaveChanges();
            gvUrunler.DataBind();
            lblUrunMesaj.Text = "Yeni ürün kaydedildi.";
        }

        protected void gvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResimBir.Visible = true;
            txtResimİki.Visible = true;
            txtResimUc.Visible = true;
            int ıd = Convert.ToInt32(gvUrunler.SelectedDataKey.Value);
            lblID.Text = ıd.ToString();
            pnlUrunEkle.Visible = true;
            var ıdsi = (from f in ent.Urunler
                        where f.id == ıd
                        select f).FirstOrDefault();
            txtAdet.Text = ıdsi.Adet.ToString();
            txtFiyat.Text = ıdsi.Fiyat.ToString();
            txtMetaryali.Text = ıdsi.UrunMetaryali;
            txtUTanimi.Text = ıdsi.UrunTanimi;
            ddlAltKategori.SelectedValue = ıdsi.UrunKatId.ToString();
            ddlCinsiyet.SelectedValue = ıdsi.CinsiyetId.ToString();
            ddlKategoriler.SelectedValue = ıdsi.KategoriID.ToString();
            ddlMarkasi.SelectedValue = ıdsi.MarkaId.ToString();
            ddlRengi.SelectedValue = ıdsi.RenkId.ToString();
            txtResimBir.Text = ıdsi.ResimBir;
            txtResimİki.Text = ıdsi.Resimİki;
            txtResimUc.Text = ıdsi.ResimUc;
            if (ıdsi.Vitrin == true)
            {
                cbVitrin.Checked = true;
            }
            else
            {
                cbVitrin.Checked = false;
            }
            if (ıdsi.YeniMi == true)
            {
                cbYeniMi.Checked = true;
            }
            else
            {
                cbYeniMi.Checked = false;
            }

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int ıd = Convert.ToInt32(lblID.Text);
            var gUrun = (from u in ent.Urunler
                         where u.id == ıd
                         select u).FirstOrDefault();
            gUrun.Adet = Convert.ToInt32(txtAdet.Text.Trim());
            gUrun.CinsiyetId = Convert.ToInt32(ddlCinsiyet.SelectedValue);
            gUrun.BendenId = 1;
            gUrun.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            gUrun.KategoriID = Convert.ToInt32(ddlKategorisi.SelectedValue);
            gUrun.MarkaId = Convert.ToInt32(ddlMarkasi.SelectedValue);
            gUrun.RenkId = Convert.ToInt32(ddlRengi.SelectedValue);
            if (fuResimBir.HasFile)
            {
                gUrun.ResimBir = fuResimBir.FileName;
                string ResimYolu = string.Format("~/img/{0}", gUrun.ResimBir);
                fuResimBir.SaveAs(Server.MapPath(ResimYolu));
            }
            if (fuResimİki.HasFile)
            {
                gUrun.Resimİki = fuResimİki.FileName;
                string ResimYolu = string.Format("~/img/{0}", gUrun.Resimİki);
                fuResimİki.SaveAs(Server.MapPath(ResimYolu));
            }
            if (fuResimUc.HasFile)
            {
                gUrun.ResimUc = fuResimUc.FileName;
                string ResimYolu = string.Format("~/img/{0}", gUrun.ResimUc);
                fuResimUc.SaveAs(Server.MapPath(ResimYolu));
            }
            if (cbYeniMi.Checked)
            {
                gUrun.YeniMi = true;
            }
            else
            {
                gUrun.YeniMi = false;
            }
            if (cbVitrin.Checked)
            {
                gUrun.Vitrin = true;
            }
            else
            {
                gUrun.Vitrin = false;
            }

            gUrun.UrunKatId = Convert.ToInt32(ddlAltKategori.SelectedValue);
            gUrun.UrunMetaryali = txtMetaryali.Text.Trim();
            gUrun.UrunTanimi = txtUTanimi.Text.Trim();
            ent.SaveChanges();
            gvUrunler.DataBind();
            lblUrunMesaj.Text = "Güncellendi ürün kaydedildi.";
        }

        protected void gvUrunler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // silinecek ıd yi yakal
            int ıd = Convert.ToInt32(gvUrunler.Rows[e.RowIndex].Cells[2].Text);

            var SilinecekUrun = (from u in ent.Urunler
                                 where u.id == ıd
                                 select u).FirstOrDefault();
            ent.Urunler.Remove(SilinecekUrun);
            ent.SaveChanges();
            gvUrunler.DataBind();
        }

        protected void btnYeniMarka_Click(object sender, EventArgs e)
        {
            pnlMarkaEkle.Visible = true;
        }

        protected void btnMarkaKaydet_Click(object sender, EventArgs e)
        {

            var guncelle = (from m in ent.Markalar
                            select m).FirstOrDefault();
            guncelle.MarkaAd = txtMarkaAd.Text.Trim();
            var markaKontrol = (from m in ent.Markalar
                                select m).FirstOrDefault();
            if (markaKontrol.MarkaAd == txtMarkaAd.Text.Trim())
            {
                lblID.Text = "Bu Marka Veritabanın da mevcut !";
            }
            else
            {
                ent.Markalar.Add(guncelle);
                ent.SaveChanges();
                MarkalarıDoldur();
                dvDetailsMarklaar.Visible = false;
                pnlMarkaEkle.Visible = false;
            }

        }

        protected void btnYeniKategori_Click(object sender, EventArgs e)
        {
            pnlKategoriEkle.Visible = true;
        }

        protected void btnKategoriKaydet_Click(object sender, EventArgs e)
        {

            var guncelle = (from m in ent.Kategoriler
                            select m).FirstOrDefault();
            if (guncelle.KategoriAd == txtMarkaAd.Text.Trim())
            {
                lblKatmesaj.Text = "Bu Kategori Veritabanın da mevcut !";
            }
            else
            {
                guncelle.KategoriAd = txtKategoriAd.Text;
                ent.Kategoriler.Add(guncelle);
                ent.SaveChanges();
                KategorileriDoldur();
                dvDetayKategoriler.Visible = false;
                pnlKategoriEkle.Visible = true;
            }
        }

        protected void btnAKategoriKaydet_Click(object sender, EventArgs e)
        {

            var guncelle = (from m in ent.UrunKategorileri
                            select m).FirstOrDefault();
            if (guncelle.GiyimAd == txtAKategoriAd.Text.Trim())
            {
                lblKatmesaj.Text = "Bu giyimad Veritabanın da mevcut !";
            }
            else
            {
                guncelle.KategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                guncelle.GiyimAd = txtAKategoriAd.Text;
                ent.UrunKategorileri.Add(guncelle);
                ent.SaveChanges();
                AltKategorileriDoldur();
                dvAKategori.Visible = false;
                ddlKategoriler.Visible = false;
                lblKategori.Visible = false;
            }
        }
        protected void btnYeniAltKategori_Click(object sender, EventArgs e)
        {
            pnlAKategoriEkle.Visible = true;
            var katDol = (from k in ent.Kategoriler
                          select k).ToList();

            ddlKategoriler.DataSource = katDol;
            ddlKategoriler.DataBind();
            ddlKategoriler.Visible = true;
            lblKategori.Visible = true;
        }


        protected void btnRenkAdKaydet_Click(object sender, EventArgs e)
        {
            var guncelle = (from m in ent.Renkler
                            select m).FirstOrDefault();
            if (guncelle.RenkAd == txtRenkAd.Text.Trim())
            {
                lblKatmesaj.Text = "Bu Renk Veritabanın da mevcut !";
            }
            else
            {
                guncelle.RenkAd = txtRenkAd.Text;
                ent.Renkler.Add(guncelle);
                ent.SaveChanges();
                RenklerDoldur();
                dvRenkler.Visible = false;
                pnlRenkEkle.Visible = false;

            }
        }
        protected void btnYeniRenk_Click(object sender, EventArgs e)
        {
            pnlRenkEkle.Visible = true;
        }
    }
}