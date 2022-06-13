using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class KategoriGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count!=0)
            {
                if (!IsPostBack)
                {
                    int kategoriID = Convert.ToInt32(Request.QueryString["katid"]);
                    Kategori k = dm.GetKategori(kategoriID);
                    tb_kategoriAdi.Text = k.KategoriAdi;
                }
            }
            else
            {
                Response.Redirect("KategoriIndex.aspx");
            }
        }

        protected void lbtn_kategoriGuncelle_Click(object sender, EventArgs e)
        {
            int kategoriID = Convert.ToInt32(Request.QueryString["katid"]);
            Kategori k = dm.GetKategori(kategoriID);
            if (dm.NullveBoslukKontrol(tb_kategoriAdi.Text) != null)
            {
                tb_kategoriAdi.Text = dm.NullveBoslukKontrol(tb_kategoriAdi.Text);
                if (dm.UniqueKategori(tb_kategoriAdi.Text))
                {
                    k.KategoriAdi = tb_kategoriAdi.Text;
                    k.IsDeleted = false;
                    if (dm.KategoriGuncelle(k))
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