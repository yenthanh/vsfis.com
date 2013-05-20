using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MinhPham.Web.BepNhaBan.Class;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.AppAdmin.AdminControls
{
    public partial class AdminNavBar : UserControl
    {
        #region Fields

        protected Common ObjComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.Cookies["AdminID"] != null)
                //{
                //    Label1.Text = Request.Cookies["AdminID"].Value;
                //}
                repeater.DataSource = MenuDAO.GetChild(MenuDAO.GetRoot);
                repeater.DataBind();
            }
        }

        protected void repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var o = (DAO.Menu)e.Item.DataItem;
                var r2 = (Repeater)e.Item.FindControl("repeaterChild");
                r2.DataSource = MenuDAO.GetChild(o.Id);
                r2.DataBind();
            }
        }

        #endregion
    }
}