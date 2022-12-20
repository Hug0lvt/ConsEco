using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Npgsql;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Threading;
using Model;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Reflection.PortableExecutable;

namespace LinqToPgSQL
{
    public class PersLinqToPgSQL : IPersistanceManager
    {
        private Hash hash = new Hash();
        private static string connexionBDD = String.Format("Server=2.3.8.130; Username=postgres; Database=conseco; Port=5432; Password=lulu; SSLMode=Prefer");

        private static NpgsqlConnection dbAccess = new NpgsqlConnection(connexionBDD);

        public bool TestConnexionAsDatabase()
        {
            bool isOk = true;
            try
            {
                dbAccess.Open();
            }
            catch(NpgsqlException ex)
            {
                isOk = false;
                Debug.WriteLine("Problème de connection à la base de données. - " + ex.Message);
            }
            finally
            {
                dbAccess.Close();
            }
            return isOk;
        }

        public string GetId(string mail)
        {
            int resultat;
            var conn = new NpgsqlConnection(connexionBDD);
            conn.Open();
            NpgsqlParameter p1 = new NpgsqlParameter { ParameterName = "p", Value = mail };
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT id FROM INSCRIT WHERE mail=(@p)", conn);
            cmd.Parameters.Add(p1);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            resultat = dr.GetInt32(0);
            dr.Close();
            conn.Close();
            return resultat.ToString();

        }

        public string LoadInscrit(string id, string mdp)
        {
            int resultat;
            var conn = new NpgsqlConnection(connexionBDD);
            conn.Open();
            NpgsqlParameter p1 = new NpgsqlParameter { ParameterName = "p", Value = id };
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT id FROM INSCRIT WHERE mail=(@p)", conn);
            cmd.Parameters.Add(p1);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            resultat = dr.GetInt32(0);
            dr.Close();
            conn.Close();
            return resultat.ToString();
            
        }

        public bool ExistEmail(string mail)
        {

            var conn = new NpgsqlConnection(connexionBDD);
            conn.Open();
            NpgsqlDataReader dbReader = new NpgsqlCommand("SELECT mail FROM Inscrit", conn).ExecuteReader();

            while (dbReader.Read())
            {
                if (dbReader.GetString(0) == mail)
                {
                    dbReader.Close();
                    return true;
                } 
            }

            dbReader.Close();
            conn.Close();
            return false;
        }

        public async void ChangePasswordBdd(string mail, string newMdp)
        {
            Hash hash = new Hash();
            string hashedMdp = hash.CreateHashCode(newMdp);
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }
            await using var cmd = new NpgsqlCommand($"UPDATE Inscrit SET mdp = (@newmdp) WHERE mail = (@mail);", conn)
            {
                Parameters =
                {
                    new NpgsqlParameter("newmdp", hashedMdp),
                    new NpgsqlParameter("mail", mail),
                }
            };
            await cmd.ExecuteNonQueryAsync();
        }

