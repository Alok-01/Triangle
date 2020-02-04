using System;
using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Triangle.DbManagement
{
    public static class GenericDataAccess
    {

        public static DataSet SelectSqlRows(string connectionString, string queryString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);

                //code to modify data in DataSet here

                builder.GetUpdateCommand();

                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet, tableName);

                return dataSet;
            }
        }
        public static TransferableDataSet ExecuteMultipleSelectCommands(SqlCommand command)
        {
            // The DataTable to be returned 
            using (DataSet ds = new DataSet())
            {
                ds.Locale = CultureInfo.CurrentCulture;

                // Execute the command making sure the connection gets closed in the end
                try
                {
                    // Open the data connection 
                    command.Connection.Open();

                    using (SqlDataAdapter adpData = new SqlDataAdapter((SqlCommand)command))
                    {
                        adpData.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    DataErrorLogger.LogError(ex);
                    throw;
                }
                finally
                {
                    // Close the connection
                    command.Connection.Close();
                }

                return new TransferableDataSet(ds);
            }
        }


        public static TransferableDataTable ExecuteSelectCommand(SqlCommand command)
        {
            // The DataTable to be returned 
            using (DataTable table = new DataTable())
            {
                // Execute the command making sure the connection gets closed in the end
                try
                {
                    // Open the data connection 
                    command.Connection.Open();

                    // Execute the command and save the results in a DataTable

                    SqlDataReader reader = command.ExecuteReader();
                    table.Locale = CultureInfo.CurrentCulture;
                    table.Load(reader);

                    // Close the reader 
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DataErrorLogger.LogError(ex);
                    throw;
                }
                finally
                {
                    // Close the connection
                    command.Connection.Close();
                }

                return new TransferableDataTable(table);
            }
        }


        public static int ExecuteNonQuery(SqlCommand command)
        {
            // The number of affected rows 
            int affectedRows = -1;

            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();

                // Execute the command and get the number of affected rows
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them
                DataErrorLogger.LogError(ex);
                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }

            // return the number of affected rows
            return affectedRows;
        }


        public static string ExecuteScalar(SqlCommand command)
        {
            // The value to be returned 
            object result = null;
            string value = string.Empty;

            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();

                // Execute the command and get the number of affected rows
                result = command.ExecuteScalar();
                if (result != null)
                {
                    value = result.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them
                DataErrorLogger.LogError(ex);
                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }

            // return the result
            return value;
        }


        public static SqlCommand CreateCommand(string connectionString)
        {
            return CreateCommand(Connections.Configuration.ProviderName, connectionString);
        }


        public static SqlCommand CreateCommand(string dataProviderName, string connectionString)
        {
            //// Create a new data provider factory
            //DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

            //// Obtain a database specific connection object
            //DbConnection conn = factory.CreateConnection();

            //// Set the connection string
            //conn.ConnectionString = connectionString;

            //// Create a database specific command object
            //SqlCommand comm = conn.CreateCommand();

            //// Set the command type to stored procedure
            //comm.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;


            // Return the initialized command object
            return comm;
        }


        public static void AddParamWithValue(this IDbCommand command, string parameterName, DbType parameterType, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = parameterType;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }


        public static void AddParamWithValue(this IDbCommand command, string parameterName, DbType parameterType, object value, ParameterDirection direction)
        {
            command.AddParamWithValue(parameterName, parameterType, value, direction, null);
        }


        public static void AddParamWithValue(this IDbCommand command, string parameterName, DbType parameterType, object value, ParameterDirection direction, int? size)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = parameterType;
            parameter.Value = value;
            if (size.HasValue)
            {
                parameter.Size = size.Value;
            }

            parameter.Direction = direction;
            command.Parameters.Add(parameter);
        }
    }
}
