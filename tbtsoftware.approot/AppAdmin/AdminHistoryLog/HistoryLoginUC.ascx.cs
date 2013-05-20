namespace bnb.approot.AppAdmin.AdminHistoryLog
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class HistoryLoginUC : UserControl
    {
        #region Fields

        public Common objComm = new Common();

        #endregion

        #region Methods

        protected void GrvLogLogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GrvLogLogịn.PageIndex = e.NewPageIndex;
            this.ListLogLogin();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListLogLogin();
        }

        protected void bntDel_Click(object sender, EventArgs e)
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intID = int.Parse(this.objComm.SafeString(item.Substring(9, item.Length - 9)));
                    try
                    {
                        HistoryLoginDAO.Delete(intID);
                        this.objComm.wr(
                            "<script language='javascript'>alert('Xóa thành công!');location.href='/AppAdmin/AdminHistoryLog/HistoryLogin.aspx';</script>");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void ListLogLogin()
        {
            this.GrvLogLogịn.DataSource = HistoryLoginDAO.getAllHistoryLogin();
            this.GrvLogLogịn.DataBind();
        }

        #endregion
    }
}