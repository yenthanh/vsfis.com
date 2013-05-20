using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using Resources;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Menu
{
    public partial class Add : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //todo: auto create url fragment from menu name.
            //todo: upload avatar of menu.
            if (Request.Cookies["AdminID"] == null)
            {
                objComm.wr(
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=them-danh-muc';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Thêm menu" + language.title_separator + language.website_name;
            }
        }

        #endregion
    }
}