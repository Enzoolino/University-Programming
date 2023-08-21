using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class AccountPlus : Account, IAccountWithLimit
    {

        private decimal _onetimedebetlimit;

        public decimal OneTimeDebetLimit
        {
            get => _onetimedebetlimit;

            set
            {
                if (_onetimedebetlimit >= 0 && !IsBlocked)
                {
                    _onetimedebetlimit = value;
                }

                AvaibleFounds = _onetimedebetlimit + Balance;
            }
        }

        public decimal AvaibleFounds { get; private set; }


        //NIE WIEM CZY POTRZEBNE
        public new decimal Balance { get; set; }

        public new bool IsBlocked { get; private set; } = false;


        public AccountPlus(string name, decimal initialBalance = 0, decimal initialLimit = 100 )
            :base (name, initialBalance)
        {
            if ( initialLimit < 0)
                _onetimedebetlimit = 0;
            else
                _onetimedebetlimit = initialLimit;

            Balance = initialBalance;

            AvaibleFounds = _onetimedebetlimit + Balance;

            

            
        }

        public new bool Withdrawal(decimal amount)
        {
            if (amount <= 0 || IsBlocked) return false;
            else if (amount > AvaibleFounds) return false;
            else if (amount > Balance && amount < AvaibleFounds)
            {
                AvaibleFounds -= amount;
                Balance -= amount;

                if (Balance < 0) Balance = 0;

                if (AvaibleFounds < OneTimeDebetLimit)
                {
                    this.Block();
                    return true;
                }
            }
            else
            {
                AvaibleFounds -= amount;
                Balance -= amount;
                return true;
            }

            return base.Withdrawal(amount);
       
        }


        public new bool Deposit(decimal amount)
        {

            if (amount <= 0 ) return false;
            else if (AvaibleFounds <= OneTimeDebetLimit)
            {
                AvaibleFounds += amount;

                if (AvaibleFounds >= OneTimeDebetLimit)
                {
                    Unblock();
                    Balance += (AvaibleFounds - OneTimeDebetLimit);
                    return true;
                }
            }
            else
            {
                AvaibleFounds += amount;
                Balance += amount;
                return true;
            }

            return base.Deposit(amount);
  
        }

        public new void Block() => IsBlocked = true;

        public new void Unblock()
        {
            if (AvaibleFounds >= OneTimeDebetLimit)
            {
                IsBlocked = false;
            }
        }

        public override string ToString()
        {
            if (!IsBlocked)
                return $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
            else
                return $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
        }


        }
}
