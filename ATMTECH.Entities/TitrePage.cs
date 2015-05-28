using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class TitrePage : BaseEntity
    {
        public const String PAGE = "Page";
        public string Page { get; set; }
        public string TitreEn { get; set; }
        public string TitreFr { get; set; }

    }
}
