using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BepNhaBan.System;
using DevExpress.Web.ASPxCallback;
using DevExpress.Web.ASPxEditors;
using MinhPham.Core.Common;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;
using bnb.approot.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Article
{
    public partial class EditUC : UserControl
    {
        #region Constants

        private const string NotPermissControl = "~/AppAdmin/AdminControls/NoPermissionControl.ascx";

        #endregion

        #region Static Fields

        private static DataTable table;

        #endregion

        #region Fields

        private readonly PermissionCheck _objCheckPermision = new PermissionCheck();

        private int _id;

        public Common ObjComm = new Common();

        public CustomControl ObjControl = new CustomControl();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.RequestID("id") != "")
            {
                _id = int.Parse(Common.RequestID("id"));
            }

            if (_id != 0)
            {
                if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strSanPham_Sua")))
                {
                    if (!IsPostBack)
                    {
                        table = null;
                        ltr_Title.Text = "Chỉnh sửa thông tin sản phẩm";
                        LoadSpecialData(_id);
                        Page.Title = "Thay đổi thông tin sản phẩm - Bếp Nhà Bạn";
                    }
                }
                else
                {
                    iRightAccess.Visible = false;
                    ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
                }
            }
            else
            {
                if (_objCheckPermision.Permission(_objCheckPermision.LayQuyen("strSanPham_Them")))
                {
                    if (!IsPostBack)
                    {
                        ltr_Title.Text = "Thêm mới sản phẩm";
                    }
                }
                else
                {
                    iRightAccess.Visible = false;
                    ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
                }
            }
        }

        protected void lbtnPublish_Click()
        {
            Save("Publish");
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            Save("Save");
        }

        private void LoadSpecialData(int pID)
        {

            var dtit = ArticleDAO.Find(pID);
            ddlLang.SelectedValue = dtit.LanguageId.ToString();
            txtTitle.Text = dtit.Title;
            txtShort.Text = dtit.Short;
            ckFull.Text = dtit.FullDescript;
            ckbPublish.Checked = bool.Parse(dtit.Published.ToString());
        }

        private bool Validate()
        {
            return true;
        }

        private void Save(string type)
        {
            if (Validate())
            {
                
                #region Insert SanPham

                if (_id != 0)
                {
                    var dtit = ArticleDAO.Find(_id);
                    dtit.Language = BNBDataContext.Instance.Languages.Single(p => p.ID.ToString() == ddlLang.SelectedValue); 
                    dtit.Title = txtTitle.Text;
                    dtit.Short = txtShort.Text;
                    dtit.FullDescript = ckFull.Text;
                    dtit.Published = ckbPublish.Checked;
                    ArticleDAO.Update();
                }
                else
                {
                    var diit = new DAO.Article
                        {
                            LanguageId = int.Parse(ddlLang.SelectedValue),
                            Title = txtTitle.Text,
                            Short = txtShort.Text,
                            FullDescript = ckFull.Text,
                            Published = ckbPublish.Checked,
                            CreatedOnUtc = DateTime.UtcNow
                        };

                    ArticleDAO.Insert(diit);
                }

                #endregion

                if (type == "Publish")
                {
                    Response.Redirect("AppAdmin/Article/Index.aspx");
                }
                else if (type == "Save")
                {
                    Response.Redirect("/AppAdmin/Article/Index.aspx");
                }
            }
            else
            {
                iRightAccess.Visible = false;
                ObjControl.LoadMyControl(idNotPermissionAccess, NotPermissControl);
            }
        }

        #endregion
    }
}