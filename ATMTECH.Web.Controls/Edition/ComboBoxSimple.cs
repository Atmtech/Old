using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    public class ComboBoxSimple : ControleBase
    {
        public string SelectedValue { get { return _dropDownList.SelectedValue; } set { _dropDownList.SelectedValue = value; } }
        public Object DataSource { get { return _dropDownList.DataSource; } set { _dropDownList.DataSource = value; } }
        public string DataTextField { get { return _dropDownList.DataTextField; } set { _dropDownList.DataTextField = value; } }
        public string DataValueField { get { return _dropDownList.DataValueField; } set { _dropDownList.DataValueField = value; } }
        public ListItemCollection Items { get { return _dropDownList.Items; }  }
        
       // public new string ID { get { return _dropDownList.ID; } set { _dropDownList.ID = value; } }
        protected readonly DropDownList _dropDownList;


        public ComboBoxSimple()
        {
            _dropDownList = new DropDownList();
        }

        protected override void CreateChildControls()
        {
            _dropDownList.ID = this.ID;
            _dropDownList.Visible = true;
            _dropDownList.ViewStateMode = ViewStateMode.Enabled;
            Controls.Add(_dropDownList);
            ValidateurChampRequis.ControlToValidate = _dropDownList.ID;
            base.CreateChildControls();
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            string js = "$(function () {  $(\"select[name*='" + _dropDownList.ID + "']\").combobox(); });";
            Page.IncorporerJavascript("comboBox" + _dropDownList.ID, js);
            base.OnPreRender(e);
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
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(_dropDownList.SelectedValue);
            tblValeurs.Add(Enabled);
            return tblValeurs;
        }

    }
}

