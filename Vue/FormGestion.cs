using FranceInformatiqueInventaire.dal;
using Microsoft.VisualBasic.Devices;
using System;
using System.Data;
using System.Data.SQLite;
using System.DirectoryServices;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Forms;
using FranceInformatiqueInventaire.Controlleur;
using System.ComponentModel;
using FranceInformatiqueInventaire.Model;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using static FranceInformatiqueInventaire.Model.EnumPeriodes;
using Microsoft.VisualBasic;

namespace FranceInformatiqueInventaire
{
    public enum visibiliteToolstrip {VISIBLE,CACHE,CACHEAVECFOND,MODIFDGV};
    public enum ongletPrincipal { TABDEBORD, INVENTAIRE, FACTURES, SITESFAV};
    public enum typeRecherche { INVENTAIRE, MARQUE, TYPE, FACTURES};

    /// <summary>
    ///  Form principale du logiciel, partie Vue et des évenements de l'application.
    /// </summary>
    public partial class FormGestion : Form
    {
        //Variables pour les valeurs par défaut
        private List<string> defautMarquesCharge = new List<string>();
        private List<string> defautTypesCharge = new List<string>();
        private List<FacturePrestation> defautPrestationsCharge = new List<FacturePrestation>();
        //Reste des variables
        private List<DataGridViewRow> inventaireRowsCharge = new List<DataGridViewRow>();
        private List<DataGridViewRow> factureRowsCharge = new List<DataGridViewRow>();
        private List<string> marquesCharge = new List<string>();
        private List<string> typesCharge = new List<string>();
        private List<FacturePrestation> prestationsCharge = new List<FacturePrestation>();
        private List<SiteFavorisLigne> sitesFavorisCharge = new List<SiteFavorisLigne>();
        private bool confirmationAvantSuppression = true;
        private bool confirmationAvantVider = true;
        private BddManager bddManagerRef;
        public string cheminFichierOuvert = "";
        public string titreFichierOuvert = "";
        private DateTimePicker dtpInventaireDateEntree = new DateTimePicker();
        private DateTimePicker dtpInventaireDateSortie = new DateTimePicker();
        private Rectangle rectangleDtpInventaireDateEntree;
        private Rectangle rectangleDtpInventaireDateSortie;
        private List<DataGridViewRow> rowsInventaireCopiee = new List<DataGridViewRow>();
        public bool insertionAvant = true;
        private Color couleurP = Color.FromArgb(48, 50, 54);
        private Color couleurS = Color.FromArgb(73, 82, 97);
        private Color couleurT = Color.FromArgb(105, 105, 105);
        private bool couperLignes = false;
        private GestionControlleur controleur;
        private ongletPrincipal ongletPrincipalActuel = ongletPrincipal.INVENTAIRE;
        private DateTimePicker dtpFactureDate = new DateTimePicker();
        private Rectangle rectangleDtpFactureDate;
        private List<DataGridViewRow> rowsFactureCopiee = new List<DataGridViewRow>();
        private bool tentativeAccesSite = false;
        private EnumPeriodes periodeActuelle = SEMAINE;
        DateTime dateBaseDecalage = DateTime.Today;

        public FormGestion()
        {
            InitializeComponent();
            bddManagerRef = BddManager.GetInstance(this);
            //dtpInventaireEntree :
            dgv_Inventaire.Controls.Add(dtpInventaireDateEntree);
            dtpInventaireDateEntree.Visible = false;
            dtpInventaireDateEntree.Format = DateTimePickerFormat.Custom;
            dtpInventaireDateEntree.TextChanged += new EventHandler(dtpInventaireDateEntree_TextChange);
            //dtpInventaireSortie :
            dgv_Inventaire.Controls.Add(dtpInventaireDateSortie);
            dtpInventaireDateSortie.Visible = false;
            dtpInventaireDateSortie.Format = DateTimePickerFormat.Custom; ;
            dtpInventaireDateSortie.TextChanged += new EventHandler(dtpInventaireDateSortie_TextChange);
            //dtpFacture :
            dgv_Facture.Controls.Add(dtpFactureDate);
            dtpFactureDate.Visible = false;
            dtpFactureDate.Format = DateTimePickerFormat.Custom;
            dtpFactureDate.TextChanged += new EventHandler(dtpFactureDate_TextChange);

            //Preferences :
            TSMenuItem_Preferences_InsertionLigne_Cb.SelectedIndex = 0;
            controleur = new GestionControlleur(bddManagerRef);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MajCbFiltre(true);
            cb_FiltreRecherche.SelectedIndex = 0;
            cb_Periode.SelectedIndex = 0;
            this.ActiveControl = null;
            InitialiserCouleurThemeMenuItem();
            DefinirMarqueCharge();
            DefinirTypeCharge();
            DefinirVariablesDefaut();
            ChargerRemplirPrestation(defautPrestationsCharge);
            label_CopyrightVersion.Text = label_CopyrightVersion.Text.Insert(label_CopyrightVersion.Text.LastIndexOf('©') + 2, DateTime.Now.Year.ToString());
            lb_SitesFav.DataSource = sitesFavorisCharge;
            lb_Prestation.DataSource = prestationsCharge;
            tabControl_Onglets_SelectedIndexChanged(null, null);
            cb_Periode.SelectedIndex = 0;
        }

        /// <summary>
        ///  Actualise la colonne index de la dataGridView inventaire pour que les nombres se suivent.
        /// </summary>
        public void ActualiserIndexLignesInventaire()
        {
            for (int i = 0; i < dgv_Inventaire.RowCount; i++)
            {
                dgv_Inventaire.Rows[i].Cells["IndexInventaire"].Value = i;
            }
        }

        /// <summary>
        ///  Récupère la valeur de la dateTimePicker pour remplir la cellule.
        /// </summary>
        private void dtpInventaireDateEntree_TextChange(object? sender, EventArgs e)
        {
            dgv_Inventaire.CurrentCell.Value = dtpInventaireDateEntree.Text.ToString();
        }

        /// <summary>
        ///  Récupère la valeur de la dateTimePicker pour remplir la cellule.
        /// </summary>
        private void dtpInventaireDateSortie_TextChange(object? sender, EventArgs e)
        {
            dgv_Inventaire.CurrentCell.Value = dtpInventaireDateSortie.Text.ToString();
        }

        /// <summary>
        ///  Si scroll sur la dataGridView, alors cache les dateTimePicker.
        /// </summary>
        private void dgv_Inventaire_Scroll(object sender, ScrollEventArgs e)
        {
            dtpInventaireDateEntree.Visible = false;
            dtpInventaireDateSortie.Visible = false;
        }

        /// <summary>
        ///  Si clique sur une cellule appartenant aux colonnes des dates, alors fait apparaitre un dateTimePicker.
        /// </summary>
        private void dgv_Inventaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                DataGridViewCell cell = dgv_Inventaire.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (dgv_Inventaire.Columns[e.ColumnIndex].Name)
                {
                    case "DateEntreeInventaire":
                        dtpInventaireDateSortie.Visible = false;
                        rectangleDtpInventaireDateEntree = dgv_Inventaire.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtpInventaireDateEntree.Size = new Size(rectangleDtpInventaireDateEntree.Width, rectangleDtpInventaireDateEntree.Height);
                        dtpInventaireDateEntree.Location = new Point(rectangleDtpInventaireDateEntree.X, rectangleDtpInventaireDateEntree.Y);
                        dtpInventaireDateEntree.Visible = true;
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString() != "")
                            {
                                dtpInventaireDateEntree.Value = DateTime.ParseExact(cell.Value.ToString() ?? "", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                        }
                        break;
                    case "DateSortieInventaire":
                        dtpInventaireDateEntree.Visible = false;
                        rectangleDtpInventaireDateSortie = dgv_Inventaire.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtpInventaireDateSortie.Size = new Size(rectangleDtpInventaireDateSortie.Width, rectangleDtpInventaireDateSortie.Height);
                        dtpInventaireDateSortie.Location = new Point(rectangleDtpInventaireDateSortie.X, rectangleDtpInventaireDateSortie.Y);
                        dtpInventaireDateSortie.Visible = true;
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString() != "")
                            {
                                string actuelleTexte = cell.Value.ToString() ?? "";
                                dtpInventaireDateSortie.Value = DateTime.ParseExact(actuelleTexte, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                        }
                        break;
                    default:
                        dtpInventaireDateEntree.Visible = false;
                        dtpInventaireDateSortie.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        ///  Si double clique sur une cellule appartenant à la colonne Index alors séléctionne la ligne.
        /// </summary>
        private void dgv_Inventaire_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                switch (dgv_Inventaire.Columns[e.ColumnIndex].Name)
                {
                    case "IndexInventaire":
                        dgv_Inventaire.Rows[e.RowIndex].Selected = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Si des lignes sont supprimés, alors actualise les index des lignes.
        /// </summary>
        private void dgv_Inventaire_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualiserIndexLignesInventaire();
        }

        /// <summary>
        ///  Définit la variable booléen "confirmationAvantSuppresion" selon si la toolStripMenuItem est coché ou non.
        /// </summary>
        private void rToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            confirmationAvantSuppression = TSMenuItem_Preferences_ConfirmationSuppression.Checked;
        }

        /// <summary>
        ///  Définit la variable booléen "confirmationAvantVider" selon si la toolStripMenuItem est coché ou non.
        /// </summary>
        private void TSMenuItem_Preferences_ConfirmationVider_CheckedChanged(object sender, EventArgs e)
        {
            confirmationAvantVider = TSMenuItem_Preferences_ConfirmationVider.Checked;
        }

        /// <summary>
        ///  Selon le nombre de ligne selectionné, définit quel bouton est activé ou non, ici pour l'inventaire.
        /// </summary>
        private void dgv_Inventaire_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Inventaire.SelectedRows.Count != 0)
            {
                btn_SupprimerLigne.Enabled = true;
                btn_CopierLigne.Enabled = true;
                btn_CouperLigne.Enabled = true;
                btn_ViderLigne.Enabled = true;
            }
            else
            {
                btn_SupprimerLigne.Enabled = false;
                btn_CopierLigne.Enabled = false;
                btn_CouperLigne.Enabled = false;
                btn_ViderLigne.Enabled = false;
            }

