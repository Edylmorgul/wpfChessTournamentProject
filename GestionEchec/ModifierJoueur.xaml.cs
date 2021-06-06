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
    /// Logique d'interaction pour ModifierJoueur.xaml
    /// </summary>
    public partial class ModifierJoueur : Window
    {
        IJoueurDAO DAO = new JoueurDAO();
        public ModifierJoueur()
        {
            InitializeComponent();
        }

        public ModifierJoueur(int id)
        {           
            InitializeComponent();
            JOUEUR joueur = DAO.GetById(id);
            modifGrid.DataContext = joueur;
        }

        private void TxtMatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtVictoire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtDefaite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void modifGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void modifGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Methode pour retourner vers infosJoueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            InfosJoueur fenetre = new InfosJoueur();
            fenetre.Show();
            this.Close();
        }

        /// <summary>
        /// Methode pour valider les modifications d'éditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValiderModif_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text !="" && txtPrenom.Text!="" && txtVictoire.Text!="" && txtDefaite.Text!="") //Une autre façon de faire la condition de validation
            {
                JOUEUR tmp = new JOUEUR();
                tmp = modifGrid.DataContext as JOUEUR;
                tmp.nomJoueur = txtNom.Text;
                tmp.prenomJoueur = txtPrenom.Text;
                tmp.nbrVictoire = Convert.ToInt32(txtVictoire.Text);
                tmp.nbrDefaite = Convert.ToInt32(txtDefaite.Text);
                int totalMatch = Convert.ToInt32(txtVictoire.Text) + Convert.ToInt32(txtDefaite.Text);
                tmp.nbrMatch = totalMatch;
                if(DAO.Update(tmp))
                {
                    modifGrid.DataContext = tmp;
                    MessageBox.Show("Modification réussie !");
                }

                else
                {
                    MessageBox.Show("L'opération de modification a échouée");
                }                
            }

            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }
    }
}
