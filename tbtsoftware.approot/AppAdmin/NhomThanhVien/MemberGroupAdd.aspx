<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="MemberGroupAdd.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien.MemberGroupAdd" %>
<%@ Register src="MemberGroupAddUC.ascx" tagname="MemberGroupAddUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MemberGroupAddUC ID="MemberGroupAddUC1" runat="server" />
</asp:Content>