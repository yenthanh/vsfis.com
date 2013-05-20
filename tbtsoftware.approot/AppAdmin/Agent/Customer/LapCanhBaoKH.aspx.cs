namespace MinhPham.Web.BepNhaBan.AppAdmin.Agent.Customer
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using bnb.approot.DAO;

    using global::BepNhaBan.System;

    public partial class LapCanhBaoKH : Page
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static int id;

        #endregion

        #region Fields

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Sua")))
            {
                id = int.Parse(Common.RequestID("ID"));
                if (!this.IsPostBack)
                {
                    if (!this.IsPostBack)
                    {
                        this.Title = "Lập cảnh báo khách hàng - Bếp Nhà Bạn";
                    }
                    Partner t0 = NewsFactory.Find(id, true);
                    this.ltr_ID.Text = t0.ID.ToString();
                    this.ltr_Name.Text = t0.Name;
                    this.ltr_Tel.Text = t0.Tel;
                    this.ltr_Gas.Text = t0.GasUsed;
                    this.ltr_Address.Text = t0.Address;
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void btn_LapCanhBaoKH_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Sua")))
            {
                var t0 = new CanhBaoKhachHang
                             {
                                 MaKH = int.Parse(this.ID),
                                 LyDoCanhBao = this.txt_LyDo.Text,
                                 MucDoNghiemTrong = "D",
                                 NgayCanhBao = DateTime.Now,
                                 TrangThaiXuLy = false
                             };
                NewsFactory.ThemCanhBaoKhachHang(t0);
                this.Response.Redirect("danh-sach-khach-hang");
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        #endregion
    }
}