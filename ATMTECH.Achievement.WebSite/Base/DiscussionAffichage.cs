using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.WebSite.Base
{
    public class DiscussionAffichage
    {
        public Discussion Discussion { get; set; }

        public string CreerDiscussion()
        {
            string html = string.Empty;
            html += "<script type='text/javascript'>";
            html += "function testing(id){";
            html += "alert(id);";
            html += "}";
            //html += "$('#tamere').click(function() {";
            //html += "alert(this.id);";
            //html += "});";
            ////html += "$('form').submit(function (event) {";
            ////html += "event.preventDefault();";
            ////html += "alert($(this).val());";
            ////html += "var posting = $.post('Wall.aspx');";
            ////html += "});";
            html += "</script>";

            //        <div class="barreMenuDiscussion" style="text-align: right; padding-right: 15px;">
            //    <asp:Button runat="server" CssClass="boutonDiscussion" Text="Publier commentaire" />
            //</div>



            html += "<div style='padding:10px 10px 10px 10px;'>";
            html += "       <table style='width: 100%;'>";
            html += "           <tr>";
            html += "               <td style='vertical-align: top;padding-right: 15px;width: 45px;'>";
            html += "                   <img src='../images/User/moose.jpg' class='imageDiscussionMur' /></td>";
            html += "               <td>";
            html += "                   <div class='bubbleLeft'>";
            html += "                       <div style='padding: 15px 15px 15px 15px; min-height: 40px;text-align:left;'>";
            html += "                           <div class='titreUtilisateurDiscussionMur'>" + Discussion.Utilisateur.FirstNameLastName + " a dit:</div>";
            html += "                           <div class='titreTempsPosteDiscussionMur'>Il y a " + Discussion.DateCreated + "</div>";
            html += "                           <div class='texteDiscussionMur'>";
            html += Discussion.Description;
            html += "                           </div>";
            html += "                           <a href=''><img src='images/badge/comments-48.png' style='height:16px;width:16px;'></a><img src='images/badge/like-48.png' style='height:16px;width:16px;'>";
            html += "<textarea name='Text1' cols='40' rows='5' class='txtInput'></textarea>";
            html += "<input class='bouton' value='Commenter' type='button' Id='tamere' onclick='testing(1)'>";
            foreach (DiscussionReponse discussionReponse in Discussion.ListeDiscussionReponse)
            {
                html += "                           <table style='width: 100%'>";
                html += "                               <tr>";
                html += "                                   <td>";
                html += "                                       <div class='bubbleRight'>";
                html += "                                           <div style='padding: 15px 15px 15px 15px; min-height: 40px;text-align:left;'>";
                html += "                                                   <div class='titreUtilisateurDiscussionMur'>" + discussionReponse.Utilisateur.FirstNameLastName + " a dit:</div>";
                html += "                                                   <div class='titreTempsPosteDiscussionMur'>Il y a " + discussionReponse.DateCreated + "</div>";
                html += "                                                   <div class='texteDiscussionMur'>";
                html += discussionReponse.Description;
                html += "                                                   </div>";
                html += "                                                   <img src='images/badge/like-48.png' style='height:16px;width:16px;'>";
                html += "                                           </div>";
                html += "                                       </div>";
                html += "                                   </td>";
                html += "                                   <td style='width: 45px;'>";
                html += "                                       <div style='vertical-align: top; margin-left: 15px;'>";
                html += "                                           <img src='../images/User/moose.jpg' class='imageDiscussionMur' />";
                html += "                                       </div>";
                html += "                                   </td>";
                html += "                               </tr>";
                html += "                           </table>";
            }


            html += "                       </div>";
            html += "                   </div>";
            html += "               </td>";
            html += "           </tr>";
            html += "       </table>";
            html += "</div>";
            return html;
        }
    }
}