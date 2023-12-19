using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

public class Connection:IDisposable
{
    private readonly string connectionString;
    private readonly SqlConnection sqlConnection;

    public Connection(string connectionString)
    {
        this.connectionString = connectionString;
        this.sqlConnection = new SqlConnection(connectionString);
    }

    public object ExecuteScalar(Command command)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand sqlCommand = CreateSqlCommand(connection, command))
        {
            connection.Open();
            return sqlCommand.ExecuteScalar();
        }
    }

    public IEnumerable<T> ExecuteReader<T>(Command command, Func<IDataRecord, T> map)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand sqlCommand = CreateSqlCommand(connection, command))
        {
            connection.Open();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return map(reader);
                }
            }
        }
    }

    public int ExecuteNonQuery(Command command)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand sqlCommand = CreateSqlCommand(connection, command))
        {
            connection.Open();
            return sqlCommand.ExecuteNonQuery();
        }
    }

    public DataTable GetDataTable(Command command)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand sqlCommand = CreateSqlCommand(connection, command))
        {
            connection.Open();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    private static SqlCommand CreateSqlCommand(SqlConnection connection, Command command)
    {
        SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = command.CommandText;
        sqlCommand.CommandType = command.CommandType;

        foreach (var parameter in command.Parameters)
        {
            sqlCommand.Parameters.Add(parameter);
        }

        return sqlCommand;
    }

    public void Dispose()
    {
        if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
        {
            sqlConnection.Close();
        }
    }
}
