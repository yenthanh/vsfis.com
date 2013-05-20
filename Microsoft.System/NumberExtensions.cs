using System;

namespace MinhPham.Core.Common
{
    public class NumberExtensions
    {
        #region Public Properties

        public static NumberExtensions Instance
        {
            get
            {
                return Singleton<NumberExtensions>.Instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        public string NumberFormat(String value)
        {
            Double t_d;
            return Double.TryParse(value, out t_d) ? NumberFormat(t_d) : "";
        }

        public string NumberFormat(Double value)
        {
            return String.Format("{0:0,0.##}", value);
        }

        #endregion
    }
}