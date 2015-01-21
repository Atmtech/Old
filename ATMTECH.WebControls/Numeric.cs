using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.WebControls
{
    public class Numeric : CompositeControl
    {
        public string Text { get { return _textBox.Text; } set { _textBox.Text = value; } }
        public string ValidationGroup { get { return _textBox.ValidationGroup; } set { _textBox.ValidationGroup = value; } }
        public new Unit Width { get { return _textBox.Width; } set { _textBox.Width = value; } }
        public new Color ForeColor { get { return _textBox.ForeColor; } set { _textBox.ForeColor = value; } }

        public bool NoDecimal { get; set; }

        protected readonly TextBox _textBox;

        public Numeric()
        {
            _textBox = new TextBox();
        }

        protected override void CreateChildControls()
        {

            _textBox.ID = ID;
            _textBox.Visible = true;
            _textBox.ViewStateMode = ViewStateMode.Enabled;
            if (NoDecimal)
            {
                _textBox.Attributes.Add("data-v-min", "-99999999999");
                _textBox.Attributes.Add("data-v-max", "99999999999");
                _textBox.Attributes.Add("data-m-dec", "0");
            }
            else
            {
                _textBox.Attributes.Add("data-v-min", "-99999999999");
                _textBox.Attributes.Add("data-v-max", "99999999999");
                _textBox.Attributes.Add("data-m-dec", "4");
            }
            
            _textBox.Attributes.Add("data-a-sep"," ");
            _textBox.Attributes.Add("data-w-empty","zero");

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
            string js = string.Empty;

            //js = NoDecimal
            //         ? "$(function () {  " +
            //           "$(\"input[name*='$" + _textBox.ID +
            //           "']\").priceFormat({prefix: '',thousandsSeparator: '',allowNegative: true, centsLimit:0})" +
            //           "});"
            //         : "$(function () {  " +
            //           "$(\"input[name*='$" + _textBox.ID +
            //           "']\").priceFormat({prefix: '',thousandsSeparator: '',allowNegative: true})" +
            //           "});";

            js = "$(function () {  " +
                       "$(\"input[name*='$" + _textBox.ID +
                       "']\").autoNumeric('init')" +
                       "});";

            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), _textBox.ID, js, true);
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

