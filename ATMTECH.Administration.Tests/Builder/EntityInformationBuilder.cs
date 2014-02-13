using ATMTECH.Entities;

namespace ATMTECH.Administration.Tests.Builder
{
    public static class EntityInformationBuilder
    {
        public static EntityInformation Create()
        {
            return new EntityInformation();
        }
        public static EntityInformation WithNameSpace(this EntityInformation entityInformation, string nameSpace)
        {
            entityInformation.NameSpace = nameSpace;
            return entityInformation;
        }
        public static EntityInformation WithPageTitle(this EntityInformation entityInformation, string pageTitle)
        {
            entityInformation.PageTitle = pageTitle;
            return entityInformation;
        }
        public static EntityInformation WithPageAspx(this EntityInformation entityInformation, string pageAspx)
        {
            entityInformation.PageAspx = pageAspx;
            return entityInformation;
        }
    }
}
