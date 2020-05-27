namespace hapi.context
{
    /// <summary>
    ///     <c>ConnectionContext</c> class.
    ///     Przechowuje string służący do łączenia się z bazą danych.
    /// </summary>
    public class ConnectionContext
    {
        /// <summary>
        ///     Tworzy nową instancję instance klasy <see cref="ConnectionContext" />.
        /// </summary>
        /// <param name="connectionString">String do połączenia się z bazą danych.</param>
        public ConnectionContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString { get; set; }
    }
}