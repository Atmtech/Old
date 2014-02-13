function ConfirmerSuppression(message)
{ 
    return confirm(message);
}

function CheckOne(obj) {
    var grid = obj.parentNode.parentNode.parentNode.parentNode;
    var inputs = grid.getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox" && inputs[i].parentNode.className == "ChampSelection") {
          
            if ( inputs[i] != obj && inputs[i].checked) {
                inputs[i].checked = false;
            }
        }
    }
  //  return true;
}

$.ATMTECH = $.ATMTECH || {};
$.ATMTECH.grilleAvance = $.ATMTECH.grilleAvance || {};
$.extend($.ATMTECH.grilleAvance, {
    init: function () {
        $('.grilleAvance .gvBtnSelect').unbind('click', this.surlignerRangee).click(this.surlignerRangee);
        var rangeesCliquables = $('.grilleAvance.rangeeCliquable tr.gvRangee').has('.gvBtnSelect');
        rangeesCliquables.each(function() { $(this).addClass('gvClic') });
        rangeesCliquables.unbind('click', this.clicRangee).click(this.clicRangee);
        $('.grilleAvance.maitreDetail tr.gvRangee').unbind('click', this.selectRangee).click(this.selectRangee);
        $('.grilleAvance.maitreDetail tr.gvRangee,.grilleAvance.rangeeCliquable tr.gvRangee').each(this.ajouterTooltip);
        $('.grilleAvance .toutCocher input').each(this.appliquerToutCocher);
        $('.grilleAvance tr.gvRangee input:checkbox').closest('td').unbind('click').click(this.cocherCellule);
    },

    annulerSurlignage: function (idGrille) {
        $('#' + idGrille).find('.gvSelection').removeClass('gvSelection');
    },

    surlignerRangee: function (idGrille, indexRangee) {
        // Permet de faire la surbrillance de la rangée sélectionnée, en mode asynchrone.
        var elem;
        if (typeof idGrille == "string") {
            elem = $('#' + idGrille + ' tr.gvRangee').eq(indexRangee);
        } else {
            elem = $(this);
        }
        elem.closest('table').find('.gvSelection').removeClass('gvSelection');
        elem.closest('tr').addClass('gvSelection');
    },

    clicRangee: function (e) {
        if (!$(e.target).is('input,a,.gvCommande')) {
            var id = "btnConsulterRow";
            var btn = $(this).find('.gvBtnSelect');
            if (btn.length > 0 && btn.is('.btnModifierRow')) {
                id = "btnModifierRow";
            }
            var postbackArg = $(this).attr('id') + '$' + id;
            __doPostBack(postbackArg, '');
        }
    },

    selectRangee: function (e) {
        if (!$(e.target).is('input,a,.gvCommande')) {
            $.ATMTECH.grilleAvance.surlignerRangee.apply(this);
            $.ATMTECH.grilleAvance.clicRangee.call(this, e);
        }
    },

    ajouterTooltip: function (e) {
        var btn = $(this).find('.btnModifierRow');
        if (btn.length == 0) btn = $(this).find('.btnConsulterRow');
        if (btn.length > 0) {
            $(this).attr('title', btn.attr('title'));
            $(this).find('td.gvCommande').attr('title', '');
        }
    },

    cocherCellule: function (e) {
        if (!$(e.target).is('input')) {
            $(this).find('input').click();
        }
    },

    appliquerToutCocher: function () {
        var checkBoxEntete = $(this);
        checkBoxEntete.unbind('change', $.ATMTECH.grilleAvance.toutCocher).change($.ATMTECH.grilleAvance.toutCocher);
        var listeCheckBoxDetail = $.ATMTECH.grilleAvance.obtenirListeCheckBoxColonne(checkBoxEntete);
        listeCheckBoxDetail.unbind('change', $.ATMTECH.grilleAvance.synchroniserToutCocher).change($.ATMTECH.grilleAvance.synchroniserToutCocher);
        $.ATMTECH.grilleAvance.synchroniserToutCocher.apply(checkBoxEntete);
    },

    toutCocher: function (e) {
        var input = $(this);
        var cocher = input.is(':checked');
        $.ATMTECH.grilleAvance.obtenirListeCheckBoxColonne(input).prop('checked', cocher);
    },

    obtenirListeCheckBoxColonne: function (checkBoxEntete) {
        var cellule = checkBoxEntete.closest('th');
        var rangee = cellule.parent();
        var idx = rangee.children().index(cellule) + 1;
        return rangee.closest('table').find('.gvRangee td:nth-child(' + idx + ') input:checkbox')
    },

    synchroniserToutCocher: function (e) {
        var input = $(this);
        if (!input.parent().is('.toutCocher')) {
            input = $.ATMTECH.grilleAvance.obtenirEnteteCheckBox(input);
        }
        var listeCheckBox = $.ATMTECH.grilleAvance.obtenirListeCheckBoxColonne(input);
        var nombreCheckBox = listeCheckBox.length;
        var nombreCoches = listeCheckBox.filter(':checked').length;
        if (nombreCoches == 0) {
            input.prop('checked', false);
        } else if (nombreCoches == nombreCheckBox) {
            input.prop('checked', true);
        }
    },

    obtenirEnteteCheckBox: function (checkBox) {
        var cellule = checkBox.closest('td');
        var rangee = cellule.parent();
        var idx = rangee.children().index(cellule) + 1;
        return rangee.closest('table').find('.gvHeader th:nth-child(' + idx + ') input:checkbox')
    }
});

$(function() {
    $.ATMTECH.grilleAvance.init();
    // Pour rebinder les plugins jQuery dans les UpdatePanel.
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
        $.ATMTECH.grilleAvance.init();
    });
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
