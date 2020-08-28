$(document).ready(function () {

    $('ul.switcher li').click(function () {
        var tab_id = $(this).attr('data-tab');

        $('li').removeClass('active');
        $('div.tab-pane').removeClass('active');

        $(this).addClass('active');
        $("#" + tab_id).addClass('active');
    })

});

$(function () {
    $("#txtUsuarioOp").keydown(function (event) {
        //alert(event.keyCode);
        if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode !== 190 && event.keyCode !== 110 && event.keyCode !== 8 && event.keyCode !== 9) {
            return false;
        }
    });
});

