using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class ImagesDAO
    {
        #region Static Fields

        private static readonly BNBDataContext DB = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        #region Public Methods and Operators

        public static Boolean CheckImagesByUrl(string imageUrl)
        {
            if (DB.SanPham_HinhAnhs.Any(p => p.ImageUrl.Equals(imageUrl)))
            {
                return true;
            }
            return false;
        }

        public static void DeleteImagesByID(int ID)
        {
            DB.SanPham_HinhAnhs.DeleteOnSubmit(DB.SanPham_HinhAnhs.Single(p => p.ProductID.Equals(ID)));
            DB.SubmitChanges();
        }

        public static void DeleteImagesByUrl(string imageUrl)
        {
            DB.SanPham_HinhAnhs.DeleteOnSubmit(DB.SanPham_HinhAnhs.Single(p => p.ImageUrl.Equals(imageUrl)));
            DB.SubmitChanges();
        }

        public static IQueryable<SanPham_HinhAnh> GetImagesByID(int ID)
        {
            return DB.SanPham_HinhAnhs.Where(p => p.IsDelete.Equals(false) && p.ProductID.Equals(ID));
        }

        public static IQueryable<SanPham_HinhAnh> GetImagesByImageID(string imageID)
        {
            return DB.SanPham_HinhAnhs.Where(p => p.IsDelete.Equals(false) && p.ImageID.Equals(imageID));
        }

        public static void InsertImages(SanPham_HinhAnh _obj)
        {
            DB.SanPham_HinhAnhs.InsertOnSubmit(_obj);
            DB.SubmitChanges();
        }

        //End Insert Images

        //Update Images
        public static void UpateImages(SanPham_HinhAnh _obj)
        {
            DB.SubmitChanges();
        }

        public static void XoaHetAnhTheoMaSP(int ID)
        {
            DB.SanPham_HinhAnhs.DeleteAllOnSubmit(DB.SanPham_HinhAnhs.Where(p => p.ProductID.Equals(ID)));
            DB.SubmitChanges();
        }

        public static List<SanPham_HinhAnh> getAllImages()
        {
            return DB.SanPham_HinhAnhs.OrderByDescending(p => p.IsDelete.Equals(false)).ToList();
        }

        public static SanPham_HinhAnh getDefaultImagesByID(int ID)
        {
            return
                DB.SanPham_HinhAnhs.Single(
                    p =>
                    p.IsDelete.Equals(false) && p.ProductID.Equals(ID) && p.ImageUrl == @"\ProductImages\logobnb.jpg");
        }

        public static IQueryable<SanPham_HinhAnh> getImagesByIDWithoutDefault(int ID)
        {
            return
                DB.SanPham_HinhAnhs.Where(
                    p =>
                    p.IsDelete.Equals(false) && p.ProductID.Equals(ID) && p.ImageUrl != @"\ProductImages\logobnb.jpg");
        }

        public static SanPham_HinhAnh getImagesByUrl(string imageUrl)
        {
            return DB.SanPham_HinhAnhs.Single(p => p.IsDelete.Equals(false) && p.ImageUrl.Equals(imageUrl));
        }

        #endregion
    }
}