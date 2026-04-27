namespace ProjetFacturationConsole.App
{
    public abstract class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }

        protected Personne(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal)
        {
            Id = id;
            Nom = nom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            Ville = ville;
            CodePostal = codePostal;
        }
    }
}