using System.Linq;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.WebSite.Base
{
    public class BadgeAffichage
    {
        public Accomplissement Accomplissement { get; set; }

        public string CouleurBordure { get; set; }
        public bool EstSansTitre { get; set; }
        public bool EstAvecAjout { get; set; }
        public bool EstAvecVote { get; set; }
        public bool EstAvecMentionFait { get; set; }
        public bool EstVisualisableAvecLoupe { get; set; }

        public string CreerDialogue()
        {
            string html = string.Empty;
            html += " <script type='text/javascript'>";
            html += "$(document).ready(function () {";
            html += "$('#ouvrirFenetre" + Accomplissement.Id + "').overlay({";
            html += "mask: {";
            html += "color: '#ebecff',";
            html += "loadSpeed: 200,";
            html += "opacity: 0.9";
            html += "},";
            html += "closeOnClick: false";
            html += "});";
            html += "});";
            html += "</script>";


            html += "<style>";
            html += ".modal" + Accomplissement.Id;
            html += "{";
            html += "background-color: #fff;";
            html += "display: none;";
            html += "width: 350px;";
            html += "padding: 15px;";
            html += "text-align: left;";
            html += "border: 2px solid #333;";
            html += "opacity: 0.8;";
            html += "-moz-border-radius: 6px;";
            html += "-webkit-border-radius: 6px;";
            html += "-moz-box-shadow: 0 0 50px #ccc;";
            html += "-webkit-box-shadow: 0 0 50px #ccc;";
            html += "}";
            html += "</style>";
            html += "<div class='modal" + Accomplissement.Id + "' id='visualiserAccomplissement" + Accomplissement.Id + "'>";
            html += "<h1>" + Accomplissement.Titre + "</h1>";
            html += Accomplissement.Description;
            html += "<div>";
            html = Accomplissement.AccomplissementTraits.Aggregate(html, (current, accomplissementTrait) => current + ("<li>" + accomplissementTrait.Trait.Description));
            html += "</div>";
            html += "<div>";
            html += "Nombre de vote: " + Accomplissement.NombreVote + " sur " + Accomplissement.NombreVoteRequis;
            html += "</div>";
            html += "<div>";
            html += "<button class='bouton'>Fermer</button>";
            html += "</div>";
            html += "</div>";
            return html;
        }


        public string CreerBadge()
        {
            string html = string.Empty;
            string toolTip = string.Empty;
            string listeQualite = "<ul>" +
                Accomplissement.AccomplissementTraits.Aggregate(string.Empty, (current, accomplissementTrait) => current + ("<li>" + accomplissementTrait.Trait.Description + "</li> ")) + "</ul>";

            toolTip += "<div class=tooltipTitreAccomplissement>" + Accomplissement.Titre + "</div>";
            toolTip += "<div class=tooltipDescriptionAccomplissement>" + Accomplissement.Description + "</div>";
            toolTip += "<div class=tooltipQualiteAccomplissement>" + listeQualite + "</div>";

            if (EstSansTitre)
            {
                html += "<div class='badge' style='margin-left:15px;top:8px;left:8px;background: " + CouleurBordure + "; width: 30px; height: 30px; position: relative; text-align: center; border-radius: 5px;'>";
                html += "<div style='position: relative; z-index: 1; text-align: center; border-radius: 100%; box-sizing: border-box; width: 30px; height: 30px; color: " + CouleurBordure + "; top: 0; left: 0; background: " + Accomplissement.Couleur + ";'>";
                html += "<img src='images/Badge/" + Accomplissement.Image.FileName + "' style='width: 20px; height: 20px;padding-top:4px;' />";
                html += "</div>";
                html += "</div>";
            }
            else
            {
                if (EstAvecMentionFait)
                {
                    html += "<div class='contenantBadge' style='background-color: rgb(181, 246, 164);'>";
                    html += "<div class='mentionAccompli'>Accompli</div>";
                }
                else
                {
                    html += "<div class='contenantBadge' style='background-color: #bed6ef;'>";
                    html += "<div class='mentionAccompli'>&nbsp;</div>";
                }

                html += "<div class='titreBadge'>" + Accomplissement.Titre + "</div>";
                html += "<div class='badge' style='background: " + CouleurBordure + ";'>";
                html += "<div class='badgeInterieur' style='background: -webkit-linear-gradient(" + Accomplissement.Couleur + "," + CouleurBordure + ");'>";
                html += "<img src='../images/Badge/" + Accomplissement.Image.FileName + "' class='imageBadge' />";
                html += "</div>";
                html += "</div>";
                html += "<div class='contenantMenuBadge'>";
                html += "<div style='display: inline-block;'>";
                html += "<a href='test.aspx' class='boutonBadge'>Vote</a>";
                html += "<input type='button' class='boutonBadge' id='ouvrirFenetre" + Accomplissement.Id + "' rel='#visualiserAccomplissement" + Accomplissement.Id + "' value='Voir'/>";
                html += "</div>";
                html += "<div class='mentionAccompli'> Vote: " + Accomplissement.NombreVote + " Requis: " + Accomplissement.NombreVoteRequis + " </div>";
                html += "</div>";
                html += "</div>";

                html += CreerDialogue();
            }

            return html;
        }
    }
}