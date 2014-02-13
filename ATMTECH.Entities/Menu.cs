using System;
using System.Collections.Generic;

namespace ATMTECH.Entities
{
    [Serializable]
    public class Menu : BaseEntity
    {
        public const string MENU_ID = "MenuId";
        public const string PARENT_ID = "ParentId";
        public const string ORDER_BY = "OrderBy";

        public string Title { get; set; }
        public string Url { get; set; }
        public Menu ParentId { get; set; }
        public string MenuId { get; set; }
        public int OrderBy { get; set; }
        public IList<Menu> SubMenu { get; set; }
    }
}
