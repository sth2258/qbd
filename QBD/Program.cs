using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBXMLRP2Lib;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;


namespace QBD
{
    class Program
    {


        static void Main(string[] args)
        {

            //            RequestProcessor2 rp = null;

            //            string ticket = null;

            //            try
            //            {
            //                rp = new RequestProcessor2();
            //                rp.OpenConnection("", "IDN CustomerAdd C# sample");
            //                ticket = rp.BeginSession("Z:\\Haber Electric 2013.QBW", QBFileMode.qbFileOpenDoNotCare);

            //                Random random = new Random();

            //                string invoiceinput = @"<?xml version=""1.0"" encoding=""utf-8""?>
            //                                <?qbxml version=""8.0""?>
            //                                <QBXML>
            //            	                    <QBXMLMsgsRq onError=""stopOnError"">
            //            		                    <InvoiceQueryRq requestID=""1"">
            //                                            <IncludeLineItems>true</IncludeLineItems>
            //            		                    </InvoiceQueryRq>
            //            	                    </QBXMLMsgsRq>
            //                                </QBXML>";

            //                string customerinput = @"<?xml version=""1.0"" encoding=""utf-8""?>
            //            <?qbxml version=""8.0""?>
            //            <QBXML>
            //              <QBXMLMsgsRq onError=""stopOnError"">
            //                <CustomerQueryRq requestID=""1234abcd"">
            //                  
            //                </CustomerQueryRq>  
            //              </QBXMLMsgsRq>
            //            </QBXML>";


            //                //ExecuteStatement("Z:\\CustomerXML.xml", customerinput, ref ticket, ref rp);
            //                ExecuteStatement("Z:\\InvoicesXML.xml", invoiceinput, ref ticket, ref rp);


            //            }

            //            catch (System.Runtime.InteropServices.COMException ex)
            //            {
            //                Console.WriteLine(ex);
            //            }
            //            finally
            //            {
            //                if (ticket != null)
            //                {
            //                    rp.EndSession(ticket);
            //                }

            //                if (rp != null)
            //                {
            //                    rp.CloseConnection();
            //                }
            //            }

            XMLTranslateInvoice("Z:\\InvoicesXML.xml");

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }

        private static void ExecuteStatement(string outputFile, string XMLInput, ref string ticket, ref RequestProcessor2 rp)
        {
            string response = rp.ProcessRequest(ticket, XMLInput);

            //Console.WriteLine(response);
            StreamWriter wrt = new StreamWriter(outputFile);
            wrt.WriteLine(response);
            wrt.Flush();
            wrt.Close();

        }

