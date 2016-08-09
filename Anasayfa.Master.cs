using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class Anasayfa : System.Web.UI.MasterPage
    {
       
        List<int> idlerim = new List<int>();
        List<int> idlerim2 = new List<int>();
        Service s = new Service();
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ErkekUrunleriGetir();
                BayanUrunleriGetir();
                SepetiGoster();
               MarkalarıVeRenkleriGetir();
                AnaMenuDoldur();
                int ID = Convert.ToInt32(Session["kullanici"]);
                if (Session["kullanici"] != null)
                {

                    if (KullaniciKontrol(ID))
                    {

                       
                        lblAdmingizle.Visible = true;
                        lblKullanici.Text = "ADMİN";
                        lblGiris.Visible = false;
                        lblCikis.Visible = true;
                        Panel1.Visible = false;
                    }
                    else
                    {
                        lblGiris.Visible = false;
                        lblCikis.Visible = true;
                        lblAdmingizle.Visible = false;
                        lblKullanici.Visible = true;
                        Panel1.Visible = false;
                        KullaniciAdminMi(ID);

                    }

                }
                else if (Session["kullanici"] != null && lblGiris.Text == "Çıkış")
                {
                    lblGiris.Visible = true;
                    lblCikis.Visible = false;
                    lblGiris.Text = "Giriş";
                    Session.Remove("kullanici");
                    Response.Redirect("default.aspx");
                    lblKullanici.Visible = false;
                    Panel1.Visible = true;
                    KullaniciAdminMi(ID);

                }


            }
        }
        private bool KullaniciKontrol(int idsi)
        {
            bool sonuc;
            var admin = (from k in ent.Kullanicilar
                         where k.id == idsi
                         select k).FirstOrDefault();
        
            if (admin.Ad=="admin")
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }
            return sonuc;
        }
        private void KullaniciAdminMi(int ID)
        {
            //int ID = Convert.ToInt32(Session["kullanici"]);
            var admin = (from k in ent.Kullanicilar
                         where k.id == ID
                         select k).FirstOrDefault();
            lblKullanici.Text = admin.Ad.ToUpper() + " " + admin.Soyad.ToUpper();

        }
        private void SepetiGoster()
        {
            if (Session["sepeteAt"] != null)
            {


                lblurunAdet.Text = ToplamAdetBul().ToString() + " Adet ürün var";

            }
            else
            {
                lblurunAdet.Text = "Boş";
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
        private void AnaMenuDoldur()
        {


            var katId1 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 1 && u.CinsiyetId == 1 && u.Adet >= 0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();

            var katId2 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 2 && u.CinsiyetId == 1 && u.Adet >= 0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();
            var katId3 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 3 && u.CinsiyetId == 1 && u.Adet >= 0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.id, Urunkategorisi.GiyimAd }).Distinct()).ToList();

            var katId4 = ((from u in ent.Urunler
                           join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                           where u.CinsiyetId == 1 && u.Adet >= 0
                           orderby Urunmarkasi.MarkaAd ascending
                           select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

            rptKadınGiyim.DataSource = katId1;
            rptKadınGiyim.DataBind();

            rptKadınAyakkabı.DataSource = katId2;
            rptKadınAyakkabı.DataBind();

            rptKadınAksesuar.DataSource = katId3;
            rptKadınAksesuar.DataBind();

            rptKadınMarkalar.DataSource = katId4;
            rptKadınMarkalar.DataBind();

            /// Menu Erkek doldurdum
            var ErkId1 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 1 && u.CinsiyetId == 2 && u.Adet>=0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();

            var ErkId2 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 2 && u.CinsiyetId == 2 && u.Adet >= 0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();
            var ErkId3 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 3 && u.CinsiyetId == 2 && u.Adet >= 0
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.id, Urunkategorisi.GiyimAd }).Distinct()).ToList();

            var ErkId4 = ((from u in ent.Urunler
                           join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                           where u.CinsiyetId == 2 && u.Adet >= 0
                           orderby Urunmarkasi.MarkaAd ascending
                           select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();


            rptErkekGiyim.DataSource = ErkId1;
            rptErkekGiyim.DataBind();

            rptErkekAyakkabı.DataSource = ErkId2;
            rptErkekAyakkabı.DataBind();


            rptErkekAksesuar.DataSource = ErkId3;
            rptErkekAksesuar.DataBind();

            rptErkekMarkalar.DataSource = ErkId4;
            rptErkekMarkalar.DataBind();

        }
        private void MarkalarıVeRenkleriGetir()
        {
            int kID = Convert.ToInt32(Request.QueryString["EkatId"]);
            int KaID = Convert.ToInt32(Request.QueryString["KkatId"]);
            int KdnID = Convert.ToInt32(Request.QueryString["UKatId"]);
            int ErkID = Convert.ToInt32(Request.QueryString["UEKatId"]);

            if (kID != 0)
            {

                var ErkId4 = ((from u in ent.Urunler
                               join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                               where u.CinsiyetId == 2 && u.KategoriID == kID
                               orderby Urunmarkasi.MarkaAd ascending
                               select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

                var ErkId5 = ((from u in ent.Urunler
                               join Urunrengi in ent.Renkler on u.RenkId equals Urunrengi.id
                               where u.CinsiyetId == 2 && u.KategoriID == kID
                               orderby Urunrengi.RenkAd ascending
                               select new { Urunrengi.id, Urunrengi.RenkAd }).Distinct()).ToList();


                rptMarkalar.DataSource = ErkId4;
                rptMarkalar.DataBind();

                rptRenkler.DataSource = ErkId5;
                rptRenkler.DataBind();


            }
            else if (KaID != 0)
            {
                var KatId4 = ((from u in ent.Urunler
                               join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                               where u.CinsiyetId == 1 && u.KategoriID == KaID
                               orderby Urunmarkasi.MarkaAd ascending
                               select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

                var ErkId5 = ((from u in ent.Urunler
                               join Urunrengi in ent.Renkler on u.RenkId equals Urunrengi.id
                               where u.CinsiyetId == 1 && u.KategoriID == KaID
                               orderby Urunrengi.RenkAd ascending
                               select new { Urunrengi.id, Urunrengi.RenkAd }).Distinct()).ToList();

                rptMarkalar.DataSource = KatId4;
                rptMarkalar.DataBind();

                rptRenkler.DataSource = ErkId5;
                rptRenkler.DataBind();


            }
            else if (KdnID != 0)
            {
                var KatId4 = ((from u in ent.Urunler
                               join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                               where u.CinsiyetId == 1 && u.UrunKatId == KdnID
                               orderby Urunmarkasi.MarkaAd ascending
                               select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

                var ErkId5 = ((from u in ent.Urunler
                               join Urunrengi in ent.Renkler on u.RenkId equals Urunrengi.id
                               where u.CinsiyetId == 1 && u.UrunKatId ==KdnID
                               orderby Urunrengi.RenkAd ascending
                               select new { Urunrengi.id, Urunrengi.RenkAd }).Distinct()).ToList();

                rptMarkalar.DataSource = KatId4;
                rptMarkalar.DataBind();

                rptRenkler.DataSource = ErkId5;
                rptRenkler.DataBind();


            }
            else if (ErkID != 0)
            {
                var KatId4 = ((from u in ent.Urunler
                               join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                               where u.CinsiyetId == 2 && u.UrunKatId== ErkID
                               orderby Urunmarkasi.MarkaAd ascending
                               select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

                var ErkId5 = ((from u in ent.Urunler
                               join Urunrengi in ent.Renkler on u.RenkId equals Urunrengi.id
                               where u.CinsiyetId == 2 && u.UrunKatId == ErkID
                               orderby Urunrengi.RenkAd ascending
                               select new { Urunrengi.id, Urunrengi.RenkAd }).Distinct()).ToList();

                rptMarkalar.DataSource = KatId4;
                rptMarkalar.DataBind();

                rptRenkler.DataSource = ErkId5;
                rptRenkler.DataBind();


            }


            else
            {
                var MarId4 = ((from u in ent.Urunler
                               join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                               orderby Urunmarkasi.MarkaAd ascending
                               select new { Urunmarkasi.id, Urunmarkasi.MarkaAd }).Distinct()).ToList();

                var RenkId5 = ((from u in ent.Urunler
                                join Urunrengi in ent.Renkler on u.RenkId equals Urunrengi.id
                                orderby Urunrengi.RenkAd ascending
                                select new { Urunrengi.id, Urunrengi.RenkAd }).Distinct()).ToList();


                rptMarkalar.DataSource = MarId4;
                rptMarkalar.DataBind();

                rptRenkler.DataSource = RenkId5;
                rptRenkler.DataBind();

            }


        }
        private void BayanUrunleriGetir()
        {
            var KaId2 = ((from u in ent.Urunler
                          join kategorisi in ent.Kategoriler on u.KategoriID equals kategorisi.id
                          where u.KategoriID == kategorisi.id && u.CinsiyetId == 1
                          select new { kategorisi.KategoriAd, kategorisi.id }).Distinct()).ToList();

            rptKadınKategorileri.DataSource = KaId2;
            rptKadınKategorileri.DataBind();


        }
        private void ErkekUrunleriGetir()
        {
            var ErkId2 = ((from u in ent.Urunler
                           join kategorisi in ent.Kategoriler on u.KategoriID equals kategorisi.id
                           where u.KategoriID == kategorisi.id && u.CinsiyetId == 2
                           select new { kategorisi.KategoriAd, kategorisi.id }).Distinct()).ToList();

            rptErkekKategorileri.DataSource = ErkId2;
            rptErkekKategorileri.DataBind();


        }
        protected void btnMarkaArayap_Click(object sender, EventArgs e)
        {
            int kID = Convert.ToInt32(Request.QueryString["EkatId"]);
            int KaID = Convert.ToInt32(Request.QueryString["KkatId"]);           
            int KdnID = Convert.ToInt32(Request.QueryString["UKatId"]);
            int ErkID = Convert.ToInt32(Request.QueryString["UEKatId"]);
            foreach (RepeaterItem rpt in this.rptMarkalar.Items)
            {
                CheckBox cb = rpt.FindControl("cbMarkalar") as CheckBox;
                if (cb.Checked)
                {
                    Label hf = rpt.FindControl("hfMarkaId") as Label;
                    idlerim.Add(Convert.ToInt32(hf.Text));
                }
            }
            int MarkaId = idlerim[0];
            if (KaID != 0)
            {
                Response.Redirect("category.aspx?AMarId=" + MarkaId + "&KkatId=" + KaID);
            }
            else if (kID != 0)
            {
                Response.Redirect("category.aspx?AMarId=" + MarkaId + "&EkatId=" + kID);
            }
            else if (KdnID!=0)
            {
                Response.Redirect("category.aspx?AMarId=" + MarkaId + "&UKatId=" + KdnID);
            }
            else if (ErkID!=0)
            {
                Response.Redirect("category.aspx?AMarId=" + MarkaId + "&UEKatId=" + ErkID);
            }
            else
            {
                Response.Redirect("category.aspx?AMarkId=" + MarkaId);
            }

        }
        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string mail = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            var KKontrol = (from k in ent.Kullanicilar
                            where k.Email == mail && k.Sifre == sifre
                            select k).FirstOrDefault();
            if (KKontrol != null)
            {
                Session["kullanici"] = KKontrol.id;
                Response.Redirect("default.aspx");
            }
        }
        protected void btnRenkAra_Click(object sender, EventArgs e)
        {
            int kID = Convert.ToInt32(Request.QueryString["EkatId"]);
            int KaID = Convert.ToInt32(Request.QueryString["KkatId"]);
            int KdnID = Convert.ToInt32(Request.QueryString["UKatId"]);
            int ErkID = Convert.ToInt32(Request.QueryString["UEKatId"]);

            foreach (RepeaterItem rpt in this.rptRenkler.Items)
            {
                CheckBox cb = rpt.FindControl("cbRenkler") as CheckBox;
                if (cb.Checked)
                {
                    Label hf = rpt.FindControl("hfRenkId") as Label;
                    idlerim2.Add(Convert.ToInt32(hf.Text));
                }
            }
            int RenkId = idlerim2[0];
            if (kID != 0)
            {
                Response.Redirect("category.aspx?ARenkId=" + RenkId + "&EkatId=" + kID);
            }
            else if (KaID != 0)
            {
                Response.Redirect("category.aspx?ARenkId=" + RenkId + "&KkatId=" + KaID);
            }
            else if (KdnID != 0)
            {
                Response.Redirect("category.aspx?ARenkId=" + RenkId + "&UKatId=" + KdnID);
            }
            else if (ErkID != 0)
            {
                Response.Redirect("category.aspx?ARenkId=" + RenkId + "&UEKatId=" + ErkID);
            }
            else
            {
                Response.Redirect("category.aspx?ARenkId=" + RenkId);
            }

        }
        protected void lblCikis_Click(object sender, EventArgs e)
        {
            lblGiris.Visible = true;
            lblCikis.Visible = false;
            lblGiris.Text = "Giriş";
            Session.Remove("kullanici");
            Response.Redirect("default.aspx");
            lblKullanici.Visible = false;
            Panel1.Visible = true;
           
        }
        protected void btnAramaYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("category.aspx?Aranan=" + txtArama.Text.Trim());
        }
    }
}


