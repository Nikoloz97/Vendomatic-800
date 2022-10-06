using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Payment
    {
        public decimal AmountPaid { get; private set; }
        public decimal Change { get; private set; }
        public decimal BalanceDue { get; private set; }
        public DateTime Time { get; private set; }

        public void CalculateChange(decimal amountPaid, decimal balanceDue)
        {
            if (ValidTransaction(amountPaid, balanceDue))
            {
            
            AmountPaid = amountPaid;
            BalanceDue = balanceDue;

            Change = amountPaid - balanceDue;
            }
        }

        public bool ValidTransaction(decimal amountPaid, decimal balanceDue)
        {
            return amountPaid >= balanceDue;


        }

        public string DisplayMessage()
        {

        }

        public string StartTransaction()
        {

        }

        public string LogItem()
        {

        }

    }
}
