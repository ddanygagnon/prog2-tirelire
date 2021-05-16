using System;
using System.Collections.Generic;
using System.Diagnostics;

using BanqueLib;

using cstjean.info.fg.consoleplus;

using TirelireLib;

namespace TPConsole
{
    public static class MenuUtil
    {
        public static void AfficherEntête(decimal montantTotal, string tirelireId)
        {
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(ConsoleColor.Magenta, $"DG - Tirelire {tirelireId}");
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "===============");
            ConsolePlus.WriteLine();

            Historique.Afficher(tirelireId);

            ConsolePlus.WriteLine();
            ConsolePlus.Afficher("Actif", $"{montantTotal:C}");
            ConsolePlus.WriteLine();
        }

        public static void AfficherEntête(dynamic instance, int numéroCompte)
        {
            if (instance is not Compte1)
            {
                throw new ArgumentException("L'instance passée en paramètre est invalide.");
            }
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(ConsoleColor.Magenta, $"DG - Compte #{numéroCompte}");
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "===============");
            ConsolePlus.WriteLine();

            Historique.Afficher(numéroCompte);

            ConsolePlus.WriteLine();

            ConsolePlus.Afficher($"{"Titulaire",9}", $"{instance.Titulaire}");
            ConsolePlus.Afficher($"{"Solde",9}", $"{instance.MontantTotal:C}");

            if (instance is Compte2)
            {
                ConsolePlus.Afficher($"{"État",9}", $"{Enum.GetName(instance.État)}");
            }

