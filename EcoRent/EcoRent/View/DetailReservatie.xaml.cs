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
using EcoRent.Model;

namespace EcoRent.View
{
    /// <summary>
    /// Interaction logic for DetailReservatie.xaml
    /// </summary>
    public partial class DetailReservatie : Window
    {
        private ReservatieViewModel reservatieVM = new ReservatieViewModel();
        private Auto auto;
        private Chauffeur chauffeur;

        public DetailReservatie(Auto auto, Chauffeur chauffeur)
        {
            this.auto = auto;
            this.chauffeur = chauffeur;
            InitializeComponent();
            Reservatie reservatie = new Reservatie();
            reservatieVM.CurrentReservatie = reservatie;
            reservatieVM.CurrentReservatie.AutoID = auto.AutoID;
            reservatieVM.CurrentReservatie.ChauffeurID = chauffeur.ChauffeurID;
            reservatieVM.CurrentReservatie.ReservatieID = reservatieVM.GetLastID();
            chauffeurLabel.Content = chauffeur.VoorNaam + " " + chauffeur.Naam;
            autoLabel.Content = auto.Merk + " " + auto.Naam;
            reservatieCalender.BlackoutDates.AddDatesInPast();

            kalenderMarkeren();

             

            /*<Calendar Name="cldSample" SelectionMode="MultipleRange">
        <Calendar.BlackoutDates>
        <CalendarDateRange Start="10.13.2013" End="10.19.2013" />
        <CalendarDateRange Start="10.27.2013" End="10.31.2013" />
        </Calendar.BlackoutDates>
    </Calendar>*/
        }

        private void kalenderMarkeren()
        {
            reservatieVM.LeesReservaties();
            
            List<Reservatie> reservaties = reservatieVM.GetReservatiesByAutoID(auto.AutoID);
            if (reservaties != null)
            {
                foreach (Reservatie r in reservaties)
                {
                    CalendarDateRange calendarDateRange = new CalendarDateRange();
                    calendarDateRange.Start = r.BeginDatum;
                    calendarDateRange.End = r.EindDatum;
                    reservatieCalender.BlackoutDates.Add(calendarDateRange);
                }
            }
        }

        private void reservatieCalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            reservatieVM.CurrentReservatie.BeginDatum = reservatieCalender.SelectedDates.Min();
            fromDatePicker.Text = reservatieCalender.SelectedDates.Min().ToShortDateString();
            reservatieVM.CurrentReservatie.EindDatum = reservatieCalender.SelectedDates.Max();
            toDatePicker.Text = reservatieCalender.SelectedDates.Max().ToShortDateString();
           // reservatieCalender.SelectedDates.
        }



        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            reservatieVM.ToevoegenReservatie();
            DetailReservatie reservatie = new DetailReservatie(auto, chauffeur);
            reservatie.Show();
            this.Close();

        }

        private void reservatieCalender_GotMouseCapture(object sender, MouseEventArgs e)
        {
            UIElement originalElement = e.OriginalSource as UIElement;
            if (originalElement != null)
            {
                originalElement.ReleaseMouseCapture();
            }
        }
    }
}
