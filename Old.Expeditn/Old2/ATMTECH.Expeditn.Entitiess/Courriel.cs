using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Courriel : BaseEntity
    {
        public const string CODE = "Code";

        public string Code { get; set; }
        public string From { get; set; }
        public string SubjectFr { get; set; }
        public string BodyFr { get; set; }
        public string SubjectEn { get; set; }
        public string BodyEn { get; set; }
    }
}
