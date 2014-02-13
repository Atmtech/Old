using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Views.Interface
{
    public interface IContentPresenter : IViewBase
    {
        string Value { get; set; }
        string PageName { get; set; }
        string Description { get; set; }
        string QueryStringPageName { get; }
        IList<ContentCms> PageList { set; }
        IList<Language> LanguageList { set; }
        bool IsAdministrator { set; }
        string LanguageValue { get; set; }
        ContentCms CurrentContent { get; set; }
    }
}
