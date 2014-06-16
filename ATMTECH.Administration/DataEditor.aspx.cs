using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Services;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Common.Utilities;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Utils.Web;
using ATMTECH.Web;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.Administration
{
    public partial class DataEditor : PageBaseAdministration, IDataEditorPresenter
    {
        public DataEditorPresenter Presenter { get; set; }

        public IList<EntityInformation> EntityInformations
        {
            get { return (IList<EntityInformation>)Session["EntityInformations"]; }
            set
            {
                if (Session["EntityInformations"] == null)
                    Session["EntityInformations"] = value;
            }
        }
        public IList<EntityProperty> EntityProperties
        {
            get { return (IList<EntityProperty>)Session["EntityProperties"]; }
            set
            {
                if (Session["EntityProperties"] == null)
                    Session["EntityProperties"] = value;
            }
        }

        public string Entity
        {
            get
            {
                string val = QueryString.GetQueryStringValue("Entity");
                if (String.IsNullOrEmpty(val))
                {
                    val = "Product";
                }
                return val;
            }
        }
        public string IsEnterpriseRuled
        {
            get
            {
                string val = QueryString.GetQueryStringValue("IsEnterpriseRuled");
                if (String.IsNullOrEmpty(val))
                {
                    val = "1";
                }
                return val;
            }
        }
        public string NameSpace
        {
            get
            {
                ManageClass manageClass = new ManageClass();
                if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", Entity))
                {
                    return "ATMTECH.ShoppingCart.Entities";
                }
                if (manageClass.IsExistInNameSpace("ATMTECH.Entities", Entity))
                {
                    return "ATMTECH.Entities";
                }

                return "ATMTECH.ShoppingCart.Entities";
            }
        }
        public object EnterpriseList
        {
            set
            {
                cboSelectionEntreprise.DataSource = value;
                cboSelectionEntreprise.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboSelectionEntreprise.DataValueField = BaseEntity.ID;
                cboSelectionEntreprise.DataBind();
            }
        }
        public string Enterprise
        {
            get { return cboSelectionEntreprise.SelectedValue; }
        }
        public string InnerTitle
        {
            set { lblTitle.Text = value; }
        }
        public bool IsInserting
        {
            get { return Convert.ToBoolean(Session["IsInserting"]); }
            set { Session["IsInserting"] = value; }
        }
        public int? IdCopy
        {
            set
            {
                grdData.DataSource = Presenter.RechercheInformation(txtSearch.Text, 0);
                grdData.DataBind();
                EditData(value);
            }
        }
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }

            Presenter.OnViewLoaded();

            if (IsEnterpriseRuled == "0")
            {
                pnlEnterprise.Visible = false;
            }


            GenererControles(Convert.ToInt32(Session["IdSelectionner"]));

            if (IsEnterpriseRuled == "0")
            {
                Search();
            }
        }
        private void FindGridViewField(GridView gridView, string nameSpace, string entity)
        {


            DataControlField dataControlField1 = gridView.Columns[0];
            DataControlField dataControlField2 = gridView.Columns[1];
            DataControlField dataControlField3 = gridView.Columns[2];
            DataControlField dataControlField4 = gridView.Columns[3];


            gridView.Columns.Clear();
            gridView.Columns.Add(dataControlField1);
            gridView.Columns.Add(dataControlField2);
            gridView.Columns.Add(dataControlField3);
            gridView.Columns.Add(dataControlField4);



            IList<PropertyWithLabel> listeProprieteSansCelleSysteme = Presenter.ListeProprieteSansCelleSysteme(nameSpace, entity);
            foreach (PropertyWithLabel propertyWithLabel in listeProprieteSansCelleSysteme)
            {


                if (propertyWithLabel.PropertyInfo.PropertyType.Namespace == "System")
                {
                    if (propertyWithLabel.PropertyInfo.Name != "Language")
                    {


                        BoundField field = new BoundField
                                               {
                                                   DataField = propertyWithLabel.PropertyInfo.Name,
                                                   HeaderText = propertyWithLabel.Label

                                               };
                        gridView.Columns.Add(field);
                    }
                }
                else
                {
                    if (propertyWithLabel.PropertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                    {
                        TemplateField customField = new TemplateField
                                                        {
                                                            ItemTemplate =
                                                                new GridViewTemplate(DataControlRowType.DataRow,
                                                                                     propertyWithLabel.PropertyInfo.Name),
                                                            HeaderTemplate =
                                                                new GridViewTemplate(DataControlRowType.Header,
                                                                                     propertyWithLabel.PropertyInfo.Name)
                                                        };
                        gridView.Columns.Add(customField);
                    }
                }
            }
        }
        private void Search()
        {
            FindGridViewField(grdData, NameSpace, Entity);
            grdData.DataSource = Presenter.RechercheInformation(txtSearch.Text, 0);
            grdData.DataBind();
            pnlSaveDone.Visible = false;
            IsInserting = false;
        }
        protected void SearchClick(object sender, EventArgs e)
        {
            Search();
        }
        private void EditData(int? id)
        {
            if (id != null)
            {
                windowEditData.OuvrirFenetre("Édition");
                IsInserting = false;
                GenererControles((int)id);
            }

        }
        protected void RowCommandClick(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index <= grdData.Rows.Count - 1)
            {


                GridViewRow selectedRow = grdData.Rows[index];
                TableCell id = selectedRow.Cells[3];

                switch (e.CommandName)
                {
                    case "Copie":
                        Presenter.Copy(Convert.ToInt32(id.Text));
                        break;
                    case "Edition":
                        {
                            EditData(Convert.ToInt32(id.Text));
                        }
                        break;
                    case "Inactive":
                        {
                            Presenter.Inactivate(Convert.ToInt32(id.Text));
                            Search();
                        }
                        break;
                }
            }

        }
        private void GenererControles(int id)
        {
            if (Session["IdSelectionner"] == null) Session["IdSelectionner"] = 0;
            Session["IdSelectionner"] = id;
            pnlControl.Controls.Clear();

            IList<ControlWithLabel> controlWithLabels = Presenter.CreateControls(NameSpace, Entity, IsInserting, id, Convert.ToInt32(cboSelectionEntreprise.SelectedValue));

            Table table = new Table { Width = new Unit(100, UnitType.Percentage) };

            foreach (ControlWithLabel controlWithLabel in controlWithLabels)
            {
                TableRow tableRow = new TableRow();
                TableCell tableCellLabel = new TableCell { Width = new Unit(175, UnitType.Pixel) };
                TableCell tableCellControl = new TableCell();

                tableCellLabel.Controls.Add(controlWithLabel.Label);
                tableCellControl.Controls.Add(controlWithLabel.Control);

                tableRow.Cells.Add(tableCellLabel);
                tableRow.Cells.Add(tableCellControl);
                table.Rows.Add(tableRow);
            }
            pnlControl.Controls.Add(table);
        }
        private void Save()
        {
            ManageClass manageClass = new ManageClass();
            Type type = manageClass.GetTypeFromNameSpace(NameSpace, Entity);
            Object entity = Activator.CreateInstance(type, null);

            foreach (Control control in type.GetProperties().Select(propertyInfo => Pages.FindControlRecursive(pnlControl, propertyInfo.Name)))
            {
                var textBoxAvance = control as TextBoxAvance;
                if (textBoxAvance != null)
                {
                    manageClass.AssignValue(type, entity, textBoxAvance.Text, textBoxAvance.ID);
                }

                var alphaNumTextBoxAvance = control as AlphaNumTextBoxAvance;
                if (alphaNumTextBoxAvance != null)
                {
                    manageClass.AssignValue(type, entity, alphaNumTextBoxAvance.ValeurDecimale.ToString(), alphaNumTextBoxAvance.ID);
                }

                var dateTextBoxAvance = control as DateTextBoxAvance;
                if (dateTextBoxAvance != null)
                {
                    manageClass.AssignValue(type, entity, dateTextBoxAvance.Text, dateTextBoxAvance.ID);
                }
                var comboboxAvance = control as ComboBoxAvance;
                if (comboboxAvance != null)
                {
                    manageClass.AssignValue(type, entity, comboboxAvance.SelectedValue, comboboxAvance.ID);
                }
                var checkboxAvance = control as CheckBoxAvance;
                if (checkboxAvance != null)
                {
                    manageClass.AssignValue(type, entity, checkboxAvance.Checked ? "True" : "False", checkboxAvance.ID);
                }

                var comboboxSimple = control as ComboBoxSimple;
                if (comboboxSimple != null)
                {
                    manageClass.AssignValue(type, entity, comboboxSimple.SelectedValue, comboboxSimple.ID);
                }

                var textEditorAvance = control as TextEditorAvance;
                if (textEditorAvance != null)
                {
                    manageClass.AssignValue(type, entity, textEditorAvance.Text, textEditorAvance.ID);
                }


            }


            string entreprise = Enterprise;
            Presenter.Save(entity);
            cboSelectionEntreprise.SelectedValue = entreprise;
            Search();
            GenererControles(Convert.ToInt32(Session["IdSelectionner"]));
            pnlSaveDone.Visible = true;

            IsInserting = false;
        }
        protected void SaveClick(object sender, EventArgs e)
        {
            Save();
            windowEditData.FermerFenetre();
        }
        protected void AddClick(object sender, EventArgs e)
        {
            windowEditData.OuvrirFenetre("Ajouter une donnée");
            IsInserting = true;
            GenererControles(0);
        }
        protected void CancelClick(object sender, EventArgs e)
        {
            GenererControles((int)Session["IdSelectionner"]);
            windowEditData.FermerFenetre();
        }
        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            grdData.DataBind();
            Search();
        }
      
      
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem is Order)
                {
                    string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[18].Text);
                    switch (decodedText)
                    {
                        case "1":
                            e.Row.Cells[18].Text = "Liste de souhait";
                            break;
                        case "2":
                            e.Row.Cells[18].Text = "Commandé par le client";
                            break;
                        case "3":
                            e.Row.Cells[18].Text = "Envoyé au client";
                            break;
                    }
                }
                for (int i = 3; i < e.Row.Cells.Count; i++)
                {
                    string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    if (decodedText == "True")
                        decodedText = "Vrai";
                    if (decodedText == "False")
                        decodedText = "Faux";

                    if (!string.IsNullOrEmpty(decodedText))
                    {
                        decodedText = Pages.RemoveHtmlTag(decodedText);

                        if (decodedText.Length > 100)
                        {
                            e.Row.Cells[i].Text = decodedText.Substring(0, 100) + "...";
                        }
                        else
                        {
                            e.Row.Cells[i].Text = decodedText;
                        }

                    }
                }

            }
        }

    }
}