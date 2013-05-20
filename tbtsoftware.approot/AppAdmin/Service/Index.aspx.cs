using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using Resources;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Service
{
    public partial class Index : Page
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=/AppAdmin/Service/Index.aspx';</script>");
            }
            if (!IsPostBack)
            {
                Title = language.service_title + language.title_separator + language.website_name;
            }
        }

        #endregion
    }
}