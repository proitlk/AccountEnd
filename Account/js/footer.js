$(document).ready(function() {
    var height = $(window).height();
    var footer = $('.footer').height();
    var footerTop = $('.footer').position().top + footer;
    if (footerTop < height) {
        $('.footer').css('margin-top', -1 + (height - footerTop) + 'px');
    }
    console.log("height:" + height + "  footer height:" + footer + "  footerTop:" + footerTop);
});