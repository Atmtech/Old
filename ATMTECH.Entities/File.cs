using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class File : BaseEntity
    {
        public const string FILE_NAME = "FileName";
        public const string FILE_TYPE = "FileType";
        public const string CATEGORY = "Category";

        public int Size { get; set; }
        public string Title { get; set; }
        public FileType FileType { get; set; }
        public bool IsInUse { get; set; }
        public string ServerPath { get; set; }
        public string FileName { get; set; }
        public string Category { get; set; }
        public string RootImagePath { get; set; }

        public string SearchUpdate { get { return FileName + " " + Title; } }
        public string ComboboxDescriptionUpdate { get { return Description + " " + Title + " " + FileName ; } }

    }
}
