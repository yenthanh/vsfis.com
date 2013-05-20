namespace bnb.approot.DAO
{
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public class BrandDAO
    {
        #region Public Methods and Operators

        public static void Delete(int Id)
        {
            BNBDataContext.Instance.Brands.DeleteOnSubmit(BNBDataContext.Instance.Brands.Single(p => p.ID.Equals(Id)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static IQueryable<Brand> Get()
        {
            return BNBDataContext.Instance.Brands.OrderBy(p => p.Name);
        }

        public static Brand Get(int Id)
        {
            return BNBDataContext.Instance.Brands.First(p => p.ID.Equals(Id));
        }

        public static void Insert(Brand _obj)
        {
            BNBDataContext.Instance.Brands.InsertOnSubmit(_obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}