﻿using DataAccessLayer;
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
            lv_yoneticiler.DataSource = dm.YoneticiListele(false);
            lv_yoneticiler.DataBind();
            lv_makaleler.DataSource = dm.MakaleListele();
            lv_makaleler.DataBind();
            
        }

        protected void lv_yoneticiler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.YoneticiSil(id))
                {
                    Response.Redirect("AdminDefault.aspx");
                }
            }
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
    }
}