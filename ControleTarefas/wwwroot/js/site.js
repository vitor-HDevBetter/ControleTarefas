

(function () {
    $("#lightmode").prop("disabled", true);
    $("#darkmode").prop("disabled", false);

})();

function ChangeMode() {

    if ($('#lightmode').prop("disabled") == true) {

        $("#lightmode").prop("disabled", false);
        $("#darkmode").prop("disabled", true);

    } else {

        $("#lightmode").prop("disabled", true);
        $("#darkmode").prop("disabled", false);
    }
}



