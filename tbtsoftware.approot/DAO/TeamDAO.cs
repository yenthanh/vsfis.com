namespace bnb.approot.DAO
{
    using System.Collections.Generic;
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public class TeamDAO
    {
        #region Public Methods and Operators

        public static void Delete(int pID)
        {
            BNBDataContext.Instance.Teams.DeleteOnSubmit(BNBDataContext.Instance.Teams.Single(p => p.ID.Equals(pID)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static Team Get(int pID)
        {
            return BNBDataContext.Instance.Teams.First(p => p.ID.Equals(pID));
        }

        public static List<Team> Get()
        {
            return BNBDataContext.Instance.Teams.ToList();
        }

        public static void Insert(Team pTeam)
        {
            BNBDataContext.Instance.Teams.InsertOnSubmit(pTeam);
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}