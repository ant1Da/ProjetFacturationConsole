namespace ProjetFacturationConsole.App
{
    public abstract class DocumentCommercial
    {
        public string Numero { get; set; }
        public DateTime DateEmission { get; set; }
        public Client Client { get; set; }
        public Entreprise Entreprise { get; set; }
        public List<LigneFacture> Lignes { get; set; }

        protected DocumentCommercial(string numero, DateTime dateEmission, Client client, Entreprise entreprise)
        {
            Numero = numero;
            DateEmission = dateEmission;
            Client = client;
            Entreprise = entreprise;
            Lignes = new List<LigneFacture>();
        }

        public void AjouterLigne(LigneFacture ligne)
        {
            Lignes.Add(ligne);
        }
        public decimal CalculerTotalHT()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
                total += ligne.CalculerTotalHT();
            return total;
        }
        public decimal CalculerTotalTVA()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
                total += ligne.CalculerMontantTVA();
            return total;
        }
        public decimal CalculerTotalTTC()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
                total += ligne.CalculerTotalTTC();
            return total;
        }
    }
}