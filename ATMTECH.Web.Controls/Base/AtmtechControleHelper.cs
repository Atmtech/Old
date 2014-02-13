using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Base
{
    internal static class ATMTECHControleHelper
    {
        const string QUERYSTRING_ONGLET_SELECTIONNE = "og";

        internal static Attribute ObtenirAttribut(PropertyDescriptor propertyDescriptor, Type typeEntite)
        {
            return
                propertyDescriptor.Attributes.Cast<Attribute>().FirstOrDefault(
                    attribute => attribute.GetType() == typeEntite);
        }

        internal static object ConvertirControlIdEnClientId(object id, ITrouveurControle control)
        {
            Control ctrl = null;

            if (id != null)
            {
                ctrl = control.RetrouverControle(id.ToString());
            }

            return ctrl == null ? null : ctrl.ClientID;
        }

        /// <summary>
        /// Ajoute un fichier Javascript à la page, ou demande au ScriptManager de
        /// le charger (dans le cas du postback asynchrone d'un UpdatePanel).
        /// </summary>
        /// <param name="page">Page courante</param>
        /// <param name="ressource">Nom de la ressource, mais sans le préfixe "ATMTECH.Web.Controls."</param>
        internal static void InclureRessourceJavascript(this Page page, string ressource)
        {
            string scriptLocation = page.GetResourceUrl(ressource);
            if (page.EstPostbackAsynchrone())
            {
                ScriptManager.RegisterClientScriptInclude(page, typeof(Page), ressource, scriptLocation);
            }
            else
            {
                page.ClientScript.RegisterClientScriptInclude(typeof(Page), ressource, scriptLocation);
            }
        }

        /// <summary>
        /// Méthode d'extension qui permet d'ajouter du code Javascript dans la page,
        /// avec la clé précisée; et ce, peu importe que nous soyons dans un UpdatePanel
        /// ou non. Les ressources peuvent être spécifiées sous la forme:
        /// "@@SubNamespace.Resource.png@@"
        /// </summary>
        /// <param name="page">Page courante</param>
        /// <param name="cle">La clé unique (pour éviter de multiples blocs identiques.</param>
        /// <param name="js">Le code Javascript sans les balises &lt;script&gt;.</param>
        internal static void IncorporerJavascript(this Page page, string cle, string js)
        {
            string jsAvecRessources = page.RemplacerRessources(js);
            if (page.EstPostbackAsynchrone())
            {
                ScriptManager.RegisterClientScriptBlock(page, typeof(Page), cle, jsAvecRessources, true);
            }
            else
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), cle, jsAvecRessources, true);
            }
        }

        /// <summary>
        /// Dans le code fourni, remplace les noms de type @@SubNamespace.Resource.png@@
        /// avec le nom de la ressource correspondante (sous ATMTECH.Web.Controls).
        /// Utiliser des pourcentages (%%SubNamespace.Resource.png%%) pour encoder le nom
        /// de la ressource pour utilistation dans un attribut de balise HTML.
        /// </summary>
        internal static string RemplacerRessources(this Page page, string codeAvecRessources)
        {
            string resultat = Regex.Replace(codeAvecRessources, "%%([^@]*)%%",
                                            match => GetResourceUrl(page, match.Groups[1].Value, true));
            return Regex.Replace(resultat, "@@([^@]*)@@",
                                 match => GetResourceUrl(page, match.Groups[1].Value, false));

        }

        internal static string GetEncodedResourceUrl(this Page page, string resource)
        {
            return GetResourceUrl(page, resource, true);
        }

        /// <summary>
        /// Retourne le URL d'une ressource spécifiée (image, script). La ressource doit contenir
        /// le namespace, mais sans le préfixe "ATMTECH.Web.Controls.".
        /// </summary>
        internal static string GetResourceUrl(this Page page, string resource)
        {
            return GetResourceUrl(page, resource, false);
        }

        private static string GetResourceUrl(Page page, string resource, bool encode)
        {
            if (page != null)
            {


                string res = page.ClientScript.GetWebResourceUrl(typeof(ControleBase), "ATMTECH.Web.Controls." + resource);
                if (encode)
                {
                    res = HttpUtility.HtmlEncode(res);
                }
                return res;
            }
            return string.Empty;
        }

        /// <summary>
        /// Ajoute un attribut non-standard, de manière à ce que le HTML soit valide,
        /// et à ce que l'attribut soit disponible directement par javascript.
        /// </summary>
        internal static void AjouterAttribut(this WebControl ctrl, string attribut, string valeur)
        {
            Page page = ctrl.Page;
            const bool encode = false;
            if (ScriptManager.GetCurrent(page) != null)
            {
                ScriptManager.RegisterExpandoAttribute(ctrl, ctrl.ClientID, attribut, valeur, encode);
            }
            else
            {
                page.ClientScript.RegisterExpandoAttribute(ctrl.ClientID, attribut, valeur, encode);
            }
        }

        /// <summary>
        /// Permet d'obtenir le Presenter le plus proche dans la hiérarchie du contrôle.
        /// </summary>
        /// <param name="controle"></param>
        internal static object ObtenirPresenter(this Control controle)
        {
            while (controle != null)
            {
                PropertyInfo pi = controle.GetType().GetProperty("Presenter");
                if (pi != null && !(controle is MasterPage))
                {
                    return pi.GetValue(controle, null);
                }
                controle = controle.Parent;
            }
            return null;
        }

        internal static IEnumerable<Control> All(this ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }

        /// <summary>
        /// Méthode qui boucle dans les controles parent du controle que l'on désire avoir
        /// le mode d'affichage pour trouver le premier mode d'affichage qui n'est pas
        /// hérité
        /// </summary>
        /// <param name="ctrl">controle de base</param>
        /// <returns></returns>
        internal static ModeAffichage ObtenirModeAffichage(IControleAvecModeAffichage ctrl)
        {
            if (ctrl.ModeAffichageControle != ModeAffichage.Herite)
            {
                return ctrl.ModeAffichageControle;
            }
            ModeAffichage modeAffichage = ModeAffichage.Herite;
            Control controle = (Control)ctrl;
            Control controlParent = controle;

            while (controlParent != null && modeAffichage == ModeAffichage.Herite)
            {
                ATMTECHUserControlBase ucb = controlParent as ATMTECHUserControlBase;
                if (ucb != null)
                {
                    modeAffichage = ucb.ModeAffichageControle;
                }
                ControleBase cb = controlParent as ControleBase;
                if (cb != null)
                {
                    modeAffichage = cb.ModeAffichageControle;
                }
                ATMTECHScriptBaseControle sbc = controlParent as ATMTECHScriptBaseControle;
                if (sbc != null)
                {
                    if (sbc is Onglets)
                    {
                        // Aller chercher la page pour pouvoir obtenir le querystring
                        Control parent = sbc;
                        while (!(parent is PageBase) && (parent != null))
                        {
                            parent = parent.Parent;
                        }
                        string og = string.Empty;

                        // Aller lire le querystring
                        if (parent != null)
                        {
                            // ReSharper disable PossibleInvalidCastException
                            og = ((PageBase)parent).Request.QueryString[QUERYSTRING_ONGLET_SELECTIONNE];
                            // ReSharper restore PossibleInvalidCastException
                        }
                        if (string.IsNullOrEmpty(og))
                        {
                            og = "0";
                        }

                        // Obtenir le mode d'affichage du bon onglet
                        modeAffichage = ((OngletElement)((Onglets)sbc).Items[int.Parse(og)]).ModeAffichage;
                    }
                    else
                    {
                        modeAffichage = sbc.ModeAffichage;
                    }
                }
                controlParent = controlParent.Parent;
            }

            if (modeAffichage == ModeAffichage.Herite)
            {
                PageBase pb = controle.Page as PageBase;
                if (pb != null)
                {
                    modeAffichage = pb.ModeAffichage;
                }
            }
            if (modeAffichage == ModeAffichage.Herite)
            {
                // Par défaut
                modeAffichage = ModeAffichage.Modification;
            }
            return modeAffichage;
        }

        /// <summary>
        /// Permet de générer l'écriture du contrôle en mode lecture seule.
        /// </summary>
        internal static void EcrireControleLectureSeule(this ControleBase controle, TextWriter writer, string texte)
        {
            EcrireControleLectureSeule(controle, writer, texte, string.Empty, string.Empty, true);
        }

        /// <summary>
        /// Permet de générer l'écriture du contrôle en mode lecture seule.
        /// </summary>
        internal static void EcrireControleLectureSeule(this ControleBase controle, TextWriter writer, string texte, bool encoderHtml)
        {
            EcrireControleLectureSeule(controle, writer, texte, string.Empty, string.Empty, encoderHtml);
        }

        /// <summary>
        /// Permet de générer l'écriture du contrôle en mode lecture seule. Une classe
        /// CSS et un style "en ligne" peuvent être spécifiés, et seront ajoutés aux
        /// valeurs par défaut.
        /// </summary>
        internal static void EcrireControleLectureSeule(this ControleBase controle, TextWriter writer, string texte, string classeCss, string styleControle)
        {
            EcrireControleLectureSeule(controle, writer, texte, classeCss, styleControle, true);
        }

        /// <summary>
        /// Permet de générer l'écriture du contrôle en mode lecture seule. Une classe
        /// CSS et un style "en ligne" peuvent être spécifiés, et seront ajoutés aux
        /// valeurs par défaut.
        /// </summary>
        internal static void EcrireControleLectureSeule(this ControleBase controle, TextWriter writer, string texte, string classeCss, string styleControle, bool encoderHtml)
        {
            Unit largeur = controle.Width;
            string styleLargeur = largeur.IsEmpty ? string.Empty : string.Format("width: {0};", largeur.ToString());
            if (controle.WrapEnModeLectureSeule)
            {
                classeCss = ((classeCss ?? string.Empty) + " wrap").TrimStart();
            }
            writer.Write("<span class='controleLectureSeule {0}' style='{1}{2}'>",
                         classeCss ?? string.Empty, styleLargeur, styleControle ?? string.Empty);
            if (string.IsNullOrWhiteSpace(texte))
            {
                writer.Write("&nbsp;");
            }
            else
            {
                if (encoderHtml)
                    texte = HttpUtility.HtmlEncode(texte);

                if (controle.ConvertirSautsDeLigne)
                    texte = texte.Replace("\r", "").Replace("\n", "<br />");

                writer.Write(texte);
            }
            writer.Write("</span>");
        }

        internal static bool SeraMisAJour(this Control controle)
        {
            if (controle.Page.EstPostbackAsynchrone())
            {
                // Rendu partiel, vérifions si le contrôle a un UpdatePanel parent qui sera mis à jour.
                controle = controle.Parent;
                while (controle != null)
                {
                    UpdatePanel udp = controle as UpdatePanel;
                    if (udp != null && udp.IsInPartialRendering)
                    {
                        return true; // Rendu partiel, et le contrôle sera  mis à jour
                    }
                    controle = controle.Parent;
                }
                return false; // Rendu partiel, mais le contrôle n'est pas mis à jour
            }
            return true; // Rendu de la page au complet
        }

        internal static bool EstPostbackAsynchrone(this Page page)
        {
            ScriptManager sm = ScriptManager.GetCurrent(page);
            return sm != null && sm.IsInAsyncPostBack;
        }
    }
}