using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Services;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Common.Utils;
using ATMTECH.Common.Utils.Web;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Web;
using ATMTECH.WebControls;

namespace ATMTECH.Administration.Commerce
{
    public partial class DataEditor :  PageBase<DataEditorPresenter, IDataEditorPresenter>, IDataEditorPresenter
    {
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
                string val = QueryString.GetQueryStringValue("Entite");
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
                //cboSelectionEnterprise.DataSource = value;
                //cboSelectionEnterprise.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                //cboSelectionEnterprise.DataValueField = BaseEntity.ID;
                //cboSelectionEnterprise.DataBind();
            }
        }
        public string Enterprise
        {
            get { return "1"; }
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
           

            //if (IsEnterpriseRuled == "0")
            //{
            //    pnlEnterprise.Visible = false;
            //}


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
                pnlEdit.Visible = true;
                pnlPilotage.Visible = false;
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

            IList<ControlWithLabel> controlWithLabels = Presenter.CreateControls(NameSpace, Entity, IsInserting, id, Convert.ToInt32(Enterprise));

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
                var editor = control as Editor;
                if (editor != null)
                {
                    manageClass.AssignValue(type, entity, editor.Text, editor.ID);
                }
                var combobox = control as ComboBox;
                if (combobox != null)
                {
                    if (!string.IsNullOrEmpty(combobox.SelectedValue))
                    {
                        manageClass.AssignValue(type, entity, combobox.SelectedValue, combobox.ID);
                    }
                }
                var checkbox = control as CheckBox;
                if (checkbox != null)
                {
                    manageClass.AssignValue(type, entity, checkbox.Checked ? "True" : "False", checkbox.ID);
                }
                var datePicker = control as DatePicker;
                if (datePicker != null)
                {
                    manageClass.AssignValue(type, entity, datePicker.Text, datePicker.ID);
                }
                var numeric = control as Numeric;
                if (numeric != null)
                {
                    manageClass.AssignValue(type, entity, numeric.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), numeric.ID);
                }
            }

           // string entreprise = Enterprise;
            Presenter.Save(entity);
            //Enterprise = entreprise;
            Search();
            GenererControles(Convert.ToInt32(Session["IdSelectionner"]));
            IsInserting = false;
        }
        protected void SaveClick(object sender, EventArgs e)
        {
            Save();
            pnlSaveDone.Visible = true;
            pnlEdit.Visible = false;
            pnlPilotage.Visible = true;
        }
        protected void AddClick(object sender, EventArgs e)
        {
            pnlEdit.Visible = true;
            pnlPilotage.Visible = false;
            IsInserting = true;
            GenererControles(0);

        }
        protected void CancelClick(object sender, EventArgs e)
        {
            GenererControles((int)Session["IdSelectionner"]);
            pnlEdit.Visible = false;
            pnlPilotage.Visible = true;
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