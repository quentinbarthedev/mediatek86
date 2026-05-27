using mediatek86.dal;
using mediatek86.model;
using System;
using System.Collections.Generic;

namespace mediatek86.controller
{
    /// <summary>
    /// Contrôleur de FrmAbsences
    /// </summary>
    public class FrmAbsencesController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur Absence
        /// </summary>
        private readonly AbsenceAccess absenceAccess;

        /// <summary>
        /// objet d'accès aux opérations possibles sur Motif
        /// </summary>
        private readonly MotifAccess motifAccess;

        /// <summary>
        /// Récupère les accès aux données
        /// </summary>
        public FrmAbsencesController()
        {
            absenceAccess = new AbsenceAccess();
            motifAccess = new MotifAccess();
        }

        /// <summary>
        /// Récupère et retourne les absences d'un personnel
        /// </summary>
        /// <param name="idpersonnel"></param>
        /// <returns>liste des absences</returns>
        public List<Absence> GetLesAbsences(int idpersonnel)
        {
            return absenceAccess.GetLesAbsences(idpersonnel);
        }

        /// <summary>
        /// Récupère et retourne les motifs
        /// </summary>
        /// <returns>liste des motifs</returns>
        public List<Motif> GetLesMotifs()
        {
            return motifAccess.GetLesMotifs();
        }

        /// <summary>
        /// Demande d'ajout d'une absence
        /// </summary>
        /// <param name="absence">objet absence à ajouter</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        public void AddAbsence(Absence absence, int idpersonnel)
        {
            absenceAccess.AddAbsence(absence, idpersonnel);
        }

        /// <summary>
        /// Demande de suppression d'une absence
        /// </summary>
        /// <param name="absence">objet absence à supprimer</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        public void DelAbsence(Absence absence, int idpersonnel)
        {
            absenceAccess.DelAbsence(absence, idpersonnel);
        }

        /// <summary>
        /// Demande de modification d'une absence
        /// </summary>
        /// <param name="absence">objet absence à modifier</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        /// <param name="ancienneDatedebut">ancienne date de début</param>
        public void UpdateAbsence(Absence absence, int idpersonnel, DateTime ancienneDatedebut)
        {
            absenceAccess.UpdateAbsence(absence, idpersonnel, ancienneDatedebut);
        }

        /// <summary>
        /// Controle si une absence existe déjà sur le même créneau
        /// </summary>
        /// <param name="absence">absence à contrôler</param>
        /// <param name="idpersonnel">id du personnel concerné</param>
        /// <returns>true si une absence existe déjà sur le même créneau</returns>
        public Boolean ControleAbsence(Absence absence, int idpersonnel)
        {
            return absenceAccess.ControleAbsence(absence, idpersonnel);
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
            return absenceAccess.ControleAbsenceModif(absence, idpersonnel, ancienneDatedebut);
        }
    }
}