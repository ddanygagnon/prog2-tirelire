using System;
using System.Text.Json.Serialization;

using TirelireLib;

namespace BanqueLib
{
    public class Compte2 : Compte1
    {
        public ÉtatDuCompte État { get; set; }

        [JsonConstructor]
        public Compte2(int numéro, string titulaire, decimal montantTotal = 0, ÉtatDuCompte état = ÉtatDuCompte.Actif) : base(numéro, titulaire, montantTotal)
        {
            if (état == ÉtatDuCompte.Fermé && montantTotal != 0)
            {
                throw new ArgumentException("Un état fermé est incompatible avec un solde non nul.", nameof(état));
            }
            this.État = état;
        }

        public Compte2(Compte2 compte2) : base(compte2)
        {
            this.Numéro = compte2.Numéro;
            this.Titulaire = compte2.Titulaire;
            this.MontantTotal = compte2.MontantTotal;
            this.État = compte2.État;
        }

        public override void Déposer(decimal montant)
        {
            if (this.État != ÉtatDuCompte.Actif)
            {
                throw new InvalidOperationException("Impossible de déposer car le compte n'est pas actif.");
            }
            base.Déposer(montant);
        }

        public override void Retirer(decimal montant)
        {
            if (this.État != ÉtatDuCompte.Actif)
            {
                throw new InvalidOperationException("Impossible de retirer car le compte n'est pas actif.");
            }
            base.Retirer(montant);
        }

        public override decimal Vider()
        {
            if (this.État != ÉtatDuCompte.Actif)
            {
                throw new InvalidOperationException("Impossible de vider car le compte n'est pas actif.");
            }
            return base.Vider();
        }

        public decimal Fermer()
        {
            if (this.État == ÉtatDuCompte.Fermé)
            {
                throw new InvalidOperationException("Impossible de fermer un compte déjà fermé.");
            }
            this.État = ÉtatDuCompte.Fermé;
            var montantRestant = this.MontantTotal;
            this.MontantTotal = 0;

            Historique.Instance.Add($"> Fermer {montantRestant}");

            return montantRestant;
        }

        public void Réactiver()
        {
            if (this.État == ÉtatDuCompte.Actif)
            {
                throw new InvalidOperationException("Impossible de réactiver un compte déjà actif.");
            }
            Historique.Instance.Add($"> Réactiver");

            this.État = ÉtatDuCompte.Actif;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.État}";
        }

        public override bool Equals(object obj)
            => obj is Compte2 c2
               && c2.État == this.État
               && base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