        public string LastInscrit()
        {
            string resultat = "";
            var conn = new NpgsqlConnection(connexionBDD);
            conn.Open();
            NpgsqlDataReader dr = new NpgsqlCommand($"SELECT max(id) FROM INSCRIT", conn).ExecuteReader();
            try
            {
                dr.Read();
                resultat = dr.GetString(0);
                dr.Close();
                return resultat;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + "Problème bdd");
                dr.Close();
                return "null";//a changer doit retester
            }

        }



        public async void CreateInscrit(Inscrit inscrit)
        {
            string mdpHash = hash.CreateHashCode(inscrit.Mdp);
            Console.WriteLine("AAAAAA"+mdpHash.Length);
            var conn = new NpgsqlConnection(connexionBDD);
            conn.Open();
            await using var cmd = new NpgsqlCommand($"INSERT INTO Inscrit (nom,prenom,mail,mdp) VALUES ((@name), (@surname), (@mail), (@password))", conn)
            {
                Parameters =
                {
                    new NpgsqlParameter("name", inscrit.Nom),
                    new NpgsqlParameter("surname", inscrit.Prenom),
                    new NpgsqlParameter("mail", inscrit.Mail),
                    new NpgsqlParameter("password", mdpHash),
                }
            };
            await cmd.ExecuteNonQueryAsync();
        }

        public int CalculTotalSoldeComtpe(Inscrit user)
        {
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT sum(c.solde) FROM Compte c, Inscrit i, InscrBanque ib WHERE i.mail = (@mailUser) AND i.id = ib.idinscrit AND c.idinscritbanque = ib.id", conn)
            {
                Parameters =
                {
                    new NpgsqlParameter("mailuser", user.Mail),
                }
            };
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                return dataReader.GetInt32(0);
            }
            return -1;
        }

        public string RecupMdpBdd(string mail)
        {
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT mdp FROM Inscrit WHERE mail = (@mail)", conn)
            {
                Parameters =
                {
                    new NpgsqlParameter("mail", mail),
                }
            };
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
               return dataReader.GetString(0);
            }
            return null;
        }

        public IEnumerable<Banque> LoadBanque()
        {
            List<Banque> ListeBanques = new List<Banque>();

            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection"); 
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de donnée. Aprés fermeture, l'application se fermera automatiquement");
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

            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }

            string requete = "Select * FROM Compte c, InscrBanque ib, Inscrit i WHERE c.idInscrit = ib.idInscrit AND c.idInscritBanque = ib.id AND i.id = (@p1)";
            NpgsqlDataReader dbReader = new NpgsqlCommand("Select * FROM Compte c, InscrBanque ib, Inscrit i WHERE c.idInscrit = ib.idInscrit AND c.idInscritBanque = ib.id AND i.id = (@p1) ", conn).ExecuteReader();

            using (var command1 = new NpgsqlCommand(requete, conn))
            {
                command1.Parameters.AddWithValue("p", i.Id);
            }


            while (dbReader.Read())
            {
                ListeCompte.Add(new Compte("NULL",dbReader.GetString(0), dbReader.GetInt64(1)));//a patch NULL
            }
            dbReader.Close();
            return ListeCompte;
        }

        public List<Banque> LoadBanqueId(int id)
        {
            ;
            List<Banque> ListeBanque = new List<Banque>();
            Debug.WriteLine(id);
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);
            }
            NpgsqlCommand cmd = new NpgsqlCommand("select b.nom,b.urlsite,b.urllogo from banque b, inscrbanque ib, Inscrit i where ib.idinscrit =(@p) AND ib.nombanque = b.nom AND ib.idinscrit = i.id;", conn);
            cmd.Parameters.AddWithValue("p", id);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Debug.WriteLine(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2));
                ListeBanque.Add(new Banque(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2)));
            }
            dataReader.Close();
            return ListeBanque;
        }

        /*Suppression d'un inscrit dans la base de données*/
        public async void SupprimerInscritBdd(Inscrit i)
        {
            /*List<Inscrit> ListeInscrits = new List<Inscrit>(LoadInscrit());*/

            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection à la base de données. Aprés fermeture, l'application se fermera automatiquement.");
                Environment.Exit(-1);         
            }


            string requete = $"DELETE FROM INSCRIT WHERE id=(@p)";
            string requeteFKey = $"DELETE FROM DEVISEINSCRIT WHERE idInscrit=(@p2)";
            using (var command1 = new NpgsqlCommand(requeteFKey, conn))
            {
                command1.Parameters.AddWithValue("p", i.Id);
                await command1.ExecuteNonQueryAsync();
            }


               SupprimerToutesBanquesBdd(i);
                /* SupprimerCompteBdd(i);
                 SupprimerEcheancierBdd(i);
                 SupprimerPlanificationBdd(i);
            */
        }

      /*  Suppression de toutes les banques d'un inscrit*/
        public async void SupprimerToutesBanquesBdd(Inscrit i)
        {
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch 
            {
                conn.Close();
                Debug.WriteLine("Problème de connection ave la base de données. Aprés fermeture de la fenêtre, l'application se fermera automatiquement");
                Environment.Exit(-1);
            }
            string requete = $"DELETE * FROM BANQUE b, INSCRBANQUE ib WHERE b.nom=ib.nomBanque AND ib.idInscrit=(@id)";
            using (var command1 = new NpgsqlCommand(requete, conn))
            {
                command1.Parameters.AddWithValue("p", i.Id);
                await command1.ExecuteNonQueryAsync();
            }
        }

        /*Suppression d'une banque d'un inscrit*/
        public async void SupprimerBanqueBdd(Inscrit i, Banque b)
        {
            var conn = new NpgsqlConnection(connexionBDD);
            Console.Out.WriteLine("Ouverture de la connection");
            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                Debug.WriteLine("Problème de connection avec la base de données. Aprés fermeture de la fenêtre, l'application se fermera automatiquement");
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

        public List<Banque> ImportBanques()
        {
            List<Banque> bquesDispo = new List<Banque>();
            dbAccess.Open();

            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM Banque", dbAccess);
            NpgsqlDataReader dbReader = cmd.ExecuteReader();
            while (dbReader.Read())
            {
                bquesDispo.Add(new Banque(dbReader.GetString(0), dbReader.GetString(1), dbReader.GetString(2)));
            }
            dbAccess.Close();
            return bquesDispo;
        }

        public Inscrit GetInscrit(string mail)
        {
            throw new NotImplementedException();
        }

        public IList<Compte> GetCompteFromOFX(string ofx)
        {
            throw new NotImplementedException();
        }
    }
}