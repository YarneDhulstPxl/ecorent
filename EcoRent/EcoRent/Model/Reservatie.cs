using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRent.Model
{
    public class Reservatie : BaseModel
    {
        private int _reservatieID;
        private DateTime _beginDatum;
        private DateTime _eindDatum;
        private int _autoID;
        private int _chauffeurID;

        public int ReservatieID
        {
            get { return _reservatieID; }
            set { _reservatieID = value; NotifyPropertyChanged(); }
        }

        public DateTime BeginDatum
        {
            get { return _beginDatum; }
            set { _beginDatum = value; NotifyPropertyChanged(); }
        }

        public DateTime EindDatum
        {
            get { return _eindDatum; }
            set { _eindDatum = value; NotifyPropertyChanged(); }
        }

        public int AutoID
        {
            get { return _autoID; }
            set { _autoID = value; NotifyPropertyChanged(); }
        }

        public int ChauffeurID
        {
            get { return _chauffeurID; }
            set { _chauffeurID = value; NotifyPropertyChanged(); }
        }
    }
}
