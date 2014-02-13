if (typeof ($.ATMTECH) == 'undefined') $.ATMTECH = {};
if (typeof ($.ATMTECH.barreNav) == 'undefined') $.ATMTECH.barreNav = {};


$.extend($.ATMTECH.barreNav, {
    // Initialisation des barres de navigations présentes pour la page.
    // On s'occupe de binder les événements "click" des boutons Suivant et
    // Précédent
    init: function() {
        $('.precedentBarreNav').unbind('click').click(this.precedent);
        $('.suivantBarreNav').unbind('click').click(this.suivant);
        $('.terminerBarreNav').unbind('click').click(this.terminer);
    },

    // Fonction qui décrémente l'index de sélection du composant d'onglet
    // de l'assistant. Aucune validation n'est faite pour la validité de
    // la page, et ce bouton ne devrait en aucun cas la déclencher.
    precedent: function(e) {
        $.ATMTECH.barreNav.disablerBouton();
        $.ATMTECH.barreNav.changerOnglet(this, -1);
        return true;
    },
    terminer: function(e) {

        $.ATMTECH.barreNav.disablerBouton();
        return true;
    },
    // Fonction qui incrémente l'index de sélection du composant d'onglet
    // de l'assistant. La page est validée; si cette dernière possède des
    // composants de validations en état d'invalidité, l'index ne sera
    // pas incrémenté.
    suivant: function(e) {
        var valGroup = $.ATMTECH.barreNav.obtenirGroupeValidation(this);
        if (typeof (Page_ClientValidate) != 'function' || Page_ClientValidate(valGroup)) {
            // La page est valide
            $.ATMTECH.barreNav.disablerBouton();
            $.ATMTECH.barreNav.changerOnglet(this, 1);


        }
        // Dans tous les cas, on retourne true, car le validateur se chargera
        // d'annuler le postback. Si on retourne false, on se retrouve avec
        // des problèmes lors des clics subséquents.
        return true;
    },
    disablerBouton: function() {

        for (var i = 0; i < document.forms[0].elements.length; i++) {
            element = document.forms[0].elements[i];
            if (element.type == 'submit') {
                $("#" + element.id).unbind('click').click(function() {
                    return false;
                });
            }
        }
        return true;
    },
    // Fonction utilisée par les événements pour changer d'onglet.
    changerOnglet: function(bouton, increment) {
        var selecteur = $(bouton).closest('.barreNav').attr('SelecteurEtatOnglet');
        var onglet = $(selecteur);
        var idx = parseInt(onglet.val());
        onglet.val(idx + increment);
    },

    // Fonction permettant d'obtenir le groupe de validation de l'onglet courant.
    // Celui-ci aura été ajouté comme attribut de la barre de navigation dans la
    // partie serveur de la composante.
    obtenirGroupeValidation: function(bouton) {
        return $(bouton).closest('.barreNav').attr('GroupeValidation');
    }
});

$(function() {
    $.ATMTECH.barreNav.init();
    // Pour rebinder les plugins jQuery dans les UpdatePanel.
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
        $.ATMTECH.barreNav.init();
    });
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
