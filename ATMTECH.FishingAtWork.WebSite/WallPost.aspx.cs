//using System;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.WebSite.Base;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class WallPost : PageBaseFishingAtWork, IWallPostPresenter
//    {
//        public WallPostPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();
//        }


//        protected void WritePostClick(object sender, EventArgs e)
//        {
//            Presenter.WritePost();
//        }


//        public string Post
//        {
//            get { return CKEditorEditorPost.Text; }
//            set { CKEditorEditorPost.Text = value; }
//        }

//        public bool IsPanelWritePost
//        {
//            get { return pnlWritePost.Visible; }
//            set
//            {
//                if (value)
//                {
//                    pnlPostList.Visible = false;
//                    pnlWritePost.Visible = true;
//                }
//                else
//                {
//                    pnlPostList.Visible = true;
//                    pnlWritePost.Visible = false;
//                }
//            }
//        }

//        protected void SavePostClick(object sender, EventArgs e)
//        {
//            Presenter.SavePost();
//        }

//        protected void CancelPostClick(object sender, EventArgs e)
//        {
//            Presenter.CancelPost();
//        }
//    }
//}