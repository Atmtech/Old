using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.WebControls
{
    public class DatePicker : CompositeControl
    {
        public string Text { get { return _textBox.Text; } set { _textBox.Text = value; } }
     
        protected readonly TextBox _textBox;

        public DatePicker()
        {
            _textBox = new TextBox();
        }

        protected override void CreateChildControls()
        {
            _textBox.ID = ID;
            _textBox.Visible = true;
            _textBox.ViewStateMode = ViewStateMode.Enabled;
            Controls.Add(_textBox);
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
            string js = "$(function () {  " +
                        "$(\"input[name*='$" + _textBox.ID + "']\").datepicker(" +
                        " {" +
                        "dayNamesMin: ['Di', 'Lu', 'Ma', 'Me', 'Je', 'Ve', 'Sa']," +
                        "monthNames: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre']" +
                        "}); " +
                        "$(\"input[name*='$" + _textBox.ID + "']\").datepicker(\"option\", \"dateFormat\", \"yy-mm-dd\"); " +
                        "});";

            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), _textBox.ID, js, true);
        }


        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                int i = 0;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    _textBox.Text = tblValeurs[i].ToString();
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
            return new ArrayList { base.SaveViewState(), _textBox.Text, Enabled };
        }

    }
}

