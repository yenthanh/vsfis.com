<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/AppAdmin/AdminHome.Master" ValidateRequest="false"  Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Article.Edit" %>
<%@ Register src="EditUC.ascx" tagname="EditUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EditUC ID="EditUC1" runat="server" />
</asp:Content>