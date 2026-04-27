namespace ProjetFacturationConsole.App
{
    public class LigneFacture
    {
        public string Description { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaireHT { get; set; }
        public decimal TauxTVA { get; set; }

        public LigneFacture(string description, int quantite, decimal prixUnitaireHT, decimal tauxTVA)
        {
            Description = description;
            Quantite = quantite;
            PrixUnitaireHT = prixUnitaireHT;
            TauxTVA = tauxTVA;
        }

        public decimal CalculerTotalHT()
        {
            return Quantite * PrixUnitaireHT;
        }
        public decimal CalculerMontantTVA()
        {
            return CalculerTotalHT() * (TauxTVA / 100);
        }
        public decimal CalculerTotalTTC()
        {
            return CalculerTotalHT() + CalculerMontantTVA();
        }
    }
}