using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Services;
using ATMTECH.Common.Utils;
using ATMTECH.WebControls;

namespace ATMTECH.Administration.Commerce
{
    public class GridViewTemplate : ITemplate
    {
        private readonly DataControlRowType _templateType;
        private readonly string _nomColonne;
        private readonly string _libelleColonne;
        private readonly bool _estColonneNative;
        private readonly string _classe;

        public GridViewTemplate(DataControlRowType type, string libelleColonne, string nomColonne, bool estColonneNative, string classe)
        {
            _templateType = type;
            _nomColonne = nomColonne;
            _libelleColonne = libelleColonne;
            _estColonneNative = estColonneNative;
            _classe = classe;
        }
        public void InstantiateIn(Control container)
        {
            switch (_templateType)
            {
                case DataControlRowType.Header:
                    Literal lc = new Literal { Text = string.Format("<b>{0}</b>", _libelleColonne) };
                    container.Controls.Add(lc);
                    break;
                case DataControlRowType.DataRow:
                    LabelGridView labelGridView = new LabelGridView { NomColonne = _nomColonne, EstProprieteNative = _estColonneNative };
                    labelGridView.DataBinding += Data_DataBinding;
                    container.Controls.Add(labelGridView);
                    break;
            }
        }

        private void Data_DataBinding(Object sender, EventArgs e)
        {
            try
            {
                LabelGridView labelGridView = (LabelGridView)sender;
                GridViewRow row = (GridViewRow)labelGridView.NamingContainer;

                if (labelGridView.EstProprieteNative)
                {
                    object evaluation = DataBinder.Eval(row.DataItem, labelGridView.NomColonne);
                    if (evaluation != null)
                    {
                        string valeur = evaluation.ToString().Replace(Environment.NewLine, "");

                        if (valeur == "True")
                            valeur = "Vrai";
                        if (valeur == "False")
                            valeur = "Faux";

                        if (_classe.ToLower() == "order")
                        {
                            switch (valeur)
                            {
                                case "1":
                                    valeur = "Liste de souhait";
                                    break;
                                case "2":
                                    valeur = "Commandé par le client";
                                    break;
                                case "3":
                                    valeur = "Envoyé au client";
                                    break;
                            }
                        }
                        //labelGridView.Text = valeur.Length > 25 ? valeur.Substring(0, 25) + "<a href='#' title='" + valeur + "'>[...]</a>" : valeur;
                        labelGridView.Text = valeur.Length > 25 ? "<div title='" + valeur.Replace("'",".") + "'>" + valeur.Substring(0, 25) + "[...]</div>" : valeur;
                    }
                    else
                    {
                        labelGridView.Text = "<b>Aucune donnée</b>";
                    }

                }
                else
                {
                    string classe = labelGridView.NomColonne;
                    string assembli = string.Empty;
                    if (classe == "ProductLinked")
                    {
                        classe = "Product";
                    }
                    if (classe == "Image")
                    {
                        classe = "File";
                    }
                    if (classe == "ProductCategoryEnglish")
                    {
                        classe = "ProductCategory";
                    }
                    if (classe == "ProductCategoryFrench")
                    {
                        classe = "ProductCategory";
                    }

                    ManageClass manageClass = new ManageClass();

                    if (manageClass.IsExistInNameSpace("ATMTECH.Entities", classe))
                    {
                        assembli = "ATMTECH.Entities";
                    }
                    if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", classe))
                    {
                        assembli = "ATMTECH.ShoppingCart.Entities";
                    }

                    DataEditorService dataEditorService = new DataEditorService();
                    int id = Convert.ToInt32(DataBinder.Eval(row.DataItem, labelGridView.NomColonne + ".Id").ToString());
                    Object o = dataEditorService.GetById(assembli, classe, id);
                    labelGridView.Text = o == null ? "Aucune donnée" : dataEditorService.FindValue(o, "ComboboxDescription");
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}