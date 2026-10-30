using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework6
{
    public enum AccountType
    {
        Current,
        Savings
    }
    public class BankAccount
    {
        private static int _nextId = 1;
        private int _id;
        private decimal _balance;
        private AccountType _type;

        private static int GenerateId() { return _nextId++; }

        public void SetData(decimal balance, AccountType type)
        {
            _id = GenerateId();
            _balance = balance;
            _type = type;
        }

        public int GetId() { return _id; }
        public decimal GetBalance() { return _balance; }
        public AccountType GetAccountType() { return _type; }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public void Print() { Console.WriteLine($"Счет: {_id} Тип: {_type} Баланс: {_balance}"); }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();
            account.SetData(10000m, AccountType.Current);

            account.Print();

            account.Deposit(5000m);
            account.Print();

            account.Withdraw(2000m);
            account.Print();

            account.Withdraw(50000m);
            account.Print();
        }
    }
}
