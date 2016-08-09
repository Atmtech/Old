using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Utils;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenererSqlClick(object sender, EventArgs e)
        {
            ManageClass manageClass = new ManageClass();
            List<string> classes = manageClass.GetAllClassesFromNameSpace("ATMTECH.Expeditn.Entities");
            foreach (string classe in classes)
            {
                txtSql.Text += manageClass.GenerateCreateTableSqlFromClass("ATMTECH.Expeditn.Entities", classe) + Environment.NewLine + Environment.NewLine;
            }
        }

        protected void btnRecalculerChampsClick(object sender, EventArgs e)
        {
            IList<Vehicule> obtenirVehicule = new DAOVehicule().ObtenirVehicule();
            foreach (Vehicule VARIABLE in obtenirVehicule)
            {
                new DAOVehicule().Save(VARIABLE);
            }
        }
    }
}