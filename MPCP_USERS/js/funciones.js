
$(document).ready(function () {
    $('.sidenav').sidenav();
});

$(document).ready(function () {
    $('.datepicker').datepicker();
});

$(document).ready(function () {
    $('.tabs').tabs();
});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.datepicker');
    //var instances = M.Datepicker.init(elems, options);
});

$(document).ready(function () {
    $('.timepicker').timepicker();
});

$(document).ready(function () {
    $('select').formSelect();
});

$(function () {
    $("#txtUsuarioOp").keydown(function (event) {
        //alert(event.keyCode);
        if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode !== 190 && event.keyCode !== 110 && event.keyCode !== 8 && event.keyCode !== 9) {
            return false;
        }
    });
});

$(function () {
    $("#txtUsuarioSop").keydown(function (event) {
        //alert(event.keyCode);
        if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode !== 190 && event.keyCode !== 110 && event.keyCode !== 8 && event.keyCode !== 9) {
            return false;
        }
    });
});

//GRAFICA DE CONCERNS ABIERTOS

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {

    var num1 = parseInt($('#lblPrefab').text());
    var num2 = parseInt($('#lblEfff').text());
    var num3 = parseInt($('#lblCyf').text());
    var num4 = parseInt($('#lblHi').text());
    var num5 = parseInt($('#lblCnc').text());
    var num6 = parseInt($('#lblPwt').text());



    var data = google.visualization.arrayToDataTable([['Task', 'Hours per Day'], ['PREFABRICADO', num1]
        , ['ENSAMBLE FINAL', num2], ['CORTE Y FORMADO', num3], ['HORNO E INSERCION', num4], ['CNC', num5], ['POWER TRAIN', num6]]);

    var options = { "title": "", "backgroundColor": { "fill": "#FFFFFF" }, "is3D": true, "pieHole": 0, "fontSize": 15.09684149667559, "pieSliceTextStyle": { "color": "#FFFFFF" }, "sliceVisibilityThreshold": false, "legend": { "position": "labeled", "textStyle": { "color": "#000000", "fontSize": 15.920540954966505 } }, "tooltip": { "textStyle": { "color": "#000000" }, "showColorCode": true }, "colors": ["#b71c1c", "#1b5e20", "#1a237e", "#616161", "#1e88e5", "#ffc400"] };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));
    chart.draw(data, options);
}



$(document).ready(function () {
    $("#txtResponsable").keyup(function () {
        var value = $(this).val();
        $("#txtCausaRaiz").val(value);
    });
});



$(document).ready(function () {
    $("#txtResponsable").keypress(function () {
        $("#txtCausaRaiz").append("Tecla presionada");
    });
});
