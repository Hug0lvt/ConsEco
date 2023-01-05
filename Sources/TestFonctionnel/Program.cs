using Data;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Xml.Linq;

//test OFX
/*
Console.WriteLine("Test Deserializer OFX - simplifié");

IList<Compte> comptes= new List<Compte>();


comptes = LoadOperation.LoadOperationsFromOFX("C:\\Dev\\ConsEco\\Sources\\TestFonctionnel\\CAcomplet.ofx");


foreach (Compte compte in comptes)
{
    Console.WriteLine(compte);
    foreach(Operation operation in compte.LesOpe)
    {
        Console.WriteLine("\t\t"+operation);
    }
}
*/

//test APIClient


Console.WriteLine("Test ClientAPI");

Console.WriteLine("\n\nEtat API : " + ClientAPI.GetStateApi().GetAwaiter().GetResult());

Console.WriteLine("\n\n\n----Inscrits----\n");

IList<Inscrit> res = ClientAPI.GetInscritsAsync().GetAwaiter().GetResult();
foreach(Inscrit i in res)
{
    Console.WriteLine(i);
}

Console.WriteLine("\n--------\n");

IList<Inscrit> inscrit = ClientAPI.GetInscritAsync("renaudtoutnu@gmail.com").GetAwaiter().GetResult();
foreach (Inscrit i in inscrit)
{
    Console.WriteLine(i);
}

Console.WriteLine("\n----Modifs----\n");

bool r = ClientAPI.PutPasswordInscritAsync("lucasevard@gmail.com", "CeciEstUnNouveauMdp123456789!").GetAwaiter().GetResult();
Console.WriteLine("Changement de mdp : "+r+"\n");

bool rr = ClientAPI.PostAddInscritAsync("LIVET", "Hugo", "livet.hugo2003@gmail.com", "EnAvantOuiOui!0").GetAwaiter().GetResult();
Console.WriteLine("Ajout user : " + rr + "\n");

Console.WriteLine("\n----Resultats----\n");

IList<Inscrit> modif = ClientAPI.GetInscritsAsync().GetAwaiter().GetResult();
foreach (Inscrit i in modif)
{
    Console.WriteLine(i);
}

Console.WriteLine("\n----Modifs----\n");

bool rrr = ClientAPI.DeleteInscritAsync("livet.hugo2003@gmail.com").GetAwaiter().GetResult();
Console.WriteLine("Del user : " + rrr + "\n");


modif = ClientAPI.GetInscritsAsync().GetAwaiter().GetResult();
foreach (Inscrit i in modif)
{
    Console.WriteLine(i);
}

Console.WriteLine("\n\n\n----Banques----\n");

IList<Banque> banques = ClientAPI.GetBanquesAsync().GetAwaiter().GetResult();
foreach (Banque b in banques)
{
    Console.WriteLine(b);
}

Console.WriteLine("\n--------\n");

IList<Banque> banquesId1 = ClientAPI.GetBanqueAsync("1").GetAwaiter().GetResult();
foreach (Banque b in banquesId1)
{
    Console.WriteLine(b);
}

Console.WriteLine("\n----Modifs----\n");

bool rrrr = ClientAPI.PostAddBanqueInscritAsync("ORANGE BANK","1").GetAwaiter().GetResult();
Console.WriteLine("Add banque for user : " + rrrr + "\n");

Console.WriteLine("\n----Verif----\n");

banquesId1 = ClientAPI.GetBanqueAsync("1").GetAwaiter().GetResult();
foreach (Banque b in banquesId1)
{
    Console.WriteLine(b);
}

Console.WriteLine("\n----Modifs----\n");

