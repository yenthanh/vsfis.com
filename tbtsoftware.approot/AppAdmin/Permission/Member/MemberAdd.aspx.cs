﻿namespace MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class MemberAdd : Page
    {
        #region Fields

        private readonly Common objComm = new Common();

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Cookies["AdminID"] == null)
            {
                this.objComm.wr(
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=them-thanh-vien';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Thêm thành viên - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}