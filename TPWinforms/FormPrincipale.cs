using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using BanqueLib;

using TPConsole;

namespace TPWinforms
{
    public partial class FormPrincipale : Form
    {
        private Banque banque;

        public FormPrincipale()
        {
            this.InitializeComponent();
            Persistance.Charger();

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

        private new void Update()
        {
            this.banque = Instances.MesInstances.BanqueJedi;

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
            this.txtNomTitulaire.Text = string.Empty;
            this.nmrMiseFond.Value = 0;

            this.Update();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var reponse = MessageBox.Show(
                $"Voulez-vous vraiment remettre à zéro la banque {this.banque.Nom}, pour retrouver les comptes initiaux ?",
                $"Remettre à zéro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (reponse != DialogResult.Yes)
            {
                return;
            }

            Instances.MesInstances = new Instances();

            this.Update();
        }

        private void btnSupprimerCompte_Click(object sender, EventArgs e)
        {
            var noCompte = this.listViewBanqueComptes.SelectedItems[0].Text;
            var reponse = MessageBox.Show(
            $"Voulez-vous vraiment supprimer le compte no. {noCompte} ?",
            $"Supprimer {this.listViewBanqueComptes.SelectedItems[0].SubItems[1].Text}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (reponse != DialogResult.Yes)
            {
                return;
            }

            this.banque.DétruireCompte(Convert.ToInt32(noCompte));

            this.ToggleSupprimerBtn(this.btnSupprimerCompte, false);
            this.Update();
        }

        private void listViewBanqueComptes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var estFermes = e.Item.SubItems[2].Text.Contains("Fermé");
            Console.WriteLine(e.Item.SubItems[2].Text);
            this.ToggleSupprimerBtn(this.btnSupprimerCompte, this.listViewBanqueComptes.SelectedItems.Count != 0 && estFermes);
        }

        private void ToggleSupprimerBtn(Button button, bool state)
        {
            button.Enabled = state;

            var backColor = Color.FromArgb(255, 227, 227);
            var foreColor = Color.FromArgb(171, 9, 30);

            var disabledBackColor = Color.FromArgb(200, 240, 244, 248);
            var disabledForeColor = Color.FromArgb(100, 159, 179, 200);

            button.BackColor = state ? backColor : disabledBackColor;
            button.ForeColor = state ? foreColor : disabledForeColor;
        }

        private void FormPrincipale_FormClosed(object sender, FormClosedEventArgs e) => Persistance.Sauvegarder();
    }
}
