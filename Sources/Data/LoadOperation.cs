using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data
{
    public static class LoadOperation
    {
        public static IList<Compte> LoadOperationsFromOFX(string ofx)
        {
            IList<Compte> lesComptes = new List<Compte>();

            Compte compteEnCoursDeSaisie = null;

            //détail d'une Operation
            string intituleOperation;
            double montant;
            DateTime dateOperation;
            MethodePayement modePayement;
            bool isDebit;

            //info compte
            string identifiantCompte="";

            using (StreamReader reader = new StreamReader(ofx))
            {
                if (reader != null)
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        if (row.Contains("<STMTTRNRS>"))
                        {
                            compteEnCoursDeSaisie = new Compte(identifiantCompte, identifiantCompte, 0);
                            
                        } 
                        else if (row.Contains("</STMTTRNRS>")){
                            lesComptes.Add(compteEnCoursDeSaisie);
                        }
                        else if (row.Contains("<ACCTID>") || row.Contains("<CURDEF>"))
                        {
                            compteEnCoursDeSaisie.Identifiant = CutRow(row).Last();
                            compteEnCoursDeSaisie.Nom = CutRow(row).Last();

                        }
                        else if (row.Contains("<BALAMT>"))
                        {
                            compteEnCoursDeSaisie.Solde = double.Parse(CutRow(row).Last(), CultureInfo.InvariantCulture);
                        }
                        else if (row.Contains("<STMTTRN>"))
                        {
                            row = "";
                            intituleOperation = "";
                            montant = 0;
                            dateOperation = new DateTime();
                            modePayement = MethodePayement.None;
                            isDebit = false;
                            while ((row = reader.ReadLine()) != "</STMTTRN>")
                            {
                                if (row.Contains("<DTPOSTED>"))
                                {
                                    DateTime.TryParseExact(CutRow(row).Last(), "yyyyMMdd", null, DateTimeStyles.None, out dateOperation);
                                }
                                else if (row.Contains("<TRNAMT>"))
                                {
                                    montant = double.Parse(CutRow(row).Last(), CultureInfo.InvariantCulture);
                                    if (montant < 0)
                                    {
                                        isDebit = true;
                                        montant = Math.Abs(montant);
                                    }
                                }
                                else if (row.Contains("<NAME>"))
                                {
                                    intituleOperation = CutRow(row).Last();
                                }
                                else if (row.Contains("<MEMO>"))
                                {
                                    if (row.Contains("PAIEMENT"))
                                    {
                                        modePayement = MethodePayement.CB;
                                    }
                                    else
                                    {
                                        modePayement = MethodePayement.None;
                                    }

                                }
                                else
                                {
                                    row = "";
                                }
                            }
                            compteEnCoursDeSaisie.ajouterOperation(new Operation(intituleOperation, montant, dateOperation, modePayement, TagOperation.None, isDebit));
                        }
                        else
                        {
                            row = "";
                        }
                    }
                }
            }
            return lesComptes;
            
        }

        private static string[] CutRow(string row) 
        {
            string[] cutRow;
            if (row == null) throw new ArgumentNullException();
            cutRow = row.Split('>');
            return cutRow;
        }

    }
}
