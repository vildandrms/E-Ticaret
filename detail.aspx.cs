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
    public partial class detail : System.Web.UI.Page
    {
        EShopEntities ent = new EShopEntities();
        cSepet c = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                UrunDetayDoldur();
            }
        }

        protected void btnSepeteEkle_Click(object sender, EventArgs e)
        {


        }
        private decimal ToplamTutarBul()
        {
            decimal toplamtutar = 0;
            DataTable dt = (DataTable)Session["sepeteAt"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamtutar += Convert.ToDecimal(dr["Tutar"]);
            }
            return toplamtutar;
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
        private void UrunDetayDoldur()
        {
            int ıdsi = Convert.ToInt32(Request.QueryString["UId"]);

            var dty = (from u in ent.Urunler
                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                       where u.id == ıdsi
                       select new { u.Fiyat, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();

            rptUrunDetay.DataSource = dty;
            rptUrunDetay.DataBind();
        }
        protected void rptUrunDetay_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["sepeteAt"] == null)
            {
                Session["sepeteAt"] = c.YeniSepet();
            }
            DataTable dt = (DataTable)Session["sepeteAt"];
            int ıdsi = Convert.ToInt32(Request.QueryString["UId"]);
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