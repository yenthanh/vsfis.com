using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinhPham.Core.Common.UnitTest
{
    [TestClass]
    public class StringExtensions_Test
    {
        #region Fields

        private readonly StringExtensions stringExtensions = new StringExtensions();

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void ConvertToUnSign_Test()
        {
            var dataColl = new List<InputData>
                               {
                                   new InputData
                                       {
                                           input = "TÔ-TIÊN. PHÁI",
                                           expectOutput = "TO TIEN- PHAI"
                                       },
                                   new InputData { input = "Nguyễn ;Văn", expectOutput = "Nguyen -Van" }
                               };
            foreach (InputData data in dataColl)
            {
                Assert.AreEqual(data.expectOutput, this.stringExtensions.Standard(data.input));
            }
        }

        [TestMethod]
        public void ExistNumbericOrAnphabe_Test()
        {
            var dataColl = new List<InputData>
                               {
                                   new InputData { input = "TÔ TIÊN PHÁI", expectOutput = "true" },
                                   new InputData { input = "```11111Văn", expectOutput = "true" },
                                   new InputData { input = "```", expectOutput = "false" },
                               };
            foreach (InputData data in dataColl)
            {
                Assert.AreEqual(bool.Parse(data.expectOutput), this.stringExtensions.ExistNumbericOrAnphabe(data.input));
            }
        }

        [TestMethod]
        public void Standard_Test()
        {
            var dataColl = new List<InputData>
                               {
                                   new InputData { input = "TÔ TIÊN PHÁI", expectOutput = "Tô Tiên Phái" },
                                   new InputData { input = "tÔ TIÊN pHÁI", expectOutput = "Tô Tiên Phái" }
                               };
            foreach (InputData data in dataColl)
            {
                Assert.AreEqual(data.expectOutput, this.stringExtensions.Standard(data.input));
            }
        }

        [TestMethod]
        public void ToUnsignString_Test()
        {
            var dataColl = new List<InputData>
                               {
                                   new InputData { input = "TÔ TIÊN PHÁI", expectOutput = "TO TIEN PHAI" },
                                   new InputData { input = "Nguyễn Văn", expectOutput = "Nguyen Van" }
                               };
            foreach (InputData data in dataColl)
            {
                Assert.AreEqual(data.expectOutput, this.stringExtensions.ToUnsignString(data.input));
            }
        }

        #endregion
    }

    public class InputData
    {
        #region Public Properties

        public string expectOutput { get; set; }

        public string input { get; set; }

        #endregion
    }

    public class InputData1
    {
        #region Public Properties

        public string expectOutput { get; set; }

        public double input { get; set; }

        #endregion
    }
}