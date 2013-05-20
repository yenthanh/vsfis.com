<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AboutUs.Master" CodeBehind="BanDoDuongDi.aspx.cs"
         Inherits="MinhPham.Web.BepNhaBan.BanDoDuongDi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('a[href^=ban-do-duong-di]').addClass('active');
        });
    </script>
    <div id="bando">
        <iframe width="725" height="500" frameborder="0" scrolling="no" marginheight="0"
                marginwidth="0" src="https://maps.google.com/maps/ms?msa=0&amp;msid=201459066619711705751.0004c2e639df55d29a517&amp;ie=UTF8&amp;t=h&amp;source=embed&amp;ll=20.958394,106.833286&amp;spn=0.080152,0.124283&amp;z=13&amp;iwloc=0004c2e68a8f0069586ef&amp;output=embed">
        </iframe>
        <br />
        <small>Xem <a href="https://maps.google.com/maps/ms?msa=0&amp;msid=201459066619711705751.0004c2e639df55d29a517&amp;ie=UTF8&amp;t=h&amp;source=embed&amp;ll=20.958394,106.833286&amp;spn=0.080152,0.124283&amp;z=13&amp;iwloc=0004c2e68a8f0069586ef"
                      style="color: #0000FF; text-align: left">BẾP NHÀ BẠN </a>ở bản đồ lớn hơn</small>
    </div>
</asp:Content>