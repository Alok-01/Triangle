using Triangle.DbManagement;

namespace Triangle.Common
{
    public static class ConnectionFactory
    {
        public static void Initialize()
        {
            Initialize(string.Empty);
        }

        public static void Initialize(string domainName)
        {
            Connections.Load(domainName);
        }
        public static void Initialize(string domainName, string connectionString)
        {
            Connections.Load(domainName, connectionString);
        }
    }
}
