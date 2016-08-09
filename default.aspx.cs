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
    public partial class _default : System.Web.UI.Page
    {
        cSepet c = new cSepet();
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UrunleriDoldur();
                MarkaIdBul();
                RenkIdBul();
                SepetiGoster();
                
            }
        }

        private void RenkIdBul()
        {
            int ID = Convert.ToInt32(Request.QueryString["ARenkId"]);
            if (ID != 0)
            {

                var mID = (from u in ent.Urunler
                           join rnk in ent.Renkler on u.RenkId equals rnk.id
                           join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                           join mrk in ent.Markalar on u.MarkaId equals mrk.id
                           where u.RenkId == ID && u.Adet >= 0
                           select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                rpYeniUrunler.DataSource = mID;
                rpYeniUrunler.DataBind();
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
            Label urunAdet = (Label)this.Master.FindControl("lblurunAdet") as Label;
            if (Session["sepeteAt"] != null)
            {


                urunAdet.Text = ToplamAdetBul().ToString() + " Adet ürün var";

            }
            else
            {
                urunAdet.Text = "Boş";
            }
        }
        private void UrunleriDoldur()
        {
           

            var urn = (from u in ent.Urunler
                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                       
                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();

            rpYeniUrunler.DataSource =urn;
            rpYeniUrunler.DataBind();
            
        }
        private void MarkaIdBul()
        {
            int ID = Convert.ToInt32(Request.QueryString["AMarId"]);
            if (ID != 0)
            {
                
                        var mID = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.MarkaId == ID && u.Adet >= 0
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                rpYeniUrunler.DataSource = mID;
                rpYeniUrunler.DataBind();
            }
        }
        protected void rpYeniUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

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

        }
    }
}