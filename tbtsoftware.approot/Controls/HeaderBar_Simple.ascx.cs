namespace bnb.approot
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class HeaderBar_Simple : UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (this.txt_TimKiem.Text != Common.RequestID("q"))
                {
                    this.Response.Redirect("Default.aspx?q=" + this.txt_TimKiem.Text);
                }
            }
            else
            {
                string a = Common.RequestID("q");
                if (a != "")
                {
                    this.txt_TimKiem.Text = a;
                }
            }
        }

        protected void lbtn_TK_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Default.aspx?q=" + this.txt_TimKiem.Text);
        }

        #endregion
    }
}