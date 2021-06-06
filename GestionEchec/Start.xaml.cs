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
    /// Logique d'interaction pour Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        IJoueurDAO DAO = new JoueurDAO();
        public Start()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Methoede pour quitter le programme proprement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Methode pour choix d'action à effectuer ==> Menu du programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            IList<JOUEUR> listeJoueur = new List<JOUEUR>();
            listeJoueur = DAO.GetAll();
            if(choixJoueur.IsChecked == true) // Registre des joueurs
            {    
                if(listeJoueur.Count() == 0)
                {
                    MessageBox.Show("Aucun joueur présent dans le registre, veuillez en ajouter");
                }

                else
                {
                    InfosJoueur fenetre = new InfosJoueur();
                    fenetre.Show();
                }                
            }

            else if(choixClub.IsChecked == true) // Affichage joueur par club
            {
                if (listeJoueur.Count() == 0)
                {
                    MessageBox.Show("Aucun joueur présent dans le registre, veuillez en ajouter");
                }

                else
                {
                    JoueurClub fenetre = new JoueurClub();
                    fenetre.Show();
                }                
            }

            else //Création du tournoi d'échec
            {
                MainWindow fenetre = new MainWindow();
                this.Close();
                fenetre.Show();
            }
        }
       
    }
}
