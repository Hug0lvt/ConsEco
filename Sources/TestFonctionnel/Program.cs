using Data;
using Model;

Console.WriteLine("Test Deserializer OFX - simplifié");

IList<Operation> operations= new List<Operation>();
operations.Add(new Operation("OpeDeTest", "01234567890", 100, DateTime.Now, MethodePayement.Esp, true));


operations = LoadOperation.LoadOperationsFromOFX("C:\\Dev\\ConsEcoAndMAUI\\Sources\\TestFonctionnel\\CA_simplifié.ofx");


foreach (Operation op in operations)
{
    Console.WriteLine(op);
}