

namespace TirelireLib
{
    public static class Opérations4
    {
        public static decimal Vider(this Tirelire4 tirelire)
        {
            var montantRestant = tirelire.MontantTotal;
            tirelire.MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");

            return montantRestant;
        }

        public static bool Déposer(this Tirelire4 tirelire, decimal montant)
        {
            bool montantValide = montant > 0;

            if (!montantValide)
            {
                return false;
            }

            tirelire.MontantTotal += montant;
            Historique.Instance.Add($"> Déposer {montant}");

            return montantValide;
        }
        public static bool Retirer(this Tirelire4 tirelire, decimal montant)
        {
            bool montantValide = montant > 0;
            bool retirerValide = montant <= tirelire.MontantTotal;
            bool transactionValide = montantValide && retirerValide;

            if (!transactionValide)
            {
                return false;
            }

            tirelire.MontantTotal -= montant;

            Historique.Instance.Add($"> Retirer {montant}");
            return transactionValide;
        }
    }
}
