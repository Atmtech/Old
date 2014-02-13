/*
 * Fonctionnalités globales à tous les contrôles
 */

if (typeof ($.ATMTECH) == 'undefined') $.ATMTECH = {};

/*
 * http://www.west-wind.com/weblog/posts/891992.aspx
 */
$.maxZIndex = $.fn.maxZIndex = function(opt) {
    /// <summary>
    /// Returns the max zOrder in the document (no parameter)
    /// Sets max zOrder by passing a non-zero number
    /// which gets added to the highest zOrder.
    /// </summary>    
    /// <param name="opt" type="object">
    /// inc: increment value, 
    /// group: selector for zIndex elements to find max for
    /// </param>
    /// <returns type="jQuery" />
    var def = { inc: 10, group: "*" };
    $.extend(def, opt);
    var zmax = 0;
    $(def.group).each(function() {
        var cur = parseInt($(this).css('z-index'));
        zmax = cur > zmax ? cur : zmax;
    });
    if (!this.jquery)
        return zmax;

    return this.each(function() {
        zmax += def.inc;
        $(this).css("z-index", zmax);
    });
};

/*
 * http://stackoverflow.com/questions/487073/jquery-check-if-element-is-visible-after-scrolling
 */
$.ATMTECH.isScrolledIntoView = function(elem) {
    var docViewTop = $(window).scrollTop();
    var docViewBottom = docViewTop + $(window).height();
    var elemTop = $(elem).offset().top;
    var elemBottom = elemTop + $(elem).height();
    return ((docViewTop < elemTop) && (docViewBottom > elemBottom));
};

$.ATMTECH.empecherFocus = false;

$.ATMTECH.afficherRapport = function (url) {
    $.ATMTECH.empecherFocus = true;
    window.open(url);
};

// Correctifs à appliquer lors du focus sur le Combobox autocomplet.
$.ATMTECH.appliquerCorrectifsDevExpress = function (s) {
    // 1 - Pour les problèmes du z-index dans MSIE 7 (avec GroupeBoite notamment)
    $(s.mainElement).parents('.groupeBoite').maxZIndex({ group: '.groupeBoite' });
    
    // 2 - Dans le cas suivant:
    // Alors DevExpress nous offre seulement une ligne vide et l'élément précédemment choisi dans sa liste initiale.
    // On veut le forcer à faire le faire le callback pour obtenir toute la première page d'éléments.
    // ATTENTION: filterStrategy et Filtering() sont des méthodes non documentées.
    if ((s.GetValue() || '-1') == '-1' && s.GetItemCount() <= 2) s.filterStrategy.Filtering();
};

$.ATMTECH.focusSurPremierControle = function () {
    var input = $(':input:enabled:visible').not(':submit,:button,input[type=image]').first();
    if (input.length == 1) {
        var elem = input[0];
        var estDateObligatoire = input.is(".dateTextBoxAvance") && input.prev().is('.indicObligatoire');
        if ($.ATMTECH.isScrolledIntoView(elem) && !estDateObligatoire) {
            // Ne pas mettre le focus sur le premier champ si cela nécessite un scroll de la page.
            // De plus, il y a un problème avec un DateTextBoxAvance obligatoire(!)
            input.focus();
        }
    }
}

$(window).load(function () {
    if (!$.ATMTECH.empecherFocus) {
        $.ATMTECH.focusSurPremierControle();
    }
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
