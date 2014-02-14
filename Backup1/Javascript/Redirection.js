
// ************************************************************************************************
// Fonction pour rediriger vers la page d'accueil en reinitialisant la session
// ************************************************************************************************
function RedirigerVersAccueil() {
        RedirectionUrl("/default.aspx");
}

function RedirectionUrl(url) {
    window.location = url;
}