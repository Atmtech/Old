using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.WebSite.UserControls;
using ATMTECH.Views.Interface;
using ATMTECH.Web;
using ATMTECH.WebControls;
using Message = ATMTECH.Entities.Message;

namespace ATMTECH.Expeditn.WebSite
{
    public class PageBase<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseExpeditnPresenter<TView>
    {
        public TPresenter Presenter { get; set; }
        public void ShowMessage(Message message)
        {
            Session["MessageEnvoye"] = message;
            Response.Redirect("Inscription.aspx");

            //Response.Redirect("Error.aspx");
        }
        public void FillDropDown(DropDownList dropDownList, object Source)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
            dropDownList.DataValueField = BaseEntity.ID;
            dropDownList.DataBind();
        }
        public void FillDropDown(DropDownList dropDownList, object Source, string DisplayText)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = DisplayText;
            dropDownList.DataValueField = BaseEntity.ID;
            dropDownList.DataBind();
        }

        public void FillDropDown(ComboBox dropDownList, object Source)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
            dropDownList.DataValueField = BaseEntity.ID;
            dropDownList.DataBind();
        }
        public void FillDropDown(ComboBox dropDownList, object Source, string DisplayText)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = DisplayText;
            dropDownList.DataValueField = BaseEntity.ID;
            dropDownList.DataBind();
        }
        public void FillDropDownWithoutEntity(ComboBox dropDownList, object Source, string DisplayText, string value)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = DisplayText;
            dropDownList.DataValueField = value;
            dropDownList.DataBind();
        }
        public void FillDropDownWithoutEntity(DropDownList dropDownList, object Source, string DisplayText, string value)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = DisplayText;
            dropDownList.DataValueField = value;
            dropDownList.DataBind();
        }
        public void FillDropDownWithoutEntity(ComboBox dropDownList, object Source)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataBind();
        }
        public void FillDropDownWithoutEntity(DropDownList dropDownList, object Source)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataBind();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                List<Control> allControls = new List<Control>();
                GetControlList(Page.Controls, allControls);
                Presenter.Controls = allControls;
                Presenter.Localize();
                Presenter.OnViewInitialized();
            }

            //List<Control> allControls = new List<Control>();
            //GetControlList(Page.Controls, allControls);

            if (Session["MessageEnvoye"] != null)
            {
                List<Control> allControls = new List<Control>();
                GetControlList(Page.Controls, allControls);

                foreach (Control control in allControls)
                {
                    if (control.ID == "MessageInformation")
                    {
                        MessageInformation panel = control as MessageInformation;
                        panel.EstVisible = true;
                        Message message = (Message)Session["MessageEnvoye"];
                        panel.Message = message.Description;
                        Session["MessageEnvoye"] = null;
                        return;
                    }
                }
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
    }
}