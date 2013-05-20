<%@ Page Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Article.Index" %>
<%@ Register src="IndexUC.ascx" tagname="IndexUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:IndexUC ID="IndexUC1" runat="server" />
</asp:Content>