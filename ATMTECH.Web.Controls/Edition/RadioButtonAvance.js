if ($.ATMTECH == undefined) $.ATMTECH = {};

$.extend($.ATMTECH, {
    initRadioButton: function() {
        $('.radioButtonAvance input').unbind('click').click(function() {
            var gn = this.groupname;
            $('.radioButtonAvance input[groupname="' + gn + '"]').not(this).attr('checked', false);
        });
    }
});

$(function() {

    $.ATMTECH.initRadioButton();

    // Pour rebinder les plugins jQuery dans les UpdatePanel.
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
        $.ATMTECH.initRadioButton();
    });
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
