using System;

namespace Triangle.DbManagement
{
    public static class Connections
    {
        public static IDataConfiguration Configuration { get; private set; }

        public static void Load(string domainName)
        {
            Configuration = new DataConfiguration(domainName);
        }

        public static void Load(string domainName, string connectionString)
        {
            Configuration = new DataConfiguration(domainName, connectionString);
        }
    }
}
