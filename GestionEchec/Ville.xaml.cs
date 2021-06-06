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
    /// Logique d'interaction pour Ville.xaml
    /// </summary>
    public partial class Ville : Window
    {
        private IVilleDAO DAO = new VilleDAO();
        PAYS paysHote;

        public Ville()
        {
            InitializeComponent();
        }

        public Ville(PAYS pays)
        {
            InitializeComponent();
            paysHote = pays;
            foreach (var item in DAO.GetAllCityByCountry(pays))
            {
                listeVille.Items.Add(item).ToString();
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

        private void AjouterVilleTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Methode pour ajouter une ville appartenant à un pays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterVille_Click(object sender, RoutedEventArgs e)
        {
            VILLE ville = new VILLE();
            if(AjouterVilleTxt.Text =="")
            {
                MessageBox.Show("Veuillez remplir le champ ou choisir une ville !");
            }

            else
            {
                ville.nomVille = AjouterVilleTxt.Text;
                ville.idPays = paysHote.idPays;
                if(DAO.CheckVilleDbByname(AjouterVilleTxt.Text) != null)
                {
                    MessageBox.Show("Ville déja présente pour ce pays");
                }

                else if(DAO.Create(ville))
                {
                    List<VILLE> listeDbVille = DAO.GetAllCityByCountry(paysHote);
                    foreach (var item in listeDbVille)
                    {
                        listeVille.Items.Remove(item);
                    }
                    foreach (var item in listeDbVille)
                    {
                        listeVille.Items.Add(item);
                    }                   
                    AjouterVilleTxt.Text = "";
                }

                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la creation !");
                }
            }
        }

        /// <summary>
        /// Methode pour valider le choix du pays et le renvoyer vers club
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            if(listeVille.SelectedItem != null)
            {
                Club fenetre = new Club(listeVille.SelectedItem as VILLE);
                fenetre.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Veuillez choisir ou ajouter une ville");
            }
        }

        /// <summary>
        /// Permet de changer le curseur de base en 'main' une fois dans la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void villeGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        /// <summary>
        /// Reviens au curseur de base quand le curseur quitte la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void villeGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
