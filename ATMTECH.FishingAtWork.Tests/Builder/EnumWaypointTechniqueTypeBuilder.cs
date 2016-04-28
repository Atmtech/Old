using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class EnumWaypointTechniqueTypeBuilder
    {
        public static EnumWaypointTechniqueType Create()
        {
            return new EnumWaypointTechniqueType();
        }
        public static EnumWaypointTechniqueType WithCode(this EnumWaypointTechniqueType enume, string code)
        {
            enume.Code = code;
            return enume;
        }
        public static EnumWaypointTechniqueType WithDescription(this EnumWaypointTechniqueType enume, string description)
        {
            enume.Description = description;
            return enume;
        }


    }

}
