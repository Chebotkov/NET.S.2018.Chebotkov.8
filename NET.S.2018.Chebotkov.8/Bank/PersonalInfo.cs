using System;

namespace Bank
{
    /// <summary>
    /// Cotains information about client.
    /// </summary>
    public class PersonalInfo
    {
        #region Fields
        private string firstName;
        private string lastName;
        private string patronymic;
        private string passportNumber;
        private string email;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalInfo"/>
        /// </summary>
        /// <param name="firstName">Сlient first name.</param>
        /// <param name="lastName">Сlient last name.</param>
        /// <param name="patronymic">Сlient patronymic.</param>
        /// <exception cref="ArgumentNullException">Throws when entered Full name isn't full or passport nubmer is null.</exception>
        public PersonalInfo(string firstName, string lastName, string patronymic, string passportNumber, string email)
        {
            if (firstName is null || lastName is null || patronymic is null)
            {
                throw new ArgumentNullException("Information about client must be full.");
            }

            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException("Passport number can't be null.");
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.patronymic = patronymic;
            this.passportNumber = passportNumber;
            this.email = email;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets client first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
        }

        /// <summary>
        /// Gets client last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
        }

        /// <summary>
        /// Gets client patronymic.
        /// </summary>
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
        }

        /// <summary>
        /// Gets client passport number.
        /// </summary>
        public string PassportNumber
        {
            get
            {
                return passportNumber;
            }
        }

        /// <summary>
        /// Gets client email.
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
        }
        #endregion
    }
}
