using System;
using System.Collections.Generic;

using cstjean.info.fg.consoleplus;

namespace TirelireLib
{
    public static class Historique
    {
        public static List<string> Instance { get; set; } = new();
        public static List<string> Général { get; set; } = new();

        public static void Afficher(string tirelireId = "")
        {
            ConsolePlus.Afficher("Historique", "");

            foreach (string historique in Général)
            {
                Console.WriteLine($"\t{historique}");
            }

            if (tirelireId != string.Empty)
            {
                Console.WriteLine($"\t>> Tirelire {tirelireId} {string.Join(" ", Instance)}");
            }
        }

        public static void Afficher(int numéroCompte = 0, bool estBanque = false, string nomBanque = "")
        {
            ConsolePlus.Afficher("Historique", "");

            foreach (string historique in Général)
            {
                Console.WriteLine($"\t>> {historique}");
            }



            if (numéroCompte != 0)
            {
                if (estBanque)
                {
                    Console.WriteLine($"\t>> [{nomBanque}] Compte {numéroCompte} {string.Join(" ", Instance)}");
                }
                else
                {
                    Console.WriteLine($"\t>> Mon compte {numéroCompte} {string.Join(" ", Instance)}");
                }
            }
        }

        public static void AfficherBanqueHisto(string nomBanque, int numero)
        {
            ConsolePlus.Afficher("Historique", "");

            foreach (string historique in Général)
            {
                Console.WriteLine($"\t>> {historique}");
            }

            Console.WriteLine($"\t>> [{nomBanque}] Compte {numero} {string.Join(" ", Instance)}");
        }

        public static void AfficherBanque()
        {
            ConsolePlus.Afficher("Historique", "");

            foreach (string historique in Général)
            {
                Console.WriteLine($"\t>> {historique}");
            }

            foreach (string s in Instance)
            {
                Console.WriteLine($"\t>> {s}");
            }

        }

        public static void Quitter(List<string> historique)
        {
            if (historique.Count == 0)
            {
                return;
            }

            foreach (var histo in historique)
            {
                Général.Add($">> {histo}");
            }

            Instance.Clear();
        }

        public static void Quitter(string tirelireId, List<string> historique)
        {
            if (historique.Count == 0)
            {
                return;
            }
            historique.Insert(0, $">> Tirelire {tirelireId}");
            Général.Add(string.Join(" ", historique));
            Instance.Clear();
        }

        public static void Quitter(int numeroCompte, List<string> historique)
        {
            if (historique.Count == 0)
            {
                return;
            }
            historique.Insert(0, $">> Compte {numeroCompte}");
            Général.Add(string.Join(" ", historique));
            Instance.Clear();
        }

        public static void QuitterBanque(int numeroCompte, string nom, List<string> historique)
        {
            historique.Insert(0, $"[{nom}] Compte {numeroCompte}");
            Général.Add(string.Join(" ", historique));
            Instance.Clear();
        }
    }
}
