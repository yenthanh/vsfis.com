using MinhPham.Core.Common;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Agent.Customer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DevExpress.Web.ASPxEditors;
    using DevExpress.Web.ASPxGridView;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    using bnb.approot.DAO;

    using global::BepNhaBan.System;

    public partial class IndexUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        private readonly PermissionCheck objCheckPermision = new PermissionCheck();

        #endregion

        //public void DocDuLieuXml()
        //{
        //    XDocument xdoc = XDocument.Load(this.Server.MapPath("Customer.xml"));

        //    IEnumerable<Customer> _customer = from customerItem in xdoc.Descendants("Customer")
        //                                      let xElement = customerItem.Element("Address")
        //                                      where xElement != null
        //                                      let element = customerItem.Element("CustomerID")
        //                                      where element != null
        //                                      let xElement1 = customerItem.Element("CustomerName")
        //                                      where xElement1 != null
        //                                      let element1 = customerItem.Element("Phone")
        //                                      where element1 != null
        //                                      select
        //                                          new Customer
        //                                              {
        //                                                  ID = element.Value,
        //                                                  Name = xElement1.Value,
        //                                                  Address = xElement.Value,
        //                                                  Tel = element1.Value,
        //                                                  GasUsed = customerItem.G,
        //                                                  IsCare = false,
        //                                                  Active = true,
        //                                                  IsDelete = false,
        //                                              };
        //    foreach (Customer t0 in _customer)
        //    {
        //        PartnerDAO.Insert(t0);
        //    }
        //}

        #region Methods

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.BinList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_Xem")))
            {
                if (!this.IsPostBack)
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

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_Sua")))
            {
                foreach (ListViewDataItem lvit in this.lv_HienThi.Items)
                {
                    int id;
                    if (((HiddenField)lvit.FindControl("hfID")).Value != "")
                    {
                        id = int.Parse(((HiddenField)lvit.FindControl("hfID")).Value);
                    }
                    else
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(
                            false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng mã sản phẩm");
                        return;
                    }

                    Partner t0 = NewsFactory.Find(id, true);
                    t0.Name = StringExtensions.Instance.Standard(((ASPxTextBox)lvit.FindControl("txtName")).Text);
                    t0.Address = StringExtensions.Instance.Standard(((ASPxTextBox)lvit.FindControl("txtAddress")).Text);
                    t0.Tel = ((ASPxTextBox)lvit.FindControl("txtTel")).Text;
                    t0.Note = ((ASPxTextBox)lvit.FindControl("txtNote")).Text;
                    t0.IsCare = ((CheckBox)lvit.FindControl("ckb_IsCare")).Checked;
                    t0.Active = ((CheckBox)lvit.FindControl("ckb_Active")).Checked;
                    NewsFactory.Update();
                }
                this.ltr_Notice.Text = this.objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='danh-sach-khach-hang';</script>");
            }
        }

        protected void lbtn_DoTim_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_DoTim")))
            {
                NewsFactory.RadarKhachHang();
                this.Response.Redirect("canh-bao-khach-hang");
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-san-pham';</script>");
            }
        }

        protected void lbtn_TK_Click(object sender, EventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_TimKiem")))
            {
                if (this.txt_TimKiem.Text != "")
                {
                    this.Response.Redirect("danh-sach-khach-hang?q=" + this.txt_TimKiem.Text);
                }
                else
                {
                    this.Response.Redirect("danh-sach-khach-hang");
                }
            }
            else
            {
                this.objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='danh-sach-khach-hang';</script>");
            }
        }

        protected void lv_HienThi_HtmlDataCellPrepared(ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Unbound")
            {
                e.Cell.Text = (e.VisibleIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        protected void lv_HienThi_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            this.lv_HienThi.EditIndex = -1;
            this.BinList();
        }

        protected void lv_HienThi_ItemDeleted(object sender, ListViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
            }
        }

        protected void lv_HienThi_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_Xoa")))
            {
                var hdf = (this.lv_HienThi.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;
                if (hdf != null)
                {
                    if (NewsFactory.Delete(hdf.Value) != "")
                    {
                        this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Xóa khách hàng thất bại!");
                    }
                    this.lv_HienThi.EditIndex = -1;
                    this.BinList();
                }
            }
            else
            {
                this.iRightAccess.Visible = false;
                this.objControl.LoadMyControl(this.idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lv_HienThi_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (this.objCheckPermision.Permission(this.objCheckPermision.LayQuyen("strKhachHang_Them")))
            {
                var t0 = new Partner();
                var txt = (e.Item.FindControl("txtID")) as ASPxTextBox;
                if (txt != null)
                {
                    t0.ID = int.Parse(txt.Text);
                }
                if (txt != null && NewsFactory.Any(t0.ID))
                {
                    this.ltr_Notice.Text = this.objComm.ShowNotice(false, "Trung ma!");
                    return;
                }
                txt = (e.Item.FindControl("txtName")) as ASPxTextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                txt = (e.Item.FindControl("txtAddress")) as ASPxTextBox;
                if (txt != null)
                {
                    t0.Address = txt.Text;
                }
                txt = (e.Item.FindControl("txtTel")) as ASPxTextBox;
                if (txt != null)
                {
                    t0.Tel = txt.Text;
                }
                txt = (e.Item.FindControl("txtNote")) as ASPxTextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                t0.IsCare = false;
                t0.Active = true;
                t0.IsDelete = false;
                t0.Created = DateTime.Now;
                t0.PartnerGroupID = (int)PartnerEnum.Customer;
                NewsFactory.Insert(t0);
                this.lv_HienThi.EditIndex = -1;
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
            IEnumerable<Partner> list = NewsFactory.Get();

            //if (Request.QueryString["NgayKS"] != null)
            //{
            //    if (Request.QueryString["NgayKS"].ToString() == "tang")
            //    {
            //        list = list.OrderBy(p => p.NgayKS);
            //    }
            //    else
            //        list = list.OrderByDescending(p => p.NgayKS);

            //}
            if (Common.RequestID("q") != "")
            {
                this.txt_TimKiem.Text = Common.RequestID("q").ToLower();
                list =
                    list.Where(
                        p =>
                        p.Alias.ToLower().Contains(this.txt_TimKiem.Text)
                        || p.Name.ToLower().Contains(this.txt_TimKiem.Text)
                        || p.Address.ToLower().Contains(this.txt_TimKiem.Text));
            }
            this.lv_HienThi.DataSource = list;
            this.lv_HienThi.DataBind();
        }

        #endregion
    }
}