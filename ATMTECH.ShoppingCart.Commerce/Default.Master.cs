using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
      

        private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }

        protected void btnLocaliserClick(object sender, EventArgs e)
        {
            IList<Localization> localizations = new List<Localization>();
            List<Control> allControls = new List<Control>();
            GetControlList(Page.Controls, allControls);
            foreach (Control control in allControls)
            {
                Localization localization = new Localization();
                if (control is GridView)
                {
                    for (int i = 0; i < (control as GridView).Columns.Count - 1; i++)
                    {
                        localization.ObjectId = (control as GridView).ID + "[" + i + "]";
                        localization.French = (control as GridView).ID + "[" + i + "]";
                        localization.English = (control as GridView).ID + "[" + i + "]";
                        localizations.Add(localization);
                    }
                }
                else
                {
                    if (control is Label)
                    {
                        localization.ObjectId = control.ID;
                        localization.French = (control as Label).Text.Replace(" (*Loc)", "");
                        localization.English = (control as Label).Text.Replace(" (*Loc)", "");
                        localizations.Add(localization);
                    }
                    if (control is Button)
                    {
                        localization.ObjectId = control.ID;
                        localization.French = (control as Button).Text.Replace(" (*Loc)", "");
                        localization.English = (control as Button).Text.Replace(" (*Loc)", "");
                        localizations.Add(localization);
                    }

                    if (control is TextBox)
                    {
                        if (!string.IsNullOrEmpty((control as TextBox).Attributes["placeholder"]))
                        {
                            localization.ObjectId = control.ID;
                            localization.French = (control as TextBox).Attributes["placeholder"];
                            localization.English = (control as TextBox).Attributes["placeholder"];
                            localizations.Add(localization);
                        }

                        if (!string.IsNullOrEmpty((control as TextBox).ToolTip))
                        {
                            localization.ObjectId = control.ID;
                            localization.French = (control as TextBox).ToolTip;
                            localization.English = (control as TextBox).ToolTip;
                            localizations.Add(localization);
                        }
                    }
                }
            }
            Presenter.SaveLocalization(localizations);
            Presenter.NavigationService.Refresh();
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public bool IsLogged { set; private get; }
        public string Name { set; private get; }
        public int NumberOfItemInBasket { set; private get; }
        public string ImageCorp { set; private get; }
        public int ProductCount { set; private get; }
        public string Welcome { set; private get; }
        public decimal TotalPrice { set; private get; }
        public string Language { set; private get; }
        public Enterprise Enterprise { set; private get; }
    }
}