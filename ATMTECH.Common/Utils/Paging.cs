using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.Common.Constant;

namespace ATMTECH.Common.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class Paging<TModel>
    {
        public static IList<TModel> PagingAvecTri(IList<TModel> lstATrie, string parametreTri, int nbEnreg, int indexDebutRangee)
        {
            IQueryable<TModel> lst = lstATrie.AsQueryable();
            if (!string.IsNullOrEmpty(parametreTri))
            {
                lst = lst.OrderBy(parametreTri);
            }
            return Queryable.Take(Queryable.Skip(lst, indexDebutRangee), nbEnreg).ToList();
        }


        public static IList<TModel> PagingAvecTri(IList<TModel> lstATrie, IList<string> lstNomColonne, int nbEnreg,
                                                      int indexDebutRangee, OrderByType.OrderType OrderType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (String item in lstNomColonne)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
                stringBuilder.Append(OrderType);
                stringBuilder.Append(",");
            }

            lstATrie =
                Queryable.Take(Queryable.Skip(lstATrie.AsQueryable().OrderBy(stringBuilder.ToString().TrimEnd(',')), indexDebutRangee), nbEnreg).ToList();

            return lstATrie;
        }


        public static IList<TModel> PagingAvecTriMultiple(IList<TModel> lstATrie, IList<string> lstNomColonne,
                                                              int nbEnreg, int indexDebutRangee,
                                                              IList<OrderByType.OrderType> lstOrderType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int compteur = 0;

            foreach (String item in lstNomColonne)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
                stringBuilder.Append(lstOrderType[compteur]);
                stringBuilder.Append(",");
                compteur++;
            }

            lstATrie =
                Queryable.Take(Queryable.Skip(lstATrie.AsQueryable().OrderBy(stringBuilder.ToString().TrimEnd(',')), indexDebutRangee), nbEnreg).ToList();

            return lstATrie;
        }

        public static IList<TModel> PagingSansTri(IList<TModel> lstATrie, int nbEnreg, int indexDebutRangee)
        {
            lstATrie = Queryable.Take(Queryable.Skip(lstATrie.AsQueryable(), indexDebutRangee), nbEnreg).ToList();

            return lstATrie;
        }

        public static OrderByType.OrderType TypeDeTri(string parametreTri)
        {
            string typeTrie = string.Empty;
            int indexTrie = parametreTri.LastIndexOf(" ");

            // Obtient le nom du parametre de tri et l'ordre de tri.
            if (indexTrie != -1)
                typeTrie = parametreTri.Substring(parametreTri.LastIndexOf(" ") + 1);

            return typeTrie.ToUpper().CompareTo("DESC") == 0 ? OrderByType.OrderType.DESC : OrderByType.OrderType.ASC;
        }
    }

   
    public static class PagingExtensions
    {

   
        public static IList<TModel> TrierEtPaginer<TModel>(this IList<TModel> liste, string ordre, int nbEnregMax, int indexDebut)
        {
            IQueryable<TModel> lst = liste.AsQueryable();
            if (!string.IsNullOrEmpty(ordre))
            {
                lst = lst.OrderBy(ordre);
            }
            return Queryable.Take(Queryable.Skip(lst, indexDebut), nbEnregMax).ToList();
        }
    }
}
