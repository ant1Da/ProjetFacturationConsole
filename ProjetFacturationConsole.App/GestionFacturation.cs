using System.Collections.Generic;

namespace ProjetFacturationConsole.App
{
    public class GestionFacturation
    {
        private List<Client> clients = new List<Client>();
        private List<Entreprise> entreprises = new List<Entreprise>();
        private Dictionary<int, Client> dictionnaireClients = new Dictionary<int, Client>();
        private Dictionary<int, Entreprise> dictionnaireEntreprises = new Dictionary<int, Entreprise>();

        public GestionFacturation() { }

        // ─── Étape 3 : Import CSV ────────────────────────────────────────────

        public void ImporterClientsDepuisCsv(string cheminCsv, string cheminJson)
        {
            clients.Clear();
            dictionnaireClients.Clear();
            var lignes = System.IO.File.ReadAllLines(cheminCsv);
            for (int i = 1; i < lignes.Length; i++) // On saute l'entête
            {
                var champs = lignes[i].Split(';');
                var client = new Client(
                    int.Parse(champs[0]),
                    champs[1],
                    champs[2],
                    champs[3],
                    champs[4],
                    champs[5],
                    champs[6],
                    DateTime.Parse(champs[7])
                );
                clients.Add(client);
                dictionnaireClients[client.Id] = client;
            }
            var json = System.Text.Json.JsonSerializer.Serialize(clients, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(cheminJson, json);
        }

        public void ImporterEntreprisesDepuisCsv(string cheminCsv, string cheminJson)
        {
            entreprises.Clear();
            dictionnaireEntreprises.Clear();
            var lignes = System.IO.File.ReadAllLines(cheminCsv);
            for (int i = 1; i < lignes.Length; i++) // On saute l'entête
            {
                var champs = lignes[i].Split(';');
                var entreprise = new Entreprise(
                    int.Parse(champs[0]),
                    champs[1],
                    champs[2],
                    champs[3],
                    champs[4],
                    champs[5],
                    champs[6],
                    champs[7]
                );
                entreprises.Add(entreprise);
                dictionnaireEntreprises[entreprise.Id] = entreprise;
            }
            var json = System.Text.Json.JsonSerializer.Serialize(entreprises, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(cheminJson, json);
        }

        // ─── Étape 5 : Charger depuis JSON ──────────────────────────────────

        public void ChargerClientsDepuisJson(string cheminJson)
        {
            clients.Clear();
            dictionnaireClients.Clear();
            if (!System.IO.File.Exists(cheminJson)) return;
            var json = System.IO.File.ReadAllText(cheminJson);
            var liste = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(json);
            if (liste != null)
            {
                foreach (var client in liste)
                {
                    clients.Add(client);
                    dictionnaireClients[client.Id] = client;
                }
            }
        }

        public void ChargerEntreprisesDepuisJson(string cheminJson)
        {
            entreprises.Clear();
            dictionnaireEntreprises.Clear();
            if (!System.IO.File.Exists(cheminJson)) return;
            var json = System.IO.File.ReadAllText(cheminJson);
            var liste = System.Text.Json.JsonSerializer.Deserialize<List<Entreprise>>(json);
            if (liste != null)
            {
                foreach (var entreprise in liste)
                {
                    entreprises.Add(entreprise);
                    dictionnaireEntreprises[entreprise.Id] = entreprise;
                }
            }
        }

        // ─── Étape 5 : Affichage ────────────────────────────────────────────

        public void AfficherClients()
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("Aucun client à afficher.");
                return;
            }
            Console.WriteLine($"=== Liste des clients ({clients.Count}) ===");
            foreach (var client in clients)
                client.AfficherInfos();
        }

        public void AfficherEntreprises()
        {
            if (entreprises.Count == 0)
            {
                Console.WriteLine("Aucune entreprise à afficher.");
                return;
            }
            Console.WriteLine($"=== Liste des entreprises ({entreprises.Count}) ===");
            foreach (var entreprise in entreprises)
                entreprise.AfficherInfos();
        }

        // ─── Accesseurs ─────────────────────────────────────────────────────

        public List<Client> GetClients() => clients;
        public List<Entreprise> GetEntreprises() => entreprises;
    }
}
