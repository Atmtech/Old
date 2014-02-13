Type.registerNamespace('ATMTECH.Web.Controls.Affichage');

ATMTECH.Web.Controls.Affichage.FenetreDialogue = function(element) {
    ATMTECH.Web.Controls.Affichage.FenetreDialogue.initializeBase(this, [element]);
    this._hauteur = null;
    this._estModal = true;
    this._estDeplacable = true;
    this._estOuverte = true;
    this._titre = null;
    this._largeur = null;
    this._estRedimentionnable = false;
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.prototype = {

    initialize: function() {

        ATMTECH.Web.Controls.Affichage.FenetreDialogue.callBaseMethod(this, 'initialize');

        var element = this;
        var domElement = this.get_element();
        var idModal = domElement.id;
        var nameModal = domElement.name;
        var jqObject = $(domElement);

        //Création de la boite de dialogue
        var hauteur = parseInt(element.get_hauteur());
        if (isNaN(hauteur)) {
            hauteur = element.get_hauteur();
        }
        var largeur = parseInt(element.get_largeur());
        if (isNaN(largeur)) {
            largeur = element.get_largeur();
        }
        var opts = {
            autoOpen: false,
            title: element.get_titre(),
            modal: element.get_estModal(),
            resizable: element.get_estRedimentionnable(),
            draggable: element.get_estDeplacable(),
            height: hauteur,
            width: largeur,
            minWidth: false,
            closeOnEscape: false,
            close: function(type, data) {
                __doPostBack(nameModal, "fermer");
            }
        };

        domElement.cacher = false;
        var container = jqObject.parent()[0];
        domElement.container = container;
        jqObject.dialog(opts);
        // Au début, nous plaçons la fenêtre à la fin du formulaire. Ceci permet au viewstate
        // d'être conservé en cas de postback normal (synchrone). Ainsi la valeur initiale
        // d'un contrôle comme checkbox sera conservée.

        // De plus, lorsque la fenêtre est ouverte, nous voulons qu'elle soit à cet endroit
        // dans le DOM, afin qu'elle soit correctement centrée sur la page.
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.PlacerFenetreDansForm.apply(domElement);

        if (element.get_estOuverte() && !jqObject.dialog('isOpen')) {
            ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuvrirDialogue(idModal);
        }
    },

    dispose: function() {
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.callBaseMethod(this, 'dispose');
    },
    get_estDeplacable: function() {
        return this._estDeplacable;
    },
    set_estDeplacable: function(value) {
        this._estDeplacable = value;
    },
    get_hauteur: function() {
        return this._hauteur;
    },
    set_hauteur: function(value) {
        this._hauteur = value;
    },
    get_estModal: function() {
        return this._estModal;
    },
    set_estModal: function(value) {
        this._estModal = value;
    },
    get_estOuverte: function() {
        return this._estOuverte;
    },
    set_estOuverte: function(value) {
        this._estOuverte = value;
    },
    get_titre: function() {
        return this._titre;
    },
    set_titre: function(value) {
        this._titre = value;
    },
    get_largeur: function() {
        return this._largeur;
    },
    set_largeur: function(value) {
        this._largeur = value;
    },
    get_estRedimentionnable: function() {
        return this._estRedimentionnable;
    },
    set_estRedimentionnable: function(value) {
        this._estRedimentionnable = value;
    }
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.descriptor = {
    properties: [{ name: 'estDeplacable', type: Boolean },
                  { name: 'hauteur', type: String },
                  { name: 'estModal', type: Boolean },
                  { name: 'estOuverte', type: Boolean },
                  { name: 'titre', type: String },
                  { name: 'largeur', type: String },
                  { name: 'estRedimentionnable', type: Boolean}]
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.FenetresFermees = {};
ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuverturesRetardees = [];

ATMTECH.Web.Controls.Affichage.FenetreDialogue.FermerDialogue = function(clientId) {
    if (Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.FenetresFermees[clientId] = true;
    }
    $('#' + clientId).dialog('close');
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuvrirDialogue = function(clientId, titre) {
    if (Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
        // On n'ouvrira la fenêtre qu'à la toute fin de l'appel AJAX pour éviter
        // un bug de positionnement (ex. 1072 dans BugNet)
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.RetarderOuverture(clientId, titre);
        return;
    }
    var dlg = $('#' + clientId);
    if (typeof titre !== 'undefined' && titre !== null) {
        dlg.dialog('option', 'title', titre);
    }
    var zindex = $.maxZIndex({ group: '.groupeBoite' }) + 10;
    dlg.dialog('option', 'zIndex', zindex);
    $('.groupeBoite', dlg[0]).css('z-index', zindex + 20);
    dlg.dialog('open');
    dlg.css('z-index', zindex + 10);
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.RetarderOuverture = function(clientId, titre) {
    ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuverturesRetardees.push({ clientId: clientId, titre: titre });
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.TraiterOuverturesRetardees = function() {
    //debugger;
    var ouvertures = ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuverturesRetardees;
    var len = ouvertures.length;
    for (var i = 0; i < len; i++) {
        var fenetre = ouvertures[i];
        if (typeof ATMTECH.Web.Controls.Affichage.FenetreDialogue.FenetresFermees[fenetre.clientId] === 'undefined') {
            // Ne pas rouvrir une fenêtre si on a demandé à la fermer.
            ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuvrirDialogue(fenetre.clientId, fenetre.titre);
        }
    }
    ATMTECH.Web.Controls.Affichage.FenetreDialogue.FenetresFermees = {};
    ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuverturesRetardees = [];
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.PlacerFenetreDansForm = function() {
    var jqElem = $(this);
    if (jqElem.parent().is('.ui-dialog')) {
        jqElem = jqElem.parent();
    }
    jqElem.appendTo('form');
    if (this.cacher) {
        if (typeof ATMTECH.Web.Controls.Affichage.FenetreDialogue.FenetresFermees[this.id] === 'undefined') {
            jqElem.show();
        }
        this.cacher = false;
    }
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.ReplacerFenetre = function() {
    // Cette fonction remet le contrôle dans son conteneur d'origine. Ceci
    // est nécessaire lors d'un postback asynchrone, afin de s'assurer que
    // la composante soit re-générée au complet. Autrement, nous aurons des
    // erreurs comme quoi un on tente d'injecter un élément dans la page
    // avec le même ID qu'un élément déjà présent.
    var jqElem = $(this);
    // On va cacher l'élément avant, sinon il va "bouger" sur la page,
    // ce qui est finalement encore plus laid. En réalité, il devrait
    // être remplacé par une fenêtre de progression.
    this.cacher = jqElem.dialog('isOpen');
    if (jqElem.parent().is('.ui-dialog')) {
        jqElem = jqElem.parent();
    }
    if (this.cacher) {
        jqElem.hide();
    }
    jqElem.appendTo(this.container);
};

ATMTECH.Web.Controls.Affichage.FenetreDialogue.AjusterZindex = function() {
    $('.fenetreDialogue').each(function() {
        if ($(this).dialog('isOpen')) {
            var zindex = $(this).dialog('option', 'zIndex');
            $('.groupeBoite', this).css('z-index', zindex + 20);
        }
    });
};

$(function() {
    // Pour les fenêtres qui contiennent des UpdatePanel, on les remets à leur place
    // au début de la requête, et on le remets à la fin du formulaire à la fin de la
    // requête. On ajuste aussi le z-index au retour.
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function() {
        $('.fenetreDialogue').each(ATMTECH.Web.Controls.Affichage.FenetreDialogue.ReplacerFenetre);
    });
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
        $('.fenetreDialogue').each(ATMTECH.Web.Controls.Affichage.FenetreDialogue.PlacerFenetreDansForm);
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.AjusterZindex();
        ATMTECH.Web.Controls.Affichage.FenetreDialogue.TraiterOuverturesRetardees();
    });
});

ATMTECH.Web.Controls.Affichage.FenetreDialogue.registerClass('ATMTECH.Web.Controls.Affichage.FenetreDialogue', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
