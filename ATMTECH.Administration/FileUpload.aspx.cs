using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Views.Interface;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Administration
{
    public partial class FileUpload : PageBaseAdministration, IFileUploadPresenter
    {

        public FileUploadAdminPresenter Presenter { get; set; }

        public string RootImagePath
        {
            get
            {
                return ddlSiteList.SelectedValue;
            }
        }

        public string Filter { get { return txtFilter.Text; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

            lblRootPathImage.Text = RootImagePath;
        }

        protected void BtnUploadClick(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        public void ResizeAll()
        {
            Presenter.ResizeAll(RootImagePath + "\\Product");
        }

        public void SaveImageFile()
        {
            try
            {
                HttpFileCollection hfc = Request.Files;
                string files = string.Empty;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile httpPostedFile = hfc[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        Presenter.SaveFile(httpPostedFile, cboType.SelectedValue);
                        files +=
                            string.Format(
                                "<b>Fichier: </b>{0} <b>Taille:</b> {1} <b>Type:</b> {2} Transfert réussi <br/>",
                                httpPostedFile.FileName, httpPostedFile.ContentLength, httpPostedFile.ContentType);
                    }
                }

                lblTransferedFile.Text = files;
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
        }


        public string Category
        {
            get { return cboType.SelectedValue; }
            set { cboType.SelectedValue = value; }
        }

        public IList<File> AllFiles
        {
            set
            {
                grdFile.DataSource = value;
                grdFile.DataBind();
            }
        }

        protected void btnTelechargerClick(object sender, EventArgs e)
        {
            //Response.ContentType = "application/x-sqlite3";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=ShoppingCart.db3");
            //Response.TransmitFile(Server.MapPath("~/data/ShoppingCart.db3"));
            //Response.End();
        }

        protected void btnTeleverserClick(object sender, EventArgs e)
        {
            //HttpFileCollection hfc = Request.Files;
            //for (int i = 0; i < hfc.Count; i++)
            //{
            //    HttpPostedFile httpPostedFile = hfc[i];
            //    if (httpPostedFile.ContentLength > 0)
            //    {
            //        string serverPath = string.Format(@"{0}\ShoppingCart.db3", Server.MapPath("~/data"));

            //        httpPostedFile.SaveAs(serverPath);
            //    }
            //}
        }

        protected void btnResizeClick(object sender, EventArgs e)
        {
            Presenter.ResizeAll(RootImagePath + @"\Product");
        }


        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFile.PageIndex = e.NewPageIndex;
            grdFile.DataBind();
        }


        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = grdFile.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gridViewRow.Cells[0].Text);
                if (e.CommandName == "Edition")
                {
                    lblId.Text = id.ToString();
                    File file = Presenter.GetFile(Convert.ToInt32(lblId.Text));
                    lblFile.Text = file.FileName;
                    txtTitle.Text = file.Title;
                    txtDescription.Text = file.Description;
                    pnlEdit.Visible = true;
                }
                if (e.CommandName == "Supprimer")
                {
                    Presenter.DeleteFile(id);


                }
            }
            catch (Exception)
            {


            }

        }

        protected void SaveFile(object sender, EventArgs e)
        {
            File file = Presenter.GetFile(Convert.ToInt32(lblId.Text));
            file.Description = txtDescription.Text;
            file.Title = txtTitle.Text;
            Presenter.SaveFile(file);
            pnlEdit.Visible = false;
            Presenter.Refresh();
        }

        protected void btnFilterClick(object sender, EventArgs e)
        {
           Presenter.FillAllFiles();
        }
    }
}