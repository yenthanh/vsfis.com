<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="ThuongHieu.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.ThuongHieu.ThuongHieuPage" %>
<%@ Register src="ThuongHieuUC.ascx" tagname="ThuongHieuUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ThuongHieuUC ID="ThuongHieuUC1" runat="server" />
</asp:Content>