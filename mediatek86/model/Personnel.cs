using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatek86.model
{
    /// <summary>
    /// Package contenant les classes métiers de l'application.
    /// </summary>
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Classe métier représentant un personnel
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idpersonnel"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="service"></param>
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, Service service)
        {
            this.Idpersonnel = idpersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Service = service;
        }

        /// <summary>
        /// Id du personnel
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Nom du personnel
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du personnel
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Téléphone du personnel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Mail du personnel
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Service du personnel
        /// </summary>
        public Service Service { get; set; }
    }
}
