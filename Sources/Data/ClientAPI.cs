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

        //routes operation
        private const string POST_OPERATION_COMPTE_DATA_URL = ROOT_URL + "Operation/FromIdCompte/";
        private const string POST_ADD_OPERATION_COMPTE_DATA_URL = ROOT_URL + "Operation/add/";
        private const string DELETE_OPERATION_COMPTE_DATA_URL = ROOT_URL + "Operation/delete/";

        //routes planification
        private const string POST_PLANIFICATION_COMPTE_DATA_URL = ROOT_URL + "Planification/FromIdCompte/";
        private const string POST_ADD_PLANIFICATION_COMPTE_DATA_URL = ROOT_URL + "Planification/add/";
        private const string DELETE_PLANIFICATION_COMPTE_DATA_URL = ROOT_URL + "Planification/delete/";

        //routes echeance
        private const string POST_ECHEANCE_COMPTE_DATA_URL = ROOT_URL + "Echeance/FromIdCompte/";
        private const string POST_ADD_ECHEANCE_COMPTE_DATA_URL = ROOT_URL + "Echeance/add/";
        private const string DELETE_ECHEANCE_COMPTE_DATA_URL = ROOT_URL + "Echeance/delete/";

        //routes utilitaire
        private const string TEST_API_STATEMENT = ROOT_URL;

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

        public static async Task<List<BanqueInscrit>> GetBanqueAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_BANQUES_INSCRIT_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BanqueInscrit>>(await reponse.Content.ReadAsStringAsync());
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


        //Operations
        public static async Task<List<Operation>> GetOperationAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_OPERATION_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Operation>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddOperationInscritAsync(Compte compte, Operation operation)
        {
            var dataBody = new Dictionary<string, string>
            {
                { "compte", compte.Identifiant },
                { "nom", operation.Nom },
                { "montant", operation.Montant.ToString() },
                { "dateO", operation.DateOperation.ToString() },
                { "methodePayement", operation.ModePayement.ToString() },
                { "isDebit", operation.IsDebit.ToString() },
                { "tag", operation.Tag.ToString() },
                { "fromBanque", operation.FromBanque.ToString() }
            };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_OPERATION_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeleteOperationInscritAsync(string idCompte, string nomOpe)
        {
            var dataBody = new Dictionary<string, string> { { "compte", idCompte }, { "nom", nomOpe } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_OPERATION_COMPTE_DATA_URL)
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


        //Planifications
        public static async Task<List<Planification>> GetPlanificationAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_PLANIFICATION_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Planification>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddPlanificationInscritAsync(Compte compte, Planification planification)
        {
            var dataBody = new Dictionary<string, string>
            {
                { "compte", compte.Identifiant },
                { "nom", planification.Nom },
                { "montant", planification.Montant.ToString() },
                { "dateO", planification.DateOperation.ToString() },
                { "methodePayement", planification.ModePayement.ToString() },
                { "isDebit", planification.IsDebit.ToString() },
                { "tag", planification.Tag.ToString() }
            };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_PLANIFICATION_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeletePlanificationInscritAsync(string idCompte, string nomOpe)
        {
            var dataBody = new Dictionary<string, string> { { "compte", idCompte }, { "nom", nomOpe } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_PLANIFICATION_COMPTE_DATA_URL)
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


        //Echeances
        public static async Task<List<Echeance>> GetEcheanceAsync(string id)
        {
            var dataBody = new Dictionary<string, string> { { "id", id } };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ECHEANCE_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Echeance>>(await reponse.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> PostAddEcheanceInscritAsync(Compte compte, Echeance echeance)
        {
            var dataBody = new Dictionary<string, string>
            {
                { "compte", compte.Identifiant },
                { "nom", echeance.IntituleOperation },
                { "montant", echeance.Montant.ToString() },
                { "dateO", echeance.DateOperation.ToString() },
                { "methodePayement", echeance.ModePayement.ToString() },
                { "isDebit", echeance.IsDebit.ToString() },
                { "tag", echeance.Tag.ToString() }
            };
            HttpResponseMessage reponse = await cli.PostAsJsonAsync(POST_ADD_ECHEANCE_COMPTE_DATA_URL, dataBody);

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException(reponse.StatusCode.ToString());
            }

        }

        public static async Task<bool> DeleteEcheanceInscritAsync(string idCompte, string nomOpe)
        {
            var dataBody = new Dictionary<string, string> { { "compte", idCompte }, { "nom", nomOpe } };

            var reponse =
                cli.SendAsync(
                new HttpRequestMessage(HttpMethod.Delete, DELETE_ECHEANCE_COMPTE_DATA_URL)
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

        //Utilitaires
        public static async Task<bool> GetStateApi()
        {
            HttpResponseMessage reponse = await cli.GetAsync(TEST_API_STATEMENT);
            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
