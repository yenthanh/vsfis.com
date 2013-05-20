using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BepNhaBan.System;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Menu
{
    public partial class EditUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        #region Public Methods and Operators

        public void LoadCurrentCate()
        {
            if (Common.RequestID("ID") == "")
            {
                this.Context.Response.Redirect("/AppAdmin/Config/Menu/Index.aspx");
            }
            List<DAO.Menu> item = MenuDAO.Get(int.Parse(Common.RequestID("ID")));
            if (item.Count > 0)
            {
                this.txtName.Text = item[0].Name;
                this.listView.SelectedValue = item[0].ParentId.ToString();
                this.txtDescript.Text = item[0].Descript;
                this.txtOrderSort.Text = item[0].OrderSort.ToString();
                this.ckbDisplay.Checked = item[0].IsDisplay.ToString().ToLower() == "true";
                this.txtImgSrc.Text = item[0].ImgSrc;
                this.txtLink.Text = item[0].Link;
            }
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strDanhMuc_Sua")))
            {
                if (!this.Page.IsPostBack)
                {
                    this.BindList();
                    this.LoadCurrentCate();
                }
            }
            else
            {
                this.tabs.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void BindList()
        {
            this.listView.DataSource = MenuDAO.GetHierarchyMenu(0, 0);
            this.listView.DataTextField = "Name";
            this.listView.DataValueField = "Id";
            this.listView.DataBind();
        }

        private void Save()
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strDanhMuc_Sua")))
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
                DAO.Menu cateit = MenuDAO.Get(int.Parse(Common.RequestID("ID"))).First();
                cateit.Name = this.txtName.Text;
                cateit.ImgSrc = this.txtImgSrc.Text;
                cateit.ParentId = int.Parse(this.listView.SelectedValue);
                cateit.Descript = this.txtDescript.Text;
                cateit.OrderSort = Int32.TryParse(this.txtOrderSort.Text, out t_int) ? t_int : 999;
                cateit.IsDisplay = this.ckbDisplay.Checked;
                cateit.Link = this.txtLink.Text;
                cateit.IsDelete = false;
                MenuDAO.Update();
                this.Response.Redirect("/AppAdmin/Config/Menu/Index.aspx");
            }
            else
            {
                this.tabs.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        #endregion
    }
}