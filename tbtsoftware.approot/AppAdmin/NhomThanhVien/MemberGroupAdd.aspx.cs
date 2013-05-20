using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien
{
    public partial class MemberGroupAdd : Page
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=them-nhom-thanh-vien';</script>");
            }
            if (!IsPostBack)
            {
                Title = "Thêm nhóm thành viên" + Resources.language.title_separator + Resources.language.website_name;
            }
        }

        #endregion
    }
}