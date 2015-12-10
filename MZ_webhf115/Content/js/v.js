function validate(form) {
    var validated = true;

    var sortering = document.forms[form.name]["Sortering"].value;
    var errSort = document.getElementById("ph_for_sortering");
    errSort.innerText = "";
    if (sortering != "") {
        if (!ValidateInt(sortering)) {
            validated = false;
            errSort.innerText = "Det indtastede er ikke et tal!";
        }
    } else {
        validated = false;
        errSort.innerText = "Feltet skal udfyldes!";
    }

    var name = document.forms[form.name]["Navn"].value;
    var errName = document.getElementById("ph_for_name");
    errName.innerText = "";
    if (name != "") {

    }
    else {
        validated = false;
        errName.innerText = "Feltet skal udfyldes!";
    }

    return validated;
}





/* ------------------------- Valideringsmuligheder -------------------------------------------- */

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