namespace ProjetFacturationConsole.App
{
    public class Client : Personne
    {
        public DateTime DateInscription { get; set; }

        public Client(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, DateTime dateInscription)
            : base(id, nom, email, telephone, adresse, ville, codePostal)
        {
            DateInscription = dateInscription;
        }
    }
}