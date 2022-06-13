using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace BemBlog.Admin
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_kullaniciAdi.Text) && !String.IsNullOrEmpty(tb_sifre.Text))
            {
                if (dm.ValidEposta(tb_kullaniciAdi.Text))
                {
                    Yonetici y = dm.GirisYap(tb_kullaniciAdi.Text, tb_sifre.Text);
                    if (y != null)
                    {
                        Session["yonetici"] = y;
                        Response.Redirect("AdminDefault.aspx");
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