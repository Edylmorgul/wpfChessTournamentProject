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
    /// Logique d'interaction pour Joueur.xaml
    /// </summary>
    public partial class Joueur : Window
    {
        private IJoueurDAO DAO = new JoueurDAO();
        CLUB clubHote;
        public Joueur()
        {
            InitializeComponent();
        }

        public Joueur(CLUB club)
        {
            InitializeComponent();
            clubHote = club;
            foreach(var item in DAO.GetAllJoueurByClub(clubHote))
            {
                listeJoueur.Items.Add(item).ToString();
            }
        }

        /// <summary>
        /// Methode pour fermer le programme proprement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Methode pour ajouter un joueur en base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterJoueur_Click(object sender, RoutedEventArgs e)
        {
            JOUEUR joueur = new JOUEUR();
            if(txtNom.Text== "" || txtPrenom.Text== "" || txtDefaite.Text== "" || txtVictoire.Text== "")
            {
                MessageBox.Show("Veuillez remplir les champs ou choisir un joueur !");
            }

            else
            {
                int totalMatch;
                joueur.idClub = clubHote.idClub;
                joueur.nomJoueur = txtNom.Text;
                joueur.prenomJoueur = txtPrenom.Text;
                joueur.nbrVictoire = Convert.ToInt32(txtVictoire.Text);
                joueur.nbrDefaite = Convert.ToInt32(txtDefaite.Text);
                totalMatch = Convert.ToInt32(txtVictoire.Text) + Convert.ToInt32(txtDefaite.Text);
                joueur.nbrMatch = totalMatch;
                if(DAO.Create(joueur))
                {
                    List<JOUEUR> listeDbJoueur = DAO.GetAllJoueurByClub(clubHote);
                    foreach (var item in listeDbJoueur)
                    {
                        listeJoueur.Items.Remove(item);
                    }

                    foreach (var item in listeDbJoueur)
                    {
                        listeJoueur.Items.Add(item);
                    }
                    txtNom.Text = "";
                    txtPrenom.Text = "";
                    txtVictoire.Text = "";
                    txtDefaite.Text = "";
                }

                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la creation !");
                }
            }
        }
        
        private void TxtDefaite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true;
            else e.Handled = false;
        }

        private void TxtMatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; 
            else e.Handled = false;
        }

        private void TxtVictoire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true;
            else e.Handled = false;
        }

        /// <summary>
        /// Permet de changer le curseur de base en 'main' une fois dans la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void joueurGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
            {
                Mouse.OverrideCursor = Cursors.Hand;
            }                
        }

        /// <summary>
        /// Reviens au curseur de base quand le curseur quitte la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void joueurGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }                
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            Start fenetre = new Start();
            fenetre.Show();
            this.Close();
        }
    }
}
