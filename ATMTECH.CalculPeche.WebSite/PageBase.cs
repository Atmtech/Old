using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.CalculPeche.Views.Base;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web;
using ATMTECH.WebControls;
using Message = System.Web.Services.Description.Message;

namespace ATMTECH.CalculPeche.WebSite
{
    public class PageBase<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseCalculPechePresenter<TView>
    {
        public TPresenter Presenter { get; set; }
        public void ShowMessage(Message message)
        {

            List<Control> allControls = new List<Control>();
            GetControlList(Page.Controls, allControls);
            foreach (Control controle in allControls)
            {
                if (controle is PlaceHolder)
                {
                    if (controle.ID == "placeHolderErreur")
                    {
                        //MessageInformation messageInformation = (MessageInformation)LoadControl(@"~/usercontrols/MessageInformation.ascx");
                        //messageInformation.Message = message;
                        //((PlaceHolder)controle).Controls.Add(messageInformation);
                    }
                }
            }
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
               // Presenter.Localize();
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
    }
}