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
using EcoRent.Model;

namespace EcoRent.View
{
    /// <summary>
    /// Interaction logic for BoekenReservatie.xaml
    /// </summary>
    public partial class BoekenReservatie : Window
    {
        private Chauffeur chauffeur;
        private Auto auto;

        public BoekenReservatie(Chauffeur chauffeur)
        {
            InitializeComponent();
            this.chauffeur = chauffeur;
        }

        private void maakReservatie_Click(object sender, RoutedEventArgs e)
        {
            if (reservatieList.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een auto!");
            }
            else
            {
                auto = (Auto)reservatieList.SelectedItem;
                DetailReservatie detailReservatie = new DetailReservatie(auto, chauffeur);
                detailReservatie.Show();
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void bekijkReservatie_Click(object sender, RoutedEventArgs e)
        {

            OverzichtReservatie overzichtReservatie = new OverzichtReservatie(chauffeur);
            overzichtReservatie.Show();
        }
    }
}
