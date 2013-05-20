<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Article.EditUC" %>
<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
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
    <div id="tabs1" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
        <div id="tabs-1" class="ui-tabs-panel ui-widget-content ui-corner-bottom">
            <table class="admintable" width="100%">
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Ngôn ngữ
                    </td>
                    <td style="width: 25%">
                        <asp:DropDownList ID="ddlLang" runat="server">
                            <asp:ListItem Value="1">Tiếng Anh</asp:ListItem>
                            <asp:ListItem Value="2">Tiếng Nhật</asp:ListItem>
                            <asp:ListItem Value="3">Tiếng Việt</asp:ListItem>
                        </asp:DropDownList>
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
                        <span class="Required">*</span>&nbsp;Tiêu đề
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
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
                        <span class="Required">*</span>&nbsp;Mô tả ngắn
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtShort" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
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
                        <span class="Required">*</span>&nbsp;Mô tả chi tiết
                    </td>
                    <td style="width: 25%">
                        <CKEditor:CKEditorControl ID="ckFull" BasePath="/ckeditor" runat="server"></CKEditor:CKEditorControl>
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
                        <span class="Required">*</span>&nbsp;Đã công bố: 
                    </td>
                    <td style="width: 25%">
                        <asp:CheckBox ID="ckbPublish" runat="server" />
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