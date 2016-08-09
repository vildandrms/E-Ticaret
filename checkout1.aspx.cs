using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class checkout1 : System.Web.UI.Page
    {
        cOdeme.AdresBilgileri O = new cOdeme.AdresBilgileri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["kullanici"] != null)
                {
                    
                    AdresBilgileriniDoldur();
                }
                else
                {
                    Response.Redirect("register.aspx");
                }

            }
        }

        private void AdresBilgileriniDoldur()
        {
            if (Session["Adresi"] != null)
            {
                cOdeme.AdresBilgileri oku = new cOdeme.AdresBilgileri();
                oku = (cOdeme.AdresBilgileri)Session["Adresi"];
                txtAd.Text = oku.Ad;
                txtSoyad.Text = oku.Soyad;
                txtTelefon.Text = oku.Telefon;
                txtSokak.Text = oku.Sokak;
                txtCadde.Text = oku.Cadde;
                txtEmail.Text = oku.Email;
                txtIl.Text = oku.Il;
                txtIlce.Text = oku.Ilce;
                txtMahalle.Text = oku.Mahalle;
                txtPostaKodu.Text = oku.PostaKodu.ToString();

            }

        }

        protected void btnKargoyeGec_Click1(object sender, EventArgs e)
        {

            O.Ad = txtAd.Text.Trim();
            O.Soyad = txtSokak.Text.Trim();
            O.Cadde = txtCadde.Text.Trim();
            O.Sokak = txtSokak.Text.Trim();
            O.Mahalle = txtMahalle.Text.Trim();
            O.PostaKodu = Convert.ToInt32(txtPostaKodu.Text.Trim());
            O.Il = txtIl.Text.Trim();
            O.Ilce = txtIlce.Text.Trim();
            O.Telefon = txtTelefon.Text.Trim();
            O.Email = txtEmail.Text.Trim();
            Session["Adresi"] = O;

            Response.Redirect("checkout2.aspx");


        }
    }
}