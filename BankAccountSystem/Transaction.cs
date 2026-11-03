using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSystem // project name 
{
    internal class Transaction // class of transaction 
    {
        public DateTime Date { get;  } // properties of the transaction 
        public string Type { get;  } // get is used as it is read only and f
                                     // further the detail wont be chnaged in future 
        public decimal Amount { get;  }
        public decimal BalanceAfter { get;  }

        public Transaction(string type, decimal amount, decimal balanceAfter) 
        // simple constructor running eventually whenever the tractions class is called.
        {
            Date = DateTime.Now; // stores the bvalue of the current date and time 
            Type = type; // take the information given to the contructor and store it 
            Amount = amount; // in the transaction.
            BalanceAfter = balanceAfter;
        }
    }
}
