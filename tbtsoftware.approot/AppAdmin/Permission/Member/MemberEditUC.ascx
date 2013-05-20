<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberEditUC.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member.MemberEditUC" %>
<link href="/StyleLibrary/AdminStyles/jquery-ui.css" rel="stylesheet" type="text/css" />
<div runat="server" id="iRightAccess">
    <div class="ui-widget-content ui-corner-top ui-corner-bottom">
        <div id="toolbox">
            <div class="header" style="float: left;">
                <img src="/StyleLibrary/AdminStyles/icon-48-generic.png" style="border-width: 0px;" />
                <span>Thêm mới thành viên</span>
            </div>
            <div style="float: right;">
                <table class="toolbar">
                    <tr>
                        <td align="center">
                            <%-- <asp:LinkButton ID="lbtnHelp" runat="server" CssClass="toolbar"><span title="Help" class="Icon-32-Help"></span>Trợ giúp</asp:LinkButton>--%>
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
    <div id="tabs" runat="server" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
        <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
            <li class="ui-corner-top ui-tabs-selected ui-state-active"><a href="#tabs-1">Thông tin
                                                                           chung</a></li>
        </ul>
        <div id="tabs-1">
            <table class="admintable" style="width: 100%;">
                <!-- Nhóm thành viên -->
                <tr>
                    <td class="key" style="width: 150px;">
                        <span class="Required">*</span> Nhóm thành viên
                    </td>
                    <td>
                        <asp:ListBox ID="lb_Nhom" runat="server" Rows="5" Width="213px"></asp:ListBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Nhóm thành viên</p>
                                                  <p class="tooltipmessage">
                                                      Quản trị nội dung, quản trị website...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!-- Tên đăng nhập -->
                <tr>
                    <td class="key" style="width: 150px;">
                        <span class="Required">*</span> Tên đăng nhập
                    </td>
                    <td>
                        <asp:TextBox CssClass="textbox" ID="txtUserName" runat="server" Width="208px"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Tên đăng nhập</p>
                                                  <p class="tooltipmessage">
                                                      VD: Admin, minhpd,dungpt...
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!-- Mật khẩu -->
                <%--   <tr>
                    <td class="key">
                        <span class="Required">*</span> Mật khẩu
                    </td>
                    <td>
                        <asp:TextBox CssClass="textbox" ID="txtPassword" runat="server" Width="208px" TextMode="Password"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                            <p class="tooltiptitle">
                                Mật khẩu</p>
                            <p class="tooltipmessage">
                                VD: abc@1234...
                            </p>
                        </span></span>
                    </td>
                </tr>--%>
                <!-- Nhập lại mật khẩu -->
                <%--            <tr>
                    <td class="key">
                        <span class="Required">*</span> Mật khẩu nhập lại
                    </td>
                    <td>
                        <asp:TextBox CssClass="textbox" ID="txtRePassword" runat="server" Width="208px" TextMode="Password"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                            <p class="tooltiptitle">
                                Mật khẩu</p>
                            <p class="tooltipmessage">
                                VD: abc@1234...
                            </p>
                        </span></span>
                    </td>
                </tr>--%>
                <!-- Kích hoạt -->
                <tr>
                    <td class="key">
                        Kích hoạt
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" Text="Cho phép" />
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Kích hoạt tài khoản</p>
                                                  <p class="tooltipmessage">
                                                      Lựa chọn để kích hoạt tài khoản hoạt động
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!-- Họ tên -->
                <tr>
                    <td class="key">
                        Họ tên
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Họ tên thành viên</p>
                                                  <p class="tooltipmessage">
                                                      VD: Phạm Đức Minh
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!-- Địa chỉ -->
                <tr>
                    <td class="key">
                        Địa chỉ
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Địa chỉ</p>
                                                  <p class="tooltipmessage">
                                                      VD: 109 Nguyễn Bình - Quảng Yên - Quảng Ninh
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Giới tính-->
                <tr>
                    <td class="key">
                        Giới tính
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLSex" runat="server">
                            <asp:ListItem Value="0">Nam</asp:ListItem>
                            <asp:ListItem Value="1">Nữ</asp:ListItem>
                        </asp:DropDownList>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Địa chỉ</p>
                                                  <p class="tooltipmessage">
                                                      VD: 109 Nguyễn Bình - Quảng Yên - Quảng Ninh
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Cơ quan-->
                <tr>
                    <td class="key">
                        Cơ quan
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Cơ quan</p>
                                                  <p class="tooltipmessage">
                                                      VD: Phòng Kinh doanh..
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Chức vụ-->
                <tr>
                    <td class="key">
                        Chức vụ
                    </td>
                    <td>
                        <asp:TextBox ID="txtPosi" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Chức vụ</p>
                                                  <p class="tooltipmessage">
                                                      VD: Trưởng Phòng Kinh doanh..
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Email-->
                <tr>
                    <td class="key">
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Email</p>
                                                  <p class="tooltipmessage">
                                                      VD: minhpd@bepnhaban.vn
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Điện thoại di động-->
                <tr>
                    <td class="key">
                        Điện thoại di động
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobi" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Điện thoại di động</p>
                                                  <p class="tooltipmessage">
                                                      VD: 0936.605.886
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Điện thoại cố định-->
                <tr>
                    <td class="key">
                        Điện thoại cố định
                    </td>
                    <td>
                        <asp:TextBox ID="txtTel" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Điện thoại cố định</p>
                                                  <p class="tooltipmessage">
                                                      VD: (033) 3602606
                                                  </p>
                                              </span></span>
                    </td>
                </tr>
                <!--Fax-->
                <tr>
                    <td class="key">
                        Fax
                    </td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" Width="208px" CssClass="textbox"></asp:TextBox>
                        <span class="tooltip"><span class="tooltipContent">
                                                  <p class="tooltiptitle">
                                                      Fax</p>
                                                  <p class="tooltipmessage">
                                                      VD: (033) 3602606
                                                  </p>
                                              </span></span>
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