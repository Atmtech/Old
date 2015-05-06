using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Services;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class MotPasseOubliePresenter : BaseExpeditnPresenter<IMotPasseOubliePresenter>
    {
        public IDAOUser DAOUser { get; set; }
        public MotPasseOubliePresenter(IMotPasseOubliePresenter view)
            : base(view)
        {
        }

        public ICourrielService CourrielService { get; set; }

        public void EnvoyerMotPasseOublie()
        {
            User user = DAOUser.GetUserByEmail(View.Courriel);
            if (user != null)
            {
                CourrielService.EnvoyerMotPasseOublie(user);
            }
            MessageService.ThrowMessage(CodeErreur.SC_MOT_PASSE_OUBLIE_ENVOYER_PAR_COURRIEL);
        }
    }

}