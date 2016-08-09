using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepeteAt"];
            if (!IsPostBack)
            {
                SepetiDoldur(dt);
                
            }

        }

        private void SepetiDoldur(DataTable dt)
        {
            if (Session["sepeteAt"] != null)
            {
                rptSiparisler.DataSource = dt;
                rptSiparisler.DataBind();

                lblToplam.Text = ToplamTutarBul().ToString();

            }




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

        protected void btnSiparisSil_Click(object sender, EventArgs e)
        {

        }

        protected void rptSiparisler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ıd = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)Session["sepeteAt"];
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sepetID"]) == ıd && Convert.ToInt32(dr["Adet"]) > 1)
                {
                    dr["Adet"] = (Convert.ToInt32(dr["Adet"]) - 1).ToString();
                    Session["sepeteAt"] = dt;
                    SepetiDoldur(dt);

                    return;
                }

            }
            if (HttpContext.Current.Session["sepeteAt"] != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["sepetID"].ToString() == ıd.ToString())
                    {
                        dt.Rows[i].Delete();
                        HttpContext.Current.Session["sepeteAt"] = dt;
                        SepetiDoldur(dt);
                        break;
                    }

                }
            }

        }

        protected void btnOdemeyeGec_Click(object sender, EventArgs e)
        {
            string syf = "basket.aspx";
            if (Session["kullanici"] != null)
            {
                Response.Redirect("checkout1.aspx");

            }
            else
            {
                Response.Redirect(string.Format("register.aspx?yonlendirme={0}", syf));

            }
        }
    }
}
