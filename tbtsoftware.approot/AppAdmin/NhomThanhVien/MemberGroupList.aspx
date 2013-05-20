<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="MemberGroupList.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.NhomThanhVien.MemberGroupList" %>
<%@ Register src="MemberGroupListUC.ascx" tagname="MemberGroupListUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:MemberGroupListUC ID="MemberGroupListUC1" runat="server" />

</asp:Content>