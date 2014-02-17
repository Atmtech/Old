//using System;
//using System.Collections.Generic;
//using System.Web.UI.WebControls;
//using ATMTECH.FishingAtWork.Entities;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.Views.Pages;
//using ATMTECH.FishingAtWork.WebSite.Base;
//using ATMTECH.FishingAtWork.WebSite.UserControls;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class SiteList : PageBaseFishingAtWork, ISiteListPresenter
//    {
//        public SiteListPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();
//        }


//        public IList<Entities.Site> SitesList
//        {
//            set
//            {
//                dataListSite.DataSource = value;
//                dataListSite.DataBind();
//            }
//        }

//        public Entities.Site SiteInformation
//        {
//            set
//            {
//                googleMapThumbnailWindow.Zoom = value.Zoom;
//                googleMapThumbnailWindow.Latitude = value.Latitude;
//                googleMapThumbnailWindow.Longitude = value.Longitude;
//                googleMapThumbnailWindow.SetPosition();

//                lblName.Text = value.Name;
//                lblInformation.Text = value.Description;
//                lblSpecies.Text = "";
//                int i = 0;
//                foreach (SiteSpecies siteSpeciese in value.SiteSpecies)
//                {
//                    i++;
//                    lblSpecies.Text += i + ". " + siteSpeciese.Species.Name + "<br>";
//                }
//            }
//        }


//        protected void SiteListCommand(object source, DataListCommandEventArgs e)
//        {
//            if (e.CommandName == "info")
//            {
//                Presenter.GetInformation(Convert.ToInt32(e.CommandArgument));
//                pnlSiteInformation.Visible = true;
//                pnlList.Visible = false;
//            }
//        }

//        protected void SiteListDataBound(object sender, DataListItemEventArgs e)
//        {
//            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
//            {
//                Entities.Site dataItem = (Entities.Site)e.Item.DataItem;
//                ((Label)e.Item.FindControl("lblSiteName")).Text = dataItem.Name;
//                ((GoogleMap)e.Item.FindControl("googleMapThumbnail")).Latitude = dataItem.Latitude;
//                ((GoogleMap)e.Item.FindControl("googleMapThumbnail")).Longitude = dataItem.Longitude;
//                ((GoogleMap)e.Item.FindControl("googleMapThumbnail")).Zoom = dataItem.Zoom;
//                ((GoogleMap)e.Item.FindControl("googleMapThumbnail")).SetPosition();
//            }
//        }

//        protected void ShowSiteListClick(object sender, EventArgs e)
//        {
//            Presenter.OpenSiteList();
//        }
//    }
//}