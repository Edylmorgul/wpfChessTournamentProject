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
    /// Logique d'interaction pour DetailJoueur.xaml
    /// </summary>
    public partial class DetailJoueur : Window
    {
        IJoueurDAO DAO = new JoueurDAO();
        public DetailJoueur()
        {
            InitializeComponent();
        }

        public DetailJoueur(int id)
        {
            InitializeComponent();
            JOUEUR joueur = DAO.GetById(id);
            detailGrid.DataContext = joueur;
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            InfosJoueur fenetre = new InfosJoueur();
            fenetre.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
