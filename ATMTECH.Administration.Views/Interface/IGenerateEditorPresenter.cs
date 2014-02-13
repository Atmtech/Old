using System.Collections.Generic;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IGenerateEditorPresenter : IViewBase
    {
        Dictionary<string, string> Entities { set; }
        string NameSpaceSelected { get; }
        string BinDirectory { get; }
        string DataEditorDirectory { get; }
        string NameSpace { get; set; }
        string PageTitle { get; set; }
        string PageAspx { get; set; }

    }
}
