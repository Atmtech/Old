
// ************************************************************************************************
// Fonction pour rediriger vers la page d'accueil en reinitialisant la session
// ************************************************************************************************
function RedirigerVersAccueil() {
    var envir = window.location.host;
    if (envir == "localhost") {
        RedirectionUrl("/pesa/default.aspx");
    }
    else {
        RedirectionUrl("/default.aspx");
    }

}

function RedirectionUrl(url) {
    window.location = url;
}