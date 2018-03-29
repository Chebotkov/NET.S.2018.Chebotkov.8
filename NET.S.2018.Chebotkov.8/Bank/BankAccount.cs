using System;

namespace Bank
{
    /// <summary>
    /// Types of a client account.
    /// </summary>
    public enum Gradation { Base, Silver, Gold, Platinum };

    /// <summary>
    /// This class contains information about client and methods for different operations with client account.
    /// </summary>
    public class BankAccount
    {
        #region fields
        private int balance = 0;
        private int bonuses = 0;
        private Gradation accountType = Gradation.Base;
        private long id;
        private string firstName;
        private string lastName;
        private string patronymic;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/>
        /// </summary>
        /// <param name="firstName">Сlient first name.</param>
        /// <param name="lastName">Сlient last name.</param>
        /// <param name="patronymic">Сlient patronymic.</param>
        /// <exception cref="ArgumentNullException">Throws when entered Full name isn't full.</exception>
        public BankAccount(string firstName, string lastName, string patronymic)
        {
            if (firstName == null || lastName == null || patronymic == null)
            {
                throw new ArgumentNullException("Information about client must be full.");
            }

            this.firstName = String.Copy(firstName);
            this.lastName = String.Copy(lastName);
            this.patronymic = String.Copy(patronymic);
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets client Balance.
        /// </summary>
        public int Balance
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
        /// Gets client account type. 
        /// </summary>
        public Gradation AccountType
        {
            get
            {
                return accountType;
            }
            private set
            {
                accountType = value;
            }
        }

        /// <summary>
        /// Gets client identifier.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets client first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return String.Copy(firstName);
            }
        }

        /// <summary>
        /// Gets client last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return String.Copy(lastName);
            }
        }

        /// <summary>
        /// Gets client patronymic.
        /// </summary>
        public string Patronymic
        {
            get
            {
                return String.Copy(patronymic);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// This method adds money to client balance.
        /// </summary>
        /// <param name="sumOfMoney">Sum of adding money.</param>
        public void TopUpAnAccount(int sumOfMoney)
        {
            Balance += sumOfMoney;
            Bonuses += CalculateAmountOfBonuses(sumOfMoney, true);
        }

        /// <summary>
        /// This method widthraws money.
        /// </summary>
        /// <param name="sumOfMoney">Sum of deductible money.</param>
        public void Withdraw(int sumOfMoney)
        {
            Balance -= sumOfMoney;
            Bonuses -= CalculateAmountOfBonuses(sumOfMoney, false);
        }

        /// <summary>
        /// Sets type of account. 
        /// </summary>
        /// <param name="gradation">Account gradation.</param>
        public void SetGradation(Gradation gradation)
        {
            AccountType = gradation;
        }

        /// <summary>
        /// Create new bank account.
        /// </summary>
        /// <param name="firstName">Сlient first name.</param>
        /// <param name="lastName">Сlient last name.</param>
        /// <param name="patronymic">Сlient patronymic.</param>
        /// <returns>New bank account.</returns>
        /// <exception cref="ArgumentNullException">Throws when entered Full name isn't full.</exception>
        public BankAccount GetNewBankAccount(string firstName, string lastName, string patronymic)
        {
            if (firstName == null || lastName == null || patronymic == null)
            {
                throw new ArgumentNullException("Information about client must be full.");
            }

            return new BankAccount(firstName, lastName, patronymic);
        }

        /// <summary>
        /// This method closes bank account. 
        /// </summary>
        /// <returns>Returns null.</returns>
        public BankAccount CloseAccount()
        {
            return null;
        }
        #endregion

        #region private method
        /// <summary>
        /// This method calculates bonuses.
        /// </summary>
        /// <param name="sum">Sum of money.</param>
        /// <param name="isPut">Is sum putting or widthraw.</param>
        /// <returns>Returns amount of bonuses.</returns>
        private int CalculateAmountOfBonuses(int sum, bool isPut)
        {
            double percentFofSum = 0.005;
            double somePercent = 0.05;
            int privilegies;
            double percentForGradation;
            if (isPut)
            {
                privilegies = (int)AccountType * 2 + 2;
                percentForGradation = privilegies;
            }
            else
            {
                privilegies = (int)Gradation.Platinum * 2 + 2 - (int)AccountType * 2;
                percentForGradation = 1.0 / 8.0 * privilegies;
            }

            return (int)((percentFofSum * sum + somePercent) * percentForGradation);
        }
        #endregion
    }
}
