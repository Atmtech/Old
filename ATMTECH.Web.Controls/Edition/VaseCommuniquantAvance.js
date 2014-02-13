if ($.ATMTECH == undefined) $.ATMTECH = {};
$.extend($.ATMTECH, {

    validerListBox: function(nombreItem, args) {

        args.IsValid = false;
        if (nombreItem > 0) {
            args.IsValid = true;
        }
    }
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();