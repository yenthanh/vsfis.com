namespace MinhPham.Web.BepNhaBan.AppAdmin.ThuongHieu
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using bnb.approot.DAO;

    using global::BepNhaBan.System;

    public partial class ThuongHieuUC : UserControl
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThuongHieu_Xem")))
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

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThuongHieu_Sua")))
            {
                try
                {
                    foreach (ListViewDataItem lvit in this.lv_ThongTinSP.Items)
                    {
                        string BranchID;
                        if (((HiddenField)lvit.FindControl("hfID")).Value != "")
                        {
                            BranchID = ((HiddenField)lvit.FindControl("hfID")).Value;
                        }
                        else
                        {
                            this.ltr_Notice.Text = this.objComm.ShowNotice(
                                false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng chi nhánh");
                            return;
                        }
                        Brand t0 = BrandDAO.Get(Int32.Parse(BranchID));
                        t0.Name = ((TextBox)lvit.FindControl("txtName")).Text;
                        t0.Note = ((TextBox)lvit.FindControl("txtNote")).Text;
                        ProductDAO.Update();
                    }
                    this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(
                        false, "Cập nhật thông tin thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-san-pham';</script>");
            }
        }

        //protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        //{
        //    if (this.IsPostBack)
        //    {
        //        BinList();
        //    }

        //}

        protected void lv_ThongTinSP_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            this.lv_ThongTinSP.EditIndex = -1;
            this.BinList();
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThuongHieu_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;

                if (hdf != null)
                {
                    BrandDAO.Delete(Int32.Parse(hdf.Value));
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

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThuongHieu_Them")))
            {
                var t0 = new Brand();
                var txt = (e.Item.FindControl("txtName")) as TextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                txt = (e.Item.FindControl("txtNote")) as TextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                BrandDAO.Insert(t0);
                this.lv_ThongTinSP.EditIndex = -1;
                this.BinList();
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        private void BinList()
        {
            this.lv_ThongTinSP.DataSource = BrandDAO.Get();
            this.lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}