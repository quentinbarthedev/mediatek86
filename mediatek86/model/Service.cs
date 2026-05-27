using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatek86.model
{
    /// <summary>
    /// Classe métier représentant un service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Id du service
        /// </summary>
        public int Idservice { get; }

        /// <summary>
        /// Nom du service
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idservice"></param>
        /// <param name="nom"></param>
        public Service(int idservice, string nom)
        {
            this.Idservice = idservice;
            this.Nom = nom;
        }

        /// <summary>
        /// Définit l'information à afficher (seulement le nom)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
