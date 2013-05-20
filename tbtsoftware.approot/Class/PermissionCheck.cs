using System.Data.SqlClient;
using System.Web.UI;

namespace MinhPham.Web.BepNhaBan.Class
{
    public class PermissionCheck : Page
    {
        #region Public Methods and Operators

        public string LayQuyen(string functionCodeKey)
        {
            return (string) GetGlobalResourceObject("Permission", functionCodeKey);
        }

        public bool Permission(string strAllowFunctions)
        {
            bool flag = true;
            //if ((Request.Cookies["admin_User_Functions"] == null)
            //    || (Request.Cookies["admin_User_Functions"].ToString() == ""))
            //{
            //    return false;
            //}
            //string[] strArray = strAllowFunctions.Split(new[] {','});
            //string[] strArray2 = Request.Cookies["admin_User_Functions"].ToString().Split(new[] { ',' });
            //foreach (string str in strArray)
            //{
            //    foreach (string str2 in strArray2)
            //    {
            //        if (str == str2)
            //        {
            //            flag = true;
            //            break;
            //        }
            //        flag = false;
            //    }
            //}
            return flag;
        }

        #endregion
    }

    public class tbtsoftwareLogin
    {
        #region Fields

        private readonly DBHelper _objDb = new DBHelper();

        private SqlCommand _objCmd;

        private string _objStr = string.Empty;

        #endregion

        #region Public Methods and Operators

        public int GetIntValue(string pFieldName, string pTableName, string pTblName, string pCondition)
        {
            int num;
            _objStr = "SELECT " + pFieldName + " FROM " + pTableName + ", " + pTblName + " WHERE " + pCondition;
            _objCmd = new SqlCommand(_objStr, _objDb.SqlConn());
            _objCmd.Connection.Close();
            _objCmd.Connection.Open();
            var reader = _objCmd.ExecuteReader();
            if (reader.Read())
            {
                num = reader.GetInt32(0);
                _objCmd.Connection.Close();
                _objCmd.Dispose();
                return num;
            }
            num = -1;
            _objCmd.Connection.Close();
            _objCmd.Dispose();
            return num;
        }

        public bool IsExits(string pFieldName, string pTableName, string pTblName, string pCondition)
        {
            return (GetIntValue("Count(" + pFieldName + ") As Total", pTableName, pTblName, pCondition) > 0);
        }

        #endregion
    }
}