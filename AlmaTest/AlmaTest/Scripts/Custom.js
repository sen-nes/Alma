var ajaxRequest;

$(document).ready(function () {
    $(window).scroll(sticky_relocate);
    clientSelect();
    testingAjax();
});

function clientSelect() {
    $("#clients tbody tr")
        .mouseout(function () {
            $(this).css({ 'cursor': 'pointer' });
        })
        .bind('click', function () {
            var id = $(this).attr('id');

            ajaxFunction();
            $.ajax({
                type: "GET",
                url: "/api/Client/" + id,
                success: function (text) {
                    $("#name").text(text.Client);
                    $("#database").text(text.Baza);
                    $("#date").text(text.Date);
                    $("#host").text(text.HostName);

                    $("#details").removeClass("hidden");
                },
                error: function () {
                    $("#details").addClass("hidden");
                    alert("error");
                },
                complete: function () {
                }
            });
        });
};

function sticky_relocate() {
    var window_top = $(window).scrollTop();
    var div_top = $('#the-stick-anchor').offset().top;
    if (window_top + 61 >= div_top) {
        $('#the-stick').addClass('sticky');
        $('#the-sticky').show();
    }
    else {
        $('#the-stick').removeClass('sticky');
        $('#the-sticky').hide();
    }
}

function details(target, id) {
    
}

function ajaxFunction() {
    try {
        ajaxRequest = new XMLHttpRequest();
    } catch (e) {
        try {
            ajaxRequest = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                ajaxRequest = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                console("Your browser broke!")

                return false;
            }
        }
    }
}

function testingAjax() {
    ajaxFunction();

    $.ajax({
        type: "GET",
        url: "/api/ClientNames",
        success: function (names) {
            $("#client-name").autocomplete({
                source: names
            });
        },
        error: function () {
            alert("error");
        },
        complete: function () {
        }
    });
}