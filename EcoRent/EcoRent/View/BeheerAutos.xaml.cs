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

namespace EcoRent.View
{
    /// <summary>
    /// Interaction logic for BeheerAutos.xaml
    /// </summary>
    public partial class BeheerAutos : Window
    {
        public BeheerAutos()
        {
            InitializeComponent();
            
        }

        private void toevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            ToevoegenAuto toevoegenAuto = new ToevoegenAuto();
            toevoegenAuto.Show();
            this.Close();
        }

        private void verwijderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Als er nog reserveringen zijn op deze auto word de verwijdering geblokeerd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
