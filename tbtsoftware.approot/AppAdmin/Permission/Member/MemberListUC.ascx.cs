namespace MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class MemberListUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        public DBHelper objDB = new DBHelper();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Xem")))
            {
                if (!this.Page.IsPostBack)
                {
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        //protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        //{
        //    if (this.IsPostBack)
        //    {
        //        BinList();
        //    }

        //}

        protected void bntAddNew_Click()
        {
            this.Response.Redirect("them-thanh-vien");
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfUserName")) as HiddenField;

                if (hdf != null)
                {
                    if (MemberGroupDAO.XoaThanhVien(hdf.Value) != "")
                    {
                        if (!this.Page.ClientScript.IsStartupScriptRegistered("popup"))
                        {
                            this.Page.ClientScript.RegisterStartupScript(
                                this.GetType(), "popup", "popup('Tác vụ xóa thành viên gặp thất bại!.');", true);
                        }
                    }
                    this.lv_ThongTinSP.EditIndex = -1;
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        private void BinList()
        {
            this.lv_ThongTinSP.DataSource = MemberGroupDAO.LayDanhSachThanhVien();
            this.lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}