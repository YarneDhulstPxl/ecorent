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
using EcoRent.View;
using EcoRent.ViewModel;
using EcoRent.Model;

namespace EcoRent.View
{
    /// <summary>
    /// Interaction logic for OverzichtReservatie.xaml
    /// </summary>
    public partial class OverzichtReservatie : Window
    {
        private ReservatieViewModel reservatieViewModel = new ReservatieViewModel();
        private Chauffeur chauffeur;
        public OverzichtReservatie(Chauffeur chauffeur)
        {
            InitializeComponent();
            this.chauffeur = chauffeur;
            chauffeurName.Text = chauffeur.VoorNaam + " " + chauffeur.Naam;
            reservatieViewModel.SelectReservaties = reservatieViewModel.GetReservatiesByChauffeurID(chauffeur.ChauffeurID);
            DataContext = reservatieViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reservatieViewModel.VerwijderenReservatie();
            reservatieViewModel.SelectReservaties = reservatieViewModel.GetReservatiesByChauffeurID(chauffeur.ChauffeurID);
        }
    }
}
