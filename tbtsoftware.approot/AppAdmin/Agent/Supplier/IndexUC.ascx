﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexUC.ascx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Agent.Supplier.IndexUC" %>
<link href="../../StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="../../StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Danh sách nhà cung cấp công ty</span>
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
                      OnItemInserting="lv_ThongTinSP_ItemInserting" InsertItemPosition="FirstItem"
                      runat="server">
            <LayoutTemplate>
                <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                    <div>
                        <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                               rules="all" class="adminlist">
                            <tbody>
                                <tr>
                                    <th style="width: 3%">
                                        #
                                    </th>
                                    <th style="width: 5%">
                                        Mã NCC
                                    </th>
                                    <th>
                                        Tên nhà cung cấp
                                    </th>
                                    <th style="width: 15%">
                                        Địa chỉ
                                    </th>
                                    <th style="width: 13%">
                                        Email
                                    </th>
                                    <th style="width: 8%">
                                        Tel
                                    </th>
                                    <th style="width: 8%">
                                        Phone
                                    </th>
                                    <th style="width: 8%">
                                        STK
                                    </th>
                                    <th style="width: 8%">
                                    Ngân hàng
                                    <th style="width: 8%">
                                        Thao tác
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
                    <td><%#DataBinder.Eval(Container.DataItem, "Alias") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Address") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Email") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Tel") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Phone") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "BankNumber") %>
                    </td>
                    <td><%#DataBinder.Eval(Container.DataItem, "BankName") %>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn nhóm nhà cung cấp này không?')) return false; "
                                        ToolTip="Xóa nhóm nhà cung cấp" CommandName="Delete">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td colspan="2">
                        <asp:TextBox Width="94%" ID="txtAlias"
                                     runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox Width="98%" ID="txtName"
                                     runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox Width="98%" ID="txt_Address"
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--Email--%>
                    <td>
                        <asp:TextBox Width="94%" ID="txt_Email" 
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--Phone--%>
                    <td>
                        <asp:TextBox Width="94%" ID="txt_Phone"
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--Mobile--%>
                    <td>
                        <asp:TextBox Width="94%" ID="txt_Mobile"
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--BankNumber--%>
                    <td>
                        <asp:TextBox Width="94%" ID="txt_BankNumber" Text='<%#DataBinder.Eval(Container.DataItem, "BankNumber") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                    <%--BankName--%>
                    <td>
                        <asp:TextBox Width="94%" ID="txt_BankName" Text='<%#DataBinder.Eval(Container.DataItem, "BankName") %>'
                                     runat="server"></asp:TextBox>
                    </td>
                    <!-- Thao tác -->
                    <td>
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Thêm mới"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Hủy bỏ"></asp:LinkButton>
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