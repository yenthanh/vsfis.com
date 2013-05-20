using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BepNhaBan.System;
using DevExpress.Web.ASPxEditors;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Agent.Supplier
{
    public partial class IndexUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        private readonly PermissionCheck _objCheckPermision = new PermissionCheck();

        private string Mobile;

        private string Name;

        private string Phone;

        private string SupplierID;

        private string _address;

        private string _bankName;

        private string _bankNumber;

        private string _email;
        public Common objComm = new Common();

        public CustomControl objControl = new CustomControl();

        public DBHelper objDB = new DBHelper();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strNCC_Xem")))
            {
                if (!Page.IsPostBack)
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

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strNCC_Sua")))
            {
                try
                {
                    foreach (ListViewDataItem lvit in lv_ThongTinSP.Items)
                    {
                        string ID;
                        if (((HiddenField) lvit.FindControl("hfID")).Value != "")
                        {
                            ID = ((HiddenField) lvit.FindControl("hfID")).Value;
                        }
                        else
                        {
                            ltr_Notice.Text = objComm.ShowNotice(
                                false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng chi nhánh");
                            return;
                        }
                        Partner t0 = NewsFactory.Find(Int32.Parse(ID));
                        t0.ID = int.Parse(((TextBox) lvit.FindControl("txtAlias")).Text);
                        t0.Name = ((TextBox) lvit.FindControl("txtName")).Text;
                        t0.Address = ((TextBox) lvit.FindControl("txt_Address")).Text;
                        t0.Email = ((TextBox) lvit.FindControl("txt_Email")).Text;
                        t0.Tel = ((TextBox) lvit.FindControl("txt_Phone")).Text;
                        t0.Phone = ((TextBox) lvit.FindControl("txt_Mobile")).Text;
                        t0.BankNumber = ((TextBox) lvit.FindControl("txt_BankNumber")).Text;
                        t0.BankName = ((TextBox) lvit.FindControl("txt_BankName")).Text;
                        NewsFactory.Update();
                    }
                    ltr_Notice.Text = objComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    ltr_Notice.Text = objComm.ShowNotice(
                        false, "Cập nhật thông tin thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
            else
            {
                objComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='thong-tin-san-pham';</script>");
            }
        }

        protected void lv_ThongTinSP_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lv_ThongTinSP.EditIndex = -1;
            BinList();
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strNCC_Xoa")))
            {
                var hdf = (lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;

                if (hdf != null)
                {
                    NewsFactory.Delete(Int32.Parse(hdf.Value));
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

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strNCC_Them")))
            {
                if (ValidateData())
                {
                    var t0 = new Partner
                        {
                            ID = int.Parse(SupplierID),
                            Name = Name,
                            Address = _address,
                            Email = _email,
                            Tel = Phone,
                            Phone = Mobile,
                            BankNumber = _bankNumber,
                            BankName = _bankName,
                            PartnerGroupID = (int) PartnerEnum.Supplier
                        };
                    NewsFactory.Insert(t0);
                    lv_ThongTinSP.EditIndex = -1;
                    BinList();
                    ltr_Notice.Text = objComm.ShowNotice(true, "Thêm mới nhà cung cấp thành công!");
                }
            }
            else
            {
                iRightAccess.Visible = false;
                objControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        private void BinList()
        {
            lv_ThongTinSP.DataSource = NewsFactory.Get((int) PartnerEnum.Supplier);
            lv_ThongTinSP.DataBind();
        }

        private bool ValidateData()
        {
            SupplierID = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txtAlias")).Text;
            Name = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txtName")).Text;
            _address = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_Address")).Text;
            _email = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_Email")).Text;
            Phone = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_Phone")).Text;
            Mobile = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_Mobile")).Text;
            _bankNumber = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_BankNumber")).Text;
            _bankName = ((TextBox) lv_ThongTinSP.InsertItem.FindControl("txt_BankName")).Text;
            if (SupplierID == "")
            {
                ltr_Notice.Text = objComm.ShowNotice(false, "Bạn chưa nhập mã nhà cung cấp");
                return false;
            }
            if (Name == "")
            {
                ltr_Notice.Text = objComm.ShowNotice(false, "Bạn chưa nhập tên nhà cung cấp");
                return false;
            }
            if (_address == "")
            {
                ltr_Notice.Text = objComm.ShowNotice(false, "Bạn chưa nhập địa chỉ nhà cung cấp");
                return false;
            }
            return true;
        }

        #endregion
    }
}