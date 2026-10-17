using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("Résolveur du problème des n reines");
        Console.WriteLine("==========================");

        Console.Write("\nEntrez le nombre de reines (N) : ");

        int n = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nVous avez choisi un échiquier de {n} x {n}.");

        // Création des variables propositionnelles.
        // Chaque variable représente une case de l'échiquier.
        Console.WriteLine("\nVariables propositionnelles :\n");

        // La variable i représente le numéro de la ligne.
        // On parcourt toutes les lignes de l'échiquier.
        for (int i = 1; i <= n; i++)
        {
            // La variable j représente le numéro de la colonne.
            // On parcourt toutes les colonnes de chaque ligne.
            for (int j = 1; j <= n; j++)
            {
                Console.Write($"x{i},{j}\t");
            }

            // On passe à la ligne suivante.
            Console.WriteLine();
        }

        // ==========================================
        // CONTRAINTES DES LIGNES
        // ==========================================

        // On appelle la méthode qui génère les contraintes
        // empêchant deux reines d'être sur la même ligne.
        List<int[]> contraintesLignes = GenererContraintesLignes(n);

        Console.WriteLine("\nContraintes CNF des lignes :\n");

        // On parcourt toutes les contraintes de lignes.
        foreach (int[] clause in contraintesLignes)
        {
            Console.WriteLine($"({clause[0]} OU {clause[1]})");
        }

        // On affiche le nombre total de contraintes de lignes.
        Console.WriteLine($"\nNombre de contraintes de lignes : {contraintesLignes.Count}");

        // ==========================================
        // CONTRAINTES DES COLONNES
        // ==========================================

        // On appelle la méthode qui génère les contraintes
        // empêchant deux reines d'être sur la même colonne.
        List<int[]> contraintesColonnes = GenererContraintesColonnes(n);

        Console.WriteLine("\nContraintes CNF des colonnes :\n");

        // On parcourt toutes les contraintes de colonnes.
        foreach (int[] clause in contraintesColonnes)
        {
            Console.WriteLine($"({clause[0]} OU {clause[1]})");
        }

        // On affiche le nombre total de contraintes de colonnes.
        Console.WriteLine($"\nNombre de contraintes de colonnes : {contraintesColonnes.Count}");

        // On affiche le nombre total de contraintes générées.
        int total = contraintesLignes.Count + contraintesColonnes.Count;

        Console.WriteLine($"\nNombre total de contraintes : {total}");
    }

    // ==========================================
    // MÉTHODE : CONTRAINTES DES LIGNES
    // ==========================================

    static List<int[]> GenererContraintesLignes(int n)
    {
        // Cette liste va stocker toutes les contraintes des lignes.
        List<int[]> contraintes = new List<int[]>();

        // On parcourt chaque ligne de l'échiquier.
        for (int i = 1; i <= n; i++)
        {
            // On choisit une première colonne.
            for (int j = 1; j <= n; j++)
            {
                // On choisit une deuxième colonne.
                // On commence à j + 1 pour éviter les doublons.
                for (int k = j + 1; k <= n; k++)
                {
                    // On transforme les positions en numéros de variables.
                    int variable1 = (i - 1) * n + j;
                    int variable2 = (i - 1) * n + k;

                    // Les deux variables sont négatives.
                    // Cela interdit de placer deux reines
                    // simultanément sur ces deux cases.
                    int[] clause = { -variable1, -variable2 };

                    // On ajoute la contrainte dans la liste.
                    contraintes.Add(clause);
                }
            }
        }

        // On renvoie toutes les contraintes générées.
        return contraintes;
    }

    // ==========================================
    // MÉTHODE : CONTRAINTES DES COLONNES
    // ==========================================

    static List<int[]> GenererContraintesColonnes(int n)
    {
        // Cette liste va stocker toutes les contraintes des colonnes.
        List<int[]> contraintes = new List<int[]>();

        // On parcourt toutes les colonnes de l'échiquier.
        for (int j = 1; j <= n; j++)
        {
            // On choisit une première ligne.
            for (int i = 1; i <= n; i++)
            {
                // On choisit une deuxième ligne.
                // On commence à i + 1 pour éviter les doublons.
                for (int k = i + 1; k <= n; k++)
                {
                    // On transforme les positions en numéros de variables.
                    int variable1 = (i - 1) * n + j;
                    int variable2 = (k - 1) * n + j;

                    // On crée une clause contenant deux variables négatives.
                    // Cela signifie que les deux cases ne peuvent pas
                    // contenir une reine en même temps.
                    int[] clause = { -variable1, -variable2 };

                    // On ajoute cette clause à notre liste.
                    contraintes.Add(clause);
                }
            }
        }

        // On renvoie toutes les contraintes des colonnes.
        return contraintes;
    }
}