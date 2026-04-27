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

        public void AfficherFacture()
        {
            Console.WriteLine($"Facture {Numero} du {DateEmission:dd/MM/yyyy} pour {Client.Nom} par {Entreprise.Nom}");
            foreach (var ligne in Lignes)
            {
                Console.WriteLine($"- {ligne.Description} : {ligne.Quantite} x {ligne.PrixUnitaireHT}€ HT, TVA {ligne.TauxTVA}%");
            }
            Console.WriteLine($"Total HT : {CalculerTotalHT():0.00}€");
            Console.WriteLine($"Total TVA : {CalculerTotalTVA():0.00}€");
            Console.WriteLine($"Total TTC : {CalculerTotalTTC():0.00}€");
            Console.WriteLine($"Statut : {Statut}, Échéance : {DateEcheance:dd/MM/yyyy}");
        }
    }
}