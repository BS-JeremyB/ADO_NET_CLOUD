using Microsoft.Data.SqlClient;
using System.Data;

public class Command
{
    public string CommandText { get; set; }
    public CommandType CommandType { get; set; }
    public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

    public void AddParameter(string name, object value)
    {
        Parameters.Add(new SqlParameter(name, value));
    }
}