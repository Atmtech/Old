using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class MotPasseOubliePresenter : BaseAccomplissementPresenter<IMotPasseOubliePresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IParameterService ParameterService { get; set; }


        public MotPasseOubliePresenter(IMotPasseOubliePresenter view)
            : base(view)
        {
        }


        public void EnvoyerMonMotDePasse()
        {
            //throw new System.NotImplementedException();
        }
    }
}
