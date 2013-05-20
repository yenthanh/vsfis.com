using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Content
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=/AppAdmin/Article/Index.aspx';</script>");
            }
        }

        #endregion
    }
}