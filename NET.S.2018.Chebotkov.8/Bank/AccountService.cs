using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Contains servant methods.
    /// </summary>
    class AccountService
    {
        /// <summary>
        /// Opens new account.
        /// </summary>
        /// <param name="gradation">Type of account.</param>
        public Account OpenAccount(Gradation gradation, PersonalInfo personalInfo)
        {
            switch(gradation)
            {
                case Gradation.Base:
                    {
                        return new BaseAccount(personalInfo);
                    }
                case Gradation.Silver:
                    {
                        return new SilverAccount(personalInfo);
                    }
                case Gradation.Gold:
                    {
                        return new GoldAccount(personalInfo);
                    }
                case Gradation.Platinum:
                    {
                        return new PlatinumAccount(personalInfo);
                    }
                default:
                    {
                        return new BaseAccount(personalInfo);
                    }
            }
        }

        /// <summary>
        /// Closes some account.
        /// </summary>
        /// <param name="account">Account.</param>
        public void CloseAccount(Account account)
        {
            account = null;
        }

        /// <summary>
        /// Adds money to some account.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="sum">Sum of adding money</param>
        public void DepositAccount(Account account, decimal sum)
        {
            account.Deposit(sum);
        }

        /// <summary>
        /// Widthraws money.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="sumOfMoney">Sum of deductible money.</param>
        public void WidthrawAccount(Account account, decimal sum)
        {
            account.WidthRaw(sum);
        }

        /// <summary>
        /// Transfer money from one account to another.
        /// </summary>
        /// <param name="fromAccount">Sender.</param>
        /// <param name="toAccount">Receiving account.</param>
        /// <param name="sum">Sum of transaction</param>
        public void Transaction(Account fromAccount, Account toAccount, decimal sum)
        {
            fromAccount.WidthRaw(sum);
            toAccount.Deposit(sum);
        }
    }
}
