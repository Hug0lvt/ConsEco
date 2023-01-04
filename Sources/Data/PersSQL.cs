using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Graphics;
using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersSQL : IPersistanceManager
    {
        Hash hash = new Hash();
        private static string connexionBaseDeDonnees = String.Format("Server=2.3.8.130; Username=postgres; Database=conseco; Port=5432; Password=lulu; SSLMode=Prefer");
        private static NpgsqlConnection dbAcces = new NpgsqlConnection(connexionBaseDeDonnees);

        //   /!\ Toutes les méthodes ici permettent d'uniquement manipuler une stratégie de persistance
        //   /!\ et ne doit en aucun cas manipuler la mémoire !

        //actions sur les inscrits
        public bool AjouterInscrit(Inscrit inscrit)
        {
            string mdpHash = hash.CreateHashCode(inscrit.Mdp);
            dbAcces.Open();
            using var cmd = new NpgsqlCommand($"INSERT INTO Inscrit (nom,prenom,mail,mdp) VALUES ((@name), (@surname), (@mail), (@password))", dbAcces)
            {
                Parameters =
                {
                    new NpgsqlParameter("name", inscrit.Nom),
                    new NpgsqlParameter("surname", inscrit.Prenom),
                    new NpgsqlParameter("mail", inscrit.Mail),
                    new NpgsqlParameter("password", mdpHash),
                }
            };
            cmd.ExecuteNonQueryAsync();
            dbAcces.Close();
            return true;
        }
        public bool SupprimerInscrit(Inscrit inscrit)
        {
            dbAcces.Open();
            using var cmd = new NpgsqlCommand($"DELETE FROM INSCRIT WHERE mail=(@mail)", dbAcces)
            {
                Parameters =
                {
                    new NpgsqlParameter("mail", inscrit.Mail)
                }
            };
            cmd.ExecuteNonQueryAsync();
            dbAcces.Close();
            return true;
        }
        public bool ModifierMdpInscrit(string mail, string nouveauMdp)
        {
            dbAcces.Open();
            using var cmd = new NpgsqlCommand($"UPDATE Inscrit SET mdp = (@mdp) WHERE mail = (@mail)", dbAcces)
            {
                Parameters =
                {
                    new NpgsqlParameter("mail", mail),
                    new NpgsqlParameter("mdp", nouveauMdp)
                }
            };
            cmd.ExecuteNonQueryAsync();
            dbAcces.Close();
            return true;

        }
        public Inscrit RecupererInscrit(string mail)
        {
            IList<Inscrit> inscrits = new List<Inscrit>();
            dbAcces.Open();
            NpgsqlDataReader dbReader = new NpgsqlCommand("SELECT * FROM Inscrit WHERE mail = (@mail)", dbAcces).ExecuteReader();
            while (dbReader.Read())
            {

                inscrits.Add(new Inscrit(dbReader.GetInt32(0), dbReader.GetString(1), dbReader.GetString(3), dbReader.GetString(2), dbReader.GetString(4)));

            }
            dbReader.Close();
            dbAcces.Close();

            return inscrits.FirstOrDefault();

        }
        public bool EmailDisponible(string mail)
        {
            throw new NotImplementedException();
        }


        //actions sur les banques
        public bool AjouterBanque(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerBanque(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public IList<Banque> RecupererBanques(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public IList<Banque> RecupererBanquesDisponible()
        {
            throw new NotImplementedException();
        }


        //actions sur les comptes
        public bool AjouterCompte(Compte compte, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerCompte(Compte compte, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererCompte(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }


        //actions sur les Opérations
        public bool AjouterOperation(Compte compte, Operation operation)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerOperation(Compte compte, Operation operation)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererOperation(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions sur les Planifications
        public bool AjouterPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions sur les Echéances
        public bool AjouterEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions utilitaire
        public bool TestConnexion()
        {
            throw new NotImplementedException();
        }
    }
}
