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
    public class ChauffeurDataService
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["cnnDatabase"].ConnectionString;
        private static IDbConnection db = new SqlConnection(conStr);

        public List<Chauffeur> GetChauffeurs()
        {
            string statement = "Select * from Chauffeur order by ChauffeurID";
            return (List<Chauffeur>)db.Query<Chauffeur>(statement);
        }

        public bool CheckSafeDelete(Chauffeur chauffeur)
        {
            string statement = "SELECT * FROM Reservatie WHERE ChauffeurID='" + chauffeur.ChauffeurID + "'";
            List<Reservatie> resv = (List<Reservatie>)db.Query<Reservatie>(statement);
            if (resv.Count == 0)
                return true;
            else
                return false;
        }

        public int GetLastID()
        {
            List<Chauffeur> chauffeurs = GetChauffeurs();
            int first;
            if (chauffeurs.Count == 0)
                return first = 1;
            first = chauffeurs.First().ChauffeurID;
            foreach (Chauffeur o in chauffeurs)
            {
                if (o.ChauffeurID == first)
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


        public Chauffeur Controle2(string loginNaam, string passwoord)
        {
            string statement = "SELECT * FROM Chauffeur WHERE LoginNaam='" + loginNaam + "' and Passwoord='" + passwoord + "'";
            List<Chauffeur> chaf = (List<Chauffeur>)db.Query<Chauffeur>(statement);
            if (chaf.Count == 0)
            {
                Chauffeur chauffeur = new Chauffeur();
                return chauffeur;
            }
            else
            {
                return chaf.First();
            }
        }
        /*
        public Chauffeur Controle(string loginNaam, string passwoord)
        {
            SqlConnection dbCon = new SqlConnection();
            dbCon.ConnectionString = conStr;
            dbCon.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Chauffeur WHERE LoginNaam='" + loginNaam + "' and Passwoord='" + passwoord + "'", dbCon);

            SqlDataReader dr = cmd.ExecuteReader();

            string userText = loginNaam;
            string passText = passwoord;

            while (dr.Read())
            {
                if (String.Equals(dr["LoginNaam"].ToString(), loginNaam) &&
                    String.Equals(dr["Passwoord"].ToString(), passwoord))
                {
                    int id = Convert.ToInt32(dr["ChauffeurID"].ToString());
                    string voorNaam = dr["VoorNaam"].ToString();
                    string naam = dr["Naam"].ToString();
                    string email = dr["Email"].ToString();
                    string rijksregisterNummer = dr["RijksregisterNummer"].ToString();
                    DateTime geboorteDatum = Convert.ToDateTime(dr["GeboorteDatum"].ToString());

                    object autoID = null;

                    if (dr["AutoID"] == null)
                    {
                        
                    }
                    else
                    {
                        autoID = Convert.ToInt32(dr["AutoID"].ToString());
                    }
                    Boolean admin = Convert.ToBoolean(dr["Admin"].ToString());
                    //Chauffeur chauffeur = new Chauffeur(id,voorNaam,naam,email,rijksregisterNummer,geboorteDatum, (int) autoID, loginNaam, passwoord, admin);
                    dr.Close();

                    dbCon.Close();
                    return null;
                }
            }
            
            dr.Close();

            dbCon.Close();
            return null;

        }*/


        public void Update(Chauffeur chauffeur)
        {
            // SQL statement update 
            string statement = "Update Chauffeur set VoorNaam = @VoorNaam, Naam = @Naam, Email = @Email, " +
                "RijksregisterNummer = @RijksregisterNummer, GeboorteDatum = @GeboorteDatum, " +
                "LoginNaam = @LoginNaam, Passwoord = @Passwoord where ChauffeurID = @ChauffeurID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                chauffeur.VoorNaam,
                chauffeur.Naam,
                chauffeur.Email,
                chauffeur.RijksregisterNummer,
                chauffeur.GeboorteDatum,
                chauffeur.LoginNaam,
                chauffeur.Passwoord,
                chauffeur.ChauffeurID
            });
        }

        public void Insert(Chauffeur chauffeur)
        {
            // SQL statement insert
            string statement = "Insert into Chauffeur (ChauffeurID, VoorNaam, Naam, Email, RijksregisterNummer, " +
                "GeboorteDatum, LoginNaam, Passwoord, Admin) values (@ChauffeurID, @VoorNaam, @Naam, @Email," +
                " @RijksregisterNummer, @GeboorteDatum, " +
                "@LoginNaam, @Passwoord, @Admin)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(statement, new
            {
                chauffeur.ChauffeurID,
                chauffeur.VoorNaam,
                chauffeur.Naam,
                chauffeur.Email,
                chauffeur.RijksregisterNummer,
                chauffeur.GeboorteDatum,
                chauffeur.LoginNaam,
                chauffeur.Passwoord,
                chauffeur.Admin              
            });
        }

        public string Delete(Chauffeur chauffeur)
        {
            // SQL statement delete 
            string statement = "Delete Chauffeur where ChauffeurID = @ChauffeurID";
            if (CheckSafeDelete(chauffeur))
            {
                db.Execute(statement, new { chauffeur.ChauffeurID });
                return "Verwijdering geslaagd";
            }
            else
            {
                return "Verwijder eerst bijhorende reservaties";
            }
            

            // Uitvoeren SQL statement en doorgeven parametercollectie
            
        }
    }
}
