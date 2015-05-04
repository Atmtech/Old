using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IIdentificationPresenter : IViewBase
    {
        string NomUtilisateurIdentification { get; set; }
        string MotPasseIdentification { get; set; }

        string PrenomCreation { get; set; }
        string NomCreation { get; set; }
        string CourrielCreation { get; set; }
        string MotPasseCreation { get; set; }
        string MotPasseConfirmationCreation { get; set; }
    }
}
