using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetFacturationConsole.App;

namespace ProjetFacturationConsole.Tests;

[TestClass]
public class LigneFactureTests
{
    // ─────────────────────────────────────────────
    //  CalculerTotalHT
    // ─────────────────────────────────────────────
    [TestMethod]
    public void CalculerTotalHT_DeuxProduits_RetourneProduitQuantitePrix()
    {
        // Arrange
        var ligne = new LigneFacture("Développement", 2, 150m, 20m);

        // Act
        decimal totalHT = ligne.CalculerTotalHT();

        // Assert
        Assert.AreEqual(300m, totalHT);
    }

    [TestMethod]
    public void CalculerTotalHT_QuantiteUnitaire_RetournePrixUnitaire()
    {
        // Arrange
        var ligne = new LigneFacture("Maintenance", 1, 80m, 10m);

        // Act
        decimal totalHT = ligne.CalculerTotalHT();

        // Assert
        Assert.AreEqual(80m, totalHT);
    }

    [TestMethod]
    public void CalculerTotalHT_PrixZero_RetourneZero()
    {
        // Arrange
        var ligne = new LigneFacture("Gratuit", 5, 0m, 20m);

        // Act
        decimal totalHT = ligne.CalculerTotalHT();

        // Assert
        Assert.AreEqual(0m, totalHT);
    }

    // ─────────────────────────────────────────────
    //  CalculerTotalTTC (ligne)
    // ─────────────────────────────────────────────
    [TestMethod]
    public void CalculerTotalTTC_TVA20_RetourneTotalAvecTVA()
    {
        // Arrange
        var ligne = new LigneFacture("Développement", 2, 150m, 20m);

        // Act
        decimal totalTTC = ligne.CalculerTotalTTC();

        // Assert
        // HT = 300, TVA = 60  => TTC = 360
        Assert.AreEqual(360m, totalTTC);
    }

    [TestMethod]
    public void CalculerTotalTTC_TVA10_RetourneTotalAvecTVA()
    {
        // Arrange
        var ligne = new LigneFacture("Maintenance", 1, 80m, 10m);

        // Act
        decimal totalTTC = ligne.CalculerTotalTTC();

        // Assert
        // HT = 80, TVA = 8 => TTC = 88
        Assert.AreEqual(88m, totalTTC);
    }

    [TestMethod]
    public void CalculerTotalTTC_TVAZero_EgalTotalHT()
    {
        // Arrange
        var ligne = new LigneFacture("Exonéré", 3, 100m, 0m);

        // Act
        decimal totalTTC = ligne.CalculerTotalTTC();

        // Assert
        Assert.AreEqual(300m, totalTTC);
    }

    // ─────────────────────────────────────────────
    //  Exceptions
    // ─────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructeur_QuantiteNegative_LeveException()
    {
        _ = new LigneFacture("Test", -1, 100m, 20m);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructeur_QuantiteZero_LeveException()
    {
        _ = new LigneFacture("Test", 0, 100m, 20m);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructeur_PrixNegatif_LeveException()
    {
        _ = new LigneFacture("Test", 2, -50m, 20m);
    }
}

[TestClass]
public class FactureTotalTTCTests
{
    private Client CreerClientTest()
    {
        return new Client(1, "Paul Durand", "paul@mail.fr", "0600000000",
            "1 rue Test", "Lille", "59000", DateTime.Today.AddMonths(-1));
    }

    private Entreprise CreerEntrepriseTest()
    {
        return new Entreprise(1, "TechNova", "contact@technova.fr", "0300000000",
            "25 rue des Lilas", "Amiens", "80000", "12345678900011");
    }

    // ─────────────────────────────────────────────
    //  CalculerTotalTTC (Facture multi-lignes)
    // ─────────────────────────────────────────────
    [TestMethod]
    public void CalculerTotalTTC_DeuxLignes_RetourneSommeDesTTC()
    {
        // Arrange
        var facture = new Facture("F2026-001", DateTime.Today, CreerClientTest(), CreerEntrepriseTest());
        facture.AjouterLigne(new LigneFacture("Développement module connexion", 2, 150m, 20m)); // TTC = 360
        facture.AjouterLigne(new LigneFacture("Maintenance corrective", 1, 80m, 10m));          // TTC = 88

        // Act
        decimal totalTTC = facture.CalculerTotalTTC();

        // Assert
        Assert.AreEqual(448m, totalTTC);
    }

    [TestMethod]
    public void CalculerTotalTTC_TroisLignes_RetourneSommeCorrecteDesTousTTC()
    {
        // Arrange
        var facture = new Facture("F2026-002", DateTime.Today, CreerClientTest(), CreerEntrepriseTest());
        facture.AjouterLigne(new LigneFacture("Ligne 1", 1, 100m, 20m));   // TTC = 120
        facture.AjouterLigne(new LigneFacture("Ligne 2", 2, 50m, 10m));    // TTC = 110
        facture.AjouterLigne(new LigneFacture("Ligne 3", 3, 30m, 5m));     // TTC = 94.5

        // Act
        decimal totalTTC = facture.CalculerTotalTTC();

        // Assert
        Assert.AreEqual(324.5m, totalTTC);
    }

    [TestMethod]
    public void CalculerTotalHT_DeuxLignes_RetourneSommeDesHT()
    {
        // Arrange
        var facture = new Facture("F2026-003", DateTime.Today, CreerClientTest(), CreerEntrepriseTest());
        facture.AjouterLigne(new LigneFacture("Développement", 2, 150m, 20m)); // HT = 300
        facture.AjouterLigne(new LigneFacture("Maintenance", 1, 80m, 10m));    // HT = 80

        // Act
        decimal totalHT = facture.CalculerTotalHT();

        // Assert
        Assert.AreEqual(380m, totalHT);
    }

    [TestMethod]
    public void DateEcheance_EstDateEmissionPlus30Jours()
    {
        // Arrange
        DateTime dateEmission = new DateTime(2026, 5, 15);
        var facture = new Facture("F2026-001", dateEmission, CreerClientTest(), CreerEntrepriseTest());

        // Act & Assert
        Assert.AreEqual(dateEmission.AddDays(30), facture.DateEcheance);
    }
}

[TestClass]
public class ClientTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructeur_DateInscriptionFuture_LeveException()
    {
        _ = new Client(1, "Test", "test@mail.fr", "0600000000", "1 rue A", "Ville", "00000", DateTime.Today.AddDays(1));
    }

    [TestMethod]
    public void Constructeur_DateInscriptionAujourdhui_NeLevePasException()
    {
        // Ne doit pas lever d'exception
        var client = new Client(1, "Test", "test@mail.fr", "0600000000", "1 rue A", "Ville", "00000", DateTime.Today);
        Assert.IsNotNull(client);
    }
}
