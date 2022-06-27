using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class YeniKayit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ltbn_yeniKayit_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciAdi = tb_kullaniciAdi.Text;
            k.Eposta = tb_eposta.Text;
            if (tb_sifre.Text==tb_sifre2.Text)
            {
                k.Sifre = tb_sifre.Text;
            }
            else
            {
                //HATA
            }
            k.DogumTarihi = Convert.ToDateTime(dtp_dogumTarihi.Text);
            
            k.UyelikTarihi = DateTime.Now;
            k.IsDeleted = true;
            if (dm.KullaniciEkle(k))
            {
                Response.Redirect("GirisYap.aspx");
            }
            else
            {
                //Hata
            }
        }
    }
}