namespace MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class TinhNangUC : UserControl
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNang_Xem")))
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

        protected void bntAddNew_Click()
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNang_Them")))
            {
                this.Response.Redirect("them-thanh-vien");
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNang_Sua")))
            {
                try
                {
                    string function_Group_ID;
                    int id = 1;
                    foreach (ListViewItem lvit in this.lv_ThongTinSP.Items)
                    {
                        if (((HiddenField)lvit.FindControl("hfFunction_Group_ID")).Value != "")
                        {
                            function_Group_ID = ((HiddenField)lvit.FindControl("hfFunction_Group_ID")).Value;
                        }
                        else
                        {
                            this.ltr_Notice.Text = this.objComm.ShowNotice(
                                false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng nhóm chức năng");
                            return;
                        }

                        TBT_AdminFunctionName ctit = MemberGroupDAO.LayTinhNangById(Int32.Parse(function_Group_ID));
                        ctit.FunctionName = ((TextBox)lvit.FindControl("txt_FunctionGroupName")).Text;
                        ctit.FunctionOrder = id++;
                        ctit.FunctionNameDesc = ((TextBox)lvit.FindControl("txt_FunctionGroupDesc")).Text;
                        MemberGroupDAO.Update();
                    }
                    this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                    this.BinList();
                }
                catch
                {
                    if (!this.Page.ClientScript.IsStartupScriptRegistered("popup"))
                    {
                        this.Page.ClientScript.RegisterStartupScript(
                            this.GetType(),
                            "popup",
                            "popup('Cập nhật thất bại! Bạn hãy tải lại trang để thử lại cập nhật.');",
                            true);
                    }
                }
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='tin-tuc';</script>");
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNang_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfFunction_Group_ID")) as HiddenField;
                if (hdf != null)
                {
                    if (MemberGroupDAO.XoaTinhNang(Int32.Parse(hdf.Value)) != "")
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Xóa tính năng thất bại");
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

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNang_Them")))
            {
                var it = new TBT_AdminFunctionName();

                var txt = (e.Item.FindControl("txt_FunctionGroupName")) as TextBox;

                if (txt != null)
                {
                    it.FunctionName = txt.Text;
                }

                it.FunctionOrder = MemberGroupDAO.LayOrderSortTinhNang() + 1;

                txt = (e.Item.FindControl("txt_FunctionGroupDesc")) as TextBox;

                if (txt != null)
                {
                    it.FunctionNameDesc = txt.Text;
                }

                MemberGroupDAO.ThemTinhNang(it);

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
            this.lv_ThongTinSP.DataSource = MemberGroupDAO.DanhSachTinhNang();
            this.lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}