bool rrrrrr = ClientAPI.DeleteBanqueInscritAsync("ORANGE BANK", "1").GetAwaiter().GetResult();
Console.WriteLine("Del banque for user : " + rrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");

banquesId1 = ClientAPI.GetBanqueAsync("1").GetAwaiter().GetResult();
foreach (Banque b in banquesId1)
{
    Console.WriteLine(b);
}

Console.WriteLine("\n\n\n----Comptes----\n");

IList<Compte> comptes = ClientAPI.GetCompteAsync("1").GetAwaiter().GetResult();
foreach (Compte c in comptes)
{
    Console.WriteLine(c);
}

Console.WriteLine("\n----Modifs----\n");

bool rrrrrrr = ClientAPI.PostAddCompteInscritAsync("PEL","1").GetAwaiter().GetResult();
Console.WriteLine("Add Compte for user : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");

comptes = ClientAPI.GetCompteAsync("1").GetAwaiter().GetResult();
foreach (Compte c in comptes)
{
    Console.WriteLine(c);
}

rrrrrrr = ClientAPI.DeleteCompteInscritAsync("PEL", "1").GetAwaiter().GetResult();
Console.WriteLine("Del Compte for user : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");

comptes = ClientAPI.GetCompteAsync("1").GetAwaiter().GetResult();
foreach (Compte c in comptes)
{
    Console.WriteLine(c);
}

Console.WriteLine("\n\n\n----Operations----\n");

IList<Operation> operations = ClientAPI.GetOperationAsync("1").GetAwaiter().GetResult();
foreach (Operation o in operations)
{
    Console.WriteLine(o);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.PostAddOperationInscritAsync(new Compte("1","PEL"), new Operation("test",100,DateTime.Now,MethodePayement.Cb, TagOperation.Alimentaire, true)).GetAwaiter().GetResult();
Console.WriteLine("Add Ope On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
operations = ClientAPI.GetOperationAsync("1").GetAwaiter().GetResult();
foreach (Operation o in operations)
{
    Console.WriteLine(o);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.DeleteOperationInscritAsync("1", "test").GetAwaiter().GetResult();
Console.WriteLine("Del Ope On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
operations = ClientAPI.GetOperationAsync("1").GetAwaiter().GetResult();
foreach (Operation o in operations)
{
    Console.WriteLine(o);
}

Console.WriteLine("\n\n\n----Planifications----\n");

IList<Planification> planifications = ClientAPI.GetPlanificationAsync("1").GetAwaiter().GetResult();
foreach (Planification p in planifications)
{
    Console.WriteLine(p);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.PostAddPlanificationInscritAsync(new Compte("1", "PEL"), new Planification("test", 100, DateTime.Now, MethodePayement.Cb, TagOperation.Alimentaire, true)).GetAwaiter().GetResult();
Console.WriteLine("Add Pla On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
planifications = ClientAPI.GetPlanificationAsync("1").GetAwaiter().GetResult();
foreach (Planification p in planifications)
{
    Console.WriteLine(p);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.DeletePlanificationInscritAsync("1", "test").GetAwaiter().GetResult();
Console.WriteLine("Del Pla On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
planifications = ClientAPI.GetPlanificationAsync("1").GetAwaiter().GetResult();
foreach (Planification p in planifications)
{
    Console.WriteLine(p);
}

Console.WriteLine("\n\n\n----Echeances----\n");

IList<Echeance> echeances = ClientAPI.GetEcheanceAsync("1").GetAwaiter().GetResult();
foreach (Echeance e in echeances)
{
    Console.WriteLine(e);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.PostAddEcheanceInscritAsync(new Compte("1", "PEL"), new Echeance("test", 100, DateTime.Now, MethodePayement.Cb, TagOperation.Alimentaire, true)).GetAwaiter().GetResult();
Console.WriteLine("Add Ech On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
echeances = ClientAPI.GetEcheanceAsync("1").GetAwaiter().GetResult();
foreach (Echeance e in echeances)
{
    Console.WriteLine(e);
}

Console.WriteLine("\n----Modifs----\n");

rrrrrrr = ClientAPI.DeleteEcheanceInscritAsync("1", "test").GetAwaiter().GetResult();
Console.WriteLine("Del Ech On Compte : " + rrrrrrr + "\n");

Console.WriteLine("\n----Verif----\n");
echeances = ClientAPI.GetEcheanceAsync("1").GetAwaiter().GetResult();
foreach (Echeance e in echeances)
{
    Console.WriteLine(e);
}