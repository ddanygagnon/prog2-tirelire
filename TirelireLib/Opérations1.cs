namespace TirelireLib
{
    public static class Opérations1
    {
        public static bool Déposer(decimal montant)
        {
            bool montantValide = montant > 0;

            if (!montantValide)
            {
                return false;
            }

            Historique.Instance.Add($"> Déposer {montant}");
            Tirelire1.MontantTotal += montant;
            return montantValide;
        }

        public static bool Retirer(decimal montant)
        {
            bool montantValide = montant > 0;
            bool retirerValide = montant <= Tirelire1.MontantTotal;
            bool transactionValide = montantValide && retirerValide;

            if (!transactionValide)
            {
                return false;
            }

            Tirelire1.MontantTotal -= montant;
            Historique.Instance.Add($"> Retirer {montant}");

            return transactionValide;
        }

        public static decimal Vider()
        {
            var montantRestant = Tirelire1.MontantTotal;
            Tirelire1.MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");
            return montantRestant;
        }
    }
}
