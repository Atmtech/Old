using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.WebControls
{
    public class ComboBox : CompositeControl
    {
        public string SelectedValue { get { return _dropDownList.SelectedValue; } set { _dropDownList.SelectedValue = value; } }
        public Object DataSource
        {
            get { return _dropDownList.DataSource; }
            set
            {
                _dropDownList.DataSource = value;
             
            }
        }
        public string DataTextField { get { return _dropDownList.DataTextField; } set { _dropDownList.DataTextField = value; } }
        public string DataValueField { get { return _dropDownList.DataValueField; } set { _dropDownList.DataValueField = value; } }
        public ListItemCollection Items { get { return _dropDownList.Items; } }
        public bool AutoPostBack { get { return _dropDownList.AutoPostBack; } set { _dropDownList.AutoPostBack = value; } }

        protected readonly DropDownList _dropDownList;

        public ComboBox()
        {
            _dropDownList = new DropDownList();
        }

        public void AjouterItemsNull()
        {
            ListItem listItem = new ListItem("-- N/A --", "null");
            Items.Insert(0, listItem);
        }

        protected override void CreateChildControls()
        {
            _dropDownList.ID = ID;
            _dropDownList.Visible = true;
            _dropDownList.ViewStateMode = ViewStateMode.Enabled;
            Controls.Add(_dropDownList);
            base.CreateChildControls();
        }

        public event EventHandler SelectedIndexChanged
        {
            add { _dropDownList.SelectedIndexChanged += value; }
            remove { _dropDownList.SelectedIndexChanged -= value; }
        }


        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string js = "$(function () {  $(\"select[name*='$" + _dropDownList.ID + "']\").combobox(); });";
            //string js = "$(\"select[name*='$" + _dropDownList.ID + "']\").combobox();";
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), _dropDownList.ID, js, true);
        }


        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                int i = 0;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    _dropDownList.SelectedValue = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    Enabled = bool.Parse(tblValeurs[i].ToString());
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }
        protected override object SaveViewState()
        {
            return new ArrayList { base.SaveViewState(), _dropDownList.SelectedValue, Enabled };
        }

    }
}

