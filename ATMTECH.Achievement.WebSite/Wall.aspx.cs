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
                    string html = string.Empty;
                    foreach (Discussion discussion in value)
                    {
                        DiscussionAffichage discussionAffichage = new DiscussionAffichage { Discussion = discussion };
                        html += discussionAffichage.CreerDiscussion();
                    }
                    Literal literal = new Literal() { Text = html };
                    placeHolderDiscussion.Controls.Add(literal);
                }
            }
        }

        public string IdDiscussion { get { return Session["IdDiscussion"].ToString(); } set { Session["IdDiscussion"] = value; } }
        public string Commentaire
        {
            get
            {
                return Request.Form["txtCommentaire" + IdDiscussion];
            }
        }

        protected void test(object sender, EventArgs e)
        {
            string  x = Request.Form["txtCommentaire1"];
            string value = Request.Form["txtBox1"];
        }
    }
}