using System;
using System.Configuration;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan.AppAdmin
{
    public partial class AdminHome : MasterPage
    {
        #region Constants

        private const string FooterControl = "~/AppAdmin/AdminControls/AdminFooter.ascx";

        private const string GlobalToolbarControl = "~/AppAdmin/AdminControls/GlobalToolbar.ascx";

        private const string NavBarControl = "~/AppAdmin/AdminControls/AdminNavBar.ascx";

        private const string SummaryControl = "~/AppAdmin/CanhBao/CanhBaoThongMinh_ViewUC.ascx";

        #endregion

        #region Fields

        protected Common ObjComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                    tdNavBarControl.Controls.Add(LoadControl(NavBarControl));
                    if (ConfigurationManager.AppSettings["DisableFooterControl"] == null
                        || ConfigurationManager.AppSettings["DisableFooterControl"] != "true")
                    {
                        tdFooterControl.Controls.Add(LoadControl(FooterControl));
                    }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        #endregion
    }
}