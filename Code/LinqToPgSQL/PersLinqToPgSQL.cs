using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Model;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Threading;

namespace LinqToPgSQL
{
    public class PersLinqToPgSQL : IPersistanceManager
    {
        private static string Host = "90.114.135.116";
        private static string User = "postgres";
        private static string DBname = "conseco";
        private static string Password = "lul";
        private static string Port = "5432";

        string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

        public PersLinqToPgSQL() { }
        public IEnumerable<Inscrit> LoadInscrit()
        {
            List<Inscrit> ListeInscrits = new List<Inscrit>();

            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection"); try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                
                MessageBox.Show("Problème de connection à la base de données. L'application se fermera après fermeture de la fenêtre");
                Environment.Exit(0);
               
            }
            
            
            NpgsqlDataReader dbReader = new NpgsqlCommand("SELECT * FROM Inscrit", conn).ExecuteReader();

            while (dbReader.Read())
            {

                ListeInscrits.Add(new Inscrit(dbReader.GetString(0), dbReader.GetString(1), dbReader.GetString(2), dbReader.GetString(3), dbReader.GetString(4)));
                
            }
            

            dbReader.Close();

            return ListeInscrits;
        }


        
        public async void SupprimerInscritBdd(Inscrit i)
        {
            /*List<Inscrit> ListeInscrits = new List<Inscrit>(LoadInscrit());*/
           
            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            conn.Open();


            string requete = $"DELETE FROM INSCRIT WHERE id=(@p)";

            using (var command1 = new NpgsqlCommand(requete, conn))
            {
                command1.Parameters.AddWithValue("p2", i.Id);
                await command1.ExecuteNonQueryAsync();
            }

         /*   SupprimerBanqueBdd(i);
            SupprimerCompteBdd(i);
            SupprimerEcheancierBdd(i);
            SupprimerPlanificationBdd(i);
*/

        }
    }
}
