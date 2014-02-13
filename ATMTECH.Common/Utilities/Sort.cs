using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using ATMTECH.Common.Constant;

namespace ATMTECH.Common.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class Tri<TModel>
    {
        public static IList<TModel> Sort(IList<TModel> toSortList, IList<string> columnName, OrderByType.OrderType orderType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (String item in columnName)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
                stringBuilder.Append(orderType);
                stringBuilder.Append(",");
            }

            if (toSortList != null)
                toSortList = toSortList.AsQueryable().OrderBy(stringBuilder.ToString().TrimEnd(',')).ToList();

            return toSortList;
        }

        /// <summary>
        /// Méthode semblable à l'autre, mais qui accepte une spécification de colonnes,
        /// exemple "NomEmploye DESC"
        /// </summary>
        /// <param name="toSortList"></param>
        /// <param name="colonneTri"></param>
        /// <returns></returns>
        public static IList<TModel> Sort(IList<TModel> toSortList, string colonneTri)
        {
            if (toSortList != null)
                toSortList = toSortList.AsQueryable().OrderBy(colonneTri).ToList();

            return toSortList;
        }
    }
}
