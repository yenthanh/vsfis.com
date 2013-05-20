namespace MinhPham.Web.BepNhaBan.Class
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;

    public class DBHelper : Common
    {
        // Fields

        #region Fields

        private string strConn = ConfigurationManager.ConnectionStrings["strConnectionSQL"].ConnectionString;

        #endregion

        #region Public Properties

        public string strConn_
        {
            get
            {
                return this.strConn;
            }
            set
            {
                this.strConn = value;
            }
        }

        #endregion

        // Methods

        #region Public Methods and Operators

        public string ConvertHTML(string strConvert)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(strConvert))
            {
                str = strConvert.Replace(">", "&gt;");
                str = strConvert.Replace("<", "&lt;");
                str = strConvert.Replace("&", "&amp;");
                str = strConvert.Replace("'", "&#039;");
            }
            return str;
        }

        public void CreateConnection()
        {
            new SqlConnection(this.strConn).Open();
        }

        public SqlDataReader CreateDataReader_StoreProcedure(
            string StoreProcedure, string Parameters, string VariableParamName)
        {
            return this.ExecuteReader(String.Format("EXEC {0} {1}={2}", StoreProcedure, VariableParamName, Parameters));
        }

        public DataTable CreateDataTable(string strSQL)
        {
            var adapter = new SqlDataAdapter(strSQL, this.SqlConn());
            this.SqlConn().Open();
            var dataTable = new DataTable();
            
                adapter.Fill(dataTable);
            
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            return dataTable;
        }

        public DataTable CreateDataTableSearchNews_StorProcedure(
            string StoreProcedure,
            string strSearch,
            int LangId,
            int intCatID,
            int intSearchFollow,
            string strFromDate,
            string strEndDate,
            int statusId)
        {
            var dataTable = new DataTable();
            object obj2 = String.Format("Exec {0} @Search=N'{1}', ", StoreProcedure, strSearch);
            obj2 = string.Concat(new[] { obj2, "@Language_ID=", LangId, ", " });
            obj2 = String.Format(
                "{0}@EndDate='{1}', ",
                (string.Concat(new[] { obj2, "@Cat_Id=", intCatID, ", " }) + "@FromDate='" + strFromDate + "', "),
                strEndDate);
            string selectCommandText = String.Format(
                "{0}@SearchFollow={1}", string.Concat(new[] { obj2, "@status=", statusId, ", " }), intSearchFollow);
            try
            {
                var adapter = new SqlDataAdapter(selectCommandText, this.SqlConn());
                this.SqlConn().Open();
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataTable;
        }

        public DataTable CreateDataTableSearch_StorProcedure(
            string StoreProcedure, string strSearch, int LangId, int intCatID, int status)
        {
            var dataTable = new DataTable();
            object obj2 = String.Format("Exec {0} @strSearch=N'{1}' , ", StoreProcedure, strSearch);
            obj2 = string.Concat(new[] { obj2, "@Language_ID=", LangId, ", " });
            string selectCommandText = String.Format(
                "{0}@status={1}", string.Concat(new[] { obj2, "@Cat_Id=", intCatID, ", " }), status);
            try
            {
                var adapter = new SqlDataAdapter(selectCommandText, this.SqlConn());
                this.SqlConn().Open();
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataTable;
        }

        public DataTable CreateDataTable_StorProcedure(string StoreProcedure)
        {
            var dataTable = new DataTable();
            var adapter = new SqlDataAdapter(StoreProcedure, this.SqlConn());
            try
            {
                this.SqlConn().Open();
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataTable;
        }

        public DataTable CreateDataTable_StorProcedure(string StoreProcedure, string Para)
        {
            var dataTable = new DataTable();
            var adapter = new SqlDataAdapter(String.Format("EXEC {0} {1}", StoreProcedure, Para), this.SqlConn());
            try
            {
                this.SqlConn().Open();
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataTable;
        }

        public string Create_Cat_Tree(int Cat_Id, DataTable dt, string varSpace)
        {
            varSpace = varSpace + "&nbsp;&nbsp;&nbsp;&nbsp";
            var builder = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int parent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (parent == Cat_Id)
                {
                    int num3 = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string catName = dt.Rows[i]["CatName"].ToString();
                    var active = (bool)dt.Rows[i]["Active"];
                    builder.Append(this.rwProductCat(num3, parent, catName, active, varSpace));
                    if (this.FindProductCatChildNode(num3, dt))
                    {
                        builder.Append(this.Create_Cat_Tree(num3, dt, varSpace));
                    }
                }
            }
            return builder.ToString();
        }

        public string Create_Select_Tree(int Cat_Id, DataTable dt, int Parent_Id, string varSpace)
        {
            varSpace = varSpace + "&nbsp;&nbsp;&nbsp;&nbsp";
            var builder = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == Cat_Id)
                {
                    int num3 = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string str = dt.Rows[i]["CatName"].ToString();
                    string str2 = string.Empty;
                    if (Parent_Id == num3)
                    {
                        str2 = " selected ";
                    }
                    builder.Append(
                        string.Concat(
                            new object[]
                                { "<option value='", num3, "'", str2, ">", varSpace, "-&nbsp;", str, "</option>" }));
                    if (this.FindProductCatChildNode(num3, dt))
                    {
                        builder.Append(this.Create_Select_Tree(num3, dt, Parent_Id, varSpace));
                    }
                }
            }
            return builder.ToString();
        }

        public void Delete_Files(string File_Name)
        {
            File.Delete(File_Name);
        }

        public void Delete_Product_File(int Cat_Id)
        {
            var adapter = new SqlDataAdapter();
            var command = new SqlCommand("Get_Product_Cat_Parent", this.SqlConn())
                              {
                                  CommandType =
                                      CommandType.StoredProcedure
                              };
            command.Parameters.AddWithValue("@Parent", Cat_Id);
            command.Connection.Open();
            adapter.SelectCommand = command;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int num2 = int.Parse(dataTable.Rows[i]["Cat_Id"].ToString());
                if ((bool)dataTable.Rows[i]["IsLeaf"])
                {
                    var command2 = new SqlCommand(
                        "Select ProductFile From TB_Products Where Cat_Id =" + num2, this.SqlConn());
                    command2.Connection.Open();
                    SqlDataReader reader = command2.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        string str2 = reader["ProductFile"].ToString();
                        if ((str2 != string.Empty) && (str2 != null))
                        {
                            string path = HttpContext.Current.Server.MapPath("//") + base.GetPathToDeleteProductFile()
                                          + str2;
                            if (File.Exists(path))
                            {
                                this.Delete_Files(path);
                            }
                        }
                    }
                    reader.Close();
                    command2.Connection.Close();
                }
                else
                {
                    this.Delete_Product_File(num2);
                }
            }
        }

        public void ExcuteNoneQuery(string StoreProcedureName)
        {
            var command = new SqlCommand(StoreProcedureName, this.SqlConn())
                              {
                                  CommandType = CommandType.StoredProcedure
                              };
            command.Connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

        public void ExcuteNoneQuery(
            string StoreProcedureName,
            int Cat_ID,
            int Status_ID,
            int Language_ID,
            string Subject,
            string Brief,
            int Hotnews,
            string Source,
            string Author,
            string Content,
            string RelateNews_Id,
            string strFileVideo,
            string keysearch)
        {
            var command = new SqlCommand(StoreProcedureName, this.SqlConn());
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                command.Parameters.AddWithValue("@Cat_ID", Cat_ID);
                command.Parameters.AddWithValue("@Status_ID", Status_ID);
                command.Parameters.AddWithValue("@Language_ID", Language_ID);
                command.Parameters.AddWithValue("@Subject", Subject);
                command.Parameters.AddWithValue("@Brief", Brief);
                command.Parameters.AddWithValue("@Hotnews", Hotnews);
                command.Parameters.AddWithValue("@Source", Source);
                command.Parameters.AddWithValue("@Author", Author);
                command.Parameters.AddWithValue("@Content", Content);
                command.Parameters.AddWithValue("@RelateNews_Id", RelateNews_Id);
                command.Parameters.AddWithValue("@VideoFile", strFileVideo);
                command.Parameters.AddWithValue("@keysearch", keysearch);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("C\x00f3 lỗi xảy ra: " + exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                command.Connection.Close();
                this.SqlConn().Dispose();
                command.Dispose();
            }
        }

        public DataSet Exec_Store(string ProductName, string strSearch, int intSearch)
        {
            var dataSet = new DataSet();
            try
            {
                new SqlDataAdapter(
                    string.Concat(
                        new object[]
                            {
                                "Exec ", ProductName, " @strSearch = ", base.SafeString(strSearch), ", @intSearch = ",
                                intSearch
                            }),
                    this.SqlConn()).Fill(dataSet);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataSet;
        }

        public DataSet Exec_Store_Allow_See_News(string ProductName, string strAuthor, int flag)
        {
            var dataSet = new DataSet();
            try
            {
                new SqlDataAdapter(
                    string.Concat(
                        new object[]
                            { "Exec ", ProductName, " @Author = ", base.SafeString(strAuthor), ", @Flag = ", flag }),
                    this.SqlConn()).Fill(dataSet);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataSet;
        }

        public int Execute(string QueryString)
        {
            int num = -1;
            try
            {
                var command = new SqlCommand(QueryString, this.SqlConn());
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return num;
        }

        public int Execute(int intLang, int intId, string Input, int intIsActive, string StrQueryString)
        {
            var command = new SqlCommand(StrQueryString, this.SqlConn());
            int num = -1;
            try
            {
                var parameter = new SqlParameter("@intLang", SqlDbType.Int) { Value = intLang };
                command.Parameters.Add(parameter);
                var parameter2 = new SqlParameter("@intId", SqlDbType.Int) { Value = intId };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Input", SqlDbType.NVarChar) { Value = Input };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@intIsActive", SqlDbType.Bit);
                parameter4.Value = intIsActive;
                command.Parameters.Add(parameter4);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                num = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return num;
        }

        public SqlDataReader ExecuteReader(string QueryString)
        {
            var command = new SqlCommand(QueryString, this.SqlConn());
            command.Connection.Open();
            SqlDataReader reader = null;
            try
            {
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return reader;
        }

        public SqlDataReader ExecuteReader_StoreProcedure(string StoreProcedure)
        {
            var command = new SqlCommand(StoreProcedure, this.SqlConn());
            command.Connection.Open();
            SqlDataReader reader = null;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                reader = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return reader;
        }

        public DataSet Execute_Store(string Proceduce_Name)
        {
            var dataSet = new DataSet();
            try
            {
                new SqlDataAdapter(Proceduce_Name, this.SqlConn()).Fill(dataSet);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return dataSet;
        }

        public bool FindProductCatChildNode(int Cat_Id, DataTable dt)
        {
            bool flag = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Cat_Id == int.Parse(dt.Rows[i]["Parent"].ToString()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public int Insert(int IntFunction_ID, int IntGroup_ID, string StrQueryString)
        {
            var command = new SqlCommand(StrQueryString, this.SqlConn());
            int num = -1;
            try
            {
                var parameter = new SqlParameter("@IntFunction_ID", SqlDbType.Int) { Value = IntFunction_ID };
                command.Parameters.Add(parameter);
                var parameter2 = new SqlParameter("@IntGroup_ID", SqlDbType.Int);
                parameter2.Value = IntGroup_ID;
                command.Parameters.Add(parameter2);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                num = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return num;
        }

        public int InsertMemberGroup(string GroupName, string GroupDesc, int isActive, string StrQueryString)
        {
            var command = new SqlCommand(StrQueryString, this.SqlConn());
            int num = -1;
            try
            {
                var parameter = new SqlParameter("@GroupName", SqlDbType.NVarChar);
                parameter.Value = GroupName;
                command.Parameters.Add(parameter);
                var parameter2 = new SqlParameter("@GroupDesc", SqlDbType.NVarChar);
                parameter2.Value = GroupDesc;
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@isActive", SqlDbType.Bit) { Value = isActive };
                command.Parameters.Add(parameter3);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                num = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return num;
        }

        public string ShowBanner(int Language_Id)
        {
            var builder = new StringBuilder();
            string str = HttpContext.Current.Request.ServerVariables["URL"];
            str = str.Substring(str.LastIndexOf("/") + 1, str.Length - (str.LastIndexOf("/") + 1));
            string datetime = Convert.ToString(DateTime.Now);
            datetime = base.FormatDateTimeEN(datetime);
            var command = new SqlCommand("Get_List_Banner", this.SqlConn());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Language_id", Language_Id);
            command.Parameters.AddWithValue("@CurrentDate", datetime);
            command.Parameters.AddWithValue("@PagePath", str);
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                builder.Append(" <table width='100%' cellspacing='1' cellpadding='0'>");
                while (reader.Read())
                {
                    int num = int.Parse(reader["Height"].ToString());
                    builder.Append(" <tr>");
                    builder.Append("    <td align='center'>");
                    if (int.Parse(reader["TypeLink"].ToString()) == 1)
                    {
                        builder.Append(
                            string.Concat(
                                new object[]
                                    {
                                        " <img src=\"", base.GetPathToUploadBanner(), reader["ImageName"].ToString(),
                                        "\" border='0' width='435' height='", num,
                                        "' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('",
                                        reader["BannerURL"].ToString(), "');\" onClick=\"javascript:window.open('http://",
                                        reader["BannerURL"].ToString(), "');\" style='cursor:hand;' title='",
                                        reader["BannerName"].ToString(), "'>"
                                    }));
                    }
                    else if (int.Parse(reader["TypeLink"].ToString()) == 0)
                    {
                        builder.Append(
                            string.Concat(
                                new object[]
                                    {
                                        " <img src=\"", base.GetPathToUploadBanner(), reader["ImageName"].ToString(),
                                        "\" border='0' width='435' height='", num,
                                        "' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('",
                                        reader["BannerURL"].ToString(), "');\" onClick=\"javascript:location.href('",
                                        reader["BannerURL"].ToString(), "');\" style='cursor:hand;' title='",
                                        reader["BannerName"].ToString(), "'>"
                                    }));
                    }
                    builder.Append("    </td>");
                    builder.Append(" </tr>");
                    builder.Append(" <tr><td height='2'></td></tr>");
                }
                builder.Append(" </table>");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + exception.StackTrace);
            }
            finally
            {
                command.Connection.Close();
                this.SqlConn().Close();
                command.Connection.Dispose();
                this.SqlConn().Dispose();
            }
            return builder.ToString();
        }

        public string ShowLogo(int Language_Id, int Cat_Id, int Location_ID)
        {
            Exception exception;
            var builder = new StringBuilder();
            string str = HttpContext.Current.Request.ServerVariables["URL"];
            str = str.Substring(str.LastIndexOf("/") + 1, str.Length - (str.LastIndexOf("/") + 1));
            string datetime = Convert.ToString(DateTime.Now);
            datetime = base.FormatDateTimeEN(datetime);
            var command =
                new SqlCommand(
                    string.Concat(
                        new object[]
                            {
                                "select top 1 LBRandom From TB_Cat_Logo Where active=1 and (Cat_Id = ", Cat_Id,
                                " or PagePath='", str, "') ORDER BY CreatedDate DESC"
                            }),
                    this.SqlConn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                if ((reader != null) && reader.Read())
                {
                    int num = 0;
                    if ((bool)reader["LBRandom"])
                    {
                        num = 1;
                    }
                    int num2 = 0;
                    SqlDataReader reader2 = null;
                    var command2 = new SqlCommand("Get_List_Logo", this.SqlConn())
                                       {
                                           CommandType =
                                               CommandType.StoredProcedure
                                       };
                    command2.Parameters.AddWithValue("@Language_id", Language_Id);
                    command2.Parameters.AddWithValue("@Cat_Id", Cat_Id);
                    command2.Parameters.AddWithValue("@Location_ID", Location_ID);
                    command2.Parameters.AddWithValue("@CurrentDate", datetime);
                    command2.Parameters.AddWithValue("@PagePath", str);
                    command2.Parameters.AddWithValue("@LBRandom", num);
                    try
                    {
                        command2.Connection.Open();
                        reader2 = command2.ExecuteReader();
                        if (Location_ID == 0)
                        {
                            num2 = 0x91;
                        }
                        else
                        {
                            num2 = 0xb9;
                        }
                        builder.Append(" <table width='100%' cellspacing='0' cellpadding='0'>");
                        if (reader2 != null)
                        {
                            while (reader2.Read())
                            {
                                builder.Append(" <tr>");
                                builder.Append("    <td align='center' >");
                                if (int.Parse(reader2["TypeLink"].ToString()) == 1)
                                {
                                    builder.Append(
                                        string.Concat(
                                            new object[]
                                                {
                                                    "        <img src=\"", base.GetPathToUploadLogo(),
                                                    reader2["ImageName"].ToString(), "\" border='0' width='", num2,
                                                    "' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('",
                                                    reader2["LogoURL"].ToString(),
                                                    "');\" onClick=\"javascript:window.open('http://",
                                                    reader2["LogoURL"].ToString(), "');\" style='cursor:hand;' title='",
                                                    reader2["LogoName"].ToString(), "'>"
                                                }));
                                }
                                else if (int.Parse(reader2["TypeLink"].ToString()) == 0)
                                {
                                    builder.Append(
                                        string.Concat(
                                            new object[]
                                                {
                                                    "        <img src=\"", base.GetPathToUploadLogo(),
                                                    reader2["ImageName"].ToString(), "\" border='0' width='", num2,
                                                    "' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('",
                                                    reader2["LogoURL"].ToString(),
                                                    "');\" onClick=\"javascript:location.href('",
                                                    reader2["LogoURL"].ToString(), "');\" style='cursor:hand;' title='",
                                                    reader2["LogoName"].ToString(), "'>"
                                                }));
                                }
                                builder.Append("    </td>");
                                builder.Append(" </tr>");
                            }
                        }
                        builder.Append(" </table>");
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        throw new Exception(exception.Message + exception.StackTrace);
                    }
                    finally
                    {
                        reader2.Close();
                        command2.Connection.Close();
                        this.SqlConn().Close();
                        command2.Connection.Dispose();
                        this.SqlConn().Dispose();
                    }
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message + exception.StackTrace);
            }
            finally
            {
                reader.Close();
                command.Connection.Close();
                this.SqlConn().Close();
                command.Connection.Dispose();
                this.SqlConn().Dispose();
            }
            return builder.ToString();
        }

        public SqlConnection SqlConn()
        {
            return new SqlConnection(this.strConn);
        }

        public int Update(string StrGroupName, string strGroupDesc, int intIsActive, string StrQueryString)
        {
            var command = new SqlCommand(StrQueryString, this.SqlConn());
            int num = -1;
            try
            {
                var parameter = new SqlParameter("@StrGroupName", SqlDbType.NVarChar) { Value = StrGroupName };
                command.Parameters.Add(parameter);
                var parameter2 = new SqlParameter("@strGroupDesc", SqlDbType.NVarChar) { Value = strGroupDesc };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@intIsActive", SqlDbType.Bit) { Value = intIsActive };
                command.Parameters.Add(parameter3);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                num = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                this.SqlConn().Close();
                this.SqlConn().Dispose();
            }
            return num;
        }

        public string rwProductCat(int Cat_Id, int Parent, string CatName, bool Active, string varSpace)
        {
            var builder = new StringBuilder();
            string str = string.Empty;
            if (!Active)
            {
                str = String.Format("<span style='color:#FF0000'>{0}</span>", CatName);
            }
            else
            {
                str = CatName;
            }
            if (Parent == 0)
            {
                builder.Append(
                    String.Format(
                        "<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>{0}</strong>",
                        str));
            }
            else
            {
                builder.Append(String.Format("{0}-&nbsp;{1}", varSpace, str));
            }
            builder.Append(
                string.Concat(
                    new object[]
                        {
                            "&nbsp;&nbsp;&nbsp;<a href='Product_Cat_Edit.aspx?id=", Cat_Id, "' title='Sửa danh mục ",
                            CatName, "'><img src='/images/Admin/edit_u.gif' border='0'></a>"
                        }));
            builder.Append(
                string.Concat(
                    new object[]
                        {
                            "&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Product_Cat_Delete.aspx?id="
                            , Cat_Id, "'};\" title='X\x00f3a danh mục ", CatName,
                            "'><img src='/Images/Admin/delete.gif' border='0'></a>"
                        }));
            builder.Append("<br />");
            return builder.ToString();
        }

        public void wrCatProduct(int Cat_Id, ref string strCatName, int Language_Id)
        {
            var command = new SqlCommand("Get_ProductCat", this.SqlConn()) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@Cat_Id", Cat_Id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader["CatName"].ToString() != null)
                {
                    if (strCatName != string.Empty)
                    {
                        if (Language_Id == 1)
                        {
                            strCatName = "<a href=\"Product_Cat.aspx?catid=" + reader["Cat_Id"]
                                         + "\" class='product_list_title'>" + reader["CatName"] + "</a> > " + strCatName;
                        }
                        else
                        {
                            strCatName =
                                String.Format(
                                    "<a href=\"eProduct_Cat.aspx?catid={0}\" class='product_list_title'>{1}</a> > {2}",
                                    reader["Cat_Id"],
                                    reader["CatName"],
                                    strCatName);
                        }
                    }
                    else
                    {
                        strCatName = "<font class='product_list_title_Isleaf'>" + reader["CatName"] + "</font>";
                    }
                }
                if (int.Parse(reader["Parent"].ToString()) != 0)
                {
                    this.wrCatProduct(int.Parse(reader["Parent"].ToString()), ref strCatName, Language_Id);
                }
            }
            reader.Close();
            command.Connection.Close();
            command.Connection.Dispose();
        }

        public string wrCatProductTitle(int Cat_Id, int Language_Id)
        {
            string strCatName = string.Empty;
            var builder = new StringBuilder();
            this.wrCatProduct(Cat_Id, ref strCatName, Language_Id);
            builder.Append(" <table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            builder.Append("    <tr>");
            builder.Append(String.Format("        <td valign='top'>{0}</td>", strCatName));
            builder.Append("    </tr>");
            builder.Append("    <tr><td height='10'></td></tr>");
            builder.Append(" </table>");
            return builder.ToString();
        }

        public string wrProductImage(int LeadImage)
        {
            string str = string.Empty;
            if (LeadImage != 0)
            {
                var command = new SqlCommand("Select PhotoID From TB_Images Where ID =" + LeadImage, this.SqlConn())
                                  {
                                      CommandType
                                          =
                                          CommandType
                                          .Text
                                  };
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str = String.Format(
                        "<img src='{0}{1}_T.jpg' border='0'>", base.GetPathToUploadProductImage(), reader["PhotoID"]);
                }
                reader.Close();
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return str;
        }

        public string wrProductImageDetail(int LeadImage, int cid, int proid, int Language_Id)
        {
            string str = string.Empty;
            if (LeadImage != 0)
            {
                var command = new SqlCommand("Select PhotoID From TB_Images Where ID =" + LeadImage, this.SqlConn());
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (Language_Id == 1)
                    {
                        str =
                            string.Concat(
                                new object[]
                                    {
                                        "<a onclick=\"javascript:PopImage('", LeadImage, "','", cid, "','", proid,
                                        "')\" style='cursor:hand;' title='Chi tiết sản phẩm'><img src='",
                                        base.GetPathToUploadProductImage(), reader["PhotoID"].ToString(),
                                        "_T.jpg' border='0'></a>"
                                    });
                    }
                    else
                    {
                        str =
                            string.Concat(
                                new object[]
                                    {
                                        "<a onclick=\"javascript:PopImage_1('", LeadImage, "','", cid, "','", proid,
                                        "')\" style='cursor:hand;' title='Chi tiết sản phẩm'><img src='",
                                        base.GetPathToUploadProductImage(), reader["PhotoID"].ToString(),
                                        "_T.jpg' border='0'></a>"
                                    });
                    }
                }
                reader.Close();
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return str;
        }

        #endregion

        // Properties
    }
}