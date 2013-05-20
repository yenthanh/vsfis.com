<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member.Index" %>
<%@ Register src="MemberListUC.ascx" tagname="MemberListUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MemberListUC ID="MemberListUC1" runat="server" />
</asp:Content>