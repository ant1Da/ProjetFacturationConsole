
using System;
using ProjetFacturationConsole.App;


namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var gestion = new GestionFacturation();
            gestion.ImporterClientsDepuisCsv("c:/Users/adast/Downloads/projet_gestion_factures/clients.csv", "c:/Users/adast/Downloads/projet_gestion_factures/clients.json");
            gestion.ImporterEntreprisesDepuisCsv("c:/Users/adast/Downloads/projet_gestion_factures/entreprises.csv", "c:/Users/adast/Downloads/projet_gestion_factures/entreprises.json");
            Console.WriteLine("--- Import clients/entreprises terminé ---");
            Console.WriteLine("Exemple client importé :");
            if (gestion.GetClients().Count > 0)
                gestion.GetClients()[0].AfficherInfos();
            Console.WriteLine("Exemple entreprise importée :");
            if (gestion.GetEntreprises().Count > 0)
                gestion.GetEntreprises()[0].AfficherInfos();
        }
    }
}
