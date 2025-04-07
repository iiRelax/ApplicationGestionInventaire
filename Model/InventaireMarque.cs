using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceInformatiqueInventaire.Model
{
    public class InventaireMarque
    {
        /// <summary>
        /// Le nom, c'est à dire la marque en soi.
        /// </summary>
        public string nom;

        /// <summary>
        /// Constructeur de l'entité inventaireMarque.
        /// </summary>
        public InventaireMarque(string nom)
        {
            this.nom = nom;
        }
    }
}
