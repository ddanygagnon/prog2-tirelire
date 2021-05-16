using System;
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

            this.banque = Instances.MesInstances.BanqueJedi;

            this.CreationListeViewColonne();
            this.lblActifsTotal.Text = this.banque.ActifTotal.ToString("C");
            this.lblActifsGele.Text = this.banque.ActifGelé.ToString("C");
            this.lblNbComptes.Text = $"Nombre de comptes: {this.banque.NbComptes}";
            this.lblNbActifs.Text = $"Comptes actifs: {this.banque.NbActifs}";
            this.lblNbGeles.Text = $"Comptes gelés: {this.banque.NbGelés}";
            this.lblNbFermes.Text = $"Comptes fermés: {this.banque.NbFermés}";

        }

        private void CreationListeViewColonne()
        {
            this.listViewBanqueComptes.View = View.Details;
            this.listViewBanqueComptes.Columns.Add("No", 100);
            this.listViewBanqueComptes.Columns.Add("Titulaire", 300);
            this.listViewBanqueComptes.Columns.Add("État", 200);
            this.listViewBanqueComptes.Columns.Add("Solde", 200);

            var item = new ListViewItem();

        }

        private void btnVerserInterets_Click(object sender, EventArgs e)
        {

        }
    }
}
