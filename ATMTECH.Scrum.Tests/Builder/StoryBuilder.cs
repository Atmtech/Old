using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Tests.Builder
{
    public static class StoryBuilder
    {
        public static Story Create()
        {
            return new Story();
        }
        public static Story WithProduct(this Story story, Product product)
        {
            story.Product = product;
            return story;
        }
        public static Story WithComment(this Story story, string comment)
        {
            story.Comment = comment;
            return story;
        }
        public static Story WithDescription(this Story story, string description)
        {
            story.Description = description;
            return story;
        }
        public static Story WithPoint(this Story story, int point)
        {
            story.Point = point;
            return story;
        }

        public static Story WithSprint(this Story story, Sprint sprint)
        {
            story.Sprint = sprint;
            return story;
        }

        public static Story WithStatus(this Story story, string status)
        {
            story.Status = status;
            return story;
        }

    }
}
