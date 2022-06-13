using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class YoneticiEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            Yonetici y = new Yonetici();
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
            if (dm.YoneticiEkle(y))
            {
                Response.Redirect("AdminDefault.aspx");
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Hata Oluştu";
            }
        }
    }
}