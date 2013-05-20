<%@ Page Title="" Language="C#" MasterPageFile="~/AppAdmin/AdminHome.Master" AutoEventWireup="true" CodeBehind="HistoryLogin.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.AdminHistoryLog.HistoryLogin" %>
<%@ Register src="HistoryLoginUC.ascx" tagname="HistoryLoginUC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HistoryLoginUC ID="HistoryLoginUC1" runat="server" />
</asp:Content>