$('#ajaxLoader').hide()
    .ajaxStart(function (e) {
        $(this).show();
    })
    .ajaxStop(function (e) {
        $(this).hide();
    });

$(function () {
    $(this).ajaxError(function (event, request) {
        if (request.status == 530) {
            window.location = request.response;
        }
        else if (request.status == 0) {
        }
        else {
            alert(request.responseText);
        }
    });
});