using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class AdminDefault : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();
            lv_makaleler.DataSource = dm.MakaleListele();
            lv_makaleler.DataBind();

        }

        protected void lv_makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.MakaleSil(id))
                {
                    Response.Redirect("AdminDefault.aspx");
                }
            }
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "aktif")
            {
                if (dm.YorumDurumGuncelle(id, false))
                {
                    Response.Redirect("YorumIndex.aspx");
                }
            }
            else if (e.CommandName == "kaliciSil")
            {
                if (dm.YorumKaliciSil(id))
                {
                    Response.Redirect("YorumIndex.aspx");
                }
            }
        }
    }
}