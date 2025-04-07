using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceInformatiqueInventaire.Model
{
    public class InventaireLigne
    {
        /// <summary>
        /// L'id de la facture.
        /// </summary>
        public int id;
        /// <summary>
        /// Le type de l'objet, par exemple ça peut être un pc complet, ou bien une carte graphique.
        /// </summary>
        public string type;
        /// <summary>
        /// La marque de l'objet.
        /// </summary>
        public string marque;
        /// <summary>
        /// Le nom de l'objet.
        /// </summary>
        public string nom;
        /// <summary>
        /// L'année de l'objet.
        /// </summary>
        public string annee;
        /// <summary>
        /// Le prix de l'objet, sa valeur dans l'inventaire.
        /// </summary>
        public float prix;
        /// <summary>
        /// Le quantité de l'objet.
        /// </summary>
        public int quantite;
        /// <summary>
        /// La date d'entrée de l'objet.
        /// </summary>
        public string dateEntree;
        /// <summary>
        /// Le date de sortie l'objet.
        /// </summary>
        public string dateSortie;
        /// <summary>
        /// Le commentaire de l'objet.
        /// </summary>
        public string commentaire;

        /// <summary>
        /// Le constructeur de l'entité inventaireLigne.
        /// </summary>
        public InventaireLigne(int id, string type, string marque, string nom, string annee, float prix, int quantite, string dateEntree, string dateSortie, string commentaire)
        {
            this.id = id;
            this.type = type;
            this.marque = marque;
            this.nom = nom;
            this.annee = annee;
            this.prix = prix;
            this.quantite = quantite;
            this.dateEntree = dateEntree;
            this.dateSortie = dateSortie;
            this.commentaire = commentaire;
        }
    }
}