            if (dgv_Inventaire.SelectedRows.Count == 1)
            {
                btn_InsererLigne.Enabled = true;
            }
            else
            {
                btn_InsererLigne.Enabled = false;
            }
        }


        /// <summary>
        ///  Permet de changer le titre de la FormGestion si on ouvre ou sauvegarde un fichier.
        /// </summary>
        public void changerFormTitre(bool titreBasique)
        {
            if (titreBasique)
            {
                this.Text = "Gestion Inventaire";
            }
            else
            {
                this.Text = "Gestion Inventaire - " + titreFichierOuvert;
            }
        }

        /// <summary>
        ///  Si clique sur le ToolStripMenuItem "ouvrir", alors ouvre la boite de dialogue pour ouvrir un fichier.
        /// </summary>
        private void TSMenuItem_Fichier_Ouvrir_Click(object sender, EventArgs e)
        {
            Ouvrir();
        }

        /// <summary>
        ///  Ouvre une boite de dialogue de fichier, puis charge le fichier choisi.
        /// </summary>
        private void Ouvrir()
        {
            dgv_Inventaire.EndEdit();
            string tempText = controleur.OuvrirDialogueOuvertureFichier();
            if (tempText != "")
            {
                cheminFichierOuvert = tempText;
                titreFichierOuvert = controleur.GetFileNameSansChemin(cheminFichierOuvert);
                string texteConnexion = @"Data Source=" + cheminFichierOuvert + ";Version=3;";
                if (cheminFichierOuvert != "")
                {
                    changerFormTitre(false);
                    ChargerRemplirMarque(bddManagerRef.RecupererTableMarque(texteConnexion));
                    ChargerRemplirType(bddManagerRef.RecupererTableType(texteConnexion));
                    DefinirMarqueCharge();
                    DefinirTypeCharge();
                    ChargerRemplirInventaire(bddManagerRef.RecupererTableInventaire(texteConnexion));
                    DefinirInventaireRowsCharge();
                    UpdateInventaireColonneType();
                    UpdateInventaireColonneMarque();
                    if (bddManagerRef.VerifierExistanceTableFacture(texteConnexion))
                    {
                        ChargerRemplirPrestation(bddManagerRef.RecupererTablePrestation(texteConnexion));
                        UpdateFactureColonnePrestation();
                        ChargerRemplirFacture(bddManagerRef.RecupererTableFacture(texteConnexion));
                        DefinirFactureRowsCharge();
                    }
                    if (bddManagerRef.VerifierExistanceTableSiteFavoris(texteConnexion))
                    {
                        ChargerRemplirSiteFavoris(bddManagerRef.RecupererTableSiteFav(texteConnexion));
                    }
                    TSMenuItem_Fichier_Sauvegarder.Enabled = true;
                    btn_Sauvegarder.Enabled = true;
                    MajGraphiquesTabDeBord();
                }
            }
        }

        /// <summary>
        ///  Mets à jour le tableau de bord avec ses graphiques.
        /// </summary>
        private void MajGraphiquesTabDeBord()
        {
            cb_FiltreRecherche.SelectedIndex = 0;
            MajGraphiqueLineaireTabDeBord(true);
            MajGraphiqueLineaireTabDeBord(false);
            MajGraphiqueDonutTabDeBord(true);
            MajGraphiqueDonutTabDeBord(false);
        }

        /// <summary>
        ///  Ajoute une ligne dans la dataGridView et sauvegarde ces rows temporairement dans une collection.
        /// </summary>
        private void AjouterLigneInventaire()
        {
            dgv_Inventaire.Sort(dgv_Inventaire.Columns[0], ListSortDirection.Ascending);
            dgv_Inventaire.Rows.Add();
            dgv_Inventaire.Rows[dgv_Inventaire.Rows.Count - 1].Cells["QuantiteInventaire"].Value = 1;
            DefinirInventaireRowsCharge();
        }

        /// <summary>
        ///  Charge toutes les lignes de la dataGridView inventaire à partir d'une liste de InventaireLigne.
        /// </summary>
        /// <param name="contenuInventaireDansDbTemp">Liste de InventaireLigne qui permet de charger toutes les lignes de chaque colonne de la dataGridView inventaire.</ param >
        private void ChargerRemplirInventaire(List<InventaireLigne> contenuInventaireDansDbTemp)
        {
            dgv_Inventaire.Rows.Clear();
            for (int i = 0; i < contenuInventaireDansDbTemp.Count(); i++)
            {
                dgv_Inventaire.Rows.Add(contenuInventaireDansDbTemp[i].id, contenuInventaireDansDbTemp[i].type, contenuInventaireDansDbTemp[i].marque, contenuInventaireDansDbTemp[i].nom, contenuInventaireDansDbTemp[i].annee, null, contenuInventaireDansDbTemp[i].quantite, contenuInventaireDansDbTemp[i].dateEntree, contenuInventaireDansDbTemp[i].dateSortie, contenuInventaireDansDbTemp[i].commentaire);
                if (contenuInventaireDansDbTemp[i].prix != -1f)
                {
                    dgv_Inventaire.Rows[i].Cells[5].Value = contenuInventaireDansDbTemp[i].prix + "€";
                }
            }
        }

        /// <summary>
        ///  Charge la listBox Marque à partir du fichier chargé.
        /// </summary>
        /// <param name="marques">Liste InventaireMarque à charger.</param>
        private void ChargerRemplirMarque(List<InventaireMarque> marques)
        {
            lb_Marque.Items.Clear();
            for (int i = 0; i < marques.Count; i++)
            {
                lb_Marque.Items.Add(marques[i].nom);
            }
        }

        /// <summary>
        ///  Charge la listBox Type à partir du fichier chargé.
        /// </summary>
        /// <param name="types">Liste InventaireType à charger.</param>
        private void ChargerRemplirType(List<InventaireType> types)
        {
            lb_Type.Items.Clear();
            for (int i = 0; i < types.Count; i++)
            {
                lb_Type.Items.Add(types[i].nom);
            }
        }

        /// <summary>
        ///  Charge toutes les lignes de la dataGridView facture à partir d'une liste de FactureLigne.
        /// </summary>
        /// <param name="contenuFactureDansDbTemp">Liste de FactureLigne qui permet de charger toutes les lignes de chaque colonne de la dataGridView facture.</param>
        private void ChargerRemplirFacture(List<FactureLigne> contenuFactureDansDbTemp)
        {
            dgv_Facture.Rows.Clear();
            for (int i = 0; i < contenuFactureDansDbTemp.Count(); i++)
            {
                dgv_Facture.Rows.Add(contenuFactureDansDbTemp[i].id, contenuFactureDansDbTemp[i].nom, contenuFactureDansDbTemp[i].prestation, contenuFactureDansDbTemp[i].date, contenuFactureDansDbTemp[i].commentaire, null, null, null);
                if (contenuFactureDansDbTemp[i].prixHT != -1f)
                {
                    dgv_Facture.Rows[i].Cells[5].Value = contenuFactureDansDbTemp[i].prixHT + "€";
                }
                if (contenuFactureDansDbTemp[i].prixTTC != -1f)
                {
                    dgv_Facture.Rows[i].Cells[6].Value = contenuFactureDansDbTemp[i].prixTTC + "€";
                }
                if (contenuFactureDansDbTemp[i].difference != -1f)
                {
                    dgv_Facture.Rows[i].Cells[7].Value = contenuFactureDansDbTemp[i].difference + "€";
                }
            }
        }

        /// <summary>
        ///  Charge la listBox prestation à partir du fichier chargé.
        /// </summary>
        /// <param name="prestations">Liste FacturePrestation à charger.</param>
        private void ChargerRemplirPrestation(List<FacturePrestation> prestations)
        {
            prestationsCharge.Clear();
            for (int i = 0; i < prestations.Count; i++)
            {
                prestationsCharge.Add(new FacturePrestation(prestations[i].nom, prestations[i].pourcentageTVA));

            }
            UpdateListBoxFromDataSource(lb_Prestation);
        }

        /// <summary>
        ///  Charge la listBox SiteFavoris à partir du fichier chargé.
        /// </summary>
        /// <param name="sitesFav">Liste SiteFavoris à charger.</param>
        private void ChargerRemplirSiteFavoris(List<SiteFavorisLigne> sitesFav)
        {
            sitesFavorisCharge.Clear();
            for (int i = 0; i < sitesFav.Count; i++)
            {
                sitesFavorisCharge.Add(new SiteFavorisLigne(sitesFav[i].nom, sitesFav[i].url));

            }
            UpdateListBoxFromDataSource(lb_SitesFav);
        }

        /// <summary>
        ///  Récupère la valeur de la cellule, si elle est vide alors retourne un str vide, sinon retourne simplement la valeur.
        /// </summary>
        /// <param name="celluleValeur">Valeur de la cellule.</param>
        /// <param name="nomColonne">Nom de la colonne de la cellule.</param>
        private object GetCellValueOuDefaultValue(object celluleValeur, string nomColonne)
        {
            if (celluleValeur == null || celluleValeur == "")
            {
                return "";
            }
            else
            {
                if (nomColonne.Contains("Prix") || nomColonne == "Difference")
                {
                    celluleValeur = ((string)celluleValeur).Replace("€", "");
                    if (float.TryParse(celluleValeur.ToString(), out float floatValue))
                    {
                        return floatValue;
                    }
                }
                return celluleValeur;
            }
        }

        /// <summary>
        ///  Récupère les valeurs du dataGridView inventaire, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de la classe métier InventaireLigne correspondant aux lignes de l'inventaire.</returns>
        public List<InventaireLigne> RecupererInventaireActuelle()
        {
            List<InventaireLigne> inventaireLignes = new List<InventaireLigne> { };
            int id;
            string type;
            string marque;
            string nom;
            string annee;
            float prix;
            int quantite;
            string dateEntree;
            string dateSortie;
            string commentaire;
            dgv_Inventaire.Enabled = false;
            for (int i = 0; i < dgv_Inventaire.Rows.Count; i++)
            {
                id = (int)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["IndexInventaire"].Value, "IndexInventaire");
                type = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["TypeInventaire"].Value, "TypeInventaire");
                marque = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["MarqueInventaire"].Value, "MarqueInventaire");
                nom = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["NomInventaire"].Value, "NomInventaire");
                annee = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["AnneeInventaire"].Value, "AnneeInventaire");
                if (dgv_Inventaire.Rows[i].Cells["PrixInventaire"].Value != null && dgv_Inventaire.Rows[i].Cells["PrixInventaire"].Value != "")
                {
                    prix = (float)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["PrixInventaire"].Value.ToString(), "PrixInventaire"); ;
                }
                else
                {
                    prix = -1;
                }
                object temp = dgv_Inventaire.Rows[i].Cells["QuantiteInventaire"].Value;
                if (temp == null)
                {
                    temp = "1";
                }
                else if (temp.ToString() == "")
                {
                    temp = "1";
                }
                quantite = (int)GetCellValueOuDefaultValue(int.Parse(temp.ToString() ?? "1"), "QuantiteInventaire");
                dateEntree = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["DateEntreeInventaire"].Value, "DateEntreeInventaire");
                dateSortie = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["DateSortieInventaire"].Value, "DateSortieInventaire");
                commentaire = (string)GetCellValueOuDefaultValue(dgv_Inventaire.Rows[i].Cells["CommentaireInventaire"].Value, "CommentaireInventaire");
                InventaireLigne nouvelleLigne = new InventaireLigne(id, type, marque, nom, annee, prix, quantite, dateEntree, dateSortie, commentaire);
                inventaireLignes.Add(nouvelleLigne);
            }
            dgv_Inventaire.Enabled = true;
            return inventaireLignes;
        }

        /// <summary>
        ///  Récupère les valeurs de la listBox marque, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de type de la classe métier InventaireMarque qui correspond aux marques actuelles.</returns>
        public List<InventaireMarque> RecupererMarquesActuelle()
        {
            List<InventaireMarque> marques = new List<InventaireMarque>();
            for (int i = 0; i < lb_Marque.Items.Count; i++)
            {
                InventaireMarque nouvelleMarque = new InventaireMarque(lb_Marque.Items[i].ToString() ?? "");
                marques.Add(nouvelleMarque);
            }
            return marques;
        }

        /// <summary>
        ///  Récupère les valeurs de la listBox type, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de la classe métier InventaireType qui correspond aux types actuelles.</returns>
        public List<InventaireType> RecupererTypesActuelle()
        {
            List<InventaireType> types = new List<InventaireType>();
            for (int i = 0; i < lb_Type.Items.Count; i++)
            {
                InventaireType nouveauType = new InventaireType(lb_Type.Items[i].ToString() ?? "");
                types.Add(nouveauType);
            }
            return types;
        }

        /// <summary>
        ///  Récupère les valeurs du dataGridView facture, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de la classe métier FactureLigne qui correspond aux factures.</returns>
        public List<FactureLigne> RecupererFacturesActuelle()
        {
            List<FactureLigne> factures = new List<FactureLigne>();
            int id;
            string nom;
            string prestation;
            string date;
            string commentaire;
            float prixHT;
            float prixTTC;
            float difference;
            dgv_Facture.Enabled = false;
            for (int i = 0; i < dgv_Facture.Rows.Count; i++)
            {
                id = (int)GetCellValueOuDefaultValue(dgv_Facture.Rows[i].Cells[0].Value, dgv_Facture.Columns[0].Name);
                nom = (string)GetCellValueOuDefaultValue(dgv_Facture.Rows[i].Cells[1].Value, dgv_Facture.Columns[1].Name);
                prestation = (string)GetCellValueOuDefaultValue(dgv_Facture.Rows[i].Cells[2].Value, dgv_Facture.Columns[2].Name);
                date = (string)GetCellValueOuDefaultValue(dgv_Facture.Rows[i].Cells[3].Value, dgv_Facture.Columns[3].Name);
                commentaire = (string)GetCellValueOuDefaultValue(dgv_Facture.Rows[i].Cells[4].Value, dgv_Facture.Columns[4].Name);
                if (dgv_Facture.Rows[i].Cells[5].Value != null && dgv_Facture.Rows[i].Cells[5].Value != "")
                {
                    string value = dgv_Facture.Rows[i].Cells[5].Value.ToString();
                    object t = GetCellValueOuDefaultValue(value, dgv_Facture.Columns[5].Name);
                    prixHT = (float)(t);
                }
                else
                {
                    prixHT = -1;
                }
                if (dgv_Facture.Rows[i].Cells[6].Value != null && dgv_Facture.Rows[i].Cells[6].Value != "")
                {
                    string value = dgv_Facture.Rows[i].Cells[6].Value.ToString();
                    object t = GetCellValueOuDefaultValue(value, dgv_Facture.Columns[6].Name);
                    prixTTC = (float)(t);
                }
                else
                {
                    prixTTC = -1;
                }
                if (dgv_Facture.Rows[i].Cells[7].Value != null && dgv_Facture.Rows[i].Cells[7].Value != "")
                {
                    string value = dgv_Facture.Rows[i].Cells[7].Value.ToString();
                    object t = GetCellValueOuDefaultValue(value, dgv_Facture.Columns[7].Name);
                    difference = (float)(t);
                }
                else
                {
                    difference = -1;
                }
                FactureLigne nouvelleLigne = new FactureLigne(id, nom, prestation, date, commentaire, prixHT, prixTTC, difference);
                factures.Add(nouvelleLigne);
            }
            dgv_Facture.Enabled = true;
            return factures;
        }

        /// <summary>
        ///  Récupère les valeurs de la listBox prestation, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de la classe métier FacturePrestation qui correspond aux prestations actuelles.</returns>
        public List<FacturePrestation> RecupererPrestationsActuelle()
        {
            return lb_Prestation.Items.Cast<FacturePrestation>().ToList();
        }

        /// <summary>
        ///  Récupère les valeurs de la listBox sitesFav, pour pouvoir les sauvegarder dans un fichier.
        /// </summary>
        /// <returns>Retourne une liste de type de la classe métier SiteFavorisLigne qui correspond aux sites favoris actuelles.</returns>
        public List<SiteFavorisLigne> RecupererSitesFavActuelle()
        {
            return lb_SitesFav.Items.Cast<SiteFavorisLigne>().ToList();
        }

        /// <summary>
        ///  Sauvegarde du fichier actuellement ouvert.
        /// </summary>
        private void Sauvegarder()
        {
            dgv_Inventaire.Enabled = false;
            dgv_Inventaire.EndEdit();
            bddManagerRef.EcrireBdd(cheminFichierOuvert);
            dgv_Inventaire.Enabled = true;
        }

        /// <summary>
        ///  Lance la sauvegarde du fichier actuellement ouvert.
        /// </summary>
        private void TSMenuItem_Fichier_Sauvegarder_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }

        /// <summary>
        ///  Lance la sauvegarde d'un nouveau fichier qui va être créer.
        /// </summary>
        private void TSMenuItem_Fichier_SauvegarderSous_Click(object sender, EventArgs e)
        {

            SauvegarderSous();
        }

        /// <summary>
        ///  Crée un nouveau fichier de sauvegarde après le l'utilisateur choisisse le chemin et le nom du fichier.
        /// </summary>
        private void SauvegarderSous()
        {
            dgv_Inventaire.EndEdit();
            string fileName = controleur.OuvrirDialogueSaveFichier();
            if (fileName != "")
            {
                dgv_Inventaire.Enabled = false;
                cheminFichierOuvert = fileName;
                titreFichierOuvert = controleur.GetFileNameSansChemin(cheminFichierOuvert);
                controleur.CallEcrireBDD(cheminFichierOuvert);
                changerFormTitre(false);
                TSMenuItem_Fichier_Sauvegarder.Enabled = true;
                dgv_Inventaire.Enabled = true;
            }
        }

        /// <summary>
        ///  Si des lignes sont ajoutées, mets à jour les cellules nécessaires et actualise la colonne Index du dataGridView inventaire.
        /// </summary>
        private void dgv_Inventaire_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualiserIndexLignesInventaire();
            DataGridViewComboBoxCell comboBoxCellType = (DataGridViewComboBoxCell)dgv_Inventaire.Rows[e.RowIndex].Cells[1];
            DataGridViewComboBoxCell comboBoxCellMarque = (DataGridViewComboBoxCell)dgv_Inventaire.Rows[e.RowIndex].Cells[2];
            UpdateCbCellType(comboBoxCellType);
            UpdateCbCellMarque(comboBoxCellMarque);
        }

        /// <summary>
        ///  Permet de mettre à jour la comboBox de la cellule appartenant à la colonne Type du dataGridView inventaire au niveau de ses options, en se basant sur la listBox type.
        /// </summary>
        private void UpdateCbCellType(DataGridViewComboBoxCell cbType)
        {
            cbType.Items.Clear();
            foreach (string type in lb_Type.Items)
            {
                cbType.Items.Add(type);
            }
        }

        /// <summary>
        ///  Permet de mettre à jour la comboBox de la cellule appartenant à la colonne Marque du dataGridView inventaire au niveau de ses options, en se basant sur la listBox marque.
        /// </summary>
        private void UpdateCbCellMarque(DataGridViewComboBoxCell cbMarque)
        {
            cbMarque.Items.Clear();
            foreach (string type in marquesCharge)
            {
                cbMarque.Items.Add(type);
            }
        }

        /// <summary>
        ///  Permet de mettre à jour la comboBox de la cellule appartenant à la colonne Prestation du dataGridView facture au niveau de ses options, en se basant sur la listBox prestation.
        /// </summary>
        private void UpdateCbCellPrestation(DataGridViewComboBoxCell cbPrestation)
        {
            var ancienneValue = cbPrestation.Value;
            cbPrestation.Items.Clear();
            foreach (FacturePrestation prestation in prestationsCharge)
            {
                cbPrestation.Items.Add(prestation.ToString());
            }
            if (ancienneValue != "" && ancienneValue != null)
            {
                if (cbPrestation.Items.Contains(ancienneValue))
                {
                    cbPrestation.Value = ancienneValue;
                }
                else
                {
                    cbPrestation.Value = null;
                }
            }
        }

        /// <summary>
        ///  Permet de mettre à jour les comboBoxCell de la colonne Type du dataGridView inventaire, à partir de la listBox Type, cela permet de vider l'option choisi si l'option actuellement choisi n'est plus disponible car supprimée dans la listBox.
        /// </summary>
        private void UpdateInventaireColonneType()
        {
            for (int i = 0; i < dgv_Inventaire.Rows.Count; i++)
            {
                DataGridViewCell cellType = dgv_Inventaire.Rows[i].Cells[1];
                if (cellType.Value != null)
                {
                    string actuelleTexte = cellType.Value.ToString() ?? "-844578";
                    if (!(lb_Type.Items.Contains(actuelleTexte)))
                    {
                        cellType.Value = "";
                    }
                }
                UpdateCbCellType((DataGridViewComboBoxCell)cellType);
            }
        }

        /// <summary>
        ///  Permet de mettre à jour les comboBoxCell de la colonne Marque du dataGridView inventaire, à partir de la listBox marque, cela permet de vider l'option choisi si l'option  actuellement choisi n'est plus disponible car supprimée dans la listBox.
        /// </summary>
        private void UpdateInventaireColonneMarque()
        {
            for (int i = 0; i < dgv_Inventaire.Rows.Count; i++)
            {
                DataGridViewCell cellMarque = dgv_Inventaire.Rows[i].Cells[2];
                if (cellMarque.Value != null)
                {
                    string actuelleTexte = cellMarque.Value.ToString() ?? "";
                    if (!(lb_Marque.Items.Contains(actuelleTexte)))
                    {
                        cellMarque.Value = "";
                    }
                }
                UpdateCbCellMarque((DataGridViewComboBoxCell)cellMarque);
            }
        }

        /// <summary>
        ///  Permet de mettre à jour les comboBoxCell de la colonne Prestation du dataGridView facture, à partir de la listBox prestation, cela permet de vider l'option choisi si l'option  actuellement choisi n'est plus disponible car supprimée dans la listBox.
        /// </summary>
        private void UpdateFactureColonnePrestation()
        {
            for (int i = 0; i < dgv_Facture.Rows.Count; i++)
            {
                DataGridViewCell cellPrestation = dgv_Facture.Rows[i].Cells[2];
                UpdateCbCellPrestation((DataGridViewComboBoxCell)cellPrestation);
            }
        }

        /// <summary>
        ///  Permet de cacher les boutons du toolStripMenu selon la page du tabControl choisi, le filtre de recherche est caché ou non, et le placeholderText de la textBox Recherche est aussi changé.
        /// </summary>
        private void tabControl_Inventaire_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl_Inventaire.SelectedIndex != 0)
            {
                DefinirVisibiliteToolStrip(visibiliteToolstrip.CACHEAVECFOND);
            }
            else if (tabControl_Inventaire.SelectedIndex == 0)
            {
                DefinirVisibiliteToolStrip(visibiliteToolstrip.MODIFDGV);
            }
            switch (tabControl_Inventaire.SelectedIndex)
            {
                case 0:
                    txt_Recherche.PlaceholderText = "Rechercher dans l'inventaire";
                    MajCbFiltre(true);

                    break;
                case 1:
                    txt_Recherche.PlaceholderText = "Rechercher dans les marques";
                    MajCbFiltre(false);
                    break;
                case 2:
                    txt_Recherche.PlaceholderText = "Rechercher dans les types";
                    MajCbFiltre(false);
                    break;
            }
        }

        /// <summary>
        ///  Permets de définir quel élément du ToolStrip s'affiche ou non selon l'onglet.
        /// </summary>
        /// <param name="visibilite">Enum visibiliteToolstrip qui permet de simplement choisir une option.</param>
        /// <param name="inclureBtnsEnregistrer">Permet de choisir si on veut afficher les boutons de sauvegarde.</param>
        private void DefinirVisibiliteToolStrip(visibiliteToolstrip visibilite, bool inclureBtnsEnregistrer = false)
        {
            switch (visibilite)
            {
                case visibiliteToolstrip.VISIBLE:
                    ts_Inventaire.Visible = true;
                    break;
                case visibiliteToolstrip.CACHE:
                    ts_Inventaire.Visible = false;
                    break;
                case visibiliteToolstrip.CACHEAVECFOND:
                    btn_SupprimerLigne.Visible = false;
                    btn_AjouterLigne.Visible = false;
                    btn_InsererLigne.Visible = false;
                    btn_CopierLigne.Visible = false;
                    btn_CollerLigne.Visible = false;
                    btn_CouperLigne.Visible = false;
                    btn_ViderLigne.Visible = false;
                    toolStripSeparator2.Visible = false;
                    break;
                case visibiliteToolstrip.MODIFDGV:
                    btn_SupprimerLigne.Visible = true;
                    btn_AjouterLigne.Visible = true;
                    btn_InsererLigne.Visible = true;
                    btn_CopierLigne.Visible = true;
                    btn_CollerLigne.Visible = true;
                    btn_CouperLigne.Visible = true;
                    btn_ViderLigne.Visible = true;
                    toolStripSeparator2.Visible = true;
                    btn_Sauvegarder.Visible = true;
                    btn_SauvegarderSous.Visible = true;
                    break;
            }
            if (visibilite != visibiliteToolstrip.VISIBLE && inclureBtnsEnregistrer)
            {
                btn_Sauvegarder.Visible = false;
                btn_SauvegarderSous.Visible = false;
            }
        }


        /// <summary>
        ///  Permet de déselectionné la marque choisi dans la listBox Marque si on appuie sur échappe.
        /// </summary>
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lb_Marque.SelectedIndex = -1;
            }
        }

        /// <summary>
        ///  Permet de déselectionné le type choisi dans la listBox Type si on appuie sur échappe.
        /// </summary>
        private void lb_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lb_Type.SelectedIndex = -1;
            }
        }

        /// <summary>
        ///  Activé ou non le bouton AjouterMarque selon si le texte AjoutMarque est vide.
        /// </summary>
        private void txt_AjoutMarque_TextChanged(object sender, EventArgs e)
        {
            if (txt_AjoutMarque.Text != "")
            {
                btn_AjouterMarque.Enabled = true;
            }
            else
            {
                btn_AjouterMarque.Enabled = false;
            }
        }

        /// <summary>
        ///  Activé ou non le bouton AjouterType selon si le texte AjoutType est vide.
        /// </summary>
        private void txt_TypeAjouter_TextChanged(object sender, EventArgs e)
        {
            if (txt_AjoutType.Text != "")
            {
                btn_AjouterType.Enabled = true;
            }
            else
            {
                btn_AjouterType.Enabled = false;
            }
        }

        /// <summary>
        ///  Ajoute la marque dans la listBox Marque et actualise ce qui est nécessaire.
        /// </summary>
        private void btn_AjouterMarque_Click(object sender, EventArgs e)
        {
            ViderRecherche();
            lb_Marque.Items.Add(txt_AjoutMarque.Text);
            lb_Marque.SelectedIndex = -1;
            txt_AjoutMarque.Text = "";
            UpdateInventaireColonneMarque();
            DefinirMarqueCharge();
        }

        /// <summary>
        ///  Ajoute le type dans la listBox Type et actualise ce qui est nécessaire.
        /// </summary>
        private void btn_AjouterType_Click(object sender, EventArgs e)
        {
            ViderRecherche();
            lb_Type.Items.Add(txt_AjoutType.Text);
            lb_Type.SelectedIndex = -1;
            txt_AjoutType.Text = "";
            UpdateInventaireColonneType();
            DefinirTypeCharge();
        }

        /// <summary>
        ///  Activé ou non le bouton SupprimerMarque selon si une marque est sélectionné.
        /// </summary>
        private void lb_Marque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Marque.SelectedIndex != -1)
            {
                btn_SupprimerMarque.Enabled = true;
            }
            else
            {
                btn_SupprimerMarque.Enabled = false;
            }
        }

        /// <summary>
        ///  Supprime la marque choisi et mets à jour ce qui est nécessaire.
        /// </summary>
        private void btn_SupprimerMarque_Click(object sender, EventArgs e)
        {
            string saveSelectedItemText = lb_Marque.SelectedItem.ToString() ?? "";
            ViderRecherche();
            lb_Marque.Items.Remove(saveSelectedItemText);
            lb_Marque.SelectedIndex = -1;
            txt_AjoutMarque.Text = "";
            UpdateInventaireColonneMarque();
            DefinirMarqueCharge();
        }

        /// <summary>
        ///  Supprime le type choisi et mets à jour ce qui est nécessaire.
        /// </summary>
        private void btn_SupprimerType_Click(object sender, EventArgs e)
        {
            string saveSelectedItemText = lb_Type.SelectedItem.ToString() ?? "";
            ViderRecherche();
            lb_Type.Items.RemoveAt(lb_Type.SelectedIndex);
            lb_Type.SelectedIndex = -1;
            txt_AjoutType.Text = "";
            UpdateInventaireColonneType();
            DefinirTypeCharge();
        }


        /// <summary>
        ///  Activé ou non le bouton SupprimerType selon si un type est sélectionné.
        /// </summary>
        private void lb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Type.SelectedIndex != -1)
            {
                btn_SupprimerType.Enabled = true;
            }
            else
            {
                btn_SupprimerType.Enabled = false;
            }
        }

        /// <summary>
        ///  Permet d'imposer des conditions selon la colonne quand on entre des valeurs dans les cellules de l'inventaire.
        /// </summary>
        private void dgv_Inventaire_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            dgv_Inventaire.CellValueChanged -= dgv_Inventaire_CellValueChanged;
            if (dgv_Inventaire.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgv_Inventaire.CurrentCell;
                switch (dgv_Inventaire.Columns[currentCell.ColumnIndex].Name)
                {
                    case "PrixInventaire":
                        GererInputPrix(dgv_Inventaire);
                        break;
                    case "QuantiteInventaire":
                        GererInputQuantite(dgv_Inventaire);
                        break;
                    case "DateEntreeInventaire":
                        string cellDateEntreeTexte = (string)(currentCell.Value ?? "");
                        DateTime dateNonUtilise;
                        if (!(DateTime.TryParseExact(cellDateEntreeTexte, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateNonUtilise)))
                        {
                            currentCell.Value = "";
                        }
                        break;
                    case "DateSortieInventaire":
                        string cellDateSortieTexte = (string)(currentCell.Value ?? "");
                        DateTime dateNonUtilise2;
                        if (!(DateTime.TryParseExact(cellDateSortieTexte, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateNonUtilise2)))
                        {
                            currentCell.Value = "";
                        }
                        break;
                }
            }
            dgv_Inventaire.CellValueChanged += dgv_Inventaire_CellValueChanged;
        }

        /// <summary>
        ///  Supprime le lien avec le fichier actuellement ouvert, et permet de faire "page blanche".
        /// </summary>
        private void TSMenuItem_Fichier_Nouveau_Click(object sender, EventArgs e)
        {
            cheminFichierOuvert = "";
            FairePageBlanche();
        }



        /// <summary>
        ///  Si on change le texte de la textBox Recherche, alors recherche dans l'inventaire, dans les marques ou dans les types selon la page tabControl choisi.
        /// </summary>
        private void txt_RechercheInventaire_TextChanged(object sender, EventArgs e)
        {
            switch (ongletPrincipalActuel)
            {
                case ongletPrincipal.INVENTAIRE:
                    switch (tabControl_Inventaire.SelectedIndex)
                    {
                        case 0:
                            Rechercher(typeRecherche.INVENTAIRE);
                            break;
                        case 1:
                            Rechercher(typeRecherche.MARQUE);
                            break;
                        case 2:
                            Rechercher(typeRecherche.TYPE);
                            break;
                    }
                    break;
                case ongletPrincipal.FACTURES:
                    switch (tabControl_Facture.SelectedIndex)
                    {
                        case 0:
                            Rechercher(typeRecherche.FACTURES);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        ///  Mets à jour un dataGridView à partir d'une liste de rows.
        /// </summary>
        /// <param name="dgv">Permet de choisir le dataGridView.</param>
        /// <param name="savedRows">Permet de passer les rows qui vont peupler le dataGridView choisi.</param>
        private void MajDGV(DataGridView dgv, List<DataGridViewRow> savedRows)
        {
            dgv.Rows.Clear();
            foreach (DataGridViewRow row in savedRows)
            {
                dgv.Rows.Add(row);
            }
        }

        /// <summary>
        ///  Mets à jour une listBox à partir d'une liste de str.
        /// </summary>
        /// <param name="listBox">Permet de choisir la listBox.</param>
        /// <param name="savedItems">Permet de passer les items qui vont peupler la listBox choisi.</param>
        private void MajListBox(ListBox listBox, List<string> savedItems)
        {
            listBox.Items.Clear();
            foreach (string item in savedItems)
            {
                listBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Permet de faire une recherche selon le type de recherche.
        /// </summary>
        /// <param name="type">Le type de la recherche, c'est un enum qui revient à certains onglets et sous-onglets en particulier.</param>
        private void Rechercher(typeRecherche type)
        {
            string txtRecherche = txt_Recherche.Text;
            int filtreSelectedIndex = cb_FiltreRecherche.SelectedIndex;
            switch (type)
            {
                case typeRecherche.INVENTAIRE:
                    MajDGV(dgv_Inventaire, inventaireRowsCharge);
                    foreach (int i in controleur.RechercherInventaire(inventaireRowsCharge, txtRecherche, filtreSelectedIndex))
                    {
                        dgv_Inventaire.Rows.RemoveAt(i);
                    }
                    break;
                case typeRecherche.MARQUE:
                    MajListBox(lb_Marque, marquesCharge);
                    foreach (int i in controleur.RechercherMarque(marquesCharge, txtRecherche, filtreSelectedIndex))
                    {
                        lb_Marque.Items.RemoveAt(i);
                    }
                    break;
                case typeRecherche.TYPE:
                    MajListBox(lb_Type, typesCharge);
                    foreach (int i in controleur.RechercherType(typesCharge, txtRecherche, filtreSelectedIndex))
                    {
                        lb_Type.Items.RemoveAt(i);
                    }
                    break;
                case typeRecherche.FACTURES:
                    MajDGV(dgv_Facture, factureRowsCharge);
                    foreach (int i in controleur.RechercherFacture(factureRowsCharge, txtRecherche, filtreSelectedIndex))
                    {
                        dgv_Facture.Rows.RemoveAt(i);
                    }
                    break;
            }
        }



        /// <summary>
        ///  Permet de sauvegarder dans la variable "inventaireRowsCharge" l'inventaire, cette procédure est nécessaire dans la recherche dans l'inventaire car à chaque recherche on "vide" la dataGridView, il faut donc la re-remplir pour refaire une recherche.
        /// </summary>
        public void DefinirInventaireRowsCharge()
        {
            inventaireRowsCharge.Clear();
            foreach (DataGridViewRow row in dgv_Inventaire.Rows)
            {
                inventaireRowsCharge.Add(row);
            }
        }

        /// <summary>
        ///  Permet de sauvegarder dans la variable "factureRowsCharge" les factures, cette procédure est nécessaire dans la recherche dans la facture car à chaque recherche on "vide" la dataGridView, il faut donc la re-remplir pour refaire une recherche.
        /// </summary>
        public void DefinirFactureRowsCharge()
        {
            factureRowsCharge.Clear();
            foreach (DataGridViewRow row in dgv_Facture.Rows)
            {
                factureRowsCharge.Add(row);
            }
        }

        /// <summary>
        ///  Permet de sauvegarder dans la variable "marquesCharge" la listBox marque, cette procédure est nécessaire dans la recherche de marque car à chaque recherche on "vide" la listBox, il faut donc la re-remplir pour refaire une recherche.
        /// </summary>
        private void DefinirMarqueCharge()
        {
            marquesCharge = lb_Marque.Items.OfType<string>().ToList();
        }

        /// <summary>
        ///  Permet de sauvegarder dans la variable "typesCharge" la listBox type, cette procédure est nécessaire dans la recherche de type car à chaque recherche on "vide" la listBox, il faut donc la re-remplir pour refaire une recherche.
        /// </summary>
        private void DefinirTypeCharge()
        {
            typesCharge = lb_Type.Items.OfType<string>().ToList();
        }


        /// <summary>
        ///  Si la FormGestion est redimensionné, alors cache les dateTimePicker InventaireEntreeDate, InventaireSortieDate et FactureDate.
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            dtpInventaireDateEntree.Visible = false;
            dtpInventaireDateSortie.Visible = false;
            dtpFactureDate.Visible = false;
        }

        /// <summary>
        ///  Si le filtre de recherche est changé, alors relance la recherche.
        /// </summary>
        private void cb_FiltreRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ongletPrincipalActuel)
            {
                case ongletPrincipal.INVENTAIRE:
                    Rechercher(typeRecherche.INVENTAIRE);
                    break;
                case ongletPrincipal.FACTURES:
                    Rechercher(typeRecherche.FACTURES);
                    break;
            }
        }

        /// <summary>
        ///  Arrete la recherche et lance l'ajout d'une ligne à l'inventaire ou aux factures.
        /// </summary>
        private void btn_AjouterLigneInventaire_Click_1(object sender, EventArgs e)
        {
            if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
            {
                ViderRecherche();
                AjouterLigneInventaire();
            }
            else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
            {
                ViderRecherche();
                AjouterLigneFacture();
            }
        }

        /// <summary>
        ///  Si la variable "confirmationAvantSuppression" est vrai, alors crée une boite de dialogue de confirmation avant de lancer la suppression des lignes.
        /// </summary>
        private void btn_SupprimerLigneInventaire_Click_1(object sender, EventArgs e)
        {
            if (confirmationAvantSuppression)
            {
                string message;
                if (dgv_Inventaire.SelectedRows.Count > 1)
                {
                    message = "Voulez-vous vraiment supprimer les lignes sélectionnés ?";
                }
                else
                {
                    message = "Voulez-vous vraiment supprimer la ligne sélectionné ?";
                }
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
                    {
                        SupprimerLignesInventaire();
                    }
                    else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
                    {
                        SupprimerLignesFacture();
                    }
                }
            }
            else
            {
                if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
                {
                    SupprimerLignesInventaire();
                }
                else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
                {
                    SupprimerLignesFacture();
                }
            }
        }

        /// <summary>
        /// Supprime des lignes de la dataGriwView inventaire en mettant à jour certaines choses par la même occasion.
        /// </summary>
        private void SupprimerLignesInventaire()
        {
            txt_Recherche.Text = "";
            foreach (DataGridViewRow row in dgv_Inventaire.SelectedRows)
            {
                dgv_Inventaire.Rows.Remove(row);
            }
            ActualiserIndexLignesInventaire();
            DefinirInventaireRowsCharge();
        }

        /// <summary>
        ///  Supprime des lignes de la dataGriwView facture en mettant à jour certaines choses par la même occasion.
        /// </summary>
        public void SupprimerLignesFacture()
        {
            txt_Recherche.Text = "";
            foreach (DataGridViewRow ligne in dgv_Facture.SelectedRows)
            {
                dgv_Facture.Rows.Remove(ligne);
            }
            ActualiserIndexLignesFacture();
            DefinirFactureRowsCharge();
        }

        /// <summary>
        ///  Lance l'insertion de ligne à l'inventaire ou aux factures.
        /// </summary>
        private void btn_InsererLigneInventaire_Click(object sender, EventArgs e)
        {
            ViderRecherche();
            if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
            {
                InsererLigneInventaire((int)dgv_Inventaire.CurrentRow.Cells["IndexInventaire"].Value);
            }
            else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
            {
                InsererLigneFacture((int)dgv_Facture.CurrentRow.Cells["IndexFacture"].Value);
            }
        }

        /// <summary>
        ///  Permet d'insérer une ligne dans la dataGridView inventaire, insérer avant ou après la ligne séléctionné selon l'option choisi.
        /// </summary>
        public void InsererLigneInventaire(int indexRowSelected)
        {
            txt_Recherche.Text = "";
            if (insertionAvant)
            {
                dgv_Inventaire.Rows.Insert(indexRowSelected, "");
            }
            else
            {
                dgv_Inventaire.Rows.Insert(indexRowSelected + 1, "");
            }
        }

        /// <summary>
        ///  Permet d'insérer une ligne dans la dataGridView facture, insérer avant ou après la ligne séléctionné selon l'option choisi.
        /// </summary>
        public void InsererLigneFacture(int indexRowSelected)
        {
            txt_Recherche.Text = "";
            if (insertionAvant)
            {
                dgv_Facture.Rows.Insert(indexRowSelected, "");
            }
            else
            {
                dgv_Facture.Rows.Insert(indexRowSelected + 1, "");
            }
        }

        /// <summary>
        ///  Lance la copie de ligne de l'inventaire ou aux factures.
        /// </summary>
        private void btn_CopierLigne_Click(object sender, EventArgs e)
        {
            if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
            {
                CopierLignesInventaire();
            }
            else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
            {
                CopierLignesFacture();
            }
        }

        /// <summary>
        /// Copie les lignes actuellement séléctionnées dans une variable.
        /// </summary>
        private void CopierLignesFacture()
        {
            rowsFactureCopiee.Clear();
            foreach (DataGridViewRow row in dgv_Facture.SelectedRows)
            {
                DataGridViewRow clone = (DataGridViewRow)row.Clone();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    clone.Cells[i].Value = row.Cells[i].Value;
                }
                rowsFactureCopiee.Insert(0, clone);
            }
            txt_Recherche.Text = "";
            btn_CollerLigne.Enabled = true;
        }

        /// <summary>
        /// Copie les lignes actuellement séléctionnées dans une variable.
        /// </summary>
        private void CopierLignesInventaire()
        {
            rowsInventaireCopiee.Clear();
            foreach (DataGridViewRow row in dgv_Inventaire.SelectedRows)
            {
                DataGridViewRow clone = (DataGridViewRow)row.Clone();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    clone.Cells[i].Value = row.Cells[i].Value;
                }
                rowsInventaireCopiee.Add(clone);
            }
            txt_Recherche.Text = "";
            btn_CollerLigne.Enabled = true;
        }

        /// <summary>
        ///  Lance le fait de coller les lignes copiées à l'inventaire ou aux factures.
        /// </summary>
        private void btn_CollerLigne_Click(object sender, EventArgs e)
        {
            if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
            {
                CollerLignesInventaire();
            }
            else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
            {
                CollerLignesFacture();
            }
        }

        /// <summary>
        /// Colle les lignes sauvegardées dans le dataGridView facture.
        /// </summary>
        private void CollerLignesFacture()
        {
            txt_Recherche.Text = "";
            Dictionary<int, DataGridViewRow> nouvelleRows = controleur.GetDgvRowsApresCollageLignes(dgv_Facture.Rows, dgv_Facture.SelectedRows, rowsFactureCopiee, dgv_Facture.ColumnCount);
            foreach (KeyValuePair<int, DataGridViewRow> item in nouvelleRows)
            {
                dgv_Facture.Rows.RemoveAt(item.Key);
                dgv_Facture.Rows.Insert(item.Key, item.Value);
            }
            ActualiserIndexLignesInventaire();
            if (couperLignes)
            {
                couperLignes = false;
                btn_CollerLigne.Enabled = false;
                rowsFactureCopiee.Clear();
            }
        }

        /// <summary>
        /// Colle les lignes sauvegardées dans le dataGridView facture.
        /// </summary>
        private void CollerLignesInventaire()
        {
            txt_Recherche.Text = "";
            Dictionary<int, DataGridViewRow> nouvelleRows = controleur.GetDgvRowsApresCollageLignes(dgv_Inventaire.Rows, dgv_Inventaire.SelectedRows, rowsInventaireCopiee, dgv_Inventaire.ColumnCount);
            foreach (KeyValuePair<int, DataGridViewRow> item in nouvelleRows)
            {
                foreach (DataGridViewColumn col in dgv_Inventaire.Columns)
                {
                    if (item.Value.Cells[col.Index].Value != null)
                    {
                        dgv_Inventaire.Rows[item.Key].Cells[col.Index].Value = item.Value.Cells[col.Index].Value.ToString();
                    }
                    else
                    {
                        dgv_Inventaire.Rows[item.Key].Cells[col.Index].Value = "";
                    }
                }
            }
            ActualiserIndexLignesInventaire();
            if (couperLignes)
            {
                couperLignes = false;
                btn_CollerLigne.Enabled = false;
                rowsInventaireCopiee.Clear();
            }
        }

        /// <summary>
        ///  Lance la coupe de ligne de l'inventaire ou aux factures.
        /// </summary>
        private void btn_CouperLigneInventaire_Click(object sender, EventArgs e)
        {
            if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
            {
                CouperLignesInventaire();
            }
            else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
            {
                CouperLignesFacture();
            }
        }

        /// <summary>
        ///  Permet de "couper" donc copier puis vider les rows copiées, on peut coller une fois après la coupe.
        /// </summary>
        private void CouperLignesFacture()
        {
            CopierLignesFacture();
            ViderLignes(dgv_Facture);
            couperLignes = true;
        }

        /// <summary>
        ///  Permet de "couper" donc copier puis vider les rows copiées, on peut coller une fois après la coupe.
        /// </summary>
        private void CouperLignesInventaire()
        {
            CopierLignesInventaire();
            ViderLignes(dgv_Inventaire);
            couperLignes = true;

        }

        /// <summary>
        ///  Lance le fait de vider la ou les lignes.
        /// </summary>
        private void btn_ViderLigneInventaire_Click(object sender, EventArgs e)
        {
            if (confirmationAvantVider)
            {
                string message;
                if (dgv_Inventaire.SelectedRows.Count > 1)
                {
                    message = "Voulez-vous vraiment vider les lignes sélectionnés ?";
                }
                else
                {
                    message = "Voulez-vous vraiment vider la ligne sélectionné ?";
                }
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
                    {
                        ViderLignes(dgv_Inventaire);
                    }
                    else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
                    {
                        ViderLignes(dgv_Facture);
                    }
                }
            }
            else
            {
                if (ongletPrincipalActuel == ongletPrincipal.INVENTAIRE)
                {
                    ViderLignes(dgv_Inventaire);
                }
                else if (ongletPrincipalActuel == ongletPrincipal.FACTURES)
                {
                    ViderLignes(dgv_Facture);
                }
            }
        }

        /// <summary>
        ///  Permet de "clear" les rows séléctionnées, de les vider.
        /// </summary>
        public void ViderLignes(DataGridView dgv)
        {
            if (dgv != dgv_Facture)
            {
                for (int i = (dgv.SelectedRows.Count - 1); i > -1; i--)
                {
                    for (int e = 1; e < dgv.ColumnCount; e++)
                    {
                        if (dgv.Columns[e].Name != "QuantiteInventaire")
                        {
                            dgv.Rows[dgv.SelectedRows[i].Index].Cells[e].Value = "";
                        }
                        else
                        {
                            dgv.Rows[dgv.SelectedRows[i].Index].Cells[e].Value = "1";
                        }
                    }
                }
            }
            else
            {
                for (int i = (dgv.SelectedRows.Count - 1); i > -1; i--)
                {
                    for (int e = 1; e < dgv.ColumnCount; e++)
                    {
                        dgv.Rows[dgv.SelectedRows[i].Index].Cells[e].Value = "";
                    }
                }
            }
        }

        /// <summary>
        ///  Si l'application se ferme alors demande confirmation à partir d'une boite de dialogue.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Sauvegarder avant de quitter ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (confirmation == DialogResult.Yes)
            {
                if (cheminFichierOuvert != "")
                {
                    Sauvegarder();
                }
                else
                {
                    SauvegarderSous();
                }
            }
            else if (confirmation == DialogResult.No)
            {
                DialogResult confirmation2 = MessageBox.Show("Êtes-vous sûr ?", "Confirmation", MessageBoxButtons.YesNo);
                if (confirmation2 == DialogResult.Yes)
                {
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        ///  Permet de définir si l'insertion sera fait après ou avant la ligne choisie, à partir d'une comboBox dans un toolStripMenuItem.
        /// </summary>
        private void TSMenuItem_Preferences_InsertionLigne_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TSMenuItem_Preferences_InsertionLigne_Cb.SelectedIndex)
            {
                case 0:
                    insertionAvant = true;
                    break;
                case 1:
                    insertionAvant = false;
                    break;
            }
        }

        /// <summary>
        ///  Crée une boite de dialogue de couleur pour permettre de choisir la couleur primaire de l'application.
        /// </summary>
        private void TSMenuItem_Preferences_Theme_CouleurP_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = couleurP;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                couleurP = colorDialog1.Color;
                TSMenuItem_Preferences_Theme_CouleurP.ForeColor = couleurP;
                ChangerCouleur();
            }
        }

        /// <summary>
        ///  Crée une boite de dialogue de couleur pour permettre de choisir la couleur secondaire de l'application.
        /// </summary>
        private void TSMenuItem_Preferences_Theme_CouleurS_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = couleurS;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                couleurS = colorDialog1.Color;
                TSMenuItem_Preferences_Theme_CouleurS.ForeColor = couleurS;
                ChangerCouleur();
            }
        }

        /// <summary>
        ///  Crée une boite de dialogue de couleur pour permettre de choisir la couleur tertiaire de l'application.
        /// </summary>
        private void TSMenuItem_Preferences_Theme_CouleurT_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = couleurT;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                couleurT = colorDialog1.Color;
                TSMenuItem_Preferences_Theme_CouleurT.ForeColor = couleurT;
                ChangerCouleur();
            }
        }

        /// <summary>
        ///  Change les couleurs de l'application.
        /// </summary>
        private void ChangerCouleur()
        {
            //Primaire
            this.BackColor = couleurP;
            tab_Inventaire.ForeColor = couleurP;
            tab_Marque.ForeColor = couleurP;
            tab_Type.ForeColor = couleurP;
            tabControl_Facture.ForeColor = couleurP;
            tabControl_Inventaire.ForeColor = couleurP;
            tabControl_Onglets.ForeColor = couleurP;
            //Secondaire
            ts_Inventaire.BackColor = couleurS;
            menuStrip1.BackColor = couleurS;
            //Tertiaire
            dgv_Inventaire.BackgroundColor = couleurT;
            dgv_Facture.BackgroundColor = couleurT;
        }

        /// <summary>
        ///  Initialise les couleurs des toolStripMenuItem correspondant aux couleurs primaire, secondaire et tertiaire.
        /// </summary>
        private void InitialiserCouleurThemeMenuItem()
        {
            TSMenuItem_Preferences_Theme_CouleurP.ForeColor = couleurP;
            TSMenuItem_Preferences_Theme_CouleurS.ForeColor = couleurS;
            TSMenuItem_Preferences_Theme_CouleurT.ForeColor = couleurT;
        }

        /// <summary>
        ///  Permet d'utiliser les fameux raccourcis CTRL+X pour couper, CTRL+C pour copier, CTRL+V pour coller, ici pour l'inventaire.
        /// </summary>
        private void dgv_Inventaire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (dgv_Inventaire.SelectedRows.Count != 0 && btn_CopierLigne.Enabled)
                {
                    CopierLignesInventaire();
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (dgv_Inventaire.SelectedRows.Count != 0 && btn_CollerLigne.Enabled)
                {
                    CollerLignesInventaire();
                }
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                if (dgv_Inventaire.SelectedRows.Count != 0 && btn_CouperLigne.Enabled)
                {
                    CouperLignesInventaire();
                }
            }
        }

        /// <summary>
        /// Déclenche la sauvegarde.
        /// </summary>
        private void btn_Sauvegarder_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }

        /// <summary>
        /// Déclenche la sauvegarde sous, ce qui revient à la création du fichier de sauvegarde.
        /// </summary>
        private void btn_SauvegarderSous_Click(object sender, EventArgs e)
        {
            SauvegarderSous();
        }

        /// <summary>
        /// Permet de réagir au changement d'onglet en mettant à jour certaines choses.
        /// </summary>
        private void tabControl_Onglets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ongletPrincipalActuel = (ongletPrincipal)tabControl_Onglets.SelectedIndex;
            switch (ongletPrincipalActuel)
            {
                case ongletPrincipal.TABDEBORD:
                    MajGraphiquesTabDeBord();
                    DefinirVisibiliteToolStrip(visibiliteToolstrip.CACHEAVECFOND);
                    MajCbFiltre(false);
                    txt_Recherche.Visible = false;
                    lbl_RechercheInventaire.Visible = false;
                    break;
                case ongletPrincipal.INVENTAIRE:
                    DefinirVisibiliteToolStrip(visibiliteToolstrip.MODIFDGV);
                    MajCbFiltre(true);
                    tabControl_Inventaire_Selecting(null, null);
                    dgv_Inventaire_SelectionChanged(null, null);
                    txt_Recherche.Visible = true;
                    lbl_RechercheInventaire.Visible = true;
                    btn_CollerLigne.Enabled = (rowsInventaireCopiee.Count != 0);
                    break;
                case ongletPrincipal.FACTURES:
                    DefinirVisibiliteToolStrip(visibiliteToolstrip.MODIFDGV);
                    MajCbFiltre(true);
                    tabControl_FactureOnglet_SelectedIndexChanged(null, null);
                    dgv_Facture_SelectionChanged(null, null);
                    txt_Recherche.Visible = true;
                    lbl_RechercheInventaire.Visible = true;
                    btn_CollerLigne.Enabled = (rowsFactureCopiee.Count != 0);
                    break;
                case ongletPrincipal.SITESFAV:
                    DefinirVisibiliteToolStrip(visibiliteToolstrip.CACHEAVECFOND);
                    MajCbFiltre(false);
                    txt_Recherche.Visible = true;
                    txt_Recherche.PlaceholderText = "Rechercher dans les sites favoris";
                    lbl_RechercheInventaire.Visible = true;
                    break;
            }
        }

        /// <summary>
        ///  Ajoute une ligne dans la dataGridView facture et sauvegarde ses lignes temporairement dans une collection.
        /// </summary>
        private void AjouterLigneFacture()
        {
            dgv_Facture.Sort(dgv_Facture.Columns[0], ListSortDirection.Ascending);
            dgv_Facture.Rows.Add();
            DefinirFactureRowsCharge();
        }


        /// <summary>
        ///  Actualise la colonne index de la dataGridView facture pour que les nombres se suivent.
        /// </summary>
        public void ActualiserIndexLignesFacture()
        {
            for (int i = 0; i < dgv_Facture.RowCount; i++)
            {
                dgv_Facture.Rows[i].Cells["IndexFacture"].Value = i;
            }
        }

        /// <summary>
        /// Si des lignes sont supprimés, alors actualise les index des lignes.
        /// </summary>
        private void dgv_Facture_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualiserIndexLignesFacture();
        }

        /// <summary>
        ///  Si des lignes sont ajoutées, mets à jour les cellules nécessaires et actualise la colonne Index.
        /// </summary>
        private void dgv_Facture_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualiserIndexLignesFacture();
            DataGridViewComboBoxCell comboBoxCellPrestation = (DataGridViewComboBoxCell)dgv_Facture.Rows[e.RowIndex].Cells[2];
            UpdateCbCellPrestation(comboBoxCellPrestation);
        }


        /// <summary>
        ///  Si scroll sur la dataGridView facture, alors cache le dateTimePicker.
        /// </summary>
        private void dgv_Facture_Scroll(object sender, ScrollEventArgs e)
        {
            dtpFactureDate.Visible = false;
        }

        /// <summary>
        ///  Si clique sur une cellule appartenant à la colonne de la date de la facture, alors fait apparaitre un dateTimePicker.
        /// </summary>
        private void dgv_Facture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                dgv_Facture.EndEdit();
                DataGridViewCell cell = dgv_Facture.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (dgv_Facture.Columns[e.ColumnIndex].Name)
                {
                    case "DateFacture":
                        dtpFactureDate.Visible = false;
                        rectangleDtpFactureDate = dgv_Facture.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtpFactureDate.Size = new Size(rectangleDtpFactureDate.Width, rectangleDtpFactureDate.Height);
                        dtpFactureDate.Location = new Point(rectangleDtpFactureDate.X, rectangleDtpFactureDate.Y);
                        dtpFactureDate.Visible = true;
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString() != "")
                            {
                                dtpFactureDate.Value = DateTime.ParseExact(cell.Value.ToString() ?? "", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                        }
                        break;
                    default:
                        dtpFactureDate.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Mise à jour du comboBox Filtre, l'idée est de changer le contenu du comboBox selon l'onglet actuelle.
        /// </summary>
        /// <param name="rendreVisible"></param>
        /// <param name="clear"></param>
        private void MajCbFiltre(bool rendreVisible, bool clear = true)
        {
            cb_FiltreRecherche.Visible = rendreVisible;
            lbl_Filtre.Visible = rendreVisible;
            if (!rendreVisible)
            {
                cb_FiltreRecherche.SelectedIndex = 0;
                cb_FiltreRecherche_SelectedIndexChanged(null, null);
                return;
            }
            if (clear)
            {
                cb_FiltreRecherche.Items.Clear();
            }
            cb_FiltreRecherche.Items.Add("Pas de filtre");
            switch (ongletPrincipalActuel)
            {
                case ongletPrincipal.INVENTAIRE:
                    for (int i = 1; i < dgv_Inventaire.Columns.Count; i++)
                    {
                        cb_FiltreRecherche.Items.Add(dgv_Inventaire.Columns[i].HeaderText);
                    }
                    break;
                case ongletPrincipal.FACTURES:
                    for (int i = 1; i < dgv_Facture.Columns.Count; i++)
                    {
                        cb_FiltreRecherche.Items.Add(dgv_Facture.Columns[i].HeaderText);
                    }
                    break;
            }
            cb_FiltreRecherche.SelectedIndex = 0;
            cb_FiltreRecherche_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Permet simplement de retirer le focus de la textBox txtRecherche en mettant le focus sur un label quelconque.
        /// </summary>
        private void RetirerFocusDeTxtRecherche()
        {
            lbl_RechercheInventaire.Focus();
        }

        /// <summary>
        /// Permet de mettre à jour la listBox prestation.
        /// </summary>
        /// <param name="lb">La listBox affectée.</param>
        public void UpdateListBoxFromDataSource(ListBox lb)
        {
            object dataSourceSaved = lb.DataSource;
            lb.DataSource = null;
            lb.DataSource = dataSourceSaved;
        }

        /// <summary>
        ///  Si double clique sur une cellule appartenant à la colonne Index alors séléctionne la ligne.
        /// </summary>
        private void dgv_Facture_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                switch (dgv_Facture.Columns[e.ColumnIndex].Name)
                {
                    case "IndexFacture":
                        dgv_Facture.Rows[e.RowIndex].Selected = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Définit les variables par défaut, utilisés pour la page blanche ("Nouveau fichier").
        /// </summary>
        private void DefinirVariablesDefaut()
        {
            defautMarquesCharge = marquesCharge.ToList();
            defautTypesCharge = typesCharge.ToList();
            defautPrestationsCharge = new List<FacturePrestation>();
            defautPrestationsCharge.Add(new FacturePrestation("Vente de produit", 13f));
            defautPrestationsCharge.Add(new FacturePrestation("Service main d'oeuvre ", 23f));
        }

        /// <summary>
        ///  Permet d'imposer des conditions selon la colonne quand on entre des valeurs dans les cellules.
        /// </summary>
        private void dgv_Facture_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            dgv_Facture.CellValueChanged -= dgv_Facture_CellValueChanged;
            string currentCellStr;
            DataGridViewCell currentCell = dgv_Facture.CurrentCell;
            if (currentCell != null)
            {
                switch (dgv_Facture.Columns[currentCell.ColumnIndex].Name)
                {
                    case "DateFacture":
                        currentCellStr = (string)(currentCell.Value ?? "");
                        DateTime dateNonUtilise;
                        if (!(DateTime.TryParseExact(currentCellStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateNonUtilise)))
                        {
                            currentCell.Value = "";
                        }
                        break;
                    case "PrixHT":
                        GererInputPrix(dgv_Facture);
                        if (currentCell.Value != null)
                        {
                            DefinirCellsLieTVA(currentCell, false);
                        }
                        else
                        {
                            DefinirCellsLieTVA(currentCell, false, true);
                        }
                        break;
                    case "PrixTTC":
                        GererInputPrix(dgv_Facture);
                        if (currentCell.Value != null)
                        {
                            DefinirCellsLieTVA(dgv_Facture.Rows[currentCell.RowIndex].Cells[5], true);
                        }
                        else
                        {
                            DefinirCellsLieTVA(dgv_Facture.Rows[currentCell.RowIndex].Cells[5], true, true);
                        }
                        break;
                    case "PrestationFacture":
                        if (dgv_Facture.Rows[currentCell.RowIndex].Cells[5].Value != null)
                        {
                            DefinirCellsLieTVA(dgv_Facture.Rows[currentCell.RowIndex].Cells[5], false);
                        }
                        else if (dgv_Facture.Rows[currentCell.RowIndex].Cells[6].Value != null)
                        {
                            DefinirCellsLieTVA(dgv_Facture.Rows[currentCell.RowIndex].Cells[5], true);
                        }
                        break;
                }
            }
            dgv_Facture.CellValueChanged += dgv_Facture_CellValueChanged;
        }

        /// <summary>
        /// Permet de générer à la volée les valeurs des cells lié à la TVA : prixHT, prixTTC et difference.
        /// </summary>
        /// <param name="cellHT">Cellule prixHT en question.</param>
        /// <param name="depuisCellTTC">Bool permettant de savoir si l'utilisateur entre une nouvelle valeur dans la cellule prixHT ou dans prixTTC.</param>
        /// <param name="clearCellsLieTVA">Bool permettant de savoir si on veut vider les cellules lié à la TVA de la row concernée.</param>
        public void DefinirCellsLieTVA(DataGridViewCell cellHT, bool depuisCellTTC, bool clearCellsLieTVA = false)
        {
            float tva = -1f;
            DataGridViewCell dgvCellPrixTTC = dgv_Facture.Rows[cellHT.RowIndex].Cells[6];
            DataGridViewCell dgvCellDifference = dgv_Facture.Rows[cellHT.RowIndex].Cells[7];
            DataGridViewCell dgvCellPrestation = dgv_Facture.Rows[cellHT.RowIndex].Cells[2];
            if (clearCellsLieTVA)
            {
                cellHT.Value = null;
                dgvCellPrixTTC.Value = null;
                dgvCellDifference.Value = null;
                return;
            }
            else if (dgvCellPrestation.Value != null && dgvCellPrestation.Value != "")
            {
                tva = controleur.SeparerPrestationNomPourcentage((string)dgvCellPrestation.Value).Item2;
            }
            else
            {
                return;
            }
            float prixHT;
            string cellHTStr = (string)(cellHT.Value ?? "");
            string cellprixTTCStr = (string)(dgvCellPrixTTC.Value ?? "");
            DataGridViewComboBoxCell prestationCell = (DataGridViewComboBoxCell)dgv_Facture.Rows[cellHT.RowIndex].Cells[2];
            int indexPrestation = prestationCell.Items.IndexOf(((string)prestationCell.Value) ?? "");
            if (depuisCellTTC && cellprixTTCStr != "")
            {
                float prixTTC = float.Parse(cellprixTTCStr.Replace("€", ""));
                cellHT.Value = Math.Round((decimal)(prixTTC / (1 + tva)), 2) + "€";
                cellHTStr = (string)(cellHT.Value ?? "");
                prixHT = float.Parse(cellHTStr.Replace("€", ""));
                dgvCellDifference.Value = Math.Round((decimal)(prixHT * tva), 2) + "€";
            }
            else
            {
                prixHT = float.Parse(cellHTStr.Replace("€", ""));
                dgvCellPrixTTC.Value = Math.Round((decimal)(prixHT * (1 + tva)), 2) + "€";
                dgvCellDifference.Value = Math.Round((decimal)(prixHT * tva), 2) + "€";
            }
        }

        /// <summary>
        /// Permet d'empêcher l'utilistateur d'entrer autre chose qu'un entier dans une cellule de dataGridView.
        /// </summary>
        /// <param name="dgv">Le dataGridView utilisé.</param>
        private void GererInputQuantite(DataGridView dgv)
        {
            string cellQuantiteTexte = (string)(dgv.CurrentCell.Value ?? " ");
            if (!cellQuantiteTexte.All(char.IsDigit) || float.Parse(cellQuantiteTexte) <= 0f)
            {
                dgv.CurrentCell.Value = 1;
            }
        }

        /// <summary>
        /// Permet d'empêcher l'utilistateur d'entrer autre chose qu'un prix dans une cellule de dataGridView, cela revient à un float autorisant également le signe €.
        /// </summary>
        /// <param name="dgv">Le dataGridView utilisé.</param>
        public void GererInputPrix(DataGridView dgv)
        {
            string cellPrixTexte = (string)(dgv.CurrentCell.Value ?? " ");
            string cellPrixTexteSansEuro = cellPrixTexte;
            char premierCharPrixTexteSansEuro = cellPrixTexteSansEuro[0];
            char dernierCharPrixTexteSansEuro = cellPrixTexteSansEuro[cellPrixTexteSansEuro.Length - 1];
            char caractereAvantEuro;
            bool virguleMalPlace = false;
            bool charEuroMalPlace = false;
            cellPrixTexteSansEuro = cellPrixTexteSansEuro.Replace("€", "");
            if (premierCharPrixTexteSansEuro == ',' || premierCharPrixTexteSansEuro == '.' || dernierCharPrixTexteSansEuro == ',' || dernierCharPrixTexteSansEuro == '.' || cellPrixTexteSansEuro.Count(f => f == ',') > 1 || cellPrixTexteSansEuro.Count(f => f == '.') > 1)
            {
                virguleMalPlace = true;
            }
            if (!cellPrixTexte.Contains("€"))
            {
                cellPrixTexte = cellPrixTexte + "€";
            }
            if (cellPrixTexte.IndexOf("€") == (cellPrixTexte.Length - 1))
            {
                caractereAvantEuro = cellPrixTexte[cellPrixTexte.IndexOf("€") - 1];
                charEuroMalPlace = !(char.IsDigit(caractereAvantEuro) && caractereAvantEuro != 0);
            }
            else
            {
                charEuroMalPlace = true;
            }
            if (cellPrixTexte.Any(char.IsDigit))
            {
                cellPrixTexte = cellPrixTexte.Replace(",", "");
                cellPrixTexte = cellPrixTexte.Replace(".", "");
                cellPrixTexte = cellPrixTexte.Replace("€", "");
                if ((charEuroMalPlace || virguleMalPlace || !cellPrixTexte.All(char.IsDigit)))
                {
                    dgv.CurrentCell.Value = null;
                }
                else if (dgv.CurrentCell.Value != null)
                {
                    string actuelleText = dgv.CurrentCell.Value.ToString() as string ?? string.Empty;
                    dgv.CurrentCell.Value = actuelleText.Replace('.', ',');
                    if (!((string)dgv.CurrentCell.Value).Contains("€"))
                    {
                        dgv.CurrentCell.Value = dgv.CurrentCell.Value + "€";
                    }
                }
            }
            else
            {
                dgv.CurrentCell.Value = null;
            }
        }

        /// <summary>
        ///  Permet d'utiliser les fameux raccourcis CTRL+X pour couper, CTRL+C pour copier, CTRL+V pour coller, ici pour les factures.
        /// </summary>
        private void dgv_Facture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (dgv_Facture.SelectedRows.Count != 0 && btn_CopierLigne.Enabled)
                {
                    CopierLignesFacture();
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (dgv_Facture.SelectedRows.Count != 0 && btn_CollerLigne.Enabled)
                {
                    CollerLignesFacture();
                }
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                if (dgv_Facture.SelectedRows.Count != 0 && btn_CouperLigne.Enabled)
                {
                    CouperLignesFacture();
                }
            }
        }

        /// <summary>
        ///  Selon le nombre de ligne selectionné, définit quel bouton du toolStrip est activé ou non, ici pour les factures.
        /// </summary>
        private void dgv_Facture_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Facture.SelectedRows.Count != 0)
            {
                btn_SupprimerLigne.Enabled = true;
                btn_CopierLigne.Enabled = true;
                btn_CouperLigne.Enabled = true;
                btn_ViderLigne.Enabled = true;
            }
            else
            {
                btn_SupprimerLigne.Enabled = false;
                btn_CopierLigne.Enabled = false;
                btn_CouperLigne.Enabled = false;
                btn_ViderLigne.Enabled = false;
            }

            if (dgv_Facture.SelectedRows.Count == 1)
            {
                btn_InsererLigne.Enabled = true;
            }
            else
            {
                btn_InsererLigne.Enabled = false;
            }
        }

        /// <summary>
        ///  Récupère la valeur de la dateTimePicker pour remplir la cellule.
        /// </summary>
        private void dtpFactureDate_TextChange(object? sender, EventArgs e)
        {
            dgv_Facture.CurrentCell.Value = dtpFactureDate.Text.ToString();
        }

        //-----------------------------------------------------------------------------------------
        //Meilleur méthode trouvée pour pouvoir retirer le focus du textBox recherche lorsqu'on clique dans les controles environnants.
        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void tabControl_Onglets_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }

        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void ts_Inventaire_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }

        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void lbl_RechercheInventaire_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }

        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void menuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }

        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void tlp_Main_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }

        /// <summary>
        /// Retire le focus du textBox recherche si il détecte un clique.
        /// </summary>
        private void tlp_Millieu_MouseClick(object sender, MouseEventArgs e)
        {
            RetirerFocusDeTxtRecherche();
        }
        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// Permet de valider directement la valeur sans avoir à cliquer autre part que la cellule.
        /// </summary>
        private void dgv_Facture_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgv_Facture.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// Permet de valider directement la valeur sans avoir à cliquer autre part que la cellule.
        /// </summary>
        private void dgv_Inventaire_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgv_Inventaire.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        ///  Ajoute la prestation dans la listBox prestation et actualise ce qui est nécessaire.
        /// </summary>
        private void btn_AjoutPrestation_Click(object sender, EventArgs e)
        {
            ViderRecherche();
            prestationsCharge.Add(new FacturePrestation(txt_AjoutPrestationNom.Text, (float)nupd_AjoutPourcentageTVA.Value));
            UpdateListBoxFromDataSource(lb_Prestation);
            lb_Prestation.SelectedIndex = -1;
            txt_AjoutPrestationNom.Text = "";
            nupd_AjoutPourcentageTVA.Value = 0;
            UpdateFactureColonnePrestation();
        }

        /// <summary>
        ///  Supprime la prestation choisi et mets à jour ce qui est nécessaire.
        /// </summary>
        private void btn_SupprPrestation_Click(object sender, EventArgs e)
        {
            FacturePrestation saveSelectedItem = (FacturePrestation)lb_Prestation.SelectedItem;
            cb_FiltreRecherche.SelectedIndex = 0;
            txt_Recherche.Text = "";
            prestationsCharge.Remove(saveSelectedItem);
            UpdateListBoxFromDataSource(lb_Prestation);
            lb_Prestation.SelectedIndex = -1;
            txt_AjoutPrestationNom.Text = "";
            nupd_AjoutPourcentageTVA.Value = 0;
            UpdateFactureColonnePrestation();
        }

        /// <summary>
        ///  Activé ou non le bouton AjouterPrestation selon si le texte AjoutPrestation est vide, pareil pour le numericUpDown ajoutPourcentageTVA.
        /// </summary>
        private void txt_AjoutPrestationNom_TextChanged(object sender, EventArgs e)
        {
            if (txt_AjoutPrestationNom.Text != "" && nupd_AjoutPourcentageTVA.Value > 0)
            {
                btn_AjoutPrestation.Enabled = true;
            }
            else
            {
                btn_AjoutPrestation.Enabled = false;
            }
        }

        /// <summary>
        ///  Activé ou non le bouton AjouterPrestation selon si le texte AjoutPrestation est vide, pareil pour le numericUpDown ajoutPourcentageTVA.
        /// </summary>
        private void nupd_AjoutPourcentageTVA_ValueChanged(object sender, EventArgs e)
        {
            if (txt_AjoutPrestationNom.Text != "" && nupd_AjoutPourcentageTVA.Value > 0)
            {
                btn_AjoutPrestation.Enabled = true;
            }
            else
            {
                btn_AjoutPrestation.Enabled = false;
            }
        }

        /// <summary>
        ///  Permet de déselectionné la prestation choisi dans la listBox prestation si on appuie sur échappe.
        /// </summary>
        private void lb_Prestation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lb_Prestation.SelectedIndex = -1;
            }
        }

        /// <summary>
        ///  Activé ou non le bouton SupprimerPrestation selon si une prestation est sélectionné.
        /// </summary>
        private void lb_Prestation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Prestation.SelectedIndex != -1)
            {
                btn_SupprimerPrestation.Enabled = true;
            }
            else
            {
                btn_SupprimerPrestation.Enabled = false;
            }
        }

        /// <summary>
        /// Permet de réagir au changement de sous-onglet dans l'onglet Facture.
        /// </summary>
        private void tabControl_FactureOnglet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_Facture.SelectedIndex != 0)
            {
                DefinirVisibiliteToolStrip(visibiliteToolstrip.CACHEAVECFOND);
            }
            else if (tabControl_Facture.SelectedIndex == 0)
            {
                DefinirVisibiliteToolStrip(visibiliteToolstrip.MODIFDGV);
            }
            switch (tabControl_Facture.SelectedIndex)
            {
                case 0:
                    txt_Recherche.PlaceholderText = "Rechercher dans les factures";
                    MajCbFiltre(true);
                    break;
                case 1:
                    MajCbFiltre(false);
                    txt_Recherche.Visible = false;
                    lbl_RechercheInventaire.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Active ou désactive le bouton ajouterSiteWeb selon si txtAjoutSiteWebUrl contient du texte.
        /// </summary>
        private void txt_AjoutSiteWebUrl_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                btn_AjouterSiteWeb.Enabled = true;
            }
            else
            {
                btn_AjouterSiteWeb.Enabled = false;
            }
        }

        /// <summary>
        /// Active ou désactive des boutons lié à l'onglet siteFavoris selon si un élément est séléctionné dans la listBox.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                btn_SupprimerSiteWeb.Enabled = true;
                btn_AccederSiteWeb.Enabled = true;
            }
            else
            {
                btn_SupprimerSiteWeb.Enabled = false;
                btn_AccederSiteWeb.Enabled = false;
            }
        }

        /// <summary>
        /// Permet de faire "page blanche", l'idée est de vider tout les valeurs pour les re-peupler avec des valeurs "par défaut" qu'on définit au début du lancement du logiciel.
        /// </summary>
        private void FairePageBlanche()
        {
            dtpInventaireDateEntree.Visible = false;
            dtpInventaireDateSortie.Visible = false;
            dtpFactureDate.Visible = false;
            inventaireRowsCharge.Clear();
            factureRowsCharge.Clear();
            marquesCharge.Clear();
            typesCharge.Clear();
            prestationsCharge.Clear();
            dgv_Inventaire.Rows.Clear();
            dgv_Facture.Rows.Clear();
            lb_Marque.Items.Clear();
            lb_Type.Items.Clear();
            lb_SitesFav.DataSource = null;
            UpdateListBoxFromDataSource(lb_Prestation);
            foreach (string marque in defautMarquesCharge)
            {
                lb_Marque.Items.Add(marque);
            }
            foreach (string type in defautTypesCharge)
            {
                lb_Type.Items.Add(type);
            }
            foreach (FacturePrestation prestation in defautPrestationsCharge)
            {
                prestationsCharge.Add(prestation);
            }
            DefinirMarqueCharge();
            DefinirTypeCharge();
            UpdateListBoxFromDataSource(lb_Prestation);
            changerFormTitre(true);
            TSMenuItem_Fichier_Sauvegarder.Enabled = false;
            btn_Sauvegarder.Enabled = false;
            cb_Periode.SelectedIndex = 0;
            MajGraphiquesTabDeBord();
        }

        /// <summary>
        ///  Ajoute une ligne dans la listBox des prestations et vide par la même occasion les controls lié à la recherche.
        /// </summary>
        private void AjouterLignePrestation()
        {
            FacturePrestation saveSelectedItem = (FacturePrestation)lb_Prestation.SelectedItem;
            ViderRecherche();
            prestationsCharge.Remove(saveSelectedItem);
            UpdateListBoxFromDataSource(lb_Prestation);
            lb_Prestation.SelectedIndex = -1;
            txt_AjoutPrestationNom.Text = "";
            nupd_AjoutPourcentageTVA.Value = 0;
            UpdateFactureColonnePrestation();
        }

        /// <summary>
        /// Ajoute une ligne dans la listBox des sites web, vérifie également la présence de "www." dans l'url pour pouvoir réagir en conséquence.
        /// </summary>
        private void AjouterLigneSiteWeb()
        {
            string siteNom;
            string url = txt_AjoutSiteWebUrl.Text;
            if (!url.Contains("www."))
            {
                url = url.Insert(0, "www.");
            }
            if (txt_AjoutSiteWebNom.Text != "")
            {
                siteNom = txt_AjoutSiteWebNom.Text;
            }
            else
            {
                siteNom = url;
            }
            sitesFavorisCharge.Add(new SiteFavorisLigne(siteNom, url));
            UpdateListBoxFromDataSource(lb_SitesFav);
            txt_AjoutSiteWebNom.Text = "";
            txt_AjoutSiteWebUrl.Text = "";
        }

        /// <summary>
        /// Vide les éléments lié à la recherche.
        /// </summary>
        private void ViderRecherche()
        {
            cb_FiltreRecherche.SelectedIndex = 0;
            txt_Recherche.Text = "";
        }

        /// <summary>
        /// Appelle la fonction d'ajout de ligne dans la listBox siteWeb lors du clique.
        /// </summary>
        private void btn_AjouterSiteWeb_Click(object sender, EventArgs e)
        {
            AjouterLigneSiteWeb();
        }

        /// <summary>
        /// Appelle la fonction GererAccesSiteWeb() qui ouvre la page web si un élément est séléctionné dans la listBox.
        /// </summary>
        private void lb_SitesFav_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GererAccesSiteWeb();
        }

        /// <summary>
        /// Agit de la même manière que le double clique, appelle de la fonction GererAccesSiteWeb().
        /// </summary>
        private void btn_AccederSiteWeb_Click(object sender, EventArgs e)
        {
            GererAccesSiteWeb();
        }

        /// <summary>
        /// Vérifie si un élément est séléctionné, si c'est le cas alors ouvre la page web.
        /// </summary>
        private void GererAccesSiteWeb()
        {
            if (lb_SitesFav.SelectedIndex != -1)
            {
                controleur.AccederSiteWebSelected(((SiteFavorisLigne)lb_SitesFav.SelectedItem).url);
            }
        }

        /// <summary>
        /// Supprime le site web séléctionné.
        /// </summary>
        private void btn_SupprimerSiteWeb_Click(object sender, EventArgs e)
        {
            sitesFavorisCharge.Remove((SiteFavorisLigne)lb_SitesFav.SelectedItem);
            UpdateListBoxFromDataSource(lb_SitesFav);
        }

        /// <summary>
        /// Réagit au changement d'élément dans la comboBox periode (qui se situe dans le tableau de bord).
        /// </summary>
        private void cb_Periode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GererChangementPeriode((EnumPeriodes)cb_Periode.SelectedIndex + 1);
        }

        /// <summary>
        /// Gére le changement de période en modifiant certains textes et en mettant à jour le tableau de bord.
        /// </summary>
        /// <param name="nouvellePeriode">La nouvelle période.</param>
        private void GererChangementPeriode(EnumPeriodes nouvellePeriode)
        {
            periodeActuelle = nouvellePeriode;
            string btnText = "";
            switch (nouvellePeriode)
            {
                case SEMAINE:
                    btnText = " d'une semaine";
                    break;
                case MOIS:
                    btnText = " d'un mois";
                    break;
                case ANNEE:
                    btnText = " d'une année";
                    break;
            }
            btn_AvancerPeriodeFacture.Text = "Avancer" + btnText;
            btn_ReculerPeriodeFacture.Text = "Reculer" + btnText;
            btn_AvancerPeriodeInventaire.Text = "Avancer" + btnText;
            btn_ReculerPeriodeInventaire.Text = "Reculer" + btnText;
            MajGraphiqueLineaireTabDeBord(true);
            MajGraphiqueLineaireTabDeBord(false);
        }

        /// <summary>
        /// Permet de se déplacer avec un cran correspondant à la période, si on choisit semaine alors on va ajouter ou retirer une semaine, cela permet de consulter les graphiques linéaires de manière compléte.
        /// </summary>
        /// <param name="chartFacture">Permet de savoir si on parle du graphique linéaire lié aux factures.</param>
        /// <param name="reculer">Permet de savoir si on recule d'une période.</param>
        private void AjoutDecalagePeriode(bool chartFacture, bool reculer)
        {
            int multiplicateur = 1;
            if (reculer)
            {
                multiplicateur = -1;
            }
            switch (periodeActuelle)
            {
                case SEMAINE:
                    dateBaseDecalage = dateBaseDecalage.AddDays(7 * multiplicateur);
                    break;
                case MOIS:
                    dateBaseDecalage = dateBaseDecalage.AddMonths(1 * multiplicateur);
                    break;
                case ANNEE:
                    dateBaseDecalage = dateBaseDecalage.AddYears(1 * multiplicateur);
                    break;
            }
            MajGraphiqueLineaireTabDeBord(chartFacture, dateBaseDecalage);
        }

        /// <summary>
        /// Génére un graphique linéaire, soit celui de l'inventaire soit celui des factures, on se base sur les données dans les variables "chargés" comme "inventaireRowsCharge" pour générer le graphique.
        /// </summary>
        /// <param name="chartFacture">Permet de savoir si ça concerne le graphique linéaire des factures.</param>
        /// <param name="dateBase">Date "source" permettant de générer le graphique.</param>
        public void MajGraphiqueLineaireTabDeBord(bool chartFacture, DateTime dateBase = new DateTime())
        {
            txt_Recherche.Text = "";
            MajDGV(dgv_Inventaire, inventaireRowsCharge);
            MajDGV(dgv_Facture, factureRowsCharge);
            if (dateBase.Year == 1)
            {
                dateBase = DateTime.Today;
            }
            EnumPeriodes periode = SEMAINE;
            switch (cb_Periode.SelectedItem.ToString())
            {
                case "Semaine":
                    periode = SEMAINE;
                    break;
                case "Mois":
                    periode = MOIS;
                    break;
                case "Année":
                    periode = ANNEE;
                    break;
            }
            string formatDate = "dd/MM/yy";
            switch (periode)
            {
                case ANNEE:
                    formatDate = "MM/yy";
                    break;
            }
            DateTime dateDebutPeriode = controleur.PremierJourPeriode(dateBase, periode);
            DateTime dateFinPeriode = controleur.DernierJourPeriode(dateDebutPeriode, periode);
            DateTime dateParcourus;
            DateTime dateRecup;
            string chartAreaName;
            string seriesName;
            string dateColonneName;
            string prixColonneName;
            int multiplicateurPrix = 1;
            float somme = 0;
            Label lbl_Total;
            Chart chart;
            List<DataGridViewRow> listeDgv = new List<DataGridViewRow>();
            if (chartFacture)
            {
                chartAreaName = "ChartAreaFacture";
                seriesName = "Revenu TTC des factures émises";
                listeDgv = factureRowsCharge.ToList<DataGridViewRow>();
                dateColonneName = "DateFacture";
                prixColonneName = "PrixTTC";
                chart = chart_Facture;
                lbl_Total = lbl_RevenuTTCFactures;
            }
            else
            {
                chartAreaName = "ChartAreaInventaire";
                seriesName = "Valeur TTC de l'inventaire";
                listeDgv = inventaireRowsCharge.ToList<DataGridViewRow>(); ;
                dateColonneName = "DateEntreeInventaire";
                prixColonneName = "PrixInventaire";
                chart = chart_Inventaire;
                lbl_Total = lbl_ValeurInventaire;
            }
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            ChartArea chartArea = new ChartArea(chartAreaName);
            chartArea.AxisX.Title = "Période";
            chartArea.AxisY.Title = "Valeur en €";
            chartArea.AxisY.LabelStyle.Format = "{0:0}€";
            chartArea.AxisX.LabelStyle.Angle = 45;
            chartArea.AxisX.LabelStyle.Format = formatDate;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = controleur.ConversionPeriodeAdateTimeIntervalType(periode);
            chartArea.AxisX.Minimum = dateDebutPeriode.ToOADate();
            chartArea.AxisX.Maximum = dateFinPeriode.ToOADate();
            chart.ChartAreas.Add(chartArea);
            Series series = new Series(seriesName);
            series.ChartType = SeriesChartType.Line;
            series.ChartArea = chartAreaName;
            series.Name = seriesName;
            chart.Series.Add(series);
            Dictionary<DateTime, float> sommeParDate = new Dictionary<DateTime, float>();
            int i = 0;
            foreach (DataGridViewRow row in listeDgv)
            {
                if (!chartFacture)
                {
                    multiplicateurPrix = int.Parse(row.Cells["QuantiteInventaire"].Value.ToString() ?? "1");
                }
                if (row.Cells[dateColonneName].Value != null)
                {
                    DateTime.TryParse(row.Cells[dateColonneName].Value.ToString() ?? "", out dateRecup);
                    if (dateRecup.Year != 1 && controleur.DateComprisDansPeriode(dateRecup, dateDebutPeriode, dateFinPeriode) && row.Cells[prixColonneName].Value != null)
                    {
                        string prixStr = row.Cells[prixColonneName].Value.ToString() ?? "0";
                        if (sommeParDate.ContainsKey(dateRecup))
                        {
                            sommeParDate[dateRecup] = sommeParDate[dateRecup] + (float.Parse(prixStr.Replace('€', ' ') ?? "0") * multiplicateurPrix);
                        }
                        else
                        {
                            sommeParDate.Add(dateRecup, float.Parse(prixStr.Replace('€', ' ') ?? "0") * multiplicateurPrix);
                        }
                    }
                }
                i++;
            }
            switch (periode)
            {
                case ANNEE:
                    int mois = 1;
                    Dictionary<int, float> sommeMensuelleParMois = new Dictionary<int, float>();
                    chart.ChartAreas[0].AxisX.Minimum = DateTime.Parse("01/01/" + dateBase.Year).ToOADate();
                    chart.ChartAreas[0].AxisX.Maximum = DateTime.Parse("01/12/" + dateBase.Year).ToOADate();
                    while (mois <= 12)
                    {
                        DateTime debutMois = DateTime.Parse("01/" + mois.ToString("00") + "/" + DateTime.Now.Year);
                        DateTime finMois = debutMois.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, mois) - 1);
                        dateParcourus = debutMois;
                        while (controleur.DateComprisDansPeriode(dateParcourus, debutMois, finMois))
                        {
                            if (sommeParDate.ContainsKey(dateParcourus))
                            {
                                if (sommeMensuelleParMois.ContainsKey(mois))
                                {
                                    sommeMensuelleParMois[mois] = sommeMensuelleParMois[mois] + sommeParDate[dateParcourus];
                                }
                                else
                                {
                                    sommeMensuelleParMois.Add(mois, sommeParDate[dateParcourus]);
                                }
                            }
                            dateParcourus = dateParcourus.AddDays(1);
                        }
                        if (sommeMensuelleParMois.ContainsKey(mois))
                        {
                            series.Points.AddXY(debutMois, sommeMensuelleParMois[mois]);
                        }
                        else
                        {
                            series.Points.AddXY(debutMois, 0);
                        }
                        mois++;
                    }
                    foreach (var item in sommeMensuelleParMois)
                    {
                        somme = somme + item.Value;
                    }
                    lbl_Total.Text = (int)somme + "€";
                    return;
                default:
                    dateParcourus = dateDebutPeriode;
                    while (controleur.DateComprisDansPeriode(dateParcourus, dateDebutPeriode, dateFinPeriode))
                    {
                        if (sommeParDate.ContainsKey(dateParcourus))
                        {
                            series.Points.AddXY(dateParcourus, sommeParDate[dateParcourus]);
                        }
                        else
                        {
                            series.Points.AddXY(dateParcourus, 0);
                        }
                        dateParcourus = dateParcourus.AddDays(1);
                    }
                    foreach (var item in sommeParDate)
                    {
                        somme = somme + item.Value;
                    }
                    lbl_Total.Text = (int)somme + "€";
                    return;
            }
        }

        /// <summary>
        /// Génére un graphique donut, soit celui des types soit celui des marques, on se base sur les données des listBox en question pour générer le graphique.
        /// </summary>
        /// <param name="chartDonutType">Permet de savoir si ça concerne le graphique donut des types (type d'objet dans l'inventaire)</param>
        public void MajGraphiqueDonutTabDeBord(bool chartDonutType)
        {
            string seriesName;
            Chart chart;
            ListBox.ObjectCollection listeItems;
            List<DataGridViewRow> listeDgv = inventaireRowsCharge;
            string cellName;
            string temp;
            int i = 0;
            int lenCompteurParElementExistant = 0;
            if (chartDonutType)
            {
                seriesName = "Répartition des types d'objet dans l'inventaire";
                listeItems = lb_Type.Items;
                chart = chartDonut_Type;
                cellName = "TypeInventaire";
            }
            else
            {
                seriesName = "Répartition des marques dans l'inventaire";
                listeItems = lb_Marque.Items;
                chart = chartDonut_Marque;
                cellName = "MarqueInventaire";
            }
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            ChartArea chartArea = new ChartArea("Pourcentage");
            chartArea.Area3DStyle.Enable3D = true;
            chart.ChartAreas.Add(chartArea);
            Series series = new Series(seriesName);
            series.ChartType = SeriesChartType.Doughnut;
            series.ChartArea = "Pourcentage";
            series.Name = seriesName;
            chart.Series.Add(series);
            Dictionary<string, int> compteurParElement = new Dictionary<string, int>();
            foreach (DataGridViewRow row in listeDgv)
            {
                if (row.Cells[cellName].Value != null)
                {
                    temp = row.Cells[cellName].Value.ToString() ?? "";
                    if (temp != "")
                    {
                        if (compteurParElement.ContainsKey(temp))
                        {
                            compteurParElement[temp] = compteurParElement[temp] + 1;
                        }
                        else
                        {
                            compteurParElement.Add(temp, 1);
                        }
                    }
                }
            }
            foreach (string item in listeItems)
            {
                if (compteurParElement.ContainsKey(item))
                {
                    lenCompteurParElementExistant += compteurParElement[item];
                }
                else
                {
                    compteurParElement.Add(item, 0);
                }
            }
            foreach (KeyValuePair<string, int> pair in compteurParElement)
            {
                if (pair.Value > 0)
                {
                    series.Points.AddXY(i, pair.Value);
                    series.Points[i].Label = (Math.Round((decimal)(((float)pair.Value / lenCompteurParElementExistant) * 100), 2)) + "%";
                    series.Points[i].LegendText = pair.Key;
                    i++;
                }
                else
                {
                    series.Points.AddXY(i, 0);
                    series.Points[i].LegendText = pair.Key;
                    i++;
                }
            }
        }

        /// <summary>
        /// Recule d'une période pour les factures lors du clique (Tableau de bord).
        /// </summary>
        private void btn_ReculerPeriodeFacture_Click(object sender, EventArgs e)
        {
            AjoutDecalagePeriode(true, true);
        }

        /// <summary>
        /// Avance d'une période pour les factures lors du clique (Tableau de bord).
        /// </summary>
        private void btn_AvancerPeriodeFacture_Click(object sender, EventArgs e)
        {
            AjoutDecalagePeriode(true, false);
        }

        /// <summary>
        /// Recule d'une période pour l'inventaire lors du clique (Tableau de bord).
        /// </summary>
        private void btn_ReculerPeriodeInventaire_Click(object sender, EventArgs e)
        {
            AjoutDecalagePeriode(false, true);
        }

        /// <summary>
        /// Avance d'une période pour l'inventaire lors du clique (Tableau de bord).
        /// </summary>
        private void btn_AvancerPeriodeInventaire_Click(object sender, EventArgs e)
        {
            AjoutDecalagePeriode(false, false);
        }

        private void dgv_Inventaire_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_Inventaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}