using System;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Tests.Builder
{
    public static class SprintBuilder
    {
        public static Sprint Create()
        {
            return new Sprint();
        }
        public static Sprint WithProduct(this Sprint sprint, Product product)
        {
            sprint.Product = product;
            return sprint;
        }
        public static Sprint WithDateStart(this Sprint sprint, DateTime start)
        {
            sprint.Start = start;
            return sprint;
        }
        public static Sprint WithDateEnd(this Sprint sprint, DateTime end)
        {
            sprint.End = end;
            return sprint;
        }

        public static Sprint WithDescription(this Sprint sprint, string description)
        {
            sprint.Description = description;
            return sprint;
        }
    }
}
