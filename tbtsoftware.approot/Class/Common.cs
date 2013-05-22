using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace MinhPham.Web.BepNhaBan.Class
{
    public class Common
    {
        #region Fields

        private string str = string.Empty;

        #endregion

        #region Public Properties

        public string GetConnectString
        {
            get { return new DBHelper().strConn_; }
        }

        #endregion

        #region Public Methods and Operators

        public static string ConvertToUnSign(string text)
        {
            for (int i = 0x20; i < 0x30; i++)
            {
                text = text.Replace(((char) i).ToString(), " ");
            }
            text = text.Replace(".", "-");
            text = text.Replace(" ", "-");
            text = text.Replace(",", "-");
            text = text.Replace(";", "-");
            text = text.Replace(":", "-");
            var regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string input = text.Normalize(NormalizationForm.FormD);
            return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
        }

        public static string RequestID(string pStrQuery)
        {
            if (HttpContext.Current.Request.QueryString[pStrQuery] != null)
            {
                return HttpContext.Current.Request.QueryString[pStrQuery];
            }
            return "";
        }
        public string ConvertDateTime(string DT)
        {
            return DateTime.Parse(DT).ToString("dd'/'MM'/'yyyy HH':' mm");
        }

        public string ConvertDateTimeEN(string DT)
        {
            return DateTime.Parse(DT).ToString("MM'/'dd'/'yyyy HH':' mm");
        }

        public string ConvertDateTimeVN(string DT)
        {
            return DateTime.Parse(DT).ToString("'Ng\x00e0y' dd 'th\x00e1ng' MM 'năm' yyyy");
        }

        public string ConvertShortDateTime(string DT)
        {
            return DateTime.Parse(DT).ToString("dd '-' MM '-' yyyy");
        }

        public int Counter()
        {
            int num = 0;
            var helper = new DBHelper();
            var connection = new SqlConnection(helper.strConn_);
            connection.Open();
            try
            {
                SqlDataReader reader = new SqlCommand("select Counter from TB_Counter", connection).ExecuteReader();
                if (reader.Read())
                {
                    num = int.Parse(reader["Counter"].ToString());
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return num;
        }

        public string EncodePassword(string strPassword, string strFormat)
        {
            if (strFormat == "")
            {
                strFormat = "MD5";
            }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, strFormat);
        }

        public string FixLength(string strTemp, int i_Length)
        {
            if (strTemp.Length <= 0)
            {
                return "";
            }
            var regex = new Regex(@"<([^\s>]+)*[^>]*>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(strTemp))
            {
                foreach (Match match in regex.Matches(strTemp))
                {
                    strTemp = strTemp.Replace(match.Value, "");
                }
                strTemp = strTemp.Replace("  ", " ");
                strTemp = strTemp.Replace(@"\r\n", "");
            }
            if (strTemp.Length > i_Length)
            {
                string str = strTemp.Substring(0, i_Length);
                strTemp = strTemp.Substring(i_Length);
                strTemp = String.Format(
                    "{0}{1}...",
                    str,
                    strTemp.IndexOf(" ", StringComparison.Ordinal) >= 0
                        ? strTemp.Substring(0, strTemp.IndexOf(" ", StringComparison.Ordinal))
                        : strTemp);
            }
            return strTemp;
        }

        public string FormatDateTimeEN(string datetime)
        {
            return DateTime.Parse(datetime).ToString("MM'/'dd'/'yyyy");
        }

        public string FormatDateTimeVN(string datetime)
        {
            return DateTime.Parse(datetime).ToString("dd'/'MM'/'yyyy");
        }

        public string GetContentBrief(string strTemp)
        {
            if (strTemp.Length <= 0)
            {
                return "";
            }
            var regex = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(strTemp))
            {
                foreach (Match match in regex.Matches(strTemp))
                {
                    strTemp = strTemp.Replace(match.Value, "");
                }
                strTemp = strTemp.Replace("  ", " ");
                strTemp = strTemp.Replace(@"\r\n", "");
            }
            return strTemp;
        }

        public string GetHTMLProperties(string key, string tagname, string input)
        {
            return GetHTMLProperties(key, tagname, input, 0);
        }

        public string GetHTMLProperties(string key, string tagname, string input, int index)
        {
            string str = GetHTMLTags(tagname, input)[index];
            foreach (string str2 in str.Split(new[] {' '}))
            {
                if (str2.Contains(key + "="))
                {
                    return
                        str2.Split(new[] {'='})[1].Replace(@"\", string.Empty)
                                                  .Replace("\"", string.Empty)
                                                  .Replace("'", string.Empty);
                }
            }
            return string.Empty;
        }

        public string GetHTMLPropertiesInInput(string key, string input)
        {
            return GetHTMLProperties(key, "input", input);
        }

        public string[] GetHTMLTags(string tagname, string input)
        {
            string[] strArray2;
            var regex = new Regex(string.Format("<{0}*[^<>]*>", tagname.ToLower()), RegexOptions.IgnoreCase);
            var strArray = new string[regex.Matches(input).Count];
            int index = 0;
            foreach (Match match in regex.Matches(input))
            {
                strArray[index] = match.Value;
                index++;
            }
            strArray2 = strArray;
            return strArray2;
        }

        public string GetImageBrief(string strSource)
        {
            try
            {
                var regex = new Regex("<img[\\w\\W]*?src=[\"|']([^\"]+?)[\"|']", RegexOptions.IgnoreCase);
                if (regex.IsMatch(strSource))
                {
                    var regex2 = new Regex(@"<img[\w\W]*?src=", RegexOptions.IgnoreCase);
                    return regex2.Replace(regex.Matches(strSource)[0].Value, "").Trim(new[] {'"', '\''});
                }
                if (GetHTMLPropertiesInInput("type", strSource).ToLower() == "image")
                {
                    return GetHTMLPropertiesInInput("src", strSource);
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetImagePathFCK(string strSource)
        {
            try
            {
                var regex = new Regex("<img[\\w\\W]*?src=[\"|']([^\"]+?)[\"|']", RegexOptions.IgnoreCase);
                if (regex.IsMatch(strSource))
                {
                    var regex2 = new Regex(@"<img[\w\W]*?src=", RegexOptions.IgnoreCase);
                    return regex2.Replace(regex.Matches(strSource)[0].Value, "").Trim(new[] {'"', '\''});
                }
                if (GetHTMLPropertiesInInput("type", strSource).ToLower() == "image")
                {
                    return GetHTMLPropertiesInInput("src", strSource);
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetKeyTitle(int page_id)
        {
            var builder = new StringBuilder();
            string queryString =
                String.Format(
                    "SELECT title FROM kd_search_contents_page WHERE page_id={0} AND active=1 ORDER BY create_date DESC",
                    page_id);
            SqlDataReader reader = new DBHelper().ExecuteReader(queryString);
            try
            {
                while (reader.Read())
                {
                    builder.Append(reader["title"]);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            return builder.ToString();
        }

        public string GetKeywords(int id_meta, int page_id)
        {
            var builder = new StringBuilder();
            string queryString =
                String.Format(
                    "SELECT title, key_descriptions, key_keywords FROM kd_search_contents_page WHERE page_id={0} AND active=1 ORDER BY create_date DESC",
                    page_id);
            SqlDataReader reader = new DBHelper().ExecuteReader(queryString);
            try
            {
                while (reader.Read())
                {
                    if (id_meta == 1)
                    {
                        builder.Append(reader["key_descriptions"]);
                    }
                    else if (id_meta == 2)
                    {
                        builder.Append(reader["key_keywords"]);
                    }
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            return builder.ToString();
        }

        public string GetPathToDeleteFileBanner()
        {
            return ConfigurationManager.AppSettings["Banner_Delete_File"];
        }

        public string GetPathToDeleteFileLogo()
        {
            return ConfigurationManager.AppSettings["Logo_Delete_File"];
        }

        public string GetPathToDeleteProductFile()
        {
            return ConfigurationManager.AppSettings["PathDeleteProductFiles"];
        }

        public string GetPathToDeleteProductImage()
        {
            return ConfigurationManager.AppSettings["PathDeleteProductImages"];
        }

        public string GetPathToProductFile()
        {
            return ConfigurationManager.AppSettings["PathProductFiles"];
        }

        public string GetPathToUploadBanner()
        {
            return ConfigurationManager.AppSettings["BannerUpload"];
        }

        public string GetPathToUploadImage()
        {
            return ConfigurationManager.AppSettings["ImagesUpload"];
        }

        public string GetPathToUploadLogo()
        {
            return ConfigurationManager.AppSettings["LogoUpload"];
        }

        public string GetPathToUploadProductImage()
        {
            return ConfigurationManager.AppSettings["PathProductImages"];
        }

        public string GetPathToUploadVideo()
        {
            return ConfigurationManager.AppSettings["VideoUpload"];
        }

        public string GetValueWebConfig(string Key, bool isMapPath)
        {
            if (isMapPath)
            {
                str = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[Key]);
            }
            else
            {
                str = ConfigurationManager.AppSettings[Key];
            }
            return str;
        }

        public double LamTronTien(double input)
        {
            if ((input - 8)%10 == 0)
            {
                return input;
            }
            double t0 = Math.Floor(input/10)*10 + 8;
            return t0;
        }

        public string Left(string source, int pos)
        {
            string str = "";
            if (pos <= source.Length)
            {
                for (int i = 0; i < pos; i++)
                {
                    str = str + source[i];
                }
            }
            return str;
        }

        public string RemoveHTML(string content)
        {
            var regex = new Regex("</?[a-z][a-z0-9]*[^<>]*>", RegexOptions.IgnoreCase);
            return regex.Replace(content, string.Empty);
        }

        public string RemoveHTMLTag(string tagname, string content)
        {
            var regex = new Regex(string.Format("</?{0}*[^<>]*>", tagname.ToLower()), RegexOptions.IgnoreCase);
            if (regex.IsMatch(content))
            {
                return regex.Replace(content, string.Empty);
            }
            return content;
        }

        public string RemoveImageInBrief(string content)
        {
            content = RemoveHTMLTag("img", content);
            if (content.Contains("input") && content.Contains("type=\"image\""))
            {
                content = RemoveHTMLTag("input", content);
            }
            return content;
        }

        public string RemoveSpeacer(string pStr)
        {
            if (!string.IsNullOrEmpty(pStr) && pStr.Trim().EndsWith(","))
            {
                pStr = pStr.Substring(0, pStr.Length - 2);
            }
            return pStr;
        }

        public string ReplaceTag(string pContent)
        {
            pContent = pContent.Replace("{", "<");
            pContent = pContent.Replace("}", ">");
            return pContent;
        }

        public string RequestForm(string StrForm)
        {
            if (HttpContext.Current.Request.Form[StrForm] != null)
            {
                str = SafeString(HttpContext.Current.Request.Form[StrForm]);
            }
            else
            {
                str = "";
            }
            return str;
        }

        public string Right(string source, int pos)
        {
            var str = "";
            if (pos <= source.Length)
            {
                for (int i = 0; i < pos; i++)
                {
                    str = str + source[(source.Length - pos) + i];
                }
            }
            return str;
        }

        public string SafeString(string str)
        {
            if (str != null)
            {
                var strArray = new[] {"select ", "drop ", ";", "--", "insert ", "delete ", "xp_ ", " or "};
                for (int i = 0; i < strArray.Length; i++)
                {
                    str = str.Replace(strArray[i], string.Empty);
                }
                if (str.IndexOf("'") > -1)
                {
                    str = str.Replace("'", string.Empty);
                }
            }
            return str;
        }

        public string SafeUrl(string strSource)
        {
            return
                strSource.ToLower()
                         .Replace("   ", "-")
                         .Replace("  ", "-")
                         .Replace(" ", "-")
                         .Replace("(", "")
                         .Replace(")", "")
                         .Replace("&", "")
                         .Replace(":", "-")
                         .Replace("/", "-")
                         .Replace(",", "")
                         .Replace("$", "");
        }

        public string ShowNotice(bool pSuccess, string pNotice)
        {
            string css = pSuccess ? "Info" : "Warning";
            return String.Format(
                "<div style='padding-top: 10px;'><div class='Notice-{0}'><span>{1}</span></div></div>", css, pNotice);
        }

        public string UcaseFirst(string pInput)
        {
            return (pInput.Substring(0, 1).ToUpper() + pInput.Substring(1, pInput.Length - 1));
        }

        public string mid(string source, int start, int stop)
        {
            string s = "";
            for (int i = start; i < stop; i++)
            {
                s = s + source[i];
            }
            return s;
        }

        public void wr(string str)
        {
            HttpContext.Current.Response.Write(str + "<br>");
        }

        #endregion

        // Fields

        // Properties
    }
}