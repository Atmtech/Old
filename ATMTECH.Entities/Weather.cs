using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class Weather : BaseEntity
    {
        public string SkyConditions { get; set; }
        public string Wind { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
    }
}
