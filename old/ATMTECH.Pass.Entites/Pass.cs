namespace ATMTECH.Pass.Entites
{
    public class Pass
    {
        public int Id { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public string Emplacement { get; set; }
        public string MotDePasse { get; set; }
    }
}
