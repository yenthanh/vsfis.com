using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.DAO;

namespace MinhPham.Web.BepNhaBan.Services
{
    public partial class Navigation : UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                int l;
                if (Request.Cookies["l"] != null)
                {
                    l = int.Parse(Request.Cookies["l"].Value);
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("l", "1"));
                    l = 1;
                }
                switch (l)
                {
                    case 1:
                        Label1.Text = "Services";
                        break;
                    case 2:
                        Label1.Text = "サービス";
                        break;
                    case 3:
                        Label1.Text = "Dịch vụ";
                        break;
                }

                var list = new List<ServiceModel>();
                var x = ServiceDAO.Get();
                foreach (var service in x)
                {
                    list.Add(new ServiceModel()
                        {
                            Name = service.Name,
                            LocaleValue = LocalizedPropertyDAO.Find(service.Id, l,"Service", "Title").LocaleValue
                        });
                }
                repeater.DataSource = list;
                repeater.DataBind();
            }
        }

        #endregion
    }

    public class ServiceModel
    {
        public string Name { get; set; }
        public string LocaleValue { get; set; }

    }
}