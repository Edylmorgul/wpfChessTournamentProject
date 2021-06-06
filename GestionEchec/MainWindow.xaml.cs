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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionEchec
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPaysDAO DAO = new PaysDAO(); // Liens base de donnée
        
        public MainWindow()
        {            
            InitializeComponent();
            List<PAYS> listeDbPays = DAO.GetAll();
            foreach(var item in listeDbPays)
            {
                listePays.Items.Add(item).ToString();                
            }
        }

        /// <summary>
        /// Quitter le programme proprement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ajout d'un pays en base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterPays_Click(object sender, RoutedEventArgs e)
        {
            PAYS pays = new PAYS();
            
            if (AjouterPaysTxt.Text == "")
            {
                MessageBox.Show("Veuillez remplir le champ ou choisir un pays !");
            }

            else
            {
                pays.nomPays = AjouterPaysTxt.Text;
                if (DAO.CheckPaysDbByName(AjouterPaysTxt.Text) != null)
                {
                    MessageBox.Show("Pays déjà présent, veuillez en ajouter un nouveau !");
                }

                else if(DAO.Create(pays))
                {
                    List<PAYS> listeDbPays = DAO.GetAll();
                    foreach(var item in listeDbPays) // Pour rafraichir la liste des pays
                    {
                        listePays.Items.Remove(item);
                    }
                    foreach(var item in listeDbPays)
                    {
                        listePays.Items.Add(item);
                    }                    
                    AjouterPaysTxt.Text = "";
                }

                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la creation !");
                }
            }            
        }

        /// <summary>
        /// Selection d'un pays afin de le renvoyer dans une seconde fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaysValider_Click(object sender, RoutedEventArgs e)
        {
            if(listePays.SelectedItem !=null)
            {
                Ville fenetre = new Ville(listePays.SelectedItem as PAYS);
                fenetre.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Veuillez choisir ou ajouter un pays");
            }
        }

        /// <summary>
        /// Permet de changer le curseur de base en 'main' une fois dans la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaysGrid_MouseEnter(object sender, MouseEventArgs e) // nouveautée 1
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        /// <summary>
        /// Reviens au curseur de base quand le curseur quitte la grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaysGrid_MouseLeave(object sender, MouseEventArgs e) // nouveautée 1
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void AjouterPaysTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Methode pour retourner à l'écrna de selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            Start fenetre = new Start();
            this.Close();
            fenetre.Show();
        }
    }
}
