using System;
using System.Collections.Generic;
using System.Linq;

using BanqueLib;

using cstjean.info.fg.consoleplus;

using TirelireLib;

namespace TPConsole
{
    public static class MenuBanque
    {
        public static void Afficher(Banque banque)
        {
            do
            {
                ConsolePlus.Clear();
                AfficherEntête(banque);
            } while (TraiterMenuEtContinuer(banque));
        }

        private static bool TraiterMenuEtContinuer(Banque banque)
        {
            if (!ConsolePlus.LireChoix(out string? choix, 'A',
                Options(banque)))
            {
                return true;
            }

            ConsolePlus.WriteLine();
            switch (choix)
            {
                case "Quitter":
                    Historique.Quitter(Historique.Instance);
                    return false;

                case "Ouvrir Compte":
                    var texte = ConsolePlus.LireTexte("Titulaire");

                    if (ConsolePlus.LireDécimal("Mise de fond initiale", out decimal miseDeFond, "0", bloquant: true))
                    {
                        try
                        {
                            var ouvrirCompte = banque.OuvrirCompte(texte, miseDeFond);
                            Console.WriteLine();
                            ConsolePlus.MessageOkBloquant($"Nouveau compte #{ouvrirCompte.Numéro} avec mise de fond {miseDeFond:C}!");
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("trop petit"))
                            {
                                ConsolePlus.MessageErreurBloquant("Échec: La mise de fond est négative.");
                            }

                            if (ex.Message.Contains("trop précis"))
                            {
                                ConsolePlus.MessageErreurBloquant("Échec: Les fractions de cent ne sont pas admissibles.");
                            }

                            else
                            {
                                ConsolePlus.MessageErreurBloquant("Il faut entrer un nombre décimal svp");
                            }
                        }
                    }

                    break;

                case "Verser 2%":
                    var verser = banque.VerserIntérêts(2, out int nbComptes);
                    ConsolePlus.MessageOkBloquant($"Intérêts versés dans {nbComptes} comptes: {verser:C}");
                    break;
                default:
                    var parser = choix.TakeWhile(Char.IsDigit).ToArray();
                    var joined = string.Join("", parser);
                    var parsed = int.TryParse(joined, out int numeroCompte);
                    if (parsed)
                    {
                        TraiterAutreMenu(banque, banque.Comptes.First(c => c.Numéro == numeroCompte));
                    }
                    //Debug.Fail($"Cas non traité: {choix}");
                    break;
            }
            return true;
        }

        private static void TraiterAutreMenu(Banque banque, Compte3 compte)
        {
            do
            {
                ConsolePlus.Clear();
                MenuUtil.BanqueEntete(banque, compte);
            } while (Traiter(banque, compte));
        }

        private static string[] OptionsComptes()
        {
            var listeOptions = new List<string>() { "Quitter", "Déposer", "Retirer", "Vider", "Fermer", "Réactiver", "Geler", "Verser 1%", "Détruire" };
            return listeOptions.ToArray();
        }

        private static bool Traiter(Banque banque, Compte3 compte)
        {
            if (!ConsolePlus.LireChoix(out string? choix, '0', OptionsComptes()))
            {
                return true;
            }

            switch (choix)
            {
                case "Déposer":
                    Historique.Instance = new List<string>();
                    MenuUtil.Déposer(compte.Déposer);
                    break;
                case "Retirer":
                    Historique.Instance = new List<string>();
                    MenuUtil.Retirer(compte.Retirer);
                    break;
                case "Vider":
                    Historique.Instance = new List<string>();
                    MenuUtil.Vider(compte.Vider);
                    break;
                case "Fermer":
                    Historique.Instance = new List<string>();
                    MenuUtil.Fermer(compte.Fermer);
                    break;
                case "Réactiver":
                    Historique.Instance = new List<string>();
                    MenuUtil.Réactiver(compte.Réactiver);
                    break;
                case "Geler":
                    Historique.Instance = new List<string>();
                    MenuUtil.Geler(compte.Geler);
                    break;
                case "Verser 1%":
                    Historique.Instance = new List<string>();
                    MenuUtil.VerserIntérêts(() => compte.VerserIntérêts(1));
                    break;
                case "Détruire":
                    Historique.Instance = new List<string>();

                    ConsolePlus.WriteLine();
                    if (!ConsolePlus.LireBooléen("Voulez-vous vraiment (o/n)", out bool estValide) || !estValide)
                    {
                        return true;
                    }
                    try
                    {
                        _ = banque.DétruireCompte(compte.Numéro);
                        ConsolePlus.MessageOkBloquant($"Le compte #{compte.Numéro} a été détruit.");
                    }
                    catch (Exception)
                    {
                        ConsolePlus.MessageErreurBloquant("Impossible de détruire un compte qui n'est pas fermé");
                    }
                    break;
                case "Quitter":
                    Historique.QuitterBanque(compte.Numéro, banque.Nom, Historique.Instance);
                    return false;
            }

            return true;
        }

        private static string[] Options(Banque instance)
        {
            var liste = new List<string>()
            {
                "Quitter",
                "Ouvrir Compte",
                "Verser 2%"
            };

            foreach (var compte in instance.Comptes)
            {
                const int grosseur = 12;
                liste.Add($"{compte.Numéro,-grosseur}{compte.Titulaire,-grosseur}{Enum.GetName(compte.État),-grosseur}{string.Format($"{compte.MontantTotal:C}"),grosseur}");
            }

            return liste.ToArray();
        }


        public static void AfficherEntête(Banque banque)
        {
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(ConsoleColor.Magenta, $"DG - Banque {banque.Nom}");
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "===============");
            ConsolePlus.WriteLine();
            Historique.AfficherBanque();
            Console.WriteLine();
            ConsolePlus.Afficher($"{"Actif total",9}", $"{banque.ActifTotal:C}");
            ConsolePlus.Afficher($"{"Actif gelé",9}", $"{banque.ActifGelé:C}", couleurValeur: (ConsoleColor.Red, null));
            ConsolePlus.Afficher($"{"Nb Comptes",9}", $"{banque.NbComptes,-12}= {banque.NbActifs} actifs + {banque.NbGelés} gelés + {banque.NbFermés} fermés");
            ConsolePlus.Afficher($"{"Prochain No",9}", $"{banque.ProchainNuméroDeCompte}", couleurValeur: (ConsoleColor.Red, null));
            Console.WriteLine();
        }
    }
}
