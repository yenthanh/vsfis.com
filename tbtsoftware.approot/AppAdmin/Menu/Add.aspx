<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs"  MasterPageFile="~/AppAdmin/AdminHome.Master" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Config.Menu.Add" %>
<%@ Register src="AddUC.ascx" tagname="AddUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddUC ID="AddUC1" runat="server" />
</asp:Content>