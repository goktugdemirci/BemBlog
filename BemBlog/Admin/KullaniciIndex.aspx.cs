using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog.Admin
{
    

    public partial class KullaniciIndex : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kullanicilar.DataSource = dm.KullaniciListele(false);
            lv_kullanicilar.DataBind();
        }

        protected void lv_kullanicilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName=="sil")
            {
                //if (dm.KullaniciSil(id))
                //{
                //    Response.Redirect("KullaniciIndex.aspx");

                //}
            }
        }
    }
}