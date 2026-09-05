public class BankAccount
{
    public string Owner { get; private set; }
    
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal startingBalance)
    {
        if (startingBalance < 0)
        {
            throw new ArgumentException("Starting balance cannot be less than 0.");
        }
        Owner = owner;
        Balance = startingBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit sum must be greater than 0.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Deposited £{amount}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount cannot be less than 0");
            return;
        }

        if (Balance - amount < 0)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Withdrew £{amount}");
    }

    public void ShowBalance()
    {
        Console.WriteLine($"{Owner}'s balance: {Balance}");
    }
}