using System;
using System.Collections;
using System.Reflection;

namespace ATMTECH.Common.Utilities
{
    public static class Debug
    {
        //public static string DisplayTime()
        //{
        //    return DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public static String EntityList(Object entity)
        //{

        //    string retour = "";
        //    if (entity != null)
        //    {

        //        Type type = entity.GetType();
        //        // Affichage entités
        //        retour += "<div style='padding-top:5px;padding-bottom:5px;'><table><tr><td>::</td><td><b>" + type.Name + "</b></td></tr></table></div>";

        //        PropertyInfo[] listePropriete = type.GetProperties();
        //        ArrayList listeProprieteClasse = new ArrayList();

        //        foreach (var propertyInfo in listePropriete)
        //        {
        //            if (propertyInfo.PropertyType.Namespace == "System")
        //            {
        //                listeProprieteClasse.Add(propertyInfo);
        //            }
        //        }

        //        // Placer les enumérations à la fin pour plus de clarté
        //        foreach (var propertyInfo in listePropriete)
        //        {
        //            if (propertyInfo.PropertyType.Namespace != "System")
        //            {
        //                listeProprieteClasse.Insert(listeProprieteClasse.Count, propertyInfo);
        //            }
        //        }



        //        foreach (PropertyInfo prop in listeProprieteClasse)
        //        {
        //            Type propType = prop.PropertyType;
        //            if (!(propType is IEnumerable) && prop.Name.ToLower() != "ischanged")
        //            {
        //                object valeurPropriete = null;

        //                if (prop.PropertyType.IsGenericType)
        //                {
        //                    Object test = prop.GetValue(entity, null);
        //                    IList lstItem = test as IList;

        //                    if (lstItem != null)
        //                    {
        //                        foreach (object t in lstItem)
        //                        {
        //                            retour += "<div style='padding-left:15px;background-color:#98B4B8;'>";
        //                            retour += EntityList(t);
        //                            retour += "</div>";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    valeurPropriete = prop.GetValue(entity, null);
        //                }

        //                if (valeurPropriete != null)
        //                {
        //                    string valeur = valeurPropriete.ToString();

        //                    if (valeur.IndexOf("FishingAtWork", 0) < 0)
        //                    {
        //                        //Affichage valeur
        //                        retour += "<div style='float:left;width:300px;border-bottom:solid 1px #BFBFBF;'>" + prop.Name + ":</div><div style='float:left;border-bottom:solid 1px #BFBFBF;width:500px;'>" + valeur + "</div><div style='clear:both;'></div>";
        //                    }
        //                    else
        //                    {
        //                        retour += "<div style='padding-left:15px;background-color:#C4D5D7;'>";
        //                        retour += EntityList(valeurPropriete);
        //                        retour += "</div>";
        //                    }
        //                }
        //                else
        //                {
        //                    //Affichage valeur
        //                    retour += "<div style='float:left;width:300px;border-bottom:solid 1px #BFBFBF;'>" + prop.Name + ":</div><div style='float:left;border-bottom:solid 1px #BFBFBF;width:500px;'>Null</div><div style='clear:both;'></div>";

        //                }
        //            }
        //        }
        //    }
        //    return retour;
        //}
    }
}
