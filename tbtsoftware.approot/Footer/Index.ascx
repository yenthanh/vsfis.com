<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index.ascx.cs"
    Inherits="MinhPham.Web.BepNhaBan.Footer.Index" %>
<link href="/Footer/Content/Footer.css" rel="stylesheet" />
<div id="footer">
    <div id="footer-content">
        <div id="headquarter">
            <div class="head-name" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="head-name" style="color: Red; text-align: center;">
               <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> <a href='/AppAdmin/Login.aspx'>&nbsp;</a>
            </div>
           
        </div>
        <div id="agent-system">
            <div class="system1">
                <div class="system1-name">
                 <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="add1">
                    <p>
                           <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
           
            <div class="system1">
                <div class="system1-name">
                         <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="add1">
                    <p>
                         <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p>
                         <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
