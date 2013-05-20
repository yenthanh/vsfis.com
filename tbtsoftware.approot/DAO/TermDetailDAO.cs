namespace bnb.approot.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public class TermDetailDAO
    {
        #region Public Methods and Operators

        public static Boolean CheckImagesByUrl(string imageUrl)
        {
            return BNBDataContext.Instance.SanPham_HinhAnhs.Any(p => p.ImageUrl.Equals(imageUrl));
        }

        public static void DeleteImagesByID(int ID)
        {
            BNBDataContext.Instance.SanPham_HinhAnhs.DeleteOnSubmit(
                BNBDataContext.Instance.SanPham_HinhAnhs.Single(p => p.ProductID.Equals(ID)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void DeleteImagesByUrl(string imageUrl)
        {
            BNBDataContext.Instance.SanPham_HinhAnhs.DeleteOnSubmit(
                BNBDataContext.Instance.SanPham_HinhAnhs.Single(p => p.ImageUrl.Equals(imageUrl)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static List<TermDetail> Get(DateTime term)
        {
            DateTime _term = DateTime.Parse("1/" + term.Month + "/" + term.Year);
            return BNBDataContext.Instance.TermDetails.Where(o => o.Term == _term).ToList();
        }

        public static void Insert(TermDetail _obj)
        {
            BNBDataContext.Instance.TermDetails.InsertOnSubmit(_obj);
            Update();
        }

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}