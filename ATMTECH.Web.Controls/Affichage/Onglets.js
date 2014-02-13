Type.registerNamespace('ATMTECH.Web.Controls.Affichage');

ATMTECH.Web.Controls.Affichage.Onglets = function(element){
    ATMTECH.Web.Controls.Affichage.Onglets.initializeBase(this,[element]);
    this._desactiverOnglets = false;
    this._ongletSelectionne = null;
}

ATMTECH.Web.Controls.Affichage.Onglets.prototype = {
    initialize : function(){
        ATMTECH.Web.Controls.Affichage.Onglets.callBaseMethod(this, 'initialize');

        var id = this.get_element().id;
        var ctrl = this;
        var name = this.get_element().name;
        $('#' + id).tabs(
                    {
                        selected: ctrl.get_ongletSelectionne(),
                        select: function(event,ui){                             
                            ctrl.set_ongletSelectionne(ui.index);
                            __doPostBack(name, "selectionChange");
                            disabled: ctrl.get_estInactifOnglets();
                        }
                    }).show();
    },
    dispose : function(){
        ATMTECH.Web.Controls.Affichage.Onglets.callBaseMethod(this, 'dispose');
    },
    get_estInactifOnglets: function(){
        return this._estInactifOnglets;
    },
    set_estInactifOnglets: function(value){
        this._estInactifOnglets = value;
        this.raisePropertyChanged('_estInactifOnglets');
    },
    get_ongletSelectionne: function(){
        return this._ongletSelectionne;
    },
    set_ongletSelectionne: function(value){
        this._ongletSelectionne = value;
        $("#__CLIENTSTATE_" + this.get_element().id).attr("value", value);
        this.raisePropertyChanged('_ongletSelectionne');
    }
}


ATMTECH.Web.Controls.Affichage.Onglets.descriptor = {
    properties: [ {name: '_estInactifOnglets', type:Boolean },
                  {name: 'ongletSelectionne', type:Number }]
}
    
ATMTECH.Web.Controls.Affichage.Onglets.registerClass('ATMTECH.Web.Controls.Affichage.Onglets', Sys.UI.Control);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();