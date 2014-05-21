using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBD
{
    class Invoice
    {
        string txnID;

        public string TxnID
        {
            get { return txnID; }
            set { txnID = value; }
        }
        string timeCreated;

        public string TimeCreated
        {
            get { return timeCreated; }
            set { timeCreated = value; }
        }
        string timeModified;

        public string TimeModified
        {
            get { return timeModified; }
            set { timeModified = value; }
        }
        string editSequence;

        public string EditSequence
        {
            get { return editSequence; }
            set { editSequence = value; }
        }
        string txnNumber;

        public string TxnNumber
        {
            get { return txnNumber; }
            set { txnNumber = value; }
        }
        string customerRef_ListID;

        public string CustomerRef_ListID
        {
            get { return customerRef_ListID; }
            set { customerRef_ListID = value; }
        }
        string aRAccountRef_ListID;

        public string ARAccountRef_ListID
        {
            get { return aRAccountRef_ListID; }
            set { aRAccountRef_ListID = value; }
        }
        string templateRef_ListID;

        public string TemplateRef_ListID
        {
            get { return templateRef_ListID; }
            set { templateRef_ListID = value; }
        }
        string txnDate;

        public string TxnDate
        {
            get { return txnDate; }
            set { txnDate = value; }
        }
        string refNumber;

        public string RefNumber
        {
            get { return refNumber; }
            set { refNumber = value; }
        }
        string billAddress_Addr1;

        public string BillAddress_Addr1
        {
            get { return billAddress_Addr1; }
            set { billAddress_Addr1 = value; }
        }
        string billAddress_Addr2;

        public string BillAddress_Addr2
        {
            get { return billAddress_Addr2; }
            set { billAddress_Addr2 = value; }
        }
        string billAddress_City;

        public string BillAddress_City
        {
            get { return billAddress_City; }
            set { billAddress_City = value; }
        }
        string billAddress_State;

        public string BillAddress_State
        {
            get { return billAddress_State; }
            set { billAddress_State = value; }
        }
        string billAddress_PostalCode;

        public string BillAddress_PostalCode
        {
            get { return billAddress_PostalCode; }
            set { billAddress_PostalCode = value; }
        }
        string billAddressBlock_Addr1;

        public string BillAddressBlock_Addr1
        {
            get { return billAddressBlock_Addr1; }
            set { billAddressBlock_Addr1 = value; }
        }
        string billAddressBlock_Addr2;

        public string BillAddressBlock_Addr2
        {
            get { return billAddressBlock_Addr2; }
            set { billAddressBlock_Addr2 = value; }
        }
        string billAddressBlock_Addr3;

        public string BillAddressBlock_Addr3
        {
            get { return billAddressBlock_Addr3; }
            set { billAddressBlock_Addr3 = value; }
        }
        string isPending;

        public string IsPending
        {
            get { return isPending; }
            set { isPending = value; }
        }
        string isFinanceCharge;

        public string IsFinanceCharge
        {
            get { return isFinanceCharge; }
            set { isFinanceCharge = value; }
        }
        string dueDate;

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        string shipDate;

        public string ShipDate
        {
            get { return shipDate; }
            set { shipDate = value; }
        }
        string subtotal;

        public string Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        string itemSalesTaxRef_ListID;

        public string ItemSalesTaxRef_ListID
        {
            get { return itemSalesTaxRef_ListID; }
            set { itemSalesTaxRef_ListID = value; }
        }
        string salesTaxPercentage;

        public string SalesTaxPercentage
        {
            get { return salesTaxPercentage; }
            set { salesTaxPercentage = value; }
        }
        string salesTaxTotal;

        public string SalesTaxTotal
        {
            get { return salesTaxTotal; }
            set { salesTaxTotal = value; }
        }
        string appliedAmount;

        public string AppliedAmount
        {
            get { return appliedAmount; }
            set { appliedAmount = value; }
        }
        string balanceRemaining;

        public string BalanceRemaining
        {
            get { return balanceRemaining; }
            set { balanceRemaining = value; }
        }
        string isPaid;

        public string IsPaid
        {
            get { return isPaid; }
            set { isPaid = value; }
        }
        string isToBePrinted;

        public string IsToBePrinted
        {
            get { return isToBePrinted; }
            set { isToBePrinted = value; }
        }
        string isToBeEmailed;

        public string IsToBeEmailed
        {
            get { return isToBeEmailed; }
            set { isToBeEmailed = value; }
        }
        string customerSalesTaxCodeRef_ListID;

        public string CustomerSalesTaxCodeRef_ListID
        {
            get { return customerSalesTaxCodeRef_ListID; }
            set { customerSalesTaxCodeRef_ListID = value; }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                ret = name + " = " + value + Environment.NewLine;
            }
            return ret;

        }

        public List<InvoiceItems> InvoiceItems;

        public Invoice()
        {
            this.TxnID = string.Empty;
            this.TimeCreated = string.Empty;
            this.TimeModified = string.Empty;
            this.EditSequence = string.Empty;
            this.TxnNumber = string.Empty;
            this.CustomerRef_ListID = string.Empty;
            this.ARAccountRef_ListID = string.Empty;
            this.TemplateRef_ListID = string.Empty;
            this.TxnDate = string.Empty;
            this.RefNumber = string.Empty;
            this.BillAddress_Addr1 = string.Empty;
            this.BillAddress_Addr2 = string.Empty;
            this.BillAddress_City = string.Empty;
            this.BillAddress_State = string.Empty;
            this.BillAddress_PostalCode = string.Empty;
            this.BillAddressBlock_Addr1 = string.Empty;
            this.BillAddressBlock_Addr2 = string.Empty;
            this.BillAddressBlock_Addr3 = string.Empty;
            this.IsPending = string.Empty;
            this.IsFinanceCharge = string.Empty;
            this.DueDate = string.Empty;
            this.ShipDate = string.Empty;
            this.Subtotal = string.Empty;
            this.ItemSalesTaxRef_ListID = string.Empty;
            this.SalesTaxPercentage = string.Empty;
            this.SalesTaxTotal = string.Empty;
            this.AppliedAmount = string.Empty;
            this.BalanceRemaining = string.Empty;
            this.IsPaid = string.Empty;
            this.IsToBePrinted = string.Empty;
            this.IsToBeEmailed = string.Empty;
            this.CustomerSalesTaxCodeRef_ListID = string.Empty;
            this.InvoiceItems = new List<InvoiceItems>();
        }

    }
}
