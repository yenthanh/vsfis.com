namespace MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class MemberGroupListUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Xem")))
            {
                if (!this.IsPostBack)
                {
                    this.ListGroupName();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idPermissionAccess, NotPermissControl);
            }
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfGroup_ID")) as HiddenField;
                if (hdf != null)
                {
                    if (MemberGroupDAO.XoaNhomThanhVien(Int32.Parse(hdf.Value)) != "")
                    {
                        if (!this.Page.ClientScript.IsStartupScriptRegistered("popup"))
                        {
                            this.Page.ClientScript.RegisterStartupScript(
                                this.GetType(), "popup", "popup('Tác vụ xóa thành viên gặp thất bại!.');", true);
                        }
                    }
                    this.lv_ThongTinSP.EditIndex = -1;
                    this.ListGroupName();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idPermissionAccess, NotPermissControl);
            }
        }

        private void ListGroupName()
        {
            this.lv_ThongTinSP.DataSource = MemberGroupDAO.getAllGroupName();
            this.lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}