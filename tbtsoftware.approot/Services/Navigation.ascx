<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs"
    Inherits="MinhPham.Web.BepNhaBan.Services.Navigation" %>
<link href="/Services/Content/Services.css" rel="stylesheet" />
<div class="block block-category-navigation">
    <div class="title">
        <strong>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </strong>
    </div>
    <div class="clear">
    </div>
    <div class="listbox">
        <asp:Repeater ID="repeater" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="inactive">
                    <a href='/Default.aspx?id=<%# Eval("Name")%>&cate=s'><%# Eval("LocaleValue") %>
        </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
