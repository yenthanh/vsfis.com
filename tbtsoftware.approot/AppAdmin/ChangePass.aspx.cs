namespace MinhPham.Web.BepNhaBan.AppAdmin
{
    #region Using

    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    #endregion

    public partial class ChangePass : Page
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static string username;

        #endregion

        #region Fields

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Sua")))
            {
                username = Common.RequestID("username");
                if (this.IsPostBack)
                {
                    this.Title = "Thay đổi mật khẩu người dùng - Bếp Nhà Bạn";
                    if (this.txt_MatKhau.Text != this.txt_NhapLai.Text)
                    {
                        this.lbl_Notice.Text = "Mật khẩu không khớp!";
                    }
                    return;
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void btn_ChangePass_Click(object sender, EventArgs e)
        {
            var t0 = MemberGroupDAO.LayThanhVienTheoUsername(username);
            t0.Password = this.objComm.EncodePassword(this.txt_MatKhau.Text, "");
            MemberGroupDAO.Update();
            this.Response.Redirect("quan-ly-thanh-vien");
        }

        #endregion
    }
}