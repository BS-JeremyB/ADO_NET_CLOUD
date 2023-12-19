using EXO_ADO_NET_CLOUD.Entities;
using System.Data;

public class StudentMapper
{
    public static Student Map(IDataRecord record)
    {
        
        int id = (int)record["Id"];
        string firstName = record["FirstName"].ToString();
        string lastName = record["LastName"].ToString();
        DateTime birthDate = (DateTime)record["BirthDate"];
        int yearResult = (int)record["YearResult"];
        int sectionId = (int)record["SectionId"];
        bool active = (bool)record["Active"];

        return new Student(firstName, lastName, birthDate, yearResult, sectionId, active);
    }
}