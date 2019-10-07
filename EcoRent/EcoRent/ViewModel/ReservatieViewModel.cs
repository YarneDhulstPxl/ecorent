using System.Collections.ObjectModel;
using EcoRent.Model;
using System.Windows.Input;
using System.Collections.Generic;

namespace EcoRent.ViewModel
{
    public class ReservatieViewModel : BaseViewModel
    {
        public ReservatieViewModel()
        {
            KoppelenCommands();
            LeesReservaties();
        }

        private ObservableCollection<Reservatie> reservaties;
        public ObservableCollection<Reservatie> Reservaties
        {
            get
            {
                return reservaties;
            }

            set
            {
                reservaties = value;
                NotifyPropertyChanged();
            }
        }

        private Reservatie currentReservatie;
        public Reservatie CurrentReservatie
        {
            get
            {
                return currentReservatie;
            }

            set
            {
                currentReservatie = value;
                NotifyPropertyChanged();
            }
        }

        private List<Reservatie> selectReservaties;
        public List<Reservatie> SelectReservaties
        {
            get
            {
                return selectReservaties;
            }

            set
            {
                selectReservaties = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenReservatie);
            VerwijderenCommand = new BaseCommand(VerwijderenReservatie);
            ToevoegenCommand = new BaseCommand(ToevoegenReservatie);
        }

        public void LeesReservaties()
        {
            //instantiëren dataservice
            Reservaties = new ObservableCollection<Reservatie>(reservatieDS.GetReservaties());
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ReservatieDataService reservatieDS = new ReservatieDataService();

        public int GetLastID()
        {
            return (reservatieDS.GetLastID());
        }

        public List<Reservatie> GetReservatiesByChauffeurID(int chauffeurID)
        {
            return (reservatieDS.GetReservatiesByChauffeurID(chauffeurID));
        }

        public List<Reservatie> GetReservatiesByAutoID(int autoID)
        {
            return (reservatieDS.GetReservatiesByAutoID(autoID));
        }

        public void WijzigenReservatie()
        {
            if (currentReservatie != null)
            {
                reservatieDS.Update(currentReservatie);
                LeesReservaties();
            }
        }

        public void ToevoegenReservatie()
        {
            reservatieDS.Insert(currentReservatie);
        }

        public void VerwijderenReservatie()
        {
            if (currentReservatie != null)
            {
                reservatieDS.Delete(currentReservatie);
                LeesReservaties();
            }
        }
    }
}

