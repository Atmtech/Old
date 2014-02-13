using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Views
{
    public class ContentPresenter : BasePresenter<IContentPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public ContentPresenter(IContentPresenter view)
            : base(view)
        { }

        private IList<ContentCms> FillPageList()
        {
            DAOContent daoContent = new DAOContent();
            return daoContent.GetContent();
        }

        private IList<Language> FillLanguage()
        {
            BaseDao<Language, int> baseDao = new BaseDao<Language, int>();
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            return baseDao.GetAllActive(orderOperation);
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.PageList = FillPageList();
        }

        public override void OnViewInitialized()
        {
            View.PageList = FillPageList();
            View.LanguageList = FillLanguage();

            if (string.IsNullOrEmpty(View.PageName))
            {
                GetContent(View.QueryStringPageName);
            }
            else
            {
                GetContent(View.PageName);
            }

            SetSecurity();

            base.OnViewInitialized();
        }

        private void SetView(ContentCms content)
        {
            View.Value = content.Value;
            View.Description = content.Description;
            View.LanguageValue = content.Language;
            View.PageName = content.PageName;
            View.CurrentContent = content;
        }

        public void SetSecurity()
        {
            if (AuthenticationService.AuthenticateUser != null && AuthenticationService.AuthenticateUser.IsAdministrator)
            {
                View.IsAdministrator = true;
            }
            else
            {
                View.IsAdministrator = false;
            }
        }
        public void GetContentById(int id)
        {
            DAOContent daoContent = new DAOContent();
            ContentCms content = daoContent.GetById(id);
            SetView(content);
        }
        public void GetContent(string page)
        {
            DAOContent daoContent = new DAOContent();
            ContentCms content = daoContent.GetContent(page, LocalizationService.CurrentLanguage);
            SetView(content);
        }
        public void SaveContent()
        {
            DAOContent daoContent = new DAOContent();

            View.CurrentContent.Description = View.Description;
            View.CurrentContent.PageName = View.PageName;
            View.CurrentContent.Value = View.Value;
            View.CurrentContent.Language = View.LanguageValue;
            View.CurrentContent.StripedValue = Utils.Web.Pages.RemoveHtmlTag(View.Value);
            daoContent.SaveContent(View.CurrentContent);
        }
    }
}
