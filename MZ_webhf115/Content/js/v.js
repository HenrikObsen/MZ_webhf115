/* --------- Definere hvad der skal valideres og hvordan -------- */

function validate(form) {
    /* Holder styr på om formen er valideret */
    var validated = true;

    /* ------------- Validering af e-mail ------------------ */
    var email = document.forms[form.name]["Email"].value;
    var errEmail = document.getElementById("ph_for_email");
    errEmail.innerText = "";
    if (email != "") {
        if (!ValidateEmail(email)) {
            validated = false;
            errEmail.innerText = "Det indtastede er ikke en e-mail!";
        }
    } else {
        validated = false;
        errEmail.innerText = "Feltet skal udfyldes!";
    }
    /* ------------ Validering af e-mail slut ------------- */


    /* ------------- Validering af sortering ------------------ */
    var postnr = document.forms[form.name]["Postnr"].value;
    var errPostnr = document.getElementById("ph_for_postnr");
    errPostnr.innerText = "";
    if (postnr != "") {
        if (!ValidateInt(postnr)) {
            validated = false;
            errPostnr.innerText = "Det indtastede er ikke et tal!";
        }
    } else {
        validated = false;
        errPostnr.innerText = "Feltet skal udfyldes!";
    }
    /* ------------ Validering af sortering slut ------------- */


    /* --------------- Validering af Navn -------------------- */
    var name = document.forms[form.name]["Navn"].value;
    var errName = document.getElementById("ph_for_name");
    errName.innerText = "";
    if (name != "") {

    }
    else {
        validated = false;
        errName.innerText = "Feltet skal udfyldes!";
    }
    /* ------------ Validering af Navn slut ------------------ */

    return validated;
}


/* ------------------------- Valideringsmuligheder ------------------------------ */

function ValidateInt(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}


function ValidateUrl(u) {
    var regex = /(http|https|ftp)?(:\/\/)?(www\.)?[A-Za-z]{1,253}\.([A-Za-z]{1,3}\.)?[A-Za-z]{1,63}/;
    return regex.test(u);
}


function ValidateEmail(e) {
    var regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    return regex.test(e);
}