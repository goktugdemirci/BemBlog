using DataAccessLayer;
using System;
using System.Collections.Generic;
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
            ddl_category.DataSource = dm.KategoriListele(false);
            ddl_category.DataBind();
        }

        protected void lbtn_makaleEkle_Click(object sender, EventArgs e)
        {

        }
    }
}