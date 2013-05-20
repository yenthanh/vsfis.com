using System;
using System.Web;
using System.Web.UI;

namespace MinhPham.Web.BepNhaBan.Partners
{
    public partial class Default : UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int l;
                if (Request.Cookies["l"] != null)
                {
                    l = int.Parse(Request.Cookies["l"].Value);
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "1"));
                    l = 1;
                }
                switch (l)
                {
                    case 1:
                        Label1.Text = "Partners";
                        break;
                    case 2:
                        Label1.Text = "パートナー";
                        break;
                    case 3:
                        Label1.Text = "Đối tác";
                        break;
                }
            }
        }

        #endregion
    }
}