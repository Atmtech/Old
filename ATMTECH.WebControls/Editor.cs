using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKEditor.NET;

namespace ATMTECH.WebControls
{
    public class Editor : CompositeControl
    {
        private readonly CKEditorControl _ckEditorControl;

        public Editor()
        {
            _ckEditorControl = new CKEditorControl();
        }

        public string Text
        {
            get { return _ckEditorControl.Text; }
            set { _ckEditorControl.Text = value; }
        }
        public string Toolbar
        {
            get { return _ckEditorControl.Toolbar; }
            set { _ckEditorControl.Toolbar = value; }
        }



        protected override void OnInit(EventArgs e)
        {
            _ckEditorControl.ID = "textEditor";
            base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            _ckEditorControl.ID = ID;
            _ckEditorControl.Visible = true;
            _ckEditorControl.ViewStateMode = ViewStateMode.Enabled;
            Controls.Add(_ckEditorControl);
            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            _ckEditorControl.Enabled = Enabled;
            _ckEditorControl.Width = Width;
            _ckEditorControl.Height = Height;
            _ckEditorControl.CssClass = "radioButtonAvance";
            base.OnPreRender(e);
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList arrayList = (ArrayList)savedState;
                base.LoadViewState(arrayList[0]);
                if (arrayList[1] != null)
                    Text = (string)arrayList[1];
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }

        protected override object SaveViewState()
        {
            return new ArrayList { base.SaveViewState(), Text };
        }
    }
}
