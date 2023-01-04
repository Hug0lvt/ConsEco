using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public static class ClientAPI
    {
        private const string ROOT_URL = "http://82.64.164.20:8888/";

        //routes inscrit
        private const string GET_INSCRITS_DATA_URL = ROOT_URL+"Inscrit/";
        private const string POST_EMAIL_INSCRIT_DATA_URL = ROOT_URL+"Inscrit/FromMail/";
        private const string PUT_PASSWORD_INSCRIT_DATA_URL = ROOT_URL+"Inscrit/UpdatePassword/";
        private const string POST_ADD_INSCRIT_DATA_URL = ROOT_URL + "Inscrit/add/";
        private const string DELETE_INSCRIT_DATA_URL = ROOT_URL + "Inscrit/delete/";

        //routes banque
        private const string GET_BANQUES_DATA_URL = ROOT_URL + "Banque/";
        private const string POST_BANQUES_INSCRIT_DATA_URL = ROOT_URL + "Banque/FromId/";
        private const string POST_ADD_BANQUE_INSCRIT_DATA_URL = ROOT_URL + "Banque/add/";
        private const string DELETE_BANQUE_INSCRIT_DATA_URL = ROOT_URL + "Banque/delete/";

        //routes compte
        private const string POST_COMPTE_INSCRIT_DATA_URL = ROOT_URL + "Compte/FromIdInscrit/";
        private const string POST_ADD_COMPTE_INSCRIT_DATA_URL = ROOT_URL + "Compte/add/";
        private const string DELETE_COMPTE_INSCRIT_DATA_URL = ROOT_URL + "Compte/delete/";


        //add all routes

        private static HttpClient cli = new HttpClient();

        //Inscrit
        public static async Task<List<Inscrit>> GetInscritsAsync()
        { 
            HttpResponseMessage reponse = await cli.GetAsync(GET_INSCRITS_DATA_URL);
            if(reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Inscrit>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }
        }

        public static async Task<List<Inscrit>> GetInscritAsync(string email)
        {
            var dataBody = new Dictionary<string, string> { { "email", email } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_EMAIL_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Inscrit>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PutPasswordInscritAsync(string email, string password)
        {
            var dataBody = new Dictionary<string, string> { { "email", email }, { "password", password } };
            HttpResponseMessage reponse = await cli.PutAsJsonAsync(PUT_PASSWORD_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddInscritAsync(string nom, string prenom, string email, string password)
        {
            var dataBody = new Dictionary<string, string> { { "nom", nom }, { "prenom", prenom }, { "email", email }, { "password", password } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeleteInscritAsync(string email)
        {
            var dataBody = new Dictionary<string, string> { { "email", email } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_INSCRIT_DATA_URL)
                {
                    Content = new FormUrlEncodedContent(dataBody)
                })
                .Result;

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }


        //Banque
        public static async Task<List<Banque>> GetBanquesAsync()
        {
            HttpResponseMessage reponse = await cli.GetAsync(GET_BANQUES_DATA_URL);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Banque>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }
        }

        public static async Task<List<Banque>> GetBanqueAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_BANQUES_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Banque>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddBanqueInscritAsync(string nomBanque, string idInscrit)
        {
            var dataBody = new Dictionary<string, string> { { "nom", nomBanque }, { "idInscrit", idInscrit } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_BANQUE_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeleteBanqueInscritAsync(string nomBanque, string idInscrit)
        {
            var dataBody = new Dictionary<string, string> { { "nom", nomBanque }, { "idInscrit", idInscrit } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_BANQUE_INSCRIT_DATA_URL)
                {
                    Content = new FormUrlEncodedContent(dataBody)
                })
                .Result;

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }


        //Comptes
        public static async Task<List<Compte>> GetCompteAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_COMPTE_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Compte>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddCompteInscritAsync(string nomCompte, string idInscrit)
        {
            var dataBody = new Dictionary<string, string> { { "nom", nomCompte }, { "idInscrit", idInscrit } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_COMPTE_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeleteCompteInscritAsync(string nomCompte, string idInscrit)
        {
            var dataBody = new Dictionary<string, string> { { "nom", nomCompte }, { "idInscrit", idInscrit } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_COMPTE_INSCRIT_DATA_URL)
                {
                    Content = new FormUrlEncodedContent(dataBody)
                })
                .Result;

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }


    }
}
