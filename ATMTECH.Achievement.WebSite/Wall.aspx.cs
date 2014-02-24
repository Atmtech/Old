using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.WebSite.Base;

namespace ATMTECH.Achievement.WebSite
{
    public partial class Wall : PageBaseAchievement<DiscussionPresenter, IDiscussionPresenter>, IDiscussionPresenter
    {
        public IList<Discussion> Discussions
        {
            set
            {
                if (value != null)
                {
                    datalistDiscussion.DataSource = value;
                    datalistDiscussion.DataBind();
                }
            }
        }

        protected void ItemDataBoundDataListDiscussion(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Discussion dataItem = (Discussion)e.Item.DataItem;
                if (dataItem.ListeDiscussionReponse.Count > 0)
                {
                    DataList dataList = ((DataList)e.Item.FindControl("dataListDiscussionReponse"));
                    dataList.DataSource = dataItem.ListeDiscussionReponse;
                    dataList.DataBind();
                }
            }
        }

        protected void ItemCommandDiscussionReponseClick(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "JaimeCommentaire")
            {
                Presenter.JaimeCommentaire(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void ItemCommandDiscussionClick(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "OuvrirPanneauCommentaire")
            {
                Panel panel = e.Item.FindControl("pnlCommenter") as Panel;
                if (panel != null)
                    panel.Visible = true;
            }
            if (e.CommandName == "JaimeMessage")
            {
                Presenter.JaimeMessage(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "PublierCommentaire")
            {
                TextBox txtCommentaire = e.Item.FindControl("txtCommentaire") as TextBox;
                if (txtCommentaire != null)
                    Presenter.PublierCommentaire(Convert.ToInt32(e.CommandArgument), txtCommentaire.Text);
            }
        }

        protected void btnPublierMessageSurLeMurClick(object sender, EventArgs e)
        {
            Presenter.PublierMessageSurLeMur(txtMessageMur.Text);
        }

        protected void btnEcrireMessageSurLeMurClick(object sender, EventArgs e)
        {
            pnlCommentaire.Visible = true;
        }
    }
}