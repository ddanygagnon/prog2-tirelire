using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using BanqueLib;

using static TPConsole.Instances;
using cstjean.info.fg.consoleplus;

using TirelireLib;

namespace TPConsole
{
    public static class MenuGénéral
    {
        private static bool estReduit;

        public static void Afficher()
        {
            do
            {
                ConsolePlus.Clear();
                AfficherEntête();
            } while (TraiterMenuEtContinuer());
        }

        private static void AfficherEntête()
        {
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "DG - Menu général");
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "===============");
            ConsolePlus.WriteLine();

            Historique.Afficher("");

            ConsolePlus.WriteLine();

            const int colonne = -14;

            if (!estReduit)
            {
                ConsolePlus.Afficher($"{"Tirelire 1",colonne}", $"{Tirelire1.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 2",colonne}", $"{Tirelire2.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 3a",colonne}", $"{MesInstances.Tirelire3a.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 3b",colonne}", $"{MesInstances.Tirelire3b.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 4a",colonne}", $"{MesInstances.Tirelire4a.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 5a",colonne}", $"{MesInstances.Tirelire5a.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 6a",colonne}", $"{MesInstances.Tirelire6a.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 6p",colonne}", $"{MesInstances.Tirelire6p.MontantTotal:C}");
                ConsolePlus.Afficher($"{"Tirelire 7a",colonne}", $"{MesInstances.Tirelire7a.MontantTotal:C}");
            }
            ConsolePlus.Afficher($"{"Tirelire 9a",colonne}", $"{MesInstances.Tirelire9a.MontantTotal:C}");
            ConsolePlus.Afficher($"{"Mon compte 1",colonne}", $"{MesInstances.MonCompte1.MontantTotal:C}");
            ConsolePlus.Afficher($"{"Mon compte 2",colonne}", $"{MesInstances.MonCompte2.MontantTotal:C}");
            ConsolePlus.Afficher($"{"Mon compte 3",colonne}", $"{MesInstances.MonCompte3.MontantTotal:C}");
            ConsolePlus.Afficher($"{"Banque DG",colonne}", $"{MesInstances.BanqueDG.ActifTotal:C}");
            ConsolePlus.Afficher($"{"Banque Jedi",colonne}", $"{MesInstances.BanqueJedi.ActifTotal:C}");

