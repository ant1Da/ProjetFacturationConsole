
using System;
using System.Collections.Generic;

public class GestionFacturation
{
    private List<Client> clients = new List<Client>();
    private Dictionary<int, Client> dictionnaireClients = new Dictionary<int, Client>();

    public void CreerFacture()
    {
        DateTime dateEmission;

        while (true)
        {
            try
            {
                Console.Write("Date d'émission (jj/mm/aaaa) : ");
                dateEmission = DateTime.Parse(Console.ReadLine());

                if (dateEmission > DateTime.Now)
                    throw new Exception("Date invalide");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        int quantite;
        while (true)
        {
            try
            {
                Console.Write("Quantité : ");
                quantite = int.Parse(Console.ReadLine());

                if (quantite <= 0)
                    throw new Exception("Quantité invalide");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        decimal prix;
        while (true)
        {
            try
            {
                Console.Write("Prix HT : ");
                prix = decimal.Parse(Console.ReadLine());

                if (prix <= 0)
                    throw new Exception("Prix invalide");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        Console.WriteLine("Facture créée avec succès !");
    }
}