            ConsolePlus.WriteLine();
        }

        public static void BanqueEntete(Banque banque, Compte3 instance)
        {
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(ConsoleColor.Magenta, $"DG - Banque {banque.Nom} : Compte #{instance.Numéro}");
            ConsolePlus.WriteLine(ConsoleColor.Magenta, "==========================");
            ConsolePlus.WriteLine();

            Historique.Afficher(instance.Numéro, true, banque.Nom);

            ConsolePlus.WriteLine();

            ConsolePlus.Afficher($"{"Titulaire",9}", $"{instance.Titulaire}");
            ConsolePlus.Afficher($"{"Solde",9}", $"{instance.MontantTotal:C}");
            ConsolePlus.Afficher($"{"État",9}", $"{Enum.GetName(instance.État)}");

            ConsolePlus.WriteLine();
        }


        public static bool TraiterMenuEtContinuer(Action deposer, Action retirer, Action vider, Action fermer = null!, Action reactiver = null!, Action geler = null!, Action verser = null!)
        {
            var listeOptions = new List<string>() { "Quitter", "Déposer", "Retirer", "Vider" };

            if (fermer != null && reactiver != null)
            {
                listeOptions.Add("Fermer");
                listeOptions.Add("Réactiver");
            }

            if (geler != null && verser != null)
            {
                listeOptions.Add("Geler");
                listeOptions.Add("Verser 1%");
            }

            if (!ConsolePlus.LireChoix(out string? choix, '0', listeOptions.ToArray()))
            {
                return true;
            }

            ConsolePlus.WriteLine();
            switch (choix)
            {
                case "Déposer":
                    deposer();
                    break;
                case "Retirer":
                    retirer();
                    break;
                case "Vider":
                    vider();
                    break;
                case "Quitter":
                    return false;
                case "Fermer":
                    fermer?.Invoke();
                    break;
                case "Réactiver":
                    reactiver?.Invoke();
                    break;
                case "Geler":
                    geler?.Invoke();
                    break;
                case "Verser 1%":
                    verser?.Invoke();
                    break;
                default:
                    Debug.Fail($"Cas non traité: {choix}");
                    break;
            }
            return true;
        }

        public static void Déposer(Func<decimal, bool> déposerDsTirelire)
        {
            if (ConsolePlus.LireDécimal("Montant", out decimal montant))
            {
                if (déposerDsTirelire(montant))
                {
                    ConsolePlus.MessageOkBloquant("Dépôt réussi");
                }
                else
                {
                    ConsolePlus.MessageErreurBloquant("Échec du dépôt");
                }
            }
            else
            {
                ConsolePlus.Poursuivre();
            }
        }

        public static void Retirer(Func<decimal, bool> retirerDsTirelire)
        {
            if (ConsolePlus.LireDécimal("Montant", out decimal montant))
            {
                if (retirerDsTirelire(montant))
                {
                    ConsolePlus.MessageOkBloquant("Retrait réussi");
                }
                else
                {
                    ConsolePlus.MessageErreurBloquant("Échec du retrait");
                }
            }
            else
            {
                ConsolePlus.Poursuivre();
            }
        }

        public static void Déposer(Action<decimal> déposerDsTirelire)
        {
            if (ConsolePlus.LireDécimal("Montant", out decimal montant))
            {
                try
                {
                    déposerDsTirelire(montant);
                    ConsolePlus.MessageOkBloquant("Dépôt réussi");
                }
                catch (Exception ex)
                {
                    string montantFormat = montant < 0 ? $"({Math.Abs(montant):C})" : $"{montant:C}";
                    string messageErreur = "";

                    if (ex.Message.Contains("trop petit"))
                    {
                        messageErreur = "Le montant doit être positif";
                    }

                    if (ex.Message.Contains("trop précis"))
                    {
                        montantFormat = "des fractions de cents";
                        messageErreur = "Le montant est trop précis";
                    }

                    if (ex.Message.Contains("pas actif"))
                    {
                        montantFormat = "car le compte n'est pas actif";
                    }

                    ConsolePlus.MessageErreurBloquant($"Impossible de déposer {montantFormat}.\n{messageErreur}");
                }
            }
            else
            {
                ConsolePlus.Poursuivre();
            }
        }

        public static void Retirer(Action<decimal> retirerDsTirelire)
        {
            if (ConsolePlus.LireDécimal("Montant", out decimal montant))
            {
                try
                {
                    retirerDsTirelire(montant);
                    ConsolePlus.MessageOkBloquant("Dépôt réussi");
                }
                catch (Exception ex)
                {
                    string montantFormat = montant < 0 ? $"({Math.Abs(montant):C})" : $"{montant:C}";
                    string messageErreur = "";

                    if (ex.Message.Contains("trop petit"))
                    {
                        messageErreur = "Le montant doit être positif";
                    }

                    else if (ex.Message.Contains("trop grand"))
                    {
                        messageErreur = "Actif insuffisant";
                    }

                    if (ex.Message.Contains("trop précis"))
                    {
                        montantFormat = "des fractions de cents";
                        messageErreur = "Le montant est trop précis";
                    }

                    if (ex.Message.Contains("pas actif"))
                    {
                        montantFormat = "car le compte n'est pas actif";
                    }

                    ConsolePlus.MessageErreurBloquant($"Impossible de retirer {montantFormat}.\n{messageErreur}");
                }
            }
            else
            {
                ConsolePlus.Poursuivre();
            }
        }

        public static void Vider(Func<decimal> vider)
        {
            try
            {
                var montant = vider();
                ConsolePlus.MessageOkBloquant($"La tirelire a été vidée. Montant récupéré: {montant:C}");
            }
            catch (Exception ex)
            {
                ConsolePlus.MessageErreurBloquant(ex.Message);
            }

        }

        public static void Fermer(Func<decimal> fermer)
        {
            try
            {
                var montant = fermer();
                ConsolePlus.MessageOkBloquant($"Le compte a été fermée. Montant récupéré: {montant:C}");
            }
            catch (Exception ex)
            {
                ConsolePlus.MessageErreurBloquant(ex.Message);
            }
        }

        public static void Réactiver(Action réactiver)
        {
            try
            {
                réactiver();
                ConsolePlus.MessageOkBloquant($"Le compte à été réactivé.");
            }
            catch (Exception ex)
            {
                ConsolePlus.MessageErreurBloquant(ex.Message);
            }
        }

        public static void Geler(Action geler)
        {
            try
            {
                geler();
                ConsolePlus.MessageOkBloquant($"Le compte à été gelé.");
            }
            catch (Exception ex)
            {
                ConsolePlus.MessageErreurBloquant(ex.Message);
            }
        }

        public static void VerserIntérêts(Func<decimal> verser)
        {
            try
            {
                var montant = verser();
                ConsolePlus.MessageOkBloquant($"Intérêts versés à votre compte: {montant:C}");
            }
            catch (Exception ex)
            {
                ConsolePlus.MessageErreurBloquant(ex.Message);
            }
        }
    }
}
