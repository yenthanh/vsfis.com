namespace bnb.approot.AppAdmin
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    public partial class SignOut : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Session.Abandon();
                FormsAuthentication.SignOut();
                string ReturnUrl = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                this.Response.Write("<script language='javascript'>location.href='/AppAdmin/Login.aspx';</script>");
            }
        }

        #endregion
    }
}