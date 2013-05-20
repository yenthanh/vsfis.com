using System;
using System.Data;
using System.Web.UI;
using BepNhaBan.System;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.Content
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
                        ltr_Title.Text = "Chỉnh sửa chủ đề";
                        LoadSpecialData(_id);
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
                        ltr_Title.Text = "Thêm mới chủ đề";
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
            txtSystem.Text = ContentDAO.Find(pID).Title;
            
            txten.Text = LocalizedPropertyDAO.Find(pID, 1, "Content", "Title") == null ? "" : LocalizedPropertyDAO.Find(pID, 1, "Content", "Title").LocaleValue;
            txtjp.Text = LocalizedPropertyDAO.Find(pID, 2, "Content", "Title") == null ? "" : LocalizedPropertyDAO.Find(pID, 2, "Content", "Title").LocaleValue;
            txtvi.Text = LocalizedPropertyDAO.Find(pID, 3, "Content", "Title") == null ? "" : LocalizedPropertyDAO.Find(pID, 3, "Content", "Title").LocaleValue;
            ckFullen.Text = LocalizedPropertyDAO.Find(pID, 1,"Content", "Body").LocaleValue;
            ckFulljp.Text = LocalizedPropertyDAO.Find(pID, 2, "Content", "Body").LocaleValue;
            ckFullvn.Text = LocalizedPropertyDAO.Find(pID, 3, "Content", "Body").LocaleValue;
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
                    ContentDAO.Find(_id).Title = txtSystem.Text;
                    if (LocalizedPropertyDAO.Find(_id, 1, "Content", "Title") == null)
                    {
                        LocalizedPropertyDAO.Insert(new LocalizedProperty
                        {
                            EntityId = _id,
                            LanguageId = 1,
                            LocaleKeyGroup = "Content",
                            LocaleKey = "Title",
                            LocaleValue = txten.Text
                        });
                    }
                    else
                    {
                        LocalizedPropertyDAO.Find(_id, 1, "Content", "Title").LocaleValue = txten.Text;  
                    }
                    if (LocalizedPropertyDAO.Find(_id, 2, "Content", "Title") == null)
                    {
                        LocalizedPropertyDAO.Insert(new LocalizedProperty
                            {
                                EntityId = _id,
                                LanguageId = 2,
                                LocaleKeyGroup = "Content",
                                LocaleKey = "Title",
                                LocaleValue = txtjp.Text
                            });
                    }
                    else
                    {
                        LocalizedPropertyDAO.Find(_id, 2, "Content", "Title").LocaleValue = txtjp.Text;
                    }
                    if (LocalizedPropertyDAO.Find(_id, 3, "Content", "Title") == null)
                    {
                        LocalizedPropertyDAO.Insert(new LocalizedProperty
                            {
                                EntityId = _id,
                                LanguageId = 3,
                                LocaleKeyGroup = "Content",
                                LocaleKey = "Title",
                                LocaleValue = txtvi.Text
                            });
                    }
                    else
                    {
                        LocalizedPropertyDAO.Find(_id, 3, "Content", "Title").LocaleValue = txtvi.Text;
                    }
                    LocalizedPropertyDAO.Find(_id, 1, "Content", "Body").LocaleValue = ckFullen.Text;
                    LocalizedPropertyDAO.Find(_id, 2, "Content", "Body").LocaleValue = ckFulljp.Text;
                    LocalizedPropertyDAO.Find(_id, 3, "Content", "Body").LocaleValue = ckFullvn.Text;
                    ContentDAO.Update();
                }
                else
                {
                    var x = new DAO.Content
                        {
                            Title = txtSystem.Text
                        };
                    ContentDAO.Insert(x);
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 1,
                        LocaleKeyGroup = "Content",
                        LocaleKey = "Title",
                        LocaleValue = txten.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 2,
                        LocaleKeyGroup = "Content",
                        LocaleKey = "Title",
                        LocaleValue = txtjp.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 3,
                        LocaleKeyGroup = "Content",
                        LocaleKey = "Title",
                        LocaleValue = txtvi.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                        {
                            EntityId = x.Id,
                            LanguageId = 1,
                            LocaleKeyGroup = "Content",
                            LocaleKey = "Body",
                            LocaleValue = ckFullen.Text
                        });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 2,
                        LocaleKeyGroup = "Content",
                        LocaleKey = "Body",
                        LocaleValue = ckFulljp.Text
                    });
                    LocalizedPropertyDAO.Insert(new LocalizedProperty
                    {
                        EntityId = x.Id,
                        LanguageId = 3,
                        LocaleKeyGroup = "Content",
                        LocaleKey = "Body",
                        LocaleValue = ckFullvn.Text
                    });
                }

                #endregion

                if (type == "Publish")
                {
                    Response.Redirect("/AppAdmin/Content/Index.aspx");
                }
                else if (type == "Save")
                {
                    Response.Redirect("/AppAdmin/Content/Index.aspx");
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