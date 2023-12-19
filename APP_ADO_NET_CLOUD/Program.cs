using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

//string connectionString = @"Server=(LocalDB)\BStormLocalDB;Database=ADO;Trusted_Connection=True;TrustServerCertificate=True";
string connectionString = @"Data Source=(localdb)\BStormLocalDB;Initial Catalog=ADO;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

#region Demo Execute Connecté
//using (SqlConnection connection = new SqlConnection(connectionString))
//{

//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT * FROM STUDENT";

//        // Permet de récupérer plusieurs enregistrements
//        //command.ExecuteReader(); 

//        // Permet de récupérer une seule donnée
//        //command.ExecuteScalar();

//        // Va retourner le nombre lignes affectées
//        //command.ExecuteNonQuery();


//    }
//};



//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT [Id],[FirstName] " +
//                              "FROM STUDENT";

//        connection.Open();
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                int id = (int)reader["Id"];
//                string firstName = reader["FirstName"].ToString();

//                Console.WriteLine($"L'étudiant N°{id} s'appel {firstName}");
//            }
//        }
//    }
//};

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT COUNT(*) " +
//                              "FROM SECTION";

//        connection.Open();
//        int nombreSection = (int)command.ExecuteScalar();

//        Console.WriteLine($"Il y a {nombreSection} sections");
//    }
//};

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "UPDATE STUDENT SET Active = 1 " +
//                              "WHERE Id = 25";

//        connection.Open();
//        int lignes = command.ExecuteNonQuery();

//        Console.WriteLine($"{lignes} ligne(s) affectée(s)");
//    }
//};
#endregion

#region Demo Déconnecté

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = connection.CreateCommand())
//    {

//        command.CommandText = "SELECT [Id] ,[FirstName] FROM [Student]";

//        SqlDataAdapter da = new SqlDataAdapter();
//        da.SelectCommand = command;

//        DataSet ds = new DataSet();

//        da.Fill(ds);

//        if (ds.Tables.Count > 0)
//        {
//            foreach (DataRow row in ds.Tables[0].Rows)
//            {

//                Console.WriteLine($"Id : {row["Id"]} - : Prenom : {row["FirstName"]}");
//            };
//        };
//    };

//}

#endregion

#region requete parametre

//int idParam = 25;

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT Id, FirstName, LastName FROM V_Student WHERE Id = @Id";

//        command.Parameters.AddWithValue("@Id", idParam);

//        connection.Open();
//        using(SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                int id = (int)reader["Id"];
//                string firstName = (string)reader["FirstName"];
//                string lastName = (string)reader["LastName"];

//                Console.WriteLine($"Id : {id} - Prenom : {firstName} - Nom : {lastName}");
//            }
//        }
//    }
//}





#endregion


#region DBNull vs Null

//using(SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT [FirstName] , [LastName],[YearResult] " +
//                              "FROM V_Student";

//        connection.Open();
//        using(SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                string prenom = (string)reader["FirstName"];
//                string nom = (string)reader["LastName"];
//                int? note = (reader["YearResult"] is DBNull ? null : (int)reader["YearResult"]);

//                if(note is null)
//                {
//                    Console.WriteLine($"{prenom} {nom} n'a pas encore de note cette année ");
//                }
//                else
//                {
//                    Console.WriteLine($"{prenom} {nom} a une note de {note}/20 pour cette année ");
//                }
//            }
//        }
//    }
//}

#endregion

#region procedure stockee


//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using(SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "AddStudent";
//        command.CommandType = CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@FirstName", "Jane");
//        command.Parameters.AddWithValue("@LastName", "Doe");
//        command.Parameters.AddWithValue("@BirthDate", new DateTime(2004, 01,12));
//        command.Parameters.AddWithValue("@YearResult", 14);
//        command.Parameters.AddWithValue("@SectionId", 1010);

//        connection.Open();
//        int id = (int)command.ExecuteScalar();

//        Console.WriteLine("La personne a été ajouté à l'id "+ id);
//    }
//}



#endregion

int modifiedRows;
using(SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    using(SqlTransaction transaction = connection.BeginTransaction())
    {
        using(SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "DELETE FROM Student WHERE Id = 10";
            command.Parameters.AddWithValue("@LastName", "Strawberry");
            command.Transaction = transaction;

            modifiedRows = command.ExecuteNonQuery();
            Console.WriteLine(modifiedRows);

        }

        if(modifiedRows > 1)
        {
            transaction.Rollback();
        }
        else
        {
            transaction.Commit();
        }
    }
}