using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MinhPham.Core.Common
{
    public class StringExtensions
    {
        #region Public Properties

        public static StringExtensions Instance
        {
            get
            {
                return Singleton<StringExtensions>.Instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ExistNumbericOrAnphabe(string input)
        {
            return input.Any(Char.IsLetterOrDigit);
        }

        /// <summary>
        ///     Convert string like name, address to standard string.
        ///     <para>Ex1: TO TIEN PHAI => To Tien Phai</para>
        ///     <para>Ex2: to TIEN pHAI => To Tien Phai</para>
        /// </summary>
        /// <param name="input">string input</param>
        /// <returns>string</returns>
        public string Standard(string input)
        {
            var builder = new StringBuilder();
            input = input.Trim().ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && input[i - 1] == ' ' || i == 0)
                {
                    builder.Append(input[i].ToString(CultureInfo.InvariantCulture).ToUpper());
                }
                else
                {
                    builder.Append(input[i]);
                }
            }
            string output = builder.ToString();
            return output;
        }

        public string ToUnsignString(string input)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = input.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        #endregion
    }
}