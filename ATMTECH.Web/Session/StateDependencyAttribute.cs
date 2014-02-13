using System;

namespace ATMTECH.Web.Session
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class StateDependencyAttribute : Attribute
    {
        public string Clef { get; private set; }
        public StateDependencyAttribute(string clef)
        {
            Clef = clef;
        }
    }
}
