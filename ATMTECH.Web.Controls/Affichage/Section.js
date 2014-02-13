if ($.ATMTECH == undefined) $.ATMTECH = {};
$.extend($.ATMTECH, {

    initControlesSection: function() {

        // Pour tous les boutons de chaque section
        $(".section img").each(function() {

            // L'objet image
            var t = $(this);

            // Le contenant du contenu à animer
            var c = t.parent().next();

            // Sur le clique, change l'image et
            // fait l'animation.
            t.unbind('click').bind('click', function() {

                // L'etat (ouvert ou ferme) est indique
                // via un input hidden
                var e = t.parent().find("input")[0];

                // Est ouvert, donc on le ferme
                if (e.value == "1") {

                    c.css("display", "none");
                    //c.slideUp();
                    t.attr('src', $.ATMTECH.imgSctAgrandir);
                    e.value = "0";

                } else { // Est ferme, donc on l'ouvre

                    c.css("display", "block");
                    //c.slideDown();
                    t.attr('src', $.ATMTECH.imgSctReduire);
                    e.value = "1";
                }
            });
        });
    }
});

$(function() {

    $.ATMTECH.initControlesSection();

    // Pour rebinder les plugins jQuery dans les UpdatePanel.
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
        $.ATMTECH.initControlesSection();
    });
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
