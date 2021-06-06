using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionEchec
{
    /// <summary>
    /// Logique d'interaction pour Club.xaml
    /// </summary>
    public partial class Club : Window
    {
        private IClubDAO DAO = new ClubDAO();
        VILLE villeHote;

        public Club()
        {
            InitializeComponent();
        }

        public Club(VILLE ville)
        {
            InitializeComponent();
            villeHote = ville;
            foreach (var item in DAO.GetAllClubByCity(ville))
            {
                listeClub.Items.Add(item);
            }            
        }

        /// <summary>
        /// Methode pour fermer proprement le programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Methode pour ajouter un club en base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterClub_Click(object sender, RoutedEventArgs e)
        {
            CLUB club = new CLUB();
            if(txtNom.Text =="" || txtTel.Text =="")
            {
                MessageBox.Show("Veuillez remplir les champs ou choisir un club !");
            }

            else
            {
                club.idVille = villeHote.idVille;
                club.nomClub = txtNom.Text;
                club.numClub = Convert.ToInt32(txtTel.Text);

                if(DAO.Create(club))
                {
                    List<CLUB> listeDbClub = DAO.GetAllClubByCity(villeHote);
                    foreach(var item in listeDbClub)
                    {
                        listeClub.Items.Remove(item);
                    }

                    foreach(var item in listeDbClub)
                    {
                        listeClub.Items.Add(item);
                    }
                    txtNom.Text = "";
                    txtTel.Text = "";
                }

                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la creation !");
                }
            }
        }

        /// <summary>
        /// Methode pour valider le choix d'un club et le renvoyer vers joueurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            if(listeClub.SelectedItem != null)
            {
                Joueur fenetre = new Joueur(listeClub.SelectedItem as CLUB);
                fenetre.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Veuillez choisir ou ajouter un club");
            }
        }

        /// <summary>
        /// Permet de changer le curseur de base en 'main' une fois dans la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clubGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        /// <summary>
        /// Reviens au curseur de base quand le curseur quitte la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clubGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        /// <summary>
        /// Methode pour bloquer autre saisie que celui d'un nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 2
            else e.Handled = false;
        }        
    }
}
