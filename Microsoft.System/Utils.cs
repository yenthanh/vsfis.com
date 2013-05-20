namespace MinhPham.Core.Common
{
    internal class Utils
    {
        #region Public Methods and Operators

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        #endregion
    }
}