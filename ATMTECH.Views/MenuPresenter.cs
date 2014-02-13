using ATMTECH.DAO;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Views
{
    public class MenuPresenter : BasePresenter<IMenuPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public MenuPresenter(IMenuPresenter view)
            : base(view)
        { }


        public override void OnViewInitialized()
        {
            SetSecurity();
            base.OnViewInitialized();
        }
        public override void OnViewLoaded()
        {
            SetMenu();
            base.OnViewLoaded();
        }

        private void SetMenu()
        {
            DAOMenu daoMenu = new DAOMenu();
            View.Menus = daoMenu.GetMenu(View.MenuId);
        }

        public void SetSecurity()
        {
            if (View.IsAdministratorOnly)
            {
                if (AuthenticationService.AuthenticateUser != null && AuthenticationService.AuthenticateUser.IsAdministrator)
                {
                    View.IsVisible = true;
                }
                else
                {
                    View.IsVisible = false;
                }
            }
        }
    }
}
