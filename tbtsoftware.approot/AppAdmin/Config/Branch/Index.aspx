<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Config.Branch.Index" %>
<%@ Register src="BranchUC.ascx" tagname="BranchUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BranchUC ID="BranchUC1" runat="server" />
</asp:Content>