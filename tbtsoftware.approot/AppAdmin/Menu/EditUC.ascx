<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUC.ascx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Menu.EditUC" %>
<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
<div class="ui-widget-content ui-corner-top ui-corner-bottom">
    <div id="toolbox">
        <div class="header" style="float: left;">
            <img src="/StyleLibrary/AdminStyles/icon-48-generic.png" style="border-width: 0px;" />
            <span>Chỉnh sửa danh mục sản phẩm</span>
        </div>
        <div style="float: right;">
            <table class="toolbar">
                <tr>
                    <td align="center">
                        <%--<asp:LinkButton ID="lbtnHelp" runat="server" CssClass="toolbar"><span title="Help" class="Icon-32-Help"></span>Trợ giúp</asp:LinkButton>--%>
                        <asp:LinkButton ID="lbtnSave" CssClass="toolbar" runat="server" 
                                        onclick="lbtnSave_Click"><span title="Lưu danh mục" class="Icon-32-Save"></span>Lưu</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; " CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
<div id="tabs" runat="server" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
    <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
        <li class="ui-corner-top ui-tabs-selected ui-state-active"><a href="#tabs-1">Thông tin
                                                                       chung</a></li>
    </ul>
    <div id="tabs-1">
        <table class="admintable" style="width: 100%;">
            <tr>
                <td class="key" style="width: 150px;">
                    <span class="Required">*</span> Nhóm danh mục
                </td>
                <td>
                    <asp:TextBox ID="txtName" CssClass="TextInput" Style="width: 350px;" runat="server"></asp:TextBox>
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
                    <span class="Required">*</span> Danh mục cha
                </td>
                <td>
                    <asp:ListBox ID="listView" runat="server" Rows="15" Width="356px"></asp:ListBox>
                    <span class="tooltip"><span class="tooltipContent">
                                              <p class="tooltiptitle">
                                                  Danh mục cha</p>
                                              <p class="tooltipmessage">
                                                  Danh mục cấp trên của danh mục đang cập nhật
                                              </p>
                                          </span></span>
                </td>
            </tr>
            <tr>
                <td class="key" style="width: 150px;">
                    <span class="Required">*</span>Đường dẫn
                </td>
                <td>
                    <asp:TextBox ID="txtLink" CssClass="TextInput" Style="width: 350px;" runat="server"></asp:TextBox>
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
                    <span class="Required">*</span> Ảnh đại diện
                </td>
                <td>
                    <asp:TextBox ID="txtImgSrc" CssClass="TextInput" Style="width: 350px;" runat="server"></asp:TextBox>
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
                    Mô tả
                </td>
                <td>
                    <asp:TextBox ID="txtDescript" runat="server" Columns="20" CssClass="TextInput" Rows="3"
                                 TextMode="MultiLine" Width="346px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="key">
                    Ảnh
                </td>
                <td>
                    <table id="tblUpload" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="file" class="Upload" style="width: 200px;" />&nbsp;&nbsp;
                                <input type="submit" value="Tải lên" class="Button" />
                            </td>
                        </tr>
                    </table>
                    <input type="hidden" />
                </td>
            </tr>
            <tr>
                <td class="key">
                    Thứ tự
                </td>
                <td>
                    <asp:TextBox ID="txtOrderSort" runat="server" CssClass="TextInput" Width="70px"></asp:TextBox>
                    <span class="tooltip"><span class="tooltipContent">
                                              <p class="tooltiptitle">
                                                  Thứ tự hiển thị</p>
                                              <p class="tooltipmessage">
                                                  Thứ tự hiển thị của danh mục sản phẩm
                                              </p>
                                          </span></span>
                </td>
            </tr>
            <tr>
                <td class="key">
                    Hiển thị
                </td>
                <td>
                    <asp:CheckBox ID="ckbDisplay" runat="server" />
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
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server">
        </td>
    </tr>
</table>