using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Utils;

namespace ATMTECH.CalculPeche.WebSite
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenererSqlClick(object sender, EventArgs e)
        {
            ManageClass manageClass = new ManageClass();
            List<string> classes = manageClass.GetAllClassesFromNameSpace("ATMTECH.CalculPeche.Entities");
            foreach (string classe in classes)
            {
                txtSql.Text += manageClass.GenerateCreateTableSqlFromClass("ATMTECH.CalculPeche.Entities", classe) + Environment.NewLine + Environment.NewLine;
            }
        }
    }
}