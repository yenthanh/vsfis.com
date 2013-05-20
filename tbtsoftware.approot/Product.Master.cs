namespace MinhPham.Web.BepNhaBan
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;
    using MinhPham.Web.BepNhaBan.DAO;

    public partial class Product : MasterPage
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //string pId = Common.RequestID("pId");
            string ID = Common.RequestID("ProductNameSEO");
            this.ltr_BreadCrumb.Text = "";
            if (ID != "")
            {
                this.DuaTenSanPhamVaoBreadCrumb(ID);
            }
            //else if (pId != "")
            //    DuaTenDanhMucVaoBreadCrumb(pId);
        }

        private void DuaTenDanhMucVaoBreadCrumb(string pId)
        {
            Catalog t0 = ProductDAO.getCategoryById(pId)[0];
            this.ltr_BreadCrumb.Text = this.ltr_BreadCrumb.Text.Insert(
                0,
                String.Format("<a class='fss breads' title='{0}' href='trang-chu?pId={1}'> > {0}</a>", t0.Name, t0.ID));
            if (t0.ParentID != "danh-muc-goc")
            {
                this.DuaTenDanhMucVaoBreadCrumb(t0.ParentID);
            }
            else
            {
                this.ltr_BreadCrumb.Text = this.ltr_BreadCrumb.Text.Insert(
                    0, "<a class='fss breads' title='Trang chủ' href='trang-chu'>Trang chủ</a>");
            }
        }

        private void DuaTenSanPhamVaoBreadCrumb(string ID)
        {
            var t0 = ProductDAO.SanPhamByNameSEO(ID);
            this.ltr_BreadCrumb.Text = this.ltr_BreadCrumb.Text.Insert(
                0, String.Format("<span class='fsslast'> > {0}</span>", t0.Name));
            this.DuaTenDanhMucVaoBreadCrumb(t0.CateID);
        }

        #endregion
    }
}