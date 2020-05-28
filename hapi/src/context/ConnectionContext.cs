namespace hapi.context
{
    public class ConnectionContext
    {
        public ConnectionContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString { get; set; }
    }
}