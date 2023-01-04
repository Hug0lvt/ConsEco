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