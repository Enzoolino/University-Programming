using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank
{
    public class Account : IAccount
    {
        protected const int PRECISION = 4;

        public string Name { get; }
        public decimal Balance { get; private set; }


        public bool IsBlocked { get; private set; } = false;
        public void Block() => IsBlocked = true;
        public void Unblock() => IsBlocked = false;

        public Account(string name, decimal initialBalance = 0)
        {
            if (name == null || initialBalance < 0)
                throw new ArgumentOutOfRangeException();
            Name = name.Trim();
            if (Name.Length < 3)
                throw new ArgumentException();
            Balance = Math.Round(initialBalance, PRECISION);
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= 0 || IsBlocked) return false;

            Balance = Math.Round(Balance += amount, PRECISION);
            return true;
        }

        public bool Withdrawal(decimal amount)
        {
            if (amount <= 0 || IsBlocked || amount > Balance) return false;

            Balance = Math.Round(Balance -= amount, PRECISION);
            return true;
        }

        public override string ToString() =>
            IsBlocked ? $"Account name: {Name}, balance: {Balance:F2}, blocked"
                        : $"Account name: {Name}, balance: {Balance:F2}";
    }
}