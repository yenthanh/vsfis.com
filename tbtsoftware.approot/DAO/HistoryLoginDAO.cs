namespace bnb.approot
{
    using System.Collections.Generic;
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public static class HistoryLoginDAO
    {
        #region Static Fields

        private static readonly BNBDataContext DB = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        //Delete record of table

        #region Public Methods and Operators

        public static void Delete(int id)
        {
            DB.TBT_AdminHistoryLogins.DeleteOnSubmit(DB.TBT_AdminHistoryLogins.Single(p => p.Id.Equals(id)));
            DB.SubmitChanges();
        }

        public static List<TBT_AdminHistoryLogin> getAllHistoryLogin()
        {
            return DB.TBT_AdminHistoryLogins.OrderByDescending(p => p.DateTime).ToList();
        }

        #endregion
    }
}