<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="TinhNangChucNang.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.TinhNangChucNang.TinhNangChucNang" %>
<%@ Register src="TinhNangChucNangUC.ascx" tagname="TinhNangChucNangUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TinhNangChucNangUC ID="TinhNangChucNangUC1" runat="server" />
</asp:Content>