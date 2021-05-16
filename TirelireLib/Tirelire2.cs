using System.Text.Json.Serialization;

namespace TirelireLib
{
    public static class Tirelire2
    {
        [JsonInclude]
        public static decimal MontantTotal { get; private set; }

        public static bool Déposer(decimal montant)
        {
            bool montantValide = montant > 0;

            if (!montantValide)
            {
                return false;
            }

            MontantTotal += montant;
            Historique.Instance.Add($"> Déposer {montant}");

            return montantValide;
        }
        public static bool Retirer(decimal montant)
        {
            bool montantValide = montant > 0;
            bool retirerValide = montant <= MontantTotal;
            bool transactionValide = montantValide && retirerValide;

            if (!transactionValide)
            {
                return false;
            }

            MontantTotal -= montant;
            Historique.Instance.Add($"> Retirer {montant}");

            return transactionValide;
        }

        public static decimal Vider()
        {
            var montantRestant = MontantTotal;
            MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");

            return montantRestant;
        }
    }
}
