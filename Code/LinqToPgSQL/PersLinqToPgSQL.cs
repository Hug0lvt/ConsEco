using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Model;
using System.IO;
using System.Diagnostics;

namespace LinqToPgSQL
{
    public class PersLinqToPgSQL : IPersistanceManager
    {
        private static string Host = "90.114.135.116";
        private static string User = "postgres";
        private static string DBname = "conseco";
        private static string Password = "lulu";
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


        /*Revoir la BDD, probleme de clé étrangère de devise*/
        public async void SupprimerInscritBdd(Inscrit i)
        {
            /*List<Inscrit> ListeInscrits = new List<Inscrit>(LoadInscrit());*/
           
            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            conn.Open();


            string requete = $"DELETE FROM INSCRIT WHERE id=(@p)";
            string requeteFKey = $"DELETE FROM DEVISEINSCRIT WHERE idInscrit=(@p2)";

            using (var command1 = new NpgsqlCommand(requeteFKey, conn))
            {
                command1.Parameters.AddWithValue("p2", i.Id);
                await command1.ExecuteNonQueryAsync();
            }

            using (var command = new NpgsqlCommand(requete, conn))
            {
                command.Parameters.AddWithValue("p", i.Id);
                await command.ExecuteNonQueryAsync();
            }

            

        }

        public async void SupprimerBanqueBdd(Banque b)
        {
            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            conn.Open();

            string requete = $"DELETE FROM Banque WHERE nom=(@n)";
            string requeteFKey = $"DELETE From Compte WHERE nomBanque=(@n2)";

            using (var commandFKey = new NpgsqlCommand(requeteFKey, conn))
            {
                commandFKey.Parameters.AddWithValue("n2", b.Nom);
                await commandFKey.ExecuteNonQueryAsync();
            }

            using (var command = new NpgsqlCommand(requete, conn))
            {
                command.Parameters.AddWithValue("n", b.Nom);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
