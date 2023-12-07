// Account.cs
public class Account
{
    public int AccountNumber { get; }
    public Customer Owner { get; }
    public decimal Balance { get; private set; }

    public Account(int accountNumber, Customer owner, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}
