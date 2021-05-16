
namespace TPWinforms
{
    partial class FormPrincipale
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNomBanque = new System.Windows.Forms.Label();
            this.listViewBanqueComptes = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActifsTotal = new System.Windows.Forms.Label();
            this.lblActifsGele = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblNbComptes = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNbActifs = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNbGeles = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNbFermes = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAjouterCompte = new System.Windows.Forms.Button();
            this.btnVerserInterets = new System.Windows.Forms.Button();
            this.btnSupprimerCompte = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNomTitulaire = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmrMiseFond = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMiseFond)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomBanque
            // 
            this.lblNomBanque.Font = new System.Drawing.Font("Helvetica LT Std", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNomBanque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.lblNomBanque.Location = new System.Drawing.Point(51, 57);
            this.lblNomBanque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomBanque.Name = "lblNomBanque";
            this.lblNomBanque.Size = new System.Drawing.Size(184, 85);
            this.lblNomBanque.TabIndex = 0;
            this.lblNomBanque.Text = "Jedi";
            // 
            // listViewBanqueComptes
            // 
            this.listViewBanqueComptes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBanqueComptes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.listViewBanqueComptes.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewBanqueComptes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.listViewBanqueComptes.FullRowSelect = true;
            this.listViewBanqueComptes.GridLines = true;
            this.listViewBanqueComptes.HideSelection = false;
            this.listViewBanqueComptes.Location = new System.Drawing.Point(51, 373);
            this.listViewBanqueComptes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listViewBanqueComptes.MultiSelect = false;
            this.listViewBanqueComptes.Name = "listViewBanqueComptes";
            this.listViewBanqueComptes.Size = new System.Drawing.Size(816, 335);
            this.listViewBanqueComptes.TabIndex = 1;
            this.listViewBanqueComptes.UseCompatibleStateImageBehavior = false;
            this.listViewBanqueComptes.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewBanqueComptes_ItemSelectionChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.label2.Location = new System.Drawing.Point(31, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.label3.Location = new System.Drawing.Point(31, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gelé";
            // 
            // lblActifsTotal
            // 
            this.lblActifsTotal.Font = new System.Drawing.Font("Helvetica LT Std", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActifsTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.lblActifsTotal.Location = new System.Drawing.Point(93, 27);
            this.lblActifsTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActifsTotal.Name = "lblActifsTotal";
            this.lblActifsTotal.Size = new System.Drawing.Size(203, 29);
            this.lblActifsTotal.TabIndex = 4;
            this.lblActifsTotal.Text = "0,00 $";
            // 
            // lblActifsGele
            // 
            this.lblActifsGele.Font = new System.Drawing.Font("Helvetica LT Std", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActifsGele.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.lblActifsGele.Location = new System.Drawing.Point(93, 73);
            this.lblActifsGele.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActifsGele.Name = "lblActifsGele";
            this.lblActifsGele.Size = new System.Drawing.Size(203, 29);
            this.lblActifsGele.TabIndex = 6;
            this.lblActifsGele.Text = "0,00 $";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblActifsTotal);
            this.groupBox1.Controls.Add(this.lblActifsGele);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.groupBox1.Location = new System.Drawing.Point(51, 163);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(322, 115);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actifs";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNbComptes,
            this.lblNbActifs,
            this.lblNbGeles,
            this.lblNbFermes});
            this.statusStrip.Location = new System.Drawing.Point(0, 755);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(915, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblNbComptes
            // 
            this.lblNbComptes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.lblNbComptes.Name = "lblNbComptes";
            this.lblNbComptes.Size = new System.Drawing.Size(128, 17);
            this.lblNbComptes.Text = "Nombre de comptes: 0";
            // 
            // lblNbActifs
            // 
            this.lblNbActifs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.lblNbActifs.Name = "lblNbActifs";
            this.lblNbActifs.Size = new System.Drawing.Size(98, 17);
            this.lblNbActifs.Text = "Comptes actifs: 0";
            // 
            // lblNbGeles
            // 
            this.lblNbGeles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.lblNbGeles.Name = "lblNbGeles";
            this.lblNbGeles.Size = new System.Drawing.Size(97, 17);
            this.lblNbGeles.Text = "Comptes gelés: 0";
            // 
            // lblNbFermes
            // 
            this.lblNbFermes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.lblNbFermes.Name = "lblNbFermes";
            this.lblNbFermes.Size = new System.Drawing.Size(106, 17);
            this.lblNbFermes.Text = "Comptes fermés: 0";
            // 
            // btnAjouterCompte
            // 
            this.btnAjouterCompte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouterCompte.AutoSize = true;
            this.btnAjouterCompte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(249)))), ((int)(((byte)(229)))));
            this.btnAjouterCompte.FlatAppearance.BorderSize = 0;
            this.btnAjouterCompte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(230)))), ((int)(((byte)(151)))));
            this.btnAjouterCompte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(242)))), ((int)(((byte)(199)))));
            this.btnAjouterCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterCompte.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAjouterCompte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(96)))), ((int)(((byte)(14)))));
            this.btnAjouterCompte.Location = new System.Drawing.Point(645, 309);
            this.btnAjouterCompte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAjouterCompte.Name = "btnAjouterCompte";
            this.btnAjouterCompte.Size = new System.Drawing.Size(224, 39);
            this.btnAjouterCompte.TabIndex = 9;
            this.btnAjouterCompte.Text = "Ajouter un compte";
            this.btnAjouterCompte.UseVisualStyleBackColor = false;
            this.btnAjouterCompte.Click += new System.EventHandler(this.btnAjouterCompte_Click);
            // 
            // btnVerserInterets
            // 
            this.btnVerserInterets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerserInterets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(234)))));
            this.btnVerserInterets.FlatAppearance.BorderSize = 0;
            this.btnVerserInterets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(229)))), ((int)(((byte)(136)))));
            this.btnVerserInterets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(196)))));
            this.btnVerserInterets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerserInterets.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVerserInterets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(110)))), ((int)(((byte)(23)))));
            this.btnVerserInterets.Location = new System.Drawing.Point(702, 79);
            this.btnVerserInterets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerserInterets.Name = "btnVerserInterets";
            this.btnVerserInterets.Size = new System.Drawing.Size(167, 39);
            this.btnVerserInterets.TabIndex = 10;
            this.btnVerserInterets.Text = "Verser intérêts (2%)\r\n";
            this.btnVerserInterets.UseVisualStyleBackColor = false;
            this.btnVerserInterets.Click += new System.EventHandler(this.btnVerserInterets_Click);
            // 
            // btnSupprimerCompte
            // 
            this.btnSupprimerCompte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSupprimerCompte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnSupprimerCompte.Enabled = false;
            this.btnSupprimerCompte.FlatAppearance.BorderSize = 0;
            this.btnSupprimerCompte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnSupprimerCompte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnSupprimerCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerCompte.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSupprimerCompte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.btnSupprimerCompte.Location = new System.Drawing.Point(51, 309);
            this.btnSupprimerCompte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSupprimerCompte.Name = "btnSupprimerCompte";
            this.btnSupprimerCompte.Size = new System.Drawing.Size(224, 39);
            this.btnSupprimerCompte.TabIndex = 11;
            this.btnSupprimerCompte.Text = "Supprimer le compte";
            this.btnSupprimerCompte.UseVisualStyleBackColor = false;
            this.btnSupprimerCompte.Click += new System.EventHandler(this.btnSupprimerCompte_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReset});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(915, 27);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemReset
            // 
            this.toolStripMenuItemReset.Checked = true;
            this.toolStripMenuItemReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripMenuItemReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.toolStripMenuItemReset.Name = "toolStripMenuItemReset";
            this.toolStripMenuItemReset.Size = new System.Drawing.Size(54, 23);
            this.toolStripMenuItemReset.Text = "Reset";
            this.toolStripMenuItemReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtNomTitulaire
            // 
            this.txtNomTitulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtNomTitulaire.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNomTitulaire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.txtNomTitulaire.Location = new System.Drawing.Point(180, 35);
            this.txtNomTitulaire.Name = "txtNomTitulaire";
            this.txtNomTitulaire.Size = new System.Drawing.Size(258, 27);
            this.txtNomTitulaire.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.label4.Location = new System.Drawing.Point(27, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nom du titulaire";
            // 
            // nmrMiseFond
            // 
            this.nmrMiseFond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.nmrMiseFond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmrMiseFond.DecimalPlaces = 2;
            this.nmrMiseFond.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nmrMiseFond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.nmrMiseFond.Location = new System.Drawing.Point(180, 87);
            this.nmrMiseFond.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nmrMiseFond.Name = "nmrMiseFond";
            this.nmrMiseFond.Size = new System.Drawing.Size(258, 27);
            this.nmrMiseFond.TabIndex = 16;
            this.nmrMiseFond.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.label5.Location = new System.Drawing.Point(48, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Mise de fond";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNomTitulaire);
            this.groupBox2.Controls.Add(this.nmrMiseFond);
            this.groupBox2.Font = new System.Drawing.Font("Helvetica LT Std", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.groupBox2.Location = new System.Drawing.Point(407, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 144);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajouter";
            // 
            // FormPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 777);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSupprimerCompte);
            this.Controls.Add(this.btnVerserInterets);
            this.Controls.Add(this.btnAjouterCompte);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewBanqueComptes);
            this.Controls.Add(this.lblNomBanque);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(912, 571);
            this.Name = "FormPrincipale";
            this.Text = "Dany Gagnon";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMiseFond)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSupprimerCompte;

        private System.Windows.Forms.Button btnVerserInterets;

        private System.Windows.Forms.ListView listViewBanqueComptes;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReset;
        private System.Windows.Forms.MenuStrip menuStrip;


        private System.Windows.Forms.Button btnAjouterCompte;

        private System.Windows.Forms.ToolStripStatusLabel lblNbComptes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbActifs;
        private System.Windows.Forms.ToolStripStatusLabel lvlNbGeles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbFermes;

        private System.Windows.Forms.StatusStrip statusStrip;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label lblActifsGele;

        private System.Windows.Forms.Label lblActifsTotal;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label lblNomBanque;

        #endregion

        private System.Windows.Forms.TextBox txtNomTitulaire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmrMiseFond;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel lblNbActifs;
        private System.Windows.Forms.ToolStripStatusLabel lblNbGeles;
        private System.Windows.Forms.ToolStripStatusLabel lblNbFermes;
    }
}

