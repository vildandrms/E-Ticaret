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
    public partial class index : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        cSepet c = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            UrunleriDoldur();
            AnaMenuDoldur();
            SepetiGoster();
            
            if (Session["kullanici"] != null)
            {
                lblGiris.Text = "Çıkış";
            }
            else if (Session["kullanici"] == null && lblGiris.Text == "Çıkış")
            {
                lblGiris.Text = "Giriş";
                Session.Remove("kullanici");
                Response.Redirect("default.aspx");

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
        private void AnaMenuDoldur()
        {

           
            var katId1 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 1 && u.CinsiyetId == 1
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();

            var katId2 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 2 && u.CinsiyetId == 1
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();
            var katId3 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 3 && u.CinsiyetId == 1
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.id, Urunkategorisi.GiyimAd }).Distinct()).ToList();

            var katId4 = ((from u in ent.Urunler
                           join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                           where u.CinsiyetId == 1
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
                           where u.KategoriID == 1 && u.CinsiyetId == 2
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();

            var ErkId2 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 2 && u.CinsiyetId == 2
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.GiyimAd, Urunkategorisi.id }).Distinct()).ToList();
            var ErkId3 = ((from u in ent.Urunler
                           join Urunkategorisi in ent.UrunKategorileri on u.UrunKatId equals Urunkategorisi.id
                           where u.KategoriID == 3 && u.CinsiyetId == 2
                           orderby Urunkategorisi.GiyimAd ascending
                           select new { Urunkategorisi.id, Urunkategorisi.GiyimAd }).Distinct()).ToList();

            var ErkId4 = ((from u in ent.Urunler
                           join Urunmarkasi in ent.Markalar on u.MarkaId equals Urunmarkasi.id
                           where u.CinsiyetId == 2
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
        private void UrunleriDoldur()
        {


            var urn = (from u in ent.Urunler
                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                       where u.YeniMi==true && u.Adet >= 0
                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();

            rptYeniUrunler.DataSource = urn;
            rptYeniUrunler.DataBind();


        }

        protected void rptYeniUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            
                if (Session["sepeteAt"] == null)
                {
                    Session["sepeteAt"] = c.YeniSepet();
                }
                DataTable dt = (DataTable)Session["sepeteAt"];
                int ıdsi = Convert.ToInt32(e.CommandArgument);
                Label ResimAdres = (Label)e.Item.FindControl("lblResimBir");
                Label RenkAdmarkası = (Label)e.Item.FindControl("lblRenkAdMarka");
                Label Fiyat = (Label)e.Item.FindControl("lblFiyat");
                int Adet = 1;
                bool Varmi = false;

                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["UrunId"]) == ıdsi)
                    {
                        Varmi = true;
                        dr["Adet"] = (Convert.ToInt32(dr["Adet"]) + Adet).ToString();
                        dr["Tutar"] = (Convert.ToDecimal(dr["Tutar"]) + Convert.ToDecimal(Fiyat.Text)).ToString();
                       
                        Session["sepeteAt"] = dt;
                    SepetiGoster();

                        break;


                    }
                }
                if (Varmi == false)
                {

                    DataRow drw;
                    drw = dt.NewRow();
                    drw["UrunId"] = ıdsi;
                    drw["RenkAd"] = RenkAdmarkası.Text;
                    drw["Adet"] = Adet;
                    drw["ResimAdres"] = ResimAdres.Text;
                    drw["Fiyat"] = Convert.ToDecimal(Fiyat.Text);
                    drw["Tutar"] = Adet * Convert.ToDecimal(Fiyat.Text);
                    dt.Rows.Add(drw);
                    Session["sepeteAt"] = dt;
                SepetiGoster();
                }
            }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

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
        }
    }
    }