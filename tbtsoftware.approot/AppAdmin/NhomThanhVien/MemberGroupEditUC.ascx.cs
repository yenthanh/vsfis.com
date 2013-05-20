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

    public partial class MemberGroupEditUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static int GroupID;

        private static int max = 20, tinhNangCount;

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
            #region LoadThongTin

            var it = MemberGroupDAO.getGroupByID(GroupID);
            this.txt_GroupName.Text = it.GroupName;
            this.txt_GroupDesc.Text = it.GroupDesc;
            this.ckb_Active.Checked = it.Active;

            #endregion

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

            foreach (var t1 in MemberGroupDAO.DanhSachNhomChucNang())
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
                foreach (var t2 in MemberGroupDAO.DanhSachTinhNangChucNang1(t1.Function_Group_ID))
                {
                    int id = (int)(t2.TBT_AdminFunctionName.FunctionOrder - 1);
                    this.Permission[id] = true;
                    this.Function_Group_Id[id] = t1.Function_Group_ID;
                    this.Function_Id[id] = t2.Function_ID;
                    if (
                        MemberGroupDAO.DanhSachQuyenHanNhomThanhVien().Any(p => p.Group_ID == GroupID && p.Function_ID == t2.Function_ID))
                    {
                        this.bcheck[id] = " checked ";
                    }
                }

                for (int i = 0; i < tinhNangCount; i++)
                {
                    if (this.Permission[i])
                    {
                        this.tbl.Append("<td align='center'>");
                        this.tbl.Append(
                            String.Format(
                                "<input type='checkbox' name='chbFunc{0}' value='check' id='{1}' {2}>",
                                this.Function_Id[i],
                                this.Function_Group_Id[i],
                                this.bcheck[i]));
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Sua")))
            {
                if (!this.IsPostBack)
                {
                    if (Common.RequestID("id") != "")
                    {
                        tinhNangCount = MemberGroupDAO.DanhSachTinhNang().Count();
                        GroupID = Int32.Parse(Common.RequestID("id"));
                        this.BindData();
                    }
                    else
                    {
                        this.Response.Redirect("quan-ly-nhom-thanh-vien");
                    }
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strNhomThanhVien_Sua")))
            {
                #region SaveThongTinNhom

                var it = MemberGroupDAO.getGroupByID(GroupID);
                it.GroupName = this.txt_GroupName.Text;
                it.GroupDesc = this.txt_GroupDesc.Text;
                it.Active = this.ckb_Active.Checked;
                MemberGroupDAO.Update();

                #endregion

                try
                {
                    MemberGroupDAO.XoaTinhNangByNhomThanhVien(GroupID);

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
                    this.BindData();
                }
                catch (Exception ex)
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thất bại!" + ex.Message);
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