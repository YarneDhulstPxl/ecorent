using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EcoRent.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EcoRent
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void chauffeurButton_Click(object sender, RoutedEventArgs e)
        {
            BeheerChauffeurs beheerChauffeurs = new BeheerChauffeurs();
            beheerChauffeurs.Show();
        }

        private void autoButton_Click(object sender, RoutedEventArgs e)
        {
            BeheerAutos beheerAutos = new BeheerAutos();
            beheerAutos.Show();
        }

        private void reservatieButton_Click(object sender, RoutedEventArgs e)
        {
            BeheerReservaties beheerReservaties = new BeheerReservaties();
            beheerReservaties.Show();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
