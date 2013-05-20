namespace MinhPham.Web.BepNhaBan.DAO
{
    using System.Configuration;

    public static class DBConnect
    {
        #region Public Methods and Operators

        public static string GetConnectionString()
        {
            string connectionString = @"Data Source=.;Initial Catalog=bepnhaban;user id=bnb;pwd=13091989;";
            if (ConfigurationManager.ConnectionStrings["strConnectionSQL"] != null)
            {
                connectionString = ConfigurationManager.ConnectionStrings["strConnectionSQL"].ToString();
            }
            return connectionString;
        }

        #endregion
    }

    public partial class BNBDataContext
    {
        #region Static Fields

        private static readonly BNBDataContext _instance = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        #region Public Properties

        public static BNBDataContext Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion
    }
}