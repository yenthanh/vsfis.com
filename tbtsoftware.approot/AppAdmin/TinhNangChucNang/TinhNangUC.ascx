<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TinhNangUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.TinhNangUC" %>
<link href="/StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="/StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<script src="http://code.jquery.com/jquery-1.9.1.min.js"> </script>
<script src="/StyleLibrary/AdminStyles/Popup.js" type="text/javascript"> </script>
<link href="/StyleLibrary/AdminStyles/Popup.css" rel="stylesheet" type="text/css" />
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="/StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Danh sách tính năng</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <a title="Trợ giúp" class="toolbar" href="#"><span title="Trợ giúp" class="Icon-32-Help">
                                                                         </span>Trợ giúp</a>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar" OnClick="lbtnUpdate_Click"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                                                         </span>Cập nhật</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <%-- <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="padding: 2px;
        margin: 5px 0px 5px 0px; height: 32px">
        <div class="pagination">
            <ul class="paginator">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lv_ThongTinSP" PageSize="12"
                    OnPreRender="DataPagerProducts_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                            PreviousPageText="Trang trước" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="pagination_numeric_selected" NumericButtonCssClass="pagination_numeric"
                            ButtonCount="15" NextPreviousButtonCssClass="pagination_numeric" />
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                            NextPageText="Trang kế" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </ul>
        </div>
    </div>--%>
    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="margin: 5px 0px 5px 0px; padding: 2px;">
        <asp:ListView ID="lv_ThongTinSP" OnItemDeleting="lv_ThongTinSP_ItemDeleting" OnItemCanceling="lv_ThongTinSP_ItemCanceling"
                      OnItemInserting="lv_ThongTinSP_ItemInserting" InsertItemPosition="FirstItem" runat="server">
            <LayoutTemplate>
                <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                    <div>
                        <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                               rules="all" class="adminlist">
                            <tbody>
                                <tr>
                                    <th style="width: 20px">
                                        #
                                    </th>
                                    <th style="width: 40px">
                                        Thao tác
                                    </th>
                                    <th style="width: 200px">
                                        Nhóm chức năng
                                    </th>
                                    <th style="width: 50px">
                                        Thứ tự
                                    </th>
                                    <th style="width: 600px">
                                        Mô tả
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
                    <asp:HiddenField ID="hfFunction_Group_ID" Value='<%#Eval("FunctionName_ID") %>'
                                     runat="server" />
                    <td align="center">
                        <%# Container.DataItemIndex + 1 %>
                    </td>
                    <%--Thao tác--%>
                    <td align="center">
                        <asp:LinkButton Width="98%" ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa thành viên này không?')) return false; "
                                        ToolTip="Xóa danh mục sản phẩm" CommandName="Delete">Xóa</asp:LinkButton>
                    </td>
                    <%--Nhóm chức năng--%>
                    <td>
                        <asp:TextBox Width="98%" ID="txt_FunctionGroupName" Text='<%#DataBinder.Eval(Container.DataItem, "FunctionName") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--Thứ tự--%>
                    <td style="text-align: center">
                        <%#DataBinder.Eval(Container.DataItem, "FunctionOrder") %>
                    </td>
                    <%--Mô tả--%>
                    <td>
                        <asp:TextBox Width="98%" ID="txt_FunctionGroupDesc" Text='<%#DataBinder.Eval(Container.DataItem, "FunctionNameDesc") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td style="border-color: #F90" colspan="2">
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Thêm mới"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Hủy bỏ"></asp:LinkButton>
                    </td>
                    <%--Nhóm chức năng--%>
                    <td style="border-color: #F90">
                        <asp:TextBox Width="98%" ID="txt_FunctionGroupName" runat="server"></asp:TextBox>
                    </td>
                    <%--Thứ tự--%>
                    <td style="border-color: #F90">
                    </td>
                    <%--Mô tả--%>
                    <td style="border-color: #F90">
                        <asp:TextBox Width="98%" ID="txt_FunctionGroupDesc" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>
    <%--    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="padding: 2px;
        margin: 5px 0px 5px 0px; height: 32px">
        <div class="pagination">
            <ul class="paginator">
                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="lv_ThongTinSP"
                    PageSize="14" OnPreRender="DataPagerProducts_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                            PreviousPageText="Trang trước" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="pagination_numeric_selected" NumericButtonCssClass="pagination_numeric"
                            ButtonCount="15" NextPreviousButtonCssClass="pagination_numeric" />
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                            NextPageText="Trang kế" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </ul>
        </div>
    </div>--%>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server">
        </td>
    </tr>
</table>