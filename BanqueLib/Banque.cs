using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

using TirelireLib;

namespace BanqueLib
{
    public class Banque
    {
        private readonly List<Compte3> comptes = new();

        public IEnumerable<Compte3> Comptes => this.comptes;

        public string Nom { get; }

        [JsonConstructor]
        public Banque(string nom, IEnumerable<Compte3> comptes = null)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentException("null ou blanc", nameof(nom));
            }

            var listCompte = (comptes ?? Array.Empty<Compte3>())
                .Select(compte => new Compte3(compte))
                .ToList();

            var listeNumero = listCompte.Select(compte => compte.Numéro).ToList();
            var listDistinct = listCompte.Select(compte => compte.Numéro).Distinct().ToList();

            if (listeNumero.Count != listDistinct.Count)
            {
                throw new ArgumentException("numéros en double");
            }

            this.comptes = listCompte.OrderBy(compte => compte.Numéro).ToList();
            var maximum = 0;
            if (this.comptes.Count > 0)
            {
                maximum = comptes?.Max(compte => compte.Numéro) ?? 0;
            }
            this.ProchainNuméroDeCompte = maximum + 1;
            this.Nom = nom;
        }

        [JsonIgnore]
        public int ProchainNuméroDeCompte { get; set; }

        [JsonIgnore]
        public decimal ActifTotal
            => this.comptes.Sum(compte => compte.MontantTotal);

        [JsonIgnore]
        public decimal ActifGelé
            => this.comptes.Where(compte => compte.État == ÉtatDuCompte.Gelé)
                .Sum(compte => compte.MontantTotal);

        [JsonIgnore]
        public int NbComptes
            => this.comptes.Count;

        [JsonIgnore]
        public int NbActifs
            => this.comptes.Count(compte => compte.État == ÉtatDuCompte.Actif);

        [JsonIgnore]
        public int NbGelés
            => this.comptes.Count(compte => compte.État == ÉtatDuCompte.Gelé);

        [JsonIgnore]
        public int NbFermés
            => this.comptes.Count(compte => compte.État == ÉtatDuCompte.Fermé);

        public Compte3 OuvrirCompte(string nom, decimal miseDeFond = 0)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentException("null ou blanc", nameof(nom));
            }

            if (miseDeFond < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(miseDeFond), miseDeFond, "trop petit");
            }

            var nouveauCompte = new Compte3(this.ProchainNuméroDeCompte, nom, miseDeFond);
            this.comptes.Add(nouveauCompte);
            this.ProchainNuméroDeCompte++;

            Historique.Instance.Add($"[{this.Nom}] Ouvrir #{nouveauCompte.Numéro} avec {miseDeFond:C}");

            return nouveauCompte;
        }

        public Compte3 DétruireCompte(int noCompte)
        {
            var listeComptes = this.Comptes.Where(compte => compte.Numéro == noCompte).ToList();

            if (!listeComptes.Any())
            {
                throw new ArgumentException("compte inexistant");
            }


            if (listeComptes.First().État != ÉtatDuCompte.Fermé)
            {
                throw new InvalidOperationException("pas fermé.");
            }

            _ = this.comptes.Remove(listeComptes.First());

            Historique.Instance.Add($"> Détruire #{noCompte}");

            return listeComptes.First();
        }

        public decimal VerserIntérêts(decimal pourcentage, out int nbComptes)
        {
            var comptesAdmissible = this.Comptes
                .Where(compte => compte.État != ÉtatDuCompte.Fermé && compte.MontantTotal > 0)
                .ToList();

            var comptesInterets = comptesAdmissible
                .Select(compte => compte.VerserIntérêts(pourcentage, false))
                .Sum();

            Historique.Instance.Add($"[{Nom}] Verser {comptesInterets:C}");

            nbComptes = comptesAdmissible.Count;

            return comptesInterets;
        }
    }
}
