using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Model;
using System.IO;

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
            conn.Open();

            var AllInscrit = new NpgsqlCommand("SELECT * FROM Inscrit", conn);

            var reader = AllInscrit.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(
                    string.Format(
                        "({0}, {1}, {2}, {3}, {4}",
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                        /*reader.GetInt32(2).ToString()*/
                        )
                    );
                foreach (var EltInscrit in reader)
                {
                    ListeInscrits.Add(new(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(2), reader.GetString(4)));
                }
                   

            }
            reader.Close();

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
            string requeteFKey = $"DELETE FROM DEVISE WHERE id=(@p2)";

            using (var command1 = new NpgsqlCommand(requeteFKey, conn))
            {
                command1.Parameters.AddWithValue("p2", i.Dev);
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
