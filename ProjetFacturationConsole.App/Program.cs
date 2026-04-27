
using System;
using ProjetFacturationConsole.App;


namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test simple de création d'objets pour vérifier la compilation
            var client = new Client(1, "Dupont", "dupont@email.com", "0102030405", "1 rue A", "Paris", "75000", DateTime.Now);
            var entreprise = new Entreprise(2, "EntrepriseX", "contact@x.com", "0607080910", "2 rue B", "Lyon", "69000", "12345678901234");
            var ligne = new LigneFacture("Produit A", 2, 100.0m, 20.0m);
            var facture = new Facture("F001", DateTime.Now, client, entreprise, DateTime.Now.AddDays(30), "En attente");
            var gestion = new GestionFacturation();
            Console.WriteLine("Test de création des objets réussi.");
        }
    }
}
