﻿namespace bnb.approot.AppAdmin.NhomThanhVien
{
    using System;
    using System.Web.UI;

    using MinhPham.Web.BepNhaBan.Class;

    public partial class MemberGroupList : Page
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
                    "<script language='javascript'>location.href='/AppAdmin/Login.aspx?ReturnUrl=quan-ly-nhom-thanh-vien';</script>");
            }
            if (!this.IsPostBack)
            {
                this.Title = "Danh sách nhóm thành viên - Bếp Nhà Bạn";
            }
        }

        #endregion
    }
}