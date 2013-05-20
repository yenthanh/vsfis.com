namespace MinhPham.Web.BepNhaBan.AppAdmin.ThuongHieu
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class ThuongHieuPage : Page
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
                    "<script language='javascript'>location.href='quan-tri?ReturnUrl=thuong-hieu';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Thương hiệu - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}