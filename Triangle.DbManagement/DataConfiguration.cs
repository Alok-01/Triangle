
using System.Configuration;

namespace Triangle.DbManagement
{
    /// <summary>
    /// Data Configuration
    /// </summary>
    public class DataConfiguration : IDataConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataConfiguration"/> class.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        public DataConfiguration(string domainName)
        {
            if (domainName == "UnitTest")
            {
                return;
            }

            this.StudentV4Db = GetConnectionString("StudentV4Db");

        }

        public DataConfiguration(string domainName, string connectionString)
        {
            if (domainName == "UnitTest")
            {
                return;
            }

            this.StudentV4Db = GetConnectionString("StudentV4Db");
            this.ProviderName = "Microsoft.Data.SqlClient";
            if (string.IsNullOrEmpty(this.StudentV4Db))
            {
                this.StudentV4Db = GetConnectionString("StudentV4DB", connectionString);
            }
        }

        public string StudentV4Db { get; set; }
        public string ContentV4Db { get; set; }
        public string ProviderName { get; set; }

        /// <summary>
        /// This function extracts a connection string from the Web Config file
        /// It uses bespoke sections because a section may need to be encrypted
        /// and its easier to break the connection strings into dev stage or live environments
        /// </summary>
        /// <param name="database">Database to return connection string for</param>
        /// <returns>Connection String as a string</returns>
        private static string GetConnectionString(string database)
        {
            string connectionstr = string.Empty;
            if (ConfigurationManager.ConnectionStrings[database] != null)
            {
                connectionstr = ConfigurationManager.ConnectionStrings[database].ToString();
            }

            return connectionstr;
        }
        private static string GetConnectionString(string database, string connectionString)
        {
            string connectionstr = connectionString;
            if (ConfigurationManager.ConnectionStrings[database] != null)
            {
                connectionstr = ConfigurationManager.ConnectionStrings[database].ToString();
            }

            return connectionstr;
        }
    }
}