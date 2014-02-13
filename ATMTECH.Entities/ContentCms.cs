using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class ContentCms : BaseEntity
    {
        public const string PAGENAME = "PageName";
        public string Value { get; set; }
        public string PageName { get; set; }
        public string StripedValue { get; set; }
    }
}
