namespace MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class MemberGroupAddUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static int GroupID;

        private static int max = 10, tinhNangCount;

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        public DBHelper objDB = new DBHelper();

        private readonly int[] Function_Group_Id = new int[max];

        private readonly int[] Function_Id = new int[max];

        private readonly bool[] Permission = new bool[max];

        private readonly string[] bcheck = new string[max];

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        private readonly StringBuilder tbl = new StringBuilder();

        private string strSQLInsert = string.Empty;

        #endregion

        #region Public Methods and Operators

        public void BindData()
        {
            #region Quyền hạn trong từng chức năng

            #region Header

            this.tbl.Append(
                "<div style='padding: 2px; margin: 5px 0px 5px 0px;' class='ui-widget-content ui-corner-top ui-corner-bottom'><div><table cellspacing='0' border='1' style='width: 100%; border-collapse: collapse;' rules='all' class='adminlist'><tbody> <tr> <th scope='col'>Nhóm chức năng</th>");
            foreach (TBT_AdminFunctionName t1 in MemberGroupDAO.DanhSachTinhNang())
            {
                this.tbl.Append(String.Format("<th scope='col'>{0}</th>", t1.FunctionName));
            }
            this.tbl.Append("</tr>");

            #endregion

            #region Content

            foreach (TBT_AdminFunctionGroup t1 in MemberGroupDAO.DanhSachNhomChucNang())
            {
                for (int i = 0; i < tinhNangCount; i++)
                {
                    this.Permission[i] = false;
                    this.bcheck[i] = string.Empty;
                }
                this.tbl.Append("<tr class='row0'>");
                this.tbl.Append("    <td align='left' width='25%'>");
                this.tbl.Append(
                    String.Format(
                        "        <a href='JavaScript:checkAllGroupItem({0},document.aspnetForm.chbFunc{0})' class='member_list'>{1}</a>",
                        t1.Function_Group_ID,
                        t1.FunctionGroupName));
                this.tbl.Append("    </td>");
                int ID = -1;
                foreach (TBT_AdminFunction t2 in MemberGroupDAO.DanhSachTinhNangChucNang1(t1.Function_Group_ID))
                {
                    ID++;
                    this.Permission[ID] = true;
                    this.Function_Group_Id[ID] = t1.Function_Group_ID;
                    this.Function_Id[ID] = t2.Function_ID;
                }

                for (int i = 0; i < tinhNangCount; i++)
                {
                    if (this.Permission[i])
                    {
                        this.tbl.Append("<td align='center'>");
                        this.tbl.Append(
                            String.Format(
                                "<input type='checkbox' name='chbFunc{0}' value='check' id='{1}'>",
                                this.Function_Id[i],
                                this.Function_Group_Id[i]));
                        this.tbl.Append("</td>");
                    }
                    else
                    {
                        this.tbl.Append("<td align='center'>");
                        this.tbl.Append("&nbsp;");
                        this.tbl.Append("</td>");
                    }
                }
                this.tbl.Append("</tr>");
            }
            this.tbl.Append("</tbody></table></div></div>");

            #endregion

            #endregion

            this.htmlMemberGroupEdit.InnerHtml = this.tbl.ToString();
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Them")))
            {
                if (!this.IsPostBack)
                {
                    tinhNangCount = MemberGroupDAO.DanhSachTinhNang().Count();
                    this.BindData();
                }
            }
            else
            {
                this.htmlMemberGroupEdit.Visible = false;
                this.objControl.LoadMyControl(this.idPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Them")))
            {
                #region SaveThongTinNhom

                var it = new Role {
                                 GroupName = this.txt_GroupName.Text,
                                 GroupDesc = this.txt_GroupDesc.Text,
                                 Active = this.ckb_Active.Checked
                             };
                MemberGroupDAO.ThemNhomNguoiDung(it);

                #endregion

                GroupID = it.Group_ID;
                try
                {
                    foreach (string item in HttpContext.Current.Request.Form)
                    {
                        if (item.Substring(0, 6) == "chbFun")
                        {
                            int tempFunction_ID = Int32.Parse(item.Substring(7, item.Length - 7));
                            this.strSQLInsert =
                                String.Format(
                                    "Insert Into TBT_AdminMemberGroupFunction (Function_ID,Group_ID) values('{0}','{1}')",
                                    tempFunction_ID,
                                    GroupID);
                            this.objDB.Insert(tempFunction_ID, GroupID, this.strSQLInsert);
                        }
                        //i++;
                    }
                    this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                    this.Response.Redirect("quan-ly-nhom-thanh-vien");
                }
                catch (Exception ex)
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(
                        false, "Cập nhật thông tin thất bại. Chi tiết: " + ex.Message);
                }
            }
            else
            {
                this.htmlMemberGroupEdit.Visible = false;
                this.objControl.LoadMyControl(this.idPermissionAccess, NotPermissControl);
            }
        }

        #endregion
    }
}