<%@ Page Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="NhanVien_View.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Employee.NhanVien_View" %>
<%@ Register src="NhanVien_ViewUC.ascx" tagname="NhanVien_ViewUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NhanVien_ViewUC ID="NhanVien_ViewUC1" runat="server" />
</asp:Content>