<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderBar_Simple.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.HeaderBar_Simple" %>
<link type="text/css" href="/StyleLibrary/RootStyles/Css/HeaderBar_Simple.css"
      rel="stylesheet" />
<div class="searchBox">
    <div class="searchBox-bg">
  
        <asp:TextBox ID="txt_TimKiem" CssClass="search-txt" runat="server"></asp:TextBox>
        <asp:LinkButton  ID="lbtn_TK" CssClass="search-btn" runat="server" 
                         onclick="lbtn_TK_Click">
            <img src="/StyleLibrary/RootStyles/Images/HeaderBar_Simple/btnSearch.gif" />
        </asp:LinkButton>
    </div>
</div>