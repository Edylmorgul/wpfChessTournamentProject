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
    /// Logique d'interaction pour InfosJoueur.xaml
    /// </summary>
    public partial class InfosJoueur : Window
    {
        IJoueurDAO DAO = new JoueurDAO();        
        public InfosJoueur()
        {
            InitializeComponent();
            List<JOUEUR> listeDbJoueur = DAO.GetAll();
            IList<JOUEUR> liste = new List<JOUEUR>();
            foreach (var item in listeDbJoueur)
            {
                //registreJoueur.Items.Add(SERVICE.DisplayInfosPlayers(item));
                liste.Add(item);
            }
            registreJoueur.ItemsSource = liste;
        }

        /// <summary>
        /// Methode afin d'éditer les informations du joueur selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPlayer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            JOUEUR joueur = b.CommandParameter as JOUEUR;
            ModifierJoueur fenetre = new ModifierJoueur(joueur.idJoueur);
            this.Close();
            fenetre.Show();
        }

        /// <summary>
        /// Methode afin de supprimer le joueur selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            JOUEUR joueur = b.CommandParameter as JOUEUR; // Afin de recevoir le joueur "appartenant" au bouton

            if (DAO.DeleteById(joueur.idJoueur))
            {
                List<JOUEUR> listeDbJoueur = DAO.GetAll();
                IList<JOUEUR> liste = new List<JOUEUR>();
                foreach (var item in listeDbJoueur)
                {
                    liste.Remove(item);
                }
                foreach (var item in listeDbJoueur)
                {
                    liste.Add(item);
                }
                registreJoueur.ItemsSource = liste;
                //registreJoueur.Items.Refresh(); ==> Ce truc ne marche pas !            
            }            
            else
            {
                MessageBox.Show("Une erreur est survenue lors de la suppression");
            }            
        }

        /// <summary>
        /// Methode pour afficher la description d'un joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailPlayer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            JOUEUR joueur = b.CommandParameter as JOUEUR;
            DetailJoueur fenetre = new DetailJoueur(joueur.idJoueur);
            this.Close();
            fenetre.Show();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
