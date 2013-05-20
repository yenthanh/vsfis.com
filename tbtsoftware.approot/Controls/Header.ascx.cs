using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace MinhPham.Web.BepNhaBan
{
    public partial class Header : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string l;
                if (Request.Cookies["l"] != null)
                {
                    l = Request.Cookies["l"].Value;
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "1"));
                    l = "1";
                }
                switch (l)
                {
                    case "1":
                        Label1.Text = "Home";
                        Label2.Text = "Corporate";
                        Label3.Text = "Services";
                        Label4.Text = "Contact Us";
                        Label5.Text = "Recruitment";
                        break;
                    case "2":
                        Label1.Text = "ホーム";
                        Label2.Text = "企業の";
                        Label3.Text = "サービス";
                        Label4.Text = "お問い合わせ";
                        Label5.Text = "募集";
                        break;
                    case "3":
                        Label1.Text = "Trang chủ";
                        Label2.Text = "Công ty";
                        Label3.Text = "Dịch vụ";
                        Label4.Text = "Liên hệ";
                        Label5.Text = "Tuyển dụng";
                        break;
                }
            }
        }

        protected void lbtvn_Click(object sender, System.EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "3"));
            Response.Redirect(Request.Url.ToString());
        }

        protected void lbtjp_Click(object sender, System.EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "2"));
            Response.Redirect(Request.Url.ToString());
        }


        protected void lbten_Click(object sender, System.EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "1"));
            Response.Redirect(Request.Url.ToString());
        }
    }
}