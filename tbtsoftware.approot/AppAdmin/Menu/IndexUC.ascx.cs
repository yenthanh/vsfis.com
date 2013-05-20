using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BepNhaBan.System;
using DevExpress.Web.ASPxEditors;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Menu
{
    public partial class IndexUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();
        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strDanhMuc_Xem")))
            {
                if (!IsPostBack)
                {
                    BinList();
                    Page.Title = "Menu";
                }
            }
            else
            {
                iRightAccess.Visible = false;
                objControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strDanhMuc_Sua")))
            {
                //foreach (ListViewDataItem lvit in this.listView.Items)
                //{
                //    string id;
                //    if (((HiddenField)lvit.FindControl("hfID")).Value != "")
                //    {
                //        id = ((HiddenField)lvit.FindControl("hfID")).Value;
                //    }
                //    else
                //    {
                //        this.ltr_Notice.Text = this.objComm.ShowNotice(
                //            false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng mã danh mục");
                //        return;
                //    }
                //    string ods = ((ASPxTextBox)lvit.FindControl("txt_OrderSort")).Text;
                //    int ordersort;
                //    int tint;
                //    if (Int32.TryParse(ods, out tint))
                //    {
                //        ordersort = tint;
                //    }
                //    else
                //    {
                //        this.ltr_Notice.Text = this.objComm.ShowNotice(
                //            false,
                //            "Cập nhật thông tin thất bại.\nThứ tự nhập vào không phải kiểu số.\nHãy kiểm tra và thử lại!");
                //        return;
                //    }

                //    Catalog ctit = ProductDAO.getCategoryById(id).First();
                //    ctit.OrderSort = ordersort;
                //    ProductDAO.Update();
                //}
                //this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                //this.BinList();
            }
            else
            {
                objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-danh-muc';</script>");
            }
        }

        protected void lbtn_Xoa_Click(object sender, EventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strDanhMuc_Xoa")))
            {
                foreach (ListViewDataItem lvit in listView.Items)
                {
                    string id;
                    if (((HiddenField) lvit.FindControl("hfID")).Value != "")
                    {
                        id = ((HiddenField) lvit.FindControl("hfID")).Value;
                    }
                    else
                    {
                        ltr_Notice.Text = objComm.ShowNotice(
                            false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng mã danh mục");
                        return;
                    }
                    if (((ASPxCheckBox) lvit.FindControl("ckb_Choose")).Checked)
                    {
                        CatalogDAO.Delete(id);
                    }
                }
                ltr_Notice.Text = objComm.ShowNotice(true, "Xóa danh mục đã chọn thành công!");
                BinList();
            }
            else
            {
                objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-danh-muc';</script>");
            }
        }

        protected void listView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (objCheckPermision.Permission(objCheckPermision.LayQuyen("strDanhMuc_Xoa")))
            {
                ListViewDataItem dataItem = listView.Items[e.ItemIndex];
                string id = ((HiddenField) dataItem.FindControl("hfID")).Value;
                //if (SanPhamDAO.CheckProductInCateDelete(ID))
                //{
                //}
                DAO.Menu ctit = MenuDAO.Find(int.Parse(id));
                ctit.IsDelete = true;
                MenuDAO.Update();
                ltr_Notice.Text = objComm.ShowNotice(true, "Menu đã được xóa thành công!!");
                BinList();
            }
            else
            {
                objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-danh-muc';</script>");
            }
        }

        private void BinList()
        {
            listView.DataSource = MenuDAO.GetHierarchyMenu(MenuDAO.GetRoot, 0);
            listView.DataBind();
        }

        #endregion
    }
}