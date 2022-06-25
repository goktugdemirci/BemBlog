using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int makid = Convert.ToInt32(Request.QueryString["makid"]);
                Makale M = dm.GetMakale(makid);
                ltrl_title.Text = M.Baslik;
                ltrl_content.Text = M.TamIcerik;
                ltrl_category.Text = " 📌 " + M.KategoriAdi;
                ltrl_author.Text = M.YetkiAdi + " 📝 " +M.Adi;
                img_max.ImageUrl = "Images/" + M.TamResimAdi;
                lv_comments.DataSource = dm.YorumListele(makid);
                lv_comments.DataBind();
                if (Session["uye"] != null)
                {
                    pnl_loggedin.Visible = true;
                    pnl_loggedout.Visible = false;
                }
                else
                {
                    pnl_loggedin.Visible = false;
                    pnl_loggedout.Visible = true;
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        protected void lbtn_gonder_Click(object sender, EventArgs e)
        {
            Yorum Y = new Yorum();
            int makid = Convert.ToInt32(Request.QueryString["makid"]);
            Y.MakaleID = makid;
            Y.KullaniciID = ((Kullanici)Session["uye"]).ID;
            Y.KullaniciAdi = ((Kullanici)Session["uye"]).KullaniciAdi;
            Y.YorumIcerik = tb_comment.Text;
            Y.YorumTarihi = DateTime.Now;
            Y.IsDeleted = true;
            if (dm.YorumEkle(Y))
            {
                tb_comment.Text = "";
                lbl_mesaj.Text = "Yorum Onaylandıktan Sonra Gösterimde Olacak";
            }
            else
            {
                lbl_mesaj.Text = "Bir Hata Oluştu.";
            }
        }
    }
}