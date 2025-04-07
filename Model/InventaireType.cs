using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceInformatiqueInventaire.Model
{
    public class InventaireType
    {
        /// <summary>
        /// Le nom, c'est à dire le type en soi.
        /// </summary>
        public string nom;

        /// <summary>
        /// Constructeur de l'entité inventaireType.
        /// </summary>
        public InventaireType(string nom)
        {
            this.nom = nom;
        }
    }
}
