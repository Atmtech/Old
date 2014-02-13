using ATMTECH.Entities;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Tests.Builder
{
    public static class TaskBuilder
    {
        public static Task Create()
        {
            return new Task();
        }
        public static Task WithStory(this Task task, Story story)
        {
            task.Story = story;
            return task;
        }
        public static Task WithEstimateTime(this Task task, decimal estimateTime)
        {
            task.EstimateTime = estimateTime;
            return task;
        }
        public static Task WithUser(this Task task, User user)
        {
            task.User = user;
            return task;
        }
        public static Task WithDescription(this Task task, string description)
        {
            task.Description = description;
            return task;
        }
    }
}
