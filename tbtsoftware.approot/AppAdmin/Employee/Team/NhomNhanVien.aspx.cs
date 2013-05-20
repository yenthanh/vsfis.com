using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Employee.Team
{
    public partial class NhomNhanVien : Page
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
                    "<script language='javascript'>location.href='quan-tri?ReturnUrl=nhom-nhan-vien';</script>");
            }
        }

        #endregion
    }
}