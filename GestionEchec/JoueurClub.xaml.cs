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
    /// Logique d'interaction pour JoueurClub.xaml
    /// </summary>
    public partial class JoueurClub : Window
    {
        IJoueurDAO JDAO = new JoueurDAO();
        IClubDAO CDAO = new ClubDAO();        

        public JoueurClub()
        {
            InitializeComponent();            
            List<CLUB> listeDbClub = CDAO.GetAll();         

            foreach(var item in listeDbClub)
            {
                ComboClub.Items.Add(item);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Methode pour afficher les joueurs en fonction du club choisi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CLUB club = new CLUB(); // Club précédent                     
            List<JOUEUR> listeJoueur = new List<JOUEUR>();
            List<JOUEUR> AllListeJoueur = new List<JOUEUR>();

            club = ComboClub.SelectedValue as CLUB;
            listeJoueur = JDAO.GetAllJoueurByClub(club);
            AllListeJoueur = JDAO.GetAll(); // Besoin pour vider complétement la liste, sinon il garde en mémoire les items déjà selectionné par d'autres clubs
            listeJoueurParClub.Visibility = Visibility.Visible;          

            foreach (var item in AllListeJoueur) // On vide complétement la liste après chaque changement de valeur
            {
                listeJoueurParClub.Items.Remove(item);
            }

            foreach (var item in listeJoueur) // On remplace par la nouvelle valeur
            {
                listeJoueurParClub.Items.Add(item);
            }
        }
    }
}
