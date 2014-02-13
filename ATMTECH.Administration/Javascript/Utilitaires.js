$(function () {
    // Empêcher ENTER d'envoyer le formulaire
    $('form').keypress(function (e) {
        return (e.which != 13 || $(e.target).is('textarea,:button,:submit,:image'));
    });
});




// ******************************************************************************************************************
// Formatage des polices
// ******************************************************************************************************************

function reformaterPolice(increment) {
    var tableauPolice = new Array("1em", "1.2em", "1.4em", "1.6em");

    var i = $.inArray(document.body.style.fontSize, tableauPolice);
    if (i == -1) {
        // Taille inconnue, on initialise au plus petit
        i = 0;
        document.body.style.fontSize = tableauPolice[i];
    }

    var nouvelIndex = i + increment;
    // Éviter les débordements
    nouvelIndex = Math.min(Math.max(nouvelIndex, 0), tableauPolice.length - 1);

    document.body.style.fontSize = tableauPolice[nouvelIndex];

    return false;
}

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
        afficherTemps: afficherTempsRestant || false
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
            function () { ExecuterExpiration(urlTimeout) },
            tempsTimeOut);
        if (typeof afficherTempsRestant != 'undefined' && afficherTempsRestant) {
            if ($('#tempsRestant').length == 0) {
                $('body').append('<div id="tempsRestant"> </div>');
            }
            MiseAJourTempsRestant(tempsTimeOut);
            var intervalleMaj = 1000;
            window.idTimerAffichage = window.setInterval(
                function () { MiseAJourTempsRestant(tempsTimeOut, intervalleMaj) },
                intervalleMaj);
        }
        if (typeof appelSubsequent == 'undefined' || !appelSubsequent) {
            // Réinitialiser si MAJ dans UpdatePanel.
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
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
    $('#tempsRestant').text('Session expire dans: ' + ConvertirMillisecondeEnHeure(tempsRestant));
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

// ************************************************************************************************
// Fonction pour rétrécir ou agrandir le menu de gauche
// ************************************************************************************************
function ReduireMenu() {

    var control = document.getElementById("barreMenuGauche");
    var div = document.getElementById("divBarreMenuGauche");
    var imgRetrecir = document.getElementById("ctl00_imgReduire");
    var imgAgrandir = document.getElementById("ctl00_imgAgrandir");

    control.style.width = "3px";
    div.style.display = "none";
    imgRetrecir.style.display = "none";
    imgAgrandir.style.display = "inline";

}
function AgrandirMenu() {

    var control = document.getElementById("barreMenuGauche");
    var div = document.getElementById("divBarreMenuGauche");
    var imgRetrecir = document.getElementById("ctl00_imgReduire");
    var imgAgrandir = document.getElementById("ctl00_imgAgrandir");

    control.style.width = "180px";
    div.style.display = "inline";
    imgRetrecir.style.display = "inline";
    imgAgrandir.style.display = "none";
}

// ************************************************************************************************
// Fonction pour rediriger vers la page d'accueil en reinitialisant la session
// ************************************************************************************************
function RedirigerVersAccueil() {


}


function displayHTML(printContent) {
    var inf = printContent;
    var win = window.open("print.htm", 'popup', 'toolbar = no, status = no');
    win.document.write(inf);
    win.document.close(); // new line 
}


function Print(elementId) {
    var printContent = document.getElementById(elementId);
    var windowUrl = 'about:blank';
    var uniqueName = new Date();
    var windowName = 'Print' + uniqueName.getTime();
    var printWindow = window.open(windowUrl, windowName, 'left=1,top=1,width=800,height=600');
    printWindow.document.write(printContent.innerHTML);
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();
}

function windowOpener(windowHeight, windowWidth, windowName, windowUri) {
    var centerWidth = (window.screen.width - windowWidth) / 2;
    var centerHeight = (window.screen.height - windowHeight) / 2;
  
    newWindow = window.open(windowUri, windowName, 'resizable=0,width=' + windowWidth +
        ',height=' + windowHeight +
        ',left=' + centerWidth +
        ',top=' + centerHeight);

    newWindow.focus();
    return newWindow.name;
}