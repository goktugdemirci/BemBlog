using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BemBlog
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                lv_articles.DataSource = dm.MakaleListele();
                lv_articles.DataBind();
            }
            else
            {
                int katid = Convert.ToInt32(Request.QueryString["katid"]);
                lv_articles.DataSource = dm.GetMakalesByKategori(katid);
                lv_articles.DataBind();
            }
        }
    }
}