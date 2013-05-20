namespace MinhPham.Web.BepNhaBan.AppAdmin.Employee
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    using DevExpress.Web.ASPxEditors;
    using DevExpress.Web.ASPxGridView;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using bnb.approot.DAO;

    using global::BepNhaBan.System;

    public partial class NhanVien_ViewUC : UserControl
    {
        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private string Alias;

        private string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        private DropDownList chiNhanhID;

        private string hoTen;

        private HtmlImage img_AnhNhanVien1;

        private string ngaySinh;

        private DropDownList nhomNV;

        #endregion

        #region Methods

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            //if (this.IsPostBack)
            //    BinList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Xem")))
            {
                if (!this.IsPostBack)
                {
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, this.NotPermissControl);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var FileUploadControl = (FileUpload)this.lv_ThongTinSP.InsertItem.FindControl("FileUploadControl");

            this.img_AnhNhanVien1 = (HtmlImage)this.lv_ThongTinSP.InsertItem.FindControl("img_anh");
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg"
                        || FileUploadControl.PostedFile.ContentType == "image/png"
                        || FileUploadControl.PostedFile.ContentType == "image/gif")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            string url = "\\StyleLibrary\\AnhNhanVien\\" + filename;
                            string fulldirect = this.Server.MapPath("~/") + url;
                            FileUploadControl.SaveAs(fulldirect);
                            this.img_AnhNhanVien1.Src = url;
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

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Sua")))
            {
                foreach (ListViewDataItem lvit in this.lv_ThongTinSP.Items)
                {
                    string nhanVienID;
                    if (((HiddenField)lvit.FindControl("hfID")).Value != "")
                    {
                        nhanVienID = ((HiddenField)lvit.FindControl("hfID")).Value;
                    }
                    else
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(
                            false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng mã nhân viên");
                        return;
                    }
                    var t0 = EmployeeDAO.Get(Int32.Parse(nhanVienID));
                    t0.Alias = ((ASPxTextBox)lvit.FindControl("txt_Alias")).Text;
                    t0.Name = ((TextBox)lvit.FindControl("txt_TenNV")).Text;
                    t0.DOB = DateTime.ParseExact(
                        ((TextBox)lvit.FindControl("txt_NgaySinh")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    EmployeeDAO.Update();
                }
                this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thành công!");
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='nhan-vien';</script>");
            }
        }

        protected void lv_ThongTinSP_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Unbound")
            {
                e.Cell.Text = (e.VisibleIndex + 1).ToString();
            }
        }

        protected void lv_ThongTinSP_ItemDeleted(object sender, ListViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
            }
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;
                if (hdf != null)
                {
                    EmployeeDAO.Delete(Int32.Parse(hdf.Value));
                    this.lv_ThongTinSP.EditIndex = -1;
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, this.NotPermissControl);
            }
        }

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhanVien_Them")))
            {
                if (this.ValidateData())
                {
                    var t0 = new Employee
                                 {
                                     Alias = this.Alias,
                                     Name = this.hoTen,
                                     TeamID = Int32.Parse(this.nhomNV.SelectedValue),
                                     BranchID = Int32.Parse(this.chiNhanhID.SelectedValue),
                                     DOB =
                                         DateTime.ParseExact(
                                             this.ngaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                     Gender = true,
                                     Created = DateTime.Now,
                                     LuongCoBan = 0,
                                     TheoDoi = true
                                 };
                    if (this.img_AnhNhanVien1 != null)
                    {
                        t0.Picture = this.img_AnhNhanVien1.Src;
                    }

                    EmployeeDAO.Insert(t0);
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, this.NotPermissControl);
            }
        }

        private void BinList()
        {
            this.lv_ThongTinSP.DataSource = EmployeeDAO.DanhSachNhanVienFull();
            this.lv_ThongTinSP.DataBind();
            this.Load_ChiNhanh();
            this.Load_Nhom();
        }

        private void Load_ChiNhanh()
        {
            var ddl_ChiNhanhID = (DropDownList)this.lv_ThongTinSP.InsertItem.FindControl("ddl_ChiNhanhID");
            ddl_ChiNhanhID.DataSource = ChiNhanhDAO.Get();
            ddl_ChiNhanhID.DataValueField = "ID";
            ddl_ChiNhanhID.DataTextField = "Name";
            ddl_ChiNhanhID.DataBind();
        }

        private void Load_Nhom()
        {
            var ddl_Nhom = (DropDownList)this.lv_ThongTinSP.InsertItem.FindControl("ddl_Nhom");
            ddl_Nhom.DataSource = TeamDAO.Get();
            ddl_Nhom.DataValueField = "ID";
            ddl_Nhom.DataTextField = "Name";
            ddl_Nhom.DataBind();
        }

        private bool ValidateData()
        {
            this.Alias = ((TextBox)this.lv_ThongTinSP.InsertItem.FindControl("txt_Alias")).Text;
            this.hoTen = ((TextBox)this.lv_ThongTinSP.InsertItem.FindControl("txt_TenNV")).Text;
            this.ngaySinh = ((TextBox)this.lv_ThongTinSP.InsertItem.FindControl("txt_NgaySinh")).Text;
            this.nhomNV = (DropDownList)this.lv_ThongTinSP.InsertItem.FindControl("ddl_Nhom");
            this.chiNhanhID = (DropDownList)this.lv_ThongTinSP.InsertItem.FindControl("ddl_ChiNhanhID");
            if (this.Alias == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập mã nhân viên");
                return false;
            }
            if (this.hoTen == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập tên nhân viên");
                return false;
            }
            if (this.ngaySinh == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa nhập ngày sinh");
                return false;
            }
            if (string.IsNullOrEmpty(this.nhomNV.SelectedValue))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa chọn nhóm nhân viên");
                return false;
            }
            if (string.IsNullOrEmpty(this.chiNhanhID.SelectedValue))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn chưa chọn chi nhánh");
                return false;
            }
            return true;
        }

        #endregion
    }
}