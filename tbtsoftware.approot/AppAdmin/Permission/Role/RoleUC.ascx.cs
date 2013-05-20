namespace MinhPham.Web.BepNhaBan.AppAdmin.Permission.Role
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web.ASPxEditors;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class RoleUC : UserControl
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomChucNang_Xem")))
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomChucNang_Them")))
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomChucNang_Sua")))
            {
                try
                {
                    int tint, ordersort;
                    string function_Group_ID;
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
                        string ods = ((ASPxTextBox)lvit.FindControl("txt_OrderSort")).Text;
                        if (Int32.TryParse(ods, out tint))
                        {
                            ordersort = tint;
                        }
                        else
                        {
                            this.ltr_Notice.Text = this.objComm.ShowNotice(
                                false,
                                "Cập nhật thông tin thất bại.\nThứ tự nhập vào không phải kiểu số.\nHãy kiểm tra và thử lại!");
                            return;
                        }

                        TBT_AdminFunctionGroup ctit = MemberGroupDAO.LayNhomChucNangById(Int32.Parse(function_Group_ID));
                        ctit.FunctionGroupName = ((TextBox)lvit.FindControl("txt_FunctionGroupName")).Text;
                        ctit.FunctionGroupOrder = ordersort;
                        ctit.FunctionGroupDesc = ((TextBox)lvit.FindControl("txt_FunctionGroupDesc")).Text;
                        MemberGroupDAO.Update();
                    }
                    this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
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
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='/AppAdmin/Article/Index.aspx';</script>");
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomChucNang_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfFunction_Group_ID")) as HiddenField;

                if (hdf != null)
                {
                    if (MemberGroupDAO.XoaNhomChucNang(Int32.Parse(hdf.Value)) != "")
                    {
                        if (!this.Page.ClientScript.IsStartupScriptRegistered("popup"))
                        {
                            this.Page.ClientScript.RegisterStartupScript(
                                this.GetType(),
                                "popup",
                                "popup('Bạn cần xóa bỏ các chức năng thuộc nhóm này trước khi xóa nhóm!.');",
                                true);
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

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomChucNang_Them")))
            {
                var it = new TBT_AdminFunctionGroup();
                var txt = (e.Item.FindControl("txt_FunctionGroupName")) as TextBox;
                if (txt != null)
                {
                    it.FunctionGroupName = txt.Text;
                }
                var txt1 = (e.Item.FindControl("txt_FunctionGroupOrder")) as ASPxTextBox;
                if (txt1 != null)
                {
                    it.FunctionGroupOrder = Int32.Parse(txt1.Text);
                }
                txt = (e.Item.FindControl("txt_FunctionGroupDesc")) as TextBox;
                if (txt != null)
                {
                    it.FunctionGroupDesc = txt.Text;
                }
                MemberGroupDAO.ThemNhomChucNang(it);
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
            this.lv_ThongTinSP.DataSource = MemberGroupDAO.DanhSachNhomChucNang();
            this.lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}