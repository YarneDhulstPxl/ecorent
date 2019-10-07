using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRent.Model
{
    public class Auto : BaseModel
    {
        private int _autoID;
        private string _naam;
        private int _bouwjaar;
        private string _merk;
        private string _nummerplaat;
        private int _vermogen;
        private string _beschrijving;

        /*public Auto(int id, string naam, int bouwjaar, string merk, string nummerplaat, int vermogen, string rijbewijscategorie, 
            string beschrijving, string beschikbaarheid, int positieID, int chauffeurID, int reservatieID)
        {
            AutoID = id;
            Naam = naam;
            Bouwjaar = bouwjaar;
            Merk = merk;
            Nummerplaat = nummerplaat;
            Vermogen = vermogen;
            Rijbewijscategorie = rijbewijscategorie;
            Beschrijving = beschrijving;
            Beschikbaarheid = beschikbaarheid;
            PositieID = positieID;
            ChauffeurID = chauffeurID;
            ReservatieID = reservatieID;
        }*/

        public int AutoID 
        {
            get { return _autoID; }
            set { _autoID = value; NotifyPropertyChanged(); }
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; NotifyPropertyChanged(); }
        }

        public int Bouwjaar
        {
            get { return _bouwjaar; }
            set { _bouwjaar = value; NotifyPropertyChanged(); }
        }

        public string Merk
        {
            get { return _merk; }
            set { _merk = value; NotifyPropertyChanged(); }
        }

        public string Nummerplaat
        {
            get { return _nummerplaat; }
            set { _nummerplaat = value; NotifyPropertyChanged(); }
        }

        public int Vermogen
        {
            get { return _vermogen; }
            set { _vermogen = value; NotifyPropertyChanged(); }
        }

        public string Beschrijving
        {
            get { return _beschrijving; }
            set { _beschrijving = value; NotifyPropertyChanged(); }
        }

    }
}
