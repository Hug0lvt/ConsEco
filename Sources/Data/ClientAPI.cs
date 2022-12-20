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

        //add all routes


        private static HttpClient cli = new HttpClient();

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

    }
}
