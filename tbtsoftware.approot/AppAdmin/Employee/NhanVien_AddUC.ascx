<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhanVien_AddUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Employee.NhanVien_AddUC" %>
<link href="../../StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../StyleLibrary/AdminStyles/Popup.css" rel="stylesheet" type="text/css" />
<script src="../../StyleLibrary/AdminStyles/Popup.js" type="text/javascript"> </script>
<div id="iRightAccess" runat="server">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img src="../../StyleLibrary/AdminStyles/icon-48-generic.png" style="border-width: 0px;" />
                <span>
                    <asp:Label ID="lbl_Title" runat="server" Text="Label"></asp:Label></span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <%--<asp:LinkButton ID="lbtnHelp" runat="server" CssClass="toolbar"><span title="Help" class="Icon-32-Help"></span>Trợ giúp</asp:LinkButton>--%>
                            <asp:LinkButton ID="lbtnPublish" runat="server" CssClass="toolbar" OnClick="lbtnPublish_Click"><span title="Help" class="Icon-32-Publish"></span>Lưu và Thêm mới</asp:LinkButton>
                            <asp:LinkButton ID="lbtnSave" CssClass="toolbar" runat="server" OnClick="lbtnSave_Click"><span title="Save" class="Icon-32-Save"></span>Lưu</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; " CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltr_Notice" runat="server"></asp:Literal>
    <div id="tabs1" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
        <div id="tabs-1" class="ui-tabs-panel ui-widget-content ui-corner-bottom">
            <table class="admintable" width="100%">
                <tr>
                    <td style="height: 5px;">
                    </td>
                </tr>
                <!-- Alias -->
                <tr>
                    <td class="key" style="width: 125px;">
                        <span class="Required">*</span>&nbsp;Mã nhân viên
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Alias" runat="server" MaxLength="500" CssClass="TextInput" Width="170px"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Mã nhân viên</p>
                                                  <p class="tooltipmessage">
                                                      VD: NV0001...
                                                  </p>
                                              </span></span>
                    </td>
                    <td rowspan="7">
                        <img src="" runat="server" id="img_AnhNhanVien" />
                    </td>
                </tr>
                <!--HoTen -->
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Họ tên
                    </td>
                    <td>
                        <asp:TextBox ID="txt_HoTen" runat="server" MaxLength="500" CssClass="TextInput" Width="170px"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Họ tên</p>
                                                  <p class="tooltipmessage">
                                                      VD: Nguyễn Văn A...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--ID-->
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Bộ phận
                    </td>
                    <td>
                        <asp:ListBox ID="lb_NhomNV" runat="server" Rows="10" Width="175px"></asp:ListBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Bộ phận</p>
                                                  <p class="tooltipmessage">
                                                      VD: Phòng kinh doanh...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Chi nhánh-->
                <tr>
                    <td class="key">
                        <span class="Required">*</span>&nbsp;Chi nhánh
                    </td>
                    <td>
                        <asp:ListBox ID="lb_ChiNhanh" runat="server" Rows="10" Width="175px"></asp:ListBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Chi nhánh</p>
                                                  <p class="tooltipmessage">
                                                      VD: Chi nhánh 1...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--NgaySinh -->
                <tr id="tr_GiaNhap">
                    <td class="key">
                        Ngày sinh
                    </td>
                    <td>
                        <asp:TextBox ID="txt_NgaySinh" runat="server" AutoCompleteType="None" Width="100px"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/StyleLibrary/AdminStyles/Calendar_scheduleHS.png"
                                         AlternateText="Nhấn để chọn ngày sinh" />
                        <ajc:CalendarExtender CssClass="cal_Theme1" PopupPosition="TopLeft" PopupButtonID="Image1"
                                              ID="cld_NgayKS" runat="server" DaysModeTitleFormat="dd/MM/yyyy" TargetControlID="txt_NgaySinh"
                                              TodaysDateFormat="dd/MM/yyyy" Format="dd/MM/yyyy">
                        </ajc:CalendarExtender>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Ngày sinh nhân viên</p>
                                                  <p class="tooltipmessage">
                                                      VD: 12/31/1982...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--GioiTinh-->
                <tr>
                    <td class="key">
                        Giới tính
                    </td>
                    <td>
                        <asp:DropDownList Width="70px" ID="ddl_GioiTinh" runat="server">
                            <asp:ListItem Value="True">Nam</asp:ListItem>
                            <asp:ListItem Value="False">Nữ</asp:ListItem>
                        </asp:DropDownList>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Lựa chọn giới tính</p>
                                                  <p class="tooltipmessage">
                                                      VD: Nam, nữ...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!-- Hình ảnh -->
                <tr>
                    <td class="key">
                        Hình ảnh
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="FileUploadControl"></asp:FileUpload>
                        <asp:Button runat="server" Text="Tải lên" ID="UploadButton" OnClick="UploadButton_Click">
                        </asp:Button>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Hình ảnh nhân viên</p>
                                                  <p class="tooltipmessage">
                                                      VD: NV0001...
                                                  </p>
                                              </span></span>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td id="idNotPermissionAccess" runat="server">
        </td>
    </tr>
</table>