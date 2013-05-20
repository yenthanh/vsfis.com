namespace MinhPham.Web.BepNhaBan
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    public partial class Simple : MasterPage

    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Common.RequestID("p_ID");

            //this.ltr_BreadCrumb.Text = "";
            //if (id != "")
            //{
            //    this.DuaTenDanhMucVaoBreadCrumb(id);
            //}
            //else
            //{
            //    this.ltr_BreadCrumb.Text = "<span style='margin-left:15px'></span>";
            //}
        }

        private void DuaTenDanhMucVaoBreadCrumb(string p_ID)
        {
            //Catalog t0 = ProductDAO.getCategoryById(p_ID)[0];
            //this.ltr_BreadCrumb.Text = this.ltr_BreadCrumb.Text.Insert(
            //    0,
            //    String.Format("<a class='fss breads' title='{0}' href='Default.aspx?p_ID={1}'> > {0}</a>", t0.Name, t0.ID));
            //if (t0.ParentID != "danh-muc-goc")
            //{
            //    this.DuaTenDanhMucVaoBreadCrumb(t0.ParentID);
            //}
            //else
            //{
            //    this.ltr_BreadCrumb.Text = this.ltr_BreadCrumb.Text.Insert(
            //        0, "<a class='fss breads' title='Trang chủ' href='Default.aspx'>Trang chủ</a>");
            //}
        }

        #endregion
    }
}