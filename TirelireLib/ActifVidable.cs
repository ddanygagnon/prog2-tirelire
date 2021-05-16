namespace TirelireLib
{
    public abstract class ActifVidable : ActifDeBase
    {
        public virtual decimal Vider()
        {
            var montantRestant = this.MontantTotal;
            this.MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");

            return montantRestant;
        }
        public static decimal Vider(Tirelire5 tirelire)
        {
            var montantRestant = tirelire.MontantTotal;
            tirelire.MontantTotal = 0;
            Historique.Instance.Add($"> Vider {montantRestant}");

            return montantRestant;
        }
    }
}
