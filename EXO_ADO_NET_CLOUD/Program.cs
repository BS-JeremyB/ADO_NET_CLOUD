
using ADO_TOOLBOX.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=(localdb)\BStormLocalDB;Initial Catalog=ADO;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

#region Exo 2 - Page 78
//using (SqlConnection connection = new SqlConnection(connectionString))
//{

//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT [Id], [LastName] as Nom, [FirstName] as Prenom " +
//                              "FROM V_Student";


//        connection.Open();
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                int id = (int)reader["Id"];
//                string nom = (string)reader["Nom"];
//                string prenom = (string)reader["Prenom"];


//                Console.WriteLine($"Id : {id} - Nom : {nom} - prenom {prenom}");

//            }
//        }
//    }

//}
#endregion

#region Exo 3 - Page 78

//using(SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT [Id], [LastName] as Nom " +
//                              "FROM V_Student";

//        SqlDataAdapter adapter = new SqlDataAdapter();
//        adapter.SelectCommand = command;

//        DataSet ds = new DataSet();

//        adapter.Fill(ds);

//        if(ds.Tables.Count > 0)
//        {
//            foreach (DataRow row in ds.Tables[0].Rows)
//            {
//                int id = (int)row["Id"];
//                string nom = (string)row["Nom"];

//                Console.WriteLine($"Id : {id} - Nom : {nom}");
//            }
//        }
//    }
//}



#endregion

#region Exo 4 - Page 78


//using(SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT AVG(YearResult) " +
//                              "FROM V_Student";

//        connection.Open();
//        double moyenne = (int)command.ExecuteScalar();
//        Console.WriteLine("La moyenne est de "+moyenne);

//    }
//}

#endregion

#region Exo5 - Page 86

//Student student = new Student("Jeremy","Bazin", new DateTime(1990,06,19), 15, 1010,true);
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "INSERT INTO Student output inserted.Id " +
//                              "Values( " +
//                              $"'{student.FirstName}', " +
//                              $"'{student.LastName}', " +
//                              $"'{student.BirthDate:yyyy-MM-dd}', " +
//                              $"{student.YearResult}, " +
//                              $"{student.SectionId}, " +
//                              $"{(student.Active ? 1 : 0)}" +
//                              $" )";

//        connection.Open();
//        int id = (int)command.ExecuteScalar();
//        student.Id = id;
//        Console.WriteLine(student.ToString());
//    }
//}


#endregion

#region Exo6 - Page 96


//Student student = new Student("John", "Doe", new DateTime(2000, 04, 15), 12, 1010, true);
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "INSERT INTO Student output inserted.Id " +
//                              "Values(@Firstname,@LastName,@BirthDate,@YearResult,@SectionId,@Active)";

//        command.Parameters.AddWithValue("@FirstName", student.FirstName);
//        command.Parameters.AddWithValue("@LastName", student.LastName);
//        command.Parameters.AddWithValue("@BirthDate", student.BirthDate);
//        command.Parameters.AddWithValue("@YearResult", student.YearResult);
//        command.Parameters.AddWithValue("@SectionId", student.SectionId);
//        command.Parameters.AddWithValue("@Active", student.Active);

//        connection.Open();
//        int id = (int)command.ExecuteScalar();
//        student.Id = id;
//        Console.WriteLine(student.ToString());
//    }
//}


#endregion

#region Exo 7 - Page 108


//int id = 25;

//using(SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT [YearResult] " +
//                              "FROM [Student] " +
//                              "WHERE Id = @Id";

//        command.Parameters.AddWithValue("@Id", id);
//        connection.Open();
//        int yearResult = (int)command.ExecuteScalar();
//        connection.Close();
//        command.Parameters.Clear();

//        command.CommandText = "UpdateStudent";
//        command.CommandType = CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@Id", id);
//        command.Parameters.AddWithValue("@SectionId", 1120);
//        command.Parameters.AddWithValue("@YearResult", yearResult);

//        connection.Open();
//        int modifiedRows = command.ExecuteNonQuery();

//        Console.WriteLine(modifiedRows);

//    }
//}


#endregion

#region Exo 8 - Page 108



int id = 25;

using (SqlConnection connection = new SqlConnection(connectionString))
{
    using (SqlCommand command = connection.CreateCommand())
    {

        command.CommandText = "DeleteStudent";
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);


        connection.Open();
        int modifiedRows = command.ExecuteNonQuery();

        Console.WriteLine(modifiedRows);

    }
}

#endregion