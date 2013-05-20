<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="NhomNhanVien.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Employee.Team.NhomNhanVien" %>
<%@ Register src="NhomNhanVienUC.ascx" tagname="NhomNhanVienUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NhomNhanVienUC ID="NhomNhanVienUC1" runat="server" />
</asp:Content>