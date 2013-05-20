<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">

        <link href="/StyleLibrary/AdminStyles/login.css" rel="stylesheet" type="text/css" />
    </head>
    <body class="epi-loginBody">
        <form id="form1" runat="server">
            <div class="epi-loginContainer">
                <div class="epi-loginContent">
                    <div class="epi-loginLogo">V-SFIS Co.,Ltd</div>
                    <div class="epi-credentialsContainer">
                        <div class="epi-float-left">
                            <label class="episize80">Name</label><br>
                                                                 <asp:TextBox ID="txtUserName" CssClass="epi-inputText" runat="server"></asp:TextBox>
                                                                 <span style="display: none;">­</span>
                        </div>
                        <div class="epi-float-left">
                            <label class="episize80">Password</label><br>
                                                                     <asp:TextBox ID="txtPassword" CssClass="epi-inputText" runat="server" TextMode="Password"></asp:TextBox>
                            </asp:RequiredFieldValidator>
                       
                                                                     <span style="display: none;">­</span>
                        </div>
                        <div class="buttons">
                            <asp:LinkButton ID="Button1" runat="server" CssClass="positive" OnClick="bntLogin_Click">
                                <img src="/StyleLibrary/AdminStyles/images/Login/textfield_key.png" alt=""/>Đăng nhập
                            </asp:LinkButton>
                            <a class="positive" href="Default.aspx">
                                <img src="/StyleLibrary/AdminStyles/images/Login/back-alt-icon.png" alt="" />Quay lại</a>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>