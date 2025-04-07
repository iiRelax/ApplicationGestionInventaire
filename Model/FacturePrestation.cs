using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace FranceInformatiqueInventaire.Model
{
    public class FacturePrestation
    {
        /// <summary>
        /// Le nom de la prestation.
        /// </summary>
        public string nom;
        /// <summary>
        /// Son pourcentage.
        /// </summary>
        public float pourcentageTVA;

        /// <summary>
        /// Constructeur de l'entité facturePrestation.
        /// </summary>
        public FacturePrestation(string nom, float pourcentageTVA)
        {
            this.nom = nom;
            this.pourcentageTVA = pourcentageTVA;
        }

        /// <summary>
        /// Override du ToString() pour retourner le nom puis le pourcentageTVA.
        /// </summary>
        public override string ToString()
        {
            return nom + " (" + pourcentageTVA + "%)";
        }
    }
}
