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

        string connexionBDD = String.Format("Server={0};Username{1};Database{2};Port{3};Password{4};SSLMode=Prefer",Host,User,DBname,Port,Password);
        public Inscrit LoadInscrit()
        {
            int t = 0;
            Inscrit i=null;
            var conn = new NpgsqlConnection(connexionBDD);
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
                t++;
                i=new Inscrit(dbReader.GetString(0), dbReader.GetString(1), dbReader.GetString(2), dbReader.GetString(3), dbReader.GetString(4));  
            }
            dbReader.Close();
            return i;
        }


        /*Revoir la BDD, probleme de clé étrangère de devise*/
        public async void SupprimerInscritBdd(Inscrit i)
        {
            /*List<Inscrit> ListeInscrits = new List<Inscrit>(LoadInscrit());*/
           
            var conn = new NpgsqlConnection(connexionBDD);
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
    }
}
