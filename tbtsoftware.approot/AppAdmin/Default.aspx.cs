using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using Resources;

namespace MinhPham.Web.BepNhaBan.AppAdmin
{
    public partial class Default : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AdminID"] == null)
            {
                objComm.wr("<script language='javascript'>location.href='/AppAdmin/Login.aspx';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Quản trị hệ thống" + language.title_separator + language.website_name;
            }
        }

        #endregion
    }


}