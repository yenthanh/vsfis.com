using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.AdminHistoryLog
{
    public partial class HistoryLogin : Page
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=lich-su-dang-nhap';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Lịch sử truy cập - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}