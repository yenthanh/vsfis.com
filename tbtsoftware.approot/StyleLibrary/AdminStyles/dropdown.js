$(document).ready(function() {

    $("#nav li").hover(function() {

        $(this).find('ul:first').css({ visibility: "visible", display: "none" }).show();
    }, function() {
        $(this).find('ul:first').css({ visibility: "hidden" });
    });
});