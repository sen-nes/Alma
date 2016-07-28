$(document).ready(function () {
    // $('#the-sticky').load('/Home/About');
    $(window).scroll(sticky_relocate);
    ulHover();
});

function ulHover() {
    $("#table ul")
        .mouseover(function () {
            $(this).css({ 'cursor': 'pointer', 'background-color': '#AED6F1' });
        })
        .mouseout(function () {
            $(this).css({ 'cursor': 'pointer', 'background-color': '' });
        })
        //.bind('click', function () {
            
        //});

};

function sticky_relocate() {
    var window_top = $(window).scrollTop();
    var div_top = $('#the-stick-anchor').offset().top;
    if (window_top + 61 >= div_top) {
        $('#the-stick').addClass('sticky');
        //$('#the-sticky').show();
    }
    else {
        $('#the-stick').removeClass('sticky');
        //$('#the-sticky').hide();
    }
}

function dropdwn(target, id) {
    if ($('#drop' + id).length) {
        $('#drop' + id).remove();
    } 
    else {
        $(target).after('<div id=drop' + id + '> <h1>' + id + '</h1> </div>');
    }
}

