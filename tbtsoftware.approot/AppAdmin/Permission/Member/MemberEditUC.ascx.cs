namespace MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class MemberEditUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private int intGroupID;

        private int isActive;

        private string strAddress = string.Empty;

        private string strCompany = string.Empty;

        private string strCreateDate = string.Empty;

        private string strEmail = string.Empty;

        private string strFax = string.Empty;

        private string strFullName = string.Empty;

        private string strID = string.Empty;

        private string strMobile = string.Empty;

        private string strPass = string.Empty;

        private string strPhone = string.Empty;

        private string strPosi = string.Empty;

        private string strSex = string.Empty;

        private string strUser = string.Empty;

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Sua")))
            {
                if (!this.Page.IsPostBack)
                {
                    this.LoadInfoEdit();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void SaveData(string type)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Sua")))
            {
                if (this.VerifyThongTin())
                {
                    this.strID = Common.RequestID("id");
                    this.GetInPutData();
                    var obj = MemberGroupDAO.LayThanhVienTheoUsername(this.strID);
                    obj.UserName = this.strUser;
                    //obj.Password = strPass;
                    obj.FullName = this.strFullName;
                    obj.Active = Convert.ToBoolean(this.isActive);
                    obj.Address = this.strAddress;
                    obj.Company = this.strCompany;
                    obj.Phone = this.strPhone;
                    obj.Fax = this.strFax;
                    obj.Mobile = this.strMobile;
                    obj.Position = this.strPosi;
                    obj.Email = this.strEmail;
                    obj.Sex = this.strSex;
                    obj.ModifiedDate = Convert.ToDateTime(this.strCreateDate);
                    obj.Group_ID = int.Parse(this.lb_Nhom.SelectedValue);

                    MemberGroupDAO.Update();
                    switch (type)
                    {
                        case "Publish":
                            this.Response.Redirect("them-thanh-vien");
                            break;
                        case "Save":
                            this.Response.Redirect("quan-ly-thanh-vien");
                            break;
                    }
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
            this.SaveData("Publish");
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            this.SaveData("Save");
        }

        private void GetInPutData()
        {
            //UserName
            this.strUser = this.objComm.SafeString(this.txtUserName.Text.ToLower());

            //Password
            //this.strPass = this.objComm.SafeString(this.txtPassword.Text.ToString().ToLower());
            this.strPass = this.objComm.EncodePassword(this.strPass, "");

            //FullName
            this.strFullName = this.objComm.SafeString(this.txtFullName.Text);

            //Sex
            if (this.DDLSex.SelectedValue == "0")
            {
                this.strSex = "Nam";
            }
            else
            {
                this.strSex = "Nữ";
            }

            //Position
            this.strPosi = this.objComm.SafeString(this.txtPosi.Text);

            //Email
            this.strEmail = this.objComm.SafeString(this.txtEmail.Text);

            //Tel
            this.strPhone = this.objComm.SafeString(this.txtTel.Text);

            //Mobile
            this.strMobile = this.objComm.SafeString(this.txtMobi.Text);

            //Fax
            this.strFax = this.objComm.SafeString(this.txtFax.Text);

            //Address
            this.strAddress = this.objComm.SafeString(this.txtAddress.Text);

            //Company
            this.strCompany = this.objComm.SafeString(this.txtCompany.Text);

            //CreateDate
            this.strCreateDate = DateTime.Now.ToString();

            //GroupID
            this.intGroupID = Int32.Parse(this.lb_Nhom.SelectedValue);

            //IsActive
            if (this.chkIsActive.Checked)
            {
                this.isActive = 1;
            }
            else
            {
                this.isActive = 0;
            }
        }

        private void ListGroupMember()
        {
            this.lb_Nhom.DataSource = MemberGroupDAO.getAllGroupName();
            this.lb_Nhom.DataTextField = "GroupName";
            this.lb_Nhom.DataValueField = "Group_ID";
            this.lb_Nhom.DataBind();
        }

        private void LoadInfoEdit()
        {
            this.ListGroupMember();
            this.strID = Common.RequestID("username");
            var obj = MemberGroupDAO.LayThanhVienTheoUsername(this.strID);

            if (obj != null)
            {
                this.txtUserName.Text = obj.UserName;
                this.txtFullName.Text = obj.FullName;
                //txtPassword.Text = obj.Password;
                //txtRePassword.Text = obj.Password;
                this.txtAddress.Text = obj.Address;
                this.txtCompany.Text = obj.Company;
                this.txtEmail.Text = obj.Email;
                this.txtFax.Text = obj.Fax;
                this.txtTel.Text = obj.Phone;
                this.txtMobi.Text = obj.Mobile;
                this.txtPosi.Text = obj.Position;
                this.chkIsActive.Checked = (bool)obj.Active;
                this.lb_Nhom.SelectedValue = obj.Group_ID.ToString();
                this.DDLSex.SelectedValue = obj.Sex;
            }
        }

        private Boolean VerifyThongTin()
        {
            if (this.txtUserName.Text.Replace(" ", "") == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn phải nhập tên đăng nhập");
                return false;
            }
            if (this.lb_Nhom.SelectedValue == null || this.lb_Nhom.SelectedValue == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn phải chọn nhóm thành viên");
                return false;
            }
            //if (txtPassword.Text.Replace(" ", "") == "" || txtRePassword.Text.Replace(" ", "") == "" || txtRePassword.Text.Replace(" ", "") != txtPassword.Text.Replace(" ", ""))
            //{
            //    div_MatKhau.Visible = true;
            //    return false;
            //}
            //else
            //    div_MatKhau.Visible = false;

            return true;
        }

        #endregion
    }
}