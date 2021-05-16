using TirelireLib;

namespace TirelirePlusLib
{
    public class Tirelire6Plus : Tirelire6
    {
        public bool Init(decimal montant = 0)
        {
            bool estValide = montant >= 0;

            if (!estValide)
            {
                return false;
            }

            _ = this.Vider();
            _ = estValide && montant > 0 && this.Déposer(montant);

            return true;
        }
    }
}
