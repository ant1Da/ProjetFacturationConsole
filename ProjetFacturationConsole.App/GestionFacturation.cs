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
    }
}