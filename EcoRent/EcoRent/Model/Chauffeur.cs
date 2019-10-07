using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EcoRent.Model
{
    public class Chauffeur : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        private int _chauffeurID;
        private string _voornaam;
        private string _naam;
        private string _email;
        private string _rijksregisternummer;
        private DateTime _geboortedatum;
        private string _loginnaam;
        private string _passwoord;
        private Boolean _admin;

        

        public int ChauffeurID
        {
            get { return _chauffeurID; }
            set { _chauffeurID = value; OnPropertyChanged(); }
        }

        public string VoorNaam
        {
            get { return _voornaam; }
            set { _voornaam = value; OnPropertyChanged(); }
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        public string RijksregisterNummer
        {
            get { return _rijksregisternummer; }
            set { _rijksregisternummer = value; OnPropertyChanged(); }
        }

        public DateTime GeboorteDatum
        {
            get { return _geboortedatum; }
            set { _geboortedatum = value; OnPropertyChanged(); }
        }

        public string LoginNaam
        {
            get { return _loginnaam; }
            set { _loginnaam = value; OnPropertyChanged(); }
        }

        public string Passwoord
        {
            get { return _passwoord; }
            set { _passwoord = value; OnPropertyChanged(); }
        }

        public Boolean Admin
        {
            get { return _admin; }
            set { _admin = value; OnPropertyChanged(); }
        }



        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
