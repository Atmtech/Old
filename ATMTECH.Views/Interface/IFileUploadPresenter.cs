using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Views.Interface
{
    public interface IFileUploadPresenter : IViewBase
    {
        void SaveImageFile();
        string Category { get; set; }
        IList<File> AllFiles { set; }
        string RootImagePath { get; }
    }
}
