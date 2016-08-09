using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class checkout2 : System.Web.UI.Page
    {
        cOdeme.KargoBilgileri o = new cOdeme.KargoBilgileri();
        cOdeme.OdemeBilgileri odme = new cOdeme.OdemeBilgileri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullanici"] != null)
            {

            
            if (Session["Kargosu"]!=null)
            {
                cOdeme.KargoBilgileri oku = new cOdeme.KargoBilgileri();
                oku = (cOdeme.KargoBilgileri)Session["Kargosu"];

                if (oku.Kargo1=="Aras Kargo")
                {
                    rbAras.Checked = true;
                   
                }
                else if (oku.Kargo1 == "Ups Kargo")
                {
                    rbUps.Checked = true;
                }
                else if (oku.Kargo1 == "Yurtiçi Kargo")
                {
                    rbYurtİci.Checked = true;
                }

            }
            }
            else
            {
               
                    Response.Redirect("register.aspx");           
            }
        }

        protected void btnOdemeyeGec_Click(object sender, EventArgs e)
        {
            //cOdeme.OdemeBilgileri odme = new cOdeme.OdemeBilgileri();
            //odme = (cOdeme.OdemeBilgileri)Session["Odeme"];
            if (rbAras.Checked == true)
            {
                o.Kargo1 = "Aras Kargo";
                Session["Kargosu"] = o;
                odme.SiparisTrh1 = DateTime.Now;
                odme.TeslimTrh1 = DateTime.Now.AddDays(3);
                Session["Odeme"] = odme;
               
            }
            else if (rbUps.Checked==true)
            {
                o.Kargo1 = "Ups Kargo";
                Session["Kargosu"] = o;
                odme.SiparisTrh1 = DateTime.Now;
                odme.TeslimTrh1 = DateTime.Now.AddDays(1);
                Session["Odeme"] = odme;
            }
            else if (rbYurtİci.Checked==true)
            {
                o.Kargo1 = "Yurtiçi Kargo";
                Session["Kargosu"] = o;
                odme.SiparisTrh1 = DateTime.Now;
                odme.TeslimTrh1 = DateTime.Now.AddDays(7);
                Session["Odeme"] = odme;
            }

        
            Response.Redirect("checkout3.aspx");

        }

        protected void btnAdreseGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout1.aspx");
        }
    }
}