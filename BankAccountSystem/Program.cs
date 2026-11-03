namespace BankAccountSystem
{
    internal class Program  // program class
    {
        private static readonly Dictionary<string, Account> Accounts =
            new Dictionary<string, Account>(StringComparer.OrdinalIgnoreCase);
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                string? choice = ConsoleREadLine();
                Console.WriteLine();

                try
                {
                    switch (choice?.Trim())
                    {
                        case "1": CreateAccount();
                            break;
                        case "2": Deposit();
                            break;
                        case "3": Withdraw();
                            break;
                        case "4": CheckBalance();
                            break;
                        case "5": PrintStatement();
                            break;
                        default: Console.WriteLine("Invalid Choice. Enter a number from the menu.");
                            break;
                    }
                }
                catch (ArguementException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("see ya");
            }

            static void ShowMenu()
            {
                Console.WriteLine("==== BANK ACCOUNT SYSTEM ====");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check balance");
                Console.WriteLine("5. Print Statement");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
            }

            static void CreateAccount()
            {
                string name = ReadText("Holder name: ");
                decimal opening = ReadDecimal("Opening balance (0 for none): ");

                Account account = new Account(name, opening);
                Accounts.Add(account.AccountNumber, account);

                Console.WriteLine($"Account created. Account number: {account.AccountNumber}");

            }
            static void Deposit()
            {
                Account? account = FindAccount();
                if (account == null) return;

                decimal amount = ReadDecimal("Amount to deposit: ");
                account.Deposit(amount);

                Console.WriteLine($"Deposited {amount:N2}. New balance: {account.Balance:N2}")
            }

            static void Withdraw()
            {
                Account? account = FindAccount();
                if (account == null) return;

                decimal amount = ReadDecimal("Amount to withdraw: ");
                account.Withdraw(amount);

                Console.WriteLine($"Deposited {amount:N2}. New balance: {account.Balance:N2}")
            }

            static void CheckBalance()
            {
                Account? account = FindAccount();
                if (account == null) return;

                Console.WriteLine($"{account.HolderName} ({account.AccountNumber}) balance: {account.Balance:N2}");
            }

            static void PrintStatement()
            {
                Account? account = FindAccount();
                if (account == null) return;

                Console.WriteLine($"Statement for {account.HolderName} ({account.AccountNumber})");
                Console.WriteLine("{0,-19}{1,-17}{2,12}{3,14}", "Date", "Type", "Amount", "Balance");

                foreach (Transaction t in account.Transactions)
                {
                    Console.WriteLine("{0,-19:dd-MMM-yyyy HH:mm}{1,-17}{2,12:N2}{3,14:N2}",
                        t.Date, t.Type, t.Amount, t.BalanceAfter);
                }

                Console.WriteLine($"Closing balance: {account.Balance:N2}");
            }

            static Account? FindAccount()
            {
                string number = ReadText("Account number: ");

                if (Accounts.TryGetValue(number, out Account? account))
                    return account;
                Console.WriteLine("No account found with that number.");
                return null;
            }

            static string ReadText(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string? text = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(text))
                        return text.Trim();

                    Console.WriteLine("This field cannotbe empty.");
                }
            }

            static decimal ReadDecimal(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);

                    if (decimal.TryParse(Console.ReadLine(), out decimal value))
                        return value;

                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}
