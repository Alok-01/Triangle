using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle.DbManagement
{
    public interface IDataConfiguration
    {
        /// <summary>
        /// Student Database
        /// </summary>
        string StudentV4Db { get; set; }

        /// <summary>
        /// Content Database
        /// </summary>
        string ContentV4Db { get; set; }

        /// <summary>
        /// Provider Name i.e System.Data.SqlClient But in .Core use Microsoft.Data.SqlClient
        /// </summary>
        string ProviderName { get; set; }
    }
}
