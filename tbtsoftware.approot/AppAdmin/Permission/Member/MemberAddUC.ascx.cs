using System;
using System.Globalization;
using System.Web.UI;
using BepNhaBan.System;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member
{
    public partial class MemberAddUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        public DBHelper objDB = new DBHelper();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private int intGroupID;

        private int isActive;

        private string strAddress = string.Empty;

        private string strCompany = string.Empty;

        private string strCreateDate = string.Empty;

        private string strEmail = string.Empty;

        private string strFax = string.Empty;

        private string strFullName = string.Empty;

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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Them")))
            {
                if (!this.Page.IsPostBack)
                {
                    this.ListGroupMember();
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strThanhVien_Them")))
            {
                if (this.VerifyThongTin())
                {
                    this.GetInPutData();
                    var obj = new User
                                  {
                                      UserName = this.strUser,
                                      Password = this.strPass,
                                      FullName = this.strFullName,
                                      Active = Convert.ToBoolean(this.isActive),
                                      Address = this.strAddress,
                                      Company = this.strCompany,
                                      Phone = this.strPhone,
                                      Fax = this.strFax,
                                      Mobile = this.strMobile,
                                      Position = this.strPosi,
                                      Email = this.strEmail,
                                      Sex = this.strSex,
                                      CreateDate = Convert.ToDateTime(this.strCreateDate),
                                      Group_ID = int.Parse(this.lb_Nhom.SelectedValue)
                                  };

                    MemberGroupDAO.InsertMember(obj);
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
            this.strPass = this.objComm.SafeString(this.txtPassword.Text.ToLower());
            this.strPass = this.objComm.EncodePassword(this.strPass, "");

            //FullName
            this.strFullName = this.objComm.SafeString(this.txtFullName.Text);

            //Sex
            this.strSex = this.DDLSex.SelectedValue == "1" ? "Nam" : "Nữ";

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
            this.strCreateDate = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            //GroupID
            this.intGroupID = Int32.Parse(this.lb_Nhom.SelectedValue);

            //IsActive
            this.isActive = this.chkIsActive.Checked ? 1 : 0;
        }

        private void ListGroupMember()
        {
            this.lb_Nhom.DataSource = MemberGroupDAO.getAllGroupName();
            this.lb_Nhom.DataTextField = "GroupName";
            this.lb_Nhom.DataValueField = "Group_ID";
            this.lb_Nhom.DataBind();
        }

        private Boolean VerifyThongTin()
        {
            if (this.txtUserName.Text.Replace(" ", "") == "")
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn phải nhập tên đăng nhập");
                return false;
            }
            if (string.IsNullOrEmpty(this.lb_Nhom.SelectedValue))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Bạn phải chọn nhóm thành viên");
                return false;
            }
            if (this.txtPassword.Text.Replace(" ", "") == "" || this.txtRePassword.Text.Replace(" ", "") == ""
                || this.txtRePassword.Text.Replace(" ", "") != this.txtPassword.Text.Replace(" ", ""))
            {
                this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Mật khẩu chưa đúng");
                return false;
            }

            return true;
        }

        #endregion
    }
}