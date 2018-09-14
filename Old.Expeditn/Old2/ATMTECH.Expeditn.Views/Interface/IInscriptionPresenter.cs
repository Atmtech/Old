using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IInscriptionPresenter : IViewBase
    {
        string Prenom { get; set; }
        string Nom { get; set; }
        string Courriel { get; set; }
        string MotPasse { get; set; }
        string MotPasseConfirmation { get; set; }
    }
}
