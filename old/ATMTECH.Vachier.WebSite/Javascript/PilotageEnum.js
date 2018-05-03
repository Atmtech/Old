if (typeof (SIQ) == "undefined") SIQ = {};
SIQ.pilotageEnums = {
    idDialogue: '',

    ouvrirPopin: function(titre) {
        $('#' + SIQ.pilotageEnums.idDialogue).dialog('open').dialog('option', 'title', titre);
    },

    fermerPopin: function() {
        $('#' + SIQ.pilotageEnums.idDialogue).dialog('close');
    }
};
