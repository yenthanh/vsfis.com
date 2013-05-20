$(document).ready(function() {
    $('#wrap').append('<div id="bttop">Về đầu trang</div>');
    $('#bttop').fadeOut();
    $(window).scroll(function() {
        if ($(window).scrollTop() != 0) {
            $('#bttop').fadeIn();
        } else {
            $('#bttop').fadeOut();
        }
    });
    $('#bttop').click(function() {
        $('html, body').animate({ scrollTop: 0 }, 500);
    });
});