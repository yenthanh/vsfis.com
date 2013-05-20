using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Config.Branch
{
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
                this.objComm.wr("<script language='javascript'>location.href='quan-tri?ReturnUrl=chi-nhanh';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Chi nhánh - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}