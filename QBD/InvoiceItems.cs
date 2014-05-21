using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBD
{
    class InvoiceItems
    {
        private string item;

        public string Item
        {
            get { return item; }
            set { item = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string amount;

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string tax;

        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        public InvoiceItems()
        {
            this.Description = string.Empty;
            this.Amount = string.Empty;
            this.Tax = string.Empty;
            this.Item = string.Empty;
        }

    }
}
