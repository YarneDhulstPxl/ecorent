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
    public class ReservatieDataService
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["cnnDatabase"].ConnectionString;
        private static IDbConnection db = new SqlConnection(conStr);

        public List<Reservatie> GetReservaties()
        {
            string statement = "Select * from Reservatie order by ReservatieID";
            return (List<Reservatie>)db.Query<Reservatie>(statement);
        }

        public List<Reservatie> GetReservatiesByChauffeurID(int chauffeurID)
        {
            string statement = "SELECT * FROM Reservatie WHERE ChauffeurID='" + chauffeurID + "'";
            List<Reservatie> reserv = (List<Reservatie>)db.Query<Reservatie>(statement);
            if (reserv.Count() == 0)
            {
                return null;
            }
            else
            {
                return reserv;
            }
        }

        public List<Reservatie> GetReservatiesByAutoID(int autoID)
        {
            string statement = "SELECT * FROM Reservatie WHERE AutoID='" + autoID + "'";
            List<Reservatie> reserv = (List<Reservatie>)db.Query<Reservatie>(statement);
            if (reserv.Count() == 0)
            {
                return null;
            }
            else
            {
                return reserv;
            }
        }

        public int GetLastID()
        {
            List<Reservatie> reservaties = GetReservaties();
            int first;
            if (reservaties.Count == 0)
                return 1;
            first = reservaties.First().ReservatieID;
            foreach (Reservatie o in reservaties)
            {
                if (o.ReservatieID == first)
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
        
        public void Update(Reservatie reservatie)
        {
            // SQL statement update 
            string statement = "Update Reservaties set ReservatieID = @ReservatieID, " +
                "BeginDatum = @BeginDatum, EindDatum = @EindDatum, " +
                "AutoID = @AutoID, ChauffeurID = @ChauffeurID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                reservatie.ReservatieID,
                reservatie.BeginDatum,
                reservatie.EindDatum,
                reservatie.AutoID,
                reservatie.ChauffeurID
            });
        }

        public void Insert(Reservatie reservatie)
        {
            // SQL statement insert
            string statement = "Insert into Reservatie (ReservatieID, BeginDatum, EindDatum, AutoID, ChauffeurID) " +
                "values (@ReservatieID, @BeginDatum, @EindDatum, @AutoID," +
                " @ChauffeurID)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                reservatie.ReservatieID,
                reservatie.BeginDatum,
                reservatie.EindDatum,
                reservatie.AutoID,
                reservatie.ChauffeurID
            });
        }

        public void Delete(Reservatie reservatie)
        {
            // SQL statement delete 
            string statement = "Delete Reservatie where ReservatieID = @ReservatieID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new { reservatie.ReservatieID });
        }
    }
}
