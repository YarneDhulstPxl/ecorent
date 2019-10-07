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
using EcoRent.ViewModel;
using EcoRent.View;

namespace EcoRent
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            System.Threading.Thread.Sleep(3500);
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginText.Text;
  
            string pass = passwText.Text;
            
            ChauffeurViewModel chauffeurViewModel = new ChauffeurViewModel();
            chauffeurViewModel.CurrentChauffeur = chauffeurViewModel.ControleChauffeur(login, pass);
            
            if (chauffeurViewModel.CurrentChauffeur.ChauffeurID != 0)
            {
                if (chauffeurViewModel.CurrentChauffeur.Admin)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else
                {
                    BoekenReservatie boekenReservatie = new BoekenReservatie(chauffeurViewModel.CurrentChauffeur);
                    boekenReservatie.Show();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Verkeerde ingave!");
                loginText.Text = "";
                passwText.Text ="";
            } 

        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterChauffeur window = new RegisterChauffeur();
            window.Show();
            this.Close();
        }


    }
}
