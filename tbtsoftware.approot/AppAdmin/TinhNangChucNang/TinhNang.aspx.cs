namespace MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class TinhNang : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Cookies["AdminID"] == null)
            {
                this.objComm.wr(
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=nhom-chuc-nang';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Tính năng - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}