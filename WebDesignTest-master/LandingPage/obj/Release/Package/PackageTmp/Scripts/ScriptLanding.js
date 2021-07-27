$(document).ready(function ($) {
    $("#inputNumeroTarjeta").mask('0000 0000 0000 0000');
    $("#Telefono").mask('0000000000');

    if ($('input:radio[name=PostPago]:checked').is(':checked')) {
        $("#btnRealizarPago").removeClass('disabled');
    }
    else {
        $("#btnRealizarPago").addClass('disabled');
    }

    $('input:radio[name=PostPago]').click(function () {
        if ($('input:radio[name=PostPago]:checked').is(':checked')) {
            $("#btnRealizarPago").removeClass('disabled');
        }
        else {
            $("#btnRealizarPago").addClass('disabled');
        }
    });


});

function valideNumer(evt) {

    // code is the decimal ASCII representation of the pressed key.
    var code = (evt.which) ? evt.which : evt.keyCode;

    if (code == 45 || code == 32) { // backspace.
        return true;
    } else if (code >= 48 && code <= 57) { // is a number.
        return true;
    } else { // other keys.
        return false;
    }
}

function valideName(evt) {

    // code is the decimal ASCII representation of the pressed key.
    var code = (evt.which) ? evt.which : evt.keyCode;

    if (code == 32) { // backspace.
        return true;
    } else if (code >= 65 && code <= 90 || code >= 97 && code <= 122) { // is a number.
        return true;
    } else { // other keys.
        return false;
    }
}

$('#inputMesTarjeta').on('input', function () {
    var input = $(this);
    var is_name_value = input.val();
    var validateMes = $('#inputMesTarjeta');
    if (is_name_value > 12 || is_name_value < 01) {
        validateMes.removeClass("is-valid");
        validateMes.addClass("is-invalid");
        $("#btnSendPago").addClass('disabled');
    } else {
        validateMes.removeClass("is-invalid");
        validateMes.addClass("is-valid");
        $("#btnSendPago").removeClass('disabled');
    }
});

$('#inputanioTarjeta').on('input', function () {
    var input = $(this);
    var is_name_value = input.val();
    var validateAnio = $('#inputanioTarjeta');
    var fecha = new Date();
    var anioActual = fecha.getFullYear();
    anioActual = anioActual.toString().substring(2);
    var anioLimitAfter = (parseInt(anioActual) + 6);
    var anioLimitBefore = (parseInt(anioActual) - 4);

    if (parseInt(is_name_value) > anioLimitAfter || parseInt(is_name_value) < anioLimitBefore || is_name_value.length == 0) {
        validateAnio.removeClass("is-valid");
        validateAnio.addClass("is-invalid");
        $("#btnSendPago").addClass('disabled');
    } else {
        validateAnio.removeClass("is-invalid");
        validateAnio.addClass("is-valid");
        $("#btnSendPago").removeClass('disabled');
    }
});


$("#btnCancelPago").off('click').on('click', function () {
    $("#btnRealizarPago").addClass('disabled');
    $("#contentbtnReadyPago").show('slow');
    $("#preloader").hide('slow');
    $("#contentDataClient").show('slow');
    $("#contentDataTarget").hide('slow');
});

$('#inputNombrePropietario').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 5)
});

$('#inputNumeroTarjeta').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 15)
});

$('#CVV').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 2)
});

$('#nombre_contacto').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 5)
});
$('#IdUnico').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 2)
});

$('#Telefono').on('input', function () {
    var input = $(this);
    ValidacionInput(input, 9)
});

$("#btnSendPago").click(function () {
    var Nombre = $("#inputNombrePropietario");
    var datoNombre = Nombre.val();
    var Numero = $("#inputNumeroTarjeta");
    var datoNumero = Numero.val();
    var CVV = $("#CVV");
    var datoCVV = CVV.val();

    if (datoNombre.length > 0) {
        if (datoNumero.length > 0 || datoNumero.length == 16) {
            if (datoCVV.length > 0) {
                $("#contentbtnSendPago").css("display", "none");
                $("#preloader").css("display", "block");
                $("#preloadertarget").css("display", "block");
            }
            else {
                CVV.addClass("is-invalid");
            }
        }
        else {
            Numero.addClass("is-invalid");
        }
    }
    else {
        Nombre.addClass("is-invalid");
    }
});

$("#btnRealizarPago").off('click').on('click', function () {
    $("#contentbtnReadyPago").hide('slow');
    $("#preloader").css("display", "block");
    $("#contentDataClient").hide('slow');
    $("#contentDataTarget").show('slow');

    var Pago = $('input:radio[name=PostPago]:checked').val();
    $("#Pago").val(Pago);
    $("#Pago").val($('#Pago').val().split(',').join('.'));

    var view =
        " <div class='bd-callout-primary bd-callout shadow-sm mb-4'>"
        + "<label class='radio-label'>"
        + "<input name='PostPago' type='radio' class='radioValorPago' checked />"
        + "<div id='Op2' class='div-radio-label'>"
        + "   <h5>Monto a cargar</h5>"
        + "<label class='text-muted' style='margin-bottom:0;'>$<label class='inputFormatoVenta'>" + Pago + "</label> </label>"
        + "</div>        </label>    </div>";
    $("#viewPago").html(view);

});

$("#MostrarPSW").off('click').on('click', function () {

    $("#iconView").removeClass("svg-inline--fa fa-eye fa-w-20");
    $("#iconView").addClass("fa-eye");

    password = document.getElementById("CVV");
    password.type = "text";
    return setTimeout(OcultarPSW, 3000);
});

function OcultarPSW() {
    $("#iconView").removeClass("svg-inline--fa fa-eye-slash fa-w-20");
    $("#iconView").addClass("fa-eye-slash");

    password = document.getElementById("CVV");
    password.type = "password";
}

//landing principal

$("#downface").off('click').on('click', function () {
    var action = $("#face");
    action.css({ "background": "#ff0057", "transform": "translateY(750px)"});
    $("#upface").slideDown("slow");
});

$("#upface").off('click').on('click', function () {
    var action = $("#face");
    action.css({ "background": "#ff0057", "transform": "translateY(400px)"});
    $("#upface").slideUp("slow");
});

$("#btnSendCliente").off('click').on('click', function () {
    var nombre = $('#nombre_contacto');
    var boleta = $('#IdUnico');
    var telefono = $('#Telefono');

    if (boleta.val() == "" || boleta.val.length == 0) {
        boleta.addClass("is-invalid");
    }
    else {
        if (telefono.val() == "" || telefono.val.length == 0) {
            telefono.addClass("is-invalid");
        } else {
            $("#preloadertarget").show('slow');
        }
    }
});