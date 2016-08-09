using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace E_Shop
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
          SqlConnection con = new SqlConnection("server=.;Database=EShop;Uid=sa;Pwd=12345");
            DataSet ds = new DataSet();
        //    [WebMethod]
        //    public DataSet DefaultUrunleriDoldur(Repeater Urunler)
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("select * from Urunler  ", con);
        //        da.Fill(ds, "Urunler");
        //        Urunler.DataSource = ds.Tables["Urunler"];
        //        Urunler.DataBind();
        //        return ds;


        //    }

        //    [WebMethod]
        //    public DataSet DetailUrunleriDoldur(int UId, Repeater Urunler)
        //    {

        //        SqlDataAdapter da = new SqlDataAdapter("select u.Fiyat,u.UrunMetaryali,u.UrunTanimi,u.ResimBir,u.Resimİki,u.ResimUc,k.GiyimAd,m.MarkaAd,rk.RenkAd from Urunler u inner join Markalar m  on u.MarkaId=m.id inner join UrunKategorileri k on u.UrunKatId=k.id inner join Renkler rk on u.RenkId=rk.id  where u.id=@Idsi", con);
        //        da.SelectCommand.Parameters.Add("@Idsi", SqlDbType.Int).Value = UId;
        //        da.Fill(ds, "Urunler");
        //        Urunler.DataSource = ds.Tables["Urunler"];
        //        Urunler.DataBind();
        //        return ds;
        //    }
        //    public DataSet AnaMenuDoldur(Repeater kadınGiyim, Repeater kadınAyakkabı, Repeater kadınAksesuar, Repeater kadınMarkalar, Repeater erkekGiyim, Repeater erkekAyakkabı,Repeater erkekAksesuar, Repeater erkekMarkalar, int? KdnId, int? ErkId, Repeater SagMenuMarkalar, Repeater SagMenuRenkler)
        //    {
        //        ///  Kadın Ana Menusunu Doldurdum
        //        /// 

        //        SqlDataAdapter da = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=1 and CinsiyetId=1", con);
        //        SqlDataAdapter da1 = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=2 and CinsiyetId=1", con);
        //        SqlDataAdapter da2 = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=3 and CinsiyetId=1", con);
        //        SqlDataAdapter da3 = new SqlDataAdapter("select  distinct m.MarkaAd,m.id from Urunler u inner join Markalar m on u.MarkaId=m.id where  CinsiyetId=1", con);

        //        da.Fill(ds, "Urunler");
        //        kadınGiyim.DataSource = ds.Tables["Urunler"];
        //        kadınGiyim.DataBind();
        //        ds.Clear();
        //        da1.Fill(ds, "Urunler");
        //        kadınAyakkabı.DataSource = ds.Tables["Urunler"];
        //        kadınAyakkabı.DataBind();
        //        ds.Clear();
        //        da2.Fill(ds, "Urunler");
        //        kadınAksesuar.DataSource = ds.Tables["Urunler"];
        //        kadınAksesuar.DataBind();
        //        ds.Clear();
        //        da3.Fill(ds, "Urunler");
        //        kadınMarkalar.DataSource = ds.Tables["Urunler"];
        //        kadınMarkalar.DataBind();
        //        ds.Clear();
        //        ///// Erkek Ana menusunu doldurdum

        //        SqlDataAdapter da4 = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=1 and CinsiyetId=2", con);
        //        SqlDataAdapter da5 = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=2 and CinsiyetId=2", con);
        //        SqlDataAdapter da6 = new SqlDataAdapter("select distinct k.GiyimAd,k.id from Urunler u inner join UrunKategorileri k on u.UrunKatId=k.id where u.KategoriID=3 and CinsiyetId=2", con);
        //        SqlDataAdapter da7 = new SqlDataAdapter("select  distinct m.MarkaAd,m.id from Urunler u inner join Markalar m on u.MarkaId=m.id where  CinsiyetId=2", con);

        //        da4.Fill(ds, "Urunler");
        //        erkekGiyim.DataSource = ds.Tables["Urunler"];
        //        erkekGiyim.DataBind();
        //        ds.Clear();

        //        da5.Fill(ds, "Urunler");
        //        erkekAyakkabı.DataSource = ds.Tables["Urunler"];
        //        erkekAyakkabı.DataBind();
        //        ds.Clear();

        //        da6.Fill(ds, "Urunler");
        //        erkekAksesuar.DataSource = ds.Tables["Urunler"];
        //        erkekAksesuar.DataBind();
        //        ds.Clear();

        //        da7.Fill(ds, "Urunler");
        //        erkekMarkalar.DataSource = ds.Tables["Urunler"];
        //        erkekMarkalar.DataBind();
        //        ds.Clear();
        //        ////// Querystring den gelen ıd ye gore markaları doldurmak Kadın sa ve erkekse  yada hepsi arama yaparken kullanılması için olan markalar
        //        if (ErkId != 0)
        //        {
        //            SqlDataAdapter da8 = new SqlDataAdapter("select m.MarkaAd,m.id  from Urunler u inner join Markalar m on u.MarkaId=m.id where u.KategoriId=@Kid and CinsiyetId=2  ", con);
        //            da8.SelectCommand.Parameters.Add("@Kid", SqlDbType.Int).Value = ErkId;
        //            da8.Fill(ds, "Urunler");
        //            SagMenuMarkalar.DataSource = ds.Tables["Urunler"];
        //            SagMenuMarkalar.DataBind();
        //            ds.Clear();

        //            SqlDataAdapter da11 = new SqlDataAdapter("select r.RenkAd,r.id  from Urunler u inner join Renkler r on u.RenkId=r.id where u.KategoriId=@Kid and CinsiyetId=2  ", con);
        //            da11.SelectCommand.Parameters.Add("@Kid", SqlDbType.Int).Value = ErkId;
        //            da11.Fill(ds, "Urunler");
        //            SagMenuRenkler.DataSource = ds.Tables["Urunler"];
        //            SagMenuRenkler.DataBind();
        //            ds.Clear();

        //        }
        //        else if (KdnId != 0)
        //        {
        //            SqlDataAdapter da9 = new SqlDataAdapter("select  m.MarkaAd,m.id  from Urunler u inner join Markalar m on u.MarkaId=m.id where u.KategoriId=@Kid and CinsiyetId=1", con);
        //            da9.SelectCommand.Parameters.Add("@Kid", SqlDbType.Int).Value = KdnId;
        //            da9.Fill(ds, "Urunler");
        //            SagMenuMarkalar.DataSource = ds.Tables["Urunler"];
        //            SagMenuMarkalar.DataBind();
        //            ds.Clear();

        //            SqlDataAdapter da12 = new SqlDataAdapter("select r.RenkAd,r.id  from Urunler u inner join Renkler r on u.RenkId=r.id where u.KategoriId=@Kid and CinsiyetId=1  ", con);
        //            da12.SelectCommand.Parameters.Add("@Kid", SqlDbType.Int).Value = KdnId;
        //            da12.Fill(ds, "Urunler");
        //            SagMenuRenkler.DataSource = ds.Tables["Urunler"];
        //            SagMenuRenkler.DataBind();
        //            ds.Clear();
        //        }
        //        else
        //        {
        //            SqlDataAdapter da10 = new SqlDataAdapter("select  m.MarkaAd,m.id  from Urunler u inner join Markalar m on u.MarkaId=m.id", con);
        //            da10.Fill(ds, "Urunler");
        //            SagMenuMarkalar.DataSource = ds.Tables["Urunler"];
        //            SagMenuMarkalar.DataBind();
        //            ds.Clear();

        //            SqlDataAdapter da13 = new SqlDataAdapter("select r.RenkAd,r.id  from Urunler u inner join Renkler r on u.RenkId=r.id  ", con);
        //            da13.Fill(ds, "Urunler");
        //            SagMenuRenkler.DataSource = ds.Tables["Urunler"];
        //            SagMenuRenkler.DataBind();
        //            ds.Clear();
        //        }
        //        return ds;
        //    }
        //    [WebMethod]
        public DataSet AnaMenuKadınKategorileriDoldur(Repeater kadınKategorileri)
        {
            SqlDataAdapter da14 = new SqlDataAdapter("select  distinct k.KategoriAd,k.id from Urunler u inner join Kategoriler k on u.KategoriID=k.id where CinsiyetId=1",
                con);
            da14.Fill(ds, "Kategoriler");
            kadınKategorileri.DataSource = ds.Tables["Kategoriler"];
            kadınKategorileri.DataBind();
            ds.Clear();
            return ds;

        }
        //    public DataSet AnaMenuErkekKategorileriDoldur(Repeater erkekKategorileri)
        //    {
        //        SqlDataAdapter da15 = new SqlDataAdapter("select  distinct k.KategoriAd,k.id from Urunler u inner join Kategoriler k on u.KategoriID=k.id where CinsiyetId=2", con);
        //        da15.Fill(ds, "Kategoriler");
        //        erkekKategorileri.DataSource = ds.Tables["Kategoriler"];
        //        erkekKategorileri.DataBind();
        //        ds.Clear();
        //        return ds;
        //    }
        //    public DataSet SepeteEkle(int UrunId,Repeater Sepet)
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("select * from Urunler Where id=@IDsi",con);
        //        da.SelectCommand.Parameters.Add("@IDsi", SqlDbType.Int).Value = UrunId;
        //        da.Fill(ds,"Urunler");
        //        Sepet.DataSource = ds.Tables["Urunler"];
        //        Sepet.DataBind();
        //        return ds;

        //    }
    }
}
