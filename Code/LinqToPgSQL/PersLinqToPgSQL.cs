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
            Console.Out.WriteLine("Ouverture de la connection"); 
            try
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

        public IEnumerable<Banque> LoadBanque()
        {
            List<Banque> ListeBanques = new List<Banque>();

            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection"); 
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("Problème de connection à la base de donnée. Aprés fermeture, l'application se fermera automatiquement");
                Environment.Exit(-1);

            }


            NpgsqlDataReader dbReader = new NpgsqlCommand("SELECT * FROM Banque", conn).ExecuteReader();

            while (dbReader.Read())
            {

                ListeBanques.Add(new Banque(dbReader.GetString(0), dbReader.GetString(1), dbReader.GetString(2)));

            }


            dbReader.Close();
           

            return ListeBanques;
        }

        /*Charge le compte d'un inscrit*/
        public IEnumerable<Compte> LoadCompte(Inscrit i)
        {
            List<Compte> ListeCompte = new List<Compte>();

            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }

            string requete = "Select * FROM Compte c, InscrBanque ib, Inscrit i WHERE c.idInscrit = ib.idInscrit AND c.idInscritBanque = ib.id AND i.id = (@p1)";
            NpgsqlDataReader dbReader = new NpgsqlCommand("Select * FROM Compte c, InscrBanque ib, Inscrit i WHERE c.idInscrit = ib.idInscrit AND c.idInscritBanque = ib.id AND i.id = (@p1) ", conn).ExecuteReader();

            using (var command1 = new NpgsqlCommand(requete, conn))
            {
                command1.Parameters.AddWithValue("p", i.Id);
                /*await command1.ExecuteNonQueryAsync();*/
            }


            while (dbReader.Read())
            {
                ListeCompte.Add(new Compte(dbReader.GetString(0), dbReader.GetInt64(1)));
            }
            dbReader.Close();
            return ListeCompte;
        }

        /*Suppression d'un inscrit dans la base de données*/
        public async void SupprimerInscritBdd(Inscrit i)
        {
           
            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);         
            }


            string requete = $"DELETE FROM INSCRIT WHERE id=(@p)";

            using (var command1 = new NpgsqlCommand(requete, conn))
            {
                command1.Parameters.AddWithValue("p", i.Id);
                await command1.ExecuteNonQueryAsync();
            }

            using (var command = new NpgsqlCommand(requete, conn))
            {
                command.Parameters.AddWithValue("p", i.Id);
                await command.ExecuteNonQueryAsync();
            }

            /*   SupprimerBanqueBdd(i);
                 SupprimerCompteBdd(i);
                 SupprimerEcheancierBdd(i);
                 SupprimerPlanificationBdd(i);
            */
        }

        /*Suppression d'une banque d'un inscrit*/
        public async void SupprimerBanqueBdd(Inscrit i, Banque b)
        {
            var conn = new NpgsqlConnection(connString);
            Console.Out.WriteLine("Ouverture de la connection");
            conn.Open();
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("Problème de connection avec la base de données. Aprés fermeture, l'application se fermera automatiquement");
                Environment.Exit(-1);
            }

            await using var cmd = new NpgsqlCommand("DELETE FROM InscrBanque WHERE nombanque=(@b) AND idinscrit=(@i)", conn)
            {
                Parameters =
                {
                    new("b", b.Nom),
                    new("i", i.Id)
                }
            };
            await cmd.ExecuteNonQueryAsync();

            // attente des autres supression
        }
    }
}