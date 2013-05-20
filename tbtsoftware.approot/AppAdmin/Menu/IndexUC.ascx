<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Menu.IndexUC" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="/StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="/StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Cấu hình menu</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <%--<a title="Trợ giúp" class="toolbar" href="#"><span title="Trợ giúp" class="Icon-32-Help">
                            </span>Trợ giúp</a>--%>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar" OnClick="lbtnUpdate_Click"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                                                         </span>Cập nhật</asp:LinkButton>
                            <a href="them-menu" cssclass="toolbar"><span title="Thêm danh mục sản phẩm" class="Icon-32-Add"></span>Thêm mới</a>
                            <asp:LinkButton ID="lbtn_Xoa" runat="server" CssClass="toolbar"
                                            OnClick="lbtn_Xoa_Click"><span title="Xóa danh mục sản phẩm đã lựa chọn" class="Icon-32-Delete">
                                                                     </span>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <asp:ListView ID="listView" runat="server" OnItemDeleting="listView_ItemDeleting">
        <LayoutTemplate>
            <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                <div>
                    <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                           rules="all" class="adminlist">
                        <tbody>
                            <tr>
                                <th style="width: 3%">#
                                </th>
                                <th style="width: 1%"></th>
                                <th style="width: 1%">Ảnh
                                </th>
                                <th>Nhóm danh mục
                                </th>
                                <th>Đường dẫn
                                </th>
                                <th style="width: 20%">Mô tả
                                </th>
                                <th style="width: 6%">Trạng thái
                                </th>
                                <th style="width: 4%">Thứ tự
                                </th>
                                <th style="width: 10%">Thao tác
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="row0">
                <asp:HiddenField ID="hfID" Value='<%#Eval("Id") %>' runat="server" />
                <td align="center">
                    <%# Container.DataItemIndex + 1 %>
                </td>
                <td>
                    <dx:ASPxCheckBox ID="ckb_Choose" runat="server">
                    </dx:ASPxCheckBox>
                </td>
                <td>
                    <img style="height: 16px; width: 16px;" src='/StyleLibrary/AdminStyles/images/Menu/<%# Eval("ImgSrc") %>' />
                </td>
                <td>
                    <a style="color: #005FA3;" href='/AppAdmin/Menu/Edit.aspx?ID=<%#Eval("Id") %>'>
                        <%# Eval("Name") %>
                    </a>
                </td>
                <td>
                    <%# Eval("Link") %>
                </td>
                <td>
                    <%# Eval("Descript") %>
                </td>
                <td align="center">
                    <%# Eval("IsDisplay").ToString().ToLower() == "true" ? "Hiển thị" : "Ẩn" %>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txt_OrderSort" runat="server" Width="98%" Text='<%#Eval("OrderSort") %>'
                                    HorizontalAlign="Right" ValidationSettings-Display="None">
                        <MaskSettings Mask="<0..9ch999999999g>" />
                    </dx:ASPxTextBox>
                </td>
                <td class="action">
                    <a><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-new.png"></a>
                    <a><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-edit.png"></a>
                     <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?')) return false; "
                                        ToolTip="Xóa sản phẩm" CommandName="Delete"><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-delete.png"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server"></td>
    </tr>
</table>