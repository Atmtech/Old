namespace ATMTECH.MidiBoardGame.Entites
{
    public class Jeu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string UrlBoardGameGeek { get; set; }
        public string NombreJoueur { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
