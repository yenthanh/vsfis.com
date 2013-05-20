<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="MemberGroupEdit.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien.MemberGroupEdit" %>


<%@ Register src="MemberGroupEditUC.ascx" tagname="MemberGroupEditUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MemberGroupEditUC ID="MemberGroupEditUC1" runat="server" />
</asp:Content>