using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class checkout3 : System.Web.UI.Page
    {
        cOdeme.OdemeBilgileri O = new cOdeme.OdemeBilgileri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullanici"] == null)
            {

                Response.Redirect("register.aspx");

            }
        }

        protected void btnSiparisBitir_Click(object sender, EventArgs e)
        {
            if (rbKrediKart.Checked==true)
            {
               
                O.OdemeTuru1 = true;
                O.KartAd1 = txtAd.Text.Trim();
                O.KartSoyad1 = txtSoyad.Text.Trim();
                O.SkTarihi1 = Convert.ToDateTime(txtSonTrhi.Text.Trim());
                O.TaksitSayisi1 =Convert.ToInt32(txtTSayisi.Text.Trim());
                O.KartNo1 = Convert.ToDecimal(txtKartNo.Text.Trim());
                O.CvcNo1 = Convert.ToInt32(txtCvcNo.Text.Trim());

                Session["Odeme"] = O;
               
            }
            else
            {
               
                O.OdemeTuru1 = false;
                
                Session["Odeme"] = O;

            }
            Response.Redirect("checkout4.aspx");

        }

        protected void btnKargoyaGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout2.aspx");
        }

        protected void rbKrediKart_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void rbNakit_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
    }
}