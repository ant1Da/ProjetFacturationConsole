using System;
using ProjetFacturationConsole.App;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var gestion = new GestionFacturation();

            // Chemins relatifs : les fichiers JSON sont à la racine du projet
            string cheminClients = Path.Combine("..", "..", "..", "..", "clients.json");
            string cheminEntreprises = Path.Combine("..", "..", "..", "..", "entreprises.json");

            // ─── Étape 5 : Charger depuis JSON et afficher ───────────────────
            Console.WriteLine("=== Test ChargerClientsDepuisJson ===");
            gestion.ChargerClientsDepuisJson(cheminClients);
            gestion.AfficherClients();

            Console.WriteLine();

            Console.WriteLine("=== Test ChargerEntreprisesDepuisJson ===");
            gestion.ChargerEntreprisesDepuisJson(cheminEntreprises);
            gestion.AfficherEntreprises();
        }
    }
}
