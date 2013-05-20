using System;
using System.Data;
using System.Web.UI;
using BepNhaBan.System;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Service
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

        public Common ObjComm = new Common();

        public CustomControl ObjControl = new CustomControl();
        private int _id;

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
            txtSystem.Text = ServiceDAO.Find(pID).Name;
            txten.Text = LocalizedPropertyDAO.Find(pID, 1,"Service", "Title").LocaleValue;
            txtjp.Text = LocalizedPropertyDAO.Find(pID, 2, "Service", "Title").LocaleValue;
            txtvi.Text = LocalizedPropertyDAO.Find(pID, 3, "Service", "Title").LocaleValue;
            ckFullen.Text = LocalizedPropertyDAO.Find(pID, 1, "Service", "Body") == null ? "" : LocalizedPropertyDAO.Find(pID, 1, "Service", "Body").LocaleValue;
            ckFulljp.Text = LocalizedPropertyDAO.Find(pID, 2, "Service", "Body") == null ? "" : LocalizedPropertyDAO.Find(pID, 2, "Service", "Body").LocaleValue; ;
            ckFullvi.Text = LocalizedPropertyDAO.Find(pID, 3, "Service", "Body") == null ? "" : LocalizedPropertyDAO.Find(pID, 3, "Service", "Body").LocaleValue; ;
             
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
                    ServiceDAO.Find(_id).Name = txtSystem.Text;
                    if (LocalizedPropertyDAO.Find(_id, 1, "Service", "Title") != null)
                        LocalizedPropertyDAO.Find(_id, 1, "Service", "Title").LocaleValue = txten.Text;
                    if (LocalizedPropertyDAO.Find(_id, 2, "Service", "Title") != null)
                        LocalizedPropertyDAO.Find(_id, 2, "Service", "Title").LocaleValue = txtjp.Text;
                    if (LocalizedPropertyDAO.Find(_id, 3, "Service", "Title") != null)
                        LocalizedPropertyDAO.Find(_id, 3, "Service", "Title").LocaleValue = txtvi.Text;
                    if (LocalizedPropertyDAO.Find(_id, 1, "Service", "Body") != null)
                        LocalizedPropertyDAO.Find(_id, 1, "Service", "Body").LocaleValue = ckFullen.Text;
                    if (LocalizedPropertyDAO.Find(_id, 2, "Service", "Body") != null)
                        LocalizedPropertyDAO.Find(_id, 2, "Service", "Body").LocaleValue = ckFulljp.Text;
                    if (LocalizedPropertyDAO.Find(_id, 3, "Service", "Body") != null)
                        LocalizedPropertyDAO.Find(_id, 3, "Service", "Body").LocaleValue = ckFullvi.Text;
                    ArticleDAO.Update();
                }
                else
                {
                    var x = new DAO.Service
                        {
                            Name = txtSystem.Text
                        };
                    ServiceDAO.Insert(x);
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                        {
                            EntityId = x.Id,
                            LanguageId = 1,
                            LocaleKeyGroup = "Service",
                            LocaleKey = "Title",
                            LocaleValue = txten.Text
                        });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 2,
                        LocaleKeyGroup = "Service",
                        LocaleKey = "Title",
                        LocaleValue = txtjp.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 3,
                        LocaleKeyGroup = "Service",
                        LocaleKey = "Title",
                        LocaleValue = txtvi.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 1,
                        LocaleKeyGroup = "Service",
                        LocaleKey = "Body",
                        LocaleValue = ckFullen.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 2,
                        LocaleKeyGroup = "Service",
                        LocaleKey = "Body",
                        LocaleValue = ckFulljp.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 3,
                        LocaleKeyGroup = "Service",
                        LocaleKey = "Body",
                        LocaleValue = ckFullvi.Text
                    });
                }

                #endregion

                if (type == "Publish")
                {
                    Response.Redirect("/AppAdmin/Service/Index.aspx");
                }
                else if (type == "Save")
                {
                    Response.Redirect("/AppAdmin/Service/Index.aspx");
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