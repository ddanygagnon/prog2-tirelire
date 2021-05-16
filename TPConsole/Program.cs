using System;
using System.Text;

using cstjean.info.fg.consoleplus;

namespace TPConsole
{
    internal static class Program
    {
        private static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            ConsolePlus.Title = "DG - TP Banque";
            ConsolePlus.IndentationGénérale = 1;
            ConsolePlus.SetWindowSize(80, 35);
            Persistance.Charger();

            AppDomain.CurrentDomain.ProcessExit += ExitHandler;

            try
            {
                MenuGénéral.Afficher();
            }
            catch (InvalidOperationException ex)
            {
                // Normalement il faudrait catcher Exception ici. 
                // Mais on se limite à InvalidOperationException pour faciliter le débogage.
                ConsolePlus.MessageErreurBloquant(
                    "Désolé, une erreur inattendue s'est produite."
                    + "\nLe programme doit malheureusement fermer."
                    + $"\n{ex.GetType().Name} : {ex.Message}");
            }
        }

        private static void ExitHandler(object? sender, EventArgs e)
        {
            Persistance.Sauvegarder();
        }
    }
}
