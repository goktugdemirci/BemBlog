using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class Profilim : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["uyeid"]);
                     Kullanici k = dm.KullaniciGetir(id);
                    if (k != null)
                    {
                        tb_kullaniciAdi.Text = k.KullaniciAdi;
                        tb_eposta.Text = k.Eposta;
                        dtp_dogumTarihi.Text = k.DogumTarihi.ToString("yyyy-MM-dd");
                        tb_sifre.Text = k.Sifre;
                        tb_sifre2.Text = k.Sifre;
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void ltbn_profilGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["uyeid"]);
            Kullanici k = dm.KullaniciGetir(id);
            k.KullaniciAdi = tb_kullaniciAdi.Text;
            k.Eposta=tb_eposta.Text;
            k.DogumTarihi = Convert.ToDateTime(dtp_dogumTarihi.Text);
            if (tb_sifre.Text==tb_sifre2.Text)
            {
                k.Sifre = tb_sifre.Text;
            }
            if (dm.KullaniciGuncelle(k))
            {
                Response.Redirect("default.aspx");

            }
            else
            {
                Response.Redirect($"Profilim.aspx?uyeid={k.ID}");
            }
        }
    }
}