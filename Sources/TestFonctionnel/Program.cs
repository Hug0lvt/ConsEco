using Data;
using Model;

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