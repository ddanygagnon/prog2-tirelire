namespace TirelireLib
{
    public class Tirelire5 : ActifVidable
    {
        public static bool Déposer(Tirelire5 tirelire, decimal montant)
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
        public static bool Retirer(Tirelire5 tirelire, decimal montant)
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
