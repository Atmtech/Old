using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Web.Controls.Edition;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class WebUtils
    {
        /// <summary>
        /// Charger une liste de valeurs dans un dropdownlist
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="liste"></param>
        /// <param name="listeValeurs"></param>
        /// <param name="champValeur"></param>
        /// <param name="champTexte"></param>
        public static void ChargerListe<TType>(ComboBoxAvance liste, IList<TType> listeValeurs, string champValeur,
                                               string champTexte)
        {
            liste.DataSource = listeValeurs;
            liste.DataTextField = champTexte;
            liste.DataValueField = champValeur;
            liste.DataBind();
        }

        /// <summary>
        /// Charge une valeur dans un checkbox
        /// </summary>
        /// <param name="ckb">Checkbox à charger</param>
        /// <param name="valeur">Valeur à charger</param>
        public static void ChargerCheckbox(CheckBoxAvance ckb, int? valeur)
        {
            ckb.Checked = false;
            if (valeur == 1)
                ckb.Checked = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controleDepart"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T TrouverControleRecursif<T>(Control controleDepart, string id) where T : Control
        {
            // this is null by default
            T found = default(T);

            int controlCount = controleDepart.Controls.Count;

            if (controlCount > 0)
            {
                for (int i = 0; i < controlCount; i++)
                {
                    Control activeControl = controleDepart.Controls[i];
                    if (activeControl is T)
                    {
                        found = controleDepart.Controls[i] as T;
                        if (found != null)
                            if (string.Compare(id, found.ID, true) == 0) break;
                            else found = null;
                    }
                    else
                    {
                        found = TrouverControleRecursif<T>(activeControl, id);
                        if (found != null) break;
                    }
                }
            }
            return found;
        }

        public static void OuvrirUrl(Control view,string url)
        {
            ScriptManager.RegisterStartupScript(view, view.GetType(), "OuvrirUrlFenetreCourante", String.Format("window.open('{0}','_self',false)", url), true);
        }
        
    }
}
