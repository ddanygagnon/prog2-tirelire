using System;
using System.Text.Json.Serialization;

using TirelireLib;

namespace BanqueLib
{
    public class Compte1 : Tirelire9
    {
        public int Numéro { get; set; }
        public string Titulaire { get; set; }

        public Compte1(Compte1 compte1)
        {
            this.Numéro = compte1.Numéro;
            this.Titulaire = compte1.Titulaire;
            this.MontantTotal = compte1.MontantTotal;
        }

        [JsonConstructor]
        public Compte1(int numéro, string titulaire, decimal montantTotal = 0)
        {
            if (numéro <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numéro), numéro, "trop petit");
            }

            if (string.IsNullOrWhiteSpace(titulaire))
            {
                throw new ArgumentException("null ou blanc", nameof(titulaire));
            }

            if (montantTotal < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montantTotal), montantTotal, "trop petit");
            }

            if (Math.Round(montantTotal, 2) != montantTotal)
            {
                throw new ArgumentException("trop précis", nameof(montantTotal));
            }

            this.Numéro = numéro;
            this.Titulaire = titulaire;
            this.MontantTotal = montantTotal;
        }

        public override string ToString()
        {
            return $"{this.Titulaire} {this.Numéro} {this.MontantTotal:C}";
        }

        public override bool Equals(object obj)
            => obj is Compte1 a
               && a.Numéro == this.Numéro
               && a.Titulaire == this.Titulaire
               && a.MontantTotal == this.MontantTotal;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
