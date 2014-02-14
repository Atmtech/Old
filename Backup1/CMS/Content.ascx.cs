using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web;
using WebFormsMvp.Web;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class Content : MvpUserControl, IContentPresenter
    {
        public ContentPresenter Presenter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public string Value
        {
            get { return CKEditorEditorContent.Text; }
            set
            {
                lblValue.Text = value;
                CKEditorEditorContent.Text = value;
            }
        }

        public string PageName
        {
            get
            {
                return Session["PageNameCms"].ToString();
            }
            set
            {
                Session["PageNameCms"] = value;
                txtPageName.Text = Session["PageNameCms"].ToString();
            }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public string QueryStringPageName
        {
            get
            {
                return QueryString.GetQueryStringValue(QueryString.PAGENAME);
            }
        }

        public IList<ContentCms> PageList
        {
            set
            {
                pageList.DataSource = value;
                pageList.DataBind();
            }
        }

        public IList<Language> LanguageList
        {
            set
            {
                cboLanguage.DataSource = value;
                cboLanguage.DataTextField = BaseEntity.DESCRIPTION;
                cboLanguage.DataValueField = BaseEnumeration.CODE;
                cboLanguage.DataBind();
            }
        }

        public bool IsAdministrator
        {
            set { pnlCommand.Visible = value; }
        }

        public string LanguageValue
        {
            get { return cboLanguage.SelectedValue; }
            set { cboLanguage.SelectedValue = value; }
        }

        protected void OpenPage(object sender, EventArgs e)
        {
            string commandArgument = ((LinkButton)sender).CommandArgument;
            Presenter.GetContentById(Convert.ToInt32(commandArgument));
        }
        protected void OnOpenEdit(object sender, EventArgs eventArgs)
        {
            ContentWindow.OuvrirFenetre();
        }

        protected void OnOpenAddFile(object sender, EventArgs eventArgs)
        {
            FileUploadWindow.OuvrirFenetre();
        }

        protected void OnClose(object sender, EventArgs e)
        {
            Presenter.GetContent(PageName);
            ContentWindow.FermerFenetre();
        }
        protected void OnAddContent(object sender, EventArgs e)
        {
            CurrentContent = new ContentCms();
            CKEditorEditorContent.Text = string.Empty;
            txtPageName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        protected void OnSaveContent(object sender, EventArgs e)
        {
            Presenter.SaveContent();
        }


        #region IContentPresenter Membres


        public ContentCms CurrentContent
        {
            get { return (ContentCms) Session["CurrentContent"]; }
            set { Session["CurrentContent"] = value; }
        }

        #endregion
    }
}