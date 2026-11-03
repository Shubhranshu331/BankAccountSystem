using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSystem
{
    internal class Account // class account
    {
        private static int _lastNumber = 1000; // private means only availble and accessible in the particular class only (track of acct numbers) static means value is shared with accounts 
        private readonly List<Transaction> _transactions = new List<Transaction>(); // list of transactions like in python = self.transaction = [] 

        // Account information 
        public string AccountNumber { get; } // can be read only but cant be changed directly
        public string HolderName { get; } // same as above
        public decimal Balance { get; private set; } // can be read only but can be changed in account class 
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly(); // giving access to transactions safety, giving other parts to see the transaction not modify  

        public Account(String holderName, decimal openingBalance = 0m) // Account contructor runs when new account is created.
            // 0m means opening account balance is optional 
        {
            if (string.IsNullOrWhiteSpace(holderName)) // checking holder's name
                throw new ArguementException("Holder name is required.");
            if (openingBalance < 0) // checking opening balance
                throw new ArgumentException("Opening balancecannot be negative.");

            _lastNumber++;
            AccountNumber = "ACC" + _lastNumber; // creating new account number 
            HolderName = holderName.Trim(); // cleaning and storing the name
            Balance = openingBalance; // setting the opeining balance 
            Record("Opening balance", openingBalance);
        }

        public void Deposit(decimal amount) // method to add money to the account 
        {
            if (amount <= 0) // deosit money > 0
                throw new ArguementException("Deposit amount must be greater than zero.");

            Balance += amount;
            Record("Deposit", amount);
        }
        public void Withdraw(decimal amount) // withdrawl moeny 
        {
            if (amount <= 0) // amount shouldnt be 0
                throw new ArguementException("Withdrawal amount must be greater than zero.");
            if (amount > Balance) // balance should cover the amont 
                throw new InvalidOperationException($"Insufficient funds. Available balance: {Balance:N2}");

            Balance -= amount;
            Record("Withdrawl", amount);
        }

        private void Record(string type, decimal amount) // record method adds new transaction and adds to the trans. list 
        {
            _transactions.Add(new Transaction(type, amount, Balance)); // appending it to the list
        }
    }
}