namespace FranceInformatiqueInventaire
{
    partial class FormGestion
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestion));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            testToolStripMenuItem = new ToolStripMenuItem();
            TSMenuItem_Fichier_Nouveau = new ToolStripMenuItem();
            TSMenuItem_Fichier_Ouvrir = new ToolStripMenuItem();
            TSMenuItem_Fichier_Sauvegarder = new ToolStripMenuItem();
            TSMenuItem_Fichier_SauvegarderSous = new ToolStripMenuItem();
            préférencesToolStripMenuItem = new ToolStripMenuItem();
            TSMenuItem_Preferences_InsertionLigne = new ToolStripMenuItem();
            TSMenuItem_Preferences_InsertionLigne_Cb = new ToolStripComboBox();
            TSMenuItem_Preferences_ConfirmationSuppression = new ToolStripMenuItem();
            TSMenuItem_Preferences_ConfirmationVider = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            TSMenuItem_Preferences_Theme = new ToolStripMenuItem();
            TSMenuItem_Preferences_Theme_CouleurP = new ToolStripMenuItem();
            TSMenuItem_Preferences_Theme_CouleurS = new ToolStripMenuItem();
            TSMenuItem_Preferences_Theme_CouleurT = new ToolStripMenuItem();
            lbl_RechercheInventaire = new Label();
            txt_Recherche = new TextBox();
            tlp_Bas = new TableLayoutPanel();
            tlp_Haut = new TableLayoutPanel();
            cb_FiltreRecherche = new ComboBox();
            lbl_Filtre = new Label();
            ts_Inventaire = new ToolStrip();
            btn_AjouterLigne = new ToolStripButton();
            btn_SupprimerLigne = new ToolStripButton();
            btn_ViderLigne = new ToolStripButton();
            btn_InsererLigne = new ToolStripButton();
            btn_CopierLigne = new ToolStripButton();
            btn_CouperLigne = new ToolStripButton();
            btn_CollerLigne = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btn_Sauvegarder = new ToolStripButton();
            btn_SauvegarderSous = new ToolStripButton();
            tlp_Main = new TableLayoutPanel();
            tlp_Millieu = new TableLayoutPanel();
            tabControl_Onglets = new TabControl();
            OngletTableauDeBord = new TabPage();
            tableLayoutPanel9 = new TableLayoutPanel();
            tableLayoutPanel_TabBord = new TableLayoutPanel();
            tableLayoutPanel_TabBord2 = new TableLayoutPanel();
            tableLayoutPanel15 = new TableLayoutPanel();
            chart_Inventaire = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel16 = new TableLayoutPanel();
            lbl_ValeurInventaire = new Label();
            label45 = new Label();
            tableLayoutPanel19 = new TableLayoutPanel();
            btn_ReculerPeriodeInventaire = new Button();
            btn_AvancerPeriodeInventaire = new Button();
            tableLayoutPanel12 = new TableLayoutPanel();
            tableLayoutPanel13 = new TableLayoutPanel();
            chart_Facture = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel14 = new TableLayoutPanel();
            lbl_RevenuTTCFactures = new Label();
            label3 = new Label();
            tableLayoutPanel20 = new TableLayoutPanel();
            btn_ReculerPeriodeFacture = new Button();
            btn_AvancerPeriodeFacture = new Button();
            tableLayoutPanel17 = new TableLayoutPanel();
            chartDonut_Marque = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel18 = new TableLayoutPanel();
            label7 = new Label();
            cb_Periode = new ComboBox();
            chartDonut_Type = new System.Windows.Forms.DataVisualization.Charting.Chart();
            OngletInventaire = new TabPage();
            tabControl_Inventaire = new TabControl();
            tab_Inventaire = new TabPage();
            dgv_Inventaire = new DataGridView();
            IndexInventaire = new DataGridViewTextBoxColumn();
            TypeInventaire = new DataGridViewComboBoxColumn();
            MarqueInventaire = new DataGridViewComboBoxColumn();
            NomInventaire = new DataGridViewTextBoxColumn();
            AnneeInventaire = new DataGridViewTextBoxColumn();
            PrixInventaire = new DataGridViewTextBoxColumn();
            QuantiteInventaire = new DataGridViewTextBoxColumn();
            DateEntreeInventaire = new DataGridViewTextBoxColumn();
            DateSortieInventaire = new DataGridViewTextBoxColumn();
            CommentaireInventaire = new DataGridViewTextBoxColumn();
            tab_Marque = new TabPage();
            tlp_MarqueMain = new TableLayoutPanel();
            lb_Marque = new ListBox();
            tlp_GererMarque = new TableLayoutPanel();
            txt_AjoutMarque = new TextBox();
            btn_SupprimerMarque = new Button();
            btn_AjouterMarque = new Button();
            tab_Type = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            lb_Type = new ListBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            txt_AjoutType = new TextBox();
            btn_SupprimerType = new Button();
            btn_AjouterType = new Button();
            OngletFactureNette = new TabPage();
            tabControl_Facture = new TabControl();
            TabFactures = new TabPage();
            dgv_Facture = new DataGridView();
            IndexFacture = new DataGridViewTextBoxColumn();
            NomFacture = new DataGridViewTextBoxColumn();
            PrestationFacture = new DataGridViewComboBoxColumn();
            DateFacture = new DataGridViewTextBoxColumn();
            CommentaireFacture = new DataGridViewTextBoxColumn();
            PrixHT = new DataGridViewTextBoxColumn();
            PrixTTC = new DataGridViewTextBoxColumn();
            Difference = new DataGridViewTextBoxColumn();
            tabPrestation = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            lb_Prestation = new ListBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            txt_AjoutPrestationNom = new TextBox();
            btn_SupprimerPrestation = new Button();
            btn_AjoutPrestation = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            label1 = new Label();
            nupd_AjoutPourcentageTVA = new NumericUpDown();
            label2 = new Label();
            OngletSitesFavoris = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            lb_SitesFav = new ListBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btn_AccederSiteWeb = new Button();
            txt_AjoutSiteWebUrl = new TextBox();
            btn_AjouterSiteWeb = new Button();
            txt_AjoutSiteWebNom = new TextBox();
            btn_SupprimerSiteWeb = new Button();
            inventaireMarqueBindingSource1 = new BindingSource(components);
            inventaireMarqueBindingSource = new BindingSource(components);
            tableLayoutPrincipal = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label_CopyrightVersion = new Label();
            colorDialog1 = new ColorDialog();
            menuStrip1.SuspendLayout();
            tlp_Haut.SuspendLayout();
            ts_Inventaire.SuspendLayout();
            tlp_Main.SuspendLayout();
            tlp_Millieu.SuspendLayout();
            tabControl_Onglets.SuspendLayout();
            OngletTableauDeBord.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel_TabBord.SuspendLayout();
            tableLayoutPanel_TabBord2.SuspendLayout();
            tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart_Inventaire).BeginInit();
            tableLayoutPanel16.SuspendLayout();
            tableLayoutPanel19.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart_Facture).BeginInit();
            tableLayoutPanel14.SuspendLayout();
            tableLayoutPanel20.SuspendLayout();
            tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDonut_Marque).BeginInit();
            tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDonut_Type).BeginInit();
            OngletInventaire.SuspendLayout();
            tabControl_Inventaire.SuspendLayout();
            tab_Inventaire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Inventaire).BeginInit();
            tab_Marque.SuspendLayout();
            tlp_MarqueMain.SuspendLayout();
            tlp_GererMarque.SuspendLayout();
            tab_Type.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            OngletFactureNette.SuspendLayout();
            tabControl_Facture.SuspendLayout();
            TabFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Facture).BeginInit();
            tabPrestation.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupd_AjoutPourcentageTVA).BeginInit();
            OngletSitesFavoris.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inventaireMarqueBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inventaireMarqueBindingSource).BeginInit();
            tableLayoutPrincipal.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(73, 82, 97);
            menuStrip1.Items.AddRange(new ToolStripItem[] { testToolStripMenuItem, préférencesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1200, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.MouseClick += menuStrip1_MouseClick;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TSMenuItem_Fichier_Nouveau, TSMenuItem_Fichier_Ouvrir, TSMenuItem_Fichier_Sauvegarder, TSMenuItem_Fichier_SauvegarderSous });
            testToolStripMenuItem.ForeColor = SystemColors.Control;
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(54, 20);
            testToolStripMenuItem.Text = "Fichier";
            // 
            // TSMenuItem_Fichier_Nouveau
            // 
            TSMenuItem_Fichier_Nouveau.Name = "TSMenuItem_Fichier_Nouveau";
            TSMenuItem_Fichier_Nouveau.Size = new Size(166, 22);
            TSMenuItem_Fichier_Nouveau.Text = "Nouveau";
            TSMenuItem_Fichier_Nouveau.Click += TSMenuItem_Fichier_Nouveau_Click;
            // 
            // TSMenuItem_Fichier_Ouvrir
            // 
            TSMenuItem_Fichier_Ouvrir.Name = "TSMenuItem_Fichier_Ouvrir";
            TSMenuItem_Fichier_Ouvrir.Size = new Size(166, 22);
            TSMenuItem_Fichier_Ouvrir.Text = "Ouvrir";
            TSMenuItem_Fichier_Ouvrir.Click += TSMenuItem_Fichier_Ouvrir_Click;
            // 
            // TSMenuItem_Fichier_Sauvegarder
            // 
            TSMenuItem_Fichier_Sauvegarder.Enabled = false;
            TSMenuItem_Fichier_Sauvegarder.Name = "TSMenuItem_Fichier_Sauvegarder";
            TSMenuItem_Fichier_Sauvegarder.Size = new Size(166, 22);
            TSMenuItem_Fichier_Sauvegarder.Text = "Sauvegarder";
            TSMenuItem_Fichier_Sauvegarder.Click += TSMenuItem_Fichier_Sauvegarder_Click;
            // 
            // TSMenuItem_Fichier_SauvegarderSous
            // 
            TSMenuItem_Fichier_SauvegarderSous.Name = "TSMenuItem_Fichier_SauvegarderSous";
            TSMenuItem_Fichier_SauvegarderSous.Size = new Size(166, 22);
            TSMenuItem_Fichier_SauvegarderSous.Text = "Sauvegarder sous";
            TSMenuItem_Fichier_SauvegarderSous.Click += TSMenuItem_Fichier_SauvegarderSous_Click;
            // 
            // préférencesToolStripMenuItem
            // 
            préférencesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TSMenuItem_Preferences_InsertionLigne, TSMenuItem_Preferences_ConfirmationSuppression, TSMenuItem_Preferences_ConfirmationVider, toolStripSeparator1, TSMenuItem_Preferences_Theme });
            préférencesToolStripMenuItem.ForeColor = SystemColors.Control;
            préférencesToolStripMenuItem.Name = "préférencesToolStripMenuItem";
            préférencesToolStripMenuItem.Size = new Size(80, 20);
            préférencesToolStripMenuItem.Text = "Préférences";
            // 
            // TSMenuItem_Preferences_InsertionLigne
            // 
            TSMenuItem_Preferences_InsertionLigne.DropDownItems.AddRange(new ToolStripItem[] { TSMenuItem_Preferences_InsertionLigne_Cb });
            TSMenuItem_Preferences_InsertionLigne.Name = "TSMenuItem_Preferences_InsertionLigne";
            TSMenuItem_Preferences_InsertionLigne.Size = new Size(288, 22);
            TSMenuItem_Preferences_InsertionLigne.Text = "Insertion de ligne";
            // 
            // TSMenuItem_Preferences_InsertionLigne_Cb
            // 
            TSMenuItem_Preferences_InsertionLigne_Cb.DropDownStyle = ComboBoxStyle.DropDownList;
            TSMenuItem_Preferences_InsertionLigne_Cb.FlatStyle = FlatStyle.Standard;
            TSMenuItem_Preferences_InsertionLigne_Cb.Items.AddRange(new object[] { "Avant la ligne", "Après la ligne" });
            TSMenuItem_Preferences_InsertionLigne_Cb.Name = "TSMenuItem_Preferences_InsertionLigne_Cb";
            TSMenuItem_Preferences_InsertionLigne_Cb.Size = new Size(121, 23);
            TSMenuItem_Preferences_InsertionLigne_Cb.SelectedIndexChanged += TSMenuItem_Preferences_InsertionLigne_Cb_SelectedIndexChanged;
            // 
            // TSMenuItem_Preferences_ConfirmationSuppression
            // 
            TSMenuItem_Preferences_ConfirmationSuppression.Checked = true;
            TSMenuItem_Preferences_ConfirmationSuppression.CheckOnClick = true;
            TSMenuItem_Preferences_ConfirmationSuppression.CheckState = CheckState.Checked;
            TSMenuItem_Preferences_ConfirmationSuppression.Name = "TSMenuItem_Preferences_ConfirmationSuppression";
            TSMenuItem_Preferences_ConfirmationSuppression.Size = new Size(288, 22);
            TSMenuItem_Preferences_ConfirmationSuppression.Text = "Confirmation avant suppression de ligne";
            TSMenuItem_Preferences_ConfirmationSuppression.CheckedChanged += rToolStripMenuItem_CheckedChanged;
            // 
            // TSMenuItem_Preferences_ConfirmationVider
            // 
            TSMenuItem_Preferences_ConfirmationVider.Checked = true;
            TSMenuItem_Preferences_ConfirmationVider.CheckOnClick = true;
            TSMenuItem_Preferences_ConfirmationVider.CheckState = CheckState.Checked;
            TSMenuItem_Preferences_ConfirmationVider.Name = "TSMenuItem_Preferences_ConfirmationVider";
            TSMenuItem_Preferences_ConfirmationVider.Size = new Size(288, 22);
            TSMenuItem_Preferences_ConfirmationVider.Text = "Confirmation avant vider ligne";
            TSMenuItem_Preferences_ConfirmationVider.CheckedChanged += TSMenuItem_Preferences_ConfirmationVider_CheckedChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(285, 6);
            // 
            // TSMenuItem_Preferences_Theme
            // 
            TSMenuItem_Preferences_Theme.AccessibleDescription = "Permet de choisir les couleurs du logiciel";
            TSMenuItem_Preferences_Theme.DropDownItems.AddRange(new ToolStripItem[] { TSMenuItem_Preferences_Theme_CouleurP, TSMenuItem_Preferences_Theme_CouleurS, TSMenuItem_Preferences_Theme_CouleurT });
            TSMenuItem_Preferences_Theme.Name = "TSMenuItem_Preferences_Theme";
            TSMenuItem_Preferences_Theme.Size = new Size(288, 22);
            TSMenuItem_Preferences_Theme.Text = "Thème";
            // 
            // TSMenuItem_Preferences_Theme_CouleurP
            // 
            TSMenuItem_Preferences_Theme_CouleurP.BackColor = SystemColors.Control;
            TSMenuItem_Preferences_Theme_CouleurP.ImageTransparentColor = Color.Transparent;
            TSMenuItem_Preferences_Theme_CouleurP.Name = "TSMenuItem_Preferences_Theme_CouleurP";
            TSMenuItem_Preferences_Theme_CouleurP.Size = new Size(176, 22);
            TSMenuItem_Preferences_Theme_CouleurP.Text = "Couleur primaire";
            TSMenuItem_Preferences_Theme_CouleurP.Click += TSMenuItem_Preferences_Theme_CouleurP_Click;
            // 
            // TSMenuItem_Preferences_Theme_CouleurS
            // 
            TSMenuItem_Preferences_Theme_CouleurS.Name = "TSMenuItem_Preferences_Theme_CouleurS";
            TSMenuItem_Preferences_Theme_CouleurS.Size = new Size(176, 22);
            TSMenuItem_Preferences_Theme_CouleurS.Text = "Couleur secondaire";
            TSMenuItem_Preferences_Theme_CouleurS.Click += TSMenuItem_Preferences_Theme_CouleurS_Click;
            // 
            // TSMenuItem_Preferences_Theme_CouleurT
            // 
            TSMenuItem_Preferences_Theme_CouleurT.Name = "TSMenuItem_Preferences_Theme_CouleurT";
            TSMenuItem_Preferences_Theme_CouleurT.Size = new Size(176, 22);
            TSMenuItem_Preferences_Theme_CouleurT.Text = "Couleur tertiaire";
            TSMenuItem_Preferences_Theme_CouleurT.Click += TSMenuItem_Preferences_Theme_CouleurT_Click;
            // 
            // lbl_RechercheInventaire
            // 
            lbl_RechercheInventaire.AutoSize = true;
            lbl_RechercheInventaire.Dock = DockStyle.Fill;
            lbl_RechercheInventaire.ForeColor = SystemColors.Control;
            lbl_RechercheInventaire.Location = new Point(611, 0);
            lbl_RechercheInventaire.Name = "lbl_RechercheInventaire";
            lbl_RechercheInventaire.Padding = new Padding(3);
            lbl_RechercheInventaire.Size = new Size(88, 29);
            lbl_RechercheInventaire.TabIndex = 7;
            lbl_RechercheInventaire.Text = "Recherche";
            lbl_RechercheInventaire.TextAlign = ContentAlignment.MiddleRight;
            lbl_RechercheInventaire.MouseClick += lbl_RechercheInventaire_MouseClick;
            // 
            // txt_Recherche
            // 
            txt_Recherche.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_Recherche.BackColor = SystemColors.Control;
            txt_Recherche.ForeColor = SystemColors.WindowText;
            txt_Recherche.Location = new Point(705, 3);
            txt_Recherche.Name = "txt_Recherche";
            txt_Recherche.PlaceholderText = "Rechercher dans l'inventaire";
            txt_Recherche.Size = new Size(222, 23);
            txt_Recherche.TabIndex = 6;
            txt_Recherche.TextChanged += txt_RechercheInventaire_TextChanged;
            // 
            // tlp_Bas
            // 
            tlp_Bas.ColumnCount = 2;
            tlp_Bas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Bas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Bas.Dock = DockStyle.Fill;
            tlp_Bas.Location = new Point(3, 533);
            tlp_Bas.Name = "tlp_Bas";
            tlp_Bas.RowCount = 1;
            tlp_Bas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Bas.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Bas.Size = new Size(1187, 1);
            tlp_Bas.TabIndex = 9;
            // 
            // tlp_Haut
            // 
            tlp_Haut.ColumnCount = 5;
            tlp_Haut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.22438F));
            tlp_Haut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.93651F));
            tlp_Haut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.26961F));
            tlp_Haut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.535149F));
            tlp_Haut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.03434F));
            tlp_Haut.Controls.Add(txt_Recherche, 2, 0);
            tlp_Haut.Controls.Add(lbl_RechercheInventaire, 1, 0);
            tlp_Haut.Controls.Add(cb_FiltreRecherche, 4, 0);
            tlp_Haut.Controls.Add(lbl_Filtre, 3, 0);
            tlp_Haut.Controls.Add(ts_Inventaire, 0, 0);
            tlp_Haut.Dock = DockStyle.Fill;
            tlp_Haut.Location = new Point(3, 3);
            tlp_Haut.Name = "tlp_Haut";
            tlp_Haut.RowCount = 1;
            tlp_Haut.RowStyles.Add(new RowStyle());
            tlp_Haut.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Haut.Size = new Size(1187, 29);
            tlp_Haut.TabIndex = 9;
            // 
            // cb_FiltreRecherche
            // 
            cb_FiltreRecherche.Dock = DockStyle.Fill;
            cb_FiltreRecherche.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_FiltreRecherche.FormattingEnabled = true;
            cb_FiltreRecherche.Items.AddRange(new object[] { "Pas de filtre" });
            cb_FiltreRecherche.Location = new Point(986, 3);
            cb_FiltreRecherche.Name = "cb_FiltreRecherche";
            cb_FiltreRecherche.Size = new Size(198, 23);
            cb_FiltreRecherche.TabIndex = 8;
            cb_FiltreRecherche.SelectedIndexChanged += cb_FiltreRecherche_SelectedIndexChanged;
            // 
            // lbl_Filtre
            // 
            lbl_Filtre.AutoSize = true;
            lbl_Filtre.Dock = DockStyle.Fill;
            lbl_Filtre.ForeColor = SystemColors.Control;
            lbl_Filtre.Location = new Point(933, 0);
            lbl_Filtre.Name = "lbl_Filtre";
            lbl_Filtre.Padding = new Padding(3);
            lbl_Filtre.Size = new Size(47, 29);
            lbl_Filtre.TabIndex = 9;
            lbl_Filtre.Text = "Filtre";
            lbl_Filtre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ts_Inventaire
            // 
            ts_Inventaire.BackColor = Color.FromArgb(73, 82, 97);
            ts_Inventaire.Dock = DockStyle.Fill;
            ts_Inventaire.Items.AddRange(new ToolStripItem[] { btn_AjouterLigne, btn_SupprimerLigne, btn_ViderLigne, btn_InsererLigne, btn_CopierLigne, btn_CouperLigne, btn_CollerLigne, toolStripSeparator2, btn_Sauvegarder, btn_SauvegarderSous });
            ts_Inventaire.Location = new Point(0, 0);
            ts_Inventaire.Name = "ts_Inventaire";
            ts_Inventaire.Size = new Size(608, 29);
            ts_Inventaire.TabIndex = 10;
            ts_Inventaire.Text = "toolStrip1";
            ts_Inventaire.MouseClick += ts_Inventaire_MouseClick;
            // 
            // btn_AjouterLigne
            // 
            btn_AjouterLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_AjouterLigne.Image = (Image)resources.GetObject("btn_AjouterLigne.Image");
            btn_AjouterLigne.ImageTransparentColor = Color.Magenta;
            btn_AjouterLigne.Name = "btn_AjouterLigne";
            btn_AjouterLigne.Size = new Size(23, 26);
            btn_AjouterLigne.Text = "Ajouter une ligne";
            btn_AjouterLigne.Click += btn_AjouterLigneInventaire_Click_1;
            // 
            // btn_SupprimerLigne
            // 
            btn_SupprimerLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_SupprimerLigne.Enabled = false;
            btn_SupprimerLigne.Image = Properties.Resources.Delete;
            btn_SupprimerLigne.ImageTransparentColor = Color.Magenta;
            btn_SupprimerLigne.Name = "btn_SupprimerLigne";
            btn_SupprimerLigne.Size = new Size(23, 26);
            btn_SupprimerLigne.Text = "Supprimer";
            btn_SupprimerLigne.Click += btn_SupprimerLigneInventaire_Click_1;
            // 
            // btn_ViderLigne
            // 
            btn_ViderLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_ViderLigne.Enabled = false;
            btn_ViderLigne.Image = Properties.Resources.Clear;
            btn_ViderLigne.ImageTransparentColor = Color.Magenta;
            btn_ViderLigne.Name = "btn_ViderLigne";
            btn_ViderLigne.Size = new Size(23, 26);
            btn_ViderLigne.Text = "Vider";
            btn_ViderLigne.Click += btn_ViderLigneInventaire_Click;
            // 
            // btn_InsererLigne
            // 
            btn_InsererLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_InsererLigne.Enabled = false;
            btn_InsererLigne.Image = Properties.Resources.Insert;
            btn_InsererLigne.ImageTransparentColor = Color.Magenta;
            btn_InsererLigne.Name = "btn_InsererLigne";
            btn_InsererLigne.Size = new Size(23, 26);
            btn_InsererLigne.Text = "Insérer une ligne";
            btn_InsererLigne.Click += btn_InsererLigneInventaire_Click;
            // 
            // btn_CopierLigne
            // 
            btn_CopierLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_CopierLigne.Enabled = false;
            btn_CopierLigne.Image = Properties.Resources.Copy1;
            btn_CopierLigne.ImageTransparentColor = Color.Magenta;
            btn_CopierLigne.Name = "btn_CopierLigne";
            btn_CopierLigne.Size = new Size(23, 26);
            btn_CopierLigne.Text = "Copier";
            btn_CopierLigne.Click += btn_CopierLigne_Click;
            // 
            // btn_CouperLigne
            // 
            btn_CouperLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_CouperLigne.Enabled = false;
            btn_CouperLigne.Image = Properties.Resources.Cut1;
            btn_CouperLigne.ImageTransparentColor = Color.Magenta;
            btn_CouperLigne.Name = "btn_CouperLigne";
            btn_CouperLigne.Size = new Size(23, 26);
            btn_CouperLigne.Text = "Couper";
            btn_CouperLigne.Click += btn_CouperLigneInventaire_Click;
            // 
            // btn_CollerLigne
            // 
            btn_CollerLigne.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_CollerLigne.Enabled = false;
            btn_CollerLigne.Image = Properties.Resources.Paste;
            btn_CollerLigne.ImageTransparentColor = Color.Magenta;
            btn_CollerLigne.Name = "btn_CollerLigne";
            btn_CollerLigne.Size = new Size(23, 26);
            btn_CollerLigne.Text = "Coller";
            btn_CollerLigne.Click += btn_CollerLigne_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 29);
            // 
            // btn_Sauvegarder
            // 
            btn_Sauvegarder.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_Sauvegarder.Enabled = false;
            btn_Sauvegarder.Image = Properties.Resources.Sauvegarder;
            btn_Sauvegarder.ImageTransparentColor = Color.Magenta;
            btn_Sauvegarder.Name = "btn_Sauvegarder";
            btn_Sauvegarder.Size = new Size(23, 26);
            btn_Sauvegarder.Text = "Sauvegarder";
            btn_Sauvegarder.Click += btn_Sauvegarder_Click;
            // 
            // btn_SauvegarderSous
            // 
            btn_SauvegarderSous.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_SauvegarderSous.Image = Properties.Resources.SauvegarderSous;
            btn_SauvegarderSous.ImageTransparentColor = Color.Magenta;
            btn_SauvegarderSous.Name = "btn_SauvegarderSous";
            btn_SauvegarderSous.Size = new Size(23, 26);
            btn_SauvegarderSous.Text = "Sauvegarder sous";
            btn_SauvegarderSous.Click += btn_SauvegarderSous_Click;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_Main.Controls.Add(tlp_Bas, 0, 2);
            tlp_Main.Controls.Add(tlp_Millieu, 0, 1);
            tlp_Main.Controls.Add(tlp_Haut, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 98.97683F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 1.023173F));
            tlp_Main.Size = new Size(1193, 536);
            tlp_Main.TabIndex = 10;
            tlp_Main.MouseClick += tlp_Main_MouseClick;
            // 
            // tlp_Millieu
            // 
            tlp_Millieu.ColumnCount = 1;
            tlp_Millieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Millieu.Controls.Add(tabControl_Onglets, 0, 0);
            tlp_Millieu.Dock = DockStyle.Fill;
            tlp_Millieu.Location = new Point(3, 38);
            tlp_Millieu.Name = "tlp_Millieu";
            tlp_Millieu.RowCount = 1;
            tlp_Millieu.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Millieu.Size = new Size(1187, 489);
            tlp_Millieu.TabIndex = 10;
            tlp_Millieu.MouseClick += tlp_Millieu_MouseClick;
            // 
            // tabControl_Onglets
            // 
            tabControl_Onglets.Controls.Add(OngletTableauDeBord);
            tabControl_Onglets.Controls.Add(OngletInventaire);
            tabControl_Onglets.Controls.Add(OngletFactureNette);
            tabControl_Onglets.Controls.Add(OngletSitesFavoris);
            tabControl_Onglets.Dock = DockStyle.Fill;
            tabControl_Onglets.Location = new Point(3, 3);
            tabControl_Onglets.Name = "tabControl_Onglets";
            tabControl_Onglets.SelectedIndex = 0;
            tabControl_Onglets.Size = new Size(1181, 483);
            tabControl_Onglets.TabIndex = 12;
            tabControl_Onglets.SelectedIndexChanged += tabControl_Onglets_SelectedIndexChanged;
            tabControl_Onglets.MouseClick += tabControl_Onglets_MouseClick;
            // 
            // OngletTableauDeBord
            // 
            OngletTableauDeBord.BackColor = Color.FromArgb(73, 82, 97);
            OngletTableauDeBord.Controls.Add(tableLayoutPanel9);
            OngletTableauDeBord.Location = new Point(4, 24);
            OngletTableauDeBord.Name = "OngletTableauDeBord";
            OngletTableauDeBord.Size = new Size(1173, 455);
            OngletTableauDeBord.TabIndex = 4;
            OngletTableauDeBord.Text = "Tableau de bord";
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.Controls.Add(tableLayoutPanel_TabBord, 0, 0);
            tableLayoutPanel9.Controls.Add(tableLayoutPanel17, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(1173, 455);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // tableLayoutPanel_TabBord
            // 
            tableLayoutPanel_TabBord.ColumnCount = 1;
            tableLayoutPanel_TabBord.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_TabBord.Controls.Add(tableLayoutPanel_TabBord2, 0, 0);
            tableLayoutPanel_TabBord.Controls.Add(tableLayoutPanel12, 0, 1);
            tableLayoutPanel_TabBord.Dock = DockStyle.Fill;
            tableLayoutPanel_TabBord.Location = new Point(3, 3);
            tableLayoutPanel_TabBord.Name = "tableLayoutPanel_TabBord";
            tableLayoutPanel_TabBord.RowCount = 2;
            tableLayoutPanel_TabBord.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_TabBord.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_TabBord.Size = new Size(873, 449);
            tableLayoutPanel_TabBord.TabIndex = 0;
            // 
            // tableLayoutPanel_TabBord2
            // 
            tableLayoutPanel_TabBord2.BackColor = Color.FromArgb(83, 92, 107);
            tableLayoutPanel_TabBord2.ColumnCount = 1;
            tableLayoutPanel_TabBord2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_TabBord2.Controls.Add(tableLayoutPanel15, 0, 0);
            tableLayoutPanel_TabBord2.Dock = DockStyle.Fill;
            tableLayoutPanel_TabBord2.Location = new Point(3, 3);
            tableLayoutPanel_TabBord2.Name = "tableLayoutPanel_TabBord2";
            tableLayoutPanel_TabBord2.RowCount = 1;
            tableLayoutPanel_TabBord2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_TabBord2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_TabBord2.Size = new Size(867, 218);
            tableLayoutPanel_TabBord2.TabIndex = 2;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.ColumnCount = 2;
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.3819618F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.6180344F));
            tableLayoutPanel15.Controls.Add(chart_Inventaire, 1, 0);
            tableLayoutPanel15.Controls.Add(tableLayoutPanel16, 0, 0);
            tableLayoutPanel15.Dock = DockStyle.Fill;
            tableLayoutPanel15.Location = new Point(3, 3);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel15.Size = new Size(861, 212);
            tableLayoutPanel15.TabIndex = 1;
            // 
            // chart_Inventaire
            // 
            chartArea1.Name = "ChartArea1";
            chart_Inventaire.ChartAreas.Add(chartArea1);
            chart_Inventaire.Dock = DockStyle.Fill;
            chart_Inventaire.Location = new Point(247, 3);
            chart_Inventaire.Name = "chart_Inventaire";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Valeur de l'inventaire";
            chart_Inventaire.Series.Add(series1);
            chart_Inventaire.Size = new Size(611, 206);
            chart_Inventaire.TabIndex = 0;
            chart_Inventaire.Text = "chart1";
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.ColumnCount = 1;
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel16.Controls.Add(lbl_ValeurInventaire, 0, 1);
            tableLayoutPanel16.Controls.Add(label45, 0, 0);
            tableLayoutPanel16.Controls.Add(tableLayoutPanel19, 0, 2);
            tableLayoutPanel16.Dock = DockStyle.Fill;
            tableLayoutPanel16.Location = new Point(3, 3);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 3;
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 25.5234127F));
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 56.71868F));
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 17.7579021F));
            tableLayoutPanel16.Size = new Size(238, 206);
            tableLayoutPanel16.TabIndex = 1;
            // 
            // lbl_ValeurInventaire
            // 
            lbl_ValeurInventaire.AutoSize = true;
            lbl_ValeurInventaire.Font = new Font("Segoe UI", 50F, FontStyle.Bold);
            lbl_ValeurInventaire.ForeColor = Color.White;
            lbl_ValeurInventaire.Location = new Point(3, 52);
            lbl_ValeurInventaire.Name = "lbl_ValeurInventaire";
            lbl_ValeurInventaire.Size = new Size(212, 116);
            lbl_ValeurInventaire.TabIndex = 1;
            lbl_ValeurInventaire.Text = "10 000 €";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label45.ForeColor = Color.White;
            label45.Location = new Point(3, 0);
            label45.Name = "label45";
            label45.Size = new Size(205, 21);
            label45.TabIndex = 0;
            label45.Text = "Valeur TTC de l'inventaire";
            // 
            // tableLayoutPanel19
            // 
            tableLayoutPanel19.ColumnCount = 2;
            tableLayoutPanel19.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel19.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel19.Controls.Add(btn_ReculerPeriodeInventaire, 0, 0);
            tableLayoutPanel19.Controls.Add(btn_AvancerPeriodeInventaire, 1, 0);
            tableLayoutPanel19.Dock = DockStyle.Fill;
            tableLayoutPanel19.Location = new Point(3, 171);
            tableLayoutPanel19.Name = "tableLayoutPanel19";
            tableLayoutPanel19.RowCount = 1;
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel19.Size = new Size(232, 32);
            tableLayoutPanel19.TabIndex = 2;
            // 
            // btn_ReculerPeriodeInventaire
            // 
            btn_ReculerPeriodeInventaire.BackColor = SystemColors.Control;
            btn_ReculerPeriodeInventaire.Dock = DockStyle.Fill;
            btn_ReculerPeriodeInventaire.ForeColor = Color.FromArgb(48, 50, 54);
            btn_ReculerPeriodeInventaire.Location = new Point(3, 3);
            btn_ReculerPeriodeInventaire.Name = "btn_ReculerPeriodeInventaire";
            btn_ReculerPeriodeInventaire.Size = new Size(110, 26);
            btn_ReculerPeriodeInventaire.TabIndex = 0;
            btn_ReculerPeriodeInventaire.Text = "Reculer d'un ";
            btn_ReculerPeriodeInventaire.UseVisualStyleBackColor = false;
            btn_ReculerPeriodeInventaire.Click += btn_ReculerPeriodeInventaire_Click;
            // 
            // btn_AvancerPeriodeInventaire
            // 
            btn_AvancerPeriodeInventaire.BackColor = SystemColors.Control;
            btn_AvancerPeriodeInventaire.Dock = DockStyle.Fill;
            btn_AvancerPeriodeInventaire.ForeColor = Color.FromArgb(48, 50, 54);
            btn_AvancerPeriodeInventaire.Location = new Point(119, 3);
            btn_AvancerPeriodeInventaire.Name = "btn_AvancerPeriodeInventaire";
            btn_AvancerPeriodeInventaire.Size = new Size(110, 26);
            btn_AvancerPeriodeInventaire.TabIndex = 1;
            btn_AvancerPeriodeInventaire.Text = "Avancer d'un ";
            btn_AvancerPeriodeInventaire.UseVisualStyleBackColor = false;
            btn_AvancerPeriodeInventaire.Click += btn_AvancerPeriodeInventaire_Click;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.BackColor = Color.FromArgb(83, 92, 107);
            tableLayoutPanel12.ColumnCount = 1;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Controls.Add(tableLayoutPanel13, 0, 0);
            tableLayoutPanel12.Dock = DockStyle.Fill;
            tableLayoutPanel12.Location = new Point(3, 227);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel12.Size = new Size(867, 219);
            tableLayoutPanel12.TabIndex = 1;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.3819637F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.6180344F));
            tableLayoutPanel13.Controls.Add(chart_Facture, 1, 0);
            tableLayoutPanel13.Controls.Add(tableLayoutPanel14, 0, 0);
            tableLayoutPanel13.Dock = DockStyle.Fill;
            tableLayoutPanel13.Location = new Point(3, 3);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Size = new Size(861, 213);
            tableLayoutPanel13.TabIndex = 1;
            // 
            // chart_Facture
            // 
            chartArea2.Name = "ChartArea1";
            chart_Facture.ChartAreas.Add(chartArea2);
            chart_Facture.Dock = DockStyle.Fill;
            chart_Facture.Location = new Point(247, 3);
            chart_Facture.Name = "chart_Facture";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Factures émises";
            chart_Facture.Series.Add(series2);
            chart_Facture.Size = new Size(611, 207);
            chart_Facture.TabIndex = 0;
            chart_Facture.Text = "chart1";
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 1;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel14.Controls.Add(lbl_RevenuTTCFactures, 0, 1);
            tableLayoutPanel14.Controls.Add(label3, 0, 0);
            tableLayoutPanel14.Controls.Add(tableLayoutPanel20, 0, 2);
            tableLayoutPanel14.Dock = DockStyle.Fill;
            tableLayoutPanel14.Location = new Point(3, 3);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 3;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 25.4508381F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 56.5574036F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 17.9917564F));
            tableLayoutPanel14.Size = new Size(238, 207);
            tableLayoutPanel14.TabIndex = 1;
            // 
            // lbl_RevenuTTCFactures
            // 
            lbl_RevenuTTCFactures.AutoSize = true;
            lbl_RevenuTTCFactures.Font = new Font("Segoe UI", 50F, FontStyle.Bold);
            lbl_RevenuTTCFactures.ForeColor = Color.White;
            lbl_RevenuTTCFactures.Location = new Point(3, 52);
            lbl_RevenuTTCFactures.Name = "lbl_RevenuTTCFactures";
            lbl_RevenuTTCFactures.Size = new Size(212, 117);
            lbl_RevenuTTCFactures.TabIndex = 1;
            lbl_RevenuTTCFactures.Text = "10 000 €";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(197, 42);
            label3.TabIndex = 0;
            label3.Text = "Revenu TTC des factures émises";
            // 
            // tableLayoutPanel20
            // 
            tableLayoutPanel20.ColumnCount = 2;
            tableLayoutPanel20.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel20.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel20.Controls.Add(btn_ReculerPeriodeFacture, 0, 0);
            tableLayoutPanel20.Controls.Add(btn_AvancerPeriodeFacture, 1, 0);
            tableLayoutPanel20.Dock = DockStyle.Fill;
            tableLayoutPanel20.Location = new Point(3, 172);
            tableLayoutPanel20.Name = "tableLayoutPanel20";
            tableLayoutPanel20.RowCount = 1;
            tableLayoutPanel20.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel20.Size = new Size(232, 32);
            tableLayoutPanel20.TabIndex = 2;
            // 
            // btn_ReculerPeriodeFacture
            // 
            btn_ReculerPeriodeFacture.BackColor = SystemColors.Control;
            btn_ReculerPeriodeFacture.Dock = DockStyle.Fill;
            btn_ReculerPeriodeFacture.ForeColor = Color.FromArgb(48, 50, 54);
            btn_ReculerPeriodeFacture.Location = new Point(3, 3);
            btn_ReculerPeriodeFacture.Name = "btn_ReculerPeriodeFacture";
            btn_ReculerPeriodeFacture.Size = new Size(110, 26);
            btn_ReculerPeriodeFacture.TabIndex = 2;
            btn_ReculerPeriodeFacture.Text = "Reculer d'un ";
            btn_ReculerPeriodeFacture.UseVisualStyleBackColor = false;
            btn_ReculerPeriodeFacture.Click += btn_ReculerPeriodeFacture_Click;
            // 
            // btn_AvancerPeriodeFacture
            // 
            btn_AvancerPeriodeFacture.BackColor = SystemColors.Control;
            btn_AvancerPeriodeFacture.Dock = DockStyle.Fill;
            btn_AvancerPeriodeFacture.ForeColor = Color.FromArgb(48, 50, 54);
            btn_AvancerPeriodeFacture.Location = new Point(119, 3);
            btn_AvancerPeriodeFacture.Name = "btn_AvancerPeriodeFacture";
            btn_AvancerPeriodeFacture.Size = new Size(110, 26);
            btn_AvancerPeriodeFacture.TabIndex = 3;
            btn_AvancerPeriodeFacture.Text = "Avancer d'un ";
            btn_AvancerPeriodeFacture.UseVisualStyleBackColor = false;
            btn_AvancerPeriodeFacture.Click += btn_AvancerPeriodeFacture_Click;
            // 
            // tableLayoutPanel17
            // 
            tableLayoutPanel17.BackColor = Color.FromArgb(83, 92, 107);
            tableLayoutPanel17.ColumnCount = 1;
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel17.Controls.Add(chartDonut_Marque, 0, 2);
            tableLayoutPanel17.Controls.Add(tableLayoutPanel18, 0, 0);
            tableLayoutPanel17.Controls.Add(chartDonut_Type, 0, 1);
            tableLayoutPanel17.Dock = DockStyle.Fill;
            tableLayoutPanel17.Location = new Point(882, 3);
            tableLayoutPanel17.Name = "tableLayoutPanel17";
            tableLayoutPanel17.RowCount = 3;
            tableLayoutPanel17.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel17.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel17.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel17.Size = new Size(288, 449);
            tableLayoutPanel17.TabIndex = 1;
            // 
            // chartDonut_Marque
            // 
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Name = "ChartArea1";
            chartDonut_Marque.ChartAreas.Add(chartArea3);
            chartDonut_Marque.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartDonut_Marque.Legends.Add(legend1);
            chartDonut_Marque.Location = new Point(3, 242);
            chartDonut_Marque.Name = "chartDonut_Marque";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartDonut_Marque.Series.Add(series3);
            chartDonut_Marque.Size = new Size(282, 204);
            chartDonut_Marque.TabIndex = 2;
            chartDonut_Marque.Text = "chart2";
            // 
            // tableLayoutPanel18
            // 
            tableLayoutPanel18.BackColor = Color.FromArgb(83, 92, 107);
            tableLayoutPanel18.ColumnCount = 2;
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel18.Controls.Add(label7, 0, 0);
            tableLayoutPanel18.Controls.Add(cb_Periode, 1, 0);
            tableLayoutPanel18.Dock = DockStyle.Fill;
            tableLayoutPanel18.Location = new Point(3, 3);
            tableLayoutPanel18.Name = "tableLayoutPanel18";
            tableLayoutPanel18.RowCount = 1;
            tableLayoutPanel18.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel18.Size = new Size(282, 24);
            tableLayoutPanel18.TabIndex = 0;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(3, 4);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 0;
            label7.Text = "Période";
            // 
            // cb_Periode
            // 
            cb_Periode.Dock = DockStyle.Fill;
            cb_Periode.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Periode.FormattingEnabled = true;
            cb_Periode.Items.AddRange(new object[] { "Semaine", "Mois", "Année" });
            cb_Periode.Location = new Point(56, 3);
            cb_Periode.Name = "cb_Periode";
            cb_Periode.Size = new Size(223, 23);
            cb_Periode.TabIndex = 1;
            cb_Periode.SelectedIndexChanged += cb_Periode_SelectedIndexChanged;
            // 
            // chartDonut_Type
            // 
            chartArea4.Area3DStyle.Enable3D = true;
            chartArea4.Name = "ChartArea1";
            chartDonut_Type.ChartAreas.Add(chartArea4);
            chartDonut_Type.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartDonut_Type.Legends.Add(legend2);
            chartDonut_Type.Location = new Point(3, 33);
            chartDonut_Type.Name = "chartDonut_Type";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartDonut_Type.Series.Add(series4);
            chartDonut_Type.Size = new Size(282, 203);
            chartDonut_Type.TabIndex = 1;
            chartDonut_Type.Text = "chart1";
            // 
            // OngletInventaire
            // 
            OngletInventaire.BackColor = Color.FromArgb(73, 82, 97);
            OngletInventaire.Controls.Add(tabControl_Inventaire);
            OngletInventaire.Location = new Point(4, 24);
            OngletInventaire.Name = "OngletInventaire";
            OngletInventaire.Padding = new Padding(3);
            OngletInventaire.Size = new Size(1173, 455);
            OngletInventaire.TabIndex = 0;
            OngletInventaire.Text = "Inventaire";
            // 
            // tabControl_Inventaire
            // 
            tabControl_Inventaire.Controls.Add(tab_Inventaire);
            tabControl_Inventaire.Controls.Add(tab_Marque);
            tabControl_Inventaire.Controls.Add(tab_Type);
            tabControl_Inventaire.Dock = DockStyle.Fill;
            tabControl_Inventaire.ImeMode = ImeMode.NoControl;
            tabControl_Inventaire.ItemSize = new Size(100, 20);
            tabControl_Inventaire.Location = new Point(3, 3);
            tabControl_Inventaire.Name = "tabControl_Inventaire";
            tabControl_Inventaire.SelectedIndex = 0;
            tabControl_Inventaire.Size = new Size(1167, 449);
            tabControl_Inventaire.SizeMode = TabSizeMode.Fixed;
            tabControl_Inventaire.TabIndex = 4;
            tabControl_Inventaire.Selecting += tabControl_Inventaire_Selecting;
            // 
            // tab_Inventaire
            // 
            tab_Inventaire.BackColor = Color.FromArgb(48, 50, 54);
            tab_Inventaire.Controls.Add(dgv_Inventaire);
            tab_Inventaire.ForeColor = Color.FromArgb(48, 50, 54);
            tab_Inventaire.Location = new Point(4, 24);
            tab_Inventaire.Name = "tab_Inventaire";
            tab_Inventaire.Padding = new Padding(3);
            tab_Inventaire.Size = new Size(1159, 421);
            tab_Inventaire.TabIndex = 0;
            tab_Inventaire.Text = "Inventaire";
            // 
            // dgv_Inventaire
            // 
            dgv_Inventaire.AllowUserToAddRows = false;
            dgv_Inventaire.AllowUserToDeleteRows = false;
            dgv_Inventaire.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Inventaire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Inventaire.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Inventaire.Columns.AddRange(new DataGridViewColumn[] { IndexInventaire, TypeInventaire, MarqueInventaire, NomInventaire, AnneeInventaire, PrixInventaire, QuantiteInventaire, DateEntreeInventaire, DateSortieInventaire, CommentaireInventaire });
            dgv_Inventaire.Dock = DockStyle.Fill;
            dgv_Inventaire.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Inventaire.GridColor = Color.FromArgb(64, 64, 64);
            dgv_Inventaire.Location = new Point(3, 3);
            dgv_Inventaire.Name = "dgv_Inventaire";
            dgv_Inventaire.RowHeadersWidth = 20;
            dgv_Inventaire.RowTemplate.Height = 25;
            dgv_Inventaire.Size = new Size(1153, 415);
            dgv_Inventaire.TabIndex = 0;
            dgv_Inventaire.CellClick += dgv_Inventaire_CellClick;
            dgv_Inventaire.CellContentClick += dgv_Inventaire_CellContentClick;
            dgv_Inventaire.CellDoubleClick += dgv_Inventaire_CellDoubleClick;
            dgv_Inventaire.CellValueChanged += dgv_Inventaire_CellValueChanged;
            dgv_Inventaire.CurrentCellDirtyStateChanged += dgv_Inventaire_CurrentCellDirtyStateChanged;
            dgv_Inventaire.DataError += dgv_Inventaire_DataError;
            dgv_Inventaire.RowsAdded += dgv_Inventaire_RowsAdded;
            dgv_Inventaire.Scroll += dgv_Inventaire_Scroll;
            dgv_Inventaire.SelectionChanged += dgv_Inventaire_SelectionChanged;
            dgv_Inventaire.KeyDown += dgv_Inventaire_KeyDown;
            // 
            // IndexInventaire
            // 
            IndexInventaire.HeaderText = " ID";
            IndexInventaire.Name = "IndexInventaire";
            IndexInventaire.ReadOnly = true;
            IndexInventaire.Width = 40;
            // 
            // TypeInventaire
            // 
            TypeInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TypeInventaire.HeaderText = "Type";
            TypeInventaire.Items.AddRange(new object[] { "Périphérique", "Processeur", "Pâte thermique" });
            TypeInventaire.MaxDropDownItems = 100;
            TypeInventaire.Name = "TypeInventaire";
            TypeInventaire.Resizable = DataGridViewTriState.True;
            TypeInventaire.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // MarqueInventaire
            // 
            MarqueInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MarqueInventaire.HeaderText = "Marque";
            MarqueInventaire.Items.AddRange(new object[] { "Asus", "Logitech", "Nividia", "Intel", "Acer", "Lenovo" });
            MarqueInventaire.MaxDropDownItems = 100;
            MarqueInventaire.Name = "MarqueInventaire";
            MarqueInventaire.Resizable = DataGridViewTriState.True;
            MarqueInventaire.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // NomInventaire
            // 
            NomInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomInventaire.HeaderText = "Nom";
            NomInventaire.Name = "NomInventaire";
            // 
            // AnneeInventaire
            // 
            AnneeInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AnneeInventaire.HeaderText = "Année";
            AnneeInventaire.Name = "AnneeInventaire";
            // 
            // PrixInventaire
            // 
            PrixInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrixInventaire.HeaderText = "Prix TTC";
            PrixInventaire.Name = "PrixInventaire";
            // 
            // QuantiteInventaire
            // 
            QuantiteInventaire.HeaderText = "Quantité";
            QuantiteInventaire.Name = "QuantiteInventaire";
            // 
            // DateEntreeInventaire
            // 
            DateEntreeInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateEntreeInventaire.HeaderText = "Date d'entrée";
            DateEntreeInventaire.Name = "DateEntreeInventaire";
            DateEntreeInventaire.ReadOnly = true;
            // 
            // DateSortieInventaire
            // 
            DateSortieInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateSortieInventaire.HeaderText = "Date de sortie";
            DateSortieInventaire.Name = "DateSortieInventaire";
            // 
            // CommentaireInventaire
            // 
            CommentaireInventaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CommentaireInventaire.HeaderText = "Commentaire";
            CommentaireInventaire.Name = "CommentaireInventaire";
            // 
            // tab_Marque
            // 
            tab_Marque.BackColor = Color.FromArgb(48, 50, 54);
            tab_Marque.Controls.Add(tlp_MarqueMain);
            tab_Marque.ForeColor = Color.FromArgb(48, 50, 54);
            tab_Marque.Location = new Point(4, 24);
            tab_Marque.Name = "tab_Marque";
            tab_Marque.Padding = new Padding(3);
            tab_Marque.Size = new Size(1159, 421);
            tab_Marque.TabIndex = 1;
            tab_Marque.Text = "Marque";
            // 
            // tlp_MarqueMain
            // 
            tlp_MarqueMain.ColumnCount = 2;
            tlp_MarqueMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_MarqueMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_MarqueMain.Controls.Add(lb_Marque, 0, 0);
            tlp_MarqueMain.Controls.Add(tlp_GererMarque, 1, 0);
            tlp_MarqueMain.Dock = DockStyle.Fill;
            tlp_MarqueMain.Location = new Point(3, 3);
            tlp_MarqueMain.Name = "tlp_MarqueMain";
            tlp_MarqueMain.RowCount = 1;
            tlp_MarqueMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_MarqueMain.Size = new Size(1153, 415);
            tlp_MarqueMain.TabIndex = 5;
            // 
            // lb_Marque
            // 
            lb_Marque.Dock = DockStyle.Fill;
            lb_Marque.Font = new Font("Segoe UI", 22F);
            lb_Marque.FormattingEnabled = true;
            lb_Marque.ItemHeight = 40;
            lb_Marque.Items.AddRange(new object[] { "Asus", "Logitech", "Nividia", "MSI", "Acer", "Lenovo" });
            lb_Marque.Location = new Point(3, 3);
            lb_Marque.Name = "lb_Marque";
            lb_Marque.Size = new Size(570, 409);
            lb_Marque.TabIndex = 1;
            lb_Marque.SelectedIndexChanged += lb_Marque_SelectedIndexChanged;
            lb_Marque.KeyDown += listBox1_KeyDown;
            // 
            // tlp_GererMarque
            // 
            tlp_GererMarque.ColumnCount = 1;
            tlp_GererMarque.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_GererMarque.Controls.Add(txt_AjoutMarque, 0, 0);
            tlp_GererMarque.Controls.Add(btn_SupprimerMarque, 0, 2);
            tlp_GererMarque.Controls.Add(btn_AjouterMarque, 0, 1);
            tlp_GererMarque.Dock = DockStyle.Fill;
            tlp_GererMarque.Location = new Point(579, 3);
            tlp_GererMarque.Name = "tlp_GererMarque";
            tlp_GererMarque.RowCount = 4;
            tlp_GererMarque.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_GererMarque.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlp_GererMarque.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlp_GererMarque.RowStyles.Add(new RowStyle());
            tlp_GererMarque.Size = new Size(571, 409);
            tlp_GererMarque.TabIndex = 2;
            // 
            // txt_AjoutMarque
            // 
            txt_AjoutMarque.Dock = DockStyle.Fill;
            txt_AjoutMarque.Location = new Point(3, 3);
            txt_AjoutMarque.Name = "txt_AjoutMarque";
            txt_AjoutMarque.PlaceholderText = "Entrer la marque à ajouter";
            txt_AjoutMarque.Size = new Size(565, 23);
            txt_AjoutMarque.TabIndex = 3;
            txt_AjoutMarque.TextChanged += txt_AjoutMarque_TextChanged;
            // 
            // btn_SupprimerMarque
            // 
            btn_SupprimerMarque.BackColor = SystemColors.Control;
            btn_SupprimerMarque.Dock = DockStyle.Fill;
            btn_SupprimerMarque.Enabled = false;
            btn_SupprimerMarque.Location = new Point(3, 83);
            btn_SupprimerMarque.Name = "btn_SupprimerMarque";
            btn_SupprimerMarque.Size = new Size(565, 44);
            btn_SupprimerMarque.TabIndex = 6;
            btn_SupprimerMarque.Text = "Supprimer";
            btn_SupprimerMarque.UseVisualStyleBackColor = false;
            btn_SupprimerMarque.Click += btn_SupprimerMarque_Click;
            // 
            // btn_AjouterMarque
            // 
            btn_AjouterMarque.BackColor = SystemColors.Control;
            btn_AjouterMarque.Dock = DockStyle.Fill;
            btn_AjouterMarque.Enabled = false;
            btn_AjouterMarque.Location = new Point(3, 33);
            btn_AjouterMarque.Name = "btn_AjouterMarque";
            btn_AjouterMarque.Size = new Size(565, 44);
            btn_AjouterMarque.TabIndex = 2;
            btn_AjouterMarque.Text = "Ajouter";
            btn_AjouterMarque.UseVisualStyleBackColor = false;
            btn_AjouterMarque.Click += btn_AjouterMarque_Click;
            // 
            // tab_Type
            // 
            tab_Type.BackColor = Color.FromArgb(48, 50, 54);
            tab_Type.Controls.Add(tableLayoutPanel1);
            tab_Type.ForeColor = Color.FromArgb(48, 50, 54);
            tab_Type.Location = new Point(4, 24);
            tab_Type.Name = "tab_Type";
            tab_Type.Padding = new Padding(3);
            tab_Type.Size = new Size(1159, 421);
            tab_Type.TabIndex = 2;
            tab_Type.Text = "Type";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lb_Type, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1153, 415);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // lb_Type
            // 
            lb_Type.Dock = DockStyle.Fill;
            lb_Type.Font = new Font("Segoe UI", 22F);
            lb_Type.FormattingEnabled = true;
            lb_Type.ItemHeight = 40;
            lb_Type.Items.AddRange(new object[] { "Périphérique", "Processeur", "Pâte thermique" });
            lb_Type.Location = new Point(3, 3);
            lb_Type.Name = "lb_Type";
            lb_Type.Size = new Size(570, 409);
            lb_Type.TabIndex = 1;
            lb_Type.SelectedIndexChanged += lb_Type_SelectedIndexChanged;
            lb_Type.KeyDown += lb_Type_KeyDown;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(txt_AjoutType, 0, 0);
            tableLayoutPanel2.Controls.Add(btn_SupprimerType, 0, 2);
            tableLayoutPanel2.Controls.Add(btn_AjouterType, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(579, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(571, 409);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // txt_AjoutType
            // 
            txt_AjoutType.Dock = DockStyle.Fill;
            txt_AjoutType.Location = new Point(3, 3);
            txt_AjoutType.Name = "txt_AjoutType";
            txt_AjoutType.PlaceholderText = "Entrer la type à ajouter";
            txt_AjoutType.Size = new Size(565, 23);
            txt_AjoutType.TabIndex = 3;
            txt_AjoutType.TextChanged += txt_TypeAjouter_TextChanged;
            // 
            // btn_SupprimerType
            // 
            btn_SupprimerType.BackColor = SystemColors.Control;
            btn_SupprimerType.Dock = DockStyle.Fill;
            btn_SupprimerType.Enabled = false;
            btn_SupprimerType.Location = new Point(3, 83);
            btn_SupprimerType.Name = "btn_SupprimerType";
            btn_SupprimerType.Size = new Size(565, 44);
            btn_SupprimerType.TabIndex = 6;
            btn_SupprimerType.Text = "Supprimer";
            btn_SupprimerType.UseVisualStyleBackColor = false;
            btn_SupprimerType.Click += btn_SupprimerType_Click;
            // 
            // btn_AjouterType
            // 
            btn_AjouterType.BackColor = SystemColors.Control;
            btn_AjouterType.Dock = DockStyle.Fill;
            btn_AjouterType.Enabled = false;
            btn_AjouterType.Location = new Point(3, 33);
            btn_AjouterType.Name = "btn_AjouterType";
            btn_AjouterType.Size = new Size(565, 44);
            btn_AjouterType.TabIndex = 2;
            btn_AjouterType.Text = "Ajouter";
            btn_AjouterType.UseVisualStyleBackColor = false;
            btn_AjouterType.Click += btn_AjouterType_Click;
            // 
            // OngletFactureNette
            // 
            OngletFactureNette.BackColor = Color.FromArgb(73, 82, 97);
            OngletFactureNette.Controls.Add(tabControl_Facture);
            OngletFactureNette.Location = new Point(4, 24);
            OngletFactureNette.Name = "OngletFactureNette";
            OngletFactureNette.Padding = new Padding(3);
            OngletFactureNette.Size = new Size(1173, 455);
            OngletFactureNette.TabIndex = 1;
            OngletFactureNette.Text = "Factures";
            // 
            // tabControl_Facture
            // 
            tabControl_Facture.Controls.Add(TabFactures);
            tabControl_Facture.Controls.Add(tabPrestation);
            tabControl_Facture.Dock = DockStyle.Fill;
            tabControl_Facture.Location = new Point(3, 3);
            tabControl_Facture.Name = "tabControl_Facture";
            tabControl_Facture.SelectedIndex = 0;
            tabControl_Facture.Size = new Size(1167, 449);
            tabControl_Facture.SizeMode = TabSizeMode.Fixed;
            tabControl_Facture.TabIndex = 0;
            tabControl_Facture.SelectedIndexChanged += tabControl_FactureOnglet_SelectedIndexChanged;
            // 
            // TabFactures
            // 
            TabFactures.BackColor = Color.FromArgb(48, 50, 54);
            TabFactures.Controls.Add(dgv_Facture);
            TabFactures.ForeColor = Color.FromArgb(48, 50, 54);
            TabFactures.Location = new Point(4, 24);
            TabFactures.Name = "TabFactures";
            TabFactures.Padding = new Padding(3);
            TabFactures.Size = new Size(1159, 421);
            TabFactures.TabIndex = 0;
            TabFactures.Text = "Facture";
            // 
            // dgv_Facture
            // 
            dgv_Facture.AllowUserToAddRows = false;
            dgv_Facture.AllowUserToDeleteRows = false;
            dgv_Facture.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Facture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Facture.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Facture.Columns.AddRange(new DataGridViewColumn[] { IndexFacture, NomFacture, PrestationFacture, DateFacture, CommentaireFacture, PrixHT, PrixTTC, Difference });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 50, 54);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_Facture.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_Facture.Dock = DockStyle.Fill;
            dgv_Facture.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Facture.GridColor = Color.FromArgb(64, 64, 64);
            dgv_Facture.Location = new Point(3, 3);
            dgv_Facture.Name = "dgv_Facture";
            dgv_Facture.RowHeadersWidth = 20;
            dgv_Facture.RowTemplate.Height = 25;
            dgv_Facture.Size = new Size(1153, 415);
            dgv_Facture.TabIndex = 3;
            dgv_Facture.CellClick += dgv_Facture_CellClick;
            dgv_Facture.CellDoubleClick += dgv_Facture_CellDoubleClick;
            dgv_Facture.CellValueChanged += dgv_Facture_CellValueChanged;
            dgv_Facture.CurrentCellDirtyStateChanged += dgv_Facture_CurrentCellDirtyStateChanged;
            dgv_Facture.RowsAdded += dgv_Facture_RowsAdded;
            dgv_Facture.RowsRemoved += dgv_Facture_RowsRemoved;
            dgv_Facture.Scroll += dgv_Facture_Scroll;
            dgv_Facture.SelectionChanged += dgv_Facture_SelectionChanged;
            dgv_Facture.KeyDown += dgv_Facture_KeyDown;
            // 
            // IndexFacture
            // 
            IndexFacture.HeaderText = " ID";
            IndexFacture.Name = "IndexFacture";
            IndexFacture.ReadOnly = true;
            IndexFacture.Width = 40;
            // 
            // NomFacture
            // 
            NomFacture.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomFacture.HeaderText = "Nom";
            NomFacture.Name = "NomFacture";
            // 
            // PrestationFacture
            // 
            PrestationFacture.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrestationFacture.HeaderText = "Prestation";
            PrestationFacture.Items.AddRange(new object[] { "Vente de produit", "Service main d'oeuvre" });
            PrestationFacture.MaxDropDownItems = 100;
            PrestationFacture.Name = "PrestationFacture";
            PrestationFacture.Resizable = DataGridViewTriState.True;
            PrestationFacture.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // DateFacture
            // 
            DateFacture.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateFacture.HeaderText = "Date";
            DateFacture.Name = "DateFacture";
            // 
            // CommentaireFacture
            // 
            CommentaireFacture.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CommentaireFacture.HeaderText = "Commentaire";
            CommentaireFacture.Name = "CommentaireFacture";
            // 
            // PrixHT
            // 
            PrixHT.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrixHT.HeaderText = "PrixHT";
            PrixHT.Name = "PrixHT";
            // 
            // PrixTTC
            // 
            PrixTTC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrixTTC.HeaderText = "PrixTTC";
            PrixTTC.Name = "PrixTTC";
            // 
            // Difference
            // 
            Difference.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Difference.HeaderText = "Montant de la TVA";
            Difference.Name = "Difference";
            Difference.ReadOnly = true;
            // 
            // tabPrestation
            // 
            tabPrestation.BackColor = Color.FromArgb(48, 50, 54);
            tabPrestation.Controls.Add(tableLayoutPanel5);
            tabPrestation.ForeColor = Color.FromArgb(48, 50, 54);
            tabPrestation.Location = new Point(4, 24);
            tabPrestation.Name = "tabPrestation";
            tabPrestation.Padding = new Padding(3);
            tabPrestation.Size = new Size(1159, 421);
            tabPrestation.TabIndex = 1;
            tabPrestation.Text = "Prestation";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(lb_Prestation, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1153, 415);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // lb_Prestation
            // 
            lb_Prestation.Dock = DockStyle.Fill;
            lb_Prestation.Font = new Font("Segoe UI", 22F);
            lb_Prestation.FormattingEnabled = true;
            lb_Prestation.ItemHeight = 40;
            lb_Prestation.Items.AddRange(new object[] { "Vente de produit (13%)", "Service main d'oeuvre (23%)" });
            lb_Prestation.Location = new Point(3, 3);
            lb_Prestation.Name = "lb_Prestation";
            lb_Prestation.Size = new Size(570, 409);
            lb_Prestation.TabIndex = 1;
            lb_Prestation.SelectedIndexChanged += lb_Prestation_SelectedIndexChanged;
            lb_Prestation.KeyDown += lb_Prestation_KeyDown;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(txt_AjoutPrestationNom, 0, 0);
            tableLayoutPanel6.Controls.Add(btn_SupprimerPrestation, 0, 3);
            tableLayoutPanel6.Controls.Add(btn_AjoutPrestation, 0, 2);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(579, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 5;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.Size = new Size(571, 409);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // txt_AjoutPrestationNom
            // 
            txt_AjoutPrestationNom.Dock = DockStyle.Fill;
            txt_AjoutPrestationNom.Location = new Point(3, 3);
            txt_AjoutPrestationNom.Name = "txt_AjoutPrestationNom";
            txt_AjoutPrestationNom.PlaceholderText = "Entrer la prestation à ajouter";
            txt_AjoutPrestationNom.Size = new Size(565, 23);
            txt_AjoutPrestationNom.TabIndex = 3;
            txt_AjoutPrestationNom.TextChanged += txt_AjoutPrestationNom_TextChanged;
            // 
            // btn_SupprimerPrestation
            // 
            btn_SupprimerPrestation.BackColor = SystemColors.Control;
            btn_SupprimerPrestation.Dock = DockStyle.Fill;
            btn_SupprimerPrestation.Enabled = false;
            btn_SupprimerPrestation.ForeColor = Color.FromArgb(48, 50, 54);
            btn_SupprimerPrestation.Location = new Point(3, 113);
            btn_SupprimerPrestation.Name = "btn_SupprimerPrestation";
            btn_SupprimerPrestation.Size = new Size(565, 44);
            btn_SupprimerPrestation.TabIndex = 6;
            btn_SupprimerPrestation.Text = "Supprimer";
            btn_SupprimerPrestation.UseVisualStyleBackColor = false;
            btn_SupprimerPrestation.Click += btn_SupprPrestation_Click;
            // 
            // btn_AjoutPrestation
            // 
            btn_AjoutPrestation.BackColor = SystemColors.Control;
            btn_AjoutPrestation.Dock = DockStyle.Fill;
            btn_AjoutPrestation.Enabled = false;
            btn_AjoutPrestation.ForeColor = Color.FromArgb(48, 50, 54);
            btn_AjoutPrestation.Location = new Point(3, 63);
            btn_AjoutPrestation.Name = "btn_AjoutPrestation";
            btn_AjoutPrestation.Size = new Size(565, 44);
            btn_AjoutPrestation.TabIndex = 2;
            btn_AjoutPrestation.Text = "Ajouter";
            btn_AjoutPrestation.UseVisualStyleBackColor = false;
            btn_AjoutPrestation.Click += btn_AjoutPrestation_Click;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 3;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6376228F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.12318F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.2392025F));
            tableLayoutPanel7.Controls.Add(label1, 0, 0);
            tableLayoutPanel7.Controls.Add(nupd_AjoutPourcentageTVA, 1, 0);
            tableLayoutPanel7.Controls.Add(label2, 2, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 33);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(565, 24);
            tableLayoutPanel7.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(7, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 24);
            label1.TabIndex = 0;
            label1.Text = "Pourcentage TVA";
            // 
            // nupd_AjoutPourcentageTVA
            // 
            nupd_AjoutPourcentageTVA.DecimalPlaces = 1;
            nupd_AjoutPourcentageTVA.Dock = DockStyle.Fill;
            nupd_AjoutPourcentageTVA.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nupd_AjoutPourcentageTVA.Location = new Point(68, 3);
            nupd_AjoutPourcentageTVA.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nupd_AjoutPourcentageTVA.Name = "nupd_AjoutPourcentageTVA";
            nupd_AjoutPourcentageTVA.Size = new Size(480, 23);
            nupd_AjoutPourcentageTVA.TabIndex = 1;
            nupd_AjoutPourcentageTVA.ValueChanged += nupd_AjoutPourcentageTVA_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(554, 4);
            label2.Name = "label2";
            label2.Size = new Size(8, 15);
            label2.TabIndex = 2;
            label2.Text = "%";
            // 
            // OngletSitesFavoris
            // 
            OngletSitesFavoris.BackColor = Color.FromArgb(73, 82, 97);
            OngletSitesFavoris.Controls.Add(tableLayoutPanel8);
            OngletSitesFavoris.Location = new Point(4, 24);
            OngletSitesFavoris.Name = "OngletSitesFavoris";
            OngletSitesFavoris.Size = new Size(1173, 455);
            OngletSitesFavoris.TabIndex = 2;
            OngletSitesFavoris.Text = "Sites favoris";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(lb_SitesFav, 0, 0);
            tableLayoutPanel8.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(1173, 455);
            tableLayoutPanel8.TabIndex = 4;
            // 
            // lb_SitesFav
            // 
            lb_SitesFav.BackColor = Color.FromArgb(48, 50, 54);
            lb_SitesFav.Dock = DockStyle.Fill;
            lb_SitesFav.Font = new Font("Segoe UI", 22F);
            lb_SitesFav.ForeColor = Color.Transparent;
            lb_SitesFav.FormattingEnabled = true;
            lb_SitesFav.ItemHeight = 40;
            lb_SitesFav.Location = new Point(3, 3);
            lb_SitesFav.Name = "lb_SitesFav";
            lb_SitesFav.Size = new Size(580, 449);
            lb_SitesFav.TabIndex = 0;
            lb_SitesFav.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            lb_SitesFav.MouseDoubleClick += lb_SitesFav_MouseDoubleClick;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(48, 50, 54);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(btn_AccederSiteWeb, 0, 3);
            tableLayoutPanel4.Controls.Add(txt_AjoutSiteWebUrl, 0, 1);
            tableLayoutPanel4.Controls.Add(btn_AjouterSiteWeb, 0, 2);
            tableLayoutPanel4.Controls.Add(txt_AjoutSiteWebNom, 0, 0);
            tableLayoutPanel4.Controls.Add(btn_SupprimerSiteWeb, 0, 4);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(589, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 6;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(581, 449);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // btn_AccederSiteWeb
            // 
            btn_AccederSiteWeb.BackColor = SystemColors.Control;
            btn_AccederSiteWeb.Dock = DockStyle.Fill;
            btn_AccederSiteWeb.Enabled = false;
            btn_AccederSiteWeb.ForeColor = Color.FromArgb(48, 50, 54);
            btn_AccederSiteWeb.Location = new Point(3, 113);
            btn_AccederSiteWeb.Name = "btn_AccederSiteWeb";
            btn_AccederSiteWeb.Size = new Size(575, 44);
            btn_AccederSiteWeb.TabIndex = 13;
            btn_AccederSiteWeb.Text = "Accéder";
            btn_AccederSiteWeb.UseVisualStyleBackColor = false;
            btn_AccederSiteWeb.Click += btn_AccederSiteWeb_Click;
            // 
            // txt_AjoutSiteWebUrl
            // 
            txt_AjoutSiteWebUrl.Dock = DockStyle.Fill;
            txt_AjoutSiteWebUrl.Location = new Point(3, 33);
            txt_AjoutSiteWebUrl.Name = "txt_AjoutSiteWebUrl";
            txt_AjoutSiteWebUrl.PlaceholderText = "Entrer l'URL du site web";
            txt_AjoutSiteWebUrl.Size = new Size(575, 23);
            txt_AjoutSiteWebUrl.TabIndex = 12;
            txt_AjoutSiteWebUrl.TextChanged += txt_AjoutSiteWebUrl_TextChanged;
            // 
            // btn_AjouterSiteWeb
            // 
            btn_AjouterSiteWeb.BackColor = SystemColors.Control;
            btn_AjouterSiteWeb.Dock = DockStyle.Fill;
            btn_AjouterSiteWeb.Enabled = false;
            btn_AjouterSiteWeb.ForeColor = Color.FromArgb(48, 50, 54);
            btn_AjouterSiteWeb.Location = new Point(3, 63);
            btn_AjouterSiteWeb.Name = "btn_AjouterSiteWeb";
            btn_AjouterSiteWeb.Size = new Size(575, 44);
            btn_AjouterSiteWeb.TabIndex = 2;
            btn_AjouterSiteWeb.Text = "Ajouter";
            btn_AjouterSiteWeb.UseVisualStyleBackColor = false;
            btn_AjouterSiteWeb.Click += btn_AjouterSiteWeb_Click;
            // 
            // txt_AjoutSiteWebNom
            // 
            txt_AjoutSiteWebNom.Dock = DockStyle.Fill;
            txt_AjoutSiteWebNom.Location = new Point(3, 3);
            txt_AjoutSiteWebNom.Name = "txt_AjoutSiteWebNom";
            txt_AjoutSiteWebNom.PlaceholderText = "Entrer le nom du site web (Laissez vide pour avoir l'url en tant que nom)";
            txt_AjoutSiteWebNom.Size = new Size(575, 23);
            txt_AjoutSiteWebNom.TabIndex = 3;
            // 
            // btn_SupprimerSiteWeb
            // 
            btn_SupprimerSiteWeb.BackColor = SystemColors.Control;
            btn_SupprimerSiteWeb.Dock = DockStyle.Fill;
            btn_SupprimerSiteWeb.Enabled = false;
            btn_SupprimerSiteWeb.ForeColor = Color.FromArgb(48, 50, 54);
            btn_SupprimerSiteWeb.Location = new Point(3, 163);
            btn_SupprimerSiteWeb.Name = "btn_SupprimerSiteWeb";
            btn_SupprimerSiteWeb.Size = new Size(575, 44);
            btn_SupprimerSiteWeb.TabIndex = 11;
            btn_SupprimerSiteWeb.Text = "Supprimer";
            btn_SupprimerSiteWeb.UseVisualStyleBackColor = false;
            btn_SupprimerSiteWeb.Click += btn_SupprimerSiteWeb_Click;
            // 
            // inventaireMarqueBindingSource1
            // 
            inventaireMarqueBindingSource1.DataSource = typeof(Model.InventaireMarque);
            // 
            // inventaireMarqueBindingSource
            // 
            inventaireMarqueBindingSource.DataSource = typeof(Model.InventaireMarque);
            // 
            // tableLayoutPrincipal
            // 
            tableLayoutPrincipal.ColumnCount = 2;
            tableLayoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1498258F));
            tableLayoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 99.850174F));
            tableLayoutPrincipal.Controls.Add(tlp_Main, 1, 0);
            tableLayoutPrincipal.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPrincipal.Dock = DockStyle.Fill;
            tableLayoutPrincipal.Location = new Point(0, 24);
            tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            tableLayoutPrincipal.RowCount = 2;
            tableLayoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPrincipal.Size = new Size(1200, 562);
            tableLayoutPrincipal.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel3.Controls.Add(label_CopyrightVersion, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(4, 545);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1193, 14);
            tableLayoutPanel3.TabIndex = 11;
            // 
            // label_CopyrightVersion
            // 
            label_CopyrightVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_CopyrightVersion.AutoSize = true;
            label_CopyrightVersion.Location = new Point(3, 0);
            label_CopyrightVersion.Name = "label_CopyrightVersion";
            label_CopyrightVersion.Size = new Size(239, 14);
            label_CopyrightVersion.TabIndex = 0;
            label_CopyrightVersion.Text = "Gestion Inventaire entreprise ©  | Version 1.1";
            // 
            // FormGestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(48, 50, 54);
            ClientSize = new Size(1200, 586);
            Controls.Add(tableLayoutPrincipal);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.AppWorkspace;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FormGestion";
            Text = "Gestion Inventaire Entreprise";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tlp_Haut.ResumeLayout(false);
            tlp_Haut.PerformLayout();
            ts_Inventaire.ResumeLayout(false);
            ts_Inventaire.PerformLayout();
            tlp_Main.ResumeLayout(false);
            tlp_Millieu.ResumeLayout(false);
            tabControl_Onglets.ResumeLayout(false);
            OngletTableauDeBord.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel_TabBord.ResumeLayout(false);
            tableLayoutPanel_TabBord2.ResumeLayout(false);
            tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart_Inventaire).EndInit();
            tableLayoutPanel16.ResumeLayout(false);
            tableLayoutPanel16.PerformLayout();
            tableLayoutPanel19.ResumeLayout(false);
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart_Facture).EndInit();
            tableLayoutPanel14.ResumeLayout(false);
            tableLayoutPanel14.PerformLayout();
            tableLayoutPanel20.ResumeLayout(false);
            tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDonut_Marque).EndInit();
            tableLayoutPanel18.ResumeLayout(false);
            tableLayoutPanel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartDonut_Type).EndInit();
            OngletInventaire.ResumeLayout(false);
            tabControl_Inventaire.ResumeLayout(false);
            tab_Inventaire.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Inventaire).EndInit();
            tab_Marque.ResumeLayout(false);
            tlp_MarqueMain.ResumeLayout(false);
            tlp_GererMarque.ResumeLayout(false);
            tlp_GererMarque.PerformLayout();
            tab_Type.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            OngletFactureNette.ResumeLayout(false);
            tabControl_Facture.ResumeLayout(false);
            TabFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Facture).EndInit();
            tabPrestation.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupd_AjoutPourcentageTVA).EndInit();
            OngletSitesFavoris.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inventaireMarqueBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)inventaireMarqueBindingSource).EndInit();
            tableLayoutPrincipal.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem TSMenuItem_Fichier_Ouvrir;
        private ToolStripMenuItem TSMenuItem_Fichier_Sauvegarder;
        private ToolStripMenuItem préférencesToolStripMenuItem;
        private ToolStripMenuItem TSMenuItem_Preferences_ConfirmationVider;
        private ToolStripMenuItem TSMenuItem_Preferences_ConfirmationSuppression;
        private TableLayoutPanel tlp_Bas;
        private TextBox txt_Recherche;
        private Label lbl_RechercheInventaire;
        private TableLayoutPanel tlp_Haut;
        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_Millieu;
        private ToolStripMenuItem TSMenuItem_Fichier_SauvegarderSous;
        private ToolStripMenuItem TSMenuItem_Fichier_Nouveau;
        private ComboBox cb_FiltreRecherche;
        private Label lbl_Filtre;
        private ToolStrip ts_Inventaire;
        private ToolStripButton btn_AjouterLigne;
        private ToolStripButton btn_SupprimerLigne;
        private ToolStripButton btn_InsererLigne;
        private ToolStripButton btn_CopierLigne;
        private ToolStripButton btn_CollerLigne;
        private TableLayoutPanel tableLayoutPrincipal;
        private TabControl tabControl_Inventaire;
        private TabPage tab_Inventaire;
        private DataGridView dgv_Inventaire;
        private TabPage tab_Marque;
        private TableLayoutPanel tlp_MarqueMain;
        private ListBox lb_Marque;
        private TableLayoutPanel tlp_GererMarque;
        private TextBox txt_AjoutMarque;
        private Button btn_SupprimerMarque;
        private Button btn_AjouterMarque;
        private TabPage tab_Type;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox lb_Type;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txt_AjoutType;
        private Button btn_SupprimerType;
        private Button btn_AjouterType;
        private ToolStripMenuItem TSMenuItem_Preferences_InsertionLigne;
        private ToolStripComboBox TSMenuItem_Preferences_InsertionLigne_Cb;
        private ToolStripMenuItem TSMenuItem_Preferences_Theme;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem TSMenuItem_Preferences_Theme_CouleurP;
        private ToolStripMenuItem TSMenuItem_Preferences_Theme_CouleurS;
        private ToolStripMenuItem TSMenuItem_Preferences_Theme_CouleurT;
        private ColorDialog colorDialog1;
        private ToolStripButton btn_CouperLigne;
        private ToolStripButton btn_ViderLigne;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btn_Sauvegarder;
        private ToolStripButton btn_SauvegarderSous;
        private TabControl tabControl_Onglets;
        private TabPage OngletInventaire;
        private TabPage OngletFactureNette;
        private DataGridView dgv_Facture;
        private TabPage OngletSitesFavoris;
        private ListBox lb_SitesFav;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox txt_AjoutSiteWebUrl;
        private Button btn_SupprimerSiteWeb;
        private Button btn_AjouterSiteWeb;
        private TextBox txt_AjoutSiteWebNom;
        private TabControl tabControl_Facture;
        private TabPage TabFactures;
        private TabPage tabPrestation;
        private TableLayoutPanel tableLayoutPanel5;
        private ListBox lb_Prestation;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox txt_AjoutPrestationNom;
        private Button btn_SupprimerPrestation;
        private Button btn_AjoutPrestation;
        private TableLayoutPanel tableLayoutPanel7;
        private TabPage OngletTableauDeBord;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label_CopyrightVersion;
        private Label label1;
        private NumericUpDown nupd_AjoutPourcentageTVA;
        private Label label2;
        private DataGridViewTextBoxColumn IndexFacture;
        private DataGridViewTextBoxColumn NomFacture;
        private DataGridViewComboBoxColumn PrestationFacture;
        private DataGridViewTextBoxColumn DateFacture;
        private DataGridViewTextBoxColumn CommentaireFacture;
        private DataGridViewTextBoxColumn PrixHT;
        private DataGridViewTextBoxColumn PrixTTC;
        private DataGridViewTextBoxColumn Difference;
        private BindingSource inventaireMarqueBindingSource;
        private Button btn_AccederSiteWeb;
        private TableLayoutPanel tableLayoutPanel9;
        private DataGridViewTextBoxColumn IndexInventaire;
        private DataGridViewComboBoxColumn TypeInventaire;
        private DataGridViewComboBoxColumn MarqueInventaire;
        private DataGridViewTextBoxColumn NomInventaire;
        private DataGridViewTextBoxColumn AnneeInventaire;
        private DataGridViewTextBoxColumn PrixInventaire;
        private DataGridViewTextBoxColumn QuantiteInventaire;
        private DataGridViewTextBoxColumn DateEntreeInventaire;
        private DataGridViewTextBoxColumn DateSortieInventaire;
        private DataGridViewTextBoxColumn CommentaireInventaire;
        private TableLayoutPanel tableLayoutPanel_TabBord;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Facture;
        private BindingSource inventaireMarqueBindingSource1;
        private TableLayoutPanel tableLayoutPanel14;
        private Label lbl_RevenuTTCFactures;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel_TabBord2;
        private TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Inventaire;
        private TableLayoutPanel tableLayoutPanel16;
        private Label lbl_ValeurInventaire;
        private Label label45;
        private TableLayoutPanel tableLayoutPanel17;
        private TableLayoutPanel tableLayoutPanel18;
        private Label label7;
        private ComboBox cb_Periode;
        private TableLayoutPanel tableLayoutPanel19;
        private Button btn_ReculerPeriodeInventaire;
        private Button btn_AvancerPeriodeInventaire;
        private TableLayoutPanel tableLayoutPanel20;
        private Button btn_ReculerPeriodeFacture;
        private Button btn_AvancerPeriodeFacture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDonut_Marque;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDonut_Type;
    }
}