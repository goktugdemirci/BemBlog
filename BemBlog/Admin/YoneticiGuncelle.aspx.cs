using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class YoneticiGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count!=0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["yonid"]);
                    Yonetici y = dm.GetYonetici(id);
                    if (y!=null)
                    {
                        tb_adi.Text = y.Adi;
                        tb_soyadi.Text = y.Soyadi;
                        tb_kullaniciadi.Text = y.KullaniciAdi;
                        tb_eposta.Text = y.Eposta;
                        tb_sifre.Text = y.Sifre;
                        if (y.YetkiID == 1)
                        {
                            rb_admin.Checked = true;
                        }
                        else
                        {
                            rb_yazar.Checked = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("YoneticiIndex.aspx");
                    }
                    
                }
            }
            else
            {
                Response.Redirect("YoneticiIndex.aspx");
            }
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["yonid"]);
            Yonetici y = dm.GetYonetici(id);
            if (dm.NullveBoslukKontrol(tb_adi.Text) != null)
            {
                tb_adi.Text = dm.NullveBoslukKontrol(tb_adi.Text);
                y.Adi = tb_adi.Text;
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullveBoslukKontrol(tb_soyadi.Text) != null)
            {
                tb_adi.Text = dm.NullveBoslukKontrol(tb_soyadi.Text);
                y.Soyadi = tb_soyadi.Text;
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullveBoslukKontrol(tb_kullaniciadi.Text) != null)
            {
                tb_kullaniciadi.Text = dm.NullveBoslukKontrol(tb_kullaniciadi.Text);
                y.KullaniciAdi = tb_kullaniciadi.Text;
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullveBoslukKontrol(tb_eposta.Text) != null)
            {
                tb_eposta.Text = dm.NullveBoslukKontrol(tb_eposta.Text);
                if (dm.ValidEposta(tb_eposta.Text))
                {
                    if (dm.UniqueEposta(tb_eposta.Text))
                    {
                        y.Eposta = tb_eposta.Text;
                    }
                    else
                    {
                        pnl_info.Visible = true;
                        lbl_message.Text = "Bu Adres Sistemde Kayıtlıdır";
                    }

                }
                else
                {
                    pnl_info.Visible = true;
                    lbl_message.Text = "E-Posta '@' ve '.com' içermelidir";
                }
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullveBoslukKontrol(tb_sifre.Text) != null)
            {
                tb_sifre.Text = dm.NullveBoslukKontrol(tb_sifre.Text);
                y.Sifre = tb_sifre.Text;
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }
            if (rb_admin.Checked)
            {
                y.YetkiID = 1;
            }
            else
            {
                y.YetkiID = 2;
            }
            if (dm.YoneticiGuncelle(y))
            {
                Response.Redirect("YoneticiIndex.aspx");
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Hata Oluştu";
            }
        }
    }
}