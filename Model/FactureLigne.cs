using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceInformatiqueInventaire.Model
{
    public class FactureLigne
    {
        /// <summary>
        /// L'id de la facture.
        /// </summary>
        public int id;
        /// <summary>
        /// Le nom de la facture.
        /// </summary>
        public string nom;
        /// <summary>
        /// La prestation de la facture.
        /// </summary>
        public string prestation;
        /// <summary>
        /// La date de la facture.
        /// </summary>
        public string date;
        /// <summary>
        /// Le commentaire de la facture.
        /// </summary>
        public string commentaire;
        /// <summary>
        /// Le prix hors-taxes de la facture.
        /// </summary>
        public float prixHT;
        /// <summary>
        /// Le prix toute taxe comprise de la facture.
        /// </summary>
        public float prixTTC;
        /// <summary>
        /// La difference entre le prixHT et le prix TTC, la TVA.
        /// </summary>
        public float difference;


        /// <summary>
        /// Constructeur de l'entité factureLigne.
        /// </summary>
        public FactureLigne(int id, string nom, string prestation, string date, string commentaire, float prixHT, float prixTTC, float difference)
        {
            this.id = id;
            this.nom = nom;
            this.prestation = prestation;
            this.date = date;
            this.commentaire = commentaire;
            this.prixHT = prixHT;
            this.prixTTC = prixTTC;
            this.difference = difference;
        }
    }
}
