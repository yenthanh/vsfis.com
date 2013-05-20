namespace MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using System.Xml.Linq;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using global::BepNhaBan.System;

    public partial class TinhNangChucNangUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static int function_Group_ID;

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        public DBHelper objDB = new DBHelper();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        #region Public Methods and Operators

        public void DongBoReSource(string key, string value)
        {
            var loResource = new XmlDocument();
            loResource.Load(this.Server.MapPath("/App_GlobalResources/Permission.resx"));
            XmlNode loRoot = loResource.SelectSingleNode(String.Format("root/data[@name='{0}']/value", key));
            if (loRoot != null)
            {
                loRoot.InnerText = value;
                loResource.Save(this.Server.MapPath("/App_GlobalResources/Permission.resx"));
            }
            else
            {
                XDocument xdoc = XDocument.Load(this.Server.MapPath("/App_GlobalResources/Permission.resx"));
                XElement rootEl = xdoc.Element("root");
                XElement subEL = null;
                var el_1 = new XElement("data");
                var att2 = new XAttribute("name", key);
                el_1.Add(att2);
                subEL = new XElement("value", value);
                el_1.Add(subEL);
                rootEl.Add(el_1);
                xdoc.Save(this.Server.MapPath("/App_GlobalResources/Permission.resx"));
            }
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNangChucNang_Xem")))
            {
                if (!this.Page.IsPostBack)
                {
                    if (Common.RequestID("manhom") != "")
                    {
                        function_Group_ID = Int32.Parse(Common.RequestID("manhom"));
                    }
                    this.ltr_Title.Text = "Danh sách tính năng của nhóm chức năng: "
                                          + MemberGroupDAO.LayNhomChucNangById(function_Group_ID).FunctionGroupName;
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strgTinhNangChucNang_Sua")))
            {
                try
                {
                    string function_ID;
                    foreach (ListViewItem lvit in this.lv_ThongTinSP.Items)
                    {
                        if (((HiddenField)lvit.FindControl("hfFunction_ID")).Value != "")
                        {
                            function_ID = ((HiddenField)lvit.FindControl("hfFunction_ID")).Value;
                        }
                        else
                        {
                            this.ltr_Notice.Text = this.objComm.ShowNotice(
                                false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng nhóm chức năng");
                            return;
                        }
                        TBT_AdminFunction ctit = MemberGroupDAO.LayTinhNangChucNangById(Int32.Parse(function_ID));
                        ctit.FunctionCode = ((TextBox)lvit.FindControl("txt_FunctionCode")).Text;
                        ctit.FunctionDesc = ((TextBox)lvit.FindControl("txt_FunctionDesc")).Text;
                        this.DongBoReSource(ctit.FunctionDesc, ctit.FunctionCode);
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNangChucNang_Xoa")))
            {
                var hdf = (this.lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfFunction_ID")) as HiddenField;

                if (hdf != null)
                {
                    if (MemberGroupDAO.XoaTinhNangChucNang(Int32.Parse(hdf.Value)) != "")
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Xóa tính năng chức năng thất bại");
                        return;
                    }
                    else
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
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
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strTinhNangChucNang_Them")))
            {
                int functionName_ID = 0;
                var txt1 = (e.Item.FindControl("ddl_FunctionName")) as DropDownList;
                if (txt1 != null)
                {
                    functionName_ID = Int32.Parse(txt1.SelectedValue);
                }
                if (!MemberGroupDAO.KiemTraTonTaiTinhNangChucNang(functionName_ID, function_Group_ID))
                {
                    var it = new TBT_AdminFunction();
                    var txt = (e.Item.FindControl("txt_FunctionCode")) as TextBox;
                    if (txt != null)
                    {
                        it.FunctionCode = txt.Text;
                    }
                    it.FunctionName_ID = functionName_ID;
                    txt = (e.Item.FindControl("txt_FunctionGroupDesc")) as TextBox;
                    if (txt != null)
                    {
                        it.FunctionDesc = txt.Text;
                    }
                    it.Function_Group_ID = function_Group_ID;
                    MemberGroupDAO.ThemTinhNangChucNang(it);
                    this.lv_ThongTinSP.EditIndex = -1;
                    this.BinList();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(
                        this.GetType(), "popup", "popup('Tính năng chức năng này đã tồn tại!.');", true);
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        private void BinList()
        {
            this.lv_ThongTinSP.DataSource = MemberGroupDAO.DanhSachTinhNangChucNang(function_Group_ID);
            this.lv_ThongTinSP.DataBind();
            var ddl_FunctionName = (DropDownList)this.lv_ThongTinSP.InsertItem.FindControl("ddl_FunctionName");
            ddl_FunctionName.DataSource = MemberGroupDAO.DanhSachTinhNang();
            ddl_FunctionName.DataValueField = "FunctionName_ID";
            ddl_FunctionName.DataTextField = "FunctionName";
            ddl_FunctionName.DataBind();
        }

        #endregion
    }
}