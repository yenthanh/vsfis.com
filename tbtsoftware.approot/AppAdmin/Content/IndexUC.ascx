<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Content.IndexUC" %>
<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="/StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<script src="http://code.jquery.com/jquery-1.9.1.min.js"> </script>
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="/StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Danh sách chủ đề</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <a href="/AppAdmin/Content/Edit.aspx" cssclass="toolbar"><span title="Thêm sản phẩm" class="Icon-32-Add"></span>Thêm mới</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
     <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="margin: 5px 0px 5px 0px; padding: 2px;">
        <asp:ListView ID="lv_ThongTinSP" OnItemDeleting="lv_ThongTinSP_ItemDeleting" runat="server">
            <LayoutTemplate>
                <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                    <div>
                        <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                               rules="all" class="adminlist">
                            <tbody>
                                <tr>
                                    <th style="width: 3%">#
                                    </th>
                                    <th>Tên
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
                    <asp:HiddenField ID="hfID" Value='<%#Eval("ID") %>' runat="server" />
                    <td align="center">
                        <%# Container.DataItemIndex + 1 %>
                    </td>
                    <td><%#Eval("Title") %>
                    </td>
                    <td class="action">
                        <a href='/AppAdmin/Content/Edit.aspx?id=<%#Eval("ID") %>'><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-edit.png"></a>
                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?')) return false; "
                                        ToolTip="Xóa sản phẩm" CommandName="Delete"><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-delete.png"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server">
        </td>
    </tr>
</table>