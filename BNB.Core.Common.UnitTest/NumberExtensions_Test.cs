using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinhPham.Core.Common.UnitTest
{
    [TestClass]
    public class NumberExtensions_Test
    {
        #region Fields

        private readonly NumberExtensions stringExtensions = new NumberExtensions();

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void NumberFormat1_Test()
        {
            var dataColl = new List<InputData1>
                               {
                                   new InputData1 { input = 100, expectOutput = "100" },
                                   new InputData1 { input = 9999, expectOutput = "9,999" },
                                   new InputData1 { input = 12345678, expectOutput = "12,345,678" },
                                   new InputData1 { input = 1234567891, expectOutput = "1,234,567,891" },
                               };
            foreach (InputData1 data in dataColl)
            {
                Assert.AreEqual(data.expectOutput, this.stringExtensions.NumberFormat(data.input));
            }
        }

        [TestMethod]
        public void NumberFormat_Test()
        {
            var dataColl = new List<InputData>
                               {
                                   new InputData { input = "100", expectOutput = "100" },
                                   new InputData { input = "9999", expectOutput = "9,999" },
                                   new InputData { input = "12345678", expectOutput = "12,345,678" },
                                   new InputData { input = "1234567891", expectOutput = "1,234,567,891" },
                               };
            foreach (InputData data in dataColl)
            {
                Assert.AreEqual(data.expectOutput, this.stringExtensions.NumberFormat(data.input));
            }
        }

        #endregion
    }
}