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

        public List<Client> GetClients() => clients;
        public List<Entreprise> GetEntreprises() => entreprises;
    }
}