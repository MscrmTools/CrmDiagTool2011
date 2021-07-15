using System;
using System.Data;
using System.Data.SqlClient;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class is used to retrieve data from a database
    /// </summary>
    class DatabaseHelper
    {
        /// <summary>
        /// Executes a query and returns the data as a datatable
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="query">Query to execute</param>
        /// <returns>Result of the query</returns>
        internal static DataTable ExecuteQuery(string connectionString, string query)
        {
            try
            {
                // If the connection string contains a provider, we remove it as the
                // SqlConnection doesn't support the use of a provider
                if (connectionString.StartsWith("Provider=SQLOLEDB;"))
                {
                    connectionString = connectionString.Replace("Provider=SQLOLEDB;", "");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    da.Fill(ds, "myTable");

                    return ds.Tables[0];
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error while querying a database: " + error.Message, error);
            }
        }
    }
}
