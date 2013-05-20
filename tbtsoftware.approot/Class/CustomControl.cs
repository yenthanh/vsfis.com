namespace BepNhaBan.System
{
    using global::System.Web.UI;
    using global::System.Web.UI.HtmlControls;

    public class CustomControl : UserControl
    {
        // Methods

        #region Public Methods and Operators

        public void LoadMyControl(HtmlTableCell tblCellId, string strPath)
        {
            tblCellId.Controls.Add(base.LoadControl(strPath));
        }

        #endregion
    }
}