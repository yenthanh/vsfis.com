<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="MemberEdit.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Permission.Member.MemberEdit" %>
<%@ Register src="MemberEditUC.ascx" tagname="MemberEditUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MemberEditUC ID="MemberEditUC1" runat="server" />
</asp:Content>