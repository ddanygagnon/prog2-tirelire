using System.Collections.Generic;

using BanqueLib;

using TirelireLib;

using TirelirePlusLib;

namespace TPConsole
{
    public class Instances
    {
        public Tirelire3 Tirelire3a { get; init; } = new();
        public Tirelire3 Tirelire3b { get; init; } = new();
        public Tirelire4 Tirelire4a { get; init; } = new();
        public Tirelire5 Tirelire5a { get; init; } = new();
        public Tirelire6 Tirelire6a { get; init; } = new();
        public Tirelire6Plus Tirelire6p { get; init; } = new();
        public Tirelire7 Tirelire7a { get; init; } = new();
        public Tirelire9 Tirelire9a { get; init; } = new();
        public Compte1 MonCompte1 { get; init; } = new(1, "Dany Gagnon");
        public Compte2 MonCompte2 { get; init; } = new(2, "Dany Gagnon");
        public Compte3 MonCompte3 { get; init; } = new(3, "Dany Gagnon");
        public Banque BanqueDG { get; init; } = new("DG", new List<Compte3>());

        public Banque BanqueJedi { get; init; } = new Banque("Jedi", new List<Compte3>
        {
            new(1, "Dany Gagnon", 111),
            new(2, "Luke", 0, ÉtatDuCompte.Fermé),
            new(4, "Leia", 444),
            new(7, "Obiwan", 777),
            new(9, "Yoda", 999, ÉtatDuCompte.Gelé),
            new(12, "Annakim", 0, ÉtatDuCompte.Fermé),
            new(15, "Solo", 150, ÉtatDuCompte.Gelé),
            new(16, "Chewy", 2150),
            new(19, "Sidious", 777, ÉtatDuCompte.Gelé)
        });

        public static Instances MesInstances { get; set; } = new();
    }
}
