using System.Data;
using System.Data.SqlClient;

namespace kristofferhusdata.Data
{
    public class DatabaseQuerys
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClimateInformation;Integrated Security=False;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void RunQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public T SelectQuery<T>(string query, string col)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        T eksempel = (T)reader[col];
                        return eksempel;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return default(T);
        }

        public DataTable PullTable(SqlCommand command)
        {

            DataTable table = new DataTable();
            Console.WriteLine(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                    connection.Close();
                    da.Dispose();
                } catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return table;
            }

        }

        public void InsertToTable(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteRow(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
