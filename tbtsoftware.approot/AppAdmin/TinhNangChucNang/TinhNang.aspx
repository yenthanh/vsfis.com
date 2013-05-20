<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="TinhNang.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang.TinhNang" %>
<%@ Register src="TinhNangUC.ascx" tagname="TinhNangUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TinhNangUC ID="TinhNangUC1" runat="server" />
</asp:Content>