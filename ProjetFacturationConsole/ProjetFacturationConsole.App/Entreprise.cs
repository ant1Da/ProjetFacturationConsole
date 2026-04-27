namespace ProjetFacturationConsole.App
{
    public class Entreprise : Personne
    {
        public string Siret { get; set; }

        public Entreprise(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, string siret)
            : base(id, nom, email, telephone, adresse, ville, codePostal)
        {
            Siret = siret;
        }
    }
}