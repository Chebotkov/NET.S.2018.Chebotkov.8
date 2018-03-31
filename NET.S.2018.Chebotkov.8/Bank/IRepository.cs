namespace Bank
{
    /// <summary>
    /// Contains methods for working with client account.
    /// </summary>
    interface IRepository
    {
        /// <summary>
        /// Closes account.
        /// </summary>
        void Close();

        void Read();

        /// <summary>
        /// Updates information in client account.
        /// </summary>
        void Update();

        /// <summary>
        /// Deletes client account.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets client account.
        /// </summary>
        /// <returns>Returns client account.</returns>
        Account Get();
    }
}
