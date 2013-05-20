namespace bnb.approot.AppAdmin.Employee
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class NhanVien_Add : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminID"] == null)
            {
                this.objComm.wr(
                    "<script language='javascript'>location.href='quan-tri?ReturnUrl=them-nhan-vien';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Thêm nhân viên - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}