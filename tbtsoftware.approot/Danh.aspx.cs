namespace bnb.approot.AppAdmin
{
    using System;
    using System.Web.UI;

    public partial class DanhPage : Page
    {
        //private static string ID;
        //Common objComm = new Common();
        //private PermissionCheck objCheckPermision = new PermissionCheck();
        //public CustomControl objControl = new CustomControl();
        //private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strThanhVien_Sua")) == true)
            //{
            //    ID = Common.RequestID("ID");
            //    if (!IsPostBack)
            //    {
            //        if (!IsPostBack)
            //        {
            //            Title = "Lập cảnh báo khách hàng - Bếp Nhà Bạn";
            //        }
            //        KhachHang t0 = KhachHangDAO.KhachHangTheoMa(ID, true);
            //        ltr_ID.Text = t0.ID;
            //        ltr_Name.Text = t0.Name;
            //        ltr_Tel.Text = t0.Tel;
            //        ltr_Gas.Text = t0.LoaiGasSD.ToString();
            //        ltr_Address.Text = t0.Address;
            //    }
            //}
            //else
            //{
            //    this.iRightAccess.Visible = false;
            //    this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            //}
        }

        protected void btn_LapCanhBaoKH_Click(object sender, EventArgs e)
        {
            //if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strThanhVien_Sua")) == true)
            //{
            //    CanhBaoKhachHang t0 = new CanhBaoKhachHang() { ID = ID, LyDoCanhBao = txt_LyDo.Text, MucDoNghiemTrong = "D", NgayCanhBao = DateTime.Now, TrangThaiXuLy = false };
            //    KhachHangDAO.ThemCanhBaoKhachHang(t0);
            //    Response.Redirect("danh-sach-khach-hang");
            //}
            //else
            //{
            //    this.iRightAccess.Visible = false;
            //    this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            //}
        }

        #endregion
    }
}