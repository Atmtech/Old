using System;

namespace ATMTECH.WPF.Diagram
{
    public interface IGroupable
    {
        Guid ID { get; }
        Guid ParentID { get; set; }
        bool IsGroup { get; set; }
    }
}
