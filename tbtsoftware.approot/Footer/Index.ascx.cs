using System;
using System.Web;
using System.Web.UI;

namespace MinhPham.Web.BepNhaBan.Footer
{
    public partial class Index : UserControl
    {
        #region Methods

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
                        Label1.Text = "";
                        Label2.Text = "V-SFIS .,Ltd";
                        Label3.Text = "Head Office";
                        Label4.Text = "Address: 24 Nguyen Canh Di-Dai Kim-Hoang Mai-Ha Noi";
                        Label5.Text = "Tel: 084-4-66860729";
                        Label6.Text = "Office";
                        Label7.Text = "Address: 18/62-Nguyen Viet Xuan-Thanh Xuan-Ha Noi";
                        Label8.Text = "Tel: 084-4-35189056";
                        break;
                    case "2":
                        Label1.Text = "";
                        Label2.Text = "V-SFIS .,Ltd";
                        Label3.Text = "本社";
                        Label4.Text = "アドレス: 24 Nguyen Canh Di-Dai Kim-Hoang Mai-Ha Noi";
                        Label5.Text = "電話: 084-4-66860729";
                        Label6.Text = "オフィス";
                        Label7.Text = "アドレス: 18/62-Nguyen Viet Xuan-Thanh Xuan-Ha Noi";
                        Label8.Text = "電話: 084-4-35189056";
                        break;
                    case "3":
                        Label1.Text = "Công ty TNHH CN & TM";
                        Label2.Text = "V-SFIS";
                        Label3.Text = " Trụ sở chính";
                        Label4.Text = "Địa chỉ: 24 Nguyễn Cảnh Dị-Đại Kim-Hoàng Mai-Hà Nội";
                        Label5.Text = " Điện thoại: 04-66860729";
                        Label6.Text = " Văn phòng công ty";
                        Label7.Text = " Địa chỉ: 18 ngõ 62-Nguyễn Viết Xuân-Thanh Xuân-Hà Nội";
                        Label8.Text = "Điện thoại: 04-35189056";
                        break;
                }
            }
        }

        #endregion
    }
}