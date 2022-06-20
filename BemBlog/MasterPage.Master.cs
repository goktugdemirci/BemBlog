using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] == null)
            {
                pnl_out.Visible = true;
                pnl_in.Visible = false;
            }
            else
            {
                pnl_out.Visible = false;
                pnl_in.Visible = true;
                Kullanici k = (Kullanici)Session["kullanici"];
                lbl_user.Text = k.KullaniciAdi;
            }


            rp_categories.DataSource = dm.KategoriListele(false);
            rp_categories.DataBind();
        }

        protected void lbtn_exit_Click(object sender, EventArgs e)
        {

        }
    }
}