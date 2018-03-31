using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Contains information about account and methods for working with account.
    /// </summary>
    public abstract class Account
    {
        private int numberOfAccount;
        private PersonalInfo personalInfo;
        private decimal balance;
        private bool isClosed;
        private int bonuses;

        public Account(PersonalInfo personalInfo)
        {
            PersonalInformation = personalInfo;
        }

        /// <summary>
        /// Gets number of Account.
        /// </summary>
        public int NumberOfAccount
        {
            get
            {
                return numberOfAccount;
            }
        }

        /// <summary>
        /// !!!!!!!!!!!!!!!!!!!!!!! Copy
        /// </summary>
        public PersonalInfo PersonalInformation
        {
            get
            {
                return personalInfo;
            }
            private set
            {
                personalInfo = value;
            }
        }

        /// <summary>
        /// Gets client Balance.
        /// </summary>
        public decimal Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                balance = value;
            }
        }

        /// <summary>
        /// Gets client bonuses.
        /// </summary>
        public int Bonuses
        {
            get
            {
                return bonuses;
            }

            private set
            {
                bonuses = value < 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Gets percents for adding/withdrawing.
        /// </summary>
        public abstract int PercentsForSum { get; set; }

        /// <summary>
        /// Gets percents for privilegies.
        /// </summary>
        public abstract int PercentsForPrivilegies { get; set; }

        /// <summary>
        /// Gets information about status of account.
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return isClosed;
            }
            set
            {
                isClosed = value;
            }
        }

        /// <summary>
        /// This method adds money to client balance.
        /// </summary>
        /// <param name="sumOfMoney">Sum of adding money.</param>
        public void Deposit(decimal sumOfMoney)
        {
            if (IsValidBalance())
            {
                Balance += sumOfMoney;
            }

            bonuses += CalculateBonuses(sumOfMoney);
        }

        /// <summary>
        /// This method widthraws money.
        /// </summary>
        /// <param name="sumOfMoney">Sum of deductible money.</param>
        public void WidthRaw(decimal sumOfMoney)
        {
            if (IsValidBalance())
            {
                Balance -= sumOfMoney;
            }

            bonuses -= CalculateBonuses(sumOfMoney);
        }

        /// <summary>
        /// Closes account.
        /// </summary>
        public void CLose()
        {

        }

        /// <summary>
        /// Gets information about client balance.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValidBalance();

        /// <summary>
        /// Calculates bonuses.
        /// </summary>
        /// <param name="sum">Added or widthrawed sum.</param>
        private int CalculateBonuses(decimal sum)
        {
            return PercentsForSum * (int)sum + PercentsForPrivilegies * (int)Balance;
        }
    }
}
