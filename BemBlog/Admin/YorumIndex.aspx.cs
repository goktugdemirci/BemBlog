using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    public partial class YorumIndex : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();
            lv_aktifYorum.DataSource = dm.YorumListele(false);
            lv_aktifYorum.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "aktif")
            {
                if (dm.YorumDurumGuncelle(id,false))
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

        protected void lv_aktifYorum_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "pasif")
            {
                if (dm.YorumDurumGuncelle(id, true))
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