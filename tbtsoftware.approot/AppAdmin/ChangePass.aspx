<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.ChangePass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="/StyleLibrary/AdminStyles/login.css" rel="stylesheet" type="text/css" />
    </head>
    <body style="background-color: #E3FEE2">
        <form id="form1" runat="server">
            <div id="iRightAccess" runat="Server" style="height: 100%; width: 100%;">
                <div class="login_navi">
                    <img src="/StyleLibrary/RootStyles/Images/header/logo.png">
                    <div class="tbl_getpass">
                        <div class="row1">
                            <span>Mật khẩu:</span>
                            <asp:TextBox ID="txt_MatKhau" CssClass="input_form" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="row1">
                            <span>Nhập lại:</span>
                            <asp:TextBox ID="txt_NhapLai" CssClass="input_form" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:Label ID="lbl_Notice" runat="server" ForeColor="#CC0000"></asp:Label>
                        <div style="margin-top: 0px;" class="row2">
                            <div class="buttons">
                                <asp:LinkButton ID="btn_ChangePass" runat="server" CssClass="positive" 
                                                onclick="btn_ChangePass_Click" > <img src="/StyleLibrary/AdminStyles/images/Login/textfield_key.png" alt=""/>Đổi mật khẩu</asp:LinkButton>
                                <a class="positive" onclick=" tb_remove(); ">
                                    <img src="/StyleLibrary/AdminStyles/images/Login/back-alt-icon.png" alt="" />Quay
                                    lại</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td id="idNotPermissionAccess" runat="server">
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>