using TirelireLib;

namespace TirelirePlusLib
{
    public static class Tirelire6Ext
    {
        public static bool Reset(this Tirelire6 tirelire, decimal montantInitial = 0)
        {
            bool estValide = montantInitial >= 0;

            if (!estValide)
            {
                return false;
            }

            _ = tirelire.Vider();
            _ = estValide && montantInitial > 0 && tirelire.Déposer(montantInitial);

            return true;
        }
    }
}
