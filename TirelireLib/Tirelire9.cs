using System;

namespace TirelireLib
{
    public class Tirelire9 : ActifVidable
    {
        public virtual void Déposer(decimal montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "trop petit");
            }

            if (Math.Round(montant, 2) != montant)
            {
                throw new ArgumentException("trop précis", nameof(montant));
            }

            Historique.Instance.Add($"> Déposer {montant}");

            this.MontantTotal += montant;
        }

        public virtual void Retirer(decimal montant)
        {
            bool montantValide = montant > 0;

            if (!montantValide)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "trop petit");
            }

            if (Math.Round(montant, 2) != montant)
            {
                throw new ArgumentException("trop précis", nameof(montant));
            }

            bool retirerValide = montant <= this.MontantTotal;

            if (!retirerValide)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "trop grand");
            }

            this.MontantTotal -= montant;

            Historique.Instance.Add($"> Retirer {montant}");
        }
    }
}
