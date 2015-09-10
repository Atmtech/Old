using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ValiderCommandeService : BaseService, IValiderCommandeService
    {
        public IMessageService MessageService { get; set; }
        public IInventaireService InventaireService { get; set; }

        public bool EstClientValide(Customer client)
        {
            if (client == null)
            {
                MessageService.ThrowMessage(CodeErreur.SC_CLIENT_EST_NULL);
                return false;
            }
            return true;
        }
        public bool EstItemPresentEnInventaire(string idProduit, string grandeur, string couleur)
        {
            if (InventaireService.ObtenirInventaireTechnosport(idProduit, grandeur, couleur) > 0)
            {
                return true;
            }
            MessageService.ThrowMessage(CodeErreur.SC_INVENTAIRE_INSUFFISANT_POUR_COMMANDER);
            return false;
        }

        public bool EstQuantiteValide(int quantite)
        {
            if (quantite <= 0)
            {
                MessageService.ThrowMessage(CodeErreur.SC_QUANTITE_INSUFFISANTE);
                return false;
            }
            return true;
        }
    }
}

