using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class FileType : BaseEnumeration
    {
        public const string TYPE = "Type";
        public class Codes
        {
            public const string PNG = "png";
            public const string JPG = "jpg";
            public const string PDF = "pdf";
            public const string UNKNOWN = "unk";

        }
    }
}
