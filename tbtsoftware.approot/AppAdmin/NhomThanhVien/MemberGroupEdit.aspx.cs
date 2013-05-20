using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien
{
    public partial class MemberGroupEdit : Page
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=quan-ly-nhom-thanh-vien';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Sửa nhóm thành viên - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}