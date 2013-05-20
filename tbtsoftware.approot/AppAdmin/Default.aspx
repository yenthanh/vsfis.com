<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Default" %>
<%@ Register src="AdminControls/AdminHome.ascx" tagname="AdminHome" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:AdminHome ID="AdminHome1" runat="server" />
</asp:Content>