using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BepNhaBan.System;
using MinhPham.Web.BepNhaBan.Class;
using bnb.approot.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Config.Branch
{
    public partial class BranchUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Fields

        private readonly PermissionCheck _objCheckPermision = new PermissionCheck();
        public Common ObjComm = new Common();

        public CustomControl ObjControl = new CustomControl();

        public DBHelper ObjDb = new DBHelper();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strChiNhanh_Xem")))
            {
                if (!Page.IsPostBack)
                {
                    BinList();
                }
            }
            else
            {
                iRightAccess.Visible = false;
                ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strChiNhanh_Sua")))
            {
                try
                {
                    foreach (ListViewDataItem lvit in lv_ThongTinSP.Items)
                    {
                        string chiNhanhID;
                        if (((HiddenField) lvit.FindControl("hfID")).Value != "")
                        {
                            chiNhanhID = ((HiddenField) lvit.FindControl("hfID")).Value;
                        }
                        else
                        {
                            ltr_Notice.Text = ObjComm.ShowNotice(
                                false, "Cập nhật thông tin thất bại.\nLỗi trong quá trình nhận dạng chi nhánh");
                            return;
                        }
                        DAO.Branch t0 = ChiNhanhDAO.Get(Int32.Parse(chiNhanhID));
                        t0.Name = ((TextBox) lvit.FindControl("txt_Name")).Text;
                        t0.Name = ((TextBox) lvit.FindControl("txt_Name")).Text;
                        ChiNhanhDAO.Update();
                    }
                    ltr_Notice.Text = ObjComm.ShowNotice(true, "Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    ltr_Notice.Text = ObjComm.ShowNotice(
                        false, "Cập nhật thông tin thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
            else
            {
                ObjComm.wr(
                    "<script language='javascript'>alert('Bạn không có quyền thực hiện chức năng này.');location.href='tin-tuc';</script>");
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
            lv_ThongTinSP.EditIndex = -1;
            BinList();
        }

        protected void lv_ThongTinSP_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strChiNhanh_Xoa")))
            {
                var hdf = (lv_ThongTinSP.Items[e.ItemIndex].FindControl("hfID")) as HiddenField;

                if (hdf != null)
                {
                    ChiNhanhDAO.Delete(Int32.Parse(hdf.Value));
                    lv_ThongTinSP.EditIndex = -1;
                    BinList();
                }
            }
            else
            {
                iRightAccess.Visible = false;
                ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        protected void lv_ThongTinSP_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strChiNhanh_Them")))
            {
                var t0 = new DAO.Branch();
                var txt = (e.Item.FindControl("txt_Name")) as TextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                txt = (e.Item.FindControl("txt_Name")) as TextBox;
                if (txt != null)
                {
                    t0.Name = txt.Text;
                }
                ChiNhanhDAO.Insert(t0);
                lv_ThongTinSP.EditIndex = -1;
                BinList();
            }
            else
            {
                iRightAccess.Visible = false;
                ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        private void BinList()
        {
            lv_ThongTinSP.DataSource = ChiNhanhDAO.Get();
            lv_ThongTinSP.DataBind();
        }

        #endregion
    }
}