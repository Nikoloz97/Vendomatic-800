using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Payment
    {
        public decimal AmountPaid { get; private set; } = 0;
        public decimal Change { get; private set; }
        public decimal BalanceDue { get; private set; } = 0;
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
            return null;

        }

        public string StartTransaction()
        {
            return null;
        }

        public string LogItem()
        {
            return null;
        }
        public string SmallestChange(int _change)
        {
            string result = "";
            if(_change / 25 > 0)
            {
                result += _change / 25 + "Q ";
                _change -= (_change / 25) * 25;
            }
            if(_change / 10 > 0)
            {
                result += _change / 10 + "D ";
                _change -= (_change / 10) * 10;
            }
            if(_change / 5 > 0)
            {
                result += _change / 5 + "N ";
                _change -= (_change / 5) * 5;
            }
            if(_change / 1 > 0)
            {
                result += _change / 1 + "P ";
                _change -= (_change / 1) * 1;
            }
            return result.TrimEnd();
        }
        public void IncreaseFeedMoney()
        {
            AmountPaid++;
        }
        
    }
}
