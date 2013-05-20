using System.Web;
using MinhPham.Web.BepNhaBan.DAO;
using System;
using System.Web.UI;
using MinhPham.Web.BepNhaBan.Class;

namespace MinhPham.Web.BepNhaBan
{
    public partial class Default : Page
    {
        #region Fields

        public Common objComm = new Common();

        #endregion

        private const string NivoSliderControl = "~/NivoSlider/Default.ascx";

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
                string cate = Common.RequestID("cate");
                if (Common.RequestID("id") != "")
                {
                    var id = Common.RequestID("id");
                    switch (cate)
                    {
                        case "c":
                            var x = ContentDAO.Find(id);
                            var y = LocalizedPropertyDAO.Find(x.Id, l,"Content", "Body");
                            var t = LocalizedPropertyDAO.Find(x.Id, l, "Content", "Title").LocaleValue;
                            Page.Title = t + Resources.language.title_separator + Resources.language.website_name;
                            Literal1.Text = y.LocaleValue;
                            break;
                        case "s":
                             var z = ServiceDAO.Find(id);
                              Literal1.Text = LocalizedPropertyDAO.Find(z.Id, l,"Service", "Body") == null ? "":LocalizedPropertyDAO.Find(z.Id, l, "Service", "Body").LocaleValue;
                              var title = LocalizedPropertyDAO.Find(z.Id, l, "Service", "Title").LocaleValue;
                              Page.Title = title + Resources.language.title_separator + Resources.language.website_name;
                            break;
                    }
                }
                else
                {

                    var z = ContentDAO.Find("default");
                    Literal1.Text = LocalizedPropertyDAO.Find(z.Id, l, "Content", "Body") == null ? "" : LocalizedPropertyDAO.Find(z.Id, l, "Content", "Body").LocaleValue;
                    var t = LocalizedPropertyDAO.Find(z.Id, l, "Content", "Title").LocaleValue;
                    Page.Title = t + Resources.language.title_separator + Resources.language.website_name;
                    content.Controls.AddAt(0,LoadControl(NivoSliderControl));
                }

            }

        }

        #endregion
    }
}