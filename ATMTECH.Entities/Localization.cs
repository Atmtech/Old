using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class Localization : BaseEntity
    {
        public const string OBJECTID = "ObjectId";
        public const string PAGE = "Page";

        public string ObjectId { get; set; }
        public string Page { get; set; }
        public string English { get; set; }
        public string French { get; set; }

    }
}
