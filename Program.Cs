using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("Résolveur du problème des n sur reines");
        Console.WriteLine("==========================");


        Console.Write("\n Entrez le nombre de reines (N) :");

        int n = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nVous avez choisi un échéquier de {n} x {n}.");

        // Création des variables propositionnelles
        Console.WriteLine("\nVariables propositionnelles :\n");

        // la variable i est le numéro de la ligne
        // on va parcourir les lignes de l'échéquier
        for(int i = 1; i < n; i++)
        {
            // la variable j est le numéro de la colonne
            // on va parcourir les colonnes
            for(int j = 1; j < n; j++)
            {
                Console.Write($"x{i},{j}\\t");
            }
            // on passe à la ligne suivante
            Console.WriteLine();
        }
    }
}