using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EcoRent.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EcoRent.Model;

namespace EcoRent
{
    /// <summary>
    /// Interaction logic for RegisterChauffeur.xaml
    /// </summary>
    public partial class RegisterChauffeur : Window
    {
        ChauffeurViewModel chauffeurViewModel = new ChauffeurViewModel();
        Chauffeur chauffeur = new Chauffeur();
        public RegisterChauffeur()
        {
            InitializeComponent();
            
            DataContext = chauffeur;
            chauffeur.ChauffeurID = chauffeurViewModel.GetLastID();
            chauffeur.GeboorteDatum = DateTime.Now;
        }

        private void RegistreerButton_Click(object sender, RoutedEventArgs e)
        {
            chauffeurViewModel.CurrentChauffeur = chauffeur;
            chauffeurViewModel.CurrentChauffeur.Admin = false;

            /*if (DateTime.Now.Year - chauffeurViewModel.CurrentChauffeur.GeboorteDatum.Year < 18)
                MessageBox.Show("Je moet 18 jaar zijn!");
            else*/ if (chauffeurViewModel.Valideer() == false)
                MessageBox.Show("Alle velden moeten ingevuld zijn!");
            else{
                chauffeurViewModel.ToevoegenChauffeur();
                back();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            back();
        }

        private void back()
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
