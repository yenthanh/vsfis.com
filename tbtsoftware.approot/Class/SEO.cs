namespace BepNhaBan.System
{
    using global::System.Web.UI.HtmlControls;

    public static class SEO
    {
        #region Public Methods and Operators

        public static void ThemMetaDescript(HtmlHead head, string descript)
        {
            var _MyName = new HtmlMeta { Name = "description", Content = descript };
            head.Controls.Add(_MyName);
        }

        #endregion
    }
}