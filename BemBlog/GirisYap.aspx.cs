using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class GirisYap : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_eposta.Text) && !String.IsNullOrEmpty(tb_sifre.Text))
            {
                if (dm.ValidEposta(tb_eposta.Text))
                {
                    Kullanici k = dm.KullaniciGirisYap(tb_eposta.Text, tb_sifre.Text);
                    if (k != null)
                    {
                        Session["uye"] = k;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_hata.Text = "E-Posta veya Şifre Hatalı";
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_hata.Text = "E-Posta '@' ve '.com' içermelidir";
                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_hata.Text = "E-Posta veya Şifre Boş Bırakılamaz";
            }
        }
    }
}