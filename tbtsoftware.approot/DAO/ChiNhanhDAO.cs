namespace bnb.approot.DAO
{
    using System.Collections.Generic;
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public class ChiNhanhDAO
    {
        #region Static Fields

        private static readonly BNBDataContext DB = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        #region Public Methods and Operators

        public static void Delete(int Id)
        {
            DB.Branches.DeleteOnSubmit(DB.Branches.Single(p => p.ID.Equals(Id)));
            DB.SubmitChanges();
        }

        public static Branch Get(int Id)
        {
            return DB.Branches.First(p => p.ID.Equals(Id));
        }

        public static List<Branch> Get()
        {
            return DB.Branches.ToList();
        }

        public static void Insert(Branch _obj)
        {
            DB.Branches.InsertOnSubmit(_obj);
            DB.SubmitChanges();
        }

        public static void Update()
        {
            DB.SubmitChanges();
        }

        #endregion
    }
}