//using System;
//using System.Web.UI.WebControls;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.WebSite.Base;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class AdminSpecies : PageBaseFishingAtWork, IAdminSpeciesPresenter
//    {
//        public AdminSpeciesPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();

//        }

//        protected void RowCommandClick(object sender, GridViewCommandEventArgs e)
//        {
//           if (e.CommandName == "OpenSpecies")
//           {
               
//           }
//        }
//    }
//}