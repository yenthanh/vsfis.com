<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TinhNangChucNangUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang.TinhNangChucNangUC" %>
<link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
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
                <span>
                    <asp:Literal ID="ltr_Title" runat="server"></asp:Literal></span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <a title="Trợ giúp" class="toolbar" href="#"><span title="Trợ giúp" class="Icon-32-Help">
                                                                         </span>Trợ giúp</a>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar" OnClick="lbtnUpdate_Click"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                                                         </span>Cập nhật</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; " CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
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
                                    <th style="width: 80px">
                                        Thao tác
                                    </th>
                                    <th style="width: 200px">
                                        FunctionCode
                                    </th>
                                    <th style="width: 80px">
                                        Tính năng
                                    </th>
                                    <th style="width: 600px">
                                        Key
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
                    <asp:HiddenField ID="hfFunction_ID" Value='<%#Eval("Function_ID") %>' runat="server" />
                    <td align="center">
                        <%# Container.DataItemIndex + 1 %>
                    </td>
                    <%--Thao tác--%>
                    <td align="center">
                        <asp:LinkButton Width="98%" ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa thành viên này không?')) return false; "
                                        ToolTip="Xóa tính năng chức năng" CommandName="Delete">Xóa</asp:LinkButton>
                    </td>
                    <%--FunctionCode--%>
                    <td>
                        <asp:TextBox Width="98%" ID="txt_FunctionCode" Text='<%#DataBinder.Eval(Container.DataItem, "FunctionCode") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--Tính năng--%>
                    <td style="text-align: center">
                        <%#DataBinder.Eval(Container.DataItem, "FunctionName") %>
                    </td>
                    <%--Key--%>
                    <td>
                        <asp:TextBox Width="98%" ID="txt_FunctionDesc" Text='<%#DataBinder.Eval(Container.DataItem, "FunctionDesc") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td style="border-color: #F90; text-align: center" colspan="2">
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Thêm mới"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Hủy bỏ"></asp:LinkButton>
                    </td>
                    <%--FunctionCode--%>
                    <td style="border-color: #F90">
                        <asp:TextBox Width="98%" ID="txt_FunctionCode" Text='' runat="server"></asp:TextBox>
                    </td>
                    <%--Tính năng--%>
                    <td style="border-color: #F90">
                        <asp:DropDownList Width="98%" ID="ddl_FunctionName" runat="server">
                        </asp:DropDownList>
                    </td>
                    <%--Mô tả--%>
                    <td style="border-color: #F90">
                        <asp:TextBox Width="98%" ID="txt_FunctionGroupDesc" Text='' runat="server"></asp:TextBox>
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