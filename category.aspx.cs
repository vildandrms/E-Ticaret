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
    public partial class category : System.Web.UI.Page
    {
        cSepet c = new cSepet();
        EShopEntities ent = new EShopEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                UrunleriDoldur();
                SepetiGoster();
                
               
            }
        }
        private void UrunleriDoldur()
        {
            {
                int kID = Convert.ToInt32(Request.QueryString["EkatId"]);
                int KaID = Convert.ToInt32(Request.QueryString["KkatId"]);
                int KdnID = Convert.ToInt32(Request.QueryString["UKatId"]);
                int KdnMarkaID = Convert.ToInt32(Request.QueryString["UMarId"]);
                int ErkID = Convert.ToInt32(Request.QueryString["UEKatId"]);
                int ErkMarkaID = Convert.ToInt32(Request.QueryString["UEMarId"]);
                int MarkayaGoreID = Convert.ToInt32(Request.QueryString["AMarId"]);
                int RengeGoreID = Convert.ToInt32(Request.QueryString["ARenkId"]);
                string  ArananKelime = Request.QueryString["Aranan"];


                if (kID != 0)
                {

                    if (MarkayaGoreID != 0)
                    {

                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.KategoriID == kID && u.CinsiyetId == 2 && mrk.id == MarkayaGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.KategoriID == kID && u.CinsiyetId == 2 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {

                        var erk = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.KategoriID == kID && u.CinsiyetId == 2
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erk;
                        rptUrunler.DataBind();

                    }

                }
                else if (KaID != 0)
                {
                    if (MarkayaGoreID != 0)
                    {

                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.KategoriID == KaID && u.CinsiyetId == 1 && mrk.id == MarkayaGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.KategoriID == KaID && u.CinsiyetId == 1 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {

                        var erk = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.KategoriID == KaID && u.CinsiyetId == 1
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();

                        rptUrunler.DataSource = erk;
                        rptUrunler.DataBind();

                    }
                }
                else if (KdnID != 0)
                {
                    if (MarkayaGoreID != 0)
                    {

                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.UrunKatId == KdnID && u.CinsiyetId == 1 && mrk.id == MarkayaGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.UrunKatId == KdnID && u.CinsiyetId == 1 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {
                        var katId3 = (from u in ent.Urunler
                                      join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                      join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                      join rnk in ent.Renkler on u.RenkId equals rnk.id
                                      where u.UrunKatId == KdnID && u.CinsiyetId == 1
                                      select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = katId3;
                        rptUrunler.DataBind();
                    }
                }
                else if (KdnMarkaID != 0)
                {
                    if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.MarkaId == KdnMarkaID && u.CinsiyetId == 1 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {
                        var kdn = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.MarkaId == KdnMarkaID && u.CinsiyetId == 1
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = kdn;
                        rptUrunler.DataBind();

                    }
                }
                else if (ErkID != 0)
                {
                    if (MarkayaGoreID != 0)
                    {

                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.UrunKatId == ErkID && u.CinsiyetId == 2 && mrk.id == MarkayaGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.UrunKatId == ErkID && u.CinsiyetId == 2 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {
                        var katId3 = (from u in ent.Urunler
                                      join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                      join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                      join rnk in ent.Renkler on u.RenkId equals rnk.id
                                      where u.UrunKatId == ErkID && u.CinsiyetId == 2
                                      select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = katId3;
                        rptUrunler.DataBind();
                    }
                }
                else if (ErkMarkaID != 0)
                {
                    if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where u.MarkaId == ErkMarkaID && u.CinsiyetId == 2 && rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else
                    {

                        var kdn = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.MarkaId == ErkMarkaID && u.CinsiyetId == 2
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = kdn;
                        rptUrunler.DataBind();
                    }
                }

                else
                {
                    if (MarkayaGoreID != 0)
                    {

                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where mrk.id == MarkayaGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (RengeGoreID != 0)
                    {
                        var erkM = (from u in ent.Urunler
                                    join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                    join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                    join rnk in ent.Renkler on u.RenkId equals rnk.id
                                    where rnk.id == RengeGoreID
                                    select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = erkM;
                        rptUrunler.DataBind();

                    }
                    else if (ArananKelime!=null)
                    {
                       
                        var aranankelime = (from u in ent.Urunler
                                            join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                            join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                            join kat in ent.Kategoriler on u.KategoriID equals kat.id
                                            join rnk in ent.Renkler on u.RenkId equals rnk.id
                                            where mrk.MarkaAd == ArananKelime || urnkat.GiyimAd==ArananKelime || kat.KategoriAd==ArananKelime
                                            select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                        rptUrunler.DataSource = aranankelime;
                        rptUrunler.DataBind();
                    }
                    else
                    {

                        var urn = (from u in ent.Urunler
                                   join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                   join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                   join rnk in ent.Renkler on u.RenkId equals rnk.id
                                   where u.YeniMi == true
                                   select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();


                        rptUrunler.DataSource = urn;
                        rptUrunler.DataBind();
                    }
                }
            }
        }
        protected void btnSepeteEkle_Click(object sender, EventArgs e)
        {

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
        protected void rptUrunler_ItemCommand1(object source, RepeaterCommandEventArgs e)
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
        private void DropSıralamaDoldur(int? EkatId, int? KkatId, int? UKatId, int? UMarId, int? UEKatId, int? UEMarId)
        {
            if (EkatId != 0 || UEKatId != 0 || UEMarId != 0)
            {

                if (ddlSıralama.SelectedValue == "Artan Fiyat")
                {


                    var artanFiyat = (from u in ent.Urunler
                                      join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                      join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                      join rnk in ent.Renkler on u.RenkId equals rnk.id
                                      where u.CinsiyetId == 2 && (u.KategoriID == EkatId || u.UrunKatId == UEKatId || u.MarkaId == UEMarId)
                                      orderby u.Fiyat ascending
                                      select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = artanFiyat;
                    rptUrunler.DataBind();
                }
                else if (ddlSıralama.SelectedValue == "Azalan Fiyat")
                {
                    var azalanFiyat = (from u in ent.Urunler
                                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                                       where u.CinsiyetId == 2 && (u.KategoriID == EkatId || u.UrunKatId == UEKatId || u.MarkaId == UEMarId)
                                       orderby u.Fiyat descending
                                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = azalanFiyat;
                    rptUrunler.DataBind();
                }
                else if (ddlSıralama.SelectedValue == "Markaya Göre")
                {
                    var azalanFiyat = (from u in ent.Urunler
                                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                                       where u.CinsiyetId == 2 && (u.KategoriID == EkatId || u.UrunKatId == UEKatId || u.MarkaId == UEMarId)
                                       orderby mrk.MarkaAd ascending
                                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = azalanFiyat;
                    rptUrunler.DataBind();
                }
            }
            else if (KkatId!=0 || UKatId!=0 || UMarId!=0)
            {

                if (ddlSıralama.SelectedValue == "Artan Fiyat")
                {


                    var artanFiyat = (from u in ent.Urunler
                                      join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                      join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                      join rnk in ent.Renkler on u.RenkId equals rnk.id
                                      where u.CinsiyetId == 1 && (u.KategoriID ==KkatId || u.UrunKatId == UKatId || u.MarkaId == UMarId)
                                      orderby u.Fiyat ascending
                                      select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = artanFiyat;
                    rptUrunler.DataBind();
                }
                else if (ddlSıralama.SelectedValue == "Azalan Fiyat")
                {
                    var azalanFiyat = (from u in ent.Urunler
                                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                                       where u.CinsiyetId == 1 && (u.KategoriID == KkatId || u.UrunKatId == UKatId || u.MarkaId == UMarId)
                                       orderby u.Fiyat descending
                                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = azalanFiyat;
                    rptUrunler.DataBind();
                }
                else if (ddlSıralama.SelectedValue == "Markaya Göre")
                {
                    var azalanFiyat = (from u in ent.Urunler
                                       join mrk in ent.Markalar on u.MarkaId equals mrk.id
                                       join urnkat in ent.UrunKategorileri on u.UrunKatId equals urnkat.id
                                       join rnk in ent.Renkler on u.RenkId equals rnk.id
                                       where u.CinsiyetId == 1 && (u.KategoriID == KkatId || u.UrunKatId == UKatId || u.MarkaId == UMarId)
                                       orderby mrk.MarkaAd ascending
                                       select new { u.Fiyat, u.id, u.UrunMetaryali, u.UrunTanimi, u.ResimBir, u.Resimİki, u.ResimUc, urnkat.GiyimAd, mrk.MarkaAd, rnk.RenkAd }).ToList();
                    rptUrunler.DataSource = azalanFiyat;
                    rptUrunler.DataBind();
                }
            }
        }
        protected void ddlSıralama_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kID = Convert.ToInt32(Request.QueryString["EkatId"]);
            int KaID = Convert.ToInt32(Request.QueryString["KkatId"]);
            int KdnID = Convert.ToInt32(Request.QueryString["UKatId"]);
            int KdnMarkaID = Convert.ToInt32(Request.QueryString["UMarId"]);
            int ErkID = Convert.ToInt32(Request.QueryString["UEKatId"]);
            int ErkMarkaID = Convert.ToInt32(Request.QueryString["UEMarId"]);
            DropSıralamaDoldur(kID, KaID, KdnID, KdnMarkaID, ErkID, ErkMarkaID);
                   }
    }
}