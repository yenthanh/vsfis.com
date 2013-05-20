<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNavBar.ascx.cs"
            Inherits="MinhPham.Web.BepNhaBan.AppAdmin.AdminControls.AdminNavBar" %>
<link type="text/css" rel="stylesheet" href="/StyleLibrary/AdminStyles/style.css" />
<link rel="stylesheet" href="/StyleLibrary/AdminStyles/jqueryslidemenu.css"
      type="text/css" media="screen" />
<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/StyleLibrary/AdminStyles/dropdown.js"> </script>

<div style="height: 28px">
    <div id="myslidemenu" class="jqueryslidemenu">
        <asp:Repeater OnItemDataBound="repeater_OnItemDataBound" ID="repeater" runat="server">
            <HeaderTemplate>
                <ul id="nav">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:HiddenField ID="hdId" Value='<%# Eval("Id") %>' runat="server" />
                    <a class="TopMenuItem" href='<%# Eval("Link") %>'><span class="CornerLeft"></span><span class="MenuImage">
                                                                                                          <img style="height: 16px; width: 16px;" src='/StyleLibrary/AdminStyles/images/Menu/<%#Eval("ImgSrc") %>' alt="" /></span><span class="MenuText"><%#Eval("Name") %></span> <span class="Arrow"></span><span
                                                                                                                                                                                                                                                                                                                  class="CornerRight"></span></a>
                    <asp:Repeater ID="repeaterChild" runat="server">
                        <HeaderTemplate>
                            <ul style="display: none; left: 0px; visibility: visible; width: 207px;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li class="SubFirst"><a href='<%#Eval("Link") %>'><span class="SubMenuText"><strong><%#Eval("Name") %></strong> <span><%#Eval("Descript") %></span>
                                                                              </span></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                        </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </li>
            </ItemTemplate>
            <FooterTemplate>
            </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="float: right; padding: 8px 0px;">
        <a href="/Default.aspx">Website</a> |<a href="/AppAdmin/Default.aspx">Trang chủ</a> <%--| Chào mừng:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        &nbsp;&nbsp;<a href="dang-xuat">[Thoát]</a>&nbsp;&nbsp;&nbsp;&nbsp;
    </div>

</div>
<div style="background-color: #05386D; height: 5px; width: 100%;">
</div>