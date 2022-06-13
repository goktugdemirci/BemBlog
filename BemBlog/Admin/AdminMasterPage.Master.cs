using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["yonetici"];
                lbl_info.Text = $"Hoşgeldiniz {y.YetkiAdi} {y.Adi} {y.Soyadi}";
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }

        protected void lbtn_exit_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("YoneticiGiris.aspx");
        }
    }
}