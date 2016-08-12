using System.Web;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ProfilePresenter : BaseExpeditnPresenter<IProfilePresenter>
    {

        public IFileService FileService { get; set; }
        public IDAOUser DAOUser { get; set; }

        public ProfilePresenter(IProfilePresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Nom = AuthenticationService.AuthenticateUser.LastName;
            View.Prenom = AuthenticationService.AuthenticateUser.FirstName;
            View.Courriel = AuthenticationService.AuthenticateUser.Email;
            View.MotPasse = AuthenticationService.AuthenticateUser.Password;
            AfficherImage();
        }

        public void AfficherImage()
        {
            File file = FileService.GetFile(AuthenticationService.AuthenticateUser.Image.Id);

            if (file != null)
            {
                if (!string.IsNullOrEmpty(file.FileName))
                { View.Image = "/Images/medias/" + file.FileName; }
                else
                {
                    View.Image = "/Images/medias/AucuneImageParticipant.gif";
                }

            }
            else
            {
                View.Image = "/Images/medias/AucuneImageParticipant.gif";
            }
        }

        public void Enregistrer()
        {
            User user = AuthenticationService.AuthenticateUser;
            user.FirstName = View.Prenom;
            user.LastName = View.Nom;
            user.Email = View.Courriel;
            user.Password = View.MotPasse;
            DAOUser.UpdateUser(user);
        }

        public void EnregistrerImage(HttpPostedFile httpPostedFile)
        {
            int idFichier = FileService.SaveFile(httpPostedFile, @"\Images\Medias", View.RootPath);
            File file = FileService.GetFile(idFichier);
            User user = AuthenticationService.AuthenticateUser;
            user.Image = file;
            DAOUser.UpdateUser(user);
            NavigationService.Refresh();
        }
    }
}