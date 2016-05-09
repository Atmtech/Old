using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Common.Utils;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class CreerSql : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenererSqlClick(object sender, EventArgs e)
        {
            ManageClass manageClass = new ManageClass();
            List<string> classes = manageClass.GetAllClassesFromNameSpace("ATMTECH.FishingAtWork.Entities");
            foreach (string classe in classes)
            {
                txtSql.Text += manageClass.GenerateCreateTableSqlFromClass("ATMTECH.FishingAtWork.Entities", classe) + Environment.NewLine + Environment.NewLine;
            }
        }

        protected void btnTestDaoClick(object sender, EventArgs e)
        {
            
        }
    }
}