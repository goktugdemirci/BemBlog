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
            List<Kullanici> aktifKullanicilar = new List<Kullanici>();
            List<Kullanici> pasifKullanicilar = new List<Kullanici>();
            foreach (Kullanici item in dm.KullaniciListele())
            {
                item.Yas = (int)DateTime.Now.Year - (int)item.DogumTarihi.Year;
                if (item.IsDeleted)
                {
                    pasifKullanicilar.Add(item);
                }
                else
                {
                    aktifKullanicilar.Add(item);
                }
            }
            lv_aktifler.DataSource = aktifKullanicilar;
            lv_aktifler.DataBind();
            lv_kullanicilar.DataSource = pasifKullanicilar;
            lv_kullanicilar.DataBind();

        }

        protected void lv_kullanicilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName=="aktifEt")
            {
                if (dm.KullaniciGuncelle(id,false))
                {
                    Response.Redirect("KullaniciIndex.aspx");

                }
            }
            else if (e.CommandName == "kaliciSil")
            {
                if (dm.KaliciSil(id))
                {
                    Response.Redirect("KullaniciIndex.aspx");
                }
            }
        }

        protected void lv_aktifler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "pasifEt")
            {
                if (dm.KullaniciGuncelle(id, true)&&dm.YorumBanla(id))
                {
                    Response.Redirect("KullaniciIndex.aspx");

                }
            }
            else if (e.CommandName == "kaliciSil")
            {
                if (dm.KaliciSil(id))
                {
                    Response.Redirect("KullaniciIndex.aspx");
                }
            }
        }
    }
}