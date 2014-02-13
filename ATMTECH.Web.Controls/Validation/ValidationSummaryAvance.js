//Override de la fonction ValidationSummaryOnSubmit

//Enlèves les messages du sommaire
function NettoyerMessages(selecteur) {

    if ($(selecteur + ' ul').size() > 0) {
        $(selecteur + ' ul').remove();
    }
}


//Verifie si le control de validation ou le sommaire fait parti du groupe de validation
function VerifierGroupeValidateur(control, validationGroup) {

    if ((typeof (validationGroup) == "undefined") || (validationGroup == null)) {
        validationGroup = "";
    }

    var controlGroup, separateur, indexGroupeValidation;

    if ((typeof (control.estPrincipalSommaire) == "string") && control.estPrincipalSommaire == "True") {

        if (validationGroup == "" && control.estPrincipalSommaire) {
            return true;
        }
    }

    if (typeof (control.separateurValidationGroup) == "string") {
        separateur = control.separateurValidationGroup;
    }
    if (typeof (control.validationGroup) == "string") {
        controlGroup = control.validationGroup.split(separateur);
    }
    else {
        controlGroup = new Array("");
    }

    for (index = 0; index < controlGroup.length; index++) {
        if (controlGroup[index] == validationGroup) {
            return true;
        }
    }

    return false;

}

function ConstruireListeErreur(selecteur, message, cssClass) {
    if ($(selecteur + ' ul').size() == 0) {
        $(selecteur).append('<ul></ul>');
    }
    if (typeof (cssClass) == "string") {
        $(selecteur + ' ul').append('<li class="' + cssClass + '">' + message + '</li>');
    }
    else {
        $(selecteur + ' ul').append('<li>' + message + '</li>');
    }
}
$(document).ready(
    function() {

        //Enregistrer la fonction de callback au scriptmanager
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        if (typeof (prm) !== "undefined") {

            verifierPositionBarreDefilement = function(sender, arg) {
                if (typeof (Page_ValidationSummaries) == "undefined")
                    return;
                var sommaire, cpt;
                for (cpt = 0; cpt < Page_ValidationSummaries.length; cpt++) {
                    sommaire = Page_ValidationSummaries[cpt];
                    if (sommaire.style.display == "" && sommaire.estPrincipalSommaire) {
                        window.scroll(0, 0);
                        return;
                    }
                }
            };
            prm.add_endRequest(verifierPositionBarreDefilement);


        }

        //Override de la methode ValidationSummaryOnSubmit
        ValidationSummaryOnSubmit = function(validationGroup) {
            if (typeof (Page_ValidationSummaries) == "undefined")
                return;
            var summary, sums, s, selecteur, cssClass;
            for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
                summary = Page_ValidationSummaries[sums];
                selecteur = '#' + summary.id;

                if (!Page_IsValid && VerifierGroupeValidateur(summary, validationGroup)) {
                    if (summary.showsummary != "False") {
                        summary.style.display = "";
                        NettoyerMessages(selecteur);
                        for (i = 0; i < Page_Validators.length; i++) {
                            if (!Page_Validators[i].isvalid && typeof (Page_Validators[i].errormessage) == "string") {
                                ConstruireListeErreur(selecteur, Page_Validators[i].errormessage, summary.cssClassErreur);
                            }
                        }

                        if (summary.estPrincipalSommaire) window.scroll(0, 0);
                    }

                }
                else {
                    summary.style.display = "none";
                }
            }
        }
    }
);

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
