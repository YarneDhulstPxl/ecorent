using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EcoRent.Model;
using EcoRent.ViewModel;
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
    /// Interaction logic for ToevoegenAuto.xaml
    /// </summary>
    public partial class ToevoegenAuto : Window
    {
        AutoViewModel autoViewModel = new AutoViewModel();
        Auto auto = new Auto();

        public ToevoegenAuto()
        {
            InitializeComponent();
            auto.AutoID = autoViewModel.GetLastID();
            DataContext = auto;
        }

        private void ToevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            autoViewModel.CurrentAuto = auto;
            if (autoViewModel.CurrentAuto.Bouwjaar > DateTime.Now.Year || autoViewModel.CurrentAuto.Bouwjaar < 1950)
            {
                MessageBox.Show("Geef een geldig jaar in");
            }
            else if (autoViewModel.Valideer() == false)
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn!");
            }
               
            else
            {
                autoViewModel.ToevoegenAuto();
                back();
            }       
        }

        private void back()
        {
            BeheerAutos beheerAutos = new BeheerAutos();
            beheerAutos.Show();
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            back();
        }
    }
}
