# Bank Account System

A small C# console app for managing simple bank accounts. Project 1 of my C# object-oriented programming practice series.

## Features

- Create accounts with auto-generated account numbers (`ACC1001`, `ACC1002`, ...)
- Deposit and withdraw money with validation: no zero or negative amounts, no overdrafts
- Check an account balance
- Print a statement showing every transaction and the balance after it

## Run it

**Visual Studio:** open `BankAccountSystem.sln` and press `Ctrl+F5`.

**Command line** (needs the .NET SDK), from the repository root:

```
dotnet run --project BankAccountSystem
```

## Project structure

```
BankAccountSystem/
├── Program.cs       Console menu and user input handling
├── Account.cs       Account class: balance rules, deposit, withdraw
└── Transaction.cs   A single entry in an account statement
```

## Example statement

```
Statement for Asha (ACC1001)
Date               Type                   Amount       Balance
02-Nov-2026 09:46  Opening balance      1,000.00      1,000.00
02-Nov-2026 09:46  Deposit                500.00      1,500.00
02-Nov-2026 09:46  Withdrawal             250.00      1,250.00
Closing balance: 1,250.00
```

## Concepts practised

- Classes and objects, constructors with validation
- Encapsulation: the balance has a `private set`, so it can only change through `Deposit` and `Withdraw`
- Properties, `static` counters, `readonly` fields
- Exceptions with `throw` and `try/catch`
- `List<T>`, `Dictionary<K,V>` and `decimal` for money

## Notes

Accounts are kept in memory only, so all data is lost when the program exits.
