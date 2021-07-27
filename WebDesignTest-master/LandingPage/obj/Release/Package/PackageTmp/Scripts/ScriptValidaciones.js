function ValidacionInput(idInput, mayorQue = "0", menorQue = "0") {
    var input = idInput;
    var datoinput = idInput.val();

    if (datoinput.length > mayorQue) {
        input.removeClass("is-invalid");
        input.addClass("is-valid");
    } else {
        input.addClass("is-invalid");
        input.removeClass("is-valid");
    }
}