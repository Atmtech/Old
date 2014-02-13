using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class ProfilePresenter : BaseAccomplissementPresenter<IProfilePresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IParameterService ParameterService { get; set; }


        public ProfilePresenter(IProfilePresenter view)
            : base(view)
        {
        }




    }
}
