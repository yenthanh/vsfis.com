using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;
using BepNhaBan.System;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Menu
{
    #region Using

    

    #endregion

    public partial class AddUC : UserControl
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strDanhMuc_Them")))
            {
                if (!this.Page.IsPostBack)
                {
                    this.BindList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnPublish_Click(object sender, EventArgs e)
        {
            this.Save("Publish");
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            this.Save("Save");
        }

        private void BindList()
        {
            this.listView.DataSource = MenuDAO.GetHierarchyMenu(0, 0);
            this.listView.DataTextField = "Name";
            this.listView.DataValueField = "Id";
            this.listView.DataBind();
        }

        private void Save(string type)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strDanhMuc_Them")))
            {
                bool flag = true;
                if (this.txtName.Text.Replace(" ", "") == "")
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn phải nhập thông tin Tên nhóm danh mục");
                    flag = false;
                }
                if (string.IsNullOrEmpty(this.listView.SelectedValue))
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(false, "	Bạn phải chọn thông tin Nhóm danh mục cha");
                    flag = false;
                }
                if (flag == false)
                {
                    return;
                }
                int t_int;
                var item = new DAO.Menu
                               {
                                   Link = this.txtLink.Text,
                                   Name = this.txtName.Text,
                                   ParentId = int.Parse(this.listView.SelectedValue),
                                   Descript = this.txtDescript.Text,
                                   ImgSrc = this.txtImgSrc.Text,
                               };
                if (Int32.TryParse(this.txtOrderSort.Text, out t_int))
                {
                    item.OrderSort = t_int;
                }
                else
                {
                    item.OrderSort = 999;
                }
                item.IsDisplay = this.ckbDisplay.Checked;
                item.IsDelete = false;
                MenuDAO.Save(item);
                if (type == "Publish")
                {
                    this.Response.Redirect("them-menu");
                }
                else if (type == "Save")
                {
                    this.Response.Redirect("/AppAdmin/Config/Menu/Index.aspx");
                }
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