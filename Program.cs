// Program.cs
using System;

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        Customer customer1 = new Customer(1, "John Doe");
        Customer customer2 = new Customer(2, "Jane Smith");

        bank.AddCustomer(customer1);
        bank.AddCustomer(customer2);

        bank.OpenAccount(customer1, 1000);
        bank.OpenAccount(customer2, 500);

        bank.PerformTransaction(1, 500, TransactionType.Withdraw);
        bank.PerformTransaction(2, 200, TransactionType.Deposit);

        Console.ReadLine();
    }
}
