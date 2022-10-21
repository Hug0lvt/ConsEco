using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Npgsql;
using Model;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace LinqToPgSQL
{
    public class PersLinqToPgSQL : IPersistanceManager
    {
        string connexionBDD = String.Format("Server=90.114.135.116; Username=postgres; Database=conseco; Port=5432; Password=lulu; SSLMode=Prefer");
        public string LoadInscrit(string id, string mdp)
        {
            string resultat="";
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            conn.Open();
            NpgsqlParameter p1 = new NpgsqlParameter { ParameterName = "p", Value = id };
            NpgsqlParameter p2 = new NpgsqlParameter { ParameterName = "p2", Value = mdp };
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT id FROM INSCRIT WHERE (nom=(@p) OR mail=(@p)) AND mdp=@p2", conn);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            try
            {
                dr.Read();
                resultat = dr.GetString(0);
                dr.Close();
                return resultat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Utilisateur inconnu");
                dr.Close();
                return null;
            }
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