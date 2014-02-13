using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Views
{
    public class MediaGalleryPresenter : BasePresenter<IMediaGalleryPresenter>
    {
        public IDAOFile DAOFile { get; set; }
        public MediaGalleryPresenter(IMediaGalleryPresenter view)
            : base(view)
        { }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            FileType fileType = new BaseDao<FileType, int>().GetById(1);
            View.Files = DAOFile.GetFileByFileType(fileType);
        }
    }
}
