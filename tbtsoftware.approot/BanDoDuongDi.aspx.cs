﻿namespace bnb.approot
{
    using System;
    using System.Web.UI;

    using BepNhaBan.System;

    public partial class BanDoDuongDi : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Title = "Bản đồ đường đi - Bếp Nhà Bạn";
                SEO.ThemMetaDescript(
                    this.Page.Header,
                    "Công ty Bếp Nhà Bạn cung cấp những mặt hàng gia dụng chất lượng cao, chính hãng,Tư vấn, thiết kế, thi công tủ bếp chuyên nghiệp, tận tình.");
            }
        }

        #endregion
    }
}