namespace TirelireLib
{
    public static class Opérations3
    {
        public static bool Déposer(Tirelire3 tirelire, decimal montant)
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

        public static decimal Vider(Tirelire3 tirelire)
        {
            var montantRestant = tirelire.MontantTotal;
            tirelire.MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");

            return montantRestant;
        }

        public static bool Retirer(Tirelire3 tirelire, decimal montant)
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
