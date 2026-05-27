using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatek86.model
{
    /// <summary>
    /// Classe métier représentant un motif d'absence
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Id du motif
        /// </summary>
        public int Idmotif { get; }

        /// <summary>
        /// Libellé du motif
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idmotif"></param>
        /// <param name="libelle"></param>
        public Motif(int idmotif, string libelle)
        {
            this.Idmotif = idmotif;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Définit l'information à afficher (seulement le libellé du motif)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
