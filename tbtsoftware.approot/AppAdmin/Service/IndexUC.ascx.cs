using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BepNhaBan.System;
using DevExpress.Web.ASPxGridView;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Service
{
    public partial class IndexUC : UserControl
    {
        #region Methods

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strSanPham_Xem")))
            {
                if (!IsPostBack)
                {
                    BinList();
                }
            }
            else
            {
                iRightAccess.Visible = false;
                objControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strTinhNang_Xoa")))
            {
                var hdf = (lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;
                if (hdf != null)
                {
                    ServiceDAO.Delete(Int32.Parse(hdf.Value));
                    lv_ThongTinSP.EditIndex = -1;
                    BinList();
                }
            }
            else
            {
                iRightAccess.Visible = false;
                objControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lv_ThongTinSP_HtmlDataCellPrepared(ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Unbound")
            {
                e.Cell.Text = (e.VisibleIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        protected void lv_ThongTinSP_ItemDeleted(object sender, ListViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
            }
        }

        private void BinList()
        {
            lv_ThongTinSP.DataSource = ServiceDAO.Get();
            lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}