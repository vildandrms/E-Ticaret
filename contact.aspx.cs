using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Shop
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() != "")
            {
               
               
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("wissendeneme@gmail.com", "Wissen MS-Yaz_10", System.Text.Encoding.UTF8);
                    mail.To.Add("vildan898991@gmail.com");
                  
                    mail.Subject = "Giyim Ürünleri-Ticaret Sitesi";
                    // mail.Body = "Sayın," + k.ad+ " "+k.soyad+" "+"<br/>Şifreniz :"+k.sifre ;//mesaj göderilen
                    StringBuilder sbMesaj = new StringBuilder();
                    sbMesaj.Append("Sayın," + txtAd.Text + " " + txtSoyad.Text +","+"<br/>" +txtEmail.Text+"<br/>"+txtMesaj.Text+"<br/>");
                    sbMesaj.Append("<a href=\"" + Request.Url.Host + "/category.aspx\" >Alişverise devam için tıklayınız</a> ");
                    //geldiğisayfya gitmesiiçin  Request.Url.Host
                    mail.Body = sbMesaj.ToString();
                    mail.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient();
                    sc.Host = "smtp.gmail.com";  // mail.domain.com
                    sc.Port = 587;
                    sc.EnableSsl = true; //ssl sertifikaları kullanıyorsa belirmek lazım
                    sc.Credentials = new NetworkCredential("wissendeneme@gmail.com", "wissen123");//gondelirecek epoasta ve sifresi
                    try
                    {
                        sc.Send(mail);
                       
                    }
                    catch (Exception ex)
                    {

                        string hat = ex.Message;
                    }

                }
               
            
        }
    }
}