﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public class PageMaitreBase<TPresenter, TView> : MasterPage
        where TView : class, IViewBase
        where TPresenter : BaseShoppingCartPresenter<TView>
    {
        public TPresenter Presenter { get; set; }
        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlSuccess");
                    Label literal = (Label)Master.FindControl("lblSuccess");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
            }
            else
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlError");
                    Label literal = (Label)Master.FindControl("lblError");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                Localiser();
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
        public void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }


        private void Localiser()
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            if (absoluteUri.IndexOf("localhost") > 0)
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
            }
        }


    }
}