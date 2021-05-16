using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using BanqueLib;

using TPConsole;

namespace TPWinforms
{
    public partial class FormPrincipale : Form
    {
        private readonly Banque banque;

        public FormPrincipale()
        {
            this.InitializeComponent();

            this.banque = Instances.MesInstances.BanqueJedi;

            this.nmrMiseFond.Maximum = decimal.MaxValue;

            this.Update();
            this.CreationListeViewColonne();
        }

        private void CreationListeViewColonne()
        {
            this.listViewBanqueComptes.View = View.Details;
            this.listViewBanqueComptes.Columns.Add("No", 100);
            this.listViewBanqueComptes.Columns.Add("Titulaire", 300);
            this.listViewBanqueComptes.Columns.Add("État", 200);
            this.listViewBanqueComptes.Columns.Add("Solde", 200);
        }

        private void Update()
        {
            this.UpdateLabels();
            this.UpdateItems();
        }

        private void UpdateLabels()
        {
            this.lblActifsTotal.Text = this.banque.ActifTotal.ToString("C");
            this.lblActifsGele.Text = this.banque.ActifGelé.ToString("C");
            this.lblNbComptes.Text = $"Nombre de comptes: {this.banque.NbComptes}";
            this.lblNbActifs.Text = $"Comptes actifs: {this.banque.NbActifs}";
            this.lblNbGeles.Text = $"Comptes gelés: {this.banque.NbGelés}";
            this.lblNbFermes.Text = $"Comptes fermés: {this.banque.NbFermés}";
        }

        private void UpdateItems()
        {
            this.listViewBanqueComptes.Items.Clear();
            var comptes = this.banque.Comptes;
            foreach (var compte in comptes)
            {
                var items = new ListViewItem(compte.Numéro.ToString());
                items.SubItems.Add(compte.Titulaire);
                items.SubItems.Add(Enum.GetName(compte.État));
                items.SubItems.Add(compte.MontantTotal.ToString("C"));
                this.listViewBanqueComptes.Items.Add(items);
            }
        }

        private void btnVerserInterets_Click(object sender, EventArgs e)
        {
            this.banque.VerserIntérêts(2, out int _);
            this.Update();
        }

        private void btnAjouterCompte_Click(object sender, EventArgs e)
        {
            var titulaire = this.txtNomTitulaire.Text;
            var miseFond = this.nmrMiseFond.Value;

            if (string.IsNullOrWhiteSpace(titulaire))
            {
                MessageBox.Show(
                    "Le nom du titulaire ne peut pas être vide.",
                    "Titulaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2
                );
                return;
            }

            _ = this.banque.OuvrirCompte(titulaire, miseFond);
            this.Update();
        }
    }
}
