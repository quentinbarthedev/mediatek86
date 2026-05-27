using mediatek86.controller;
using mediatek86.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mediatek86.view
{
    /// <summary>
    /// Fenêtre de gestion des absences
    /// </summary>
    public partial class FrmAbsences : Form
    {
        /// <summary>
        /// Id du personnel concerné
        /// </summary>
        private int idpersonnel;

        /// <summary>
        /// Ancienne date de début en cas de modification
        /// </summary>
        private DateTime ancienneDatedebut;

        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean enCoursDeModifAbsence = false;

        /// <summary>
        /// Objet pour gérer la liste des absences
        /// </summary>
        private BindingSource bdgAbsences = new BindingSource();

        /// <summary>
        /// Objet pour gérer la liste des motifs
        /// </summary>
        private BindingSource bdgMotifs = new BindingSource();

        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmAbsencesController controller;

        /// <summary>
        /// Construction des composants graphiques et appel des autres initialisations
        /// </summary>
        /// <param name="idpersonnel"></param>
        public FrmAbsences(int idpersonnel)
        {
            InitializeComponent();
            this.idpersonnel = idpersonnel;
            Init();
        }

        /// <summary>
        /// Initialisations :
        /// Création du controleur et remplissage des listes
        /// </summary>
        private void Init()
        {
            controller = new FrmAbsencesController();
            RemplirListeAbsences();
            RemplirListeMotifs();
            EnCoursModifAbsence(false);
        }

        /// <summary>
        /// Affiche les absences
        /// </summary>
        private void RemplirListeAbsences()
        {
            List<Absence> lesAbsences = controller.GetLesAbsences(idpersonnel);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsences.DataSource = bdgAbsences;
            dgvAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Affiche les motifs
        /// </summary>
        private void RemplirListeMotifs()
        {
            List<Motif> lesMotifs = controller.GetLesMotifs();
            bdgMotifs.DataSource = lesMotifs;
            cboMotif.DataSource = bdgMotifs;
        }

        /// <summary>
        /// Modification d'affichage suivant si on est en cours de modif ou d'ajout d'une absence
        /// </summary>
        /// <param name="modif"></param>
        private void EnCoursModifAbsence(Boolean modif)
        {
            enCoursDeModifAbsence = modif;
            grbAbsence.Enabled = modif;

            if (modif)
            {
                grbAbsence.Text = "modifier une absence";
            }
            else
            {
                grbAbsence.Text = "ajouter une absence";
                dtpDateDebut.Value = DateTime.Now;
                dtpDateFin.Value = DateTime.Now;
                cboMotif.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Demande d'ajout d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            EnCoursModifAbsence(false);
            grbAbsence.Enabled = true;
        }

        /// <summary>
        /// Demande de modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                EnCoursModifAbsence(true);
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                dtpDateDebut.Value = absence.Datedebut;
                dtpDateFin.Value = absence.Datefin;
                cboMotif.SelectedIndex = cboMotif.FindStringExact(absence.Motif.Libelle);
                ancienneDatedebut = absence.Datedebut;
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Demande de suppression d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];

                if (MessageBox.Show("Voulez-vous vraiment supprimer cette absence ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DelAbsence(absence, idpersonnel);
                    RemplirListeAbsences();
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Demande d'enregistrement de l'ajout ou de la modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboMotif.SelectedIndex != -1)
            {
                if (dtpDateFin.Value >= dtpDateDebut.Value)
                {
                    Motif motif = (Motif)bdgMotifs.List[bdgMotifs.Position];
                    Absence absence = new Absence(dtpDateDebut.Value, dtpDateFin.Value, motif);

                    if (enCoursDeModifAbsence)
                    {
                        if (!controller.ControleAbsenceModif(absence, idpersonnel, ancienneDatedebut))
                        {
                            controller.UpdateAbsence(absence, idpersonnel, ancienneDatedebut);
                            RemplirListeAbsences();
                            EnCoursModifAbsence(false);
                        }
                        else
                        {
                            MessageBox.Show("Une absence est déjà programmée sur ce créneau.", "Information");
                        }
                    }
                    else
                    {
                        if (!controller.ControleAbsence(absence, idpersonnel))
                        {
                            controller.AddAbsence(absence, idpersonnel);
                            RemplirListeAbsences();
                            EnCoursModifAbsence(false);
                        }
                        else
                        {
                            MessageBox.Show("Une absence est déjà programmée sur ce créneau.", "Information");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Information");
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
        }

        /// <summary>
        /// Annule la demande d'ajout ou de modification d'une absence
        /// Vide les zones de saisie de l'absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EnCoursModifAbsence(false);
            }
        }

        private void FrmAbsences_Load(object sender, EventArgs e)
        {

        }
    }
}
