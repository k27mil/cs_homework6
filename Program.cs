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
        private int _id;
        private decimal _balance;
        private AccountType _type;

        public void SetData(int id, decimal balance, AccountType type)
        {
            _id = id;
            _balance = balance;
            _type = type;
        }
        public int GetId() { return _id; }

        public decimal GetBalance() { return _balance; }

        public AccountType GetAccountType() { return _type; }

        public void Print()
        {
            Console.WriteLine($"Счет: {_id} Тип: {_type} Баланс: {_balance}");
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();

            account.SetData(1001, 15000.50m, AccountType.Current);
            account.Print();
        }
    }
}
