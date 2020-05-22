using System;
using System.Collections.Generic;
using System.Text;

namespace hapi.context
{
    public class ConnectionContext
    {
        public string connectionString { get; set; }

        public ConnectionContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
