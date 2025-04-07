using FranceInformatiqueInventaire.dal;
using FranceInformatiqueInventaire.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static FranceInformatiqueInventaire.Model.EnumPeriodes;

namespace FranceInformatiqueInventaire.Controlleur
{
    /// <summary>
    ///  Classe utilisée comme controlleur de l'application.
    /// </summary>
    public partial class GestionControlleur
    {
        BddManager bddManagerRef;

        /// <summary>
        /// Constructeur du contrôleur pour la vue Gestion.
        /// </summary>
        /// <param name="bddManagerRef"></param>
        public GestionControlleur(BddManager bddManagerRef)
        {
            this.bddManagerRef = bddManagerRef;
        }


        /// <summary>
        ///  Permet de récupérer le nom du fichier directement et la non le chemin complet.
        /// </summary>
        /// <returns>Retourne le nom du fichier.</returns>
        public string GetFileNameSansChemin(string cheminFichierOuvert)
        {
            string temp = cheminFichierOuvert.Substring(cheminFichierOuvert.LastIndexOf("\\") + 1);
            return temp.Remove(temp.Count() - 3);
        }

        /// <summary>
        ///  Permet d'ouvrir une boite de dialogue d'ouverture de fichier, on récupérer le chemin du fichier.
        /// </summary>
        /// <returns>Retourne le chemin du fichier choisi.</returns>
        public string OuvrirDialogueOuvertureFichier()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "SQLite Database|*.db";
            fileDialog.Title = "Choisissez le fichier à ouvrir";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Permet d'ouvrir une boite de dialogue de sauvegarde de fichier, on récupére le chemin du fichier.
        /// </summary>
        /// <returns>Retourne le chemin du fichier choisi.</returns>
        public string OuvrirDialogueSaveFichier()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "SQLite Database|*.db";
            fileDialog.Title = "Choisissez le nom du fichier";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                
                return fileDialog.FileName;
            }
            return "";
        }

        /// <summary>
        /// Lance l'appelle de l'écriture de la bdd en contactant le bddmanager.
        /// </summary>
        /// <param name="cheminFichier">Le chemin du fichier qui sera créé.</param>
        public void CallEcrireBDD(string cheminFichier)
        {
            bddManagerRef.EcrireBdd(cheminFichier);
        }

        /// <summary>
        /// Permet de rechercher dans les factures en supprimant les rows de la dataGridView facture qui ne contiennent pas l'élément recherché, on parcours chaque colonne ou une colonne spécifique selon le filtre choisi.
        /// </summary>
        /// <param name="rowsAparcourir">Les rows à parcourir.</param>
        /// <param name="texteARechercher">Le texte qui sera recherché dans les cellules.</param>
        /// <param name="filtreSelectedIndex">L'index du filtre choisi pour la recherche.</param>
        /// <returns>Liste des index à supprimer dans le dgv facture.</returns>
        public List<int> RechercherFacture(List<DataGridViewRow> rowsAparcourir, string texteARechercher, int filtreSelectedIndex)
        {
            texteARechercher = texteARechercher.ToLower();
            bool trouverTexteDansRow = false;
            List<int> indexsRowASupprimer = new List<int>();
            for (int i = 0; i < rowsAparcourir.Count; i++)
            {
                if (filtreSelectedIndex > 0)
                {
                    DataGridViewCell cell = rowsAparcourir[i].Cells[filtreSelectedIndex];
                    if (!(cell.Value == null))
                    {
                        string cellText = (cell.Value.ToString()) ?? "";
                        cellText = cellText.ToLower();
                        if (cellText.Contains(texteARechercher))
                        {
                            trouverTexteDansRow = true;
                        }
                    }
                }
                else
                {
                    for (int e = 0; e < rowsAparcourir[i].Cells.Count; e++)
                    {
                        DataGridViewCell cell = rowsAparcourir[i].Cells[e];
                        if (!(cell.Value == null))
                        {
                            string cellText = (cell.Value.ToString()) ?? "";
                            cellText = cellText.ToLower();
                            if (cellText.Contains(texteARechercher))
                            {
                                trouverTexteDansRow = true;
                                break;
                            }
                        }
                    }
                }
                if (!trouverTexteDansRow)
                {
                    if (!(indexsRowASupprimer.Contains(i)))
                    {
                        indexsRowASupprimer.Insert(0, i);
                    }
                }
                trouverTexteDansRow = false;
            }
            return indexsRowASupprimer;
        }

        /// <summary>
        /// Permet de rechercher dans l'inventaire en supprimant les rows de la dataGridView inventaire qui ne contiennent pas l'élément recherché, on parcours chaque colonne ou une colonne spécifique selon le filtre choisi.
        /// </summary>
        /// <param name="rowsAparcourir">Les rows à parcourir.</param>
        /// <param name="texteARechercher">Le texte qui sera recherché dans les cellules.</param>
        /// <param name="filtreSelectedIndex">L'index du filtre choisi pour la recherche.</param>
        /// <returns>Liste des index à supprimer dans le dgv inventaire.</returns>
        public List<int> RechercherInventaire(List<DataGridViewRow> rowsAparcourir, string texteARechercher, int filtreSelectedIndex)
        {
            texteARechercher = texteARechercher.ToLower();
            bool trouverTexteDansRow = false;
            List<int> indexsRowASupprimer = new List<int>();
            for (int i = 0; i < rowsAparcourir.Count; i++)
            {
                if (filtreSelectedIndex > 0)
                {
                    DataGridViewCell cell = rowsAparcourir[i].Cells[filtreSelectedIndex];
                    if (!(cell.Value == null))
                    {
                        string cellText = (cell.Value.ToString()) ?? "";
                        cellText = cellText.ToLower();
                        if (cellText.Contains(texteARechercher))
                        {
                            trouverTexteDansRow = true;
                        }
                    }
                }
                else
                {
                    for (int e = 0; e < rowsAparcourir[i].Cells.Count; e++)
                    {
                        DataGridViewCell cell = rowsAparcourir[i].Cells[e];
                        if (!(cell.Value == null))
                        {
                            string cellText = (cell.Value.ToString()) ?? "";
                            cellText = cellText.ToLower();
                            if (cellText.Contains(texteARechercher))
                            {
                                trouverTexteDansRow = true;
                                break;
                            }
                        }
                    }
                }
                if (!trouverTexteDansRow)
                {
                    if (!(indexsRowASupprimer.Contains(i)))
                    {
                        indexsRowASupprimer.Insert(0, i);
                    }
                }
                trouverTexteDansRow = false;
            }
            return indexsRowASupprimer;
        }

        /// <summary>
        /// Permet de rechercher dans les marques en supprimant les lignes de la listBox marque qui ne contiennent pas l'élément recherché.
        /// </summary>
        /// <param name="listBoxItems">Les items à parcourir.</param>
        /// <param name="texteARechercher">Le texte qui sera recherché dans les lignes.</param>
        /// <param name="filtreSelectedIndex">L'index du filtre choisi pour la recherche.</param>
        /// <returns>Liste des index à supprimer dans la listBox marque.</returns>
        public List<int> RechercherMarque(List<string> listBoxItems, string texteARechercher, int filtreSelectedIndex)
        {
            texteARechercher = texteARechercher.ToLower();
            bool trouverTexteDansRow = false;
            List<int> indexsItemASupprimer = new List<int>();
            for (int i = 0; i < listBoxItems.Count; i++)
            {
                var item = listBoxItems[i];
                if (!(item == null))
                {
                    string itemText = (item.ToString()) ?? "";
                    itemText = itemText.ToLower();
                    if (itemText.Contains(texteARechercher))
                    {
                        trouverTexteDansRow = true;
                    }
                }
                if (!trouverTexteDansRow)
                {
                    if (!(indexsItemASupprimer.Contains(i)))
                    {
                        indexsItemASupprimer.Insert(0, i);
                    }
                }
                trouverTexteDansRow = false;
            }
            return indexsItemASupprimer;
        }

        /// <summary>
        /// Permet de rechercher dans les types en supprimant les lignes de la listBox type qui ne contiennent pas l'élément recherché.
        /// </summary>
        /// <param name="listBoxItems">Les items à parcourir.</param>
        /// <param name="texteARechercher">Le texte qui sera recherché dans les lignes.</param>
        /// <param name="filtreSelectedIndex">L'index du filtre choisi pour la recherche.</param>
        /// <returns>Liste des index à supprimer dans la listBox type.</returns>
        public List<int> RechercherType(List<string> listBoxItems, string texteARechercher, int filtreSelectedIndex)
        {
            texteARechercher = texteARechercher.ToLower();
            bool trouverTexteDansRow = false;
            List<int> indexsItemASupprimer = new List<int>();
            for (int i = 0; i < listBoxItems.Count; i++)
            {
                var item = listBoxItems[i];
                if (!(item == null))
                {
                    string itemText = (item.ToString()) ?? "";
                    itemText = itemText.ToLower();
                    if (itemText.Contains(texteARechercher))
                    {
                        trouverTexteDansRow = true;
                    }
                }
                if (!trouverTexteDansRow)
                {
                    if (!(indexsItemASupprimer.Contains(i)))
                    {
                        indexsItemASupprimer.Insert(0, i);
                    }
                }
                trouverTexteDansRow = false;
            }
            return indexsItemASupprimer;
        }

        /// <summary>
        /// Permet de coller les lignes copiées dans les lignes actuellement séléctionnées.
        /// </summary>
        /// <param name="dgvRows">La liste de rows avant toute manipulation.</param>
        /// <param name="selectedRows">Les rows séléctionnées du dataGridView.</param>
        /// <param name="rowsCopiee">La liste de rows qui ont étaient copiées.</param>
        /// <param name="nbColonnesConcernees">Le nb de colonne à coller.</param>
        /// <returns>Dictionnaire des lignes affectées avec l'index et les nouvelles rows.</returns>
        public Dictionary<int, DataGridViewRow> GetDgvRowsApresCollageLignes(DataGridViewRowCollection dgvRows, DataGridViewSelectedRowCollection selectedRows, List<DataGridViewRow> rowsCopiee, int nbColonnesConcernees)
        {
            int indexPremierRowSelected = selectedRows[0].Index;
            int indexDernierRowSelected = selectedRows[selectedRows.Count - 1].Index;
            Dictionary<int, DataGridViewRow> nouvelleDgvRows = new Dictionary<int, DataGridViewRow>();
            int f = 0;
            int g = 0;
            if (((indexDernierRowSelected - indexPremierRowSelected) + 1) == rowsCopiee.Count || selectedRows.Count == 1)
            {
                for (int i = 1; i > selectedRows.Count; i++)
                {
                    DataGridViewRow nouvelleRow = (DataGridViewRow)dgvRows[0].Clone();
                    for (int k = 1; k < nbColonnesConcernees; k++)
                    {
                        if (rowsCopiee[f].Cells[k].Value != null)
                        {
                            nouvelleRow.Cells[k].Value = rowsCopiee[f].Cells[k].Value.ToString();
                        }
                        else
                        {
                            nouvelleRow.Cells[k].Value = "";
                        }
                    }
                    nouvelleDgvRows.Add(selectedRows[i].Index, nouvelleRow);
                    f++;
                }
            }
            else
            {
                for (int i = (selectedRows.Count - 1); i > -1; i--)
                {
                    DataGridViewRow nouvelleRow = (DataGridViewRow)dgvRows[0].Clone();
                    if (selectedRows[i].Index <= (dgvRows.Count - 1) && f < rowsCopiee.Count)
                    {
                        for (int k = 1; k < nbColonnesConcernees; k++)
                        {
                            if (rowsCopiee[f].Cells[k].Value != null)
                            {
                                nouvelleRow.Cells[k].Value = rowsCopiee[f].Cells[k].Value.ToString();
                            }
                            else
                            {
                                nouvelleRow.Cells[k].Value = "";
                            }
                        }
                        nouvelleDgvRows.Add(selectedRows[i].Index, nouvelleRow);
                        f++;
                    }
                }
            }
            return nouvelleDgvRows;
        }


        /// <summary>
        /// Sépare le nom et le pourcentage de la prestation à partir d'un seul str.
        /// </summary>
        /// <param name="stringOriginal"></param>
        /// <returns>Un tuple de string et de float, le nom et le pourcentage.</returns>
        public (string, float) SeparerPrestationNomPourcentage(string stringOriginal)
        {
            string nomSepare = stringOriginal;
            string strPourcentageSepare;
            float pourcentageSepare;
            nomSepare = nomSepare.Substring(0, nomSepare.IndexOf('(') - 1);
            strPourcentageSepare = stringOriginal.Substring(stringOriginal.IndexOf('(') + 1, (stringOriginal.IndexOf(')') - stringOriginal.IndexOf('(')) - 2);
            pourcentageSepare = float.Parse(strPourcentageSepare) / 100;
            return (nomSepare, pourcentageSepare);
        }

        /// <summary>
        /// Accéde au site web passé en paramètre.
        /// </summary>
        /// <param name="url">L'url du site web à ouvrir.</param>
        public void AccederSiteWebSelected(string url)
        {
            try
            {
                ProcessStartInfo psInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psInfo);
            }
            catch (Exception exc)
            {
                MessageBox.Show("L'url de ce site web ne semble pas fonctionner", "Erreur URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de vérifier si une DateTime est compris dans une période.
        /// </summary>
        /// <param name="dateAverif">Date à vérifier.</param>
        /// <param name="debutPeriode">Date de début de la période.</param>
        /// <param name="finPeriode">Date de fin de la période.</param>
        /// <returns>Le bool qui permet de connaître le résultat.</returns>
        public bool DateComprisDansPeriode(DateTime dateAverif, DateTime debutPeriode, DateTime finPeriode)
        {
            return (dateAverif >= debutPeriode) && (dateAverif <= finPeriode);
        }

        /// <summary>
        /// Ajoute ou retire une période à une date.
        /// </summary>
        /// <param name="date">Date à utiliser.</param>
        /// <param name="periode">La période en question.</param>
        /// <param name="ajouterPeriode">Permet de savoir si on ajoute ou retire une période.</param>
        /// <returns>La nouvelle date.</returns>
        public DateTime ModifierDateDepuisPeriode(DateTime date, EnumPeriodes periode, bool ajouterPeriode = false)
        {
            int multiplicateur = -1;
            if (ajouterPeriode)
            {
                multiplicateur = 1;
            }
            switch (periode)
            {
                case EnumPeriodes.SEMAINE:
                    return date.AddDays(7 * multiplicateur);
                case EnumPeriodes.MOIS:
                    return date.AddMonths(1 * multiplicateur);
                case EnumPeriodes.ANNEE:
                    return date.AddYears(1 * multiplicateur);
                default:
                    return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Permet de connaître le premier jour de la période choisie, par exemple si on prends le 06/12/24, avec période = SEMAINE alors le premier jour sera lundi 02/12/24.
        /// </summary>
        /// <param name="date">La date à utiliser.</param>
        /// <param name="periode">La période en question.</param>
        /// <returns>La date du premier jour de la période.</returns>
        public DateTime PremierJourPeriode(DateTime date, EnumPeriodes periode)
        {
            string dateStr;
            switch (periode)
            {
                case EnumPeriodes.SEMAINE:
                    while(date.DayOfWeek.ToString() != "Monday")
                    {
                        date = date.AddDays(-1);
                    }
                    return date;
                case EnumPeriodes.MOIS:
                    dateStr = date.ToString();
                    dateStr = "01" + dateStr.Substring(2);
                    return DateTime.Parse(dateStr);
                case EnumPeriodes.ANNEE:
                    dateStr = date.ToString();
                    dateStr = "01/01" + dateStr.Substring(5);
                    return DateTime.Parse(dateStr);
                default:
                    return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Au contraire de PremierJourPeriode(), permet de connaître le dernier jour de la période choisie, par exemple si on prends le 06/12/24, avec période = SEMAINE alors le dernier jour sera dimanche 08/12/24.
        /// </summary>
        /// <param name="date">La date à utiliser.</param>
        /// <param name="periode">La période en question.</param>
        /// <returns>La date du dernier jour de la période.</returns>
        public DateTime DernierJourPeriode(DateTime date, EnumPeriodes periode)
        {
            string dateStr;
            switch (periode)
            {
                case EnumPeriodes.SEMAINE:
                    while (date.DayOfWeek.ToString() != "Sunday")
                    {
                        date = date.AddDays(1);
                    }
                    return date;
                case EnumPeriodes.MOIS:
                    dateStr = date.ToString();
                    dateStr = DateTime.DaysInMonth(date.Year, date.Month) + dateStr.Substring(2);
                    return DateTime.Parse(dateStr);
                case EnumPeriodes.ANNEE:
                    dateStr = date.ToString();
                    dateStr = DateTime.DaysInMonth(date.Year, 12) + "/12" + dateStr.Substring(5);
                    return DateTime.Parse(dateStr);
                default:
                    return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Permet la conversion d'un enum periode à un DateTimeIntervalType.
        /// </summary>
        /// <param name="periode">La période à utiliser.</param>
        /// <returns>La conversion.</returns>
        public DateTimeIntervalType ConversionPeriodeAdateTimeIntervalType(EnumPeriodes periode)
        {
            switch (periode)
            {
                case EnumPeriodes.SEMAINE:
                    return DateTimeIntervalType.Days;
                case EnumPeriodes.MOIS:
                    return DateTimeIntervalType.Days;
                case EnumPeriodes.ANNEE:
                    return DateTimeIntervalType.Months;
                default:
                    return DateTimeIntervalType.Days;
            }
        }
    }
}
