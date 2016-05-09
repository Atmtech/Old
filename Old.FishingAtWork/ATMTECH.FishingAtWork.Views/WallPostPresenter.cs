using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class WallPostPresenter : BaseFishingAtWorkPresenter<IWallPostPresenter>
    {
        public IWallPostService WallPostService { get; set; }
        public IPlayerService PlayerService { get; set; }

        public WallPostPresenter(IWallPostPresenter view)
            : base(view)
        {
        }

        public IList<WallPostDTO> GetWallPost(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<WallPostDTO> rtn = WallPostService.GetWallPost(parametreTrie, nbEnreg, indexDebutRangee);
            return rtn;
        }

        public int GetWallPostCount()
        {
            return WallPostService.GetWallPostCount();
        }

        public void WritePost()
        {
            View.IsPanelWritePost = true;
        }

        public void SavePost()
        {
            WallPost wallPost = new WallPost();
            wallPost.Player = PlayerService.AuthenticatePlayer;
            wallPost.Post = View.Post;
            WallPostService.WritePost(wallPost);
            NavigationService.Redirect(Pages.Pages.WALL_POST);
        }

        public void CancelPost()
        {
            View.IsPanelWritePost = false;
        }
    }
}
