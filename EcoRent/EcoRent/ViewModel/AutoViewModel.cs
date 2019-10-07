using System.Collections.ObjectModel;
using EcoRent.Model;
using System.Windows.Input;

namespace EcoRent.ViewModel 
{
    public class AutoViewModel : BaseViewModel
    {
        public AutoViewModel()
        {
            LeesAutos();
            KoppelenCommands();
        }

        private ObservableCollection<Auto> autos;
        public ObservableCollection<Auto> Autos
        {
            get
            {
                return autos;
            }

            set
            {
                autos = value;
                NotifyPropertyChanged();
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        private Auto currentAuto;
        public Auto CurrentAuto
        {
            get
            {
                return currentAuto;
            }

            set
            {
                currentAuto = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenAuto);
            VerwijderenCommand = new BaseCommand(VerwijderenAuto);
            ToevoegenCommand = new BaseCommand(ToevoegenAuto);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public AutoDataService autoDS = new AutoDataService();

        private void LeesAutos()
        {
            //instantiëren dataservice
            Autos = new ObservableCollection<Auto>(autoDS.GetAutos());
        }

        public void WijzigenAuto()
        {
            if (CurrentAuto != null)
            {
                autoDS.Update(CurrentAuto);

                //Refresh
                LeesAutos();
            }
        }

        public int GetLastID()
        {
            return (autoDS.GetLastID());
        }

        public void ToevoegenAuto()
        {
            autoDS.Insert(CurrentAuto);

            //Refresh
            LeesAutos();
        }

        public void VerwijderenAuto()
        {
            if (CurrentAuto != null)
            {
                status = autoDS.Delete(CurrentAuto);
                
                //Refresh
                LeesAutos();
            }
        }

        public bool Valideer()
        {
            if (currentAuto.AutoID == 0)
                return false;
            else if (currentAuto.Naam == null)
                return false;
            else if (currentAuto.Bouwjaar == 0)
                return false;
            else if (currentAuto.Merk == null)
                return false;
            else if (currentAuto.Nummerplaat == null)
                return false;
            else if (currentAuto.Vermogen == 0)
                return false;
            else
                return true;
        }

    }

}

