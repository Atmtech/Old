using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageUtilisateurRecherche
    {
        public User Utilisateur { get; set; }

        public string Image
        {
            get
            {
                if (Utilisateur.Image != null)
                {
                    if (!string.IsNullOrEmpty(Utilisateur.Image.FileName))
                        return "/Images/medias/" + Utilisateur.Image.FileName;
                    return "/Images/medias/AucuneImageParticipant.gif";
                }
                return "/Images/medias/AucuneImageParticipant.gif";
            }
        }
    }
}
