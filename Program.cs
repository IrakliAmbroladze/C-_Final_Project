namespace final_project
{
    interface ITransaction
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Insufficient funds in the account.") { }
    }

    abstract class Account : ITransaction
    {
        public string Owner { get; }
        public decimal Balance { get; protected set; }
        protected Account(string owner, decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(initialBalance));
            Owner = owner;
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            Balance += amount;
        }
        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (amount > Balance)
                throw new InsufficientFundsException();

            Balance -= amount;
        }
        public virtual void Display()
        {
            Console.WriteLine(
                $"{Owner}: balance = {Balance:F2}");
        }
    }
    class SavingsAccount : Account
    {
        public SavingsAccount(string owner, decimal balance)
            : base(owner, balance)
        {
        }
        public override void Display()
        {
            Console.WriteLine(
                $"Savings account — {Owner}: {Balance:F2}");
        }
    }
    class CheckingAccount : Account
    {
        public CheckingAccount(string owner, decimal balance)
            : base(owner, balance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);
        }
        public override void Display()
        {
            Console.WriteLine(
                $"Checking account — {Owner}: {Balance:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            Account savings = new SavingsAccount("Anna", 600m);
            Account checking = new CheckingAccount("David", 500m);
            savings.Deposit(200m);
            checking.Withdraw(100m);
            savings.Display();
            checking.Display();
            try
            {
                Console.WriteLine($"\nTrying to wothdraw {1000m}");
                checking.Withdraw(1000m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
