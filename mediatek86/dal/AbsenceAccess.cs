using mediatek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatek86.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les absences
    /// </summary>
    public class AbsenceAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public AbsenceAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les absences d'un personnel
        /// </summary>
        /// <param name="idpersonnel"></param>
        /// <returns>liste des absences</returns>
        public List<Absence> GetLesAbsences(int idpersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            if (access.Manager != null)
            {
                string req = "select a.datedebut as datedebut, a.datefin as datefin, m.idmotif as idmotif, m.libelle as motif ";
                req += "from absence a join motif m on (a.idmotif = m.idmotif) ";
                req += "where a.idpersonnel = @idpersonnel ";
                req += "order by datedebut desc;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            Motif motif = new Motif((int)record[2], (string)record[3]);
                            Absence absence = new Absence((DateTime)record[0], (DateTime)record[1], motif);
                            lesAbsences.Add(absence);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesAbsences;
        }

        /// <summary>
        /// Demande d'ajout d'une absence
        /// </summary>
        /// <param name="absence">objet absence à ajouter</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        public void AddAbsence(Absence absence, int idpersonnel)
        {
            if (access.Manager != null)
            {
                string req = "insert into absence(idpersonnel, datedebut, datefin, idmotif) ";
                req += "values (@idpersonnel, @datedebut, @datefin, @idmotif);";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                parameters.Add("@datedebut", absence.Datedebut);
                parameters.Add("@datefin", absence.Datefin);
                parameters.Add("@idmotif", absence.Motif.Idmotif);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de suppression d'une absence
        /// </summary>
        /// <param name="absence">objet absence à supprimer</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        public void DelAbsence(Absence absence, int idpersonnel)
        {
            if (access.Manager != null)
            {
                string req = "delete from absence ";
                req += "where idpersonnel = @idpersonnel and datedebut = @datedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                parameters.Add("@datedebut", absence.Datedebut);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification d'une absence
        /// </summary>
        /// <param name="absence">objet absence à modifier</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        /// <param name="ancienneDatedebut">ancienne date de début</param>
        public void UpdateAbsence(Absence absence, int idpersonnel, DateTime ancienneDatedebut)
        {
            if (access.Manager != null)
            {
                string req = "update absence set datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif ";
                req += "where idpersonnel = @idpersonnel and datedebut = @ancienneDatedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                parameters.Add("@datedebut", absence.Datedebut);
                parameters.Add("@datefin", absence.Datefin);
                parameters.Add("@idmotif", absence.Motif.Idmotif);
                parameters.Add("@ancienneDatedebut", ancienneDatedebut);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Controle si une absence existe déjà sur le même créneau
        /// </summary>
        /// <param name="absence">absence à contrôler</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        /// <returns>true si une absence existe déjà sur le même créneau</returns>
        public Boolean ControleAbsence(Absence absence, int idpersonnel)
        {
            if (access.Manager != null)
            {
                string req = "select * from absence ";
                req += "where idpersonnel = @idpersonnel ";
                req += "and datedebut <= @datefin ";
                req += "and datefin >= @datedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                parameters.Add("@datedebut", absence.Datedebut);
                parameters.Add("@datefin", absence.Datefin);
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return (records.Count > 0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }

        /// <summary>
        /// Controle si une autre absence existe déjà sur le même créneau lors d'une modification
        /// </summary>
        /// <param name="absence">absence à contrôler</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        /// <param name="ancienneDatedebut">ancienne date de début</param>
        /// <returns>true si une autre absence existe déjà sur le même créneau</returns>
        public Boolean ControleAbsenceModif(Absence absence, int idpersonnel, DateTime ancienneDatedebut)
        {
            if (access.Manager != null)
            {
                string req = "select * from absence ";
                req += "where idpersonnel = @idpersonnel ";
                req += "and datedebut <= @datefin ";
                req += "and datefin >= @datedebut ";
                req += "and datedebut <> @ancienneDatedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", idpersonnel);
                parameters.Add("@datedebut", absence.Datedebut);
                parameters.Add("@datefin", absence.Datefin);
                parameters.Add("@ancienneDatedebut", ancienneDatedebut);
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return (records.Count > 0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }

    }
}
