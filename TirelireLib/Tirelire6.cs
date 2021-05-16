namespace TirelireLib
{
    public class Tirelire6 : ActifVidable
    {

        public bool Déposer(decimal montant)
        {
            bool montantValide = montant > 0;

            if (!montantValide)
            {
                return false;
            }

            this.MontantTotal += montant;
            Historique.Instance.Add($"> Déposer {montant}");

            return montantValide;
        }

        public bool Retirer(decimal montant)
        {
            bool montantValide = montant > 0;
            bool retirerValide = montant <= this.MontantTotal;
            bool transactionValide = montantValide && retirerValide;

            if (!transactionValide)
            {
                return false;
            }

            this.MontantTotal -= montant;

            Historique.Instance.Add($"> Retirer {montant}");
            return transactionValide;
        }
    }
}
