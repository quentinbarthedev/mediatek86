using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatek86.model
{
    /// <summary>
    /// Classe métier représentant une absence
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="datedebut"></param>
        /// <param name="datefin"></param>
        /// <param name="motif"></param>
        public Absence(DateTime datedebut, DateTime datefin, Motif motif)
        {
            this.Datedebut = datedebut;
            this.Datefin = datefin;
            this.Motif = motif;
        }

        public DateTime Datedebut { get; set; }
        public DateTime Datefin { get; set; }
        public Motif Motif { get; set; }
    }
}
