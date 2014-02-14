// ************************************************************************************************
// Gestion de l'expiration des pages avec timeout
// Elle n'a plus de lien direct avec la variable dans le web.config donc il faut la setter ici.
// Pour afficher le timer du temps restant en bas de page retourner dans les pages master
// pour mettre le dernier paramètre à true dans l'appel à InitialiserExpiration.
// ************************************************************************************************
function InitialiserExpiration(delaiMinutes, urlTimeout, afficherTempsRestant) {
    $.ATMTECH = $.ATMTECH || {};
    $.ATMTECH.expiration = $.ATMTECH.expiration || {};
    $.extend($.ATMTECH.expiration, {
        delai: delaiMinutes,
        url: urlTimeout,
        afficherTemps: afficherTempsRestant || true
    });
    GererExpiration();
}

function GererExpiration() {
    _GererExpiration($.ATMTECH.expiration.delai, $.ATMTECH.expiration.url, $.ATMTECH.expiration.afficherTemps);
}

// Le session timeout fonctionne en minute comme dans web.config;
function _GererExpiration(delaiMinutes, urlTimeout, afficherTempsRestant, appelSubsequent) {
    if (typeof window.idTimer != 'undefined') {
        window.clearTimeout(window.idTimer);
    }
    if (typeof window.idTimerAffichage != 'undefined') {
        window.clearInterval(window.idTimerAffichage);
    }
    if ($('#StatutExpiration').val() == "1") {
        var tempsTimeOut = delaiMinutes * 60 * 1000;
        window.idTimer = window.setTimeout(
            function() { ExecuterExpiration(urlTimeout) },
            tempsTimeOut);
        if (typeof afficherTempsRestant != 'undefined' && afficherTempsRestant) {
            if ($('#tempsRestant').length == 0) {
                $('body').append('<div id="tempsRestant"> </div>');
            }
            MiseAJourTempsRestant(tempsTimeOut);
            var intervalleMaj = 1000;
            window.idTimerAffichage = window.setInterval(
                function() { MiseAJourTempsRestant(tempsTimeOut, intervalleMaj) },
                intervalleMaj);
        }
        if (typeof appelSubsequent == 'undefined' || !appelSubsequent) {
            // Réinitialiser si MAJ dans UpdatePanel.
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
                _GererExpiration(delaiMinutes, urlTimeout, afficherTempsRestant, true);
            });
        }
    }
}

function ExecuterExpiration(urlRedirection) {
    if (document.getElementById("EstFenetreModal").value == "1") {
        var opener = window.dialogArguments;

        // setter la redirection sur le parent
        opener.RedirectionUrl(urlRedirection);
        window.close();
    }
    else {
        RedirectionUrl(urlRedirection);
    }
}

function RedirectionUrl(url) {
    window.location = url;
}

// ******************************************************************************************************************
// affichage d'un horloge en développement
// ******************************************************************************************************************
var tempsRestant = 0;

function MiseAJourTempsRestant(tempsInitial, intervalle) {
    if (typeof intervalle == 'undefined' || tempsRestant == 0) {
        tempsRestant = tempsInitial;
    }
    else {
        tempsRestant = tempsRestant - intervalle;
    }
    $('#tempsRestant').text(ConvertirMillisecondeEnHeure(tempsRestant));

    
}

// ************************************************************************************************
// Conversion de milliseconde en un temps heure
// ************************************************************************************************
function two(x) { return ((x > 9) ? "" : "0") + x }
function three(x) { return ((x > 99) ? "" : "0") + ((x > 9) ? "" : "0") + x }
function ConvertirMillisecondeEnHeure(ms) {
    var sec = Math.floor(ms / 1000)
    var t = "";
    var min = Math.floor(sec / 60)
    sec = sec % 60
    t = two(sec) + t
    var hr = Math.floor(min / 60)
    min = min % 60
    t = two(min) + ":" + t
    return t
}

