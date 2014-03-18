using System;
using System.Collections;

namespace ATMTECH.Administration
{
    public partial class CsharpEditor : System.Web.UI.Page
    {
        protected void btnHighLight_Click(object sender, EventArgs e)
        {
            string _error = string.Empty;

            // Check the value of user's input data.
            if (CheckControlValue(this.ddlLanguage.SelectedValue,
                this.tbCode.Text, out _error))
            {
                // Initialize the Hashtable variable which used to
                // store the different languages of code and their 
                // related regular expressions with matching options.
                Hashtable _htb = CodeManager.Init();

                // Initialize the suitable collection object.
                RegExp _rg = new RegExp();
                _rg = (RegExp)_htb[ddlLanguage.SelectedValue];
                this.lbResult.Visible = true;
                if (this.ddlLanguage.SelectedValue != "html")
                {
                    // Display the highlighted code in a label control.
                    this.lbResult.Text = CodeManager.Encode(
                        CodeManager.HighlightCode(
                        Server.HtmlEncode(this.tbCode.Text)
                        .Replace("&quot;", "\""),
                        this.ddlLanguage.SelectedValue, _rg)
                        );
                }
                else
                {
                    // Display the highlighted code in a label control.
                    this.lbResult.Text = CodeManager.Encode(
                        CodeManager.HighlightHTMLCode(this.tbCode.Text, _htb)
                        );
                }
            }
            else
            {
                this.lbError.Visible = true;
                this.lbError.Text = _error;
            }
        }
        public bool CheckControlValue(string selectValue,
            string inputValue,
            out string error)
        {
            error = string.Empty;
            if (selectValue == "-1")
            {
                error = "Please choose the language.";
                return false;
            }
            if (string.IsNullOrEmpty(inputValue))
            {
                error = "Please paste your code in the textbox control.";
                return false;
            }
            return true;
        }

        protected void textChangedClick(object sender, EventArgs e)
        {
            string _error = string.Empty;

            // Check the value of user's input data.
            if (CheckControlValue(this.ddlLanguage.SelectedValue,
                this.tbCode.Text, out _error))
            {
                // Initialize the Hashtable variable which used to
                // store the different languages of code and their 
                // related regular expressions with matching options.
                Hashtable _htb = CodeManager.Init();

                // Initialize the suitable collection object.
                RegExp _rg = new RegExp();
                _rg = (RegExp)_htb[this.ddlLanguage.SelectedValue];
                this.lbResult.Visible = true;
                if (this.ddlLanguage.SelectedValue != "html")
                {
                    // Display the highlighted code in a label control.
                    this.lbResult.Text = CodeManager.Encode(
                        CodeManager.HighlightCode(
                        Server.HtmlEncode(this.tbCode.Text)
                        .Replace("&quot;", "\""),
                        this.ddlLanguage.SelectedValue, _rg)
                        );
                }
                else
                {
                    // Display the highlighted code in a label control.
                    this.lbResult.Text = CodeManager.Encode(
                        CodeManager.HighlightHTMLCode(this.tbCode.Text, _htb)
                        );
                }
            }
            else
            {
                this.lbError.Visible = true;
                this.lbError.Text = _error;
            }
        }
    }
}