<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhanVien_ViewUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Employee.NhanVien_ViewUC" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<link href="../../StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../StyleLibrary/AdminStyles/jquery.fancybox.css" rel="stylesheet"
      type="text/css" />
<script src="../../StyleLibrary/AdminStyles/jquery-1.3.2.min.js" type="text/javascript"> </script>
<div runat="Server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img id="ctl00_cph_Main_ctl00_ctl00_toolbox_imgHeader" src="../../StyleLibrary/AdminStyles/icon-48-generic.png"
                     style="border-width: 0px;" />
                <span>Danh sách nhân viên</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="toolbar" OnClick="lbtnUpdate_Click"><span title="Cập nhật" class="Icon-32-Apply">
                                                                                                                         </span>Cập nhật</asp:LinkButton>
                            <a href="them-nhan-vien" cssclass="toolbar"><span title="Thêm nhân viên" class="Icon-32-Add">
                                                                        </span>Thêm mới</a>
                            <asp:LinkButton CssClass="toolbar" ID="lbtnDelete" runat="server" ToolTip="Xoá"><span title="Xóa"
                                                                                                                  class="Icon-32-Delete"></span>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <div id="scrollhere" class="ui-widget-content ui-corner-top ui-corner-bottom" style="margin: 5px 0px 5px 0px; padding: 2px;">
        <asp:ListView ID="lv_ThongTinSP" runat="server" OnItemDeleted="lv_ThongTinSP_ItemDeleted"
                      OnItemDeleting="lv_ThongTinSP_ItemDeleting" InsertItemPosition="FirstItem" 
                      oniteminserting="lv_ThongTinSP_ItemInserting">
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
                                    <th style="width: 2%">
                                        <dx:ASPxCheckBox ID="ckb_CheckAll" runat="server">
                                        </dx:ASPxCheckBox>
                                    </th>
                                    <th style="width: 10%">
                                        Ảnh
                                    </th>
                                    <th style="width: 5%">
                                        Mã nhân viên
                                    </th>
                                    <th style="width: 10%">
                                        Tên nhân viên
                                    </th>
                                    <th style="width: 10%">
                                        Phòng ban
                                    </th>
                                    <th style="width: 10%">
                                        Chi nhánh
                                    </th>
                                    <th style="width: 10%">
                                        Ngày sinh
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
                    <asp:HiddenField ID="hfID" Value='<%#Eval("EmployeeID") %>' runat="server" />
                    <td align="center" style="width: 20px;">
                        <%# Container.DataItemIndex + 1 %>
                    </td>
                    <td>
                        <dx:ASPxCheckBox ID="ckb_Check" runat="server">
                        </dx:ASPxCheckBox>
                    </td>
                    <%--Ảnh--%>
                    <td>
                        <img id="Img1" src='<%#Eval("HinhAnh") %>' width="197" runat="server">
                    </td>
                    <%--Alias--%>
                    <td align="center">
                        <dx:ASPxTextBox ID="txt_Alias" runat="server" Width="98%" Text='<%#Eval("Alias") %>'
                                        HorizontalAlign="Right" ValidationSettings-Display="None">
                        </dx:ASPxTextBox>
                    </td>
                    <%--Tên nhân viên--%>
                    <td>
                        <asp:TextBox ID="txt_TenNV" Width="98%" Text='<%#Eval("EmployeeName") %>' runat="server"></asp:TextBox>
                    </td>
                    <%--Phòng Ban--%>
                    <td>
                        <%#Eval("TeamName") %>
                    </td>
                    <%--Chi nhánh--%>
                    <td>
                        <%#Eval("BranchName") %>
                    </td>
                    <%--NgaySinh--%>
                    <td>
                        <asp:TextBox ID="txt_NgaySinh" runat="server" AutoCompleteType="None" Width="60%"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/StyleLibrary/AdminStyles/Calendar_scheduleHS.png"
                                         AlternateText="Nhấn để chọn ngày khảo sát" />
                        <ajc:CalendarExtender CssClass="cal_Theme1" PopupPosition="TopLeft" PopupButtonID="Image1"
                                              SelectedDate='<%#Eval("DOB") %>' ID="cld_NgayKS" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                              TargetControlID="txt_NgaySinh" TodaysDateFormat="dd/MM/yyyy" Format="dd/MM/yyyy">
                        </ajc:CalendarExtender>
                    </td>
                    <!-- Thao tác -->
                    <td align="center" style="width: 185px;">
                        <a title="Thêm nhân viên" href="them-nhan-vien">Thêm nhân viên</a>&nbsp;|&nbsp;
                        <a title="Chỉnh sửa thông tin nhân viên" href='sua-nhan-vien?NhanVienID=<%#Eval("EmployeeID") %>'>
                            Chỉnh sửa</a> &nbsp;|&nbsp;
                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick=" if (!confirm('Bạn có chắc chắn muốn xóa nhân viên này không?')) return false; "
                                        ToolTip="Xóa nhân viên" CommandName="Delete">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr class="row0">
                    <%--Ảnh--%>
                    <td colspan="3">
                        <asp:FileUpload runat="server" ID="FileUploadControl"></asp:FileUpload>
                        <asp:Button runat="server" Text="Tải lên" ID="UploadButton" OnClick="UploadButton_Click">
                        </asp:Button>
                        <img runat="Server" id="img_anh">
                    </td>
                    <%--Alias--%>
                    <td align="center">
                        <asp:TextBox ID="txt_Alias"  Width="98%" runat="server"></asp:TextBox>
                    </dx:ASPxTextBox>
                    </td>
                    <%--Tên nhân viên--%>
                    <td>
                        <asp:TextBox ID="txt_TenNV"  Width="98%" runat="server"></asp:TextBox>
                    </td>
                    <%--Bộ phận--%>
                    <td>
                        <asp:DropDownList Width="98%" ID="ddl_Nhom" runat="server">
                        </asp:DropDownList>
                    </td>
                    <%--Chi nhánh--%>
                    <td>
                        <asp:DropDownList Width="98%" ID="ddl_ChiNhanhID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <%--NgaySinh--%>
                    <td>
                        <asp:TextBox ID="txt_NgaySinh" runat="server" AutoCompleteType="None" Width="60%"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/StyleLibrary/AdminStyles/Calendar_scheduleHS.png"
                                         AlternateText="Nhấn để chọn ngày khảo sát" />
                        <ajc:CalendarExtender CssClass="cal_Theme1" PopupPosition="TopLeft" PopupButtonID="Image1"
                                              ID="cld_NgayKS" runat="server" DaysModeTitleFormat="dd/MM/yyyy" TargetControlID="txt_NgaySinh"
                                              TodaysDateFormat="dd/MM/yyyy" Format="dd/MM/yyyy">
                        </ajc:CalendarExtender>
                    </td>
                    <!-- Thao tác -->
                    <td style="border-color: #F90; text-align: center">
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Thêm mới"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Hủy bỏ"></asp:LinkButton>
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>
    <div class="ui-widget-content ui-corner-top ui-corner-bottom" style="height: 32px; margin: 5px 0px 5px 0px; padding: 2px;">
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
    </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server">
        </td>
    </tr>
</table>