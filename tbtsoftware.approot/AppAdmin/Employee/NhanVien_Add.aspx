<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NhanVien_Add.aspx.cs" MasterPageFile="~/AppAdmin/AdminHome.Master"  Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Employee.NhanVien_Add" %>
<%@ Register src="NhanVien_AddUC.ascx" tagname="NhanVien_AddUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NhanVien_AddUC ID="NhanVien_AddUC1" runat="server" />
</asp:Content>