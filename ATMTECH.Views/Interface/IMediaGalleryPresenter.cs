using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Views.Interface
{
    public interface IMediaGalleryPresenter : IViewBase
    {
        IList<File> Files { set; }
    }
}
