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
    public class LoadOperation
    {
        public static IList<Operation> LoadOperationsFromOFX(string csv)
        {
            //liste des opérations d'un compte
            IList<Operation> lesOpe = new List<Operation>();

            //détail d'une Operation
            string intituleOperation;
            double montant;
            DateTime dateOperation;
            MethodePayement modePayement;
            bool isDebit;


            //info compte
            string identifiantCompte="";
            double solde=0;

            using (StreamReader reader = new StreamReader(csv))
            {
                if (reader != null)
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        if (row.Contains("<CURDEF>"))
                        {
                            row = "";
                        }
                        else if (row.Contains("<ACCTID>"))
                        {
                            identifiantCompte = CutRow(row).Last();
                        }
                        else if (row.Contains("<BALAMT>"))
                        {
                            solde = Convert.ToDouble(GetValueInRow(row, 4));
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
                                        modePayement = MethodePayement.Cb;
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
                            lesOpe.Add(new Operation(intituleOperation, identifiantCompte, montant, dateOperation, modePayement, isDebit));
                        }
                        else
                        {
                            row = "";
                        }
                    }
                }
            }
            return lesOpe;
            
        }

        public static string[] CutRow(string row) 
        {
            string[] cutRow;
            if (row == null) throw new ArgumentNullException();
            cutRow = row.Split('>');
            return cutRow;
        }

        public static string GetValueInRow(string row, int position) 
        {
            string value;
            string[] cutedRow = CutRow(row);
            if (cutedRow != null)
            {
                if(cutedRow.Count() > position || position < 0) throw new IndexOutOfRangeException();
                value = cutedRow[position];
                return value;
            }

            throw new ArgumentNullException();
            
        }
    }
}
