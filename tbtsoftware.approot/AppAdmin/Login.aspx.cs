using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;
using Resources;

namespace MinhPham.Web.BepNhaBan.AppAdmin
{
    public partial class Login : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        private readonly DBHelper objDB = new DBHelper();

        private readonly tbtsoftwareLogin objLogin = new tbtsoftwareLogin();

        private int isLoginOK;

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //string xx= objComm.EncodePassword("123456", "");
            if (!IsPostBack)
            {
                Title = "Đăng nhập" + language.title_separator + language.website_name;
            }
        }

        protected void bntLogin_Click(object sender, EventArgs e)
        {
            AdminLogin();
        }

        private void AdminLogin()
        {
            if (objLogin.IsExits(
                "UserName",
                "Users",
                "Roles",
                String.Format(
                    "UserName='{0}' AND Password='{1}' AND Users.Active=1 And Users.Group_ID=Roles.Group_ID ANd Roles.Active=1",
                    objComm.SafeString(txtUserName.Text.ToLower()),
                    objComm.EncodePassword(objComm.SafeString(txtPassword.Text), ""))))
            {
                isLoginOK = 1;
                //Ghi log đăng nhập
                WriteLogLogin(isLoginOK);
                string fullName = "";
                string strSqlFunctions =
                    String.Format(
                        "SELECT TBT_AdminFunction.FunctionCode,Users.FullName FROM (TBT_AdminFunction INNER JOIN TBT_AdminMemberGroupFunction ON TBT_AdminMemberGroupFunction.Function_ID = TBT_AdminFunction.Function_ID ) INNER JOIN Users ON TBT_AdminMemberGroupFunction.Group_ID = Users.Group_ID WHERE Users.UserName = '{0}' AND Users.Active = 1",
                        objComm.SafeString(txtUserName.Text));
                var Comm = new SqlCommand(strSqlFunctions, objDB.SqlConn());
                Comm.Connection.Open();
                SqlDataReader myDrd = Comm.ExecuteReader();
                while (myDrd.Read())
                {
                    if (Request.Cookies["admin_User_Functions"] != null)
                    {
                        HttpContext.Current.Response.Cookies.Add(new HttpCookie("admin_User_Functions", String.Format(
                            "{0},{1}", Request.Cookies["admin_User_Functions"].Value, myDrd["FunctionCode"]))); 
                    }
                    else
                    {
                        HttpContext.Current.Response.Cookies.Add(new HttpCookie("admin_User_Functions",  myDrd["FunctionCode"].ToString())); 
                    }
                    fullName = myDrd["FullName"].ToString();
                }
                Comm.Connection.Close();
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("AdminID", fullName)); 
                if (Common.RequestID("ReturnUrl") != "")
                {
                    var httpCookie = Request.Cookies["AdminID"];
                    if (httpCookie != null)
                        FormsAuthentication.RedirectFromLoginPage(httpCookie.ToString(), false);
                }
                else
                {
                    var httpCookie = Request.Cookies["AdminID"];
                    if (httpCookie != null)
                        FormsAuthentication.SetAuthCookie(httpCookie.ToString(), false);
                    Response.Redirect("/AppAdmin/Default.aspx");
                }
            }
            else
            {
                isLoginOK = 0;
                WriteLogLogin(isLoginOK);
            }
        }

        private void WriteLogLogin(int pLoginSuccess)
        {
            DateTime Dt = DateTime.Now;
            string IP = Context.Request.ServerVariables["REMOTE_ADDR"];
            string strSQL = "Insert into TBT_AdminHistoryLogin (DateTime, UserName, Ip, Status, TypeLog)";
            strSQL += String.Format(
                " Values('{0}',N'{1}','{2}',{3}, 0)",
                Dt.ToString(CultureInfo.CreateSpecificCulture("en-US")),
                objComm.SafeString(txtUserName.Text.ToLower()),
                IP,
                pLoginSuccess);
            var myComm = new SqlCommand(strSQL, objDB.SqlConn());
            try
            {
                myComm.Connection.Open();
                myComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myComm.Connection.Close();
                myComm.Connection.Dispose();
            }
        }

        #endregion
    }
}