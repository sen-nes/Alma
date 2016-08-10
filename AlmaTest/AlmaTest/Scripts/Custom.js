$(document).ready(function () {
    //$(window).scroll(sticky_relocate);
    clientSelect();
    clientsAutocomplete();
    $("#addBtn").bind('click', setModal);
});

function check(event) {

    if (event != null) {
        console.log("Module " + event.target.id + " was checked");
    }
}

function clientSelect() {
    $("#clients tbody tr")
        .mouseout(function () {
            $(this).css({ 'cursor': 'pointer'});
        })
        .bind('click', function () {
            var id = $(this).attr('id');

            $("tbody .active").removeClass('active');
            $(this).addClass('active');

            $.ajax({
                type: "GET",
                url: "/api/Clients/" + id,
                success: function (clientJson) {
                    showDetails(clientJson);
                },
                error: function (errorMessage) {
                    alert(errorMessage.responseText);
                },
                complete: function () {
                    $("#details").removeClass("hidden");
                }
            });
        });
};

function sticky_relocate() {
    var window_top = $(window).scrollTop();
    var div_top = $('#the-stick-anchor').offset().top;
    if (window_top + 61 >= div_top) {
        $('#the-stick').addClass('');
        $('#the-sticky').show();
    }
    else {
        $('#the-stick').removeClass('');
        $('#the-sticky').hide();
    }
}

function showDetails(client) {
    $("#name").text(client.Client);
    $("#database").text(client.Baza);
    var date = new Date(parseInt(client.Date.substr(6)));
    $("#date").text(date.toLocaleDateString());
    $("#host").text(client.HostName);
    var modules = decodeModules(client.Modules);
    for (var i = 0; i < 32; i++) {
        if (modules[i]) {
            $(("#module" + (i + 1))).prop('checked', true);
        } else {
            $(("#module" + (i + 1))).prop('checked', false);
        }
    }
    $("#note").text(client.Note);
    $("#firmi").text(client.Firmi);
    if (client.AccOffice) {
        $("#accOffice").prop('checked', true);
    } else {
        $("#accOffice").prop('checked', false);
    }
    $("#rabMesta").text(client.RabMesta);
    $("#progKey").text(client.ProgKey);
    $("#pass").text(client.Pass);
}

function clientsAutocomplete() {
    $.ajax({
        type: "GET",
        url: "/api/Clients",
        success: function (names) {
            $("#client-name").autocomplete({
                source: names
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function decodeModules(modulesBinary) {
    var modules = [];
    for(var i = 0; i < 32; i++)
    {
        modules[i] = (modulesBinary & Math.pow(2, i)) != 0;
    }

    return modules;
}

function encodeModules() {
    var modulesBinary = 0;
    var current = false;

    for (var i = 1; i <= 32; i++) {
        current = $("#module" + i).prop("checked");
        if (current === true) {
            modulesBinary += Math.pow(2, i - 1);
        }
    }

    return modulesBinary;
}

function editPanel() {
    var text = "";

    text = $("#name").text();
    $("#name").replaceWith('<input type="text" id="name" class="form-control" value="' + text + '" />');

    text = $("#database").text();
    $("#database").replaceWith('<input type="text" id="database" class="form-control" value="' + text + '" />');

    text = $("#date").text();
    $("#date").replaceWith('<input type="date" id="date" class="form-control" value="' + text + '" />');

    text = $("#host").text();
    $("#host").replaceWith('<input type="text" id="name" class="form-control" value="' + text + '" />');

    text = $("#note").text();
    $("#note").replaceWith('<input type="text" id="name" class="form-control" value="' + text + '" />');

    text = $("#firmi").text();
    $("#firmi").replaceWith('<input type="number" id="name" class="form-control" value="' + text + '" />');
    $("#accOffice").prop("disabled", false);

    text = $("#rabMesta").text();
    $("#rabMesta").replaceWith('<input type="number" id="name" class="form-control" value="' + text + '" />');

    $("#progKey").replaceWith('<input type="text" id="name" class="form-control" />');

    $("#pass").replaceWith('<input type="text" id="name" class="form-control" disabled="true" />');

    for (var i = 1; i <= 32; i++) {
        $("#" + i).prop("disabled", false);
    }

    $("#addBtn").replaceWith('<button type="submit" class="btn btn-primary" id="requestPass">' + 'Поискай парола' + '</button>')
}

function generateCheckboxes() {
    var html = "";
    $.ajax({
        type: "GET",
        url: '/api/Modules',
        success: function (modules) {
            for (var i = 1; i <= 16; i++) {
                html += '<div class="row">';
                html += '<div class="col-sm-6">';
                html += '<div class="checkbox">';
                html += '<label>';
                html += '<input type="checkbox" id="newModule' + i + '" /> ' + modules[i - 1];
                html += '</label>';
                html += '</div>';
                html += '</div>';

                html += '<div class="col-sm-6">';
                html += '<div class="checkbox">';
                html += '<label>';
                html += '<input type="checkbox" id="newModule' + (i + 16) + '" /> ' + modules[i + 15];
                html += '</label>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
            }
            console.log(html);
            return html;
        },
        error: function () {
            alert("ERROR");
        },
        complete: function () {
        }
    });
}

function setModal() {
    $("#newName").val($("#name").text());
    $("#newDatabase").val($("#database").text());

    var date = new Date($("#date").text());
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var htmlDateString = date.getFullYear() + "-" + (month) + "-" + (day);

    $("#newDate").val(htmlDateString);
    $("#newNote").val($("#note").text());
    $("#newFirmi").val($("#firmi").text());
    $("#newAccOffice").val($("#accOffice").text());
    $("#newRabMesta").val($("#rabMesta").text());
    $("#newProgKey").val("");
    $("#newPass").val("");
    $("#newHost").val($("#host").text());
    for (var i = 1; i <= 32; i++) {
        var checked = $("#module" + i).prop('checked');
        $("#newModule" + i).prop('checked', checked);
    }
}