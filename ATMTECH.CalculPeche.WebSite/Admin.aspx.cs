using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.CalculPeche.Views;
using ATMTECH.CalculPeche.Views.Interface;
using ATMTECH.Common.Utils;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.WebSite
{
    public partial class Admin : PageBase<AdminPresenter, IAdminPresenter>, IAdminPresenter
    {
       
        protected void btnGenererSqlClick(object sender, EventArgs e)
        {
            ManageClass manageClass = new ManageClass();
            List<string> classes = manageClass.GetAllClassesFromNameSpace("ATMTECH.CalculPeche.Entities");
            foreach (string classe in classes)
            {
                txtSql.Text += manageClass.GenerateCreateTableSqlFromClass("ATMTECH.CalculPeche.Entities", classe) + Environment.NewLine + Environment.NewLine;
            }
        }

        protected void btnCreerUneExpedition(object sender, EventArgs e)
        {
            Presenter.CreerExpedition(txtNom.Text, txtDateDebut.Text, txtDateFin.Text);
        }

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}