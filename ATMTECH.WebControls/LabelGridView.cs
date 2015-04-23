using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.WebControls
{
    public class LabelGridView : CompositeControl
    {
        public string Text { get { return _label.Text; } set { _label.Text = value; } }
        public string Classe { get; set; }
        public string NomColonne { get; set; }
        public bool EstProprieteNative { get; set; }

        protected readonly Label _label;

        public LabelGridView()
        {
            _label = new Label();
        }

        protected override void CreateChildControls()
        {
            _label.ID = ID;
            _label.Visible = true;
            _label.ViewStateMode = ViewStateMode.Enabled;
            Controls.Add(_label);
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
                    _label.Text = tblValeurs[i].ToString();
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
            return new ArrayList { base.SaveViewState(), _label.Text, Enabled };
        }

    }
}

