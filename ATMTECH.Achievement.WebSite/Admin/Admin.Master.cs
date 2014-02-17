using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Tests.Database;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Test.Builder;
using ATMTECH.Web.Services.Base;
using File = ATMTECH.Entities.File;
using Parameter = System.Web.UI.WebControls.Parameter;

namespace ATMTECH.Achievement.WebSite.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenererDatabase(object sender, EventArgs e)
        {
            Initialisation initialisation = new Initialisation();
            initialisation.CreerDatabase();
        }



    }
}