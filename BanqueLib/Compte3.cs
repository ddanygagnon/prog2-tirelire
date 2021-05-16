using System;
using System.Text.Json.Serialization;

using TirelireLib;

namespace BanqueLib
{
    public class Compte3 : Compte2
    {
        [JsonConstructor]
        public Compte3(int numéro, string titulaire, decimal montantTotal = 0, ÉtatDuCompte état = ÉtatDuCompte.Actif) : base(numéro, titulaire, montantTotal, état)
        {
        }

        public Compte3(Compte2 compte2) : base(compte2)
        {
        }

        public decimal VerserIntérêts(decimal pourcentage, bool ajouterHistorique = true)
        {

            if (pourcentage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pourcentage), pourcentage, "trop petit");
            }

            if (this.État == ÉtatDuCompte.Fermé)
            {
                throw new InvalidOperationException("Impossible de verser des intérêts dans un compte fermé");
            }
            var montant = Math.Round(this.MontantTotal * (pourcentage / 100), 2);
            this.MontantTotal += montant;
            if (ajouterHistorique)
            {
                Historique.Instance.Add($"> Verser {montant}");
            }

            return montant;
        }

        public void Geler()
        {
            if (this.État == ÉtatDuCompte.Gelé)
            {
                throw new InvalidOperationException("Impossible de geler car le compte n'est pas actif");
            }
            Historique.Instance.Add($"> Geler");

            this.État = ÉtatDuCompte.Gelé;
        }
    }
}
