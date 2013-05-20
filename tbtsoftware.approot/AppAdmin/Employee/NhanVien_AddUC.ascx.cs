namespace bnb.approot.AppAdmin.Employee
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web.UI;

    using BepNhaBan.System;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using bnb.approot.DAO;

    public partial class NhanVien_AddUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private string nhanVienID;

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nhanVienID = Common.RequestID("NhanVienID");
            if (this.nhanVienID == ""
                && this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Them")))
            {
                if (!this.IsPostBack)
                {
                    this.lbl_Title.Text = "Thêm mới nhân viên";
                    this.Load_NhomNhanVien();
                    this.Load_ChiNhanh();
                }
            }
            else if (this.nhanVienID != ""
                     && this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Sua")))
            {
                if (!this.IsPostBack)
                {
                    this.lbl_Title.Text = "Chỉnh sửa thông tin nhân viên";
                    this.Load_NhomNhanVien();
                    this.Load_ChiNhanh();
                    this.Load_ThongTinNhanVien();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (this.FileUploadControl.HasFile)
            {
                try
                {
                    if (this.FileUploadControl.PostedFile.ContentType == "image/jpeg"
                        || this.FileUploadControl.PostedFile.ContentType == "image/png"
                        || this.FileUploadControl.PostedFile.ContentType == "image/gif")
                    {
                        if (this.FileUploadControl.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(this.FileUploadControl.FileName);
                            string url = "\\StyleLibrary\\AnhNhanVien\\" + filename;
                            string fulldirect = this.Server.MapPath("~/") + url;
                            this.FileUploadControl.SaveAs(fulldirect);
                            this.img_AnhNhanVien.Src = url;
                        }
                        else
                        {
                            this.ltr_Notice.Text = this.objComm.ShowNotice(
                                false, "Trạng thái tải lên: Dung lượng tệp tin hình ảnh phải nhỏ hơn 1Mb!");
                        }
                    }
                    else
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(
                            false, "Trạng thái tải lên: Tệp tin bạn chọn không phải là tệp tin ảnh!");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("is constrained to be unique"))
                    {
                        //StatusLabel.Text = "Trạng thái tải lên: Hình ảnh chưa thể tải lên. Tên hình ảnh này đã có trên hệ thống, bạn cần đổi tên ảnh nếu chắc chắn bạn đang tải lên một ảnh khác!!";
                    }
                    else
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(
                            false,
                            "Trạng thái tải lên: Hình ảnh chưa thể tải lên. Lỗi sau xuất hiện trong quá trình tải: "
                            + ex.Message);
                    }
                }
            }
        }

        protected void lbtnPublish_Click(object sender, EventArgs e)
        {
            this.SaveProduct("Publish");
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            this.SaveProduct("Save");
        }

        private void Load_ChiNhanh()
        {
            this.lb_ChiNhanh.DataSource = ChiNhanhDAO.Get();
            this.lb_ChiNhanh.DataValueField = "ID";
            this.lb_ChiNhanh.DataTextField = "Name";
            this.lb_ChiNhanh.DataBind();
        }

        private void Load_NhomNhanVien()
        {
            this.lb_NhomNV.DataSource = TeamDAO.Get();
            this.lb_NhomNV.DataTextField = "Name";
            this.lb_NhomNV.DataValueField = "ID";
            this.lb_NhomNV.DataBind();
        }

        private void Load_ThongTinNhanVien()
        {
            Employee t0 = EmployeeDAO.Get(Int32.Parse(this.nhanVienID));
            this.txt_Alias.Text = t0.Alias;
            this.txt_HoTen.Text = t0.Name;
            this.lb_NhomNV.SelectedValue = t0.TeamID.ToString(CultureInfo.InvariantCulture);
            this.lb_ChiNhanh.SelectedValue = t0.BranchID.ToString();
            if (t0.DOB != null)
            {
                this.txt_NgaySinh.Text = ((DateTime)t0.DOB).ToShortDateString();
            }
            this.ddl_GioiTinh.SelectedValue = t0.Gender.ToString();
            this.img_AnhNhanVien.Src = t0.Picture;
        }

        private void SaveProduct(string type)
        {
            if ((this.nhanVienID == ""
                 && this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Them")))
                || (this.nhanVienID != ""
                    && this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Sua"))))
            {
                if (this.ValidateData())
                {
                    var t0 = this.nhanVienID == ""
                                 ? new Employee()
                                 : EmployeeDAO.Get(Int32.Parse(this.nhanVienID));
                    t0.Alias = this.txt_Alias.Text;
                    t0.Name = this.txt_HoTen.Text;
                    t0.TeamID = Int32.Parse(this.lb_NhomNV.SelectedValue);
                    t0.BranchID = Int32.Parse(this.lb_ChiNhanh.SelectedValue);
                    t0.DOB = DateTime.ParseExact(this.txt_NgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    t0.Gender = Boolean.Parse(this.ddl_GioiTinh.SelectedValue);
                    t0.Created = DateTime.Now;
                    t0.LuongCoBan = 0;
                    t0.TheoDoi = true;
                    t0.Picture = this.img_AnhNhanVien.Src;
                    if (this.nhanVienID == "")
                    {
                        EmployeeDAO.Insert(t0);
                    }
                    else
                    {
                        EmployeeDAO.Update();
                    }

                    if (type == "Publish")
                    {
                        this.Response.Redirect("them-nhan-vien");
                    }
                    else if (type == "Save")
                    {
                        this.Response.Redirect("nhan-vien");
                    }
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        private bool ValidateData()
        {
            if (this.txt_Alias.Text == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập mã nhân viên");
                return false;
            }
            if (this.txt_HoTen.Text == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập tên nhân viên");
                return false;
            }
            if (this.txt_NgaySinh.Text == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập ngày sinh");
                return false;
            }
            if (string.IsNullOrEmpty(this.lb_NhomNV.SelectedValue))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa chọn nhóm nhân viên");
                return false;
            }
            if (string.IsNullOrEmpty(this.lb_ChiNhanh.SelectedValue))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa chọn chi nhánh");
                return false;
            }
            return true;
        }

        #endregion
    }
}