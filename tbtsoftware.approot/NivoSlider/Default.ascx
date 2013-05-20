<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Default.ascx.cs" Inherits="MinhPham.Web.BepNhaBan.NivoSlider.Default" %>
<link rel="stylesheet" href="/NivoSlider/Content/themes/default/default.css" type="text/css" media="screen" />
<link rel="stylesheet" href="/NivoSlider/Content/themes/light/light.css" type="text/css" media="screen" />
<link rel="stylesheet" href="/NivoSlider/Content/themes/dark/dark.css" type="text/css" media="screen" />
<link rel="stylesheet" href="/NivoSlider/Content/themes/bar/bar.css" type="text/css" media="screen" />
<link rel="stylesheet" href="/NivoSlider/Content/styles/nivo-slider.css" type="text/css" media="screen" />
<%--<link rel="stylesheet" href="style.css" type="text/css" media="screen" />--%>

<script type="text/javascript" src="/NivoSlider/Content/scripts/jquery-1.9.0.min.js"></script>
<script type="text/javascript" src="/NivoSlider/Content/scripts/jquery.nivo.slider.js"></script>
<script type="text/javascript" src="/NivoSlider/Content/scripts/jquery.nivo.slider.pack.js"></script>

<script type="text/javascript">
    var j = jQuery.noConflict();
    j(document).ready(function () {
        j('#slider').nivoSlider();
    });
    //$(window).load(function () {
    //    $('#slider').nivoSlider();
    //});
</script>

<div class="slider-wrapper theme-default">
    <div id="slider" class="nivoSlider">
        <img src="/NivoSlider/Content/images/toystory.jpg" data-thumb="/NivoSlider/Content/images/toystory.jpg" alt="" />
        <%--<a href="http://dev7studios.com">--%>
            <img src="/NivoSlider/Content/images/up.jpg" data-thumb="Content/images/up.jpg" alt="" title="" /><%--</a>--%>
        <img src="/NivoSlider/Content/images/walle.jpg" data-thumb="/NivoSlider/Content/images/walle.jpg" alt="" data-transition="slideInLeft" />
        <img src="/NivoSlider/Content/images/nemo.jpg" data-thumb="/NivoSlider/Content/images/nemo.jpg" alt="" title="" />
    </div>
   <%-- <div id="htmlcaption" class="nivo-html-caption">
        <strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>.
    </div>--%>
