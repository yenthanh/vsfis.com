namespace bnb.approot.AppAdmin.Agent.Supplier
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class Index : Page
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
                    "<script language='javascript'>location.href='quan-tri?ReturnUrl=nha-cung-cap';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Nhà cung cấp - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}