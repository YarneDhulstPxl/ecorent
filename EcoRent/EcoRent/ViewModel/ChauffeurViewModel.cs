using System.Collections.ObjectModel;
using EcoRent.Model;
using System.Windows.Input;
using System.Collections.Generic;

namespace EcoRent.ViewModel
{
    public class ChauffeurViewModel : BaseViewModel
    {
        public ChauffeurViewModel()
        {
            KoppelenCommands();
            LeesChauffeurs();
        }

        private ObservableCollection<Chauffeur> chauffeurs;
        public ObservableCollection<Chauffeur> Chauffeurs
        {
            get
            {
                return chauffeurs;
            }

            set
            {
                chauffeurs = value;
                NotifyPropertyChanged();
            }
        }

        private Chauffeur currentChauffeur;
        public Chauffeur CurrentChauffeur
        {
            get
            {
                return currentChauffeur;
            }

            set
            {
                currentChauffeur = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenChauffeur);
            VerwijderenCommand = new BaseCommand(VerwijderenChauffeur);
            ToevoegenCommand = new BaseCommand(ToevoegenChauffeur);
        }

        private void LeesChauffeurs()
        {
            //instantiëren dataservice
            Chauffeurs = new ObservableCollection<Chauffeur>(chauffeurDS.GetChauffeurs());
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ChauffeurDataService chauffeurDS = new ChauffeurDataService();

        public Chauffeur ControleChauffeur(string loginNaam, string passwoord)
        {
            return chauffeurDS.Controle2(loginNaam, passwoord);
        }

        public int GetLastID()
        {
            return (chauffeurDS.GetLastID());
        }

        public void WijzigenChauffeur()
        {
            if (currentChauffeur != null)
            {
                chauffeurDS.Update(currentChauffeur);
                LeesChauffeurs();
            }
        }

        public void ToevoegenChauffeur()
        {
            chauffeurDS.Insert(currentChauffeur);
        }

        public void VerwijderenChauffeur()
        {
            if (currentChauffeur != null)
            {
                chauffeurDS.Delete(currentChauffeur);
                LeesChauffeurs();
            }
        }
        
        public bool Valideer()
        {
            if (currentChauffeur.ChauffeurID == 0)
                return false;
            else if (currentChauffeur.VoorNaam == null)
                return false;
            else if (currentChauffeur.Naam == null)
                return false;
            else if (currentChauffeur.RijksregisterNummer == null)
                return false;
            else if (currentChauffeur.LoginNaam == null)
                return false;
            else if (currentChauffeur.Passwoord == null)
                return false;
            else
                return true;
        }
    }
}
