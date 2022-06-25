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
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                //if (dm.YorumSil(id))
                //{
                //    Response.Redirect("AdminDefault.aspx");
                //}
            }
            else if (e.CommandName == "onayla")
            {
                //if (dm.YorumSil(id))
                //{
                //    Response.Redirect("AdminDefault.aspx");
                //}
            }
        }
    }
}