using MinhPham.Core.Common;

namespace BNB.Core.Common.UnitTest
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeExtensions_Test
    {
        #region Fields

        private readonly DateTimeExtensions dateTimeExtensions = new DateTimeExtensions();

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void CompareMonthYear_Test()
        {
            var dataColl = new List<CompareMonthYearData>
                               {
                                   new CompareMonthYearData
                                       {
                                           dt1 =
                                               DateTime.Parse(
                                                   "1/1/2011"),
                                           dt2 =
                                               DateTime.Parse(
                                                   "1/2/2011"),
                                           exprected = true
                                       },
                                   new CompareMonthYearData
                                       {
                                           dt1 =
                                               DateTime.Parse(
                                                   "1/1/2011"),
                                           dt2 =
                                               DateTime.Parse(
                                                   "2/1/2011"),
                                           exprected = false
                                       },
                                   new CompareMonthYearData
                                       {
                                           dt1 =
                                               DateTime.Parse(
                                                   "1/1/2011"),
                                           dt2 =
                                               DateTime.Parse(
                                                   "1/1/2012"),
                                           exprected = false
                                       },
                                   new CompareMonthYearData
                                       {
                                           dt1 =
                                               DateTime.Parse(
                                                   "2/1/2011"),
                                           dt2 =
                                               DateTime.Parse(
                                                   "1/1/2012"),
                                           exprected = false
                                       }
                               };
            foreach (CompareMonthYearData data in dataColl)
            {
                Assert.AreEqual(data.exprected, this.dateTimeExtensions.CompareMonthYear(data.dt1, data.dt2));
            }
        }

        #endregion
    }

    public class CompareMonthYearData
    {
        #region Public Properties

        public DateTime dt1 { get; set; }

        public DateTime dt2 { get; set; }

        public bool exprected { get; set; }

        #endregion
    }
}