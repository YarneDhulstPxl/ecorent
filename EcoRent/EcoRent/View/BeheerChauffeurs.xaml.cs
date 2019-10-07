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

namespace EcoRent
{
    /// <summary>
    /// Interaction logic for BeheerChauffeurs.xaml
    /// </summary>
    public partial class BeheerChauffeurs : Window
    {
        public BeheerChauffeurs()
        {
            InitializeComponent();
            
        }

        private void geboorteDatum_SelectedDateChanged_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if (DateTime.Now.Year - Convert.ToDateTime(geboorteDatum.Text).Year < 18)
            {
                MessageBox.Show("Je moet 18 jaar zijn!");
            }*/
                
        }

        private void verwijderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Als er nog reserveringen zijn op deze chauffeur word de verwijdering geblokeerd");
        }
    }
}
