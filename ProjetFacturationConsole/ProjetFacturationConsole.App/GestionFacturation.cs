using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetFacturationConsole.App
{
    public class GestionFacturation
    {
        private List<Client> clients = new List<Client>();
        private List<Entreprise> entreprises = new List<Entreprise>();
        private Dictionary<int, Client> dictionnaireClients = new Dictionary<int, Client>();
        private Dictionary<int, Entreprise> dictionnaireEntreprises = new Dictionary<int, Entreprise>();

        public GestionFacturation() { }

        public Facture CreerFacture()
        {
            Console.WriteLine("Création d'une facture");

            Console.WriteLine("Id entreprise : ");
            int idEntreprise = int.Parse(Console.ReadLine());
            var entreprise = dictionnaireEntreprises[idEntreprise];

            Console.WriteLine("Id client : ");
            int idClient = int.Parse(Console.ReadLine());
            var client = dictionnaireClients[idClient];

            Console.WriteLine("Date émission (yyyy-MM-dd) : ");
            DateTime dateEmission = DateTime.Parse(Console.ReadLine());
            DateTime dateEcheance = dateEmission.AddDays(30);

            var facture = new Facture("F" + DateTime.Now.Ticks, dateEmission, client, entreprise, dateEcheance, "Brouillon");

            string continuer;
            do
            {
                Console.WriteLine("Description : ");
                string desc = Console.ReadLine();

                Console.WriteLine("Quantité : ");
                int qte = int.Parse(Console.ReadLine());

                Console.WriteLine("Prix HT : ");
                decimal prix = decimal.Parse(Console.ReadLine());

                Console.WriteLine("TVA : ");
                decimal tva = decimal.Parse(Console.ReadLine());

                facture.Lignes.Add(new LigneFacture(desc, qte, prix, tva));

                Console.WriteLine("Ajouter une ligne ? (oui/non)");
                continuer = Console.ReadLine();

            } while (continuer.ToLower() == "oui");

            GenererFichierTexteFacture(facture);

            return facture;
        }

        public void GenererFichierTexteFacture(Facture facture)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("FACTURE");
            sb.AppendLine("Numéro : " + facture.Numero);
            sb.AppendLine("Date émission : " + facture.DateEmission.ToShortDateString());
            sb.AppendLine("Date échéance : " + facture.DateEcheance.ToShortDateString());
            sb.AppendLine("Statut : " + facture.Statut);
            sb.AppendLine("Entreprise : " + facture.Entreprise.Nom);
            sb.AppendLine("Client : " + facture.Client.Nom);
            sb.AppendLine("Lignes : ");

            foreach (var l in facture.Lignes)
            {
                decimal totalHT = l.Quantite * l.PrixUnitaireHT;
                decimal totalTVA = totalHT * l.TauxTVA / 100;
                decimal totalTTC = totalHT + totalTVA;

                sb.AppendLine($"{l.Description} - {l.Quantite} - {totalHT} - {totalTTC}");
            }

            string nomFichier = $"facture_{facture.Numero}.txt";
            File.WriteAllText(nomFichier, sb.ToString());

            Console.WriteLine("Fichier généré : " + nomFichier);
        }
    }
}
