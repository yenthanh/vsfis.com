using System;

namespace MinhPham.Core.Common
{
    public class DateTimeExtensions
    {
        #region Public Properties

        public static DateTimeExtensions Instance
        {
            get
            {
                return Singleton<DateTimeExtensions>.Instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool CompareMonthYear(DateTime dt1, DateTime dt2)
        {
            if (dt1.Month == dt2.Month && dt1.Year == dt2.Year)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}