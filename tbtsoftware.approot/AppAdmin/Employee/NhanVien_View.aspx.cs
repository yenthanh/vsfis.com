using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Employee
{
    public partial class NhanVien_View : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminID"] == null)
            {
                this.objComm.wr("<script language='javascript'>location.href='quan-tri?ReturnUrl=nhan-vien';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Nhân viên - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}