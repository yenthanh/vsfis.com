<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="MemberAdd.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member.MemberAdd" %>
<%@ Register src="MemberAddUC.ascx" tagname="MemberAddUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MemberAddUC ID="MemberAddUC1" runat="server" />
</asp:Content>