        private static void XMLTranslateInvoice(string file)
        {
            ArrayList list = new ArrayList();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            foreach (XmlNode node in doc.SelectNodes("QBXML/QBXMLMsgsRs/InvoiceQueryRs/InvoiceRet"))
            {
                Invoice a = new Invoice();
                a.TxnID = node["TxnID"].InnerText;
                a.TimeCreated = node["TimeCreated"].InnerText;
                a.TimeModified = node["TimeModified"].InnerText;
                a.EditSequence = node["EditSequence"].InnerText;
                a.TxnNumber = node["TxnNumber"].InnerText;
                a.CustomerRef_ListID = node["CustomerRef"].ChildNodes[0].InnerText;
                a.ARAccountRef_ListID = node["ARAccountRef"].ChildNodes[0].InnerText;
                a.TemplateRef_ListID = node["TemplateRef"].ChildNodes[0].InnerText;
                a.TxnDate = node["TxnDate"].InnerText;
                a.RefNumber = node["RefNumber"].InnerText;
                try { a.BillAddress_Addr1 = node["BillAddress"].ChildNodes[0].InnerText; }
                catch { }
                try { a.BillAddress_Addr2 = node["BillAddress"].ChildNodes[1].InnerText; }
                catch { }
                try { a.BillAddress_City = node["BillAddress"].ChildNodes[2].InnerText; }
                catch { }
                try { a.BillAddress_State = node["BillAddress"].ChildNodes[3].InnerText; }
                catch { }
                try { a.BillAddress_PostalCode = node["BillAddress"].ChildNodes[4].InnerText; }
                catch { }
                try { a.BillAddressBlock_Addr1 = node["BillAddressBlock"].ChildNodes[0].InnerText; }
                catch { }
                try { a.BillAddressBlock_Addr2 = node["BillAddressBlock"].ChildNodes[1].InnerText; }
                catch { }
                try { a.BillAddressBlock_Addr3 = node["BillAddressBlock"].ChildNodes[2].InnerText; }
                catch { }
                a.IsPending = node["IsPending"].InnerText;
                a.IsFinanceCharge = node["IsFinanceCharge"].InnerText;
                a.DueDate = node["DueDate"].InnerText;
                a.ShipDate = node["ShipDate"].InnerText;
                a.Subtotal = node["Subtotal"].InnerText;
                a.ItemSalesTaxRef_ListID = node["ItemSalesTaxRef"].ChildNodes[0].InnerText;
                a.SalesTaxPercentage = node["SalesTaxPercentage"].InnerText;
                a.SalesTaxTotal = node["SalesTaxTotal"].InnerText;
                a.AppliedAmount = node["AppliedAmount"].InnerText;
                a.BalanceRemaining = node["BalanceRemaining"].InnerText;
                a.IsPaid = node["IsPaid"].InnerText;
                a.IsToBePrinted = node["IsToBePrinted"].InnerText;
                a.IsToBeEmailed = node["IsToBeEmailed"].InnerText;
                a.CustomerSalesTaxCodeRef_ListID = node["CustomerSalesTaxCodeRef"].ChildNodes[0].InnerText;

                foreach (XmlNode itemNode in node.SelectNodes("./InvoiceLineRet"))
                {

                    InvoiceItems ii = new InvoiceItems();
                    if (itemNode.SelectNodes("./Desc").Count == 1)
                    {
                        ii.Description = itemNode["Desc"].InnerText;
                    }
                    if (itemNode.SelectNodes("./Amount").Count == 1)
                    {
                        ii.Amount = itemNode["Amount"].InnerText;
                    }
                    if (itemNode.SelectNodes("./ItemRef").Count == 1)
                    {
                        ii.Item = itemNode.SelectNodes("./ItemRef")[0]["FullName"].InnerText;
                    }
                    if (itemNode.SelectNodes("./SalesTaxCodeRef").Count == 1)
                    {
                        ii.Tax = itemNode.SelectNodes("./SalesTaxCodeRef")[0]["FullName"].InnerText;
                    }
                    if (ii.Tax != string.Empty || ii.Item != string.Empty || ii.Amount != string.Empty || ii.Description != string.Empty)
                    {
                        a.InvoiceItems.Add(ii);
                    }




                }

                list.Add(a);

                /*foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(a))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(a);
                    Console.WriteLine(name + " = " + value + Environment.NewLine);
                }*/
            }
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QBData;Integrated Security=True");
            conn.Open();


            //cmd.Prepare();

            foreach (Invoice a in list)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Invoices (TxnID,TimeCreated,TimeModified,EditSequence,TxnNumber,CustomerRef_ListID,ARAccountRef_ListID,TemplateRef_ListID,TxnDate,RefNumber,BillAddress_Addr1,BillAddress_Addr2,BillAddress_City,BillAddress_State,BillAddress_PostalCode,BillAddressBlock_Addr1,BillAddressBlock_Addr2,BillAddressBlock_Addr3,IsPending,IsFinanceCharge,DueDate,ShipDate,Subtotal,ItemSalesTaxRef_ListID,SalesTaxPercentage,SalesTaxTotal,AppliedAmount,BalanceRemaining,IsPaid,IsToBePrinted,IsToBeEmailed,CustomerSalesTaxCodeRef_ListID) VALUES (@TxnID, @TimeCreated, @TimeModified, @EditSequence, @TxnNumber, @CustomerRef_ListID, @ARAccountRef_ListID, @TemplateRef_ListID, @TxnDate, @RefNumber, @BillAddress_Addr1, @BillAddress_Addr2, @BillAddress_City, @BillAddress_State, @BillAddress_PostalCode, @BillAddressBlock_Addr1, @BillAddressBlock_Addr2, @BillAddressBlock_Addr3, @IsPending, @IsFinanceCharge, @DueDate, @ShipDate, @Subtotal, @ItemSalesTaxRef_ListID, @SalesTaxPercentage, @SalesTaxTotal, @AppliedAmount, @BalanceRemaining, @IsPaid, @IsToBePrinted, @IsToBeEmailed, @CustomerSalesTaxCodeRef_ListID)";
                cmd.Parameters.AddWithValue("@TxnID", a.TxnDate);
                cmd.Parameters.AddWithValue("@TimeCreated", a.TimeCreated);
                cmd.Parameters.AddWithValue("@TimeModified", a.TimeModified);
                cmd.Parameters.AddWithValue("@EditSequence", a.EditSequence);
                cmd.Parameters.AddWithValue("@TxnNumber", a.TxnNumber);
                cmd.Parameters.AddWithValue("@CustomerRef_ListID", a.CustomerRef_ListID);
                cmd.Parameters.AddWithValue("@ARAccountRef_ListID", a.ARAccountRef_ListID);
                cmd.Parameters.AddWithValue("@TemplateRef_ListID", a.TemplateRef_ListID);
                cmd.Parameters.AddWithValue("@TxnDate", a.TxnDate);
                cmd.Parameters.AddWithValue("@RefNumber", a.RefNumber);
                cmd.Parameters.AddWithValue("@BillAddress_Addr1", a.BillAddress_Addr1);
                cmd.Parameters.AddWithValue("@BillAddress_Addr2", a.BillAddress_Addr2);
                cmd.Parameters.AddWithValue("@BillAddress_City", a.BillAddress_City);
                cmd.Parameters.AddWithValue("@BillAddress_State", a.BillAddress_State);
                cmd.Parameters.AddWithValue("@BillAddress_PostalCode", a.BillAddress_PostalCode);
                cmd.Parameters.AddWithValue("@BillAddressBlock_Addr1", a.BillAddressBlock_Addr1);
                cmd.Parameters.AddWithValue("@BillAddressBlock_Addr2", a.BillAddressBlock_Addr2);
                cmd.Parameters.AddWithValue("@BillAddressBlock_Addr3", a.BillAddressBlock_Addr3);
                cmd.Parameters.AddWithValue("@IsPending", a.IsPending);
                cmd.Parameters.AddWithValue("@IsFinanceCharge", a.IsFinanceCharge);
                cmd.Parameters.AddWithValue("@DueDate", a.DueDate);
                cmd.Parameters.AddWithValue("@ShipDate", a.ShipDate);
                cmd.Parameters.AddWithValue("@Subtotal", a.Subtotal);
                cmd.Parameters.AddWithValue("@ItemSalesTaxRef_ListID", a.ItemSalesTaxRef_ListID);
                cmd.Parameters.AddWithValue("@SalesTaxPercentage", a.SalesTaxPercentage);
                cmd.Parameters.AddWithValue("@SalesTaxTotal", a.SalesTaxTotal);
                cmd.Parameters.AddWithValue("@AppliedAmount", a.AppliedAmount);
                cmd.Parameters.AddWithValue("@BalanceRemaining", a.BalanceRemaining);
                cmd.Parameters.AddWithValue("@IsPaid", a.IsPaid);
                cmd.Parameters.AddWithValue("@IsToBePrinted", a.IsToBePrinted);
                cmd.Parameters.AddWithValue("@IsToBeEmailed", a.IsToBeEmailed);
                cmd.Parameters.AddWithValue("@CustomerSalesTaxCodeRef_ListID", a.CustomerSalesTaxCodeRef_ListID);

                Console.WriteLine(cmd.ExecuteNonQuery());
                cmd.Dispose();
                cmd = null;

                foreach (InvoiceItems ii in a.InvoiceItems)
                {
                    SqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "INSERT INTO InvoiceItems (Item, Description, Amount, Tax, RefNumber) VALUES (@Item, @Desc, @Amount, @Tax, @RefNumber)";
                    cmd2.Parameters.AddWithValue("@Item", ii.Item);
                    cmd2.Parameters.AddWithValue("@Desc", ii.Description);
                    cmd2.Parameters.AddWithValue("@Amount", ii.Amount);
                    cmd2.Parameters.AddWithValue("@Tax", ii.Tax);
                    cmd2.Parameters.AddWithValue("@RefNumber", a.RefNumber);
                    Console.WriteLine(cmd2.ExecuteNonQuery());
                    cmd2.Dispose();
                    cmd2 = null;
                }
            }
            conn.Close();

        }
    }
}
