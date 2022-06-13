using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kategoriEkle_Click(object sender, EventArgs e)
        {
            if (dm.NullveBoslukKontrol(tb_kategoriAdi.Text)!=null)
            {
                tb_kategoriAdi.Text = dm.NullveBoslukKontrol(tb_kategoriAdi.Text);
                if (dm.UniqueKategori(tb_kategoriAdi.Text))
                {
                    Kategori k = new Kategori();
                    k.KategoriAdi = tb_kategoriAdi.Text;
                    k.IsDeleted = false;
                    if (dm.KategoriEkle(k))
                    {
                        Response.Redirect("KategoriIndex.aspx");
                    }
                    else
                    {
                        pnl_info.Visible = true;
                        lbl_message.Text = "Bağlantı Hatası";
                    }
                }
                else
                {
                    pnl_info.Visible = true;
                    lbl_message.Text = "Bu Kategori Mevcut";
                }
            }
            else
            {
                pnl_info.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }
        }
    }
}