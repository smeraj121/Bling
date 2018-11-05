$(window).load(() => {
    $('.picContainer').children().map((i, e) => {
        var newheight = $($($(e).children()[0]).children()[0]).width() - $($($(e).children()[0]).children()[0]).siblings().height();
        $($($(e).children()[0]).children()[0]).height(newheight + "px");
        //$($(e).children()[0]).height($($(e).children()[0]).width());
        if (newheight < ($($($($(e).children()[0]).children()[0]).children()[0]).height())) {
            $($($($(e).children()[0]).children()[0]).children()[0]).height('-webkit-fill-available');
        }
        else {
            $($($(e).children()[0]).children()[0]).addClass('photocontainer')
        }
    });
    function swapsiblings() {
        var src = $($(event.target).siblings()[0]).val();
        $($(event.target).siblings()[0]).val($(event.target).attr('src'));
        $(event.target).attr('src', src);
    }
    $('.thumbnails').hover(swapsiblings, swapsiblings);
})
/* $($($(e).children()[0]).children()[0]).height($($($(e).children()[0]).children()[0]).width())*/