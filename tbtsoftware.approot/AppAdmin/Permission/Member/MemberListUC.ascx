<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberListUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member.MemberListUC" %>
<link href="/StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="/StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />

<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="/StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Danh sách thành viên</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <%--      <a title="Trợ giúp" class="toolbar" href="#"><span title="Trợ giúp" class="Icon-32-Help">
                            </span>Trợ giúp</a>--%>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                              </span>Cập nhật</asp:LinkButton>
                            <a href="them-thanh-vien" title="Xóa thành viên" class="toolbar"><span title="Xóa"
                                                                                                   class="Icon-32-Add"></span>Thêm mới</a>
                            <asp:LinkButton CssClass="toolbar" ID="lbtnDelete" runat="server" ToolTip="Xoá"><span title="Xóa"
                                                                                                                  class="Icon-32-Delete"></span>Xóa</asp:LinkButton>
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
        <asp:ListView ID="lv_ThongTinSP" runat="server" 
                      onitemdeleting="lv_ThongTinSP_ItemDeleting">
            <LayoutTemplate>
                <div style="margin: 5px 0px 5px 0px; padding: 2px;" class="ui-widget-content ui-corner-top ui-corner-bottom">
                    <div>
                        <table cellspacing="0" border="1" style="border-collapse: collapse; width: 100%;"
                               rules="all" class="adminlist">
                            <tbody>
                                <tr>
                                    <th scope="col">
                                        #
                                    </th>
                                    <th style="width: 30px">
                                        Tên thành viên
                                    </th>
                                    <th style="width: 100px">
                                        Nhóm
                                    </th>
                                    <th style="width: 80px">
                                        Họ tên
                                    </th>
                                    <th style="width: 30px">
                                        Vị trí
                                    </th>
                                    <th style="width: 30px">
                                        Trạng thái
                                    </th>
                                    <th style="width: 80px">
                                        Ngày khởi tạo
                                    </th>
                                    <th scope="col">
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
                    <asp:HiddenField ID="hfUserName" Value='<%#Eval("UserName") %>' runat="server" />
                    <td align="center" style="width: 20px;">
                        <%# Container.DataItemIndex + 1 %>
                    </td>
                    <%--Tên thành viên--%>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "UserName") %>
                    </td>
                    <%--Nhóm--%>
                    <td>
                        <a href='sua-nhom-thanh-vien?id=<%#DataBinder.Eval(Container.DataItem, "Group_ID") %>'>
                        <%#DataBinder.Eval(Container.DataItem, "GroupName") %>
                    </td>
                    <%--Họ tên--%>
                    <td>
                        <a href='sua-thong-tin-thanh-vien?id=<%#DataBinder.Eval(Container.DataItem, "UserName") %>'>
                            <%#DataBinder.Eval(Container.DataItem, "FullName") %></a>
                    </td>
                    <%--Vị trí--%>
                    <td style="width: 200px;">
                        <%#DataBinder.Eval(Container.DataItem, "Position") %>
                    </td>
                    <%--Trạng thái--%>
                    <td align="center" style="width: 80px;">
                        <%#((bool)Eval("Active")) ? "Kích hoạt" : "<font color='red'>Chưa kích hoạt</font>" %>
                    </td>
                    <%--Ngày khởi tạo--%>
                    <td align="center" style="width: 60px;">
                        <%#DataBinder.Eval(Container.DataItem, "CreateDate") %>
                    </td>
                    <%--Thao tác--%>
                    <td align="center" style="width: 185px;">
                        <a title="Thay đổi mật khẩu" href='doi-mat-khau?height=241&width=336&modal=true&username=<%#DataBinder.Eval(Container.DataItem, "UserName") %>' class="thickbox">
                            Thay mật khẩu</a> &nbsp;|&nbsp;
                        <a title="Chỉnh sửa thông tin thành viên" href='sua-thong-tin-thanh-vien?id=<%#DataBinder.Eval(Container.DataItem, "UserName") %>'>
                            Chỉnh sửa</a> &nbsp;|&nbsp;
                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa thành viên này không?')) return false; "
                                        ToolTip="Xóa danh mục sản phẩm" CommandName="Delete">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
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