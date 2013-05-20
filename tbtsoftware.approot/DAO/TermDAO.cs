namespace bnb.approot.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TermDAO
    {
        #region Public Methods and Operators

        public static List<TermDetail> Get(DateTime term)
        {
            DateTime _term = DateTime.Parse("1/" + term.Month + "/" + term.Year);
            return BNBDataContext.Instance.TermDetails.Where(o => o.TermID == _term).ToList();
        }

        public static IQueryable<SanPham_HinhAnh> GetImagesByImageID(string imageID)
        {
            return
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(
                    p => p.IsDelete.Equals(false) && p.ImageID.Equals(imageID));
        }

        public static IQueryable<SanPham_HinhAnh> GetImagesByProductId(int productID)
        {
            return
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(
                    p => p.IsDelete.Equals(false) && p.ProductID.Equals(productID));
        }

        public static void Insert(Term _obj)
        {
            BNBDataContext.Instance.Terms.InsertOnSubmit(_obj);
            Upate(_obj);
        }

        public static void Upate(Term _obj)
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void XoaHetAnhTheoMaSP(int productID)
        {
            BNBDataContext.Instance.SanPham_HinhAnhs.DeleteAllOnSubmit(
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(p => p.ProductID.Equals(productID)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static SanPham_HinhAnh getDefaultImagesByProductID(int productID)
        {
            return
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(
                    p =>
                    p.IsDelete.Equals(false) && p.ProductID.Equals(productID)
                    && p.ImageUrl == @"\ProductImages\logobnb.jpg").Single();
        }

        //Get Images by Id
        public static IQueryable<SanPham_HinhAnh> getImagesByProductIdWithoutDefault(int productID)
        {
            return
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(
                    p =>
                    p.IsDelete.Equals(false) && p.ProductID.Equals(productID)
                    && p.ImageUrl != @"\ProductImages\logobnb.jpg");
        }

        //End Get Images by Id

        //Get Images by Url
        public static SanPham_HinhAnh getImagesByUrl(string imageUrl)
        {
            return
                BNBDataContext.Instance.SanPham_HinhAnhs.Where(
                    p => p.IsDelete.Equals(false) && p.ImageUrl.Equals(imageUrl)).Single();
        }

        #endregion
    }
}