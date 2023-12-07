// Bank.cs
using System;
using System.Collections.Generic;

public class Bank
{
    private List<Customer> customers;
    private List<Account> accounts;

    public Bank()
    {
        customers = new List<Customer>();
        accounts = new List<Account>();
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void OpenAccount(Customer customer, decimal initialBalance)
    {
        if (customers.Contains(customer))
        {
            int accountNumber = accounts.Count + 1;
            Account account = new Account(accountNumber, customer, initialBalance);
            accounts.Add(account);
            Console.WriteLine($"Account opened for {customer.Name} with Account Number {accountNumber}");
        }
        else
        {
            Console.WriteLine("Customer not found. Please add the customer first.");
        }
    }

    public void PerformTransaction(int accountNumber, decimal amount, TransactionType transactionType)
    {
        Account account = accounts.Find(a => a.AccountNumber == accountNumber);

        if (account != null)
        {
            switch (transactionType)
            {
                case TransactionType.Deposit:
                    account.Deposit(amount);
                    Console.WriteLine($"Deposited {amount:C} to Account {accountNumber}. New balance: {account.Balance:C}");
                    break;

                case TransactionType.Withdraw:
                    if (account.Withdraw(amount))
                    {
                        Console.WriteLine($"Withdrawn {amount:C} from Account {accountNumber}. New balance: {account.Balance:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Insufficient funds in Account {accountNumber}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid transaction type.");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"Account with number {accountNumber} not found.");
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdraw
}
