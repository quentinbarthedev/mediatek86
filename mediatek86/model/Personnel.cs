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
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, Service service)
        {
            this.Idpersonnel = idpersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Service = service;
        }

        public int Idpersonnel { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public Service Service { get; set; }
    }
}
