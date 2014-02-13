using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Services;
using ATMTECH.Common.Utilities;

namespace ATMTECH.Administration
{
    public class GridViewTemplate : ITemplate
    {
        private readonly DataControlRowType _templateType;
        private readonly string _columnName;

        public GridViewTemplate(DataControlRowType type, string colname)
        {
            _templateType = type;
            _columnName = colname;
        }

        public void InstantiateIn(Control container)
        {
            switch (_templateType)
            {
                case DataControlRowType.Header:
                    Literal lc = new Literal { Text = string.Format("<b>{0}</b>", _columnName) };
                    container.Controls.Add(lc);
                    break;
                case DataControlRowType.DataRow:
                    Label data = new Label { ToolTip = _columnName };
                    data.DataBinding += Data_DataBinding;
                    container.Controls.Add(data);
                    break;
            }
        }

        private void Data_DataBinding(Object sender, EventArgs e)
        {
            try
            {
                Label l = (Label)sender;
                string nameSpace = string.Empty;
                string className = l.ToolTip;

                if (className == "ProductLinked")
                {
                    className = "Product";
                }
                if (className == "Image")
                {
                    className = "File";
                }

                GridViewRow row = (GridViewRow)l.NamingContainer;
                int id = Convert.ToInt32(DataBinder.Eval(row.DataItem, l.ToolTip + ".Id").ToString());

                ManageClass manageClass = new ManageClass();
                if (manageClass.IsExistInNameSpace("ATMTECH.Entities", className))
                {
                    nameSpace = "ATMTECH.Entities";
                }
                if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", className))
                {
                    nameSpace = "ATMTECH.ShoppingCart.Entities";
                }

                DataEditorService dataEditorService = new DataEditorService();
                Object o = dataEditorService.GetById(nameSpace, className, id);
                l.Text = o == null ? "N/A" : dataEditorService.FindValue(o, "ComboboxDescription");
            }
            catch (Exception)
            {

                //  throw;
            }


        }
    }
}