            ConsolePlus.WriteLine();
        }

        private static string[] Options()
        {
            var liste = new List<string>()
            {
                "Quitter",
                "Reset",
                "Planter",
                "Réduire",
                "Tirelire 1",
                "Tirelire 2",
                "Tirelire 3a",
                "Tirelire 3b",
                "Tirelire 4a",
                "Tirelire 5a",
                "Tirelire 6a",
                "Tirelire 6p",
                "Tirelire 7a",
                "Tirelire 9a",
                "Mon compte 1",
                "Mon compte 2",
                "Mon compte 3",
                "Banque DG",
                "Banque Jedi",
            };

            if (!estReduit)
            {
                return liste.ToArray();
            }

            var derniereValeur = liste.Last();
            var estReduiteListe = liste.Where(e => !e.Contains("Tirelire") && !e.Contains("Réduire") && !e.Contains("compte") && !e.Contains("Banque")).ToList();
            estReduiteListe.Add("Étendre");
            estReduiteListe.Add("Tirelire 9a");
            estReduiteListe.Add("Mon compte 1");
            estReduiteListe.Add("Mon compte 2");
            estReduiteListe.Add("Mon compte 3");
            estReduiteListe.Add("Banque DG");
            estReduiteListe.Add(derniereValeur);

            return estReduiteListe.ToArray();
        }

        private static bool TraiterMenuEtContinuer()
        {
            if (!ConsolePlus.LireChoix(out string? choix, 'A',
                Options()))
            {
                return true;
            }

            ConsolePlus.WriteLine();
            switch (choix)
            {
                case "Reset":
                    Reset();
                    break;
                case "Planter":
                    throw new InvalidOperationException("DG dit Boom!");
                case "Réduire":
                    estReduit = true;
                    break;
                case "Étendre":
                    estReduit = false;
                    break;
                case "Tirelire 1":
                    Historique.Instance = new List<string>();
                    MenuTirelire1();
                    break;
                case "Tirelire 2":
                    Historique.Instance = new List<string>();
                    MenuTirelire2();
                    break;
                case "Tirelire 3a":
                    Historique.Instance = new List<string>();
                    MenuTirelire3(MesInstances.Tirelire3a, "3a");
                    break;
                case "Tirelire 3b":
                    Historique.Instance = new List<string>();
                    MenuTirelire3(MesInstances.Tirelire3b, "3b");
                    break;
                case "Tirelire 4a":
                    Historique.Instance = new List<string>();
                    MenuTirelire4(MesInstances.Tirelire4a, "4a");
                    break;
                case "Tirelire 5a":
                    Historique.Instance = new List<string>();
                    MenuTirelire5(MesInstances.Tirelire5a, "5a");
                    break;
                case "Tirelire 6a":
                    Historique.Instance = new List<string>();
                    MenuTirelire6(MesInstances.Tirelire6a, "6a");
                    break;
                case "Tirelire 6p":
                    Historique.Instance = new List<string>();
                    MenuTirelire6(MesInstances.Tirelire6p, "6p");
                    break;
                case "Tirelire 7a":
                    Historique.Instance = new List<string>();
                    MenuTirelire6(MesInstances.Tirelire7a, "7a");
                    break;
                case "Tirelire 9a":
                    Historique.Instance = new List<string>();
                    MenuTirelire9(MesInstances.Tirelire9a, "9a");
                    break;
                case "Mon compte 1":
                    Historique.Instance = new List<string>();
                    MenuCompte1(MesInstances.MonCompte1, MesInstances.MonCompte1.Numéro);
                    break;
                case "Mon compte 2":
                    Historique.Instance = new List<string>();
                    MenuCompte2(MesInstances.MonCompte2, MesInstances.MonCompte2.Numéro);
                    break;
                case "Mon compte 3":
                    Historique.Instance = new List<string>();
                    MenuCompte3(MesInstances.MonCompte3, MesInstances.MonCompte3.Numéro);
                    break;
                case "Banque DG":
                    Historique.Instance = new List<string>();
                    MenuBanque.Afficher(MesInstances.BanqueDG);
                    break;
                case "Banque Jedi":
                    Historique.Instance = new List<string>();
                    MenuBanque.Afficher(MesInstances.BanqueJedi);
                    break;
                case "Quitter":
                    return false;
                default:
                    Debug.Fail($"Cas non traité: {choix}");
                    break;
            }
            return true;
        }

        private static void Reset()
        {
            if (!ConsolePlus.LireBooléen("Voulez-vous vraiment (o/n)", out bool estValide) || !estValide)
            {
                return;
            }

            Tirelire1.MontantTotal = 0;
            _ = Tirelire2.Vider();
            MesInstances = new Instances();

            Historique.Général = new List<string>();
        }

        private static void MenuTirelire1()
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(Tirelire1.MontantTotal, "1");
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(Opérations1.Déposer),
                    () => MenuUtil.Retirer(Opérations1.Retirer),
                    () => MenuUtil.Vider(Opérations1.Vider));
            }

            Historique.Quitter("1", Historique.Instance);
        }

        private static void MenuTirelire2()
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(Tirelire2.MontantTotal, "2");
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(Tirelire2.Déposer),
                    () => MenuUtil.Retirer(Tirelire2.Retirer),
                    () => MenuUtil.Vider(Tirelire2.Vider));
            }
            Historique.Quitter("2", Historique.Instance);
        }

        private static void MenuTirelire3(Tirelire3 instance, string tirelireId)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance.MontantTotal, tirelireId);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(montant => Opérations3.Déposer(instance, montant)),
                    () => MenuUtil.Retirer(montant => Opérations3.Retirer(instance, montant)),
                    () => MenuUtil.Vider(() => Opérations3.Vider(instance)));
            }
            Historique.Quitter(tirelireId, Historique.Instance);
        }

        private static void MenuTirelire4(Tirelire4 instance, string tirelireId)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance.MontantTotal, tirelireId);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider));
            }
            Historique.Quitter(tirelireId, Historique.Instance);
        }

        private static void MenuTirelire5(Tirelire5 instance, string tirelireId)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance.MontantTotal, tirelireId);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(m => Tirelire5.Déposer(instance, m)),
                    () => MenuUtil.Retirer(m => Tirelire5.Retirer(instance, m)),
                    () => MenuUtil.Vider(() => ActifVidable.Vider(instance)));
            }
            Historique.Quitter(tirelireId, Historique.Instance);
        }

        private static void MenuTirelire6(Tirelire6 instance, string tirelireId)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance.MontantTotal, tirelireId);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider));
            }
            Historique.Quitter(tirelireId, Historique.Instance);
        }

        private static void MenuTirelire9(Tirelire9 instance, string tirelireId)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance.MontantTotal, tirelireId);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider));
            }
            Historique.Quitter(tirelireId, Historique.Instance);
        }

        private static void MenuCompte1(Compte1 instance, int numéroCompte)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance, numéroCompte);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider));
            }
            Historique.Quitter(numéroCompte, Historique.Instance);
        }

        private static void MenuCompte2(Compte2 instance, int numéroCompte)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance, numéroCompte);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider),
                    () => MenuUtil.Fermer(instance.Fermer),
                        () => MenuUtil.Réactiver(instance.Réactiver)
                    );
            }
            Historique.Quitter(numéroCompte, Historique.Instance);
        }

        public static void MenuCompte3(Compte3 instance, int numéroCompte)
        {
            var continuer = true;
            while (continuer)
            {
                ConsolePlus.Clear();
                MenuUtil.AfficherEntête(instance, numéroCompte);
                continuer = MenuUtil.TraiterMenuEtContinuer(
                    () => MenuUtil.Déposer(instance.Déposer),
                    () => MenuUtil.Retirer(instance.Retirer),
                    () => MenuUtil.Vider(instance.Vider),
                    () => MenuUtil.Fermer(instance.Fermer),
                    () => MenuUtil.Réactiver(instance.Réactiver),
                    () => MenuUtil.Geler(instance.Geler),
                    () => MenuUtil.VerserIntérêts(() => instance.VerserIntérêts(1))
                );
            }
            Historique.Quitter(numéroCompte, Historique.Instance);
        }


    }
}
