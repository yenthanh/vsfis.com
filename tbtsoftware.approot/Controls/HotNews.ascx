<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HotNews.ascx.cs" Inherits="MinhPham.Web.BepNhaBan.HotNews" %>
<link rel="stylesheet" href="../StyleLibrary/RootStyles/NivoThemes/default/default.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../StyleLibrary/RootStyles/NivoThemes/orman/pascal.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../StyleLibrary/RootStyles/NivoThemes/pascal/orman.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../StyleLibrary/RootStyles/Css/nivo-slider.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../StyleLibrary/RootStyles/Css/style.css" type="text/css" media="screen" />
<div id="wrapper" style="width: 618px">
    <div class="slider-wrapper theme-default">
        <div class="ribbon">
        </div>
        <div id="slider" class="nivoSlider">
            <img src="../StyleLibrary/RootStyles/Images/Hotnews/toystory.jpg" alt="" />
            <a href="http://dev7studios.com">
                <img src="../StyleLibrary/RootStyles/Images/Hotnews/up.jpg" alt="" title="This is an example of a caption" /></a>
            <img src="../StyleLibrary/RootStyles/Images/Hotnews/walle.jpg" alt="" data-transition="slideInLeft" />
            <img src="../StyleLibrary/RootStyles/Images/Hotnews/nemo.jpg" alt="" title="#htmlcaption" />
        </div>
        <div id="htmlcaption" class="nivo-html-caption">
            <strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>.
        </div>
    </div>
</div>
<script type="text/javascript" src="../StyleLibrary/RootStyles/Scripts/jquery-1.7.1.min.js"> </script>
<script type="text/javascript" src="../StyleLibrary/RootStyles/Scripts/jquery.nivo.slider.pack.js"> </script>
<script type="text/javascript">
    $(window).load(function() {
        $('#slider').nivoSlider();
    });
</script>