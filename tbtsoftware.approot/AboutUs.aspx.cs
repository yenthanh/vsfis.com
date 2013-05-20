using System;
using System.Web.UI;
using BepNhaBan.System;

namespace MinhPham.Web.BepNhaBan
{
    public partial class AboutUs : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = "Về chúng tôi - Bếp Nhà Bạn";
                SEO.ThemMetaDescript(
                    Page.Header,
                    "Công ty Bếp Nhà Bạn cung cấp những mặt hàng gia dụng chất lượng cao, chính hãng,Tư vấn, thiết kế, thi công tủ bếp chuyên nghiệp, tận tình.");
            }
        }

        #endregion
    }
}