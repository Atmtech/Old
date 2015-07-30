using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IIdentificationPresenter : IViewBase
    {
        string NomUtilisateurIdentification { get; set; }
        string MotPasseIdentification { get; set; }

      
    }
}
