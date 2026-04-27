namespace ProjetFacturationConsole.App
{
    public class Facture : DocumentCommercial
    {
        public DateTime DateEcheance { get; set; }
        public string Statut { get; set; }

        public Facture(string numero, DateTime dateEmission, Client client, Entreprise entreprise, DateTime dateEcheance, string statut)
            : base(numero, dateEmission, client, entreprise)
        {
            DateEcheance = dateEcheance;
            Statut = statut;
        }
    }
}