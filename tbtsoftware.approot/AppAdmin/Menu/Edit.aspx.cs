using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using Resources;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Menu
{
    public partial class Edit : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AdminID"] == null)
            {
                objComm.wr(
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=chinh-sua-menu';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Sửa thông tin menu" + language.title_separator + language.website_name;
            }
        }

        #endregion
    }
}