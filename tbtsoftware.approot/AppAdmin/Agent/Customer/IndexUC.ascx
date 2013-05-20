<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Agent.Customer.IndexUC" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<link href="../../StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<script src="../../StyleLibrary/AdminStyles/jquery-1.3.2.min.js" type="text/javascript"> </script>
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="../../StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0;" />
                <span>Danh sách khách hàng</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                     
                            <a title="Trợ giúp" class="toolbar" href="#"><span title="Trợ giúp" class="Icon-32-Help"></span>Trợ giúp</a> <a title="Danh sách khách hàng cần kiểm tra" class="toolbar"
                                                                                                                                            href="canh-bao-khach-hang"><span title="Danh sách khách hàng cần kiểm tra" class="Icon-32-Warning"></span>Cảnh báo</a>
                            <asp:LinkButton ID="lbtn_DoTim" runat="server" CssClass="toolbar" OnClick="lbtn_DoTim_Click"><span title="Dò tìm khách hàng yếu kém" class="Icon-32-Radar">
                                                                                                                         </span>Dò tìm</asp:LinkButton>
                            <a href="thiet-lap-gia-khach-hang" cssclass="toolbar"><span title="Thiết lập giá khách hàng"
                                                                                        class="Icon-32-SetPrice"></span>Thiết lập giá</a>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar" OnClick="lbtnUpdate_Click"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                                                         </span>Cập nhật</asp:LinkButton>
                            <a href="them-khach-hang" cssclass="toolbar"><span title="Thêm khách hàng" class="Icon-32-Add"></span>Thêm mới</a>
                            <asp:LinkButton CssClass="toolbar" ID="lbtnDelete" runat="server" ToolTip="Xoá"><span title="Xóa"
                                                                                                                  class="Icon-32-Delete"></span>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <div id="scrollhere" class="ui-widget-content ui-corner-top ui-corner-bottom" style="height: 32px; margin: 5px 0px 5px 0px; padding: 2px;">
        <div class="pagination">
            <ul class="paginator">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lv_HienThi" PageSize="12"
                               OnPreRender="DataPagerProducts_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                                                    PreviousPageText="Trang trước" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="pagination_numeric_selected" NumericButtonCssClass="pagination_numeric"
                                               ButtonCount="30" NextPreviousButtonCssClass="pagination_numeric" />
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                                                    NextPageText="Trang kế" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </ul>
        </div>
    </div>
    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="margin: 5px 0px 5px 0px; padding: 2px;">
        <div class="buttons" style="margin: 5px; padding: 5px;">
            <b>Khách hàng&nbsp;</b>
            <asp:TextBox ID="txt_TimKiem" Height="21px" Width="200px" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbtn_TK" runat="server" CssClass="positive" OnClick="lbtn_TK_Click"> <img src="../StyleLibrary/AdminStyles/Toolbox/Search-icon.png" alt=""/>Tìm kiếm</asp:LinkButton>

            <a class="positive" href="danh-sach-khach-hang">
                <img src="../StyleLibrary/AdminStyles/Toolbox/Search-icon.png" alt="" />Tất cả khách hàng</a>
        </div>
        <asp:ListView ID="lv_HienThi" runat="server" OnItemDeleted="lv_HienThi_ItemDeleted"
                      OnItemDeleting="lv_HienThi_ItemDeleting" InsertItemPosition="FirstItem" OnItemCanceling="lv_HienThi_ItemCanceling"
                      OnItemInserting="lv_HienThi_ItemInserting">
            <LayoutTemplate>
                <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                    <div>
                        <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                               rules="all" class="adminlist">
                            <tbody>
                                <tr>
                                    <th style="width: 2%">#
                                    </th>
                                    <th style="width: 5%">Mã KH
                                    </th>
                                    <th>Tên khách hàng
                                    </th>
                                    <th style="width: 10%">Điện thoại
                                    </th>
                                    <th style="text-align: center; width: 5%;">Gas
                                    </th>
                                    <th>Địa chỉ
                                    </th>
                                    <th style="width: 2%">Cần CS
                                    </th>
                                    <th style="width: 2%">Kích hoạt
                                    </th>
                                    <th style="width: 20%">Ghi chú
                                    </th>
                                    <th style="width: 5%">Thao tác
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
                    <td style="text-align: center;">
                        <%#Eval("Alias") %>
                    </td>
                    <td><%#Eval("Name") %>
                    </td>
                    <td>
                        <%#Eval("Tel") %>
                    </td>
                    <td >
                        <%#Eval("GasUsed") %>
                    </td>
                    <td ><%#Eval("Address") %>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckb_IsCare" runat="server" Checked='<%#Eval("IsCare") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="ckb_Active" runat="server" Checked='<%#Eval("Active") %>' />
                    </td>
                    <td><%#Eval("Note") %>
                    </td>
                    <td class="action">
                        <%-- <a><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-new.png"></a>
                        <a title="Chỉnh sửa thông tin khách hàng" href='chinh-sua-khach-hang?ID=<%#Eval("ID") %>'>Chỉnh sửa</a> --%>
                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa khách hàng này không?')) return false; "
                                        ToolTip="Xóa khách hàng" CommandName="Delete"><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-delete.png"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr class="row0">
                    <td colspan="2">
                        <dx:ASPxTextBox ID="txtID" runat="server" Width="98%" Text='' 
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Tên KH--%>
                    <td>
                        <dx:ASPxTextBox ID="txtName" runat="server" Width="98%" Text='' 
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Điện thoại--%>
                    <td align="center">
                        <dx:ASPxTextBox ID="txtTel" runat="server" Width="98%" Text='' HorizontalAlign="Right"
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Gas--%>
                    <td>
                        <dx:ASPxTextBox ID="txtGasUsed" runat="server" Width="98%" Text='' 
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Địa chỉ--%>
                    <td align="center">
                        <dx:ASPxTextBox ID="txtAddress" runat="server" Width="98%" Text='' 
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Cần CS--%>
                    <td>&nbsp;
                    </td>
                    <%--Kích hoạt--%>
                    <td>&nbsp;
                    </td>
                    <%--Ghi chú--%>
                    <td>
                        <dx:ASPxTextBox ID="txtNote" runat="server" Width="98%" Text=''
                                        ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <td class="action">
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert"><img src="/StyleLibrary/AdminStyles/Toolbox/icon-32-new.png"></asp:LinkButton>
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Hủy bỏ"></asp:LinkButton>
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>
    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="height: 32px; margin: 5px 0 5px 0px; padding: 2px;">
        <div class="pagination">
            <ul class="paginator">
                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="lv_HienThi"
                               PageSize="14" OnPreRender="DataPagerProducts_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                                                    PreviousPageText="Trang trước" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="pagination_numeric_selected" NumericButtonCssClass="pagination_numeric"
                                               ButtonCount="30" NextPreviousButtonCssClass="pagination_numeric" />
                        <asp:NextPreviousPagerField ButtonCssClass="pagination_numeric" ShowNextPageButton="False"
                                                    NextPageText="Trang kế" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </ul>
        </div>
    </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server"></td>
    </tr>
</table>