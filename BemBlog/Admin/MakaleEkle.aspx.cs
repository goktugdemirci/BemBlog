using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_category.DataSource = dm.KategoriListele(false);
                ddl_category.DataBind();
            }
        }

        protected void lbtn_makaleEkle_Click(object sender, EventArgs e)
        {
            Makale m = new Makale();
            m.Baslik = tb_baslik.Text;
            m.KategoriID = Convert.ToInt32(ddl_category.SelectedItem.Value);
            m.Ozet = tb_list.Text;
            m.TamIcerik = tb_tam.Text;
            m.IsDeleted = !cb_confirm.Checked;
            m.YuklemeTarih = DateTime.Now;
            Yonetici y = (Yonetici)Session["yonetici"];
            m.YoneticiID = y.ID;
            if (fu_min.HasFile)
            {
                FileInfo fi = new FileInfo(fu_min.FileName);
                string fileName = Guid.NewGuid().ToString();
                fileName += fi.Extension;
                fu_min.SaveAs(Server.MapPath("~/Images/" +fileName));
                m.ThumbnailAdi = fileName;
            }
            else
            {
                m.ThumbnailAdi = "noimage.png";
            }
            if (fu_max.HasFile)
            {
                FileInfo fi = new FileInfo(fu_max.FileName);
                string fileName = Guid.NewGuid().ToString();
                fileName += fi.Extension;
                fu_max.SaveAs(Server.MapPath("~/Images/" + fileName));
                m.TamResimAdi = fileName;
            }
            else
            {
                m.TamResimAdi = "noimage.png";
            }
            if (dm.MakaleEkle(m))
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