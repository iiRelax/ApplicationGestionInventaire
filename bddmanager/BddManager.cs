using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using FranceInformatiqueInventaire.Model;
using System.Data;

namespace FranceInformatiqueInventaire.dal
{
    /// <summary>
    ///  Classe utilisée comme pont pour communiquer avec les bases de données (fichier .db) en utilisant l'extension SQLite.
    /// </summary>
    public class BddManager
    {
        private static BddManager? instance;
        private string connectionTexte = "";
        private FormGestion formGestionRef;

        /// <summary>
        ///  Constructeur de la classe, on récupére et définit ici la référence avec la FormGestion.
        /// </summary>
        private BddManager(FormGestion formGestion)
        {
            formGestionRef = formGestion;
        }

        /// <summary>
        ///  Permet de récupérer l'unique instance du singleton BddManager.
        /// </summary>
        /// <param name="formGestion">Référence donnée nécessaire pour le constructeur de la classe.</param>
        /// <returns>L'unique instance du singleton.</returns>

        public static BddManager GetInstance(FormGestion formGestion)
        {
            if (instance == null)
            {
                instance = new BddManager(formGestion);
            }
            return instance;
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité InventaireLigne.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        /// <returns>Une liste des instances de l'entité InventaireLigne récupérées grace au curseur SQL.</returns>
        public List<InventaireLigne> RecupererTableInventaire(string connectionTexteTemp)
        {
            bool existenceColonneQuantite = false;
            connectionTexte = connectionTexteTemp;
            List<InventaireLigne> inventaireLignes = new List<InventaireLigne>();
            int id;
            string type;
            string marque;
            string nom;
            string annee;
            float prix;
            int quantite = 1; //Si la colonne n'existe pas dans la sauvegarde alors on déclare que la quantité est à 1 par défaut
            string dateEntree;
            string dateSortie;
            string commentaire;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand commandVerifExistenceQuantite = new SQLiteCommand("SELECT COUNT(*) AS CNTREC FROM pragma_table_info('tablename') WHERE name='quantite'", connection))
                {
                    object result = commandVerifExistenceQuantite.ExecuteScalar();
                    existenceColonneQuantite =  result != null;
                }
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Inventaire", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        //Les noms de colonnes de la table ne sont pas les mêmes que les Names de la dataGridView inventaire.
                        while (curseur.Read())
                        {
                            id = curseur.GetInt32(curseur.GetOrdinal("Id"));
                            type = curseur.GetString(curseur.GetOrdinal("Type"));
                            marque = curseur.GetString(curseur.GetOrdinal("Marque"));
                            nom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            annee = curseur.GetString(curseur.GetOrdinal("Annee"));
                            prix = curseur.IsDBNull(curseur.GetOrdinal("Prix")) ? -1f : curseur.GetFloat(curseur.GetOrdinal("Prix"));
                            if (existenceColonneQuantite)
                            {
                                quantite = curseur.IsDBNull(curseur.GetOrdinal("Quantite")) ? 1 : curseur.GetInt32(curseur.GetOrdinal("Quantite"));
                            }
                            dateEntree = curseur.GetString(curseur.GetOrdinal("DateEntree"));
                            dateSortie = curseur.GetString(curseur.GetOrdinal("DateSortie"));
                            commentaire = curseur.GetString(curseur.GetOrdinal("Commentaire"));
                            InventaireLigne nouvelleLigne = new InventaireLigne(id, type, marque, nom, annee, prix, quantite, dateEntree, dateSortie, commentaire);
                            inventaireLignes.Add(nouvelleLigne);
                        }
                    }
                }
                return inventaireLignes;
            }
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité InventaireMarque.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        /// <returns>La liste des instances de type InventaireMarque récupéré à partir du curseur SQL.</returns>
        public List<InventaireMarque> RecupererTableMarque(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            List<InventaireMarque> marqueLignes = new List<InventaireMarque>();
            string marqueNom;
            int marqueId;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Marque", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        while (curseur.Read())
                        {
                            marqueId = curseur.GetInt32(curseur.GetOrdinal("Id"));
                            marqueNom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            
                            marqueLignes.Add(new InventaireMarque(marqueNom));
                        }
                    }
                }
            }
            return marqueLignes;
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité InventaireType.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        /// <returns>La liste des instances de type InventaireType récupéré à partir du curseur SQL.</returns>
        public List<InventaireType> RecupererTableType(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            List<InventaireType> typeLignes = new List<InventaireType>();
            string typeNom;
            int typeId;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Type", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        while (curseur.Read())
                        {
                            typeId = curseur.GetInt32(curseur.GetOrdinal("Id"));
                            typeNom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            typeLignes.Add(new InventaireType(typeNom));
                        }
                    }
                }
            }
            return typeLignes;
        }

       

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité FactureLigne.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        /// <returns>La liste des instances de type FactureLigne récupéré à partir du curseur SQL.</returns>
        public List<FactureLigne> RecupererTableFacture(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            List<FactureLigne> factureLignes = new List<FactureLigne>();
            int id;
            string nom;
            string prestation;
            string date;
            string commentaire;
            float prixHT;
            float prixTTC;
            float difference;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Facture", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        while (curseur.Read())
                        {
                            id = curseur.GetInt32(curseur.GetOrdinal("Id"));
                            nom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            prestation = curseur.GetString(curseur.GetOrdinal("Prestation"));
                            date = curseur.GetString(curseur.GetOrdinal("Date"));
                            commentaire = curseur.GetString(curseur.GetOrdinal("Commentaire"));
                            prixHT = curseur.IsDBNull(curseur.GetOrdinal("PrixHT")) ? -1f : curseur.GetFloat(curseur.GetOrdinal("PrixHT"));
                            prixTTC = curseur.IsDBNull(curseur.GetOrdinal("PrixTTC")) ? -1f : curseur.GetFloat(curseur.GetOrdinal("PrixTTC"));
                            difference = curseur.IsDBNull(curseur.GetOrdinal("Difference")) ? -1f : curseur.GetFloat(curseur.GetOrdinal("Difference"));
                            factureLignes.Add(new FactureLigne(id, nom, prestation, date, commentaire, prixHT, prixTTC, difference));
                        }
                    }
                }
            }
            return factureLignes;
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité FacturePrestation.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db </param>
        /// <returns>La liste des instances de type FacturePrestation récupéré à partir du curseur SQL.</returns>
        public List<FacturePrestation> RecupererTablePrestation(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            List<FacturePrestation> prestationLignes = new List<FacturePrestation>();
            string prestationNom;
            int prestationId;
            float pourcentageTVA;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Prestation", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        while (curseur.Read())
                        {
                            prestationId = curseur.GetInt32(curseur.GetOrdinal("Id"));
                            prestationNom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            pourcentageTVA = curseur.IsDBNull(curseur.GetOrdinal("PourcentageTVA")) ? -1f : curseur.GetFloat(curseur.GetOrdinal("PourcentageTVA"));
                            prestationLignes.Add(new FacturePrestation(prestationNom, pourcentageTVA));
                        }
                    }
                }
            }
            return prestationLignes;
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, puis de retourner une liste des instances de l'entité SiteFavorisLigne.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        /// <returns>La liste des instances de type InventaireMarque récupéré à partir du curseur SQL.</returns>
        public List<SiteFavorisLigne> RecupererTableSiteFav(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            List<SiteFavorisLigne> sitesLignes = new List<SiteFavorisLigne>();
            string siteNom;
            string siteUrl;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM SiteFavoris", connection))
                {
                    using (SQLiteDataReader curseur = command.ExecuteReader())
                    {
                        while (curseur.Read())
                        {
                            siteNom = curseur.GetString(curseur.GetOrdinal("Nom"));
                            siteUrl = curseur.GetString(curseur.GetOrdinal("Url"));
                            sitesLignes.Add(new SiteFavorisLigne(siteNom, siteUrl));
                        }
                    }
                }
            }
            return sitesLignes;
        }

        /// <summary>
        ///  Permet de créer et d'écrire un nouveau fichier .db qui aura toutes les données de l'inventaire, des factures, des marques, des types et autre.
        /// </summary>
        /// <param name="chemin">Chemin où la création et écriture du fichier sera faite.</param>
        public void EcrireBdd(string chemin)
        {
            List<InventaireLigne> inventaireActuelle = formGestionRef.RecupererInventaireActuelle();
            List<InventaireMarque> marquesActuelle = formGestionRef.RecupererMarquesActuelle();
            List<InventaireType> typesActuelle = formGestionRef.RecupererTypesActuelle();
            List<FactureLigne> facturesActuelle = formGestionRef.RecupererFacturesActuelle();
            List<FacturePrestation> prestationsActuelle = formGestionRef.RecupererPrestationsActuelle();
            List<SiteFavorisLigne> sitesFavActuelle = formGestionRef.RecupererSitesFavActuelle();
            string connectionTexte;
            SQLiteConnection.CreateFile(chemin);
            connectionTexte = @"Data Source=" + chemin + ";Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [Inventaire] ([Id] bigint NOT NULL, [Type] text,[Marque] text, [Nom] text, [Annee] text, [Prix] real, [Quantite] bigint NOT NULL,[DateEntree] text, [DateSortie] text, [Commentaire] text, CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO Inventaire (Id, Type, Marque, Nom, Annee, Prix, Quantite, DateEntree, DateSortie, Commentaire) VALUES (@Id, @Type, @Marque, @Nom, @Annee, @Prix, @Quantite, @DateEntree, @DateSortie, @Commentaire)", connection, transaction))
                        {
                            for (int i = 0; i < inventaireActuelle.Count; i++)
                            {
                                InventaireLigne inventaireLigne = inventaireActuelle[i];
                                command2.Parameters.AddWithValue("@Id", inventaireLigne.id);
                                command2.Parameters.AddWithValue("@Type", inventaireLigne.type);
                                command2.Parameters.AddWithValue("@Marque", inventaireLigne.marque);
                                command2.Parameters.AddWithValue("@Nom", inventaireLigne.nom);
                                command2.Parameters.AddWithValue("@Annee", inventaireLigne.annee);
                                if (inventaireLigne.prix != -1)
                                {
                                    command2.Parameters.AddWithValue("@Prix", inventaireLigne.prix);
                                }
                                else
                                {
                                    command2.Parameters.AddWithValue("@Prix", DBNull.Value);
                                }
                                command2.Parameters.AddWithValue("@Quantite", inventaireLigne.quantite);
                                command2.Parameters.AddWithValue("@DateEntree", inventaireLigne.dateEntree);
                                command2.Parameters.AddWithValue("@DateSortie", inventaireLigne.dateSortie);
                                command2.Parameters.AddWithValue("@Commentaire", inventaireLigne.commentaire);
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [Marque] ([Id] bigint NOT NULL, [Nom] text,CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO Marque (Id, Nom) VALUES (@Id, @Nom)", connection, transaction))
                        {
                            for (int i = 0; i < marquesActuelle.Count; i++)
                            {
                                command2.Parameters.AddWithValue("@Id", i);
                                command2.Parameters.AddWithValue("@Nom", marquesActuelle[i].nom);
                                command2.ExecuteNonQuery();
                            }
                            
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [Type] ([Id] bigint NOT NULL, [Nom] text,CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO Type (Id, Nom) VALUES (@Id, @Nom)", connection, transaction))
                        {
                            for (int i = 0; i < typesActuelle.Count; i++)
                            {
                                command2.Parameters.AddWithValue("@Id", i);
                                command2.Parameters.AddWithValue("@Nom", typesActuelle[i].nom);
                                command2.ExecuteNonQuery();
                            }

                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [Facture] ([Id] bigint NOT NULL, [Nom] text,[Prestation] text, [Date] text, [Commentaire] text, [PrixHT] real, [PrixTTC] real, [Difference] real, CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO Facture (Id, Nom, Prestation, Date, Commentaire, PrixHT, PrixTTC, Difference) VALUES (@Id, @Nom, @Prestation, @Date, @Commentaire, @PrixHT, @PrixTTC, @Difference)", connection, transaction))
                        {
                            for (int i = 0; i < facturesActuelle.Count; i++)
                            {
                                FactureLigne factureLigne = facturesActuelle[i];
                                command2.Parameters.AddWithValue("@Id", factureLigne.id);
                                command2.Parameters.AddWithValue("@Nom", factureLigne.nom);
                                command2.Parameters.AddWithValue("@Prestation", factureLigne.prestation);
                                command2.Parameters.AddWithValue("@Date", factureLigne.date);
                                command2.Parameters.AddWithValue("@Commentaire", factureLigne.commentaire);
                                if (factureLigne.prixHT != -1)
                                {
                                    command2.Parameters.AddWithValue("@PrixHT", factureLigne.prixHT);
                                }
                                else
                                {
                                    command2.Parameters.AddWithValue("@PrixHT", DBNull.Value);
                                }
                                if (factureLigne.prixTTC != -1)
                                {
                                    command2.Parameters.AddWithValue("@PrixTTC", factureLigne.prixTTC);
                                }
                                else
                                {
                                    command2.Parameters.AddWithValue("@PrixTTC", DBNull.Value);
                                }
                                if (factureLigne.difference != -1)
                                {
                                    command2.Parameters.AddWithValue("@Difference", factureLigne.difference);
                                }
                                else
                                {
                                    command2.Parameters.AddWithValue("@Difference", DBNull.Value);
                                }
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [Prestation] ([Id] bigint NOT NULL, [Nom] text, [PourcentageTVA] real, CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO Prestation (Id, Nom, PourcentageTVA) VALUES (@Id, @Nom, @PourcentageTVA)", connection, transaction))
                        {
                            for (int i = 0; i < prestationsActuelle.Count; i++)
                            {
                                command2.Parameters.AddWithValue("@Id", i);
                                command2.Parameters.AddWithValue("@Nom", prestationsActuelle[i].nom);
                                command2.Parameters.AddWithValue("@PourcentageTVA", prestationsActuelle[i].pourcentageTVA);
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE [SiteFavoris] ([Id] bigint NOT NULL, [Nom] text, [Url] text, CONSTRAINT [sqlite_master_PK_Inventaire] PRIMARY KEY ([Id]));", connection, transaction))
                    {
                        command.ExecuteNonQuery();
                        using (SQLiteCommand command2 = new SQLiteCommand("INSERT INTO SiteFavoris (Id, Nom, Url) VALUES (@Id, @Nom, @Url)", connection, transaction))
                        {
                            for (int i = 0; i < sitesFavActuelle.Count; i++)
                            {
                                command2.Parameters.AddWithValue("@Id", i);
                                command2.Parameters.AddWithValue("@Nom", sitesFavActuelle[i].nom);
                                command2.Parameters.AddWithValue("@Url", sitesFavActuelle[i].url);
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, et de vérifier si la table facture existe.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        public bool VerifierExistanceTableFacture(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Facture';", connection))
                {
                    object result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }

        /// <summary>
        ///  Permet de lire le fichier .db directement, et de vérifier si la table siteFavoris existe.
        /// </summary>
        /// <param name="connectionTexteTemp">Le texte qui permet la connexion temporaire avec le fichier .db .</param>
        public bool VerifierExistanceTableSiteFavoris(string connectionTexteTemp)
        {
            connectionTexte = connectionTexteTemp;
            using (SQLiteConnection connection = new SQLiteConnection(connectionTexte))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='SiteFavoris';", connection))
                {
                    object result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }
    }
}
