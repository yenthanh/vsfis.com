<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Service.EditUC" %>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 <script>
     $(function () {
         $("#tabs").tabs();
     });
</script>
<div id="iRightAccess" runat="server">
    <div id="scrollhere" class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img src="/StyleLibrary/AdminStyles/icon-48-generic.png" style="border-width: 0px;" />
                <span>
                    <asp:Literal ID="ltr_Title" runat="server"></asp:Literal></span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <%-- <asp:LinkButton ID="lbtnHelp" runat="server" CssClass="toolbar"><span title="Help" class="Icon-32-Help"></span>Trợ giúp</asp:LinkButton>--%>
                            <asp:LinkButton ID="lbtnSave" CssClass="toolbar" runat="server" OnClick="lbtnSave_Click"><span title="Save" class="Icon-32-Save"></span>Lưu</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; "
                                            CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
          <table class="admintable" width="100%">
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Url
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtSystem" runat="server"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Danh mục sản phẩm
                                                  </p>
                                                  <p class="tooltipmessage">
                                                      Lựa chọn danh mục chứa sản phẩm
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
            </table>
         <div id="tabs">
<ul>
           <li><a href="#tabs-1"><img src="/StyleLibrary/RootStyles/Images/commons/vn.png " class="selected" alt="Tiếng việt" title="Tiếng việt">&nbsp;&nbsp;Tiếng việt</a></li>
            <li><a href="#tabs-2"><img src="/StyleLibrary/RootStyles/Images/commons/us.png" class="selected" alt="Tiếng anh" title="Tiếng anh">&nbsp;&nbsp;Tiếng anh</a></li>
            <li><a href="#tabs-3"><img src="/StyleLibrary/RootStyles/Images/commons/jp.png " class="selected" alt="Tiếng Nhật" title="Tiếng Nhật">&nbsp;&nbsp;Tiếng Nhật</a></li>
</ul>
       
<div id="tabs-1">
       <table class="admintable" width="100%">
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Tiêu đề
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtvi" runat="server"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Danh mục sản phẩm
                                                  </p>
                                                  <p class="tooltipmessage">
                                                      Lựa chọn danh mục chứa sản phẩm
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
            <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Nội dung
                    </td>
                    <td style="width: 25%">
                        <CKEditor:CKEditorControl ID="ckFullvi" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                        <span class="tooltip"><span class="tooltipContent">
                            <p class="tooltiptitle">
                                Danh mục sản phẩm
                            </p>
                            <p class="tooltipmessage">
                                Lựa chọn danh mục chứa sản phẩm
                            </p>
                        </span></span>
                    </td>
                </tr>
            </table>
</div>
<div id="tabs-2">   <table class="admintable" width="100%">
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Tiêu đề
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txten" runat="server"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Danh mục sản phẩm
                                                  </p>
                                                  <p class="tooltipmessage">
                                                      Lựa chọn danh mục chứa sản phẩm
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
     <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Nội dung
                    </td>
                    <td style="width: 25%">
                        <CKEditor:CKEditorControl ID="ckFullen" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                        <span class="tooltip"><span class="tooltipContent">
                            <p class="tooltiptitle">
                                Danh mục sản phẩm
                            </p>
                            <p class="tooltipmessage">
                                Lựa chọn danh mục chứa sản phẩm
                            </p>
                        </span></span>
                    </td>
                </tr>
            </table>
</div>
<div id="tabs-3">   <table class="admintable" width="100%">
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Tiêu đề
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtjp" runat="server"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Danh mục sản phẩm
                                                  </p>
                                                  <p class="tooltipmessage">
                                                      Lựa chọn danh mục chứa sản phẩm
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
     <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Nội dung
                    </td>
                    <td style="width: 25%">
                        <CKEditor:CKEditorControl ID="ckFulljp" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                        <span class="tooltip"><span class="tooltipContent">
                            <p class="tooltiptitle">
                                Danh mục sản phẩm
                            </p>
                            <p class="tooltipmessage">
                                Lựa chọn danh mục chứa sản phẩm
                            </p>
                        </span></span>
                    </td>
                </tr>
            </table>
</div>
</div>
         
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server"></td>
    </tr>
</table>