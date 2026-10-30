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

        public void Print() { Console.WriteLine($"Счет {_id} Тип: {_type} Баланс: {_balance}"); }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account1 = new BankAccount();
            account1.SetData(15000.50m, AccountType.Current);
            account1.Print();

            BankAccount account2 = new BankAccount();
            account2.SetData(500m, AccountType.Savings);
            account2.Print();
        }
    }
}
