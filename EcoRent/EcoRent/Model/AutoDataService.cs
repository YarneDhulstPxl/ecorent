using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EcoRent.Model
{
    public class AutoDataService
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["cnnDatabase"].ConnectionString;
        private static IDbConnection db = new SqlConnection(conStr);

        public List<Auto> GetAutos()
        {
            string statement = "Select * from Auto order by AutoID";
            return (List<Auto>)db.Query<Auto>(statement);
        }

        public int GetLastID()
        {
            List<Auto> autos = GetAutos();
            int first;
            if (autos.Count == 0)
                return first = 1;
            first = autos.First().AutoID;
            foreach(Auto o in autos){
                if (o.AutoID == first)
                {
                    first++;
                }
                else
                {
                    break;
                }
            }
            return first;
        }

        public void Update(Auto auto)
        {
            // SQL statement update 
            string statement = "Update Auto set Naam = @Naam, Bouwjaar = @Bouwjaar, Merk = @Merk, Nummerplaat = @Nummerplaat, Vermogen = @Vermogen, " +
                "Beschrijving = @Beschrijving where AutoID = @AutoID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                auto.Naam,
                auto.Bouwjaar,
                auto.Merk,
                auto.Nummerplaat,
                auto.Vermogen,
                auto.Beschrijving,
                auto.AutoID
            });
        }

        public void Insert(Auto auto)
        {
            // SQL statement insert
            string statement = "Insert into Auto (AutoID, Naam, Bouwjaar, Merk, Nummerplaat, Vermogen, " +
                "Beschrijving) values (@AutoID, @Naam, @Bouwjaar, @Merk, @Nummerplaat, @Vermogen, " +
                "@Beschrijving)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                auto.AutoID,
                auto.Naam,
                auto.Bouwjaar,
                auto.Merk,
                auto.Nummerplaat,
                auto.Vermogen,
                auto.Beschrijving,
            });
        }

        public bool CheckSafeDelete(Auto auto)
        {
            string statement = "SELECT * FROM Reservatie WHERE AutoID='" + auto.AutoID + "'";
            List<Reservatie> resv = (List<Reservatie>)db.Query<Reservatie>(statement);
            if (resv.Count == 0)
                return true;
            else
                return false;
        }

        public string Delete(Auto auto)
        {
            // SQL statement delete 
            string statement = "Delete Auto where AutoID = @AutoID";
            if (CheckSafeDelete(auto))
            {
                db.Execute(statement, new { auto.AutoID });
                return "Verwijdering geslaagd";
            } else
            {
                return "Verwijder eerst bijhorende reservaties";
            }

        }
        /*public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service            
            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }*/
    }
}
