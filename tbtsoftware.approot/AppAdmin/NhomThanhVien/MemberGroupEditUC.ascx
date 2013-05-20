<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberGroupEditUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.MemberGroupEditUC" %>
<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
<div class="ui-widget-content ui-corner-top ui-corner-bottom">
    <div id="toolbox">
        <div class="header" style="float: left;">
            <img src="/StyleLibrary/AdminStyles/icon-48-generic.png" style="border-width: 0px;" />
            <span>Thông tin nhóm người dùng</span>
        </div>
        <div style="float: right;">
            <table class="toolbar">
                <tr>
                    <td align="center">
                        <%-- <asp:LinkButton ID="lbtnHelp" runat="server" CssClass="toolbar"><span title="Help" class="Icon-32-Help"></span>Trợ giúp</asp:LinkButton>--%>
                        <asp:LinkButton ID="lbtnSave" CssClass="toolbar" runat="server" OnClick="lbtnSave_Click"><span title="Save" class="Icon-32-Save"></span>Lưu</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; " CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
</div>
<div id="tabs" runat="server" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
    <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
        <li class="ui-corner-top ui-tabs-selected ui-state-active"><a href="#tabs-1">Thông tin
                                                                       chung</a></li>
    </ul>
    <div id="tabs-1">
        <table class="admintable" style="width: 100%;">
            <tr>
                <td class="key" style="width: 150px;">
                    <span class="Required">*</span> Tên nhóm
                </td>
                <td>
                    <asp:TextBox ID="txt_GroupName" CssClass="TextInput" Style="width: 350px;" runat="server"></asp:TextBox>
                    <span class="tooltip"><span class="tooltipContent">
                                              <p class="tooltiptitle">
                                                  Mã danh mục</p>
                                              <p class="tooltipmessage">
                                                  Mã danh mục sản phẩm (VD: DM_110)
                                              </p>
                                          </span></span>
                </td>
            </tr>
            <tr>
                <td class="key" style="width: 150px;">
                    <span class="Required">*</span> Mô tả
                </td>
                <td>
                    <asp:TextBox ID="txt_GroupDesc" runat="server" Columns="20" CssClass="TextInput"
                                 Rows="3" TextMode="MultiLine" Width="346px"></asp:TextBox>
                    <span class="tooltip"><span class="tooltipContent">
                                              <p class="tooltiptitle">
                                                  Tên nhóm danh mục</p>
                                              <p class="tooltipmessage">
                                                  Tên danh mục sản phẩm (VD: Đồ gia dụng)
                                              </p>
                                          </span></span>
                </td>
            </tr>
            <tr>
                <td class="key">
                    Kích hoạt
                </td>
                <td>
                    <asp:CheckBox ID="ckb_Active" runat="server" Checked="True" Text="Hiển thị" />
                    <span class="tooltip"><span class="tooltipContent">
                                              <p class="tooltiptitle">
                                                  Hiển thị</p>
                                              <p class="tooltipmessage">
                                                  Lựa chọn để danh mục sản phẩm hiển thị trên website
                                              </p>
                                          </span></span>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td id="htmlMemberGroupEdit" runat="server" valign="top">
            </td>
        </tr>
    </table>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idPermissionAccess" runat="server">
        </td>
    </tr>
</table>